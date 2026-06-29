"""Data models for asset analysis."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class AssetType(Enum):
    """Types of Unity assets."""

    SCENE = auto()
    PREFAB = auto()
    TEXTURE = auto()
    MATERIAL = auto()
    SHADER = auto()
    FONT = auto()
    ANIMATION = auto()
    AUDIO = auto()
    VIDEO = auto()
    MESH = auto()
    SPRITE = auto()
    SCRIPTABLE_OBJECT = auto()
    ASSET_BUNDLE = auto()
    ADDRESSABLE = auto()
    SETTINGS = auto()
    UNKNOWN = auto()


class AssetFormat(Enum):
    """Asset file format."""

    FBX = auto()
    OBJ = auto()
    PNG = auto()
    JPG = auto()
    TGA = auto()
    DDS = auto()
    WAV = auto()
    MP3 = auto()
    OGG = auto()
    MP4 = auto()
    UNITY = auto()
    PREFAB = auto()
    ASSET = auto()
    BUNDLE = auto()
    UNKNOWN = auto()


@dataclass
class AssetInfo:
    """A single Unity asset."""

    name: str
    asset_type: AssetType = AssetType.UNKNOWN
    path: str = ""
    asset_format: AssetFormat = AssetFormat.UNKNOWN
    file_size: int = 0
    reference_count: int = 0
    dependencies: list[str] = field(default_factory=list)
    tags: list[str] = field(default_factory=list)
    addressable_key: str = ""
    bundle_name: str = ""
    confidence: float = 0.0
    metadata_token: int = 0
    properties: dict[str, str] = field(default_factory=dict)


@dataclass
class AssetBundleInfo:
    """Info about a Unity asset bundle."""

    name: str
    assets: list[AssetInfo] = field(default_factory=list)
    file_size: int = 0
    format_version: int = 0
    dependencies: list[str] = field(default_factory=list)


@dataclass
class AssetAnalysisResult:
    """Aggregated asset analysis result."""

    assets: list[AssetInfo] = field(default_factory=list)
    bundles: list[AssetBundleInfo] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_assets(self) -> int:
        return len(self.assets)

    @property
    def total_bundles(self) -> int:
        return len(self.bundles)

    def by_type(self, t: AssetType) -> list[AssetInfo]:
        return [a for a in self.assets if a.asset_type == t]

    def by_name(self, name: str) -> list[AssetInfo]:
        return [a for a in self.assets if name.lower() in a.name.lower()]

    def by_format(self, f: AssetFormat) -> list[AssetInfo]:
        return [a for a in self.assets if a.asset_format == f]

    def by_bundle(self, bundle: str) -> list[AssetInfo]:
        return [a for a in self.assets if a.bundle_name == bundle]

    def search(self, query: str) -> list[AssetInfo]:
        q = query.lower()
        return [a for a in self.assets if q in a.name.lower() or q in a.path.lower()]

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {"total": self.total_assets, "bundles": self.total_bundles}
        for a in self.assets:
            key = a.asset_type.name
            stats[key] = stats.get(key, 0) + 1
        self.statistics = stats
        return stats
