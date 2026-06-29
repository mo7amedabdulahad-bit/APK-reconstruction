"""Unit tests for the recovery pipeline – Phase 3."""
from __future__ import annotations

import json
import sqlite3
from pathlib import Path

import pytest

from il2cpp_recovery_studio.recovery.models import (
    PipelineResult,
    RecoveredClass,
    RecoveredField,
    RecoveredMethod,
    RecoveredParameter,
    RecoveredProperty,
    ToolResult,
    ToolStatus,
)
from il2cpp_recovery_studio.recovery.parsers import (
    Cpp2ILParser,
    Il2CppDumperParser,
    Il2CppInspectorParser,
)
from il2cpp_recovery_studio.recovery.database import RecoveryDatabase
from il2cpp_recovery_studio.recovery.tool_registry import ToolRegistry
from il2cpp_recovery_studio.core.config import AppConfig


# =====================================================================
# Test: Models
# =====================================================================

class TestToolResult:
    def test_defaults(self) -> None:
        r = ToolResult(tool_name="test")
        assert r.status == ToolStatus.PENDING
        assert r.success is False
        assert r.execution_time_ms == 0.0

    def test_success_status(self) -> None:
        r = ToolResult(tool_name="test", status=ToolStatus.SUCCESS)
        assert r.success is True

    def test_failed_status(self) -> None:
        r = ToolResult(tool_name="test", status=ToolStatus.FAILED)
        assert r.success is False


class TestPipelineResult:
    def test_defaults(self) -> None:
        r = PipelineResult()
        assert r.any_success is False
        assert r.all_failed is True
        assert r.classes_recovered == 0

    def test_any_success(self) -> None:
        r = PipelineResult(tool_results=[
            ToolResult(tool_name="a", status=ToolStatus.FAILED),
            ToolResult(tool_name="b", status=ToolStatus.SUCCESS),
        ])
        assert r.any_success is True
        assert r.all_failed is False

    def test_all_failed(self) -> None:
        r = PipelineResult(tool_results=[
            ToolResult(tool_name="a", status=ToolStatus.FAILED),
            ToolResult(tool_name="b", status=ToolStatus.SKIPPED),
        ])
        assert r.all_failed is True

    def test_successful_tools(self) -> None:
        r = PipelineResult(tool_results=[
            ToolResult(tool_name="a", status=ToolStatus.SUCCESS),
            ToolResult(tool_name="b", status=ToolStatus.FAILED),
            ToolResult(tool_name="c", status=ToolStatus.SUCCESS),
        ])
        assert len(r.successful_tools()) == 2

    def test_failed_tools(self) -> None:
        r = PipelineResult(tool_results=[
            ToolResult(tool_name="a", status=ToolStatus.SUCCESS),
            ToolResult(tool_name="b", status=ToolStatus.FAILED),
        ])
        assert len(r.failed_tools()) == 1


class TestRecoveredClass:
    def test_defaults(self) -> None:
        cls = RecoveredClass(name="Test")
        assert cls.name == "Test"
        assert cls.namespace == ""
        assert len(cls.methods) == 0
        assert len(cls.fields) == 0

    def test_with_methods(self) -> None:
        method = RecoveredMethod(name="DoStuff", native_address=0x1000)
        cls = RecoveredClass(name="Player", methods=[method])
        assert len(cls.methods) == 1
        assert cls.methods[0].native_address == 0x1000

    def test_full_name(self) -> None:
        cls = RecoveredClass(name="Player", namespace="Game.Core", full_name="Game.Core.Player")
        assert cls.full_name == "Game.Core.Player"


class TestRecoveredMethod:
    def test_with_parameters(self) -> None:
        params = [
            RecoveredParameter(name="hp", type_name="System.Int32", position=0),
            RecoveredParameter(name="name", type_name="System.String", position=1),
        ]
        method = RecoveredMethod(name="Init", parameters=params)
        assert len(method.parameters) == 2
        assert method.parameters[0].name == "hp"


# =====================================================================
# Test: Tool Registry
# =====================================================================

class TestToolRegistry:
    def test_discover_does_not_crash(self) -> None:
        registry = ToolRegistry(config=AppConfig())
        tools = registry.discover()
        assert isinstance(tools, dict)

    def test_get_tool_returns_none_for_unknown(self) -> None:
        registry = ToolRegistry(config=AppConfig())
        registry.discover()
        assert registry.get_tool("nonexistent_tool_xyz") is None

    def test_validate_tools(self) -> None:
        registry = ToolRegistry(config=AppConfig())
        result = registry.validate_tools()
        assert isinstance(result, dict)

    def test_available_tools_returns_list(self) -> None:
        registry = ToolRegistry(config=AppConfig())
        registry.discover()
        assert isinstance(registry.available_tools(), list)

    def test_unavailable_tools_returns_list(self) -> None:
        registry = ToolRegistry(config=AppConfig())
        registry.discover()
        assert isinstance(registry.unavailable_tools(), list)


# =====================================================================
# Test: Cpp2IL Parser
# =====================================================================

class TestCpp2ILParser:
    def test_parse_empty_dir(self, tmp_path: Path) -> None:
        parser = Cpp2ILParser()
        result = parser.parse(tmp_path / "nonexistent")
        assert result == []

    def test_parse_json_type_map(self, tmp_path: Path) -> None:
        data = {
            "Types": [
                {
                    "Name": "Player",
                    "Namespace": "Game",
                    "Methods": [
                        {"Name": "Attack", "Address": "0x1234", "Token": 100},
                    ],
                    "Fields": [
                        {"Name": "health", "Type": "System.Int32", "Offset": 16},
                    ],
                }
            ]
        }
        json_file = tmp_path / "types.json"
        json_file.write_text(json.dumps(data), encoding="utf-8")

        parser = Cpp2ILParser()
        result = parser.parse(tmp_path)
        assert len(result) == 1
        assert result[0].name == "Player"
        assert result[0].namespace == "Game"
        assert len(result[0].methods) == 1
        assert result[0].methods[0].name == "Attack"

    def test_parse_csharp_stub(self, tmp_path: Path) -> None:
        stub = "public class GameManager : MonoBehaviour { public void Start() {} }"
        (tmp_path / "GameManager.cs").write_text(stub, encoding="utf-8")

        parser = Cpp2ILParser()
        result = parser.parse(tmp_path)
        assert len(result) >= 1
        names = [c.name for c in result]
        assert "GameManager" in names


# =====================================================================
# Test: Il2CppDumper Parser
# =====================================================================

class TestIl2CppDumperParser:
    def test_parse_empty_dir(self, tmp_path: Path) -> None:
        parser = Il2CppDumperParser()
        result = parser.parse(tmp_path / "nonexistent")
        assert result == []

    def test_parse_script_json(self, tmp_path: Path) -> None:
        data = [
            {
                "TypeName": "Enemy",
                "Namespace": "Game.Combat",
                "Methods": [
                    {
                        "MethodName": "TakeDamage",
                        "ReturnType": "System.Void",
                        "Parameters": [
                            {"Name": "amount", "TypeName": "System.Single", "Position": 0}
                        ],
                        "MethodAddress": "0xABCD",
                        "Token": 200,
                        "IsStatic": False,
                    }
                ],
                "Fields": [
                    {"FieldName": "maxHealth", "Type": "System.Single", "Offset": 24, "IsStatic": True}
                ],
                "ParentType": "UnityEngine.MonoBehaviour",
                "IsInterface": False,
                "IsEnum": False,
            }
        ]
        (tmp_path / "script.json").write_text(json.dumps(data), encoding="utf-8")

        parser = Il2CppDumperParser()
        result = parser.parse(tmp_path)
        assert len(result) == 1
        cls = result[0]
        assert cls.name == "Enemy"
        assert cls.namespace == "Game.Combat"
        assert cls.parent_class == "UnityEngine.MonoBehaviour"
        assert len(cls.methods) == 1
        assert cls.methods[0].name == "TakeDamage"
        assert cls.methods[0].native_address == 0xABCD
        assert len(cls.methods[0].parameters) == 1
        assert cls.methods[0].parameters[0].name == "amount"

    def test_parse_dump_cs(self, tmp_path: Path) -> None:
        dump = """
public class Player : MonoBehaviour
{
    public System.Int32 health;
    public System.Void TakeDamage(System.Single amount) {}
    public static System.Boolean IsAlive() {}
}
"""
        (tmp_path / "dump.cs").write_text(dump, encoding="utf-8")

        parser = Il2CppDumperParser()
        result = parser.parse(tmp_path)
        assert len(result) >= 1


# =====================================================================
# Test: Il2CppInspector Parser
# =====================================================================

class TestIl2CppInspectorParser:
    def test_parse_empty_dir(self, tmp_path: Path) -> None:
        parser = Il2CppInspectorParser()
        result = parser.parse(tmp_path / "nonexistent")
        assert result == []

    def test_parse_json_types(self, tmp_path: Path) -> None:
        data = {
            "types": [
                {
                    "name": "NetworkManager",
                    "namespace": "Game.Net",
                    "methods": [
                        {"name": "Connect", "address": "0x5000"}
                    ],
                }
            ]
        }
        (tmp_path / "types.json").write_text(json.dumps(data), encoding="utf-8")

        parser = Il2CppInspectorParser()
        result = parser.parse(tmp_path)
        assert len(result) == 1
        assert result[0].name == "NetworkManager"


# =====================================================================
# Test: Recovery Database
# =====================================================================

class TestRecoveryDatabase:
    def test_store_and_retrieve(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "test.db")
        classes = [
            RecoveredClass(
                name="Player",
                namespace="Game",
                full_name="Game.Player",
                parent_class="MonoBehaviour",
                fields=[
                    RecoveredField(name="health", type_name="int", offset=16),
                ],
                methods=[
                    RecoveredMethod(
                        name="TakeDamage",
                        native_address=0x1000,
                        parameters=[RecoveredParameter(name="amount", type_name="float")],
                    ),
                ],
                confidence=0.9,
                source_tool="Il2CppDumper",
            )
        ]
        count = db.store_classes(classes)
        assert count == 1

        # Retrieve
        result = db.get_class("Game.Player")
        assert result is not None
        assert result["name"] == "Player"
        assert result["parent_class"] == "MonoBehaviour"
        assert len(result["fields"]) == 1
        assert result["fields"][0]["name"] == "health"
        assert len(result["methods"]) == 1
        assert result["methods"][0]["name"] == "TakeDamage"
        assert len(result["methods"][0]["parameters"]) == 1
        db.close()

    def test_search_classes(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "test.db")
        db.store_classes([
            RecoveredClass(name="PlayerController", full_name="Game.PlayerController"),
            RecoveredClass(name="EnemyAI", full_name="Game.EnemyAI"),
            RecoveredClass(name="GameManager", full_name="Game.GameManager"),
        ])
        results = db.search_classes("Player")
        assert len(results) == 1
        assert results[0]["name"] == "PlayerController"
        db.close()

    def test_search_methods(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "test.db")
        db.store_classes([
            RecoveredClass(
                name="Combat",
                full_name="Game.Combat",
                methods=[
                    RecoveredMethod(name="Attack", native_address=0x100),
                    RecoveredMethod(name="Defend", native_address=0x200),
                ],
            )
        ])
        results = db.search_methods("Attack")
        assert len(results) == 1
        db.close()

    def test_get_method_by_address(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "test.db")
        db.store_classes([
            RecoveredClass(
                name="A",
                full_name="A",
                methods=[RecoveredMethod(name="Foo", native_address=0xDEAD)],
            )
        ])
        result = db.get_method_by_address(0xDEAD)
        assert result is not None
        assert result["name"] == "Foo"
        db.close()

    def test_statistics(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "test.db")
        db.store_classes([
            RecoveredClass(
                name="A",
                namespace="NS",
                full_name="NS.A",
                confidence=0.8,
                source_tool="Tool1",
                methods=[RecoveredMethod(name="m1")],
                fields=[RecoveredField(name="f1")],
            ),
            RecoveredClass(
                name="B",
                namespace="NS",
                full_name="NS.B",
                confidence=0.6,
                source_tool="Tool2",
            ),
        ])
        stats = db.get_statistics()
        assert stats["total_classes"] == 2
        assert stats["total_methods"] == 1
        assert stats["total_fields"] == 1
        assert abs(stats["average_confidence"] - 0.7) < 0.01
        db.close()

    def test_empty_database_statistics(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "empty.db")
        stats = db.get_statistics()
        assert stats["total_classes"] == 0
        assert stats["total_methods"] == 0
        db.close()

    def test_store_multiple_classes(self, tmp_path: Path) -> None:
        db = RecoveryDatabase(tmp_path / "multi.db")
        classes = [
            RecoveredClass(name=f"Class{i}", full_name=f"NS.Class{i}")
            for i in range(50)
        ]
        count = db.store_classes(classes)
        assert count == 50
        stats = db.get_statistics()
        assert stats["total_classes"] == 50
        db.close()


# =====================================================================
# Test: Class Merging
# =====================================================================

class TestClassMerging:
    def test_merge_preferred_confidence(self) -> None:
        from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator

        classes = [
            RecoveredClass(name="Player", full_name="Player", confidence=0.5, source_tool="A"),
            RecoveredClass(name="Player", full_name="Player", confidence=0.9, source_tool="B"),
        ]
        merged = RecoveryOrchestrator._merge_classes(classes)
        assert len(merged) == 1
        # Higher confidence comes first, so source should be "B"
        assert merged[0].confidence == 0.9

    def test_merge_methods_combined(self) -> None:
        from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator

        classes = [
            RecoveredClass(
                name="Player", full_name="Player", confidence=0.5,
                methods=[RecoveredMethod(name="Attack")],
            ),
            RecoveredClass(
                name="Player", full_name="Player", confidence=0.9,
                methods=[RecoveredMethod(name="Defend")],
            ),
        ]
        merged = RecoveryOrchestrator._merge_classes(classes)
        assert len(merged) == 1
        method_names = {m.name for m in merged[0].methods}
        assert "Attack" in method_names
        assert "Defend" in method_names

    def test_merge_no_duplicates(self) -> None:
        from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator

        classes = [
            RecoveredClass(
                name="A", full_name="A", confidence=0.8,
                methods=[RecoveredMethod(name="Foo")],
            ),
            RecoveredClass(
                name="A", full_name="A", confidence=0.7,
                methods=[RecoveredMethod(name="Foo")],
            ),
        ]
        merged = RecoveryOrchestrator._merge_classes(classes)
        assert len(merged[0].methods) == 1

    def test_merge_empty(self) -> None:
        from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator

        merged = RecoveryOrchestrator._merge_classes([])
        assert merged == []
