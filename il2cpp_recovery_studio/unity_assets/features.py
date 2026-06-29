"""Game feature grouping - reconstruct game systems from assets."""

from __future__ import annotations

import re
from typing import Any
from collections import defaultdict
from pathlib import Path

from .models import ExtractedAsset, AssetCategory


# Feature detection patterns
FEATURE_RULES: dict[str, dict[str, Any]] = {
    "Hero": {
        "keywords": ["hero", "character", "unit", "avatar", "portrait", "face",
                      "walk", "run", "idle", "attack", "death", "hit", "cast",
                      "skill", "ability", "spell", "equipment", "gear", "weapon",
                      "armor", "class", "level", "exp", "hp", "mp", "stat"],
        "types": ["AnimationClip", "AnimatorController", "Sprite", "Texture2D",
                  "Prefab", "ScriptableObject", "MonoBehaviour"],
        "subcategories": {
            "Images": ["png", "jpg", "jpeg", "tga", "bmp"],
            "Animations": ["anim", "controller"],
            "Prefabs": ["prefab"],
            "Skills": ["skill", "spell", "ability"],
            "Equipment": ["weapon", "armor", "gear", "equipment", "accessory"],
            "Icons": ["icon", "ico"],
            "Audio": ["mp3", "ogg", "wav"],
            "Localization": ["localization", "lang"],
            "Documentation": ["txt", "md", "json"],
        },
    },
    "Building": {
        "keywords": ["building", "village", "structure", "tower", "barracks",
                      "house", "farm", "mine", "market", "wall", "gate",
                      "castle", "fort", "temple", "shrine", "academy",
                      "smithy", "workshop", "warehouse", "camp", "construction",
                      "upgrade", "build_level"],
        "types": ["Texture2D", "Sprite", "Prefab", "Material"],
        "subcategories": {
            "Images": ["png", "jpg", "jpeg", "tga"],
            "Icons": ["icon"],
            "Prefabs": ["prefab"],
            "Materials": ["mat"],
            "Localization": ["localization"],
        },
    },
    "Resource": {
        "keywords": ["wood", "clay", "iron", "crop", "resource", "gold",
                      "coin", "gem", "diamond", "crystal", "ore", "stone",
                      "lumber", "food", "grain", "wheat", "currency"],
        "types": ["Texture2D", "Sprite"],
        "subcategories": {
            "Icons": ["icon"],
            "Images": ["png", "jpg"],
        },
    },
    "Combat": {
        "keywords": ["battle", "combat", "fight", "attack", "defend",
                      "damage", "health", "shield", "weapon", "hit",
                      "critical", "dodge", "block", "miss", "damage_number"],
        "types": ["AnimationClip", "AudioClip", "Texture2D", "Prefab"],
        "subcategories": {
            "Animations": ["anim", "controller"],
            "Audio": ["mp3", "ogg", "wav"],
            "Effects": ["effect", "particle", "vfx"],
            "Images": ["png", "jpg"],
        },
    },
    "Marketplace": {
        "keywords": ["market", "trade", "shop", "store", "buy", "sell",
                      "offer", "price", "merchant", "auction", "exchange"],
        "types": ["Texture2D", "Sprite", "Prefab", "ScriptableObject"],
        "subcategories": {
            "UI": ["button", "panel", "frame", "dialog"],
            "Icons": ["icon"],
            "Images": ["png", "jpg"],
        },
    },
    "Alliance": {
        "keywords": ["alliance", "guild", "clan", "team", "ally",
                      "member", "rank", "donation", "diplomacy"],
        "types": ["Texture2D", "Sprite", "Prefab", "ScriptableObject"],
        "subcategories": {
            "UI": ["button", "panel", "frame"],
            "Icons": ["icon"],
            "Images": ["png", "jpg"],
        },
    },
    "Inventory": {
        "keywords": ["inventory", "bag", "backpack", "item", "equipment",
                      "gear", "armor", "weapon", "accessory", "slot",
                      "stash", "vault", "chest"],
        "types": ["Texture2D", "Sprite", "Prefab"],
        "subcategories": {
            "Items": ["item", "potion", "scroll", "ring", "amulet"],
            "Icons": ["icon", "slot"],
            "UI": ["button", "panel", "frame", "tooltip"],
        },
    },
    "UI": {
        "keywords": ["ui", "button", "panel", "frame", "hud", "menu",
                      "dialog", "popup", "tooltip", "tab", "bar",
                      "progress", "health_bar", "mana_bar", "input"],
        "types": ["Texture2D", "Sprite", "Font", "Prefab"],
        "subcategories": {
            "Buttons": ["btn", "button"],
            "Panels": ["panel", "frame", "window", "dialog"],
            "Icons": ["icon"],
            "HUD": ["hud", "health", "mana", "exp"],
            "Fonts": ["font", "tmp"],
        },
    },
    "World": {
        "keywords": ["map", "terrain", "world", "minimap", "background",
                      "sky", "ground", "grass", "water", "tile", "tilesheet",
                      "tilemap", "landscape", "region", "zone"],
        "types": ["Texture2D", "Sprite", "TerrainData", "Material"],
        "subcategories": {
            "Maps": ["map", "minimap", "world"],
            "Terrain": ["terrain", "tile", "tilesheet"],
            "Backgrounds": ["background", "sky", "backdrop"],
        },
    },
    "Audio": {
        "keywords": ["music", "sfx", "voice", "audio", "sound",
                      "ambient", "theme", "battle_music", "village_music"],
        "types": ["AudioClip"],
        "subcategories": {
            "Music": ["music", "theme", "ost"],
            "SFX": ["sfx", "effect", "sound"],
            "Voice": ["voice", "dialog", "narration"],
        },
    },
    "Loading": {
        "keywords": ["loading", "splash", "logo", "startup", "intro",
                      "loading_screen", "progress_bar", "title"],
        "types": ["Texture2D", "Sprite", "AnimationClip"],
        "subcategories": {
            "Screens": ["loading", "splash"],
            "Logos": ["logo", "title"],
            "Animations": ["anim"],
        },
    },
    "Tutorial": {
        "keywords": ["tutorial", "guide", "help", "tip", "arrow",
                      "highlight", "hand", "newbie", "first_time", "onboard"],
        "types": ["Texture2D", "Sprite", "ScriptableObject"],
        "subcategories": {
            "Images": ["png", "jpg"],
            "UI": ["button", "panel", "tooltip"],
        },
    },
    "Quest": {
        "keywords": ["quest", "mission", "task", "objective",
                      "reward", "completion", "daily", "weekly"],
        "types": ["Texture2D", "Sprite", "ScriptableObject"],
        "subcategories": {
            "Icons": ["icon"],
            "Images": ["png", "jpg"],
            "Data": ["json", "csv"],
        },
    },
    "Settings": {
        "keywords": ["setting", "option", "config", "preference",
                      "volume", "quality", "language", "toggle"],
        "types": ["Texture2D", "Sprite", "ScriptableObject"],
        "subcategories": {
            "UI": ["button", "panel", "toggle", "slider"],
            "Icons": ["icon"],
        },
    },
}


class GameFeatureGrouper:
    """Group assets by game features/systems."""

    def __init__(self):
        self.feature_groups: dict[str, dict[str, list[ExtractedAsset]]] = defaultdict(lambda: defaultdict(list))
        self.asset_to_features: dict[str, list[str]] = defaultdict(list)

    def group_assets(self, assets: list[ExtractedAsset]) -> dict[str, dict[str, list[ExtractedAsset]]]:
        """Group all assets into game feature categories."""
        for asset in assets:
            features = self._detect_features(asset)

            for feature in features:
                subcategory = self._detect_subcategory(asset, feature)
                self.feature_groups[feature][subcategory].append(asset)
                self.asset_to_features[asset.name].append(feature)

            # Assign primary feature to asset
            if features:
                asset.feature_group = features[0]

        return dict(self.feature_groups)

    def _detect_features(self, asset: ExtractedAsset) -> list[str]:
        """Detect which features an asset belongs to."""
        name = asset.name.lower()
        path = asset.path.lower()
        combined = f"{name} {path} {asset.asset_type.lower()}"

        scores: dict[str, float] = {}

        for feature, rules in FEATURE_RULES.items():
            score = 0.0

            # Check keywords
            for keyword in rules["keywords"]:
                if keyword in combined:
                    score += 1.0

            # Check types
            if asset.asset_type in rules.get("types", []):
                score += 0.3

            if score > 0:
                scores[feature] = score

        # Return features sorted by score
        if scores:
            sorted_features = sorted(scores.items(), key=lambda x: x[1], reverse=True)
            # Return top features (above threshold)
            return [f for f, s in sorted_features if s >= 1.0][:3]

        return ["General"]

    def _detect_subcategory(self, asset: ExtractedAsset, feature: str) -> str:
        """Detect the subcategory within a feature."""
        rules = FEATURE_RULES.get(feature, {})
        subcategories = rules.get("subcategories", {})

        name = asset.name.lower()
        ext = Path(asset.name).suffix.lower().lstrip(".")

        for subcat, patterns in subcategories.items():
            for pattern in patterns:
                if pattern in name or pattern == ext:
                    return subcat

        # Default subcategory based on type
        type_defaults = {
            "Texture2D": "Images",
            "Sprite": "Images",
            "AudioClip": "Audio",
            "Font": "Fonts",
            "Shader": "Shaders",
            "Material": "Materials",
            "Prefab": "Prefabs",
            "Scene": "Scenes",
            "AnimationClip": "Animations",
            "AnimatorController": "Animations",
            "ScriptableObject": "Data",
            "MonoBehaviour": "Scripts",
            "TextAsset": "Data",
        }

        return type_defaults.get(asset.asset_type, "Other")

    def get_feature_summary(self) -> dict[str, dict[str, int]]:
        """Get a summary of features and their subcategory counts."""
        summary = {}
        for feature, subcats in self.feature_groups.items():
            summary[feature] = {
                subcat: len(assets)
                for subcat, assets in subcats.items()
            }
            summary[feature]["_total"] = sum(len(a) for a in subcats.values())
        return summary

    def get_asset_features(self, asset_name: str) -> list[str]:
        """Get all features an asset belongs to."""
        return self.asset_to_features.get(asset_name, ["General"])

    def build_feature_directories(self) -> dict[str, list[str]]:
        """Build the directory structure for feature groups."""
        dirs = {}
        for feature, subcats in self.feature_groups.items():
            dirs[feature] = list(subcats.keys())
        return dirs
