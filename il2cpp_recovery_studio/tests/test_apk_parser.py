"""Unit tests for the APK parser module."""
from __future__ import annotations

import struct
import zipfile
from pathlib import Path

import pytest

from il2cpp_recovery_studio.apk.models import (
    APKEntry,
    APKInfo,
    AndroidManifest,
    Architecture,
    BuildType,
    NativeLibrary,
    UnityBuildInfo,
)
from il2cpp_recovery_studio.apk.parser import APKParser
from il2cpp_recovery_studio.core.config import AppConfig
from il2cpp_recovery_studio.core.exceptions import (
    APKCorruptedError,
    APKNotFoundError,
    APKValidationError,
)


# =====================================================================
# Fixtures
# =====================================================================

def _make_minimal_apk(target: Path, name: str = "test.apk") -> Path:
    """Create a valid minimal ZIP that looks like a Unity APK."""
    apk = target / name
    with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        zf.writestr(
            "assets/bin/Data/Managed/Metadata/global-metadata.dat",
            b"\x00" * 256,
        )
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)
    return apk


def _make_il2cpp_apk(target: Path) -> Path:
    """Create a ZIP that contains IL2CPP artefacts."""
    apk = target / "il2cpp_game.apk"
    with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        zf.writestr(
            "assets/bin/Data/Managed/Metadata/global-metadata.dat",
            b"\x00" * 512,
        )
        zf.writestr("lib/arm64-v8a/libil2cpp.so", b"\x7fELF" + b"\x00" * 1024)
        zf.writestr("lib/armeabi-v7a/libil2cpp.so", b"\x7fELF" + b"\x00" * 512)
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)
    return apk


def _make_mono_apk(target: Path) -> Path:
    """Create a ZIP that looks like a Mono build."""
    apk = target / "mono_game.apk"
    with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        zf.writestr(
            "assets/bin/Data/Managed/Assembly-CSharp.dll",
            b"\x00" * 256,
        )
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)
    return apk


@pytest.fixture
def minimal_apk(tmp_path: Path) -> Path:
    return _make_minimal_apk(tmp_path)


@pytest.fixture
def il2cpp_apk(tmp_path: Path) -> Path:
    return _make_il2cpp_apk(tmp_path)


@pytest.fixture
def mono_apk(tmp_path: Path) -> Path:
    return _make_mono_apk(tmp_path)


@pytest.fixture
def parser() -> APKParser:
    return APKParser(config=AppConfig())


# =====================================================================
# Test: APK Validation
# =====================================================================

class TestAPKValidation:
    def test_nonexistent_file_raises(self, parser: APKParser, tmp_path: Path) -> None:
        with pytest.raises(APKNotFoundError, match="not found"):
            parser.parse(tmp_path / "does_not_exist.apk")

    def test_non_zip_file_raises(self, parser: APKParser, tmp_path: Path) -> None:
        bad = tmp_path / "bad.apk"
        bad.write_bytes(b"this is not a zip file")
        with pytest.raises(APKValidationError, match="(?i)not a valid"):
            parser.parse(bad)

    def test_valid_minimal_apk(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        assert info.is_valid_zip is True
        assert info.file_size > 0
        assert info.total_entries > 0

    def test_corrupted_zip_raises(self, parser: APKParser, tmp_path: Path) -> None:
        corrupt = tmp_path / "corrupt.apk"
        corrupt.write_bytes(b"PK\x03\x04" + b"\x00" * 200)
        with pytest.raises((APKCorruptedError, APKValidationError)):
            parser.parse(corrupt)


# =====================================================================
# Test: Entry Enumeration
# =====================================================================

class TestEntryEnumeration:
    def test_entries_populated(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        assert len(info.all_entries) >= 3
        paths = {e.path for e in info.all_entries}
        assert "AndroidManifest.xml" in paths
        assert "classes.dex" in paths

    def test_entry_sizes_positive(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        for entry in info.all_entries:
            assert entry.uncompressed_size >= 0
            assert entry.compressed_size >= 0


# =====================================================================
# Test: Native Library Detection
# =====================================================================

class TestNativeLibraryDetection:
    def test_il2cpp_detected(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        il2cpp_libs = [l for l in info.native_libraries if l.is_il2cpp]
        assert len(il2cpp_libs) == 2

    def test_architectures(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        arch_names = {a.name for a in info.detected_architectures}
        assert "ARM64" in arch_names
        assert "ARMV7" in arch_names

    def test_no_native_libs_in_minimal(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        assert len(info.native_libraries) == 0


# =====================================================================
# Test: Unity Detection
# =====================================================================

class TestUnityDetection:
    def test_il2cpp_build_type(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        assert info.unity_build.is_il2cpp is True
        assert info.unity_build.build_type == BuildType.IL2CPP
        assert len(info.unity_build.libil2cpp_paths) == 2

    def test_mono_build_type(self, parser: APKParser, mono_apk: Path) -> None:
        info = parser.parse(mono_apk)
        assert info.unity_build.is_mono is True
        assert info.unity_build.build_type == BuildType.MONO
        assert info.unity_build.has_assembly_cs is True

    def test_global_metadata_detected(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        assert info.unity_build.has_global_metadata is True
        assert "global-metadata.dat" in info.unity_build.global_metadata_path

    def test_unity_assets_found(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        assert len(info.unity_assets_found) > 0


# =====================================================================
# Test: Architecture Enum
# =====================================================================

class TestArchitecture:
    def test_from_string_valid(self) -> None:
        assert Architecture.from_string("armeabi-v7a") == Architecture.ARMV7
        assert Architecture.from_string("arm64-v8a") == Architecture.ARM64
        assert Architecture.from_string("x86") == Architecture.X86
        assert Architecture.from_string("x86_64") == Architecture.X86_64

    def test_from_string_unknown(self) -> None:
        assert Architecture.from_string("mips") == Architecture.UNKNOWN
        assert Architecture.from_string("") == Architecture.UNKNOWN

    def test_case_insensitive(self) -> None:
        assert Architecture.from_string("ARM64-V8A") == Architecture.ARM64
        assert Architecture.from_string("X86_64") == Architecture.X86_64


# =====================================================================
# Test: APKInfo Properties
# =====================================================================

class TestAPKInfoProperties:
    def test_total_entries(self) -> None:
        info = APKInfo(file_path=Path("test.apk"))
        assert info.total_entries == 0
        info.all_entries.append(APKEntry(path="a", uncompressed_size=1, compressed_size=1, crc32=0))
        assert info.total_entries == 1

    def test_has_unity_false_by_default(self) -> None:
        info = APKInfo(file_path=Path("test.apk"))
        assert info.has_unity is False
        assert info.has_il2cpp is False
        assert info.has_mono is False

    def test_has_unity_true(self) -> None:
        info = APKInfo(file_path=Path("test.apk"))
        info.unity_build.unity_version = "2021.3.20f1"
        assert info.has_unity is True


# =====================================================================
# Test: Report Generation
# =====================================================================

class TestReportGeneration:
    def test_summary_contains_key_sections(self, parser: APKParser, il2cpp_apk: Path) -> None:
        info = parser.parse(il2cpp_apk)
        summary = parser.generate_summary(info)
        assert "PROJECT SUMMARY" in summary
        assert "Unity Build" in summary
        assert "Architecture" in summary
        assert "il2cpp_game.apk" in summary

    def test_summary_package_name(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        summary = parser.generate_summary(info)
        assert "Package" in summary


# =====================================================================
# Test: Manifest Parsing
# =====================================================================

class TestManifestParsing:
    def test_manifest_object_present(self, parser: APKParser, minimal_apk: Path) -> None:
        info = parser.parse(minimal_apk)
        assert isinstance(info.manifest, AndroidManifest)

    def test_corrupted_manifest_handled(self, parser: APKParser, tmp_path: Path) -> None:
        apk = tmp_path / "bad_manifest.apk"
        with zipfile.ZipFile(str(apk), "w") as zf:
            zf.writestr("AndroidManifest.xml", b"\xff\xfe\x00\x01" + b"\x00" * 50)
            zf.writestr("classes.dex", b"\x00" * 100)
        info = parser.parse(apk)
        assert isinstance(info.manifest, AndroidManifest)


# =====================================================================
# Test: XAPK Support
# =====================================================================

def _make_xapk(target: Path) -> Path:
    """Create an XAPK bundle with a main APK and a config split."""
    xapk = target / "game.xapk"

    # Build main APK in memory
    import io
    main_buf = io.BytesIO()
    with zipfile.ZipFile(main_buf, "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        zf.writestr(
            "assets/bin/Data/Managed/Metadata/global-metadata.dat",
            b"\x00" * 512,
        )
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)

    # Build config split APK
    config_buf = io.BytesIO()
    with zipfile.ZipFile(config_buf, "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 32)
        zf.writestr("lib/arm64-v8a/libil2cpp.so", b"\x7fELF" + b"\x00" * 2048)
        zf.writestr("lib/armeabi-v7a/libil2cpp.so", b"\x7fELF" + b"\x00" * 1024)
        zf.writestr("lib/arm64-v8a/libunity.so", b"\x7fELF" + b"\x00" * 512)

    # Bundle into XAPK
    with zipfile.ZipFile(str(xapk), "w", zipfile.ZIP_DEFLATED) as xapk_zf:
        xapk_zf.writestr("com.example.game.apk", main_buf.getvalue())
        xapk_zf.writestr("config.arm64-v8a.apk", config_buf.getvalue())
        xapk_zf.writestr("config.armeabi_v7a.apk", config_buf.getvalue())

    return xapk


@pytest.fixture
def xapk_bundle(tmp_path: Path) -> Path:
    return _make_xapk(tmp_path)


class TestXAPKSupport:
    def test_xapk_detected(self, parser: APKParser, xapk_bundle: Path) -> None:
        inner = APKParser._detect_xapk(xapk_bundle)
        assert len(inner) == 3

    def test_xapk_parsed(self, parser: APKParser, xapk_bundle: Path) -> None:
        info = parser.parse(xapk_bundle)
        assert info.is_valid_zip is True
        assert info.total_entries > 0

    def test_xapk_native_libs(self, parser: APKParser, xapk_bundle: Path) -> None:
        info = parser.parse(xapk_bundle)
        il2cpp_libs = [l for l in info.native_libraries if l.is_il2cpp]
        assert len(il2cpp_libs) >= 2

    def test_xapk_architectures(self, parser: APKParser, xapk_bundle: Path) -> None:
        info = parser.parse(xapk_bundle)
        arch_names = {a.name for a in info.detected_architectures}
        assert "ARM64" in arch_names
        assert "ARMV7" in arch_names

    def test_xapk_unity_detected(self, parser: APKParser, xapk_bundle: Path) -> None:
        info = parser.parse(xapk_bundle)
        assert info.unity_build.is_il2cpp is True
        assert info.unity_build.has_global_metadata is True

    def test_single_apk_not_xapk(self, parser: APKParser, il2cpp_apk: Path) -> None:
        inner = APKParser._detect_xapk(il2cpp_apk)
        assert inner == []

    def test_xapk_main_apk_selection(self, parser: APKParser, xapk_bundle: Path) -> None:
        inner = APKParser._detect_xapk(xapk_bundle)
        main = APKParser._find_main_apk(inner)
        assert main == "com.example.game.apk"
