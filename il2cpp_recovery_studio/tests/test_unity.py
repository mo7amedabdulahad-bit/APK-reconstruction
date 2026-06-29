"""Tests for Phase 8: Unity analysis."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.unity.models import (
    DependencyEdge,
    UnityAnalysisResult,
    UnityComponentDetection,
    UnityComponentType,
    UnityPatternCategory,
)
from il2cpp_recovery_studio.unity.analyzer import UnityAnalyzer
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod


# ── Model tests ──────────────────────────────────────────────────────


class TestUnityComponentDetection:
    def test_full_name_with_namespace(self):
        c = UnityComponentDetection(class_name="GameManager", namespace="Game")
        assert c.full_name == "Game.GameManager"

    def test_full_name_no_namespace(self):
        c = UnityComponentDetection(class_name="GameManager")
        assert c.full_name == "GameManager"


class TestUnityAnalysisResult:
    def _make_result(self) -> UnityAnalysisResult:
        r = UnityAnalysisResult()
        r.components = [
            UnityComponentDetection(class_name="GameManager", component_type=UnityComponentType.GAME_MANAGER,
                                    category=UnityPatternCategory.MANAGER, is_singleton=True),
            UnityComponentDetection(class_name="NetworkManager", component_type=UnityComponentType.NETWORK_MANAGER,
                                    category=UnityPatternCategory.MANAGER),
            UnityComponentDetection(class_name="Player", component_type=UnityComponentType.CUSTOM,
                                    category=UnityPatternCategory.CUSTOM),
        ]
        return r

    def test_total_components(self):
        r = self._make_result()
        assert r.total_components == 3

    def test_managers(self):
        r = self._make_result()
        assert len(r.managers) == 2

    def test_singletons(self):
        r = self._make_result()
        assert len(r.singletons) == 1

    def test_by_type(self):
        r = self._make_result()
        assert len(r.by_type(UnityComponentType.GAME_MANAGER)) == 1

    def test_by_category(self):
        r = self._make_result()
        assert len(r.by_category(UnityPatternCategory.MANAGER)) == 2

    def test_get_component(self):
        r = self._make_result()
        assert r.get_component("GameManager") is not None
        assert r.get_component("Nonexistent") is None

    def test_compute_statistics(self):
        r = self._make_result()
        stats = r.compute_statistics()
        assert stats["total_components"] == 3
        assert stats["managers"] == 2
        assert stats["singletons"] == 1


# ── Engine tests ─────────────────────────────────────────────────────


class TestUnityAnalyzerDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        classes = []

        gm = RecoveredClass(name="GameManager", namespace="Game", parent_class="UnityEngine.MonoBehaviour",
                            source_tool="cpp2il", confidence=0.9)
        gm.fields = [RecoveredField(name="Instance", type_name="GameManager")]
        gm.methods = [
            RecoveredMethod(name="Awake", return_type="void"),
            RecoveredMethod(name="Update", return_type="void"),
        ]
        classes.append(gm)

        nm = RecoveredClass(name="NetworkManager", namespace="Game", parent_class="UnityEngine.MonoBehaviour",
                            source_tool="cpp2il", confidence=0.85)
        nm.methods = [
            RecoveredMethod(name="Start", return_type="void"),
            RecoveredMethod(name="Connect", return_type="void"),
        ]
        classes.append(nm)

        player = RecoveredClass(name="PlayerController", namespace="Game",
                                parent_class="UnityEngine.MonoBehaviour", confidence=0.8)
        player.fields = [RecoveredField(name="speed", type_name="float")]
        player.methods = [
            RecoveredMethod(name="Update", return_type="void"),
            RecoveredMethod(name="Move", return_type="void"),
        ]
        classes.append(player)

        return classes

    def test_detects_game_manager(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        gm = result.get_component("GameManager")
        assert gm is not None
        assert gm.component_type == UnityComponentType.GAME_MANAGER

    def test_detects_network_manager(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        nm = result.get_component("NetworkManager")
        assert nm is not None
        assert nm.component_type == UnityComponentType.NETWORK_MANAGER

    def test_detects_singleton(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        gm = result.get_component("GameManager")
        assert gm is not None
        assert gm.is_singleton

    def test_detects_lifecycle_methods(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        gm = result.get_component("GameManager")
        assert gm.has_update
        assert gm.has_awake

    def test_detects_monobehaviour(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        pc = result.get_component("PlayerController")
        assert pc is not None

    def test_empty_input(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze([])
        assert result.total_components == 0

    def test_statistics(self):
        analyzer = UnityAnalyzer()
        result = analyzer.analyze(self._make_classes())
        stats = result.compute_statistics()
        assert stats["total_components"] >= 2
        assert stats["managers"] >= 1

    def test_battle_manager(self):
        rc = RecoveredClass(name="BattleManager", namespace="Game",
                            parent_class="UnityEngine.MonoBehaviour", confidence=0.8)
        rc.methods = [RecoveredMethod(name="Start", return_type="void")]
        analyzer = UnityAnalyzer()
        result = analyzer.analyze([rc])
        assert result.get_component("BattleManager") is not None

    def test_inventory_manager(self):
        rc = RecoveredClass(name="InventoryManager", namespace="Game",
                            parent_class="UnityEngine.MonoBehaviour", confidence=0.8)
        rc.methods = [RecoveredMethod(name="Awake", return_type="void")]
        analyzer = UnityAnalyzer()
        result = analyzer.analyze([rc])
        bm = result.get_component("InventoryManager")
        assert bm is not None
        assert bm.component_type == UnityComponentType.INVENTORY_MANAGER

    def test_scriptable_object(self):
        rc = RecoveredClass(name="WeaponData", namespace="Game",
                            parent_class="UnityEngine.ScriptableObject", confidence=0.9)
        rc.fields = [RecoveredField(name="damage", type_name="float")]
        analyzer = UnityAnalyzer()
        result = analyzer.analyze([rc])
        wd = result.get_component("WeaponData")
        assert wd is not None
        assert wd.component_type == UnityComponentType.SCRIPTABLE_OBJECT

    def test_all_managers_detected(self):
        manager_names = [
            "GameManager", "NetworkManager", "LoginManager", "BattleManager",
            "SceneManager", "VillageManager", "AllianceManager", "TradeManager",
            "InventoryManager", "BuildingManager", "CombatManager", "PlayerManager",
        ]
        classes = []
        for name in manager_names:
            rc = RecoveredClass(name=name, namespace="Game",
                                parent_class="UnityEngine.MonoBehaviour", confidence=0.8)
            rc.methods = [RecoveredMethod(name="Start", return_type="void")]
            classes.append(rc)

        analyzer = UnityAnalyzer()
        result = analyzer.analyze(classes)
        assert result.total_components >= 12
        assert len(result.managers) >= 12
