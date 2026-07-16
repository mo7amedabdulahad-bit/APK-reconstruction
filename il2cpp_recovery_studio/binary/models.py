"""Data models for native binary analysis."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class BinaryFormat(Enum):
    """Binary file format."""
    ELF = auto()
    PE = auto()
    MACHO = auto()
    UNKNOWN = auto()


class BinaryArch(Enum):
    """Binary CPU architecture."""
    ARMV7 = auto()
    ARM64 = auto()
    X86 = auto()
    X86_64 = auto()
    MIPS = auto()
    UNKNOWN = auto()


class SymbolType(Enum):
    """Symbol type."""
    FUNCTION = auto()
    OBJECT = auto()
    SECTION = auto()
    FILE = auto()
    UNKNOWN = auto()


class SymbolBinding(Enum):
    """Symbol binding."""
    LOCAL = auto()
    GLOBAL = auto()
    WEAK = auto()
    UNKNOWN = auto()


@dataclass
class BinaryInfo:
    """High-level binary information."""
    file_path: str = ""
    file_size: int = 0
    format: BinaryFormat = BinaryFormat.UNKNOWN
    arch: BinaryArch = BinaryArch.UNKNOWN
    bits: int = 0
    endian: str = ""
    entry_point: int = 0
    is_stripped: bool = False
    is_pie: bool = False
    has_nx: bool = False
    has_canary: bool = False


@dataclass
class BinarySymbol:
    """A symbol in the binary."""
    name: str
    address: int = 0
    size: int = 0
    symbol_type: SymbolType = SymbolType.UNKNOWN
    binding: SymbolBinding = SymbolBinding.UNKNOWN
    section: str = ""
    is_imported: bool = False
    is_exported: bool = False


@dataclass
class BinarySection:
    """A section in the binary."""
    name: str
    virtual_address: int = 0
    virtual_size: int = 0
    offset: int = 0
    size: int = 0
    flags: str = ""
    is_executable: bool = False
    is_writable: bool = False
    is_readable: bool = False


@dataclass
class ImportedFunction:
    """An imported function."""
    name: str
    library: str = ""
    address: int = 0
    ordinal: int = 0


@dataclass
class ExportedFunction:
    """An exported function."""
    name: str
    address: int = 0
    size: int = 0
    ordinal: int = 0


@dataclass
class DisassembledInstruction:
    """A single disassembled instruction."""
    address: int = 0
    mnemonic: str = ""
    op_str: str = ""
    size: int = 0
    bytes: bytes = b""


@dataclass
class NativeFunction:
    """A recovered native function."""
    name: str
    address: int = 0
    size: int = 0
    end_address: int = 0
    calling_convention: str = ""
    is_thunk: bool = False
    is_library: bool = False
    parameter_count: int = 0
    return_type: str = ""
    instructions: list[DisassembledInstruction] = field(default_factory=list)
    callers: list[int] = field(default_factory=list)
    callees: list[int] = field(default_factory=list)
    cross_references: list[int] = field(default_factory=list)
    confidence: float = 0.0


@dataclass
class StringReference:
    """A string found in the binary."""
    value: str
    address: int = 0
    offset: int = 0
    section: str = ""
    encoding: str = "utf-8"
    length: int = 0
    xrefs: list[int] = field(default_factory=list)


@dataclass
class VirtualTableEntry:
    """An entry in a C++ vtable."""
    address: int = 0
    target_address: int = 0
    target_name: str = ""
    index: int = 0


@dataclass
class VirtualTable:
    """A C++ virtual table."""
    address: int = 0
    class_name: str = ""
    entries: list[VirtualTableEntry] = field(default_factory=list)
    size: int = 0


@dataclass
class RTTIInfo:
    """Runtime Type Information recovered from binary."""
    type_name: str = ""
    type_info_address: int = 0
    vtable_address: int = 0
    parent_type: str = ""
    hierarchy: list[str] = field(default_factory=list)


@dataclass
class CallGraphEdge:
    """An edge in the call graph."""
    source_address: int = 0
    target_address: int = 0
    source_name: str = ""
    target_name: str = ""
    call_type: str = ""  # direct, indirect, tail


@dataclass
class NativeAnalysisResult:
    """Complete result of native binary analysis."""
    binary_info: BinaryInfo = field(default_factory=BinaryInfo)
    sections: list[BinarySection] = field(default_factory=list)
    symbols: list[BinarySymbol] = field(default_factory=list)
    functions: list[NativeFunction] = field(default_factory=list)
    imports: list[ImportedFunction] = field(default_factory=list)
    exports: list[ExportedFunction] = field(default_factory=list)
    strings: list[StringReference] = field(default_factory=list)
    vtables: list[VirtualTable] = field(default_factory=list)
    rtti: list[RTTIInfo] = field(default_factory=list)
    call_graph: list[CallGraphEdge] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)
    analysis_time_ms: float = 0.0

    @property
    def total_functions(self) -> int:
        return len(self.functions)

    @property
    def total_symbols(self) -> int:
        return len(self.symbols)

    @property
    def total_imports(self) -> int:
        return len(self.imports)

    @property
    def total_exports(self) -> int:
        return len(self.exports)

    @property
    def total_strings(self) -> int:
        return len(self.strings)

    def function_by_address(self, address: int) -> NativeFunction | None:
        for f in self.functions:
            if f.address <= address < f.end_address:
                return f
        return None

    def symbol_by_name(self, name: str) -> BinarySymbol | None:
        for s in self.symbols:
            if s.name == name:
                return s
        return None

    def functions_in_section(self, section: str) -> list[NativeFunction]:
        return [f for f in self.functions if f.name.startswith(section)]

    def compute_statistics(self) -> dict[str, int]:
        self.statistics = {
            "total_functions": self.total_functions,
            "total_symbols": self.total_symbols,
            "total_imports": self.total_imports,
            "total_exports": self.total_exports,
            "total_strings": self.total_strings,
            "total_sections": len(self.sections),
            "total_vtables": len(self.vtables),
            "total_rtti": len(self.rtti),
            "total_call_edges": len(self.call_graph),
        }
        return self.statistics
