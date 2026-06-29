"""Unit tests for the IL2CPP detection engine."""
from __future__ import annotations

import io
import struct
import zipfile
from pathlib import Path

import pytest

from il2cpp_recovery_studio.analysis.il2cpp_detector import IL2CPPDetector
from il2cpp_recovery_studio.analysis.models import (
    DetectionReport,
    MetadataVersion,
    ObfuscationLevel,
    ProtectionType,
)
from il2cpp_recovery_studio.apk.models import (
    APKEntry,
    APKInfo,
    Architecture,
    BuildType,
    NativeLibrary,
    UnityBuildInfo,
)
from il2cpp_recovery_studio.core.config import AppConfig


# =====================================================================
# Helpers
# =====================================================================

METADATA_MAGIC = 0xAF1BB1FA


def _make_metadata_bytes(version: int = 29) -> bytes:
    """Build a minimal global-metadata.dat with valid header."""
    buf = bytearray(256)
    struct.pack_into(">I", buf, 0, METADATA_MAGIC)  # Magic is big-endian
    struct.pack_into("<I", buf, 4, version)           # Version is little-endian
    # Offset/size pairs
    offsets = [
        (0x100, 100),  # stringLiteral
        (0x200, 200),  # stringLiteralData
        (0x400, 300),  # string
        (0x600, 10),   # events
        (0x700, 20),   # properties
    ]
    pos = 8
    for off, cnt in offsets:
        struct.pack_into("<I", buf, pos, off)
        struct.pack_into("<I", buf, pos + 4, cnt)
        pos += 8
    return bytes(buf)


def _make_encrypted_metadata() -> bytes:
    """Build metadata-like data with invalid magic (simulating encryption)."""
    import random
    random.seed(42)
    data = bytes(random.randint(0, 255) for _ in range(4096))
    # Put wrong magic (big-endian)
    struct.pack_into(">I", bytearray(data), 0, 0xDEADBEEF)
    return data


def _make_apk_with_metadata(
    target: Path,
    metadata_bytes: bytes | None = None,
    metadata_path: str = "assets/bin/Data/Managed/Metadata/global-metadata.dat",
    name: str = "test.apk",
    include_il2cpp: bool = True,
) -> Path:
    """Create a test APK containing metadata and optionally IL2CPP libs."""
    apk = target / name
    with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        if metadata_bytes is not None:
            zf.writestr(metadata_path, metadata_bytes)
        if include_il2cpp:
            zf.writestr("lib/arm64-v8a/libil2cpp.so", b"\x7fELF" + b"\x00" * 2048)
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)
    return apk


def _make_xapk_with_metadata(target: Path, metadata_bytes: bytes) -> Path:
    """Create an XAPK with metadata in the main APK and IL2CPP in a split."""
    xapk = target / "game.xapk"

    main_buf = io.BytesIO()
    with zipfile.ZipFile(main_buf, "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 64)
        zf.writestr("classes.dex", b"\x00" * 100)
        zf.writestr(
            "assets/bin/Data/Managed/Metadata/global-metadata.dat",
            metadata_bytes,
        )
        zf.writestr("assets/bin/Data/settings.asset", b"\x00" * 128)

    config_buf = io.BytesIO()
    with zipfile.ZipFile(config_buf, "w", zipfile.ZIP_DEFLATED) as zf:
        zf.writestr("AndroidManifest.xml", b"\x00" * 32)
        zf.writestr("lib/arm64-v8a/libil2cpp.so", b"\x7fELF" + b"\x00" * 4096)

    with zipfile.ZipFile(str(xapk), "w", zipfile.ZIP_DEFLATED) as xapk_zf:
        xapk_zf.writestr("com.example.game.apk", main_buf.getvalue())
        xapk_zf.writestr("config.arm64-v8a.apk", config_buf.getvalue())

    return xapk


@pytest.fixture
def detector() -> IL2CPPDetector:
    return IL2CPPDetector(config=AppConfig())


# =====================================================================
# Test: Metadata Version Detection
# =====================================================================

class TestMetadataDetection:
    def test_valid_metadata_v29(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_magic_valid is True
        assert report.metadata_version == MetadataVersion.V29
        assert report.metadata_version_raw == 29

    def test_valid_metadata_v24(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(24))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_magic_valid is True
        assert report.metadata_version == MetadataVersion.V24_0

    def test_encrypted_metadata(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_encrypted_metadata())
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_magic_valid is False
        assert report.metadata_version == MetadataVersion.UNKNOWN

    def test_no_metadata_file(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, metadata_bytes=None)
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_magic_valid is False

    def test_metadata_header_parsed(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_header is not None
        assert report.metadata_header.is_valid is True
        assert report.metadata_header.string_literal_offset == 0x100
        assert report.metadata_header.string_literal_count == 100

    def test_metadata_file_size(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        md = _make_metadata_bytes(29)
        apk = _make_apk_with_metadata(tmp_path, md)
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.metadata_file_size == len(md)


# =====================================================================
# Test: Unity Version Detection
# =====================================================================

class TestUnityVersionDetection:
    def test_version_from_apk_parser(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """When APK parser already found version, detector should use it."""
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        # Manually set version as APK parser would
        info.unity_build.unity_version = "2021.3.20f1"
        report = detector.analyse(info)
        assert report.unity_version == "2021.3.20f1"
        assert "APK parser" in report.unity_version_source

    def test_version_deep_scan(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """Version embedded in settings.asset should be found."""
        # Create settings.asset with version string
        settings = b"\x00" * 100 + b"2022.3.15f1" + b"\x00" * 100
        apk = tmp_path / "ver_test.apk"
        with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
            zf.writestr("AndroidManifest.xml", b"\x00" * 64)
            zf.writestr("assets/bin/Data/settings.asset", settings)
            zf.writestr(
                "assets/bin/Data/Managed/Metadata/global-metadata.dat",
                _make_metadata_bytes(29),
            )

        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        # Clear version from APK parser so detector falls through to deep scan
        info.unity_build.unity_version = ""
        report = detector.analyse(info)
        assert report.unity_version == "2022.3.15f1"
        assert "Deep" in report.unity_version_source

    def test_version_inferred_from_metadata(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """Version should be inferred from metadata version if no other source."""
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        # Ensure no version is found by parser
        info.unity_build.unity_version = ""
        report = detector.analyse(info)
        # Should infer from metadata v29
        assert report.unity_version != ""
        assert "Inferred" in report.unity_version_source


# =====================================================================
# Test: Architecture Detection
# =====================================================================

class TestArchitectureDetection:
    def test_arm64_detected(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert any("64" in a for a in report.binary_architectures)

    def test_64bit_flag(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.binary_is_64bit is True


# =====================================================================
# Test: Protection Detection
# =====================================================================

class TestProtectionDetection:
    def test_no_protections_clean_build(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.obfuscation_level == ObfuscationLevel.NONE

    def test_encrypted_metadata_detected(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_encrypted_metadata())
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        md_enc = [p for p in report.protections if p.protection_type == ProtectionType.IL2CPP_METADATA_ENCRYPTION]
        assert len(md_enc) == 1
        assert md_enc[0].detected is True

    def test_large_libil2cpp_embedded_metadata(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """Large libil2cpp.so suggests embedded metadata."""
        apk = tmp_path / "large.apk"
        large_so = b"\x7fELF" + b"\x00" * (60 * 1024 * 1024)  # 60 MB
        with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
            zf.writestr("AndroidManifest.xml", b"\x00" * 64)
            zf.writestr("lib/arm64-v8a/libil2cpp.so", large_so)
            zf.writestr(
                "assets/bin/Data/Managed/Metadata/global-metadata.dat",
                _make_metadata_bytes(29),
            )

        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        embed = [p for p in report.protections if p.protection_type == ProtectionType.METADATA_EMBEDDED]
        assert len(embed) == 1
        assert embed[0].detected is True

    def test_obfuscation_library_detected(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """Known obfuscation library in APK triggers detection."""
        apk = tmp_path / "obf.apk"
        with zipfile.ZipFile(str(apk), "w", zipfile.ZIP_DEFLATED) as zf:
            zf.writestr("AndroidManifest.xml", b"\x00" * 64)
            zf.writestr("lib/arm64-v8a/libil2cpp.so", b"\x7fELF" + b"\x00" * 1024)
            zf.writestr("lib/arm64-v8a/libjiagu.so", b"\x00" * 100)
            zf.writestr(
                "assets/bin/Data/Managed/Metadata/global-metadata.dat",
                _make_metadata_bytes(29),
            )

        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.is_protected is True

    def test_xapk_metadata_detected(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        """Metadata in XAPK inner APK should be detected."""
        xapk = _make_xapk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(xapk)
        report = detector.analyse(info)
        assert report.metadata_magic_valid is True
        assert report.metadata_version == MetadataVersion.V29


# =====================================================================
# Test: Confidence Scoring
# =====================================================================

class TestConfidenceScoring:
    def test_full_detection_high_confidence(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        info.unity_build.unity_version = "2021.3.20f1"
        report = detector.analyse(info)
        assert report.overall_confidence >= 0.7

    def test_no_metadata_low_confidence(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, metadata_bytes=None)
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        assert report.overall_confidence < 0.5


# =====================================================================
# Test: Report Generation
# =====================================================================

class TestReportGeneration:
    def test_report_contains_sections(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_metadata_bytes(29))
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        text = detector.generate_report(report)
        assert "DETECTION REPORT" in text
        assert "Metadata" in text
        assert "Unity Version" in text
        assert "Architecture" in text
        assert "Protection" in text
        assert "Confidence" in text

    def test_report_with_encrypted_metadata(self, detector: IL2CPPDetector, tmp_path: Path) -> None:
        apk = _make_apk_with_metadata(tmp_path, _make_encrypted_metadata())
        from il2cpp_recovery_studio.apk.parser import APKParser
        info = APKParser().parse(apk)
        report = detector.analyse(info)
        text = detector.generate_report(report)
        assert "DETECTION REPORT" in text
        assert "DETECTED" in text


# =====================================================================
# Test: Entropy Calculation
# =====================================================================

class TestEntropyCalculation:
    def test_zero_entropy(self) -> None:
        assert IL2CPPDetector._calculate_entropy(b"\x00" * 100) == 0.0

    def test_max_entropy(self) -> None:
        data = bytes(range(256)) * 4
        entropy = IL2CPPDetector._calculate_entropy(data)
        assert entropy == pytest.approx(8.0, abs=0.01)

    def test_empty_data(self) -> None:
        assert IL2CPPDetector._calculate_entropy(b"") == 0.0
