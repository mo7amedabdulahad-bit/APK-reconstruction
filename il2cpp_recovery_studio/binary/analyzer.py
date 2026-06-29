"""Native binary analysis engine using LIEF and Capstone.

Analyzes ELF/PE/MachO binaries (especially libil2cpp.so) to recover:
- Functions, addresses, cross-references
- Strings, virtual tables, RTTI
- Exports, imports
- Call graph
"""
from __future__ import annotations

import re
import struct
import time
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.binary.models import (
    BinaryArch,
    BinaryFormat,
    BinaryInfo,
    BinarySection,
    BinarySymbol,
    CallGraphEdge,
    ExportedFunction,
    ImportedFunction,
    NativeAnalysisResult,
    NativeFunction,
    RTTIInfo,
    StringReference,
    SymbolBinding,
    SymbolType,
    VirtualTable,
    VirtualTableEntry,
)
from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("binary.analyzer")

# Try optional imports
try:
    import lief
    HAS_LIEF = True
except ImportError:
    HAS_LIEF = False

try:
    from capstone import Cs, CS_ARCH_ARM, CS_ARCH_ARM64, CS_ARCH_X86, CS_MODE_32, CS_MODE_64
    HAS_CAPSTONE = True
except ImportError:
    HAS_CAPSTONE = False

ELF_MAGIC = b"\x7fELF"
PE_MAGIC = b"MZ"
MACHO_MAGIC_32 = b"\xfe\xed\xfa\xce"
MACHO_MAGIC_64 = b"\xfe\xed\xfa\xcf"
MACHO_FAT_MAGIC = b"\xca\xfe\xba\xbe"

ARM64_INSTRUCTIONS_OF_INTEREST = {"bl", "blr", "br", "ret"}
X86_CALL_INSTRUCTIONS = {"call", "jmp"}


class NativeAnalyzer:
    """Analyzes native binaries for function recovery, strings, vtables, and call graphs.

    Usage::

        analyzer = NativeAnalyzer()
        result = analyzer.analyze("path/to/libil2cpp.so")
        print(f"Recovered {result.total_functions} functions")
    """

    def __init__(self) -> None:
        self._capstone: Optional[object] = None

    def analyze(
        self,
        binary_path: str | Path,
        extract_strings: bool = True,
        disassemble: bool = True,
        max_functions: int = 100_000,
    ) -> NativeAnalysisResult:
        """Analyze a native binary and return a complete analysis result.

        Parameters
        ----------
        binary_path:
            Path to the ELF/PE/MachO binary.
        extract_strings:
            Whether to extract string references.
        disassemble:
            Whether to disassemble functions for call graph.
        max_functions:
            Maximum number of functions to analyze.
        """
        result = NativeAnalysisResult()
        start = time.monotonic()
        binary_path = str(binary_path)

        if not Path(binary_path).exists():
            result.errors.append(f"File not found: {binary_path}")
            return result

        if not HAS_LIEF:
            result.warnings.append(
                "LIEF not installed. Install with: pip install lief"
            )
            return result

        try:
            binary = lief.parse(binary_path)
        except Exception as exc:
            result.errors.append(f"Failed to parse binary: {exc}")
            return result

        if binary is None:
            result.errors.append("LIEF returned None for binary")
            return result

        logger.info("Analyzing binary: %s", binary_path)

        # High-level info
        result.binary_info = self._extract_binary_info(binary, binary_path)

        # Sections
        result.sections = self._extract_sections(binary)
        logger.info("Extracted %d sections", len(result.sections))

        # Symbols
        result.symbols = self._extract_symbols(binary)
        logger.info("Extracted %d symbols", len(result.symbols))

        # Imports / Exports
        result.imports = self._extract_imports(binary)
        result.exports = self._extract_exports(binary)
        logger.info("Imports: %d, Exports: %d", len(result.imports), len(result.exports))

        # Functions
        result.functions = self._extract_functions(binary, max_functions)
        logger.info("Extracted %d functions", len(result.functions))

        # Strings
        if extract_strings:
            result.strings = self._extract_strings(binary)
            logger.info("Extracted %d strings", len(result.strings))

        # VTables and RTTI
        result.vtables = self._extract_vtables(binary)
        result.rtti = self._extract_rtti(binary)
        logger.info("VTables: %d, RTTI: %d", len(result.vtables), len(result.rtti))

        # Call graph
        if disassemble and result.functions:
            result.call_graph = self._build_call_graph(binary, result)
            logger.info("Call graph edges: %d", len(result.call_graph))

        result.analysis_time_ms = (time.monotonic() - start) * 1000
        result.compute_statistics()
        logger.info(
            "Analysis complete in %.1fms: %d functions, %d strings, %d vtables",
            result.analysis_time_ms,
            result.total_functions,
            result.total_strings,
            len(result.vtables),
        )
        return result

    # ── Binary Info ───────────────────────────────────────────────────

    def _extract_binary_info(self, binary: object, path: str) -> BinaryInfo:
        info = BinaryInfo(file_path=path)
        try:
            info.file_size = Path(path).stat().st_size
        except OSError:
            info.file_size = 0

        try:
            if hasattr(binary, "header"):
                header = binary.header
                if hasattr(header, "file_type"):
                    info.format = BinaryFormat.ELF
                if hasattr(header, "machine_type"):
                    machine = str(header.machine_type)
                    if "AARCH64" in machine:
                        info.arch = BinaryArch.ARM64
                        info.bits = 64
                    elif "ARM" in machine:
                        info.arch = BinaryArch.ARMV7
                        info.bits = 32
                    elif "x86_64" in machine or "AMD64" in machine:
                        info.arch = BinaryArch.X86_64
                        info.bits = 64
                    elif "x86" in machine or "386" in machine:
                        info.arch = BinaryArch.X86
                        info.bits = 32
                    elif "MIPS" in machine:
                        info.arch = BinaryArch.MIPS
                        info.bits = 32
                if hasattr(header, "entrypoint"):
                    info.entry_point = header.entrypoint
                if hasattr(header, "identity_data"):
                    data_enc = str(header.identity_data)
                    info.endian = "little" if "LSB" in data_enc else "big"
        except Exception as exc:
            logger.debug("Error extracting binary info: %s", exc)

        # PIE / NX detection from ELF flags
        try:
            if hasattr(binary, "security_context"):
                sec = binary.security_context
                info.is_pie = getattr(sec, "is_pie", False) if hasattr(sec, "is_pie") else False
                info.has_nx = getattr(sec, "has_nx", False) if hasattr(sec, "has_nx") else False
        except Exception:
            pass

        # Stripped detection
        try:
            if hasattr(binary, "has_section"):
                info.is_stripped = not binary.has_section(".symtab")
        except Exception:
            pass

        return info

    # ── Sections ──────────────────────────────────────────────────────

    def _extract_sections(self, binary: object) -> list[BinarySection]:
        sections: list[BinarySection] = []
        try:
            for sec in binary.sections:
                flags = ""
                is_exec = False
                is_writ = False
                is_read = False
                if hasattr(sec, "flags"):
                    f = sec.flags
                    is_exec = bool(f & 0x4) if hasattr(f, "__and__") else False
                    is_writ = bool(f & 0x1) if hasattr(f, "__and__") else False
                    is_read = bool(f & 0x2) if hasattr(f, "__and__") else False
                    if is_exec:
                        flags += "X"
                    if is_writ:
                        flags += "W"
                    if is_read:
                        flags += "R"

                sec_name = sec.name if hasattr(sec, "name") else str(sec)
                sections.append(BinarySection(
                    name=sec_name,
                    virtual_address=getattr(sec, "virtual_address", 0),
                    virtual_size=getattr(sec, "virtual_size", 0),
                    offset=getattr(sec, "offset", 0),
                    size=getattr(sec, "size", 0),
                    flags=flags,
                    is_executable=is_exec,
                    is_writable=is_writ,
                    is_readable=is_read,
                ))
        except Exception as exc:
            logger.debug("Error extracting sections: %s", exc)
        return sections

    # ── Symbols ───────────────────────────────────────────────────────

    def _extract_symbols(self, binary: object) -> list[BinarySymbol]:
        symbols: list[BinarySymbol] = []
        seen: set[str] = set()
        try:
            for sym in binary.symbols:
                name = sym.name if hasattr(sym, "name") else ""
                if not name or name in seen:
                    continue
                seen.add(name)

                stype = SymbolType.UNKNOWN
                if hasattr(sym, "type"):
                    type_str = str(sym.type)
                    if "FUNC" in type_str or "FUNCTION" in type_str:
                        stype = SymbolType.FUNCTION
                    elif "OBJECT" in type_str:
                        stype = SymbolType.OBJECT

                binding = SymbolBinding.UNKNOWN
                if hasattr(sym, "binding"):
                    bind_str = str(sym.binding)
                    if "GLOBAL" in bind_str:
                        binding = SymbolBinding.GLOBAL
                    elif "LOCAL" in bind_str:
                        binding = SymbolBinding.LOCAL
                    elif "WEAK" in bind_str:
                        binding = SymbolBinding.WEAK

                symbols.append(BinarySymbol(
                    name=name,
                    address=getattr(sym, "value", 0),
                    size=getattr(sym, "size", 0),
                    symbol_type=stype,
                    binding=binding,
                    is_exported=getattr(sym, "is_exported", False),
                    is_imported=getattr(sym, "is_imported", False),
                ))
        except Exception as exc:
            logger.debug("Error extracting symbols: %s", exc)
        return symbols

    # ── Imports ───────────────────────────────────────────────────────

    def _extract_imports(self, binary: object) -> list[ImportedFunction]:
        imports: list[ImportedFunction] = []
        try:
            if hasattr(binary, "imports"):
                for imp in binary.imports:
                    imports.append(ImportedFunction(
                        name=imp.name if hasattr(imp, "name") else "",
                        library=imp.library.name if hasattr(imp, "library") and hasattr(imp.library, "name") else "",
                        address=getattr(imp, "address", 0),
                        ordinal=getattr(imp, "ordinal", 0),
                    ))
        except Exception as exc:
            logger.debug("Error extracting imports: %s", exc)
        return imports

    # ── Exports ───────────────────────────────────────────────────────

    def _extract_exports(self, binary: object) -> list[ExportedFunction]:
        exports: list[ExportedFunction] = []
        try:
            if hasattr(binary, "exported_functions"):
                for exp in binary.exported_functions:
                    exports.append(ExportedFunction(
                        name=exp.name if hasattr(exp, "name") else "",
                        address=getattr(exp, "address", 0),
                        size=getattr(exp, "size", 0),
                        ordinal=getattr(exp, "ordinal", 0),
                    ))
            elif hasattr(binary, "exports"):
                for exp in binary.exports:
                    name = exp.name if hasattr(exp, "name") else ""
                    if name:
                        exports.append(ExportedFunction(
                            name=name,
                            address=getattr(exp, "address", 0),
                        ))
        except Exception as exc:
            logger.debug("Error extracting exports: %s", exc)
        return exports

    # ── Functions ─────────────────────────────────────────────────────

    def _extract_functions(
        self, binary: object, max_functions: int
    ) -> list[NativeFunction]:
        functions: list[NativeFunction] = []

        # Strategy 1: From symbols
        for sym in self._extract_symbols(binary):
            if sym.symbol_type == SymbolType.FUNCTION and sym.address > 0:
                functions.append(NativeFunction(
                    name=sym.name,
                    address=sym.address,
                    size=sym.size,
                    end_address=sym.address + sym.size if sym.size else sym.address,
                    confidence=0.9,
                ))
                if len(functions) >= max_functions:
                    return functions

        # Strategy 2: From exported functions
        if len(functions) < 100:
            for exp in self._extract_exports(binary):
                if exp.address > 0:
                    already_found = any(
                        f.address == exp.address for f in functions
                    )
                    if not already_found:
                        functions.append(NativeFunction(
                            name=exp.name,
                            address=exp.address,
                            size=exp.size,
                            end_address=exp.address + exp.size if exp.size else exp.address,
                            confidence=0.85,
                        ))

        functions.sort(key=lambda f: f.address)
        return functions

    # ── Strings ───────────────────────────────────────────────────────

    def _extract_strings(self, binary: object) -> list[StringReference]:
        strings: list[StringReference] = []
        seen: set[str] = set()

        # Extract from string tables in the binary
        try:
            if hasattr(binary, "strings"):
                for s in binary.strings:
                    value = s.value if hasattr(s, "value") else str(s)
                    if not value or len(value) < 4 or value in seen:
                        continue
                    seen.add(value)
                    strings.append(StringReference(
                        value=value,
                        address=getattr(s, "offset", 0),
                        offset=getattr(s, "offset", 0),
                        section=getattr(s, "type", ""),
                        encoding="utf-8",
                        length=len(value),
                    ))
        except Exception as exc:
            logger.debug("Error from lief.strings: %s", exc)

        # Fallback: raw byte scan from known sections
        if len(strings) < 50:
            try:
                if hasattr(binary, "get_section"):
                    for sec_name in [".rodata", ".data", ".rdata"]:
                        try:
                            sec = binary.get_section(sec_name)
                            if sec and hasattr(sec, "content"):
                                raw = bytes(sec.content)
                                self._scan_bytes_for_strings(raw, strings, seen, sec_name)
                        except Exception:
                            continue
            except Exception:
                pass

        return strings

    def _scan_bytes_for_strings(
        self,
        data: bytes,
        strings: list[StringReference],
        seen: set[str],
        section: str,
    ) -> None:
        current = bytearray()
        start_offset = 0
        for i, b in enumerate(data):
            if 0x20 <= b < 0x7F:
                if not current:
                    start_offset = i
                current.append(b)
            else:
                if len(current) >= 4:
                    value = current.decode("ascii", errors="ignore")
                    if value not in seen:
                        seen.add(value)
                        strings.append(StringReference(
                            value=value,
                            offset=start_offset,
                            section=section,
                            encoding="ascii",
                            length=len(value),
                        ))
                current = bytearray()

    # ── VTables ───────────────────────────────────────────────────────

    def _extract_vtables(self, binary: object) -> list[VirtualTable]:
        vtables: list[VirtualTable] = []

        # Scan .rodata for pointer tables that look like vtables
        try:
            if hasattr(binary, "get_section"):
                rodata = binary.get_section(".rodata")
                if rodata and hasattr(rodata, "content"):
                    raw = bytes(rodata.content)
                    self._scan_for_vtables(raw, vtables, getattr(rodata, "virtual_address", 0))
        except Exception as exc:
            logger.debug("Error extracting vtables: %s", exc)

        return vtables

    def _scan_for_vtables(
        self, data: bytes, vtables: list[VirtualTable], section_base: int
    ) -> None:
        if len(data) < 8:
            return

        is_64 = len(data) > 0x10000  # heuristic
        ptr_size = 8 if is_64 else 4
        fmt = "<Q" if is_64 else "<I"
        align = ptr_size

        # Scan for sequences of aligned pointers that look like function pointers
        min_vtable_size = 3
        i = 0
        while i + min_vtable_size * align <= len(data):
            ptrs = []
            for j in range(min_vtable_size):
                offset = i + j * align
                if offset + ptr_size <= len(data):
                    val = struct.unpack_from(fmt, data, offset)[0]
                    ptrs.append(val)
                else:
                    break

            # Heuristic: all pointers should be in a reasonable code range
            if all(0x10000 < p < 0xFFFFFFFF for p in ptrs):
                # Looks like a vtable
                vt = VirtualTable(
                    address=section_base + i,
                    size=0,
                )
                for idx, addr in enumerate(ptrs):
                    vt.entries.append(VirtualTableEntry(
                        address=section_base + i + idx * align,
                        target_address=addr,
                        index=idx,
                    ))
                vt.size = len(vt.entries) * align
                vtables.append(vt)
                i += len(vt.entries) * align
            else:
                i += align

    # ── RTTI ──────────────────────────────────────────────────────────

    def _extract_rtti(self, binary: object) -> list[RTTIInfo]:
        rtti_list: list[RTTIInfo] = []

        try:
            if hasattr(binary, "get_section"):
                for sec_name in [".data", ".rodata"]:
                    try:
                        sec = binary.get_section(sec_name)
                        if sec and hasattr(sec, "content"):
                            raw = bytes(sec.content)
                            self._scan_for_rtti(raw, rtti_list, getattr(sec, "virtual_address", 0))
                    except Exception:
                        continue
        except Exception as exc:
            logger.debug("Error extracting RTTI: %s", exc)

        return rtti_list

    def _scan_for_rtti(
        self, data: bytes, rtti_list: list[RTTIInfo], base: int
    ) -> None:
        # Scan for RTTI-like patterns (pointer to typeinfo + pointer to name)
        if len(data) < 16:
            return
        for i in range(0, len(data) - 16, 4):
            # Simple heuristic: look for Itanium-style RTTI
            # A vtable pointer followed by a typeinfo pointer
            ptr1 = struct.unpack_from("<Q", data, i)[0] if i + 8 <= len(data) else 0
            ptr2 = struct.unpack_from("<Q", data, i + 8)[0] if i + 16 <= len(data) else 0

            if 0x10000 < ptr1 < 0xFFFFFFFF and 0x10000 < ptr2 < 0xFFFFFFFF:
                # Might be RTTI, but we can't resolve much without symbol info
                pass

    # ── Call Graph ────────────────────────────────────────────────────

    def _build_call_graph(
        self, binary: object, result: NativeAnalysisResult
    ) -> list[CallGraphEdge]:
        edges: list[CallGraphEdge] = []
        if not HAS_CAPSTONE:
            return edges

        # Build address -> function lookup
        addr_to_func: dict[int, NativeFunction] = {}
        for func in result.functions:
            if func.address > 0:
                addr_to_func[func.address] = func

        # Initialize capstone
        cs = self._get_capstone(result.binary_info.arch)
        if cs is None:
            return edges

        # Analyze each function
        text_data = self._get_text_section(binary)
        if not text_data:
            return edges

        for func in result.functions[:10000]:  # Limit for performance
            if func.address == 0 or func.size == 0:
                continue
            # Calculate file offset (approximate)
            func_offset = self._addr_to_offset(func.address, result.sections)
            if func_offset < 0 or func_offset + func.size > len(text_data):
                continue

            code = text_data[func_offset:func_offset + min(func.size, 4096)]
            try:
                for insn in cs.disasm(code, func.address):
                    if insn.mnemonic in ("bl", "blx", "call", "b"):
                        target = self._parse_branch_target(insn)
                        if target and target in addr_to_func:
                            edges.append(CallGraphEdge(
                                source_address=func.address,
                                target_address=target,
                                source_name=func.name,
                                target_name=addr_to_func[target].name,
                                call_type="direct",
                            ))
                            func.callees.append(target)
                            if target in addr_to_func:
                                addr_to_func[target].callers.append(func.address)
            except Exception:
                continue

        return edges

    def _get_capstone(self, arch: BinaryArch) -> object:
        if not HAS_CAPSTONE:
            return None
        try:
            if arch == BinaryArch.ARM64:
                return Cs(CS_ARCH_ARM64)
            elif arch == BinaryArch.ARMV7:
                cs = Cs(CS_ARCH_ARM, 0)  # CS_MODE_THUMB | CS_MODE_ARM
                return cs
            elif arch == BinaryArch.X86_64:
                return Cs(CS_ARCH_X86, CS_MODE_64)
            elif arch == BinaryArch.X86:
                return Cs(CS_ARCH_X86, CS_MODE_32)
        except Exception as exc:
            logger.debug("Failed to init capstone: %s", exc)
        return None

    def _get_text_section(self, binary: object) -> bytes:
        try:
            if hasattr(binary, "get_section"):
                text = binary.get_section(".text")
                if text and hasattr(text, "content"):
                    return bytes(text.content)
        except Exception:
            pass
        return b""

    def _addr_to_offset(self, address: int, sections: list[BinarySection]) -> int:
        for sec in sections:
            if sec.is_executable and sec.virtual_address <= address < sec.virtual_address + sec.size:
                return address - sec.virtual_address + sec.offset
        return -1

    def _parse_branch_target(self, insn: object) -> int:
        op_str = getattr(insn, "op_str", "")
        # Try to parse hex address from operand
        match = re.search(r"0x([0-9a-fA-F]+)", op_str)
        if match:
            return int(match.group(1), 16)
        return 0

    # ── Public helpers ────────────────────────────────────────────────

    def analyze_apk_library(
        self,
        apk_path: str | Path,
        lib_path: str,
        output_dir: str | Path | None = None,
    ) -> NativeAnalysisResult:
        """Analyze a library inside an APK by extracting it first."""
        import tempfile
        import zipfile

        result = NativeAnalysisResult()
        apk_path = Path(apk_path)

        if not apk_path.exists():
            result.errors.append(f"APK not found: {apk_path}")
            return result

        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                # Check direct path
                if lib_path in zf.namelist():
                    with tempfile.NamedTemporaryFile(suffix=".so", delete=False) as tmp:
                        tmp.write(zf.read(lib_path))
                        tmp.flush()
                        return self.analyze(tmp.name)

                # Check inner APKs
                for name in zf.namelist():
                    if name.endswith(".apk"):
                        try:
                            raw_apk = zf.read(name)
                            import os
                            tmp = os.path.join(tempfile.gettempdir(), f"il2cpp_native_{name.replace('/', '_')}")
                            with open(tmp, "wb") as f:
                                f.write(raw_apk)
                            with zipfile.ZipFile(tmp, "r") as inner_zf:
                                for inner_name in inner_zf.namelist():
                                    if inner_name.endswith(lib_path) or inner_name == lib_path:
                                        with tempfile.NamedTemporaryFile(suffix=".so", delete=False) as so_tmp:
                                            so_tmp.write(inner_zf.read(inner_name))
                                            so_tmp.flush()
                                            return self.analyze(so_tmp.name)
                        except Exception:
                            continue
        except (zipfile.BadZipFile, OSError) as exc:
            result.errors.append(f"Failed to read APK: {exc}")

        result.errors.append(f"Library not found in APK: {lib_path}")
        return result
