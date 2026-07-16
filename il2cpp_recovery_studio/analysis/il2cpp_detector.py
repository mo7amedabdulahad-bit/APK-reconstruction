"""IL2CPP Detection Engine – Phase 2 of IL2CPP Recovery Studio.

Analyses the Unity build characteristics and produces a detailed report:
- Metadata version detection from global-metadata.dat header
- Unity version recovery from multiple sources
- Architecture analysis
- Obfuscation / encryption detection
- Protection mechanism detection
- Packing detection
"""
from __future__ import annotations

import math
import re
import struct
import zipfile
from collections import Counter
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.analysis.models import (
    DetectionReport,
    MetadataHeader,
    MetadataVersion,
    ObfuscationLevel,
    PackerType,
    ProtectionDetection,
    ProtectionType,
)
from il2cpp_recovery_studio.apk.models import APKInfo, BuildType
from il2cpp_recovery_studio.core.config import AppConfig
from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("analysis.il2cpp_detector")

# ── Constants ────────────────────────────────────────────────────────
METADATA_MAGIC = 0xAF1BB1FA
KNOWN_METADATA_PATHS = (
    "assets/bin/Data/Managed/Metadata/global-metadata.dat",
    "assets/bin/Data/global-metadata.dat",
)
UNITY_VERSION_RE = re.compile(r"(\d{4})\.(\d)\.(\d+)([f\d]*)")
ELF_MAGIC = b"\x7fELF"
PE_MAGIC = b"MZ"
ARCH_STRINGS = {
    "armeabi-v7a": "ARMv7 (32-bit)",
    "arm64-v8a": "ARM64 (AArch64)",
    "x86": "x86 (32-bit)",
    "x86_64": "x86_64 (64-bit)",
}


class IL2CPPDetector:
    """Analyse a parsed APK and produce a detailed IL2CPP detection report.

    Usage::

        detector = IL2CPPDetector(config=AppConfig())
        report = detector.analyse(apk_info)
        print(report.metadata_version.display_name)
    """

    def __init__(self, config: Optional[AppConfig] = None) -> None:
        self._config = config or AppConfig()

    # ------------------------------------------------------------------
    # Public API
    # ------------------------------------------------------------------

    def analyse(self, apk_info: APKInfo) -> DetectionReport:
        """Run all detection passes and return a :class:`DetectionReport`."""
        report = DetectionReport()

        logger.info("Starting IL2CPP detection analysis")

        # 1. Architecture
        self._detect_architecture(apk_info, report)

        # 2. Unity version (deep scan)
        self._detect_unity_version(apk_info, report)

        # 3. Metadata header parsing
        self._detect_metadata(apk_info, report)

        # 4. Protection / obfuscation detection
        self._detect_protections(apk_info, report)

        # 5. Confidence scoring
        self._compute_confidence(report)

        logger.info(
            "Detection complete – metadata=%s  version=%s  confidence=%.0f%%",
            report.has_metadata,
            report.metadata_version.display_name if report.has_metadata else "N/A",
            report.overall_confidence * 100,
        )
        return report

    def generate_report(self, report: DetectionReport) -> str:
        """Return a human-readable detection report."""
        lines = [
            "=" * 72,
            "  IL2CPP DETECTION REPORT",
            "=" * 72,
            "",
            "--- Metadata -------------------------------------------------------",
            f"  Magic Valid    : {report.metadata_magic_valid}",
            f"  Version (raw)  : {report.metadata_version_raw}",
            f"  Version        : {report.metadata_version.display_name}",
            f"  File Size      : {report.metadata_file_size:,} bytes",
        ]

        if report.metadata_header:
            h = report.metadata_header
            lines += [
                "  --- Header Details ---",
                f"    String Literals  : offset={h.string_literal_offset:#x}  count={h.string_literal_count}",
                f"    String Data      : offset={h.string_literal_data_offset:#x}  count={h.string_literal_data_count}",
                f"    Strings          : offset={h.string_offset:#x}  count={h.string_count}",
                f"    Events           : offset={h.events_offset:#x}  count={h.events_count}",
                f"    Properties       : offset={h.properties_offset:#x}  count={h.properties_count}",
                f"    Header Size      : {h.total_header_size} bytes",
            ]

        lines += [
            "",
            "--- Unity Version --------------------------------------------------",
            f"  Version        : {report.unity_version or 'N/A'}",
            f"  Source         : {report.unity_version_source or 'N/A'}",
            "",
            "--- Architecture ---------------------------------------------------",
            f"  Architectures  : {report.binary_architectures}",
            f"  64-bit         : {report.binary_is_64bit}",
            f"  Endianness     : {report.binary_endian}",
            "",
            "--- Protection / Obfuscation --------------------------------------",
            f"  Obfuscation    : {report.obfuscation_level.name}",
            f"  Packer         : {report.packer_detected.name}",
        ]

        for pd in report.protections:
            status = "DETECTED" if pd.detected else "clean"
            lines.append(f"  {pd.protection_type.name:30s} [{status}]  conf={pd.confidence:.0%}  {pd.details}")

        lines += [
            "",
            "--- Confidence -----------------------------------------------------",
            f"  Overall        : {report.overall_confidence:.0%}",
            "",
        ]

        if report.warnings:
            lines.append("--- Warnings --------------------------------------------------------")
            for w in report.warnings:
                lines.append(f"  ! {w}")
            lines.append("")

        if report.errors:
            lines.append("--- Errors ----------------------------------------------------------")
            for e in report.errors:
                lines.append(f"  X {e}")
            lines.append("")

        lines.append("=" * 72)
        return "\n".join(lines)

    # ------------------------------------------------------------------
    # Internal detection passes
    # ------------------------------------------------------------------

    def _detect_architecture(self, apk_info: APKInfo, report: DetectionReport) -> None:
        """Determine CPU architecture from native libraries."""
        arch_names = []
        for arch in apk_info.detected_architectures:
            display = ARCH_STRINGS.get(arch.name.lower(), arch.name)
            arch_names.append(display)

        report.binary_architectures = arch_names or ["Unknown"]
        report.binary_is_64bit = any(
            "64" in a or "aarch64" in a.lower() for a in arch_names
        )
        report.binary_endian = "little"
        logger.info("Architectures: %s (64-bit=%s)", arch_names, report.binary_is_64bit)

    def _detect_unity_version(self, apk_info: APKInfo, report: DetectionReport) -> None:
        """Recover Unity version from multiple sources."""
        # Source 1: Already detected by APK parser
        if apk_info.unity_build.unity_version:
            report.unity_version = apk_info.unity_build.unity_version
            report.unity_version_source = "APK parser"
            logger.info("Unity version from APK parser: %s", report.unity_version)
            return

        # Source 2: Deep scan of APK entries for version strings
        version = self._deep_scan_unity_version(apk_info)
        if version:
            report.unity_version = version
            report.unity_version_source = "Deep entry scan"
            logger.info("Unity version from deep scan: %s", version)
            return

        # Source 3: Infer from metadata version
        if apk_info.unity_build.has_global_metadata:
            inferred = self._infer_version_from_metadata_version(apk_info)
            if inferred:
                report.unity_version = inferred
                report.unity_version_source = "Inferred from metadata version"
                logger.info("Unity version inferred: %s", inferred)
                return

        report.warnings.append("Could not determine Unity version")

    def _deep_scan_unity_version(self, apk_info: APKInfo) -> str:
        """Scan APK entries for files containing a Unity version string."""
        scan_targets = [
            "assets/bin/Data/settings.asset",
            "assets/bin/Data/unity default resources",
            "assets/bin/Data/globalgamemanagers",
            "assets/bin/Data/boot.config",
            "assets/bin/Data/ScriptingAssemblies.json",
        ]

        apk_path = apk_info.file_path
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                namelist = zf.namelist()

                # Check inner APKs for XAPK
                for name in namelist:
                    if name.endswith(".apk"):
                        try:
                            raw_apk = zf.read(name)
                            import tempfile, os
                            tmp = os.path.join(tempfile.gettempdir(), f"il2cpp_ver_{name.replace('/', '_')}")
                            with open(tmp, "wb") as f:
                                f.write(raw_apk)
                            with zipfile.ZipFile(tmp, "r") as inner_zf:
                                for target in scan_targets:
                                    for inner_name in inner_zf.namelist():
                                        if inner_name.endswith(target):
                                            try:
                                                data = inner_zf.read(inner_name)
                                                ver = self._find_version_in_data(data)
                                                if ver:
                                                    return ver
                                            except Exception:
                                                continue
                        except Exception:
                            continue

                # Direct scan
                for target in scan_targets:
                    for name in namelist:
                        if name.endswith(target):
                            try:
                                data = zf.read(name)
                                ver = self._find_version_in_data(data)
                                if ver:
                                    return ver
                            except Exception:
                                continue

                # Broader scan of small files
                for name in namelist:
                    if name.endswith((".apk",)):
                        continue
                    try:
                        info = zf.getinfo(name)
                        if info.file_size > 10 * 1024 * 1024:
                            continue
                        data = zf.read(name)
                        ver = self._find_version_in_data(data)
                        if ver:
                            return ver
                    except Exception:
                        continue
        except (zipfile.BadZipFile, OSError):
            pass
        return ""

    def _infer_version_from_metadata_version(self, apk_info: APKInfo) -> str:
        """Infer an approximate Unity version from the metadata version number."""
        # Read the metadata header directly since apk_info may not have the version
        metadata_data = self._read_metadata_bytes(apk_info)
        if metadata_data is None or len(metadata_data) < 8:
            return ""

        magic = struct.unpack_from(">I", metadata_data, 0)[0]
        if magic != METADATA_MAGIC:
            return ""

        raw_ver = struct.unpack_from("<I", metadata_data, 4)[0]

        version_map = {
            15: "5.0.0f4", 16: "5.1.0f1", 19: "5.3.0f1",
            20: "5.5.0f1", 21: "5.6.0f1", 22: "2017.1.0f1",
            23: "2017.2.0f1", 24: "2019.4.0f1",
            27: "2020.3.0f1", 29: "2021.3.0f1",
            31: "2023.1.0f1", 33: "6000.0.0f1",
            39: "6000.3.0f1",
        }
        return version_map.get(raw_ver, "")

    def _read_metadata_bytes(self, apk_info: APKInfo) -> Optional[bytes]:
        """Read the raw bytes of global-metadata.dat from the APK."""
        apk_path = apk_info.file_path
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                # Direct lookup
                for md_path in KNOWN_METADATA_PATHS:
                    if md_path in zf.namelist():
                        return zf.read(md_path)

                # Check inner APKs (XAPK)
                for name in zf.namelist():
                    if name.endswith(".apk"):
                        try:
                            import tempfile, os
                            raw_apk = zf.read(name)
                            tmp = os.path.join(tempfile.gettempdir(), f"il2cpp_md_{name.replace('/', '_')}")
                            with open(tmp, "wb") as f:
                                f.write(raw_apk)
                            with zipfile.ZipFile(tmp, "r") as inner_zf:
                                for md_path in KNOWN_METADATA_PATHS:
                                    if md_path in inner_zf.namelist():
                                        return inner_zf.read(md_path)
                        except Exception:
                            continue
        except (zipfile.BadZipFile, OSError):
            pass
        return None

    # ── Metadata header detection ────────────────────────────────────

    def _detect_metadata(self, apk_info: APKInfo, report: DetectionReport) -> None:
        """Parse the global-metadata.dat header if present."""
        data = self._read_metadata_bytes(apk_info)
        if data is None:
            report.warnings.append("global-metadata.dat not found or unreadable")
            return

        report.metadata_file_size = len(data)

        if len(data) < 8:
            report.warnings.append("global-metadata.dat too small to contain a header")
            return

        magic = struct.unpack_from(">I", data, 0)[0]
        version_raw = struct.unpack_from("<I", data, 4)[0]

        report.metadata_magic_valid = magic == METADATA_MAGIC
        report.metadata_version_raw = version_raw
        report.metadata_version = MetadataVersion.from_raw(version_raw)

        if not report.metadata_magic_valid:
            actual_magic_be = struct.unpack_from(">I", data, 0)[0]
            report.warnings.append(
                f"Invalid metadata magic: expected 0x{METADATA_MAGIC:08X}, got 0x{actual_magic_be:08X}. "
                "Metadata may be encrypted or obfuscated."
            )
            # Still try to detect obfuscation from the data
            self._detect_encryption_indicators(data, report)
            return

        # Parse header offset/length pairs
        header = self._parse_metadata_header(data)
        report.metadata_header = header

        logger.info(
            "Metadata v%d detected (magic valid, %d bytes)",
            version_raw,
            len(data),
        )

    def _parse_metadata_header(self, data: bytes) -> MetadataHeader:
        """Parse the global-metadata.dat header structure."""
        # Header structure after magic+version:
        # A series of offset/size pairs. The first pairs are:
        #   stringLiteralOffset, stringLiteralCount
        #   stringLiteralDataOffset, stringLiteralDataCount
        #   stringOffset, stringCount
        #   eventsOffset, eventsCount
        #   propertiesOffset, propertiesCount
        #   ... more pairs
        offsets = []
        pos = 8  # Skip magic + version

        # Read up to 40 offset/size pairs (max reasonable header size)
        for _ in range(40):
            if pos + 8 > len(data):
                break
            offset_val = struct.unpack_from("<I", data, pos)[0]
            count_val = struct.unpack_from("<I", data, pos + 4)[0]
            offsets.append((offset_val, count_val))
            pos += 8

        total_header_size = pos

        # Assign named fields
        sl_off = offsets[0][0] if len(offsets) > 0 else 0
        sl_cnt = offsets[0][1] if len(offsets) > 0 else 0
        sld_off = offsets[1][0] if len(offsets) > 1 else 0
        sld_cnt = offsets[1][1] if len(offsets) > 1 else 0
        str_off = offsets[2][0] if len(offsets) > 2 else 0
        str_cnt = offsets[2][1] if len(offsets) > 2 else 0
        evt_off = offsets[3][0] if len(offsets) > 3 else 0
        evt_cnt = offsets[3][1] if len(offsets) > 3 else 0
        prp_off = offsets[4][0] if len(offsets) > 4 else 0
        prp_cnt = offsets[4][1] if len(offsets) > 4 else 0

        return MetadataHeader(
            magic=METADATA_MAGIC,
            version_raw=struct.unpack_from("<I", data, 4)[0],
            version=MetadataVersion.from_raw(struct.unpack_from("<I", data, 4)[0]),
            string_literal_offset=sl_off,
            string_literal_count=sl_cnt,
            string_literal_data_offset=sld_off,
            string_literal_data_count=sld_cnt,
            string_offset=str_off,
            string_count=str_cnt,
            events_offset=evt_off,
            events_count=evt_cnt,
            properties_offset=prp_off,
            properties_count=prp_cnt,
            total_header_size=total_header_size,
            is_valid=True,
        )

    # ── Protection detection ─────────────────────────────────────────

    def _detect_protections(self, apk_info: APKInfo, report: DetectionReport) -> None:
        """Run all protection detection heuristics."""
        protections: list[ProtectionDetection] = []

        protections.append(self._check_string_encryption(apk_info))
        protections.append(self._check_metadata_encryption(apk_info, report))
        protections.append(self._check_binary_encryption(apk_info))
        protections.append(self._check_metadata_embedded(apk_info))
        protections.append(self._check_obfuscation(apk_info))
        protections.append(self._check_anti_tamper(apk_info))
        protections.append(self._check_debugger_detection(apk_info))
        protections.append(self._check_signature_verification(apk_info))

        report.protections = protections

        # Determine obfuscation level
        detected_count = sum(1 for p in protections if p.detected)
        if detected_count == 0:
            report.obfuscation_level = ObfuscationLevel.NONE
        elif detected_count <= 2:
            report.obfuscation_level = ObfuscationLevel.LIGHT
        elif detected_count <= 4:
            report.obfuscation_level = ObfuscationLevel.MODERATE
        else:
            report.obfuscation_level = ObfuscationLevel.HEAVY

    def _check_string_encryption(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect string encryption by checking for known encryption library signatures."""
        # Check for known obfuscation libraries in entry paths
        obfuscation_indicators = [
            "obfuscator", "obfuscation", "protector", "shield",
            "dotfuscator", "confuser", "babel", "smartassembly",
            "virbox", "qihoo", "360加固", "tencent",
        ]
        for entry in apk_info.all_entries:
            path_lower = entry.path.lower()
            for indicator in obfuscation_indicators:
                if indicator in path_lower:
                    return ProtectionDetection(
                        protection_type=ProtectionType.STRING_ENCRYPTION,
                        detected=True,
                        confidence=0.7,
                        details=f"Found obfuscation-related file: {entry.path}",
                    )
        return ProtectionDetection(
            protection_type=ProtectionType.STRING_ENCRYPTION,
            detected=False,
            confidence=0.3,
            details="No obfuscation libraries detected in file paths",
        )

    def _check_metadata_encryption(
        self, apk_info: APKInfo, report: DetectionReport
    ) -> ProtectionDetection:
        """Detect metadata encryption by checking magic bytes and file entropy."""
        if report.metadata_magic_valid:
            return ProtectionDetection(
                protection_type=ProtectionType.IL2CPP_METADATA_ENCRYPTION,
                detected=False,
                confidence=0.9,
                details="Metadata header is valid (magic bytes match)",
            )

        # If we got here, the magic is invalid – likely encrypted
        data = self._read_metadata_bytes(apk_info)
        if data is None:
            return ProtectionDetection(
                protection_type=ProtectionType.IL2CPP_METADATA_ENCRYPTION,
                detected=False,
                confidence=0.0,
                details="No metadata file found",
            )

        entropy = self._calculate_entropy(data)
        if entropy > 7.5:
            return ProtectionDetection(
                protection_type=ProtectionType.IL2CPP_METADATA_ENCRYPTION,
                detected=True,
                confidence=0.85,
                details=f"Invalid magic + high entropy ({entropy:.2f}) suggests encryption",
            )

        return ProtectionDetection(
            protection_type=ProtectionType.IL2CPP_METADATA_ENCRYPTION,
            detected=True,
            confidence=0.6,
            details=f"Invalid magic bytes (0x{struct.unpack_from('<I', data, 0)[0]:08X})",
        )

    def _check_binary_encryption(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect native binary encryption by checking for encryption-related entries."""
        encryption_indicators = [
            "libjiagu.so", "libDexHelper.so", "libexec.so",
            "libexecmain.so", "libtersafe.so", "libx3g.so",
            "libchaosvmp.so", "libbugly.so", "libshella-",
            "libshellx-", "libtup.so", "libSecShell.so",
            "libSecShell-x86.so", "libducd.so",
        ]
        for entry in apk_info.all_entries:
            for indicator in encryption_indicators:
                if entry.path.endswith(indicator):
                    return ProtectionDetection(
                        protection_type=ProtectionType.IL2CPP_BINARY_ENCRYPTION,
                        detected=True,
                        confidence=0.8,
                        details=f"Found encryption library: {entry.path}",
                    )
        return ProtectionDetection(
            protection_type=ProtectionType.IL2CPP_BINARY_ENCRYPTION,
            detected=False,
            confidence=0.3,
            details="No known binary encryption libraries found",
        )

    def _check_metadata_embedded(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect if metadata is embedded in the native binary."""
        for lib in apk_info.native_libraries:
            if lib.is_il2cpp and lib.size > 50 * 1024 * 1024:
                return ProtectionDetection(
                    protection_type=ProtectionType.METADATA_EMBEDDED,
                    detected=True,
                    confidence=0.5,
                    details=f"libil2cpp.so is unusually large ({lib.size / (1 << 20):.1f} MB), "
                    "metadata may be embedded",
                )
        return ProtectionDetection(
            protection_type=ProtectionType.METADATA_EMBEDDED,
            detected=False,
            confidence=0.4,
            details="No indicators of embedded metadata",
        )

    def _check_obfuscation(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect C# obfuscation by analysing string patterns in metadata."""
        data = self._read_metadata_bytes(apk_info)
        if data is None:
            return ProtectionDetection(
                protection_type=ProtectionType.CODE混淆,
                detected=False,
                confidence=0.0,
                details="No metadata available for analysis",
            )

        # Need enough data for meaningful analysis
        if len(data) < 1024:
            return ProtectionDetection(
                protection_type=ProtectionType.CODE混淆,
                detected=False,
                confidence=0.2,
                details="Metadata too small for obfuscation analysis",
            )

        try:
            # Sample a larger region past the header (skip first 256 bytes of header)
            sample_start = min(256, len(data) - 512)
            sample_end = min(sample_start + 4096, len(data))
            sample = data[sample_start:sample_end]

            # Count printable ASCII characters (excluding null bytes)
            non_null = sum(1 for b in sample if b != 0)
            printable = sum(1 for b in sample if 0x20 <= b <= 0x7E)

            if non_null == 0:
                return ProtectionDetection(
                    protection_type=ProtectionType.CODE混淆,
                    detected=False,
                    confidence=0.3,
                    details="Metadata is mostly null bytes (not obfuscated)",
                )

            ratio = printable / non_null

            if ratio < 0.15:
                return ProtectionDetection(
                    protection_type=ProtectionType.CODE混淆,
                    detected=True,
                    confidence=0.6,
                    details=f"Low printable ratio ({ratio:.2%}) in metadata strings",
                )

            return ProtectionDetection(
                protection_type=ProtectionType.CODE混淆,
                detected=False,
                confidence=0.4,
                details=f"Printable ratio normal ({ratio:.2%})",
            )
        except Exception:
            return ProtectionDetection(
                protection_type=ProtectionType.CODE混淆,
                detected=False,
                confidence=0.2,
                details="Analysis inconclusive",
            )

    def _check_anti_tamper(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect anti-tamper mechanisms."""
        tamper_indicators = ["integrity", "tamper", "checksum", "hash"]
        for entry in apk_info.all_entries:
            path_lower = entry.path.lower()
            for indicator in tamper_indicators:
                if indicator in path_lower:
                    return ProtectionDetection(
                        protection_type=ProtectionType.ANTI_TAMPER,
                        detected=True,
                        confidence=0.5,
                        details=f"Tamper-related file: {entry.path}",
                    )
        return ProtectionDetection(
            protection_type=ProtectionType.ANTI_TAMPER,
            detected=False,
            confidence=0.3,
            details="No anti-tamper indicators found",
        )

    def _check_debugger_detection(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect debugger detection libraries."""
        debugger_indicators = ["ptrace", "debugger", "frida", "xposed"]
        for entry in apk_info.all_entries:
            path_lower = entry.path.lower()
            for indicator in debugger_indicators:
                if indicator in path_lower:
                    return ProtectionDetection(
                        protection_type=ProtectionType.DEBUGGER_DETECTION,
                        detected=True,
                        confidence=0.6,
                        details=f"Anti-debug library: {entry.path}",
                    )
        return ProtectionDetection(
            protection_type=ProtectionType.DEBUGGER_DETECTION,
            detected=False,
            confidence=0.3,
            details="No anti-debug libraries found",
        )

    def _check_signature_verification(self, apk_info: APKInfo) -> ProtectionDetection:
        """Detect signature / certificate verification."""
        sig_indicators = ["signature", "certificate", "keystore", "signing"]
        for entry in apk_info.all_entries:
            path_lower = entry.path.lower()
            for indicator in sig_indicators:
                if indicator in path_lower:
                    return ProtectionDetection(
                        protection_type=ProtectionType.SIGNATURE_VERIFICATION,
                        detected=True,
                        confidence=0.5,
                        details=f"Signature-related file: {entry.path}",
                    )
        return ProtectionDetection(
            protection_type=ProtectionType.SIGNATURE_VERIFICATION,
            detected=False,
            confidence=0.3,
            details="No signature verification indicators found",
        )

    def _detect_encryption_indicators(self, data: bytes, report: DetectionReport) -> None:
        """Analyse raw data to guess if it's encrypted metadata."""
        if len(data) < 16:
            return
        entropy = self._calculate_entropy(data)
        if entropy > 7.8:
            report.warnings.append(
                f"High entropy ({entropy:.2f}/8.0) in metadata file – likely encrypted"
            )

    # ── Utility ──────────────────────────────────────────────────────

    @staticmethod
    def _find_version_in_data(data: bytes) -> str:
        """Search binary data for a Unity version string."""
        text = data.decode("utf-8", errors="ignore")
        for match in UNITY_VERSION_RE.finditer(text):
            major, minor, patch, suffix = match.groups()
            if int(major) >= 2000 or int(major) >= 60:
                ver = f"{major}.{minor}.{patch}"
                if suffix:
                    ver += suffix
                return ver
        return ""

    @staticmethod
    def _calculate_entropy(data: bytes) -> float:
        """Calculate Shannon entropy of *data* (0.0 – 8.0 for byte data)."""
        if not data:
            return 0.0
        counter = Counter(data)
        length = len(data)
        entropy = 0.0
        for count in counter.values():
            p = count / length
            if p > 0:
                entropy -= p * math.log2(p)
        return entropy

    # ── Confidence scoring ───────────────────────────────────────────

    @staticmethod
    def _compute_confidence(report: DetectionReport) -> None:
        """Compute overall confidence score (0.0 – 1.0)."""
        score = 0.0
        total = 0.0

        # Metadata detection (weight 40%)
        total += 0.4
        if report.metadata_magic_valid:
            score += 0.4
        elif report.metadata_file_size > 0:
            score += 0.1  # File exists but magic invalid

        # Unity version (weight 20%)
        total += 0.2
        if report.unity_version:
            score += 0.2
        elif report.unity_version_source:
            score += 0.1

        # Architecture (weight 15%)
        total += 0.15
        if report.binary_architectures and report.binary_architectures != ["Unknown"]:
            score += 0.15

        # Protections analysis (weight 15%)
        total += 0.15
        if report.protections:
            score += 0.15

        # Header parsing (weight 10%)
        total += 0.1
        if report.metadata_header and report.metadata_header.is_valid:
            score += 0.1

        report.overall_confidence = score / total if total > 0 else 0.0
