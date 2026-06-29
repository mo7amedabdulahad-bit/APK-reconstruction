"""Tests for Phase 14: Search engine."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.search.models import (
    SearchMode,
    SearchQuery,
    SearchResponse,
    SearchResult,
    SearchScope,
)
from il2cpp_recovery_studio.search.engine import SearchEngine
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod


# ── Model tests ──────────────────────────────────────────────────────


class TestSearchResult:
    def test_result(self):
        r = SearchResult(name="Test", kind="class")
        assert r.name == "Test"


class TestSearchResponse:
    def test_has_results(self):
        r = SearchResponse()
        assert not r.has_results
        r.results = [SearchResult(name="x")]
        assert r.has_results

    def test_by_kind(self):
        r = SearchResponse()
        r.results = [
            SearchResult(name="a", kind="class"),
            SearchResult(name="b", kind="method"),
        ]
        assert len(r.by_kind("class")) == 1

    def test_top(self):
        r = SearchResponse()
        r.results = [
            SearchResult(name="a", score=0.5),
            SearchResult(name="b", score=0.9),
            SearchResult(name="c", score=0.7),
        ]
        top = r.top(2)
        assert top[0].score == 0.9
        assert top[1].score == 0.7


# ── Engine tests ─────────────────────────────────────────────────────


class TestSearchEngineDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        a = RecoveredClass(name="PlayerController", namespace="Game", confidence=0.9, token=0x100)
        a.methods = [
            RecoveredMethod(name="Update", native_address=0x1000),
            RecoveredMethod(name="Jump", native_address=0x2000),
        ]
        a.fields = [RecoveredField(name="health", type_name="int")]

        b = RecoveredClass(name="EnemyAI", namespace="Game", confidence=0.9, token=0x200)
        b.methods = [RecoveredMethod(name="Chase", native_address=0x3000)]

        return [a, b]

    def test_index(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        assert len(engine._index) > 0

    def test_search_exact(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="PlayerController", mode=SearchMode.EXACT)
        resp = engine.search(q)
        assert resp.has_results

    def test_search_contains(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="Player", mode=SearchMode.CONTAINS)
        resp = engine.search(q)
        assert resp.has_results

    def test_search_regex(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text=r"Player.*Controller", mode=SearchMode.REGEX)
        resp = engine.search(q)
        assert resp.has_results

    def test_search_fuzzy(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="Playr", mode=SearchMode.FUZZY)
        resp = engine.search(q)
        assert resp.has_results

    def test_search_case_sensitive(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="playercontroller", mode=SearchMode.CONTAINS, case_sensitive=True)
        resp = engine.search(q)
        assert not resp.has_results

    def test_scope_classes(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="Controller", mode=SearchMode.CONTAINS, scope=SearchScope.CLASSES)
        resp = engine.search(q)
        assert all(r.kind == "class" for r in resp.results)

    def test_max_results(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="e", mode=SearchMode.CONTAINS, max_results=1)
        resp = engine.search(q)
        assert len(resp.results) <= 1

    def test_search_time(self):
        engine = SearchEngine()
        engine.index(self._make_classes())
        q = SearchQuery(text="Player", mode=SearchMode.CONTAINS)
        resp = engine.search(q)
        assert resp.search_time_ms >= 0

    def test_not_indexed(self):
        engine = SearchEngine()
        q = SearchQuery(text="anything", mode=SearchMode.CONTAINS)
        resp = engine.search(q)
        assert not resp.has_results

    def test_full_pipeline(self):
        classes = []
        for i in range(5):
            rc = RecoveredClass(name=f"Class{i}", namespace="Ns", confidence=0.8)
            rc.methods = [RecoveredMethod(name=f"Method{i}", native_address=0x1000 + i * 0x100)]
            classes.append(rc)

        engine = SearchEngine()
        engine.index(classes)
        q = SearchQuery(text="Class", mode=SearchMode.CONTAINS)
        resp = engine.search(q)
        assert resp.has_results
        assert resp.total_hits >= 5
