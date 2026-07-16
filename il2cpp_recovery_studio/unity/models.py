"""Data models for Unity analysis."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class UnityComponentType(Enum):
    """Detected Unity component types."""

    GAME_MANAGER = auto()
    NETWORK_MANAGER = auto()
    LOGIN_MANAGER = auto()
    BATTLE_MANAGER = auto()
    SCENE_MANAGER = auto()
    VILLAGE_MANAGER = auto()
    ALLIANCE_MANAGER = auto()
    TRADE_MANAGER = auto()
    INVENTORY_MANAGER = auto()
    BUILDING_MANAGER = auto()
    COMBAT_MANAGER = auto()
    PLAYER_MANAGER = auto()
    LOCALIZATION = auto()
    ANALYTICS = auto()
    UI = auto()
    SCRIPTABLE_OBJECT = auto()
    CUSTOM = auto()


class UnityPatternCategory(Enum):
    """Categories of Unity patterns."""

    MANAGER = "Manager"
    SINGLETON = "Singleton"
    EVENT_HANDLER = "EventHandler"
    DATA_CONTAINER = "DataContainer"
    NETWORK = "Network"
    UI = "UI"
    SAVE_SYSTEM = "SaveSystem"
    CUSTOM = "Custom"


@dataclass
class UnityComponentDetection:
    """A detected Unity component/manager."""

    class_name: str
    namespace: str = ""
    component_type: UnityComponentType = UnityComponentType.CUSTOM
    category: UnityPatternCategory = UnityPatternCategory.CUSTOM
    confidence: float = 0.0
    base_classes: list[str] = field(default_factory=list)
    implements_interfaces: list[str] = field(default_factory=list)
    method_count: int = 0
    field_count: int = 0
    is_singleton: bool = False
    is_dont_destroy_on_load: bool = False
    has_update: bool = False
    has_start: bool = False
    has_awake: bool = False
    depends_on: list[str] = field(default_factory=list)
    depended_by: list[str] = field(default_factory=list)
    metadata_index: int = -1

    @property
    def full_name(self) -> str:
        if self.namespace:
            return f"{self.namespace}.{self.class_name}"
        return self.class_name


@dataclass
class DependencyEdge:
    """A dependency edge between two classes."""

    source: str
    target: str
    kind: str = "reference"  # "reference", "inheritance", "interface"
    weight: float = 1.0


@dataclass
class UnityAnalysisResult:
    """Aggregated Unity analysis result."""

    components: list[UnityComponentDetection] = field(default_factory=list)
    dependencies: list[DependencyEdge] = field(default_factory=list)
    detected_patterns: dict[str, int] = field(default_factory=dict)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_components(self) -> int:
        return len(self.components)

    @property
    def managers(self) -> list[UnityComponentDetection]:
        return [c for c in self.components if c.category == UnityPatternCategory.MANAGER]

    @property
    def singletons(self) -> list[UnityComponentDetection]:
        return [c for c in self.components if c.is_singleton]

    def by_type(self, t: UnityComponentType) -> list[UnityComponentDetection]:
        return [c for c in self.components if c.component_type == t]

    def by_category(self, cat: UnityPatternCategory) -> list[UnityComponentDetection]:
        return [c for c in self.components if c.category == cat]

    def get_component(self, class_name: str) -> UnityComponentDetection | None:
        for c in self.components:
            if c.class_name == class_name or c.full_name == class_name:
                return c
        return None

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {
            "total_components": self.total_components,
            "managers": len(self.managers),
            "singletons": len(self.singletons),
            "dependencies": len(self.dependencies),
        }
        for c in self.components:
            key = c.component_type.name
            stats[key] = stats.get(key, 0) + 1
        self.statistics = stats
        return stats
