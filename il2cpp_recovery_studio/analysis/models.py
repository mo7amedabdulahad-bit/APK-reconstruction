"""Data models for IL2CPP detection results."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto
from typing import Optional


class MetadataVersion(Enum):
    """Known IL2CPP metadata versions mapped to Unity releases."""

    UNKNOWN = 0
    V15 = 15       # Unity 4.6 / 5.0
    V16 = 16       # Unity 5.1
    V19 = 19       # Unity 5.2 – 5.4
    V20 = 20       # Unity 5.5
    V21 = 21       # Unity 5.6
    V22 = 22       # Unity 2017.1
    V23 = 23       # Unity 2017.2
    V24_0 = 240    # Unity 2017.4  (community 24.0)
    V24_1 = 241    # Unity 2018.1
    V24_2 = 242    # Unity 2018.3
    V24_3 = 243    # Unity 2019.1
    V24_4 = 244    # Unity 2019.2
    V24_5 = 245    # Unity 2019.3 – 2019.4
    V27_0 = 270    # Unity 2020.1
    V27_1 = 271    # Unity 2020.2.4+
    V29 = 29       # Unity 2021.2+
    V31 = 31       # Unity 2023.1+
    V33 = 33       # Unity 6 (2024+)
    V39 = 39       # Unity 6000.x (2025+)

    @classmethod
    def from_raw(cls, raw_version: int) -> MetadataVersion:
        """Map a raw 4-byte version integer to a known version."""
        mapping = {
            15: cls.V15, 16: cls.V16, 19: cls.V19, 20: cls.V20,
            21: cls.V21, 22: cls.V22, 23: cls.V23, 24: cls.V24_0,
            27: cls.V27_0, 29: cls.V29, 31: cls.V31, 33: cls.V33,
            39: cls.V39,
        }
        return mapping.get(raw_version, cls.UNKNOWN)

    @property
    def display_name(self) -> str:
        """Human-friendly version string."""
        names = {
            15: "15 (Unity 4.6/5.0)", 16: "16 (Unity 5.1)",
            19: "19 (Unity 5.2-5.4)", 20: "20 (Unity 5.5)",
            21: "21 (Unity 5.6)", 22: "22 (Unity 2017.1)",
            23: "23 (Unity 2017.2)", 240: "24.0 (Unity 2017.4)",
            241: "24.1 (Unity 2018.1)", 242: "24.2 (Unity 2018.3)",
            243: "24.3 (Unity 2019.1)", 244: "24.4 (Unity 2019.2)",
            245: "24.5 (Unity 2019.3-4)", 270: "27.0 (Unity 2020.1)",
            271: "27.1 (Unity 2020.2+)", 29: "29 (Unity 2021.2+)",
            31: "31 (Unity 2023.1+)", 33: "33 (Unity 6/2024+)",
            39: "39 (Unity 6000.x/2025+)",
        }
        return names.get(self.value, f"Unknown ({self.value})")


class ObfuscationLevel(Enum):
    """Detected obfuscation severity."""

    NONE = auto()
    LIGHT = auto()
    MODERATE = auto()
    HEAVY = auto()
    UNKNOWN = auto()


class ProtectionType(Enum):
    """Detected protection mechanisms."""

    NONE = auto()
    STRING_ENCRYPTION = auto()
    IL2CPP_METADATA_ENCRYPTION = auto()
    IL2CPP_BINARY_ENCRYPTION = auto()
    METADATA_EMBEDDED = auto()
    CODE混淆 = auto()
    ANTI_TAMPER = auto()
    ROOT_DETECTION = auto()
    DEBUGGER_DETECTION = auto()
    SIGNATURE_VERIFICATION = auto()
    UNKNOWN = auto()


class PackerType(Enum):
    """Detected packing / shell."""

    NONE = auto()
    UNKNOWN_PACKER = auto()


@dataclass(frozen=True)
class MetadataHeader:
    """Parsed header of a global-metadata.dat file."""

    magic: int
    version_raw: int
    version: MetadataVersion
    string_literal_offset: int
    string_literal_count: int
    string_literal_data_offset: int
    string_literal_data_count: int
    string_offset: int
    string_count: int
    events_offset: int
    events_count: int
    properties_offset: int
    properties_count: int
    total_header_size: int
    is_valid: bool


@dataclass
class ProtectionDetection:
    """Result of a single protection check."""

    protection_type: ProtectionType
    detected: bool
    confidence: float  # 0.0 – 1.0
    details: str = ""


@dataclass
class DetectionReport:
    """Complete IL2CPP detection report produced by :class:`IL2CPPDetector`."""

    # ── Metadata ──
    metadata_magic_valid: bool = False
    metadata_version_raw: int = 0
    metadata_version: MetadataVersion = MetadataVersion.UNKNOWN
    metadata_file_size: int = 0
    metadata_header: Optional[MetadataHeader] = None

    # ── Unity ──
    unity_version: str = ""
    unity_version_source: str = ""

    # ── Binary ──
    binary_architectures: list[str] = field(default_factory=list)
    binary_is_64bit: bool = False
    binary_endian: str = "little"

    # ── Protection / Obfuscation ──
    obfuscation_level: ObfuscationLevel = ObfuscationLevel.NONE
    protections: list[ProtectionDetection] = field(default_factory=list)
    packer_detected: PackerType = PackerType.NONE

    # ── Confidence ──
    overall_confidence: float = 0.0

    # ── Warnings / errors ──
    warnings: list[str] = field(default_factory=list)
    errors: list[str] = field(default_factory=list)

    @property
    def has_metadata(self) -> bool:
        return self.metadata_magic_valid and self.metadata_version != MetadataVersion.UNKNOWN

    @property
    def is_protected(self) -> bool:
        return any(p.detected for p in self.protections)

    def detected_protections(self) -> list[ProtectionDetection]:
        return [p for p in self.protections if p.detected]
