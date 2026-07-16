"""Data models for Unity asset reconstruction."""

from __future__ import annotations

import hashlib
import struct
from dataclasses import dataclass, field
from enum import Enum, IntEnum
from pathlib import Path
from typing import Any, Optional


class UnityVersion(Enum):
    UNITY_4 = "4.x"
    UNITY_5 = "5.x"
    UNITY_2017 = "2017.x"
    UNITY_2018 = "2018.x"
    UNITY_2019 = "2019.x"
    UNITY_2020 = "2020.x"
    UNITY_2021 = "2021.x"
    UNITY_2022 = "2022.x"
    UNITY_2023 = "2023.x"
    UNITY_6000 = "6000.x"
    UNKNOWN = "unknown"

    @classmethod
    def from_string(cls, version_str: str) -> UnityVersion:
        v = version_str.lower()
        if "6000" in v:
            return cls.UNITY_6000
        if "2023" in v:
            return cls.UNITY_2023
        if "2022" in v:
            return cls.UNITY_2022
        if "2021" in v:
            return cls.UNITY_2021
        if "2020" in v:
            return cls.UNITY_2020
        if "2019" in v:
            return cls.UNITY_2019
        if "2018" in v:
            return cls.UNITY_2018
        if "2017" in v:
            return cls.UNITY_2017
        if v.startswith("5."):
            return cls.UNITY_5
        if v.startswith("4."):
            return cls.UNITY_4
        return cls.UNKNOWN


class AssetCategory(Enum):
    CHARACTERS = "Characters"
    BUILDINGS = "Buildings"
    RESOURCES = "Resources"
    UI = "UI"
    WORLD = "World"
    AUDIO = "Audio"
    VIDEO = "Video"
    FONTS = "Fonts"
    SHADERS = "Shaders"
    MATERIALS = "Materials"
    EFFECTS = "Effects"
    LOCALIZATION = "Localization"
    SCRIPTS = "Scripts"
    SCENES = "Scenes"
    NETWORKING = "Networking"
    LOADING = "Loading"
    ADVERTISEMENTS = "Advertisements"
    TUTORIAL = "Tutorial"
    QUEST = "Quest"
    EVENTS = "Events"
    ACHIEVEMENTS = "Achievements"
    GENERAL = "General"
    UNKNOWN = "Unknown"

    @classmethod
    def from_name(cls, name: str) -> AssetCategory:
        n = name.lower()
        if any(k in n for k in ("hero", "character", "unit", "troop", "npc", "enemy", "boss", "animal", "avatar", "portrait")):
            return cls.CHARACTERS
        if any(k in n for k in ("building", "village", "structure", "tower", "barracks")):
            return cls.BUILDINGS
        if any(k in n for k in ("wood", "clay", "iron", "crop", "resource", "gold", "coin", "gem", "diamond")):
            return cls.RESOURCES
        if any(k in n for k in ("ui", "button", "panel", "hud", "inventory", "marketplace", "alliance", "chat", "settings", "icon")):
            return cls.UI
        if any(k in n for k in ("map", "terrain", "world", "minimap", "background", "sky")):
            return cls.WORLD
        if any(k in n for k in ("music", "sfx", "voice", "audio", "sound")):
            return cls.AUDIO
        if any(k in n for k in ("video", "movie", "cutscene", "cinematic")):
            return cls.VIDEO
        if any(k in n for k in ("font", "tmp", "textmesh")):
            return cls.FONTS
        if any(k in n for k in ("shader", "graph")):
            return cls.SHADERS
        if any(k in n for k in ("material", "mat")):
            return cls.MATERIALS
        if any(k in n for k in ("effect", "particle", "vfx", "fx")):
            return cls.EFFECTS
        if any(k in n for k in ("localization", "lang", "i18n", "l10n")):
            return cls.LOCALIZATION
        if any(k in n for k in ("scene", "level")):
            return cls.SCENES
        if any(k in n for k in ("loading", "splash", "logo")):
            return cls.LOADING
        if any(k in n for k in ("ad", "advert", "banner")):
            return cls.ADVERTISEMENTS
        if any(k in n for k in ("tutorial", "guide", "help")):
            return cls.TUTORIAL
        if any(k in n for k in ("quest", "mission", "task")):
            return cls.QUEST
        if any(k in n for k in ("event", "season", "festival")):
            return cls.EVENTS
        if any(k in n for k in ("achievement", "badge", "emblem")):
            return cls.ACHIEVEMENTS
        return cls.GENERAL


class SpriteClassification(Enum):
    PORTRAIT = "portrait"
    ICON = "icon"
    BACKGROUND = "background"
    BUTTON = "button"
    UI_PANEL = "ui_panel"
    CHARACTER = "character"
    BUILDING = "building"
    TERRAIN = "terrain"
    MAP = "map"
    SKILL = "skill"
    WEAPON = "weapon"
    ARMOR = "armor"
    ITEM = "item"
    RESOURCE = "resource"
    LOGO = "logo"
    SPLASH_SCREEN = "splash_screen"
    ANIMATION_FRAME = "animation_frame"
    UNKNOWN = "unknown"


class DuplicateType(Enum):
    EXACT = "exact"
    SCALED = "scaled"
    COMPRESSED = "compressed"
    COLOR_VARIANT = "color_variant"
    CROPPED = "cropped"
    FORMAT_DIFF = "format_diff"
    ATLAS_DUPLICATE = "atlas_duplicate"


@dataclass
class UnitySerializedHeader:
    magic: bytes = b""
    version: int = 0
    unity_version: str = ""
    platform: int = 0
    type_tree_size: int = 0
    object_count: int = 0
    object_info_offset: int = 0
    script_count: int = 0
    external_count: int = 0


@dataclass
class SerializedObjectInfo:
    class_id: int = 0
    path_id: int = 0
    byte_offset: int = 0
    byte_size: int = 0
    type_index: int = 0
    is_stripped: bool = False


@dataclass
class TypeTreeNode:
    type_name: str = ""
    byte_size: int = 0
    index: int = 0
    is_array: bool = False
    children: list[TypeTreeNode] = field(default_factory=list)


@dataclass
class SpriteRect:
    x: int = 0
    y: int = 0
    width: int = 0
    height: int = 0
    pivot_x: float = 0.5
    pivot_y: float = 0.5
    border_left: float = 0
    border_bottom: float = 0
    border_right: float = 0
    border_top: float = 0
    name: str = ""
    rotation: float = 0
    packing_mode: int = 0
    packing_tag: str = ""


@dataclass
class SpriteAtlasData:
    name: str = ""
    texture_name: str = ""
    texture_width: int = 0
    texture_height: int = 0
    sprites: list[SpriteRect] = field(default_factory=list)
    padding: int = 0
    packing_mode: int = 0
    packing_tag: str = ""
    guid: str = ""


@dataclass
class ExtractedAsset:
    name: str = ""
    path: str = ""
    guid: str = ""
    asset_type: str = ""
    category: AssetCategory = AssetCategory.GENERAL
    subcategory: str = ""
    data: bytes = b""
    width: int = 0
    height: int = 0
    format: str = ""
    file_path: Path = field(default_factory=Path)
    metadata: dict[str, Any] = field(default_factory=dict)
    dependencies: list[str] = field(default_factory=list)
    referenced_by: list[str] = field(default_factory=list)
    scenes: list[str] = field(default_factory=list)
    prefabs: list[str] = field(default_factory=list)
    classes: list[str] = field(default_factory=list)
    feature_group: str = ""
    confidence: float = 0.0
    sprite_classification: SpriteClassification = SpriteClassification.UNKNOWN
    cv_confidence: float = 0.0
    hash_md5: str = ""
    hash_sha256: str = ""

    def compute_hashes(self) -> None:
        if self.data:
            self.hash_md5 = hashlib.md5(self.data).hexdigest()
            self.hash_sha256 = hashlib.sha256(self.data).hexdigest()


@dataclass
class ExtractedSprite:
    name: str = ""
    atlas_name: str = ""
    x: int = 0
    y: int = 0
    width: int = 0
    height: int = 0
    pivot_x: float = 0.5
    pivot_y: float = 0.5
    border_left: float = 0
    border_bottom: float = 0
    border_right: float = 0
    border_top: float = 0
    rotation: float = 0
    packing_mode: int = 0
    packing_tag: str = ""
    pixels_per_unit: float = 100
    guid: str = ""
    image_data: bytes = b""
    metadata: dict[str, Any] = field(default_factory=dict)
    dependencies: list[str] = field(default_factory=list)
    referenced_by: list[str] = field(default_factory=list)
    classification: SpriteClassification = SpriteClassification.UNKNOWN


@dataclass
class AssetRelationship:
    source: str = ""
    target: str = ""
    relationship_type: str = ""
    strength: float = 1.0


@dataclass
class DuplicateGroup:
    duplicate_type: DuplicateType = DuplicateType.EXACT
    assets: list[str] = field(default_factory=list)
    primary: str = ""
    confidence: float = 1.0


@dataclass
class AssetBundleInfo:
    name: str = ""
    path: str = ""
    assets: list[str] = field(default_factory=list)
    dependencies: list[str] = field(default_factory=list)
    size: int = 0
    compressed: bool = False


@dataclass
class AddressableInfo:
    address: str = ""
    guid: str = ""
    asset_type: str = ""
    asset_name: str = ""
    labels: list[str] = field(default_factory=list)
    bundle_name: str = ""


@dataclass
class AnimationInfo:
    name: str = ""
    animation_type: str = ""
    clips: list[str] = field(default_factory=list)
    avatar: str = ""
    controller_for: str = ""


@dataclass
class ReconstructionResult:
    output_path: Path = field(default_factory=Path)
    total_assets: int = 0
    total_sprites_extracted: int = 0
    categories: dict[str, int] = field(default_factory=dict)
    feature_groups: dict[str, int] = field(default_factory=dict)
    duplicates_found: int = 0
    relationships_mapped: int = 0
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)
    assets: list[ExtractedAsset] = field(default_factory=list)
    sprites: list[ExtractedSprite] = field(default_factory=list)
    relationships: list[AssetRelationship] = field(default_factory=list)
    duplicates: list[DuplicateGroup] = field(default_factory=list)
    bundles: list[AssetBundleInfo] = field(default_factory=list)
    addressables: list[AddressableInfo] = field(default_factory=list)
    animations: list[AnimationInfo] = field(default_factory=list)
    unity_version: UnityVersion = UnityVersion.UNKNOWN
