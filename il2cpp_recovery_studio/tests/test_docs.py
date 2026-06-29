"""Tests for Phase 16: HTML documentation generation."""
from __future__ import annotations

import os
import tempfile

import pytest

from il2cpp_recovery_studio.docs_gen.generator import HTMLDocGenerator
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod


class TestHTMLDocGenerator:
    def _make_classes(self) -> list[RecoveredClass]:
        a = RecoveredClass(name="PlayerController", namespace="Game", confidence=0.9)
        a.fields = [
            RecoveredField(name="health", type_name="int"),
            RecoveredField(name="name", type_name="string"),
        ]
        a.methods = [
            RecoveredMethod(name="Update", return_type="void", native_address=0x1000),
            RecoveredMethod(name="Jump", return_type="void", parameters="float force"),
        ]

        b = RecoveredClass(name="EnemyAI", namespace="Game", confidence=0.9)
        b.parent_class = "MonoBehaviour"
        b.methods = [RecoveredMethod(name="Chase", return_type="bool")]

        return [a, b]

    def test_empty_input(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate([], tmpdir)
            assert os.path.isfile(result)

    def test_generates_html_file(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir)
            assert os.path.isfile(result)
            content = open(result).read()
            assert "PlayerController" in content
            assert "EnemyAI" in content

    def test_contains_fields(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir)
            content = open(result).read()
            assert "health" in content
            assert "int" in content

    def test_contains_methods(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir)
            content = open(result).read()
            assert "Update" in content
            assert "0x1000" in content

    def test_contains_inheritance(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir)
            content = open(result).read()
            assert "MonoBehaviour" in content

    def test_navigation(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir)
            content = open(result).read()
            assert "Navigation" in content

    def test_custom_title(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            gen = HTMLDocGenerator()
            result = gen.generate(self._make_classes(), tmpdir, title="My Game")
            content = open(result).read()
            assert "My Game" in content

    def test_full_pipeline(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            classes = []
            for i in range(10):
                rc = RecoveredClass(name=f"Class{i}", namespace="Ns", confidence=0.8)
                rc.fields = [RecoveredField(name=f"f{i}", type_name="int")]
                rc.methods = [RecoveredMethod(name=f"m{i}", return_type="void")]
                classes.append(rc)

            gen = HTMLDocGenerator()
            result = gen.generate(classes, tmpdir)
            content = open(result).read()
            assert "Class0" in content
            assert "Class9" in content
            assert "Total classes: 10" in content
