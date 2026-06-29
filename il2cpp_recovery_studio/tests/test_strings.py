"""Tests for Phase 10: String analysis."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.strings.models import (
    ExtractedString,
    StringAnalysisResult,
    StringCategory,
)
from il2cpp_recovery_studio.strings.analyzer import StringAnalyzer
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod


# ── Model tests ──────────────────────────────────────────────────────


class TestExtractedString:
    def test_length(self):
        s = ExtractedString(value="Hello World")
        assert s.length == 11

    def test_is_empty(self):
        s = ExtractedString(value="")
        assert s.is_empty

    def test_not_empty(self):
        s = ExtractedString(value="x")
        assert not s.is_empty


class TestStringAnalysisResult:
    def _make_result(self) -> StringAnalysisResult:
        r = StringAnalysisResult()
        r.strings = [
            ExtractedString(value="https://api.example.com", category=StringCategory.URL),
            ExtractedString(value="Error: file not found", category=StringCategory.ERROR),
            ExtractedString(value="Debug: variable x = 5", category=StringCategory.DEBUG),
            ExtractedString(value="MainMenu", category=StringCategory.SCENE_NAME),
            ExtractedString(value="Hello", category=StringCategory.UNKNOWN),
        ]
        return r

    def test_total_strings(self):
        r = self._make_result()
        assert r.total_strings == 5

    def test_unique_strings(self):
        r = self._make_result()
        assert r.unique_strings == 5

    def test_by_category(self):
        r = self._make_result()
        urls = r.by_category(StringCategory.URL)
        assert len(urls) == 1

    def test_by_class(self):
        r = StringAnalysisResult()
        r.strings = [
            ExtractedString(value="a", source_class="Foo"),
            ExtractedString(value="b", source_class="Bar"),
            ExtractedString(value="c", source_class="Foo"),
        ]
        assert len(r.by_class("Foo")) == 2

    def test_by_length(self):
        r = self._make_result()
        long_strings = r.by_length(min_len=10)
        assert len(long_strings) >= 1

    def test_search_case_insensitive(self):
        r = self._make_result()
        results = r.search("error")
        assert len(results) == 1

    def test_search_case_sensitive(self):
        r = self._make_result()
        results = r.search("Error", case_sensitive=True)
        assert len(results) == 1

    def test_search_no_match(self):
        r = self._make_result()
        results = r.search("nonexistent")
        assert len(results) == 0

    def test_compute_statistics(self):
        r = self._make_result()
        stats = r.compute_statistics()
        assert stats["total"] == 5
        assert stats["unique"] == 5
        assert stats.get("URL", 0) == 1
        assert stats.get("ERROR", 0) == 1


# ── Engine tests ─────────────────────────────────────────────────────


class TestStringAnalyzerDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        classes = []

        api = RecoveredClass(name="APIClient", namespace="Game", confidence=0.9)
        api.fields = [
            RecoveredField(name="baseUrl", type_name="string", default_value="https://api.game.com/v1"),
            RecoveredField(name="apiKey", type_name="string", default_value="api_key='secret123'"),
        ]
        api.methods = [
            RecoveredMethod(name="Login", return_type="bool"),
        ]
        classes.append(api)

        ui = RecoveredClass(name="UIManager", namespace="Game", confidence=0.85)
        ui.fields = [
            RecoveredField(name="sceneName", type_name="string", default_value="MainMenu"),
        ]
        ui.methods = [
            RecoveredMethod(name="ShowError", return_type="void"),
        ]
        classes.append(ui)

        return classes

    def test_empty_input(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze([])
        assert result.total_strings == 0

    def test_extracts_field_defaults(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        assert result.total_strings >= 3

    def test_categorizes_urls(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        urls = result.by_category(StringCategory.URL)
        assert len(urls) >= 1

    def test_categorizes_api_keys(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        keys = result.by_category(StringCategory.API_KEY)
        assert len(keys) >= 1

    def test_categorizes_scene_names(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        scenes = result.by_category(StringCategory.SCENE_NAME)
        assert len(scenes) >= 1

    def test_statistics(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        stats = result.compute_statistics()
        assert stats["total"] >= 3
        assert stats["unique"] >= 3

    def test_error_detection(self):
        rc = RecoveredClass(name="ErrorHandler", namespace="Game", confidence=0.8)
        rc.fields = [
            RecoveredField(name="msg", type_name="string", default_value="Error: connection failed"),
        ]
        analyzer = StringAnalyzer()
        result = analyzer.analyze([rc])
        errors = result.by_category(StringCategory.ERROR)
        assert len(errors) >= 1

    def test_debug_detection(self):
        rc = RecoveredClass(name="Logger", namespace="Game", confidence=0.8)
        rc.fields = [
            RecoveredField(name="logMsg", type_name="string", default_value="Debug: entering method"),
        ]
        analyzer = StringAnalyzer()
        result = analyzer.analyze([rc])
        debugs = result.by_category(StringCategory.DEBUG)
        assert len(debugs) >= 1

    def test_localization_detection(self):
        rc = RecoveredClass(name="TextLoader", namespace="Game", confidence=0.8)
        rc.fields = [
            RecoveredField(name="label", type_name="string", default_value="localization_key_start"),
        ]
        analyzer = StringAnalyzer()
        result = analyzer.analyze([rc])
        locs = result.by_category(StringCategory.LOCALIZATION)
        assert len(locs) >= 1

    def test_search(self):
        analyzer = StringAnalyzer()
        result = analyzer.analyze(self._make_classes())
        found = result.search("game.com")
        assert len(found) >= 1

    def test_full_pipeline(self):
        classes = []
        for i in range(5):
            rc = RecoveredClass(name=f"Class{i}", namespace="Ns", confidence=0.8)
            rc.fields = [
                RecoveredField(name="data", type_name="string",
                               default_value=f"Value_{i}"),
            ]
            classes.append(rc)

        analyzer = StringAnalyzer()
        result = analyzer.analyze(classes)
        assert result.total_strings >= 5
        stats = result.compute_statistics()
        assert stats["total"] >= 5
