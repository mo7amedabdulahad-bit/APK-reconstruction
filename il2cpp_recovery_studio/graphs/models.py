"""Data models for graph generation."""
from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum, auto


class GraphType(Enum):
    """Types of graphs that can be generated."""

    CALL = auto()
    CLASS = auto()
    NAMESPACE = auto()
    DEPENDENCY = auto()
    INHERITANCE = auto()
    SCENE = auto()
    ASSET = auto()


class EdgeType(Enum):
    """Types of edges in graphs."""

    CALLS = auto()
    INHERITS = auto()
    IMPLEMENTS = auto()
    CONTAINS = auto()
    DEPENDS_ON = auto()
    REFERENCES = auto()
    IN_SAME_NAMESPACE = auto()
    IN_SAME_SCENE = auto()


@dataclass
class GraphNode:
    """A node in a graph."""

    id: str
    name: str
    label: str = ""
    node_type: str = ""
    properties: dict[str, str] = field(default_factory=dict)
    metadata_token: int = 0


@dataclass
class GraphEdge:
    """An edge between two nodes."""

    source: str
    target: str
    edge_type: EdgeType = EdgeType.REFERENCES
    weight: float = 1.0
    label: str = ""


@dataclass
class GraphData:
    """A complete graph with nodes and edges."""

    graph_type: GraphType = GraphType.CLASS
    nodes: list[GraphNode] = field(default_factory=list)
    edges: list[GraphEdge] = field(default_factory=list)
    metadata: dict[str, str] = field(default_factory=dict)

    @property
    def node_count(self) -> int:
        return len(self.nodes)

    @property
    def edge_count(self) -> int:
        return len(self.edges)

    def get_node(self, node_id: str) -> GraphNode | None:
        for n in self.nodes:
            if n.id == node_id:
                return n
        return None

    def get_edges_from(self, node_id: str) -> list[GraphEdge]:
        return [e for e in self.edges if e.source == node_id]

    def get_edges_to(self, node_id: str) -> list[GraphEdge]:
        return [e for e in self.edges if e.target == node_id]

    def get_neighbors(self, node_id: str) -> list[str]:
        neighbors: set[str] = set()
        for e in self.edges:
            if e.source == node_id:
                neighbors.add(e.target)
            if e.target == node_id:
                neighbors.add(e.source)
        return sorted(neighbors)


@dataclass
class GraphGenerationResult:
    """Result of graph generation."""

    graphs: list[GraphData] = field(default_factory=list)
    statistics: dict[str, int] = field(default_factory=dict)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    def by_type(self, t: GraphType) -> list[GraphData]:
        return [g for g in self.graphs if g.graph_type == t]

    def get_graph(self, t: GraphType) -> GraphData | None:
        graphs = self.by_type(t)
        return graphs[0] if graphs else None

    def compute_statistics(self) -> dict[str, int]:
        stats: dict[str, int] = {"graphs": len(self.graphs)}
        for g in self.graphs:
            key = g.graph_type.name
            stats[f"{key}_nodes"] = stats.get(f"{key}_nodes", 0) + g.node_count
            stats[f"{key}_edges"] = stats.get(f"{key}_edges", 0) + g.edge_count
        self.statistics = stats
        return stats
