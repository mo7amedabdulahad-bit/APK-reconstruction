"""Tests for Phase 11: Asset analysis."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.assets.models import (
    AssetAnalysisResult,
    AssetBundleInfo,
    AssetFormat,
    AssetInfo,
    AssetType,
)
from il2cpp_recovery_studio.assets.analyzer import AssetAnalyzer, _classify_by_name
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField


# ── Model tests ──────────────────────────────────────────────────────


class TestAssetInfo:
    def test_default(self):
        a = AssetInfo(name="TestAsset")
        assert a.asset_type == AssetType.UNKNOWN
        assert a.file_size == 0
        assert a.dependencies == []

    def test_search(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="MainMenuScene", asset_type=AssetType.SCENE),
            AssetInfo(name="BattleScene", asset_type=AssetType.SCENE),
            AssetInfo(name="PlayerModel", asset_type=AssetType.MESH),
        ]
        found = r.search("Scene")
        assert len(found) == 2

    def test_by_type(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="a", asset_type=AssetType.SCENE),
            AssetInfo(name="b", asset_type=AssetType.PREFAB),
        ]
        assert len(r.by_type(AssetType.SCENE)) == 1

    def test_by_name(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="MainMenu", asset_type=AssetType.SCENE),
            AssetInfo(name="BattleMap", asset_type=AssetType.SCENE),
        ]
        assert len(r.by_name("Main")) == 1

    def test_by_format(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="a", asset_format=AssetFormat.PNG),
            AssetInfo(name="b", asset_format=AssetFormat.JPG),
        ]
        assert len(r.by_format(AssetFormat.PNG)) == 1

    def test_by_bundle(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="a", bundle_name="b1"),
            AssetInfo(name="b", bundle_name="b2"),
        ]
        assert len(r.by_bundle("b1")) == 1

    def test_compute_statistics(self):
        r = AssetAnalysisResult()
        r.assets = [
            AssetInfo(name="a", asset_type=AssetType.SCENE),
            AssetInfo(name="b", asset_type=AssetType.SCENE),
            AssetInfo(name="c", asset_type=AssetType.PREFAB),
        ]
        stats = r.compute_statistics()
        assert stats["total"] == 3
        assert stats["SCENE"] == 2
        assert stats["PREFAB"] == 1


class TestAssetBundle:
    def test_bundle(self):
        b = AssetBundleInfo(name="test", assets=[AssetInfo(name="a")])
        assert len(b.assets) == 1
        assert b.name == "test"


# ── Engine tests ─────────────────────────────────────────────────────


class TestAssetAnalyzerDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        classes = []

        scenes = RecoveredClass(name="SceneManager", namespace="Game", confidence=0.9)
        scenes.fields = [
            RecoveredField(name="sceneAsset", type_name="SceneAsset", default_value=""),
            RecoveredField(name="levelAsset", type_name="LevelData", default_value=""),
        ]
        classes.append(scenes)

        audio = RecoveredClass(name="SoundManager", namespace="Game", confidence=0.9)
        audio.fields = [
            RecoveredField(name="bgm", type_name="AudioClip", default_value=""),
            RecoveredField(name="jump", type_name="SoundEffect", default_value=""),
        ]
        classes.append(audio)

        ui = RecoveredClass(name="UIManager", namespace="Game", confidence=0.9)
        ui.fields = [
            RecoveredField(name="fontAsset", type_name="Font", default_value=""),
            RecoveredField(name="iconTexture", type_name="Texture2D", default_value=""),
        ]
        classes.append(ui)

        return classes

    def test_empty_input(self):
        result = AssetAnalyzer().analyze([])
        assert result.total_assets == 0

    def test_detects_scene_assets(self):
        result = AssetAnalyzer().analyze(self._make_classes())
        scenes = result.by_type(AssetType.SCENE)
        assert len(scenes) >= 1

    def test_detects_audio_assets(self):
        result = AssetAnalyzer().analyze(self._make_classes())
        audio = result.by_type(AssetType.AUDIO)
        assert len(audio) >= 1

    def test_detects_texture_assets(self):
        result = AssetAnalyzer().analyze(self._make_classes())
        textures = result.by_type(AssetType.TEXTURE)
        assert len(textures) >= 1

    def test_detects_font_assets(self):
        result = AssetAnalyzer().analyze(self._make_classes())
        fonts = result.by_type(AssetType.FONT)
        assert len(fonts) >= 1

    def test_statistics(self):
        result = AssetAnalyzer().analyze(self._make_classes())
        stats = result.compute_statistics()
        assert stats["total"] >= 4

    def test_full_pipeline(self):
        classes = []
        for i in range(5):
            rc = RecoveredClass(name=f"Asset{i}", namespace="Ns", confidence=0.8)
            rc.fields = [
                RecoveredField(name=f"scene{i}", type_name="Scene", default_value=""),
                RecoveredField(name=f"prefab{i}", type_name="Prefab", default_value=""),
            ]
            classes.append(rc)

        result = AssetAnalyzer().analyze(classes)
        assert result.total_assets >= 10
        stats = result.compute_statistics()
        assert stats["total"] >= 10
