"""Data models for Ghidra integration."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class GhidraStatus(Enum):
    """Status of a Ghidra operation."""

    NOT_FOUND = auto()
    PENDING = auto()
    RUNNING = auto()
    SUCCESS = auto()
    FAILED = auto()
    TIMEOUT = auto()
    SKIPPED = auto()


class AnalysisType(Enum):
    """Types of Ghidra analysis."""

    FULL = auto()
    QUICK = auto()
    FUNCTION_START = auto()
    BINARY = auto()
    STRINGS = auto()


@dataclass
class GhidraFunction:
    """A function recovered by Ghidra."""

    name: str
    address: int = 0
    size: int = 0
    calling_convention: str = ""
    is_thunk: bool = False
    is_library: bool = False
    parameter_count: int = 0
    return_type: str = ""
    complexity: float = 0.0
    metadata_token: int = 0


@dataclass
class GhidraDecompilation:
    """Pseudo-C decompilation of a function."""

    address: int = 0
    function_name: str = ""
    pseudo_c: str = ""
    includes: list[str] = field(default_factory=list)
    global_vars: list[str] = field(default_factory=list)


@dataclass
class GhidraResult:
    """Result of Ghidra analysis."""

    status: GhidraStatus = GhidraStatus.NOT_FOUND
    functions: list[GhidraFunction] = field(default_factory=list)
    decompilations: list[GhidraDecompilation] = field(default_factory=list)
    strings: list[str] = field(default_factory=list)
    cross_references: list[dict[str, int]] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)
    execution_time_ms: float = 0.0

    @property
    def total_functions(self) -> int:
        return len(self.functions)

    @property
    def total_decompilations(self) -> int:
        return len(self.decompilations)

    def function_by_address(self, address: int) -> GhidraFunction | None:
        for f in self.functions:
            if f.address == address:
                return f
        return None

    def function_by_name(self, name: str) -> GhidraFunction | None:
        for f in self.functions:
            if f.name == name:
                return f
        return None

    def decompilation_by_address(self, address: int) -> GhidraDecompilation | None:
        for d in self.decompilations:
            if d.address == address:
                return d
        return None

    def compute_statistics(self) -> dict[str, int]:
        self.statistics = {
            "total_functions": self.total_functions,
            "total_decompilations": self.total_decompilations,
            "total_strings": len(self.strings),
            "total_xrefs": len(self.cross_references),
        }
        return self.statistics
