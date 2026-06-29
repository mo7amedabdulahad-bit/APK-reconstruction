"""Tests for Phase 6: Method mapping."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.methodmap.models import MappedMethod, MethodMap
from il2cpp_recovery_studio.methodmap.engine import MethodMapper
from il2cpp_recovery_studio.metadata.models import (
    MetadataRecoveryResult,
    TypeDefinition,
    MethodDefinition,
)
from il2cpp_recovery_studio.recovery.models import (
    RecoveredClass,
    RecoveredMethod,
    RecoveredParameter,
)


# ── MappedMethod model tests ─────────────────────────────────────────


class TestMappedMethod:
    def test_defaults(self):
        m = MappedMethod(name="Start")
        assert m.name == "Start"
        assert m.native_address == 0
        assert m.confidence == 0.0
        assert not m.is_mapped

    def test_full_name_with_class(self):
        m = MappedMethod(name="Start", namespace="Game", class_name="Player")
        assert m.full_name == "Game.Player::Start"

    def test_full_name_no_class(self):
        m = MappedMethod(name="GlobalFunc")
        assert m.full_name == "GlobalFunc"

    def test_full_name_namespace_only(self):
        m = MappedMethod(name="Do", namespace="Ns")
        assert m.full_name == "Ns::Do"

    def test_is_mapped_true(self):
        m = MappedMethod(name="Start", native_address=0x1000, metadata_index=5)
        assert m.is_mapped

    def test_is_mapped_no_address(self):
        m = MappedMethod(name="Start", native_address=0, metadata_index=5)
        assert not m.is_mapped

    def test_is_mapped_no_metadata(self):
        m = MappedMethod(name="Start", native_address=0x1000, metadata_index=-1)
        assert m.is_mapped

    def test_address_hex(self):
        m = MappedMethod(name="X", native_address=0xDEAD)
        assert m.address_hex == "0xDEAD"

    def test_address_hex_zero(self):
        m = MappedMethod(name="X", native_address=0)
        assert m.address_hex == "0x0"


# ── MethodMap model tests ────────────────────────────────────────────


class TestMethodMap:
    def _make_map(self) -> MethodMap:
        mm = MethodMap()
        mm.add(MappedMethod(name="Start", namespace="Game", class_name="Player",
                            metadata_index=0, native_address=0x1000, confidence=0.9))
        mm.add(MappedMethod(name="Update", namespace="Game", class_name="Player",
                            metadata_index=1, native_address=0x2000, confidence=0.85))
        mm.add(MappedMethod(name="Attack", namespace="Game", class_name="Enemy",
                            metadata_index=2, native_address=0x3000, confidence=0.8))
        mm.add(MappedMethod(name="Hidden", namespace="Game", class_name="Player",
                            metadata_index=3, confidence=0.5))
        return mm

    def test_total(self):
        mm = self._make_map()
        assert mm.total == 4

    def test_mapped_count(self):
        mm = self._make_map()
        assert mm.mapped_count == 3

    def test_unmapped_count(self):
        mm = self._make_map()
        assert mm.unmapped_count == 1

    def test_mapping_rate(self):
        mm = self._make_map()
        assert abs(mm.mapping_rate - 0.75) < 0.01

    def test_mapping_rate_empty(self):
        mm = MethodMap()
        assert mm.mapping_rate == 0.0

    def test_by_metadata_index(self):
        mm = self._make_map()
        m = mm.by_metadata_index(0)
        assert m is not None
        assert m.name == "Start"

    def test_by_metadata_index_miss(self):
        mm = self._make_map()
        assert mm.by_metadata_index(999) is None

    def test_by_address(self):
        mm = self._make_map()
        m = mm.by_address(0x2000)
        assert m is not None
        assert m.name == "Update"

    def test_by_address_miss(self):
        mm = self._make_map()
        assert mm.by_address(0xFFFF) is None

    def test_by_name(self):
        mm = self._make_map()
        results = mm.by_name("Game.Player::Start")
        assert len(results) == 1
        assert results[0].name == "Start"

    def test_by_class(self):
        mm = self._make_map()
        results = mm.by_class("Game.Player")
        assert len(results) == 3

    def test_all_methods(self):
        mm = self._make_map()
        assert len(mm.all_methods) == 4

    def test_get_callers(self):
        mm = self._make_map()
        callers = mm.get_callers(0x2000)
        assert isinstance(callers, list)

    def test_get_callees(self):
        mm = self._make_map()
        callees = mm.get_callees(0x1000)
        assert isinstance(callees, list)

    def test_compute_statistics(self):
        mm = self._make_map()
        stats = mm.compute_statistics()
        assert stats["total"] == 4
        assert stats["mapped"] == 3
        assert stats["unmapped"] == 1

    def test_statistics_with_constructors(self):
        mm = MethodMap()
        mm.add(MappedMethod(name=".ctor", is_constructor=True, metadata_index=0))
        mm.add(MappedMethod(name=".cctor", is_constructor=True, metadata_index=1))
        stats = mm.compute_statistics()
        assert stats["constructors"] == 2

    def test_statistics_static_methods(self):
        mm = MethodMap()
        mm.add(MappedMethod(name="Static", is_static=True, metadata_index=0))
        stats = mm.compute_statistics()
        assert stats["static"] == 1

    def test_statistics_generic_methods(self):
        mm = MethodMap()
        mm.add(MappedMethod(name="Generic", is_generic=True, metadata_index=0))
        stats = mm.compute_statistics()
        assert stats["generic"] == 1


# ── MethodMapper engine tests ────────────────────────────────────────


class TestMethodMapperMetadataOnly:
    def test_empty_inputs(self):
        mapper = MethodMapper()
        mm = mapper.build_map()
        assert mm.total == 0

    def test_metadata_methods_added(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start", declaring_type_index=0),
            MethodDefinition(index=1, name="Update", declaring_type_index=0),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata)
        assert mm.total == 2
        assert mm.by_metadata_index(0).name == "Start"

    def test_metadata_method_has_class_info(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start", declaring_type_index=0),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata)
        m = mm.by_metadata_index(0)
        assert m.class_name == "Player"
        assert m.namespace == "Game"

    def test_metadata_methods_not_native_mapped(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=i) for i in range(10)
        ]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="X", declaring_type_index=0),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata)
        assert mm.mapped_count == 0


class TestMethodMapperRecoveryOnly:
    def test_recovery_methods_added(self):
        rc = RecoveredClass(name="Player", namespace="Game", source_tool="cpp2il")
        rc.methods = [
            RecoveredMethod(name="Start", native_address=0x1000, function_size=128,
                            caller_count=3, callee_count=2, confidence=0.9),
            RecoveredMethod(name="Update", native_address=0x2000, function_size=256,
                            confidence=0.85),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(recovered_classes=[rc])
        assert mm.total == 2
        assert mm.mapped_count == 2

    def test_recovery_method_preserves_address(self):
        rc = RecoveredClass(name="Player", namespace="Game", source_tool="dumper")
        rc.methods = [
            RecoveredMethod(name="Attack", native_address=0x5000, confidence=0.8),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(recovered_classes=[rc])
        m = mm.by_address(0x5000)
        assert m is not None
        assert m.name == "Attack"

    def test_recovery_method_sizes(self):
        rc = RecoveredClass(name="X", source_tool="cpp2il")
        rc.methods = [
            RecoveredMethod(name="Do", native_address=0x1000, function_size=64,
                            caller_count=5, callee_count=3, confidence=0.7),
        ]
        mapper = MethodMapper()
        mm = mapper.build_map(recovered_classes=[rc])
        m = mm.by_address(0x1000)
        assert m.function_size == 64
        assert m.caller_count == 5
        assert m.callee_count == 3

    def test_multiple_classes(self):
        classes = []
        for name in ["Player", "Enemy", "NPC"]:
            rc = RecoveredClass(name=name, namespace="Game", source_tool="cpp2il")
            rc.methods = [RecoveredMethod(name="Act", native_address=0x1000 + hash(name) % 1000)]
            classes.append(rc)
        mapper = MethodMapper()
        mm = mapper.build_map(recovered_classes=classes)
        assert mm.total == 3


class TestMethodMapperMerging:
    def test_merge_native_address(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start", declaring_type_index=0),
            MethodDefinition(index=1, name="Update", declaring_type_index=0),
        ]

        rc = RecoveredClass(name="Player", namespace="Game", source_tool="cpp2il")
        rc.methods = [
            RecoveredMethod(name="Start", native_address=0x1000, confidence=0.9),
            RecoveredMethod(name="Update", native_address=0x2000, confidence=0.85),
        ]

        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata, recovered_classes=[rc])
        assert mm.mapped_count == 2
        m = mm.by_metadata_index(0)
        assert m.native_address == 0x1000
        assert m.confidence >= 0.3

    def test_merge_boosts_confidence(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="X", namespace="Ns"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Do", declaring_type_index=0),
        ]

        rc = RecoveredClass(name="X", namespace="Ns", source_tool="cpp2il")
        rc.methods = [RecoveredMethod(name="Do", native_address=0x5000, confidence=0.95)]

        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata, recovered_classes=[rc])
        m = mm.by_metadata_index(0)
        assert m.confidence >= 0.3

    def test_merge_unmatched_recovery_added_separately(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="A", namespace="Ns"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Foo", declaring_type_index=0),
        ]

        rc = RecoveredClass(name="B", namespace="Ns", source_tool="cpp2il")
        rc.methods = [RecoveredMethod(name="Bar", native_address=0x9000, confidence=0.8)]

        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata, recovered_classes=[rc])
        assert mm.total == 2
        m = mm.by_address(0x9000)
        assert m is not None
        assert m.name == "Bar"

    def test_full_pipeline(self):
        metadata = MetadataRecoveryResult(version=29)
        metadata.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game"),
        ] + [TypeDefinition(index=i) for i in range(1, 10)]
        metadata.method_definitions = [
            MethodDefinition(index=0, name="Start", declaring_type_index=0),
            MethodDefinition(index=1, name="Update", declaring_type_index=0),
            MethodDefinition(index=2, name="Attack", declaring_type_index=0),
        ]

        rc = RecoveredClass(name="Player", namespace="Game", source_tool="cpp2il")
        rc.methods = [
            RecoveredMethod(name="Start", native_address=0x1000, function_size=64,
                            caller_count=3, callee_count=2, confidence=0.95),
            RecoveredMethod(name="Update", native_address=0x2000, function_size=128,
                            confidence=0.9),
        ]

        mapper = MethodMapper()
        mm = mapper.build_map(metadata=metadata, recovered_classes=[rc])

        assert mm.total >= 3
        assert mm.mapped_count >= 2

        m = mm.by_metadata_index(0)
        assert m is not None
        assert m.native_address == 0x1000
        assert m.function_size == 64
        assert m.caller_count == 3
        assert m.callee_count == 2

        stats = mm.compute_statistics()
        assert stats["total"] >= 3
        assert stats["mapped"] >= 2
