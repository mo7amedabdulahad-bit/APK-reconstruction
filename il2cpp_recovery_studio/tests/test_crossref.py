"""Tests for Phase 5: Cross-referencing engine."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.crossref.models import CrossRefEntry, CrossRefResult
from il2cpp_recovery_studio.crossref.engine import CrossRefEngine
from il2cpp_recovery_studio.metadata.models import (
    MetadataRecoveryResult,
    TypeDefinition,
    MethodDefinition,
    FieldDefinition,
    ImageDefinition,
)
from il2cpp_recovery_studio.recovery.models import (
    RecoveredClass,
    RecoveredMethod,
    RecoveredField,
    RecoveredParameter,
    PipelineResult,
    ToolResult,
    ToolStatus,
)


# ── CrossRefEntry model tests ────────────────────────────────────────


class TestCrossRefEntry:
    def test_defaults(self):
        e = CrossRefEntry(id="test:1", name="Foo")
        assert e.id == "test:1"
        assert e.name == "Foo"
        assert e.kind == ""
        assert e.confidence == 0.0
        assert not e.is_resolved

    def test_is_resolved_when_confident(self):
        e = CrossRefEntry(id="test:1", name="Foo", confidence=0.8, recovery_source="tool")
        assert e.is_resolved

    def test_is_resolved_no_source(self):
        e = CrossRefEntry(id="test:1", name="Foo", confidence=0.8, recovery_source="")
        assert not e.is_resolved

    def test_is_resolved_zero_confidence(self):
        e = CrossRefEntry(id="test:1", name="Foo", confidence=0.0, recovery_source="tool")
        assert not e.is_resolved


# ── CrossRefResult model tests ───────────────────────────────────────


class TestCrossRefResult:
    def _make_result(self) -> CrossRefResult:
        r = CrossRefResult()
        r.entries = [
            CrossRefEntry(id="c1", name="Player", kind="class", confidence=0.9, recovery_source="cpp2il"),
            CrossRefEntry(id="m1", name="Start", kind="method", confidence=0.7, recovery_source="dumper"),
            CrossRefEntry(id="f1", name="health", kind="field", confidence=0.5, recovery_source="metadata"),
            CrossRefEntry(id="c2", name="Enemy", kind="class", confidence=0.0, recovery_source=""),
        ]
        return r

    def test_total_entries(self):
        r = self._make_result()
        assert r.total_entries == 4

    def test_resolved_count(self):
        r = self._make_result()
        assert r.resolved_count == 3

    def test_resolution_rate(self):
        r = self._make_result()
        assert abs(r.resolution_rate - 0.75) < 0.01

    def test_resolution_rate_empty(self):
        r = CrossRefResult()
        assert r.resolution_rate == 0.0

    def test_by_kind(self):
        r = self._make_result()
        classes = r.by_kind("class")
        assert len(classes) == 2
        assert classes[0].name == "Player"

    def test_by_source(self):
        r = self._make_result()
        from_cpp2il = r.by_source("cpp2il")
        assert len(from_cpp2il) == 1

    def test_by_name(self):
        r = self._make_result()
        matches = r.by_name("Player")
        assert len(matches) == 1

    def test_by_full_name(self):
        r = CrossRefResult()
        r.entries = [
            CrossRefEntry(id="1", name="Player", full_name="Game.Player"),
            CrossRefEntry(id="2", name="Player", full_name="UI.Player"),
        ]
        assert len(r.by_full_name("Game.Player")) == 1

    def test_get_entry(self):
        r = self._make_result()
        assert r.get_entry("c1") is not None
        assert r.get_entry("c1").name == "Player"
        assert r.get_entry("nonexistent") is None

    def test_compute_statistics(self):
        r = self._make_result()
        stats = r.compute_statistics()
        assert stats["total"] == 4
        assert stats["resolved"] == 3
        assert stats["unresolved"] == len(r.unresolved_refs)
        assert stats.get("class", 0) == 2
        assert stats.get("method", 0) == 1
        assert stats.get("field", 0) == 1


# ── CrossRefEngine tests ─────────────────────────────────────────────


class TestCrossRefEngineMetadataOnly:
    def test_empty_inputs(self):
        engine = CrossRefEngine()
        result = engine.cross_reference()
        assert result.total_entries == 0

    def test_metadata_only_types(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game"),
            TypeDefinition(index=1, name="Enemy", namespace="Game"),
        ]
        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata)
        assert result.total_entries == 2
        assert result.by_kind("class") == result.entries

    def test_metadata_only_methods(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [TypeDefinition(index=i) for i in range(10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start"),
            MethodDefinition(index=1, name="Update"),
            MethodDefinition(index=2, name="DoStuff"),
        ]
        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata)
        methods = result.by_kind("method")
        assert len(methods) == 3
        assert methods[0].name == "Start"

    def test_metadata_only_fields(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [TypeDefinition(index=i) for i in range(10)]
        metadata.field_definitions = [
            FieldDefinition(index=0, name="health"),
            FieldDefinition(index=1, name="speed"),
        ]
        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata)
        fields = result.by_kind("field")
        assert len(fields) == 2

    def test_metadata_confidence(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=i) for i in range(10)
        ]
        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata)
        for e in result.entries:
            assert e.confidence == 0.5
            assert e.recovery_source == "metadata"

    def test_metadata_methods_have_parent_index(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [TypeDefinition(index=i) for i in range(10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start", declaring_type_index=3),
        ]
        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata)
        methods = result.by_kind("method")
        assert methods[0].metadata["declaring_type_index"] == 3


class TestCrossRefEngineRecoveryOnly:
    def _make_classes(self) -> list[RecoveredClass]:
        rc = RecoveredClass(
            name="Player",
            namespace="Game",
            full_name="Game.Player",
            parent_class="UnityEngine.MonoBehaviour",
            source_tool="cpp2il",
            confidence=0.9,
        )
        rc.fields = [
            RecoveredField(name="health", type_name="float", confidence=0.8),
            RecoveredField(name="speed", type_name="float", confidence=0.7),
        ]
        rc.methods = [
            RecoveredMethod(name="Start", return_type="void", confidence=0.9, native_address=0x1000),
            RecoveredMethod(name="Update", return_type="void", confidence=0.85, native_address=0x2000),
        ]
        return [rc]

    def test_recovery_classes_added(self):
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=self._make_classes())
        classes = result.by_kind("class")
        assert len(classes) == 1
        assert classes[0].name == "Player"
        assert classes[0].full_name == "Game.Player"

    def test_recovery_methods_added(self):
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=self._make_classes())
        methods = result.by_kind("method")
        assert len(methods) == 2
        assert methods[0].name == "Start"
        assert methods[0].native_address == 0x1000

    def test_recovery_fields_added(self):
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=self._make_classes())
        fields = result.by_kind("field")
        assert len(fields) == 2
        assert fields[0].name == "health"

    def test_recovery_parent_id(self):
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=self._make_classes())
        methods = result.by_kind("method")
        assert methods[0].parent_id == "recovery:class:Game.Player"

    def test_recovery_confidence_preserved(self):
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=self._make_classes())
        classes = result.by_kind("class")
        assert classes[0].confidence == 0.9

    def test_multiple_classes(self):
        classes = self._make_classes()
        rc2 = RecoveredClass(
            name="Enemy",
            namespace="Game",
            full_name="Game.Enemy",
            source_tool="dumper",
            confidence=0.85,
        )
        rc2.methods = [RecoveredMethod(name="Attack", confidence=0.8)]
        classes.append(rc2)
        engine = CrossRefEngine()
        result = engine.cross_reference(recovered_classes=classes)
        assert result.total_entries == 7  # 2 classes + 3 methods + 2 fields


class TestCrossRefEngineMerging:
    def test_metadata_and_recovery_linked(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=i, name="Player" if i == 0 else f"Type{i}", namespace="Game")
            for i in range(10)
        ]
        metadata.method_definitions = [MethodDefinition(index=i, name=f"m{i}") for i in range(10)]
        metadata.field_definitions = [FieldDefinition(index=i, name=f"f{i}") for i in range(10)]

        rc = RecoveredClass(
            name="Player",
            namespace="Game",
            full_name="Game.Player",
            source_tool="cpp2il",
            confidence=0.9,
        )
        rc.methods = [RecoveredMethod(name="Start", confidence=0.9)]

        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata, recovered_classes=[rc])
        player_class = None
        for e in result.entries:
            if e.name == "Player" and e.kind == "class":
                player_class = e
                break
        assert player_class is not None
        assert player_class.confidence >= 0.5
        assert "metadata" in player_class.recovery_source

    def test_pipeline_stats_added(self):
        pr = PipelineResult(
            classes_recovered=50,
            methods_recovered=200,
            fields_recovered=100,
            strings_recovered=500,
            total_time_ms=1500.0,
        )
        engine = CrossRefEngine()
        result = engine.cross_reference(recovery=pr)
        assert "pipeline" in result.metadata
        assert result.metadata["pipeline"]["classes_recovered"] == 50

    def test_full_pipeline(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=i, name=f"Type{i}" if i > 0 else "Type0", namespace="Ns")
            for i in range(10)
        ]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start"),
            MethodDefinition(index=1, name="Update"),
        ]
        metadata.field_definitions = [FieldDefinition(index=0, name="hp")]

        rc = RecoveredClass(name="Type0", namespace="Ns", full_name="Ns.Type0", source_tool="cpp2il", confidence=0.95)
        rc.fields = [RecoveredField(name="hp", confidence=0.8)]
        rc.methods = [RecoveredMethod(name="Start", confidence=0.9)]

        pr = PipelineResult(classes_recovered=1, methods_recovered=1, fields_recovered=1)

        engine = CrossRefEngine()
        result = engine.cross_reference(metadata=metadata, recovered_classes=[rc], recovery=pr)
        assert result.total_entries >= 10
        assert result.resolved_count > 0
        stats = result.compute_statistics()
        assert stats["total"] >= 10
        assert "pipeline" in result.metadata
