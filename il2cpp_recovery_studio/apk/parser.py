"""APK Parser – Phase 1 of IL2CPP Recovery Studio.

Provides robust APK / XAPK validation, extraction and automatic detection
of Unity version, build type, architecture, package metadata and key IL2CPP /
Mono artefacts.

Supports:
- Standard APK files
- XAPK split APK bundles (multiple APKs inside one ZIP)
"""
from __future__ import annotations

import hashlib
import re
import struct
import time
import zipfile
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.apk.binary_xml import AndroidBinaryXMLParser
from il2cpp_recovery_studio.apk.models import (
    APKEntry,
    APKInfo,
    AndroidManifest,
    Architecture,
    BuildType,
    NativeLibrary,
    ProtectionType,
    UnityBuildInfo,
)
from il2cpp_recovery_studio.core.config import AppConfig
from il2cpp_recovery_studio.core.exceptions import (
    APKCorruptedError,
    APKNotFoundError,
    APKValidationError,
)
from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("apk.parser")

UNITY_VERSION_RE = re.compile(r"(\d{4})\.(\d)\.(\d+)([f\d]*)")
KNOWN_METADATA_PATHS = (
    "assets/bin/Data/Managed/Metadata/global-metadata.dat",
    "assets/bin/Data/global-metadata.dat",
)
KNOWN_IL2CPP_LIB_PATHS = (
    "lib/arm64-v8a/libil2cpp.so",
    "lib/armeabi-v7a/libil2cpp.so",
    "lib/x86/libil2cpp.so",
    "lib/x86_64/libil2cpp.so",
)
KNOWN_ASSEMBLY_PATHS = (
    "assets/bin/Data/Managed/Assembly-CSharp.dll",
    "assets/bin/Data/Managed/asmdef/Assembly-CSharp.dll",
)
UNITY_ASSET_INDICATORS = (
    "assets/bin/Data/",
    "lib/",
    "assets/bin/",
    "res/",
    "META-INF/",
)
ANDROID_MANIFEST_PATH = "AndroidManifest.xml"
CLASSES_DEX_PATTERNS = re.compile(r"^classes\d*\.dex$")
UNITY_VERSION_FILES = (
    "assets/bin/Data/settings.asset",
    "assets/bin/Data/unity default resources",
    "globalgamemanagers",
    "globalgamemanagers.assets",
)


class APKParser:
    """High-level APK / XAPK parser.

    Usage::

        parser = APKParser(config=AppConfig())
        info = parser.parse("/path/to/game.apk")
        print(info.unity_build.unity_version)
    """

    def __init__(self, config: Optional[AppConfig] = None) -> None:
        self._config = config or AppConfig()
        self._max_file_size = int(self._config.analysis.max_file_size_gb * (1 << 30))

    # ------------------------------------------------------------------
    # Public API
    # ------------------------------------------------------------------

    def parse(self, apk_path: str | Path) -> APKInfo:
        """Parse the given APK or XAPK and return a fully-populated :class:`APKInfo`.

        Supports standard APK files and XAPK split APK bundles.

        Raises
        ------
        APKNotFoundError
            If the file does not exist.
        APKValidationError
            If the file is not a valid ZIP archive.
        """
        apk_path = Path(apk_path).resolve()
        logger.info("Starting APK parse: %s", apk_path)

        info = APKInfo(file_path=apk_path)

        if not apk_path.exists():
            raise APKNotFoundError(f"APK not found: {apk_path}")

        file_size = apk_path.stat().st_size
        info.file_size = file_size
        if file_size > self._max_file_size:
            info.warnings.append(
                f"File size ({file_size / (1 << 30):.2f} GB) exceeds configured limit "
                f"({self._max_file_size / (1 << 30):.2f} GB). Processing may be slow."
            )
        logger.info("File size: %.2f MB", file_size / (1 << 20))

        if not self._validate_zip(apk_path):
            raise APKValidationError(f"Not a valid ZIP/APK: {apk_path}")
        info.is_valid_zip = True
        logger.info("ZIP validation passed")

        # Detect if this is an XAPK bundle
        inner_apks = self._detect_xapk(apk_path)
        if inner_apks:
            info = self._parse_xapk(apk_path, info, inner_apks)
        else:
            info = self._parse_single_apk(apk_path, info)

        logger.info(
            "APK parse complete - %d entries, %d warnings",
            len(info.all_entries),
            len(info.warnings),
        )
        return info

    # ------------------------------------------------------------------
    # Single APK parsing
    # ------------------------------------------------------------------

    def _parse_single_apk(self, apk_path: Path, info: APKInfo) -> APKInfo:
        """Parse a standard single-APK file."""
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                for entry in zf.infolist():
                    info.all_entries.append(
                        APKEntry(
                            path=entry.filename,
                            uncompressed_size=entry.file_size,
                            compressed_size=entry.compress_size,
                            crc32=entry.CRC,
                        )
                    )
        except zipfile.BadZipFile as exc:
            raise APKCorruptedError(f"Corrupted APK: {exc}") from exc

        logger.info("Enumerated %d ZIP entries", len(info.all_entries))

        info.manifest = self._parse_manifest(apk_path)
        logger.info(
            "Package: %s  version: %s (%d)",
            info.manifest.package_name,
            info.manifest.version_name,
            info.manifest.version_code,
        )

        info.native_libraries = self._detect_native_libs(info.all_entries)
        info.detected_architectures = list(
            {lib.architecture for lib in info.native_libraries if lib.architecture != Architecture.UNKNOWN}
        )
        logger.info("Detected architectures: %s", [a.name for a in info.detected_architectures])

        info.unity_build = self._detect_unity(apk_path, info)
        info.unity_assets_found = self._find_unity_assets(info.all_entries)

        logger.info(
            "Unity version: %s  IL2CPP: %s  Mono: %s",
            info.unity_build.unity_version or "N/A",
            info.unity_build.is_il2cpp,
            info.unity_build.is_mono,
        )
        return info

    # ------------------------------------------------------------------
    # XAPK (split APK bundle) parsing
    # ------------------------------------------------------------------

    @staticmethod
    def _detect_xapk(apk_path: Path) -> list[str]:
        """Detect if the ZIP is an XAPK bundle (contains .apk files at root)."""
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                apk_files = [n for n in zf.namelist() if n.endswith(".apk")]
                if apk_files:
                    return apk_files
        except (zipfile.BadZipFile, OSError):
            pass
        return []

    def _parse_xapk(self, xapk_path: Path, info: APKInfo, inner_apks: list[str]) -> APKInfo:
        """Parse an XAPK bundle by merging data from all inner APKs."""
        logger.info("XAPK bundle detected with %d inner APKs: %s", len(inner_apks), inner_apks)

        # Enumerate top-level XAPK entries
        try:
            with zipfile.ZipFile(str(xapk_path), "r") as zf:
                for entry in zf.infolist():
                    info.all_entries.append(
                        APKEntry(
                            path=entry.filename,
                            uncompressed_size=entry.file_size,
                            compressed_size=entry.compress_size,
                            crc32=entry.CRC,
                        )
                    )
        except zipfile.BadZipFile as exc:
            raise APKCorruptedError(f"Corrupted XAPK: {exc}") from exc

        # Sort inner APKs: prefer the main APK (usually the largest or named with package)
        main_apk_name = self._find_main_apk(inner_apks)
        other_apks = [n for n in inner_apks if n != main_apk_name]
        ordered_apks = [main_apk_name] + other_apks if main_apk_name else inner_apks

        # Merge entries from all inner APKs
        all_inner_entries: list[APKEntry] = []
        manifest_apk_path: Optional[Path] = None

        for apk_name in ordered_apks:
            try:
                with zipfile.ZipFile(str(xapk_path), "r") as xapk_zf:
                    raw_apk = xapk_zf.read(apk_name)
            except (zipfile.BadZipFile, KeyError) as exc:
                logger.warning("Failed to extract inner APK %s: %s", apk_name, exc)
                info.errors.append(f"Failed to extract {apk_name}: {exc}")
                continue

            import tempfile
            import os

            tmp = os.path.join(tempfile.gettempdir(), f"il2cpp_recovery_{apk_name.replace('/', '_')}")
            with open(tmp, "wb") as f:
                f.write(raw_apk)

            try:
                with zipfile.ZipFile(tmp, "r") as inner_zf:
                    for entry in inner_zf.infolist():
                        prefixed = f"[{apk_name}]/{entry.filename}"
                        info.all_entries.append(
                            APKEntry(
                                path=prefixed,
                                uncompressed_size=entry.file_size,
                                compressed_size=entry.compress_size,
                                crc32=entry.CRC,
                            )
                        )
                        all_inner_entries.append(
                            APKEntry(
                                path=entry.filename,
                                uncompressed_size=entry.file_size,
                                compressed_size=entry.compress_size,
                                crc32=entry.CRC,
                            )
                        )
            except zipfile.BadZipFile as exc:
                logger.warning("Corrupted inner APK %s: %s", apk_name, exc)
                info.errors.append(f"Corrupted inner APK {apk_name}")
                continue

            # Use this inner APK for manifest if it has one and we haven't found a manifest yet
            if manifest_apk_path is None:
                try:
                    with zipfile.ZipFile(tmp, "r") as inner_zf:
                        if ANDROID_MANIFEST_PATH in inner_zf.namelist():
                            manifest_apk_path = Path(tmp)
                except (zipfile.BadZipFile, OSError):
                    pass

        logger.info("Enumerated %d entries from %d inner APKs", len(info.all_entries), len(inner_apks))

        # Parse manifest from the main APK
        if manifest_apk_path is not None:
            info.manifest = self._parse_manifest(manifest_apk_path)
        else:
            info.manifest = AndroidManifest()

        logger.info(
            "Package: %s  version: %s (%d)",
            info.manifest.package_name,
            info.manifest.version_name,
            info.manifest.version_code,
        )

        # Detect native libraries and architectures from merged entries
        info.native_libraries = self._detect_native_libs(info.all_entries)
        info.detected_architectures = list(
            {lib.architecture for lib in info.native_libraries if lib.architecture != Architecture.UNKNOWN}
        )
        logger.info("Detected architectures: %s", [a.name for a in info.detected_architectures])

        # Detect Unity build from the merged entry set
        info.unity_build = self._detect_unity_from_entries(info.all_entries, xapk_path, info)
        info.unity_assets_found = self._find_unity_assets(info.all_entries)

        logger.info(
            "Unity version: %s  IL2CPP: %s  Mono: %s",
            info.unity_build.unity_version or "N/A",
            info.unity_build.is_il2cpp,
            info.unity_build.is_mono,
        )
        return info

    @staticmethod
    def _find_main_apk(inner_apks: list[str]) -> str:
        """Heuristic: the main APK is usually the largest or has the longest name."""
        # Prefer APKs that look like the package (contain a dot-separated name, not 'config')
        for apk in inner_apks:
            basename = Path(apk).stem
            if "." in basename and not basename.startswith("config") and "UnityData" not in basename:
                return apk
        # Fall back to largest name (most likely the main package)
        if inner_apks:
            return max(inner_apks, key=len)
        return ""

    # ------------------------------------------------------------------
    # Internal helpers
    # ------------------------------------------------------------------

    @staticmethod
    def _validate_zip(path: Path) -> bool:
        """Return True if *path* is a readable ZIP file."""
        try:
            with zipfile.ZipFile(str(path), "r") as zf:
                bad = zf.testzip()
                return bad is None
        except (zipfile.BadZipFile, OSError):
            return False

    # ── Manifest parsing ─────────────────────────────────────────────

    def _parse_manifest(self, apk_path: Path) -> AndroidManifest:
        """Extract high-level manifest data.

        Tries binary XML parsing first.  Falls back to regex scanning of
        the raw bytes for critical values.
        """
        manifest = AndroidManifest()
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                if ANDROID_MANIFEST_PATH not in zf.namelist():
                    logger.warning("AndroidManifest.xml not found in APK")
                    return manifest
                raw = zf.read(ANDROID_MANIFEST_PATH)
        except (zipfile.BadZipFile, OSError) as exc:
            logger.error("Failed to read AndroidManifest.xml: %s", exc)
            return manifest

        parser = AndroidBinaryXMLParser(raw)
        result = parser.parse()
        attrs = result.get("attributes", {})

        manifest.package_name = (
            attrs.get("package")
            or attrs.get("{http://schemas.android.com/apk/res/android}package", "")
        )
        manifest.version_name = (
            attrs.get("android:versionName")
            or attrs.get("{http://schemas.android.com/apk/res/android}versionName", "")
        )
        vc = (
            attrs.get("android:versionCode")
            or attrs.get("{http://schemas.android.com/apk/res/android}versionCode", "")
        )
        try:
            manifest.version_code = int(vc)
        except (ValueError, TypeError):
            manifest.version_code = 0

        min_sdk = (
            attrs.get("android:minSdkVersion")
            or attrs.get("{http://schemas.android.com/apk/res/android}minSdkVersion", "")
        )
        target_sdk = (
            attrs.get("android:targetSdkVersion")
            or attrs.get("{http://schemas.android.com/apk/res/android}targetSdkVersion", "")
        )
        try:
            manifest.min_sdk = int(min_sdk)
        except (ValueError, TypeError):
            manifest.min_sdk = 0
        try:
            manifest.target_sdk = int(target_sdk)
        except (ValueError, TypeError):
            manifest.target_sdk = 0

        # Fallback regex extraction
        if not manifest.package_name:
            m = re.search(rb'package="([^"]+)"', raw)
            if m:
                manifest.package_name = m.group(1).decode("utf-8", errors="replace")

        if not manifest.version_name:
            m = re.search(rb'android:versionName="([^"]+)"', raw)
            if m:
                manifest.version_name = m.group(1).decode("utf-8", errors="replace")

        if manifest.version_code == 0:
            m = re.search(rb'android:versionCode="(\d+)"', raw)
            if m:
                manifest.version_code = int(m.group(1))

        # Permissions
        perm_pattern = re.compile(rb'android\.permission\.([A-Z_]+)')
        manifest.permissions = list(
            {m.group(1).decode("ascii") for m in perm_pattern.finditer(raw)}
        )

        return manifest

    # ── Native library detection ─────────────────────────────────────

    @staticmethod
    def _detect_native_libs(entries: list[APKEntry]) -> list[NativeLibrary]:
        libs: list[NativeLibrary] = []
        for entry in entries:
            path = entry.path
            # Handle both raw paths and prefixed XAPK paths like [split.apk]/lib/...
            if "/lib/" in path or path.startswith("lib/"):
                # Extract the relative part after the last lib/
                idx = path.rfind("/lib/")
                if idx >= 0:
                    relative = path[idx + 1 :]  # e.g. "lib/arm64-v8a/foo.so"
                else:
                    relative = path
            else:
                continue

            if not relative.endswith(".so"):
                continue

            parts = relative.split("/")
            if len(parts) < 3:
                continue
            arch_str = parts[1]
            arch = Architecture.from_string(arch_str)
            lib = NativeLibrary(
                path=relative,
                architecture=arch,
                size=entry.uncompressed_size,
                is_il2cpp="il2cpp" in relative.lower(),
                is_unity="unity" in relative.lower(),
            )
            libs.append(lib)
        return libs

    # ── Unity detection ──────────────────────────────────────────────

    def _detect_unity(self, apk_path: Path, info: APKInfo) -> UnityBuildInfo:
        """Detect Unity build characteristics from a single APK."""
        build = UnityBuildInfo()
        entry_paths = {e.path for e in info.all_entries}

        # IL2CPP detection
        for lib_path in KNOWN_IL2CPP_LIB_PATHS:
            if lib_path in entry_paths:
                build.is_il2cpp = True
                build.build_type = BuildType.IL2CPP
                build.libil2cpp_paths.append(lib_path)
        # Also scan for any non-standard libil2cpp.so paths
        for entry_path in entry_paths:
            if entry_path.endswith("/libil2cpp.so") and entry_path not in build.libil2cpp_paths:
                build.libil2cpp_paths.append(entry_path)

        # Mono detection
        for asm_path in KNOWN_ASSEMBLY_PATHS:
            if asm_path in entry_paths:
                build.has_assembly_cs = True
                build.assembly_cs_path = asm_path
                if not build.is_il2cpp:
                    build.is_mono = True
                    build.build_type = BuildType.MONO
                break

        # Global metadata
        for md_path in KNOWN_METADATA_PATHS:
            if md_path in entry_paths:
                build.has_global_metadata = True
                build.global_metadata_path = md_path
                break

        # Metadata encryption detection
        if build.has_global_metadata:
            for entry in info.all_entries:
                if entry.path == build.global_metadata_path:
                    if entry.uncompressed_size < 100:
                        build.metadata_version = 0
                    break

        # Unity version from APK entries
        build.unity_version = self._extract_version_from_entries(apk_path, entry_paths)

        # Architecture list
        build.architectures = list(info.detected_architectures)

        return build

    def _detect_unity_from_entries(
        self, entries: list[APKEntry], apk_path: Path, info: APKInfo
    ) -> UnityBuildInfo:
        """Detect Unity build from a merged list of entries (XAPK or single APK)."""
        build = UnityBuildInfo()
        entry_paths = {e.path for e in entries}

        # IL2CPP detection - search for both raw and prefixed paths
        for lib_path in KNOWN_IL2CPP_LIB_PATHS:
            for ep in entry_paths:
                if ep.endswith(lib_path) or ep == lib_path:
                    build.is_il2cpp = True
                    build.build_type = BuildType.IL2CPP
                    if lib_path not in build.libil2cpp_paths:
                        build.libil2cpp_paths.append(lib_path)
                    break

        # Also scan for any libil2cpp.so
        for entry_path in entry_paths:
            if entry_path.endswith("libil2cpp.so"):
                normalized = entry_path
                if normalized not in build.libil2cpp_paths:
                    build.libil2cpp_paths.append(normalized)
                build.is_il2cpp = True
                build.build_type = BuildType.IL2CPP

        # Mono detection
        for asm_path in KNOWN_ASSEMBLY_PATHS:
            for ep in entry_paths:
                if ep.endswith(asm_path) or ep == asm_path:
                    build.has_assembly_cs = True
                    build.assembly_cs_path = asm_path
                    if not build.is_il2cpp:
                        build.is_mono = True
                        build.build_type = BuildType.MONO
                    break

        # Global metadata
        for md_path in KNOWN_METADATA_PATHS:
            for ep in entry_paths:
                if ep.endswith(md_path) or ep == md_path:
                    build.has_global_metadata = True
                    build.global_metadata_path = md_path
                    break
            if build.has_global_metadata:
                break

        # Metadata size check
        if build.has_global_metadata:
            for entry in entries:
                if entry.path.endswith(build.global_metadata_path):
                    if entry.uncompressed_size < 100:
                        build.metadata_version = 0
                    break

        # Unity version
        build.unity_version = self._extract_version_from_entries(apk_path, entry_paths)

        # Architecture list
        build.architectures = list(info.detected_architectures)

        return build

    def _extract_version_from_entries(
        self, apk_path: Path, entry_paths: set[str]
    ) -> str:
        """Try to recover the Unity version string."""
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                for candidate in ("assets/bin/Data/settings.asset",):
                    # Check both raw and any prefixed version
                    found = False
                    for ep in entry_paths:
                        if ep.endswith(candidate) or ep == candidate:
                            found = True
                            break
                    if not found:
                        continue

                    # Try to read from inner APKs (XAPK) or directly
                    for zi in zf.infolist():
                        if zi.filename.endswith(".apk"):
                            try:
                                import tempfile, os
                                raw_apk = zf.read(zi.filename)
                                tmp = os.path.join(tempfile.gettempdir(), f"il2cpp_ver_{zi.filename.replace('/', '_')}")
                                with open(tmp, "wb") as f:
                                    f.write(raw_apk)
                                with zipfile.ZipFile(tmp, "r") as inner_zf:
                                    for inner_name in inner_zf.namelist():
                                        if inner_name.endswith(candidate):
                                            raw = inner_zf.read(inner_name)
                                            version = self._find_version_in_bytes(raw)
                                            if version:
                                                return version
                            except Exception:
                                continue
                        elif zi.filename.endswith(candidate):
                            try:
                                raw = zf.read(zi.filename)
                                version = self._find_version_in_bytes(raw)
                                if version:
                                    return version
                            except Exception:
                                continue

                # Broader scan
                for name in zf.namelist():
                    if name.endswith(".apk"):
                        continue
                    if any(name.endswith(ext) for ext in (".txt", ".xml", ".json", ".asset", ".dat")):
                        try:
                            raw = zf.read(name)
                            version = self._find_version_in_bytes(raw)
                            if version:
                                return version
                        except Exception:
                            continue
        except (zipfile.BadZipFile, OSError):
            pass
        return ""

    @staticmethod
    def _find_version_in_bytes(data: bytes) -> str:
        """Search raw bytes for a Unity version string like ``2021.3.20f1``."""
        text = data.decode("utf-8", errors="ignore")
        for match in UNITY_VERSION_RE.finditer(text):
            major, minor, patch, suffix = match.groups()
            ver = f"{major}.{minor}.{patch}"
            if suffix:
                ver += suffix
            if int(major) >= 2000 or int(major) >= 60:
                return ver
        return ""

    # ── Asset scanning ───────────────────────────────────────────────

    @staticmethod
    def _find_unity_assets(entries: list[APKEntry]) -> list[str]:
        found: list[str] = []
        seen_prefixes: set[str] = set()
        for entry in entries:
            path = entry.path
            # Strip any [apk_name]/ prefix
            if path.startswith("["):
                idx = path.find("]/")
                if idx >= 0:
                    path = path[idx + 2 :]
            for indicator in UNITY_ASSET_INDICATORS:
                if path.startswith(indicator):
                    prefix = indicator.rstrip("/")
                    if prefix not in seen_prefixes:
                        seen_prefixes.add(prefix)
                        found.append(prefix)
                    break
        return sorted(found)

    # ── Report generation ────────────────────────────────────────────

    def generate_summary(self, info: APKInfo) -> str:
        """Return a human-readable project summary."""
        lines = [
            "=" * 72,
            "  IL2CPP RECOVERY STUDIO - PROJECT SUMMARY",
            "=" * 72,
            "",
            f"  APK File      : {info.file_path.name}",
            f"  File Size     : {info.file_size / (1 << 20):.2f} MB",
            f"  Total Entries : {info.total_entries}",
            f"  Valid ZIP     : {info.is_valid_zip}",
            "",
            "--- Android Manifest " + "-" * 50,
            f"  Package       : {info.manifest.package_name}",
            f"  Version Name  : {info.manifest.version_name}",
            f"  Version Code  : {info.manifest.version_code}",
            f"  Min SDK       : {info.manifest.min_sdk}",
            f"  Target SDK    : {info.manifest.target_sdk}",
            f"  Permissions   : {len(info.manifest.permissions)}",
            "",
            "--- Unity Build " + "-" * 52,
            f"  Unity Version : {info.unity_build.unity_version or 'N/A'}",
            f"  Build Type    : {info.unity_build.build_type.name}",
            f"  IL2CPP        : {info.unity_build.is_il2cpp}",
            f"  Mono          : {info.unity_build.is_mono}",
            f"  Global MD     : {info.unity_build.has_global_metadata}",
            f"  Asm-CSharp    : {info.unity_build.has_assembly_cs}",
            "",
            "--- Architecture " + "-" * 51,
            f"  Detected      : {[a.name for a in info.detected_architectures]}",
            f"  Native Libs   : {len(info.native_libraries)}",
            "",
            "--- Unity Assets " + "-" * 51,
            *[f"  * {p}" for p in info.unity_assets_found],
            "",
        ]
        if info.warnings:
            lines.append("--- Warnings " + "-" * 56)
            for w in info.warnings:
                lines.append(f"  ! {w}")
            lines.append("")
        if info.errors:
            lines.append("--- Errors " + "-" * 58)
            for e in info.errors:
                lines.append(f"  X {e}")
            lines.append("")
        lines.append("=" * 72)
        return "\n".join(lines)
