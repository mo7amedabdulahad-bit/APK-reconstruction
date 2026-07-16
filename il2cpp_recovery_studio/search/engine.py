"""Search engine: indexes all recovered data and provides unified search."""
from __future__ import annotations

import re
import time
from dataclasses import dataclass, field

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.search.models import (
    SearchMode,
    SearchQuery,
    SearchResponse,
    SearchResult,
    SearchScope,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod

logger = get_logger("search.engine")


class SearchEngine:
    """Unified search over recovered Unity data."""

    def __init__(self) -> None:
        self._index: list[SearchResult] = []
        self._indexed = False

    def index(
        self,
        recovered_classes: list[RecoveredClass],
        strings: list | None = None,
        assets: list | None = None,
    ) -> None:
        self._index.clear()
        for rc in recovered_classes:
            self._index_class(rc)
        for s in strings or []:
            self._index_string(s)
        for a in assets or []:
            self._index_asset(a)
        self._indexed = True
        logger.info("Search index built: %d entries", len(self._index))

    def _index_class(self, rc: RecoveredClass) -> None:
        ns = rc.namespace or ""
        self._index.append(SearchResult(
            name=rc.name, kind="class", namespace=ns,
            address=0, metadata_token=rc.token, snippet=ns,
        ))
        for m in rc.methods:
            self._index.append(SearchResult(
                name=m.name, kind="method", namespace=ns,
                address=m.native_address, metadata_token=m.token,
                snippet=f"{rc.name}.{m.name}",
            ))
        for f in rc.fields:
            self._index.append(SearchResult(
                name=f.name, kind="field", namespace=ns,
                metadata_token=f.token, snippet=f"{rc.name}.{f.name}",
            ))

    def _index_string(self, s) -> None:
        self._index.append(SearchResult(
            name=s.value, kind="string",
            metadata_token=getattr(s, "metadata_token", 0),
            snippet=getattr(s, "source_class", ""),
        ))

    def _index_asset(self, a) -> None:
        self._index.append(SearchResult(
            name=a.name, kind="asset",
            snippet=getattr(a, "path", ""),
        ))

    def search(self, query: SearchQuery) -> SearchResponse:
        start = time.time()
        response = SearchResponse(query=query.text)

        if not self._indexed:
            response.results = []
            response.total_hits = 0
            return response

        results = self._search(query)
        results.sort(key=lambda r: r.score, reverse=True)
        truncated = len(results) > query.max_results
        results = results[: query.max_results]

        response.results = results
        response.total_hits = len(results)
        response.truncated = truncated
        response.search_time_ms = (time.time() - start) * 1000
        return response

    def _search(self, query: SearchQuery) -> list[SearchResult]:
        text = query.text
        case_sensitive = query.case_sensitive
        scope = query.scope

        if query.mode == SearchMode.EXACT:
            return self._search_exact(text, case_sensitive, scope)
        if query.mode == SearchMode.CONTAINS:
            return self._search_contains(text, case_sensitive, scope)
        if query.mode == SearchMode.REGEX:
            return self._search_regex(text, case_sensitive, scope)
        if query.mode == SearchMode.FUZZY:
            return self._search_fuzzy(text, scope)
        return []

    def _scope_filter(self, scope: SearchScope) -> list[SearchResult]:
        if scope == SearchScope.ALL:
            return list(self._index)
        kind_map = {
            SearchScope.CLASSES: "class",
            SearchScope.METHODS: "method",
            SearchScope.FIELDS: "field",
            SearchScope.STRINGS: "string",
            SearchScope.ASSETS: "asset",
        }
        kind = kind_map.get(scope)
        if kind:
            return [r for r in self._index if r.kind == kind]
        return list(self._index)

    def _search_exact(self, text: str, case_sensitive: bool, scope: SearchScope) -> list[SearchResult]:
        candidates = self._scope_filter(scope)
        results = []
        for r in candidates:
            name = r.name if case_sensitive else r.name.lower()
            target = text if case_sensitive else text.lower()
            if name == target:
                results.append(SearchResult(
                    name=r.name, kind=r.kind, namespace=r.namespace,
                    address=r.address, metadata_token=r.metadata_token,
                    score=1.0, snippet=r.snippet,
                ))
        return results

    def _search_contains(self, text: str, case_sensitive: bool, scope: SearchScope) -> list[SearchResult]:
        candidates = self._scope_filter(scope)
        results = []
        target = text if case_sensitive else text.lower()
        for r in candidates:
            name = r.name if case_sensitive else r.name.lower()
            snippet = r.snippet if case_sensitive else r.snippet.lower()
            if target in name or target in snippet:
                score = 1.0 if target in name else 0.5
                results.append(SearchResult(
                    name=r.name, kind=r.kind, namespace=r.namespace,
                    address=r.address, metadata_token=r.metadata_token,
                    score=score, snippet=r.snippet,
                ))
        return results

    def _search_regex(self, pattern: str, case_sensitive: bool, scope: SearchScope) -> list[SearchResult]:
        candidates = self._scope_filter(scope)
        flags = 0 if case_sensitive else re.IGNORECASE
        try:
            regex = re.compile(pattern, flags)
        except re.error:
            return []
        results = []
        for r in candidates:
            if regex.search(r.name):
                results.append(SearchResult(
                    name=r.name, kind=r.kind, namespace=r.namespace,
                    address=r.address, metadata_token=r.metadata_token,
                    score=0.9, snippet=r.snippet,
                ))
        return results

    def _search_fuzzy(self, text: str, scope: SearchScope) -> list[SearchResult]:
        candidates = self._scope_filter(scope)
        text_lower = text.lower()
        results = []
        for r in candidates:
            name_lower = r.name.lower()
            common = sum(1 for c in text_lower if c in name_lower)
            score = common / max(len(text_lower), len(name_lower), 1)
            if score > 0.2:
                results.append(SearchResult(
                    name=r.name, kind=r.kind, namespace=r.namespace,
                    address=r.address, metadata_token=r.metadata_token,
                    score=score, snippet=r.snippet,
                ))
        return results
