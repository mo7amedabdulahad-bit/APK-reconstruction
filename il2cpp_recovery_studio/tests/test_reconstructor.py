"""Tests for Phase 7: Project reconstruction."""
from __future__ import annotations

from pathlib import Path

import pytest

from il2cpp_recovery_studio.reconstructor.engine import ProjectReconstructor, _sanitize_name
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod
from il2cpp_recovery_studio.methodmap.models import MappedMethod, MethodMap


class TestSanitizeName:
    def test_simple(self):
        assert _sanitize_name("Player") == "Player"

    def test_with_spaces(self):
        assert _sanitize_name("My Class") == "My_Class"

    def test_with_dots(self):
        assert _sanitize_name("System.Object") == "System_Object"

    def test_starts_with_digit(self):
        assert _sanitize_name("1Class") == "_1Class"

    def test_empty(self):
        assert _sanitize_name("") == "_"

    def test_special_chars(self):
        result = _sanitize_name("Foo<Bar>")
        assert result == "Foo_Bar_"


class TestProjectReconstructor:
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
            RecoveredField(name="health", type_name="float", token=0x100, confidence=0.8),
            RecoveredField(name="speed", type_name="float", token=0x104, confidence=0.7),
        ]
        rc.methods = [
            RecoveredMethod(name="Start", return_type="void", token=0x200,
                            native_address=0x1000, function_size=64, confidence=0.95),
            RecoveredMethod(name="Update", return_type="void", token=0x208,
                            native_address=0x2000, function_size=128, confidence=0.9),
        ]
        return [rc]

    def test_creates_project_dir(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        assert result.exists()
        assert result.name == "RecoveredProject"

    def test_creates_namespace_dir(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        ns_dir = result / "Game"
        assert ns_dir.exists()

    def test_creates_class_file(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        class_file = result / "Game" / "Player.cs"
        assert class_file.exists()

    def test_class_file_has_namespace(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "namespace Game" in content

    def test_class_file_has_class_name(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "class Player" in content

    def test_class_file_has_parent(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "UnityEngine.MonoBehaviour" in content

    def test_class_file_has_fields(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "health" in content
        assert "speed" in content
        assert "float" in content

    def test_class_file_has_methods(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "Start" in content
        assert "Update" in content

    def test_class_file_has_native_address(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "0x1000" in content
        assert "0x2000" in content

    def test_class_file_has_confidence(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "Confidence" in content

    def test_class_file_has_token(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "Token" in content

    def test_multiple_classes(self, tmp_path):
        classes = self._make_classes()
        enemy = RecoveredClass(name="Enemy", namespace="Game", source_tool="dumper", confidence=0.85)
        enemy.methods = [RecoveredMethod(name="Attack", confidence=0.8)]
        classes.append(enemy)

        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(classes, tmp_path)
        assert (result / "Game" / "Player.cs").exists()
        assert (result / "Game" / "Enemy.cs").exists()

    def test_no_namespace(self, tmp_path):
        rc = RecoveredClass(name="GlobalClass", confidence=0.7)
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path)
        default_dir = result / "DefaultNamespace"
        assert default_dir.exists()
        assert (default_dir / "GlobalClass.cs").exists()

    def test_abstract_class(self, tmp_path):
        rc = RecoveredClass(name="Base", namespace="Ns", is_abstract=True, confidence=0.8)
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path)
        content = (result / "Ns" / "Base.cs").read_text(encoding="utf-8")
        assert "abstract" in content

    def test_sealed_class(self, tmp_path):
        rc = RecoveredClass(name="Final", namespace="Ns", is_sealed=True, confidence=0.8)
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path)
        content = (result / "Ns" / "Final.cs").read_text(encoding="utf-8")
        assert "sealed" in content

    def test_with_method_map(self, tmp_path):
        rc = RecoveredClass(name="Player", namespace="Game", source_tool="dumper", confidence=0.7)
        rc.methods = [RecoveredMethod(name="Start", return_type="void", confidence=0.7)]

        mm = MethodMap()
        mm.add(MappedMethod(name="Start", namespace="Game", class_name="Player",
                            metadata_index=0, native_address=0xAAAA, function_size=99,
                            caller_count=10, callee_count=5, confidence=0.95))

        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path, method_map=mm)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert "0xAAAA" in content

    def test_static_field(self, tmp_path):
        rc = RecoveredClass(name="Config", namespace="App", confidence=0.8)
        rc.fields = [RecoveredField(name="MaxHP", type_name="int", is_static=True, confidence=0.9)]
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path)
        content = (result / "App" / "Config.cs").read_text(encoding="utf-8")
        assert "static" in content

    def test_static_method(self, tmp_path):
        rc = RecoveredClass(name="Util", namespace="App", confidence=0.8)
        rc.methods = [RecoveredMethod(name="Parse", is_static=True, return_type="int", confidence=0.9)]
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([rc], tmp_path)
        content = (result / "App" / "Util.cs").read_text(encoding="utf-8")
        assert "static" in content

    def test_empty_classes_list(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct([], tmp_path)
        assert result.exists()
        assert result.name == "RecoveredProject"

    def test_file_is_valid_utf8(self, tmp_path):
        reconstructor = ProjectReconstructor()
        result = reconstructor.reconstruct(self._make_classes(), tmp_path)
        content = (result / "Game" / "Player.cs").read_text(encoding="utf-8")
        assert len(content) > 0
