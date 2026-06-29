"""Data models for network analysis."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class NetworkProtocolType(Enum):
    """Detected network protocol types."""

    REST = auto()
    UNITY_WEB_REQUEST = auto()
    HTTP_CLIENT = auto()
    SOCKET_IO = auto()
    SIGNALR = auto()
    PROTOBUF = auto()
    MESSAGE_PACK = auto()
    FLAT_BUFFERS = auto()
    GRAPHQL = auto()
    GRPC = auto()
    WEBSOCKET = auto()
    UNKNOWN = auto()


class AuthMethod(Enum):
    """Authentication method types."""

    NONE = auto()
    TOKEN = auto()
    BASIC = auto()
    API_KEY = auto()
    OAUTH = auto()
    CUSTOM = auto()


@dataclass
class NetworkEndpoint:
    """A detected network endpoint."""

    url: str
    method: str = "GET"
    protocol: NetworkProtocolType = NetworkProtocolType.UNKNOWN
    headers: dict[str, str] = field(default_factory=dict)
    auth_method: AuthMethod = AuthMethod.NONE
    content_type: str = ""
    caller_class: str = ""
    caller_method: str = ""
    confidence: float = 0.0
    is_https: bool = False

    @property
    def domain(self) -> str:
        try:
            from urllib.parse import urlparse
            parsed = urlparse(self.url)
            return parsed.hostname or ""
        except Exception:
            return ""


@dataclass
class NetworkDataPattern:
    """A detected serialization/deserialization pattern."""

    format_name: str
    protocol: NetworkProtocolType = NetworkProtocolType.UNKNOWN
    class_name: str = ""
    method_name: str = ""
    confidence: float = 0.0
    sample_data: str = ""


@dataclass
class NetworkReport:
    """Aggregated network analysis report."""

    endpoints: list[NetworkEndpoint] = field(default_factory=list)
    data_patterns: list[NetworkDataPattern] = field(default_factory=list)
    urls: list[str] = field(default_factory=list)
    json_samples: list[str] = field(default_factory=list)
    header_sets: list[dict[str, str]] = field(default_factory=list)
    authentication_methods: list[AuthMethod] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_endpoints(self) -> int:
        return len(self.endpoints)

    @property
    def unique_domains(self) -> set[str]:
        return {e.domain for e in self.endpoints if e.domain}

    @property
    def https_endpoints(self) -> list[NetworkEndpoint]:
        return [e for e in self.endpoints if e.is_https]

    def by_protocol(self, protocol: NetworkProtocolType) -> list[NetworkEndpoint]:
        return [e for e in self.endpoints if e.protocol == protocol]

    def by_auth(self, auth: AuthMethod) -> list[NetworkEndpoint]:
        return [e for e in self.endpoints if e.auth_method == auth]

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {
            "total_endpoints": self.total_endpoints,
            "unique_domains": len(self.unique_domains),
            "https_endpoints": len(self.https_endpoints),
            "total_urls": len(self.urls),
            "total_json_samples": len(self.json_samples),
            "total_data_patterns": len(self.data_patterns),
        }
        for ep in self.endpoints:
            key = ep.protocol.name
            stats[key] = stats.get(key, 0) + 1
        for auth in self.authentication_methods:
            key = f"auth:{auth.name}"
            stats[key] = stats.get(key, 0) + 1
        self.statistics = stats
        return stats
