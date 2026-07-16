"""Data models for cross-referencing."""
from __future__ import annotations

from dataclasses import dataclass, field


@dataclass
class CrossRefEntry:
    """A single cross-referenced entity (class/method/field/enum)."""

    id: str
    name: str
    namespace: str = ""
    kind: str = ""  # "class", "method", "field", "enum", "property", "event"
    metadata_index: int = -1
    recovery_source: str = ""
    native_address: int = 0
    token: int = 0
    confidence: float = 0.0
    full_name: str = ""
    parent_id: str = ""
    references_from: list[str] = field(default_factory=list)
    references_to: list[str] = field(default_factory=list)
    metadata: dict = field(default_factory=dict)

    @property
    def is_resolved(self) -> bool:
        return self.confidence > 0.0 and self.recovery_source != ""


@dataclass
class CrossRefResult:
    """Aggregated cross-reference result."""

    entries: list[CrossRefEntry] = field(default_factory=list)
    unresolved_refs: list[tuple[str, str]] = field(default_factory=list)  # (ref_id, context)
    statistics: dict[str, int] = field(default_factory=dict)
    metadata: dict[str, object] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_entries(self) -> int:
        return len(self.entries)

    @property
    def resolved_count(self) -> int:
        return sum(1 for e in self.entries if e.is_resolved)

    @property
    def resolution_rate(self) -> float:
        return self.resolved_count / self.total_entries if self.total_entries > 0 else 0.0

    def by_kind(self, kind: str) -> list[CrossRefEntry]:
        return [e for e in self.entries if e.kind == kind]

    def by_source(self, source: str) -> list[CrossRefEntry]:
        return [e for e in self.entries if e.recovery_source == source]

    def by_name(self, name: str) -> list[CrossRefEntry]:
        return [e for e in self.entries if e.name == name]

    def by_full_name(self, full_name: str) -> list[CrossRefEntry]:
        return [e for e in self.entries if e.full_name == full_name]

    def get_entry(self, entry_id: str) -> CrossRefEntry | None:
        for e in self.entries:
            if e.id == entry_id:
                return e
        return None

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {}
        for e in self.entries:
            stats[e.kind] = stats.get(e.kind, 0) + 1
            stats[f"source:{e.recovery_source}"] = stats.get(f"source:{e.recovery_source}", 0) + 1
        stats["total"] = self.total_entries
        stats["resolved"] = self.resolved_count
        stats["unresolved"] = len(self.unresolved_refs)
        self.statistics = stats
        return stats
