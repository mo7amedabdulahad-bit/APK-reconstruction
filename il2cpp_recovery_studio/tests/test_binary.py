"""Tests for Phase 5: Native binary analysis."""
from __future__ import annotations

import struct
import tempfile
from pathlib import Path

import pytest

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
from il2cpp_recovery_studio.binary.analyzer import NativeAnalyzer, HAS_CAPSTONE


# ── Model Tests ───────────────────────────────────────────────────────


class TestBinaryInfo:
    def test_defaults(self):
        info = BinaryInfo()
        assert info.format == BinaryFormat.UNKNOWN
        assert info.arch == BinaryArch.UNKNOWN
        assert info.bits == 0

    def test_custom(self):
        info = BinaryInfo(file_path="test.so", arch=BinaryArch.ARM64, bits=64)
        assert info.file_path == "test.so"
        assert info.arch == BinaryArch.ARM64
        assert info.bits == 64


class TestBinarySymbol:
    def test_defaults(self):
        sym = BinarySymbol(name="test_func")
        assert sym.name == "test_func"
        assert sym.address == 0
        assert sym.symbol_type == SymbolType.UNKNOWN


class TestNativeFunction:
    def test_defaults(self):
        func = NativeFunction(name="main", address=0x1000, size=100)
        assert func.name == "main"
        assert func.address == 0x1000
        assert func.end_address == 0

    def test_with_end_address(self):
        func = NativeFunction(name="main", address=0x1000, size=100)
        func.end_address = func.address + func.size
        assert func.end_address == 0x1064


class TestStringReference:
    def test_defaults(self):
        s = StringReference(value="hello")
        assert s.value == "hello"
        assert s.length == 0

    def test_length(self):
        s = StringReference(value="test", length=4)
        assert s.length == 4


class TestNativeAnalysisResult:
    def test_defaults(self):
        r = NativeAnalysisResult()
        assert r.total_functions == 0
        assert r.total_symbols == 0
        assert r.total_imports == 0
        assert r.total_exports == 0
        assert r.total_strings == 0

    def test_function_by_address(self):
        r = NativeAnalysisResult()
        f1 = NativeFunction(name="a", address=0x1000, size=100)
        f1.end_address = 0x1064
        r.functions.append(f1)
        assert r.function_by_address(0x1050) is f1
        assert r.function_by_address(0x2000) is None

    def test_symbol_by_name(self):
        r = NativeAnalysisResult()
        r.symbols.append(BinarySymbol(name="foo", address=0x100))
        assert r.symbol_by_name("foo") is not None
        assert r.symbol_by_name("bar") is None

    def test_compute_statistics(self):
        r = NativeAnalysisResult()
        r.functions.append(NativeFunction(name="a"))
        r.symbols.append(BinarySymbol(name="b"))
        stats = r.compute_statistics()
        assert stats["total_functions"] == 1
        assert stats["total_symbols"] == 1


class TestVirtualTable:
    def test_defaults(self):
        vt = VirtualTable(address=0x1000)
        assert vt.address == 0x1000
        assert len(vt.entries) == 0

    def test_entries(self):
        vt = VirtualTable(address=0x1000)
        vt.entries.append(VirtualTableEntry(index=0, target_address=0x2000))
        vt.entries.append(VirtualTableEntry(index=1, target_address=0x3000))
        assert len(vt.entries) == 2
        assert vt.entries[0].target_address == 0x2000


class TestCallGraphEdge:
    def test_defaults(self):
        e = CallGraphEdge(source_address=0x1000, target_address=0x2000)
        assert e.source_address == 0x1000
        assert e.target_address == 0x2000
        assert e.call_type == ""


class TestImportedFunction:
    def test_defaults(self):
        imp = ImportedFunction(name="malloc")
        assert imp.name == "malloc"
        assert imp.library == ""


class TestExportedFunction:
    def test_defaults(self):
        exp = ExportedFunction(name="init")
        assert exp.name == "init"
        assert exp.address == 0


class TestBinarySection:
    def test_defaults(self):
        sec = BinarySection(name=".text")
        assert sec.name == ".text"
        assert sec.is_executable is False


# ── Analyzer Tests ────────────────────────────────────────────────────


class TestNativeAnalyzerNonExistent:
    def test_nonexistent_file(self, tmp_path: Path):
        analyzer = NativeAnalyzer()
        result = analyzer.analyze(tmp_path / "nonexistent.so")
        assert len(result.errors) > 0
        assert "not found" in result.errors[0].lower() or "not exist" in result.errors[0].lower()


class TestNativeAnalyzerMiniElf:
    """Test with a minimal ELF-like binary (just enough to not crash)."""

    def test_minimal_elf(self, tmp_path: Path):
        """Create a minimal valid ELF64 file."""
        # ELF64 header
        elf_header = bytearray(64)
        # Magic
        elf_header[0:4] = b"\x7fELF"
        # Class: ELFCLASS64
        elf_header[4] = 2
        # Data: ELFDATA2LSB
        elf_header[5] = 1
        # Version
        elf_header[6] = 1
        # OS/ABI
        elf_header[7] = 0
        # e_type: ET_EXEC
        struct.pack_into("<H", elf_header, 16, 2)
        # e_machine: EM_AARCH64
        struct.pack_into("<H", elf_header, 18, 183)
        # e_version
        struct.pack_into("<I", elf_header, 20, 1)
        # e_entry
        struct.pack_into("<Q", elf_header, 24, 0x10000)
        # e_phoff
        struct.pack_into("<Q", elf_header, 32, 64)
        # e_shoff
        struct.pack_into("<Q", elf_header, 40, 0)
        # e_flags
        struct.pack_into("<I", elf_header, 48, 0)
        # e_ehsize
        struct.pack_into("<H", elf_header, 52, 64)
        # e_phentsize
        struct.pack_into("<H", elf_header, 54, 56)
        # e_phnum
        struct.pack_into("<H", elf_header, 56, 0)
        # e_shentsize
        struct.pack_into("<H", elf_header, 58, 64)
        # e_shnum
        struct.pack_into("<H", elf_header, 60, 0)
        # e_shstrndx
        struct.pack_into("<H", elf_header, 62, 0)

        elf_file = tmp_path / "mini.so"
        elf_file.write_bytes(bytes(elf_header))

        analyzer = NativeAnalyzer()
        result = analyzer.analyze(elf_file)
        # LIEF should parse it without crashing
        assert isinstance(result, NativeAnalysisResult)
        assert result.binary_info.format == BinaryFormat.ELF


class TestNativeAnalyzerWithoutLief:
    def test_graceful_without_lief(self, monkeypatch, tmp_path: Path):
        import il2cpp_recovery_studio.binary.analyzer as mod
        monkeypatch.setattr(mod, "HAS_LIEF", False)

        elf_file = tmp_path / "dummy.so"
        elf_file.write_bytes(b"\x7fELF" + b"\x00" * 100)

        analyzer = NativeAnalyzer()
        result = analyzer.analyze(elf_file)
        assert len(result.warnings) > 0
        assert "LIEF not installed" in result.warnings[0]


class TestNativeAnalyzerWithoutCapstone:
    def test_graceful_without_capstone(self, monkeypatch, tmp_path: Path):
        import il2cpp_recovery_studio.binary.analyzer as mod
        monkeypatch.setattr(mod, "HAS_CAPSTONE", False)

        elf_file = tmp_path / "dummy.so"
        elf_file.write_bytes(b"\x7fELF" + b"\x00" * 100)

        analyzer = NativeAnalyzer()
        result = analyzer.analyze(elf_file)
        assert isinstance(result, NativeAnalysisResult)


class TestStringScanning:
    def test_scan_bytes_for_strings(self):
        analyzer = NativeAnalyzer()
        data = b"Hello World\x00This is a test string\x00"
        strings = []
        seen = set()
        analyzer._scan_bytes_for_strings(data, strings, seen, ".rodata")
        assert len(strings) >= 2
        values = {s.value for s in strings}
        assert "Hello World" in values
        assert "This is a test string" in values

    def test_scan_short_strings_ignored(self):
        analyzer = NativeAnalyzer()
        data = b"ab\x00cd\x00"
        strings = []
        seen = set()
        analyzer._scan_bytes_for_strings(data, strings, seen, ".rodata")
        assert len(strings) == 0

    def test_scan_deduplicates(self):
        analyzer = NativeAnalyzer()
        data = b"unique_str\x00unique_str\x00"
        strings = []
        seen = set()
        analyzer._scan_bytes_for_strings(data, strings, seen, ".rodata")
        assert len(strings) == 1


class TestBranchParsing:
    def test_parse_branch_target(self):
        if not HAS_CAPSTONE:
            pytest.skip("capstone not installed")

        from capstone import CsInsn
        analyzer = NativeAnalyzer()

        class FakeInsn:
            op_str = "0xDEADBEEF"
        insn = FakeInsn()
        target = analyzer._parse_branch_target(insn)
        assert target == 0xDEADBEEF

    def test_parse_branch_no_target(self):
        analyzer = NativeAnalyzer()

        class FakeInsn:
            op_str = "x0, x1, x2"
        insn = FakeInsn()
        target = analyzer._parse_branch_target(insn)
        assert target == 0


class TestAddrToOffset:
    def test_addr_in_section(self):
        analyzer = NativeAnalyzer()
        sections = [
            BinarySection(
                name=".text",
                virtual_address=0x10000,
                size=0x1000,
                offset=0x0,
                is_executable=True,
            ),
        ]
        offset = analyzer._addr_to_offset(0x10100, sections)
        assert offset == 0x100

    def test_addr_not_in_section(self):
        analyzer = NativeAnalyzer()
        sections = [
            BinarySection(
                name=".text",
                virtual_address=0x10000,
                size=0x1000,
                offset=0x0,
                is_executable=True,
            ),
        ]
        offset = analyzer._addr_to_offset(0x20000, sections)
        assert offset == -1


class TestGetCapstone:
    def test_arm64(self):
        analyzer = NativeAnalyzer()
        cs = analyzer._get_capstone(BinaryArch.ARM64)
        if cs is not None:
            assert hasattr(cs, "disasm")

    def test_x86_64(self):
        analyzer = NativeAnalyzer()
        cs = analyzer._get_capstone(BinaryArch.X86_64)
        if cs is not None:
            assert hasattr(cs, "disasm")

    def test_unknown_arch(self):
        analyzer = NativeAnalyzer()
        cs = analyzer._get_capstone(BinaryArch.UNKNOWN)
        assert cs is None

    def test_without_capstone(self, monkeypatch):
        import il2cpp_recovery_studio.binary.analyzer as mod
        monkeypatch.setattr(mod, "HAS_CAPSTONE", False)
        analyzer = NativeAnalyzer()
        cs = analyzer._get_capstone(BinaryArch.ARM64)
        assert cs is None


class TestAnalyzeApkLibrary:
    def test_library_not_found(self, tmp_path: Path):
        import zipfile
        apk = tmp_path / "test.apk"
        with zipfile.ZipFile(str(apk), "w") as zf:
            zf.writestr("classes.dex", b"\x00" * 100)

        analyzer = NativeAnalyzer()
        result = analyzer.analyze_apk_library(apk, "lib/arm64-v8a/libil2cpp.so")
        assert len(result.errors) > 0

    def test_nonexistent_apk(self, tmp_path: Path):
        analyzer = NativeAnalyzer()
        result = analyzer.analyze_apk_library(tmp_path / "no.apk", "lib/lib.so")
        assert len(result.errors) > 0


class TestGetTextSection:
    def test_returns_bytes_or_empty(self):
        analyzer = NativeAnalyzer()
        result = analyzer._get_text_section(None)
        assert isinstance(result, bytes)
