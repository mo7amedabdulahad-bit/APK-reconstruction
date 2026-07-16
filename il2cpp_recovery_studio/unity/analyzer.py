"""Unity analysis engine: detects manager patterns, singletons, and dependency graphs."""
from __future__ import annotations

import re

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.unity.models import (
    DependencyEdge,
    UnityAnalysisResult,
    UnityComponentDetection,
    UnityComponentType,
    UnityPatternCategory,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod, RecoveredField

logger = get_logger("unity.analyzer")

MANAGER_PATTERNS: dict[str, UnityComponentType] = {
    r"(?i)GameManager$": UnityComponentType.GAME_MANAGER,
    r"(?i)NetworkManager$": UnityComponentType.NETWORK_MANAGER,
    r"(?i)LoginManager$": UnityComponentType.LOGIN_MANAGER,
    r"(?i)BattleManager$": UnityComponentType.BATTLE_MANAGER,
    r"(?i)SceneManager$": UnityComponentType.SCENE_MANAGER,
    r"(?i)VillageManager$": UnityComponentType.VILLAGE_MANAGER,
    r"(?i)AllianceManager$": UnityComponentType.ALLIANCE_MANAGER,
    r"(?i)TradeManager$": UnityComponentType.TRADE_MANAGER,
    r"(?i)InventoryManager$": UnityComponentType.INVENTORY_MANAGER,
    r"(?i)BuildingManager$": UnityComponentType.BUILDING_MANAGER,
    r"(?i)CombatManager$": UnityComponentType.COMBAT_MANAGER,
    r"(?i)PlayerManager$": UnityComponentType.PLAYER_MANAGER,
    r"(?i)Localization$": UnityComponentType.LOCALIZATION,
    r"(?i)Analytics$": UnityComponentType.ANALYTICS,
    r"(?i)(?:UI|Canvas|Panel|Manager)$": UnityComponentType.UI,
    r"(?i)ScriptableObject$": UnityComponentType.SCRIPTABLE_OBJECT,
}

SINGLETON_METHODS = {"get_Instance", "get_Instance", "GetInstance", "Awake"}
DONT_DESTROY = "DontDestroyOnLoad"
UPDATE_METHODS = {"Update", "FixedUpdate", "LateUpdate"}
LIFECYCLE_METHODS = {"Awake", "Start", "OnEnable", "OnDisable", "OnDestroy"}


class UnityAnalyzer:
    """Analyzes recovered Unity classes for common patterns and dependencies."""

    def analyze(
        self, recovered_classes: list[RecoveredClass]
    ) -> UnityAnalysisResult:
        result = UnityAnalysisResult()

        for rc in recovered_classes:
            detection = self._detect_component(rc)
            if detection:
                result.components.append(detection)

        self._build_dependencies(result)
        self._detect_singleton_patterns(recovered_classes, result)
        self._compute_statistics(result)

        logger.info(
            "Unity analysis: %d components detected, %d managers, %d singletons",
            result.total_components,
            len(result.managers),
            len(result.singletons),
        )
        return result

    def _detect_component(self, rc: RecoveredClass) -> UnityComponentDetection | None:
        component_type = UnityComponentType.CUSTOM
        category = UnityPatternCategory.CUSTOM
        confidence = 0.0

        for pattern, ctype in MANAGER_PATTERNS.items():
            if re.search(pattern, rc.name):
                component_type = ctype
                category = UnityPatternCategory.MANAGER
                confidence = 0.7
                break

        if rc.parent_class:
            parent_lower = rc.parent_class.lower()
            if "scriptableobject" in parent_lower:
                component_type = UnityComponentType.SCRIPTABLE_OBJECT
                category = UnityPatternCategory.DATA_CONTAINER
                confidence = 0.9
            elif "monobehaviour" in parent_lower:
                if category == UnityPatternCategory.CUSTOM:
                    category = UnityPatternCategory.CUSTOM
                    confidence = max(confidence, 0.4)

        method_names = {m.name for m in rc.methods}
        if any(m in method_names for m in UPDATE_METHODS):
            confidence = max(confidence, 0.3)
        if any(m in method_names for m in LIFECYCLE_METHODS):
            confidence = max(confidence, 0.3)

        if confidence < 0.2 and category == UnityPatternCategory.CUSTOM:
            return None

        base_classes = []
        if rc.parent_class:
            base_classes.append(rc.parent_class)

        return UnityComponentDetection(
            class_name=rc.name,
            namespace=rc.namespace,
            component_type=component_type,
            category=category,
            confidence=confidence,
            base_classes=base_classes,
            method_count=len(rc.methods),
            field_count=len(rc.fields),
            has_update="Update" in method_names,
            has_start="Start" in method_names,
            has_awake="Awake" in method_names,
        )

    def _detect_singleton_patterns(
        self, recovered_classes: list[RecoveredClass], result: UnityAnalysisResult
    ) -> None:
        for rc in recovered_classes:
            is_singleton = False
            method_names = {m.name for m in rc.methods}
            field_names = {f.name.lower() for f in rc.fields}

            if "instance" in field_names or "_instance" in field_names:
                is_singleton = True
            if any(m in method_names for m in SINGLETON_METHODS):
                is_singleton = True

            if is_singleton:
                comp = result.get_component(rc.name)
                if comp:
                    comp.is_singleton = True
                else:
                    result.components.append(
                        UnityComponentDetection(
                            class_name=rc.name,
                            namespace=rc.namespace,
                            component_type=UnityComponentType.CUSTOM,
                            category=UnityPatternCategory.SINGLETON,
                            confidence=0.6,
                            is_singleton=True,
                            method_count=len(rc.methods),
                            field_count=len(rc.fields),
                        )
                    )

    def _build_dependencies(self, result: UnityAnalysisResult) -> None:
        comp_names = {c.full_name for c in result.components}

        for comp in result.components:
            for dep in comp.depends_on:
                if dep in comp_names:
                    result.dependencies.append(
                        DependencyEdge(source=comp.full_name, target=dep, kind="reference")
                    )

    def _compute_statistics(self, result: UnityAnalysisResult) -> None:
        result.detected_patterns = {}
        for c in result.components:
            key = c.component_type.name
            result.detected_patterns[key] = result.detected_patterns.get(key, 0) + 1
        result.compute_statistics()
