"""Tests for Phase 18: Exporters."""
from __future__ import annotations

import json
import os
import sqlite3
import tempfile

import pytest

from il2cpp_recovery_studio.exporters.exporters import (
    CSVExporter,
    JSONExporter,
    MarkdownExporter,
    SQLiteExporter,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod


def _make_classes() -> list[RecoveredClass]:
    a = RecoveredClass(name="Player", namespace="Game", confidence=0.9, token=0x100)
    a.fields = [RecoveredField(name="hp", type_name="int", default_value="100")]
    a.methods = [RecoveredMethod(name="Run", return_type="void", native_address=0x1000)]

    b = RecoveredClass(name="Enemy", namespace="Game", confidence=0.8)
    b.parent_class = "MonoBehaviour"
    b.methods = [RecoveredMethod(name="Attack", return_type="bool", parameters="int damage")]

    return [a, b]


class TestJSONExporter:
    def test_export(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            path = JSONExporter().export(_make_classes(), tmpdir)
            assert os.path.isfile(path)
            data = json.loads(open(path).read())
            assert len(data) == 2
            assert data[0]["name"] == "Player"

    def test_empty(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            path = JSONExporter().export([], tmpdir)
            assert os.path.isfile(path)


class TestCSVExporter:
    def test_export(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            path = CSVExporter().export(_make_classes(), tmpdir)
            assert os.path.isfile(path)
            content = open(path).read()
            assert "Player" in content
            assert "Run" in content


class TestSQLiteExporter:
    def test_export(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            path = SQLiteExporter().export(_make_classes(), tmpdir)
            assert os.path.isfile(path)
            conn = sqlite3.connect(path)
            try:
                cur = conn.cursor()
                cur.execute("SELECT COUNT(*) FROM classes")
                assert cur.fetchone()[0] == 2
                cur.execute("SELECT COUNT(*) FROM methods")
                assert cur.fetchone()[0] == 2
            finally:
                conn.close()


class TestMarkdownExporter:
    def test_export(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            path = MarkdownExporter().export(_make_classes(), tmpdir)
            assert os.path.isfile(path)
            content = open(path).read()
            assert "# IL2CPP Recovery Report" in content
            assert "Player" in content
            assert "MonoBehaviour" in content
