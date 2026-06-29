"""Unit tests for IL2CPP detection models."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.analysis.models import (
    DetectionReport,
    MetadataHeader,
    MetadataVersion,
    ObfuscationLevel,
    PackerType,
    ProtectionDetection,
    ProtectionType,
)


class TestMetadataVersion:
    def test_known_versions(self) -> None:
        assert MetadataVersion.from_raw(15) == MetadataVersion.V15
        assert MetadataVersion.from_raw(24) == MetadataVersion.V24_0
        assert MetadataVersion.from_raw(27) == MetadataVersion.V27_0
        assert MetadataVersion.from_raw(29) == MetadataVersion.V29
        assert MetadataVersion.from_raw(31) == MetadataVersion.V31
        assert MetadataVersion.from_raw(33) == MetadataVersion.V33

    def test_unknown_version(self) -> None:
        assert MetadataVersion.from_raw(999) == MetadataVersion.UNKNOWN
        assert MetadataVersion.from_raw(0) == MetadataVersion.UNKNOWN

    def test_display_name(self) -> None:
        assert "Unity 2021" in MetadataVersion.V29.display_name
        assert "Unity 2019" in MetadataVersion.V24_5.display_name
        assert "Unity 6" in MetadataVersion.V33.display_name
        assert "Unknown" in MetadataVersion.UNKNOWN.display_name


class TestObfuscationLevel:
    def test_ordering(self) -> None:
        assert ObfuscationLevel.NONE.value < ObfuscationLevel.LIGHT.value
        assert ObfuscationLevel.LIGHT.value < ObfuscationLevel.MODERATE.value
        assert ObfuscationLevel.MODERATE.value < ObfuscationLevel.HEAVY.value


class TestProtectionType:
    def test_all_members(self) -> None:
        assert ProtectionType.NONE is not None
        assert ProtectionType.STRING_ENCRYPTION is not None
        assert ProtectionType.IL2CPP_METADATA_ENCRYPTION is not None
        assert ProtectionType.IL2CPP_BINARY_ENCRYPTION is not None
        assert ProtectionType.METADATA_EMBEDDED is not None


class TestPackerType:
    def test_none(self) -> None:
        assert PackerType.NONE is not None


class TestProtectionDetection:
    def test_detected(self) -> None:
        pd = ProtectionDetection(
            protection_type=ProtectionType.STRING_ENCRYPTION,
            detected=True,
            confidence=0.8,
            details="test",
        )
        assert pd.detected is True
        assert pd.confidence == 0.8

    def test_not_detected(self) -> None:
        pd = ProtectionDetection(
            protection_type=ProtectionType.NONE,
            detected=False,
            confidence=0.0,
        )
        assert pd.detected is False


class TestDetectionReport:
    def test_defaults(self) -> None:
        report = DetectionReport()
        assert report.metadata_magic_valid is False
        assert report.has_metadata is False
        assert report.is_protected is False
        assert report.overall_confidence == 0.0

    def test_has_metadata_true(self) -> None:
        report = DetectionReport(
            metadata_magic_valid=True,
            metadata_version=MetadataVersion.V29,
        )
        assert report.has_metadata is True

    def test_is_protected_true(self) -> None:
        report = DetectionReport(
            protections=[
                ProtectionDetection(
                    protection_type=ProtectionType.STRING_ENCRYPTION,
                    detected=True,
                    confidence=0.7,
                )
            ]
        )
        assert report.is_protected is True

    def test_detected_protections(self) -> None:
        report = DetectionReport(
            protections=[
                ProtectionDetection(ProtectionType.STRING_ENCRYPTION, True, 0.7),
                ProtectionDetection(ProtectionType.NONE, False, 0.0),
                ProtectionDetection(ProtectionType.ANTI_TAMPER, True, 0.5),
            ]
        )
        detected = report.detected_protections()
        assert len(detected) == 2


class TestMetadataHeader:
    def test_valid_header(self) -> None:
        h = MetadataHeader(
            magic=0xAF1BB1FA,
            version_raw=29,
            version=MetadataVersion.V29,
            string_literal_offset=0x100,
            string_literal_count=200,
            string_literal_data_offset=0x200,
            string_literal_data_count=500,
            string_offset=0x400,
            string_count=300,
            events_offset=0x600,
            events_count=10,
            properties_offset=0x700,
            properties_count=20,
            total_header_size=64,
            is_valid=True,
        )
        assert h.magic == 0xAF1BB1FA
        assert h.version == MetadataVersion.V29
        assert h.is_valid is True
