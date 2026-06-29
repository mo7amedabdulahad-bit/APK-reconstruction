"""Tests for Phase 13: Ghidra integration."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.ghidra.models import (
    AnalysisType,
    GhidraDecompilation,
    GhidraFunction,
    GhidraResult,
    GhidraStatus,
)
from il2cpp_recovery_studio.ghidra.engine import GhidraEngine
from il2cpp_recovery_studio.metadata.models import TypeDefinition


# ── Model tests ──────────────────────────────────────────────────────


class TestGhidraFunction:
    def test_function(self):
        f = GhidraFunction(name="main", address=0x1000, size=64)
        assert f.name == "main"
        assert f.address == 0x1000


class TestGhidraDecompilation:
    def test_decompilation(self):
        d = GhidraDecompilation(address=0x1000, function_name="main", pseudo_c="int main() {}")
        assert d.pseudo_c == "int main() {}"


class TestGhidraResult:
    def test_result(self):
        r = GhidraResult()
        r.functions = [
            GhidraFunction(name="a", address=0x100),
            GhidraFunction(name="b", address=0x200),
        ]
        assert r.total_functions == 2

    def test_function_by_address(self):
        r = GhidraResult()
        r.functions = [GhidraFunction(name="a", address=0x100)]
        assert r.function_by_address(0x100) is not None
        assert r.function_by_address(0x999) is None

    def test_function_by_name(self):
        r = GhidraResult()
        r.functions = [GhidraFunction(name="test")]
        assert r.function_by_name("test") is not None
        assert r.function_by_name("nope") is None

    def test_decompilation_by_address(self):
        r = GhidraResult()
        r.decompilations = [GhidraDecompilation(address=0x100, pseudo_c="code")]
        assert r.decompilation_by_address(0x100) is not None

    def test_compute_statistics(self):
        r = GhidraResult()
        r.functions = [GhidraFunction(name="a")]
        r.decompilations = [GhidraDecompilation(address=1, pseudo_c="x")]
        stats = r.compute_statistics()
        assert stats["total_functions"] == 1
        assert stats["total_decompilations"] == 1


# ── Engine tests ─────────────────────────────────────────────────────


class TestGhidraEngine:
    def test_not_found(self, monkeypatch):
        engine = GhidraEngine(ghidra_home="/nonexistent")
        assert not engine.available

    def test_analyze_missing_binary(self, monkeypatch):
        engine = GhidraEngine(ghidra_home="/nonexistent")
        result = engine.analyze("/nonexistent/binary.so")
        assert result.status == GhidraStatus.NOT_FOUND

    def test_merge_with_metadata(self):
        engine = GhidraEngine(ghidra_home="/nonexistent")
        ghidra_result = GhidraResult()
        ghidra_result.functions = [
            GhidraFunction(name="PlayerController_Update", address=0x1000),
        ]
        metadata_classes = [
            TypeDefinition(index=0, name="PlayerController", namespace="Game", token=0x1234),
        ]
        mapping = engine.merge_with_metadata(ghidra_result, metadata_classes)
        assert len(mapping) == 1
        assert mapping[0x1000] == "PlayerController"

    def test_merge_no_match(self):
        engine = GhidraEngine(ghidra_home="/nonexistent")
        ghidra_result = GhidraResult()
        ghidra_result.functions = [GhidraFunction(name="unknown_func", address=0x1000)]
        mapping = engine.merge_with_metadata(ghidra_result, [])
        assert len(mapping) == 0
