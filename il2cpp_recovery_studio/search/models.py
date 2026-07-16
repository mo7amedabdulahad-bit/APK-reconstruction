"""Data models for the search engine."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class SearchMode(Enum):
    """Search mode."""

    EXACT = auto()
    CONTAINS = auto()
    REGEX = auto()
    FUZZY = auto()


class SearchScope(Enum):
    """What to search."""

    ALL = auto()
    CLASSES = auto()
    METHODS = auto()
    FIELDS = auto()
    STRINGS = auto()
    NAMESPACES = auto()
    ADDRESSES = auto()
    ASSETS = auto()


@dataclass
class SearchResult:
    """A single search result."""

    name: str
    kind: str = ""
    namespace: str = ""
    address: int = 0
    metadata_token: int = 0
    score: float = 1.0
    snippet: str = ""
    source_file: str = ""


@dataclass
class SearchQuery:
    """A search query."""

    text: str
    mode: SearchMode = SearchMode.CONTAINS
    scope: SearchScope = SearchScope.ALL
    case_sensitive: bool = False
    max_results: int = 100


@dataclass
class SearchResponse:
    """Aggregated search response."""

    query: str = ""
    results: list[SearchResult] = field(default_factory=list)
    total_hits: int = 0
    search_time_ms: float = 0.0
    truncated: bool = False

    @property
    def has_results(self) -> bool:
        return len(self.results) > 0

    def by_kind(self, kind: str) -> list[SearchResult]:
        return [r for r in self.results if r.kind == kind]

    def top(self, n: int) -> list[SearchResult]:
        return sorted(self.results, key=lambda r: r.score, reverse=True)[:n]
