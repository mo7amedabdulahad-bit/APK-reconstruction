"""Data models for string analysis."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class StringCategory(Enum):
    """Categories for recovered strings."""

    ERROR = auto()
    DEBUG = auto()
    LOCALIZATION = auto()
    URL = auto()
    JSON = auto()
    SQL = auto()
    API_KEY = auto()
    UNITY_EVENT = auto()
    SCENE_NAME = auto()
    FILE_PATH = auto()
    CLASS_NAME = auto()
    METHOD_NAME = auto()
    CONFIGURATION = auto()
    LOG = auto()
    UNKNOWN = auto()


@dataclass
class ExtractedString:
    """A single extracted and categorized string."""

    value: str
    category: StringCategory = StringCategory.UNKNOWN
    confidence: float = 0.0
    source_class: str = ""
    source_method: str = ""
    address: int = 0
    references: list[str] = field(default_factory=list)
    metadata_token: int = 0

    @property
    def length(self) -> int:
        return len(self.value)

    @property
    def is_empty(self) -> bool:
        return len(self.value) == 0


@dataclass
class StringAnalysisResult:
    """Aggregated string analysis result."""

    strings: list[ExtractedString] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_strings(self) -> int:
        return len(self.strings)

    @property
    def unique_strings(self) -> int:
        return len({s.value for s in self.strings})

    def by_category(self, cat: StringCategory) -> list[ExtractedString]:
        return [s for s in self.strings if s.category == cat]

    def by_class(self, class_name: str) -> list[ExtractedString]:
        return [s for s in self.strings if s.source_class == class_name]

    def by_length(self, min_len: int = 0, max_len: int = 0) -> list[ExtractedString]:
        result = self.strings
        if min_len > 0:
            result = [s for s in result if s.length >= min_len]
        if max_len > 0:
            result = [s for s in result if s.length <= max_len]
        return result

    def search(self, query: str, case_sensitive: bool = False) -> list[ExtractedString]:
        if case_sensitive:
            return [s for s in self.strings if query in s.value]
        query_lower = query.lower()
        return [s for s in self.strings if query_lower in s.value.lower()]

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {
            "total": self.total_strings,
            "unique": self.unique_strings,
        }
        for s in self.strings:
            key = s.category.name
            stats[key] = stats.get(key, 0) + 1
        self.statistics = stats
        return stats
