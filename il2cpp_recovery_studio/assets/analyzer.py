"""Asset analysis engine: identifies Unity assets from recovered data."""
from __future__ import annotations

import re

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.assets.models import (
    AssetAnalysisResult,
    AssetBundleInfo,
    AssetFormat,
    AssetInfo,
    AssetType,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField

logger = get_logger("assets.analyzer")

EXTENSION_MAP: dict[str, tuple[AssetType, AssetFormat]] = {
    ".unity": (AssetType.SCENE, AssetFormat.UNITY),
    ".prefab": (AssetType.PREFAB, AssetFormat.PREFAB),
    ".png": (AssetType.TEXTURE, AssetFormat.PNG),
    ".jpg": (AssetType.TEXTURE, AssetFormat.JPG),
    ".jpeg": (AssetType.TEXTURE, AssetFormat.JPG),
    ".tga": (AssetType.TEXTURE, AssetFormat.TGA),
    ".dds": (AssetType.TEXTURE, AssetFormat.DDS),
    ".mat": (AssetType.MATERIAL, AssetFormat.ASSET),
    ".shader": (AssetType.SHADER, AssetFormat.ASSET),
    ".ttf": (AssetType.FONT, AssetFormat.UNKNOWN),
    ".otf": (AssetType.FONT, AssetFormat.UNKNOWN),
    ".wav": (AssetType.AUDIO, AssetFormat.WAV),
    ".mp3": (AssetType.AUDIO, AssetFormat.MP3),
    ".ogg": (AssetType.AUDIO, AssetFormat.OGG),
    ".mp4": (AssetType.VIDEO, AssetFormat.MP4),
    ".fbx": (AssetType.MESH, AssetFormat.FBX),
    ".obj": (AssetType.MESH, AssetFormat.OBJ),
    ".asset": (AssetType.SCRIPTABLE_OBJECT, AssetFormat.ASSET),
}

SCENE_KEYWORDS = {"Scene", "Level", "Map", "Stage", "Arena", "Zone"}
PREFAB_KEYWORDS = {"Prefab", "Template", "Blueprint", "Prototype"}
SHADER_KEYWORDS = {"Shader", "Material", "Render"}
AUDIO_KEYWORDS = {"Audio", "Sound", "Music", "SFX", "Voice", "Ambient"}
VIDEO_KEYWORDS = {"Video", "Cutscene", "Movie", "Playback"}
TEXTURE_KEYWORDS = {"Texture", "Sprite", "Image", "Icon", "SpriteRenderer"}
FONT_KEYWORDS = {"Font", "Text", "TMP"}
MESH_KEYWORDS = {"Mesh", "Model", "MeshFilter", "MeshRenderer"}


def _classify_by_name(name: str) -> AssetType | None:
    n = name.lower()
    for kw in SCENE_KEYWORDS:
        if kw.lower() in n:
            return AssetType.SCENE
    for kw in PREFAB_KEYWORDS:
        if kw.lower() in n:
            return AssetType.PREFAB
    for kw in SHADER_KEYWORDS:
        if kw.lower() in n:
            return AssetType.SHADER
    for kw in AUDIO_KEYWORDS:
        if kw.lower() in n:
            return AssetType.AUDIO
    for kw in VIDEO_KEYWORDS:
        if kw.lower() in n:
            return AssetType.VIDEO
    for kw in TEXTURE_KEYWORDS:
        if kw.lower() in n:
            return AssetType.TEXTURE
    for kw in FONT_KEYWORDS:
        if kw.lower() in n:
            return AssetType.FONT
    for kw in MESH_KEYWORDS:
        if kw.lower() in n:
            return AssetType.MESH
    return None


class AssetAnalyzer:
    """Analyzes recovered Unity classes for asset references."""

    def analyze(self, recovered_classes: list[RecoveredClass]) -> AssetAnalysisResult:
        result = AssetAnalysisResult()

        for rc in recovered_classes:
            self._analyze_class(rc, result)

        result.compute_statistics()
        logger.info(
            "Asset analysis: %d assets, %d bundles, %d types",
            result.total_assets,
            result.total_bundles,
            len(result.statistics) - 2,
        )
        return result

    def _analyze_class(self, rc: RecoveredClass, result: AssetAnalysisResult) -> None:
        for field in rc.fields:
            for asset in self._classify_field(field):
                result.assets.append(asset)

    def _classify_field(self, field: RecoveredField) -> list[AssetInfo]:
        assets: list[AssetInfo] = []
        tname = field.type_name.lower()
        fname = field.name

        if "scene" in tname or "level" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.SCENE,
                path=field.default_value or "",
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "prefab" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.PREFAB,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "texture" in tname or "sprite" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.TEXTURE,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "material" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.MATERIAL,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "shader" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.SHADER,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "audio" in tname or "sound" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.AUDIO,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "video" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.VIDEO,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "font" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.FONT,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "mesh" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.MESH,
                confidence=0.8,
                metadata_token=field.token,
            ))
        if "scriptableobject" in tname:
            assets.append(AssetInfo(
                name=fname, asset_type=AssetType.SCRIPTABLE_OBJECT,
                confidence=0.8,
                metadata_token=field.token,
            ))

        if not assets and field.default_value:
            ext = "." + field.default_value.rsplit(".", 1)[-1].lower() if "." in field.default_value else ""
            if ext in EXTENSION_MAP:
                atype, aformat = EXTENSION_MAP[ext]
                assets.append(AssetInfo(
                    name=fname, asset_type=atype, asset_format=aformat,
                    path=field.default_value,
                    confidence=0.9,
                    metadata_token=field.token,
                ))

        if not assets:
            inferred = _classify_by_name(fname)
            if inferred:
                assets.append(AssetInfo(
                    name=fname, asset_type=inferred,
                    confidence=0.6,
                    metadata_token=field.token,
                ))

        return assets
