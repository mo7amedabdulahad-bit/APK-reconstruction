from __future__ import annotations

import struct
from dataclasses import dataclass, field
from enum import Enum, auto
from pathlib import Path
from typing import Optional


class Architecture(Enum):
    """Supported CPU architectures."""

    ARMV7 = auto()
    ARM64 = auto()
    X86 = auto()
    X86_64 = auto()
    UNKNOWN = auto()

    @classmethod
    def from_string(cls, value: str) -> Architecture:
        mapping = {
            "armeabi-v7a": cls.ARMV7,
            "arm64-v8a": cls.ARM64,
            "x86": cls.X86,
            "x86_64": cls.X86_64,
        }
        return mapping.get(value.lower().strip(), cls.UNKNOWN)


class BuildType(Enum):
    """Unity build type indicators."""

    IL2CPP = auto()
    MONO = auto()
    UNKNOWN = auto()


class ProtectionType(Enum):
    """Detected protection / obfuscation."""

    NONE = auto()
    OBFUSCATION = auto()
    STRING_ENCRYPTION = auto()
    IL2CPP_ENCRYPTION = auto()
    METADATA_ENCRYPTION = auto()
    PACKER = auto()
    UNKNOWN = auto()


@dataclass(frozen=True)
class APKEntry:
    """A single entry inside the ZIP archive."""

    path: str
    uncompressed_size: int
    compressed_size: int
    crc32: int


@dataclass
class NativeLibrary:
    """A native .so library found inside the APK."""

    path: str
    architecture: Architecture
    size: int
    is_il2cpp: bool = False
    is_unity: bool = False


@dataclass
class AndroidManifest:
    """Parsed Android manifest information."""

    package_name: str = ""
    version_name: str = ""
    version_code: int = 0
    min_sdk: int = 0
    target_sdk: int = 0
    permissions: list[str] = field(default_factory=list)
    activities: list[str] = field(default_factory=list)
    services: list[str] = field(default_factory=list)
    receivers: list[str] = field(default_factory=list)
    providers: list[str] = field(default_factory=list)


@dataclass
class UnityBuildInfo:
    """Detected Unity build characteristics."""

    unity_version: str = ""
    build_type: BuildType = BuildType.UNKNOWN
    is_il2cpp: bool = False
    is_mono: bool = False
    architectures: list[Architecture] = field(default_factory=list)
    has_global_metadata: bool = False
    has_assembly_cs: bool = False
    global_metadata_path: str = ""
    assembly_cs_path: str = ""
    il2cpp_dump_path: str = ""
    libil2cpp_paths: list[str] = field(default_factory=list)
    metadata_version: int = 0


@dataclass
class APKInfo:
    """Complete analysis result for an APK file."""

    file_path: Path
    file_size: int = 0
    is_valid_zip: bool = False
    manifest: AndroidManifest = field(default_factory=AndroidManifest)
    unity_build: UnityBuildInfo = field(default_factory=UnityBuildInfo)
    native_libraries: list[NativeLibrary] = field(default_factory=list)
    all_entries: list[APKEntry] = field(default_factory=list)
    detected_architectures: list[Architecture] = field(default_factory=list)
    unity_assets_found: list[str] = field(default_factory=list)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_entries(self) -> int:
        return len(self.all_entries)

    @property
    def has_unity(self) -> bool:
        return self.unity_build.unity_version != ""

    @property
    def has_il2cpp(self) -> bool:
        return self.unity_build.is_il2cpp

    @property
    def has_mono(self) -> bool:
        return self.unity_build.is_mono
