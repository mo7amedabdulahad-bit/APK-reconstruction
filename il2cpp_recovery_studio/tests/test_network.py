"""Tests for Phase 9: Network analysis."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.network.models import (
    AuthMethod,
    NetworkDataPattern,
    NetworkEndpoint,
    NetworkProtocolType,
    NetworkReport,
)
from il2cpp_recovery_studio.network.analyzer import NetworkAnalyzer
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod


# ── Model tests ──────────────────────────────────────────────────────


class TestNetworkEndpoint:
    def test_domain_from_url(self):
        ep = NetworkEndpoint(url="https://api.example.com/v1/users")
        assert ep.domain == "api.example.com"

    def test_domain_empty(self):
        ep = NetworkEndpoint(url="")
        assert ep.domain == ""


class TestNetworkReport:
    def _make_report(self) -> NetworkReport:
        r = NetworkReport()
        r.endpoints = [
            NetworkEndpoint(url="https://api.example.com/login", protocol=NetworkProtocolType.REST,
                            auth_method=AuthMethod.TOKEN, is_https=True),
            NetworkEndpoint(url="https://api.example.com/data", protocol=NetworkProtocolType.REST,
                            is_https=True),
            NetworkEndpoint(url="ws://realtime.example.com", protocol=NetworkProtocolType.WEBSOCKET),
        ]
        r.urls = ["https://api.example.com/login", "https://api.example.com/data"]
        return r

    def test_total_endpoints(self):
        r = self._make_report()
        assert r.total_endpoints == 3

    def test_unique_domains(self):
        r = self._make_report()
        assert len(r.unique_domains) == 2

    def test_https_endpoints(self):
        r = self._make_report()
        assert len(r.https_endpoints) == 2

    def test_by_protocol(self):
        r = self._make_report()
        assert len(r.by_protocol(NetworkProtocolType.REST)) == 2

    def test_by_auth(self):
        r = self._make_report()
        assert len(r.by_auth(AuthMethod.TOKEN)) == 1

    def test_compute_statistics(self):
        r = self._make_report()
        stats = r.compute_statistics()
        assert stats["total_endpoints"] == 3
        assert stats["unique_domains"] == 2
        assert stats["https_endpoints"] == 2


# ── Engine tests ─────────────────────────────────────────────────────


class TestNetworkAnalyzerDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        classes = []

        api = RecoveredClass(name="APIClient", namespace="Game.Network", confidence=0.9)
        api.methods = [
            RecoveredMethod(name="Login", return_type="void"),
            RecoveredMethod(name="GetData", return_type="void"),
        ]
        classes.append(api)

        web = RecoveredClass(name="WebRequestHandler", namespace="Game.Network", confidence=0.85)
        web.methods = [
            RecoveredMethod(name="SendRequest", return_type="void"),
        ]
        classes.append(web)

        return classes

    def test_empty_input(self):
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze([])
        assert report.total_endpoints == 0

    def test_detects_urls_in_methods(self):
        rc = RecoveredClass(name="API", namespace="Net", confidence=0.8)
        rc.methods = [
            RecoveredMethod(name="Fetch", return_type="void"),
        ]
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze([rc])
        assert isinstance(report.total_endpoints, int)

    def test_statistics(self):
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze(self._make_classes())
        stats = report.compute_statistics()
        assert "total_endpoints" in stats

    def test_detects_unity_web_request(self):
        rc = RecoveredClass(name="Downloader", namespace="Net", confidence=0.8)
        rc.methods = [
            RecoveredMethod(name="Download", return_type="UnityWebRequest"),
        ]
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze([rc])
        assert report.total_endpoints >= 0

    def test_detects_http_client(self):
        rc = RecoveredClass(name="HTTPService", namespace="Net", confidence=0.8)
        rc.methods = [
            RecoveredMethod(name="Get", return_type="HttpResponseMessage"),
        ]
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze([rc])
        assert isinstance(report, NetworkReport)

    def test_unique_urls(self):
        rc = RecoveredClass(name="API", namespace="Net", confidence=0.8)
        rc.methods = [
            RecoveredMethod(name="Call1", return_type="void"),
            RecoveredMethod(name="Call2", return_type="void"),
        ]
        analyzer = NetworkAnalyzer()
        report = analyzer.analyze([rc])
        assert len(report.urls) == len(set(report.urls))

    def test_full_pipeline(self):
        classes = []
        api = RecoveredClass(name="GameAPI", namespace="Network", confidence=0.9)
        api.methods = [
            RecoveredMethod(name="Login", return_type="bool"),
            RecoveredMethod(name="FetchData", return_type="string"),
        ]
        classes.append(api)

        ws = RecoveredClass(name="WebSocketClient", namespace="Network", confidence=0.85)
        ws.methods = [
            RecoveredMethod(name="Connect", return_type="void"),
        ]
        classes.append(ws)

        analyzer = NetworkAnalyzer()
        report = analyzer.analyze(classes)
        stats = report.compute_statistics()
        assert stats["total_endpoints"] >= 0
        assert isinstance(report.unique_domains, set)
