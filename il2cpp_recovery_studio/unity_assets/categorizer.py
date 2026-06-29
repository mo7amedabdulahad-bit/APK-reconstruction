"""Intelligent asset categorization and classification system."""

from __future__ import annotations

import re
from typing import Optional
from pathlib import Path

from .models import ExtractedAsset, AssetCategory, SpriteClassification


# Keyword patterns for categorization
CATEGORY_PATTERNS: dict[AssetCategory, list[str]] = {
    AssetCategory.CHARACTERS: [
        r"hero", r"character", r"unit", r"troop", r"npc", r"enemy", r"boss",
        r"animal", r"avatar", r"portrait", r"fighter", r"warrior", r"archer",
        r"mage", r"knight", r"monster", r"creature", r"mob", r"mob_",
        r"soldier", r"guard", r"boss_", r"mini_boss", r"pet", r"mount",
        r"dragon", r"golem", r"demon", r"undead", r"zombie", r"skeleton",
        r"sprite_sheet", r"walk", r"run", r"idle", r"attack", r"death",
        r"hit", r"cast", r"jump", r"victory", r"defeat",
    ],
    AssetCategory.BUILDINGS: [
        r"building", r"village", r"structure", r"tower", r"barracks",
        r"house", r"farm", r"mine", r"market", r"wall", r"gate",
        r"castle", r"fort", r"temple", r"shrine", r"academy",
        r"smithy", r"workshop", r"warehouse", r"camp", r"tent",
    ],
    AssetCategory.RESOURCES: [
        r"wood", r"clay", r"iron", r"crop", r"resource", r"gold",
        r"coin", r"gem", r"diamond", r"crystal", r"ore", r"stone",
        r"lumber", r"food", r"grain", r"wheat", r"hay",
        r"resource_icon", r"currency",
    ],
    AssetCategory.UI: [
        r"^ui[_/]", r"button", r"panel", r"hud", r"inventory",
        r"marketplace", r"alliance", r"chat", r"settings", r"icon",
        r"tooltip", r"popup", r"dialog", r"modal", r"checkbox",
        r"slider", r"dropdown", r"toggle", r"scroll", r"input",
        r"tab", r"menu", r"bar", r"progress", r"health_bar",
        r"mana_bar", r"exp_bar", r"level_up", r"skill_tree",
        r"equipment", r"bag", r"backpack", r"slot", r"item_slot",
    ],
    AssetCategory.WORLD: [
        r"map", r"terrain", r"world", r"minimap", r"background",
        r"sky", r"ground", r"grass", r"water", r"sand", r"mountain",
        r"forest", r"desert", r"snow", r"volcano", r"ruins",
        r"tile", r"tilesheet", r"tilemap", r"landscape",
    ],
    AssetCategory.AUDIO: [
        r"music", r"sfx", r"voice", r"audio", r"sound",
        r"ambient", r"theme", r"battle_music", r"village_music",
        r"victory_sound", r"defeat_sound", r"click_sound",
        r"hit_sound", r"spell_sound", r"buff_sound",
    ],
    AssetCategory.VIDEO: [
        r"video", r"movie", r"cutscene", r"cinematic", r"trailer",
        r"intro", r"outro", r"loading_anim",
    ],
    AssetCategory.FONTS: [
        r"font", r"tmp", r"textmesh", r"arial", r"roboto",
        r"opensans", r"noto", r"lato", r"montserrat",
    ],
    AssetCategory.SHADERS: [
        r"shader", r"graph", r"shadergraph", r"vfx", r"particle",
    ],
    AssetCategory.MATERIALS: [
        r"^mat$", r"^mat_", r"material", r"_mat\.",
    ],
    AssetCategory.EFFECTS: [
        r"effect", r"particle", r"vfx", r"fx", r"explosion",
        r"fire", r"smoke", r"spark", r"glow", r"flash",
        r"heal", r"buff", r"debuff", r"aura",
    ],
    AssetCategory.LOCALIZATION: [
        r"localization", r"lang", r"i18n", r"l10n",
        r"string_", r"translation", r"locale",
    ],
    AssetCategory.SCENES: [
        r"scene", r"level", r"_scene\.", r"_level\.",
        r"battle_scene", r"village_scene", r"map_scene",
    ],
    AssetCategory.LOADING: [
        r"loading", r"splash", r"logo", r"startup",
        r"loading_screen", r"progress_bar",
    ],
    AssetCategory.ADVERTISEMENTS: [
        r"ad[_/]", r"advert", r"banner", r"interstitial",
        r"rewarded", r"promo",
    ],
    AssetCategory.TUTORIAL: [
        r"tutorial", r"guide", r"help", r"tip",
        r"arrow", r"highlight", r"hand",
    ],
    AssetCategory.QUEST: [
        r"quest", r"mission", r"task", r"objective",
        r"reward", r"completion",
    ],
    AssetCategory.EVENTS: [
        r"event", r"season", r"festival", r"holiday",
        r"limited_time", r"special",
    ],
    AssetCategory.ACHIEVEMENTS: [
        r"achievement", r"badge", r"emblem", r"trophy",
        r"rank", r"title",
    ],
}

# Sub-category patterns for feature grouping
FEATURE_PATTERNS: dict[str, list[str]] = {
    "Hero": [
        r"hero", r"character", r"portrait", r"hero_icon",
        r"hero_skill", r"hero_equipment", r"hero_level",
    ],
    "Building": [
        r"building", r"village", r"structure", r"construction",
        r"upgrade", r"build_level",
    ],
    "Combat": [
        r"battle", r"combat", r"fight", r"attack", r"defend",
        r"damage", r"health", r"shield", r"weapon",
    ],
    "Marketplace": [
        r"market", r"trade", r"shop", r"store", r"buy", r"sell",
        r"offer", r"price", r"currency",
    ],
    "Alliance": [
        r"alliance", r"guild", r"clan", r"team", r"ally",
        r"member", r"rank", r"donation",
    ],
    "Inventory": [
        r"inventory", r"bag", r"backpack", r"item", r"equipment",
        r"gear", r"armor", r"weapon", r"accessory",
    ],
    "Skills": [
        r"skill", r"ability", r"spell", r"power", r"talent",
        r"passive", r"active", r"cooldown",
    ],
    "Quest": [
        r"quest", r"mission", r"task", r"objective",
        r"achievement", r"reward", r"daily",
    ],
    "Settings": [
        r"setting", r"option", r"config", r"preference",
        r"volume", r"quality", r"language",
    ],
    "Social": [
        r"chat", r"message", r"friend", r"invite",
        r"mail", r"notification", r"social",
    ],
    "Map": [
        r"map", r"world", r"terrain", r"tile",
        r"region", r"zone", r"area",
    ],
    "Tutorial": [
        r"tutorial", r"guide", r"help", r"newbie",
        r"first_time", r"onboard",
    ],
}


class AssetCategorizer:
    """Intelligently categorize assets based on multiple signals."""

    def __init__(self):
        self.custom_categories: dict[str, list[str]] = {}
        self.category_rules: dict[str, callable] = {}

    def categorize(self, asset: ExtractedAsset) -> ExtractedAsset:
        """Categorize a single asset based on all available information."""
        # Score each category
        scores: dict[AssetCategory, float] = {}

        for category, patterns in CATEGORY_PATTERNS.items():
            score = self._score_asset(asset, patterns)
            if score > 0:
                scores[category] = score

        # Apply name-based scoring
        name_score = self._score_by_name(asset)
        for cat, score in name_score.items():
            scores[cat] = scores.get(cat, 0) + score

        # Apply path-based scoring
        path_score = self._score_by_path(asset)
        for cat, score in path_score.items():
            scores[cat] = scores.get(cat, 0) + score

        # Apply type-based scoring
        type_score = self._score_by_type(asset)
        for cat, score in type_score.items():
            scores[cat] = scores.get(cat, 0) + score

        # Apply size-based scoring
        size_score = self._score_by_size(asset)
        for cat, score in size_score.items():
            scores[cat] = scores.get(cat, 0) + score

        # Select highest scoring category
        if scores:
            best_category = max(scores, key=scores.get)
            asset.category = best_category
            asset.confidence = min(1.0, scores[best_category] / 3.0)

        # Determine subcategory/feature group
        asset.feature_group = self._determine_feature_group(asset)

        return asset

    def categorize_batch(self, assets: list[ExtractedAsset]) -> list[ExtractedAsset]:
        """Categorize a batch of assets."""
        for asset in assets:
            self.categorize(asset)
        return assets

    def _score_asset(self, asset: ExtractedAsset, patterns: list[str]) -> float:
        """Score an asset against a list of patterns."""
        score = 0.0
        name = asset.name.lower()
        path = asset.path.lower()

        for pattern in patterns:
            if re.search(pattern, name):
                score += 1.0
            if re.search(pattern, path):
                score += 0.5

        return score

    def _score_by_name(self, asset: ExtractedAsset) -> dict[AssetCategory, float]:
        """Score asset based on its name."""
        scores: dict[AssetCategory, float] = {}
        name = asset.name.lower()

        # UI elements
        ui_keywords = ["btn", "button", "panel", "frame", "window", "dialog",
                       "popup", "tooltip", "tab", "bar", "menu", "hud",
                       "inventory", "slot", "icon"]
        for kw in ui_keywords:
            if kw in name:
                scores[AssetCategory.UI] = scores.get(AssetCategory.UI, 0) + 0.8

        # Character-related
        char_keywords = ["hero", "unit", "char", "avatar", "portrait", "face",
                        "walk", "run", "idle", "attack", "death", "hit"]
        for kw in char_keywords:
            if kw in name:
                scores[AssetCategory.CHARACTERS] = scores.get(AssetCategory.CHARACTERS, 0) + 0.8

        # Resource icons
        res_keywords = ["wood", "clay", "iron", "crop", "gold", "gem", "coin"]
        for kw in res_keywords:
            if kw in name:
                scores[AssetCategory.RESOURCES] = scores.get(AssetCategory.RESOURCES, 0) + 1.0

        # Building
        build_keywords = ["building", "village", "town", "castle", "tower", "wall"]
        for kw in build_keywords:
            if kw in name:
                scores[AssetCategory.BUILDINGS] = scores.get(AssetCategory.BUILDINGS, 0) + 1.0

        return scores

    def _score_by_path(self, asset: ExtractedAsset) -> dict[AssetCategory, float]:
        """Score asset based on its file path."""
        scores: dict[AssetCategory, float] = {}
        path = asset.path.lower()

        path_mappings = {
            "ui": AssetCategory.UI,
            "textures/ui": AssetCategory.UI,
            "sprites/ui": AssetCategory.UI,
            "characters": AssetCategory.CHARACTERS,
            "heroes": AssetCategory.CHARACTERS,
            "units": AssetCategory.CHARACTERS,
            "buildings": AssetCategory.BUILDINGS,
            "village": AssetCategory.BUILDINGS,
            "resources": AssetCategory.RESOURCES,
            "audio": AssetCategory.AUDIO,
            "music": AssetCategory.AUDIO,
            "sfx": AssetCategory.AUDIO,
            "fonts": AssetCategory.FONTS,
            "shaders": AssetCategory.SHADERS,
            "materials": AssetCategory.MATERIALS,
            "effects": AssetCategory.EFFECTS,
            "particles": AssetCategory.EFFECTS,
            "scenes": AssetCategory.SCENES,
            "levels": AssetCategory.SCENES,
            "localization": AssetCategory.LOCALIZATION,
            "loading": AssetCategory.LOADING,
            "splash": AssetCategory.LOADING,
            "tutorial": AssetCategory.TUTORIAL,
            "quests": AssetCategory.QUEST,
            "achievements": AssetCategory.ACHIEVEMENTS,
            "map": AssetCategory.WORLD,
            "terrain": AssetCategory.WORLD,
            "market": AssetCategory.UI,
            "alliance": AssetCategory.UI,
            "chat": AssetCategory.UI,
            "settings": AssetCategory.UI,
        }

        for path_key, category in path_mappings.items():
            if path_key in path:
                scores[category] = scores.get(category, 0) + 1.0

        return scores

    def _score_by_type(self, asset: ExtractedAsset) -> dict[AssetCategory, float]:
        """Score asset based on its detected type."""
        scores: dict[AssetCategory, float] = {}
        asset_type = asset.asset_type.lower()

        type_mappings = {
            "audioclip": AssetCategory.AUDIO,
            "font": AssetCategory.FONTS,
            "shader": AssetCategory.SHADERS,
            "material": AssetCategory.MATERIALS,
            "scene": AssetCategory.SCENES,
            "animatorcontroller": AssetCategory.CHARACTERS,
            "animationclip": AssetCategory.CHARACTERS,
            "terraindata": AssetCategory.WORLD,
        }

        for type_key, category in type_mappings.items():
            if type_key in asset_type:
                scores[category] = scores.get(category, 0) + 0.5

        return scores

    def _score_by_size(self, asset: ExtractedAsset) -> dict[AssetCategory, float]:
        """Score asset based on its dimensions and file size."""
        scores: dict[AssetCategory, float] = {}

        if asset.width > 0 and asset.height > 0:
            area = asset.width * asset.height

            # Very large images are likely backgrounds or maps
            if area > 1000000:
                scores[AssetCategory.WORLD] = scores.get(AssetCategory.WORLD, 0) + 0.5
                scores[AssetCategory.LOADING] = scores.get(AssetCategory.LOADING, 0) + 0.3

            # Medium images could be UI backgrounds or portraits
            elif area > 100000:
                scores[AssetCategory.UI] = scores.get(AssetCategory.UI, 0) + 0.3

            # Small images are likely icons
            elif area < 4096:
                scores[AssetCategory.UI] = scores.get(AssetCategory.UI, 0) + 0.5

        return scores

    def _determine_feature_group(self, asset: ExtractedAsset) -> str:
        """Determine the feature group an asset belongs to."""
        name = asset.name.lower()
        path = asset.path.lower()
        combined = f"{name} {path}"

        for feature, patterns in FEATURE_PATTERNS.items():
            for pattern in patterns:
                if re.search(pattern, combined):
                    return feature

        return asset.category.value

    def discover_patterns(self, assets: list[ExtractedAsset]) -> dict[str, list[str]]:
        """Discover new patterns from asset names and paths."""
        discovered: dict[str, list[str]] = {}

        # Extract common prefixes and suffixes
        names = [a.name.lower() for a in assets]
        prefixes: dict[str, int] = {}
        for name in names:
            parts = re.split(r'[_\-/.]', name)
            if len(parts) > 1:
                prefix = parts[0]
                prefixes[prefix] = prefixes.get(prefix, 0) + 1

        # Find significant prefixes (appearing 3+ times)
        for prefix, count in prefixes.items():
            if count >= 3:
                related = [n for n in names if n.startswith(prefix)]
                discovered[prefix] = related

        return discovered
