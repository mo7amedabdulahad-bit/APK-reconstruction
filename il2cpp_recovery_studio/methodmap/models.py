"""Data models for method mapping."""
from __future__ import annotations

from dataclasses import dataclass, field


@dataclass
class MappedMethod:
    """A single method mapped between metadata and native code."""

    name: str
    namespace: str = ""
    class_name: str = ""
    metadata_index: int = -1
    metadata_token: int = 0
    native_address: int = 0
    function_size: int = 0
    caller_count: int = 0
    callee_count: int = 0
    confidence: float = 0.0
    return_type: str = ""
    parameters: list[str] = field(default_factory=list)
    is_static: bool = False
    is_constructor: bool = False
    is_abstract: bool = False
    is_generic: bool = False
    source_tools: list[str] = field(default_factory=list)

    @property
    def full_name(self) -> str:
        parts: list[str] = []
        if self.namespace:
            parts.append(self.namespace)
        if self.class_name:
            parts.append(self.class_name)
        prefix = ".".join(parts)
        return f"{prefix}::{self.name}" if prefix else self.name

    @property
    def is_mapped(self) -> bool:
        return self.native_address != 0

    @property
    def address_hex(self) -> str:
        return f"0x{self.native_address:X}" if self.native_address else "0x0"


class MethodMap:
    """Bidirectional lookup between metadata indices and native addresses."""

    def __init__(self) -> None:
        self._methods: list[MappedMethod] = []
        self._by_metadata_index: dict[int, MappedMethod] = {}
        self._by_address: dict[int, MappedMethod] = {}
        self._by_name: dict[str, list[MappedMethod]] = {}
        self._by_class: dict[str, list[MappedMethod]] = {}

    def add(self, method: MappedMethod) -> None:
        self._methods.append(method)
        if method.metadata_index >= 0:
            self._by_metadata_index[method.metadata_index] = method
        if method.native_address != 0:
            self._by_address[method.native_address] = method
        key = method.full_name
        self._by_name.setdefault(key, []).append(method)
        cls_key = f"{method.namespace}.{method.class_name}" if method.namespace else method.class_name
        if cls_key:
            self._by_class.setdefault(cls_key, []).append(method)

    def by_metadata_index(self, index: int) -> MappedMethod | None:
        return self._by_metadata_index.get(index)

    def by_address(self, address: int) -> MappedMethod | None:
        return self._by_address.get(address)

    def by_name(self, full_name: str) -> list[MappedMethod]:
        return self._by_name.get(full_name, [])

    def by_class(self, class_full_name: str) -> list[MappedMethod]:
        return self._by_class.get(class_full_name, [])

    @property
    def all_methods(self) -> list[MappedMethod]:
        return list(self._methods)

    @property
    def total(self) -> int:
        return len(self._methods)

    @property
    def mapped_count(self) -> int:
        return sum(1 for m in self._methods if m.is_mapped)

    @property
    def unmapped_count(self) -> int:
        return self.total - self.mapped_count

    @property
    def mapping_rate(self) -> float:
        return self.mapped_count / self.total if self.total > 0 else 0.0

    def get_callers(self, address: int) -> list[MappedMethod]:
        result: list[MappedMethod] = []
        target = self._by_address.get(address)
        if target is None:
            return result
        for m in self._methods:
            if m.native_address != address and m.callee_count > 0:
                result.append(m)
        return result

    def get_callees(self, address: int) -> list[MappedMethod]:
        result: list[MappedMethod] = []
        source = self._by_address.get(address)
        if source is None:
            return result
        for m in self._methods:
            if m.native_address != address and m.caller_count > 0:
                result.append(m)
        return result

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {
            "total": self.total,
            "mapped": self.mapped_count,
            "unmapped": self.unmapped_count,
        }
        for m in self._methods:
            if m.is_constructor:
                stats["constructors"] = stats.get("constructors", 0) + 1
            if m.is_static:
                stats["static"] = stats.get("static", 0) + 1
            if m.is_generic:
                stats["generic"] = stats.get("generic", 0) + 1
        return stats
