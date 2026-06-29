"""Network analysis engine: detects networking patterns in recovered Unity code."""
from __future__ import annotations

import re

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.network.models import (
    AuthMethod,
    NetworkDataPattern,
    NetworkEndpoint,
    NetworkProtocolType,
    NetworkReport,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod

logger = get_logger("network.analyzer")

URL_PATTERN = re.compile(
    r'https?://[^\s"\'<>\]\)]+|'
    r'wss?://[^\s"\'<>\]\)]+|'
    r'[\w.-]+\.(?:com|net|org|io|dev|api)[^\s"\'<>\]\)]*'
)

HTTP_METHODS = {"GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS"}

PROTOCOL_CLASS_PATTERNS: dict[str, NetworkProtocolType] = {
    r"(?i)UnityWebRequest": NetworkProtocolType.UNITY_WEB_REQUEST,
    r"(?i)HttpClient": NetworkProtocolType.HTTP_CLIENT,
    r"(?i)SocketIO(?:Client)?": NetworkProtocolType.SOCKET_IO,
    r"(?i)SignalR(?:Client|Connection)?": NetworkProtocolType.SIGNALR,
    r"(?i)(?:ProtoBuf|protobuf|Serializer)": NetworkProtocolType.PROTOBUF,
    r"(?i)MessagePack": NetworkProtocolType.MESSAGE_PACK,
    r"(?i)FlatBuffers": NetworkProtocolType.FLAT_BUFFERS,
    r"(?i)GraphQL(?:Client)?": NetworkProtocolType.GRAPHQL,
    r"(?i)GrpcChannel|Grpc(?:Client)?": NetworkProtocolType.GRPC,
    r"(?i)WebSocket": NetworkProtocolType.WEBSOCKET,
}

AUTH_PATTERNS: dict[str, AuthMethod] = {
    r"(?i)Authorization.*Bearer": AuthMethod.TOKEN,
    r"(?i)api[_-]?key": AuthMethod.API_KEY,
    r"(?i)Basic\s": AuthMethod.BASIC,
    r"(?i)OAuth": AuthMethod.OAUTH,
    r"(?i)token": AuthMethod.TOKEN,
}


class NetworkAnalyzer:
    """Analyzes recovered Unity classes for networking patterns."""

    def analyze(
        self, recovered_classes: list[RecoveredClass]
    ) -> NetworkReport:
        report = NetworkReport()

        for rc in recovered_classes:
            self._analyze_class(rc, report)

        self._extract_unique_urls(report)
        self._compute_statistics(report)

        logger.info(
            "Network analysis: %d endpoints, %d URLs, %d data patterns",
            report.total_endpoints,
            len(report.urls),
            len(report.data_patterns),
        )
        return report

    def _analyze_class(self, rc: RecoveredClass, report: NetworkReport) -> None:
        full_class = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name

        for method in rc.methods:
            self._analyze_method(rc, method, full_class, report)

    def _analyze_method(
        self,
        rc: RecoveredClass,
        method: RecoveredMethod,
        full_class: str,
        report: NetworkReport,
    ) -> None:
        text = f"{method.name} {method.return_type}"

        for pattern, proto in PROTOCOL_CLASS_PATTERNS.items():
            if re.search(pattern, text):
                endpoint = NetworkEndpoint(
                    url="",
                    protocol=proto,
                    caller_class=full_class,
                    caller_method=method.name,
                    confidence=0.6,
                )
                report.endpoints.append(endpoint)
                break

        url_matches = URL_PATTERN.findall(text)
        for url in url_matches:
            url = url.rstrip(".,;:)")
            if url.startswith("http") or url.startswith("ws"):
                report.urls.append(url)
                is_https = url.startswith("https") or url.startswith("wss")
                endpoint = NetworkEndpoint(
                    url=url,
                    protocol=NetworkProtocolType.REST,
                    caller_class=full_class,
                    caller_method=method.name,
                    confidence=0.8,
                    is_https=is_https,
                )
                report.endpoints.append(endpoint)

        for auth_pattern, auth_method in AUTH_PATTERNS.items():
            if re.search(auth_pattern, text):
                if auth_method not in report.authentication_methods:
                    report.authentication_methods.append(auth_method)
                break

        json_pattern = re.compile(r'"\w+"\s*:\s*(?:\[|\{)')
        json_matches = json_pattern.findall(text)
        for jm in json_matches[:3]:
            if jm not in report.json_samples:
                report.json_samples.append(jm)

    def _extract_unique_urls(self, report: NetworkReport) -> None:
        seen: set[str] = set()
        unique: list[str] = []
        for url in report.urls:
            if url not in seen:
                seen.add(url)
                unique.append(url)
        report.urls = unique

    def _compute_statistics(self, report: NetworkReport) -> None:
        report.compute_statistics()
