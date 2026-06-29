"""Tests for Phase 12: Graph generation."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.graphs.models import (
    EdgeType,
    GraphData,
    GraphEdge,
    GraphGenerationResult,
    GraphNode,
    GraphType,
)
from il2cpp_recovery_studio.graphs.generator import GraphGenerator, _class_id, _method_id
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod


# ── Model tests ──────────────────────────────────────────────────────


class TestGraphNode:
    def test_node(self):
        n = GraphNode(id="A", name="A", node_type="class")
        assert n.id == "A"


class TestGraphEdge:
    def test_edge(self):
        e = GraphEdge(source="A", target="B", edge_type=EdgeType.CALLS)
        assert e.source == "A"
        assert e.target == "B"


class TestGraphData:
    def _make_graph(self) -> GraphData:
        g = GraphData(graph_type=GraphType.CLASS)
        g.nodes = [
            GraphNode(id="A", name="A"),
            GraphNode(id="B", name="B"),
            GraphNode(id="C", name="C"),
        ]
        g.edges = [
            GraphEdge(source="A", target="B"),
            GraphEdge(source="B", target="C"),
        ]
        return g

    def test_node_count(self):
        g = self._make_graph()
        assert g.node_count == 3

    def test_edge_count(self):
        g = self._make_graph()
        assert g.edge_count == 2

    def test_get_node(self):
        g = self._make_graph()
        assert g.get_node("A") is not None
        assert g.get_node("Z") is None

    def test_get_edges_from(self):
        g = self._make_graph()
        assert len(g.get_edges_from("A")) == 1

    def test_get_edges_to(self):
        g = self._make_graph()
        assert len(g.get_edges_to("C")) == 1

    def test_get_neighbors(self):
        g = self._make_graph()
        neighbors = g.get_neighbors("B")
        assert "A" in neighbors
        assert "C" in neighbors


class TestGraphGenerationResult:
    def test_result(self):
        r = GraphGenerationResult()
        g1 = GraphData(graph_type=GraphType.CLASS, nodes=[GraphNode(id="x", name="x")])
        g2 = GraphData(graph_type=GraphType.NAMESPACE, nodes=[GraphNode(id="y", name="y")])
        r.graphs = [g1, g2]
        assert len(r.by_type(GraphType.CLASS)) == 1
        assert r.get_graph(GraphType.NAMESPACE) is not None

    def test_compute_statistics(self):
        r = GraphGenerationResult()
        r.graphs = [
            GraphData(graph_type=GraphType.CLASS, nodes=[GraphNode(id="a", name="a")],
                      edges=[GraphEdge(source="a", target="a")]),
        ]
        stats = r.compute_statistics()
        assert stats["graphs"] == 1
        assert stats["CLASS_nodes"] == 1
        assert stats["CLASS_edges"] == 1


# ── Engine tests ─────────────────────────────────────────────────────


class TestGraphGeneratorHelpers:
    def test_class_id_no_namespace(self):
        c = RecoveredClass(name="Foo", namespace="")
        assert _class_id(c) == "Foo"

    def test_class_id_with_namespace(self):
        c = RecoveredClass(name="Foo", namespace="Bar")
        assert _class_id(c) == "Bar::Foo"

    def test_method_id(self):
        c = RecoveredClass(name="Foo", namespace="")
        m = RecoveredMethod(name="DoStuff")
        assert _method_id(c, m) == "Foo.DoStuff"


class TestGraphGeneratorDetection:
    def _make_classes(self) -> list[RecoveredClass]:
        a = RecoveredClass(name="A", namespace="Ns", confidence=0.9)
        a.methods = [RecoveredMethod(name="Run"), RecoveredMethod(name="Stop")]

        b = RecoveredClass(name="B", namespace="Ns", confidence=0.9)
        b.methods = [RecoveredMethod(name="Start")]
        b.implements = ["IDisposable"]

        c = RecoveredClass(name="C", namespace="", confidence=0.9)
        c.methods = [RecoveredMethod(name="Init")]

        return [a, b, c]

    def test_empty_input(self):
        result = GraphGenerator().generate([])
        assert len(result.graphs) == 0

    def test_generates_class_graph(self):
        result = GraphGenerator().generate(self._make_classes())
        g = result.get_graph(GraphType.CLASS)
        assert g is not None
        assert g.node_count > 0

    def test_generates_namespace_graph(self):
        result = GraphGenerator().generate(self._make_classes())
        g = result.get_graph(GraphType.NAMESPACE)
        assert g is not None

    def test_generates_inheritance_graph(self):
        result = GraphGenerator().generate(self._make_classes())
        g = result.get_graph(GraphType.INHERITANCE)
        assert g is not None

    def test_statistics(self):
        result = GraphGenerator().generate(self._make_classes())
        stats = result.compute_statistics()
        assert stats["graphs"] >= 2

    def test_full_pipeline(self):
        classes = []
        for i in range(5):
            rc = RecoveredClass(name=f"C{i}", namespace="TestNs", confidence=0.8)
            rc.methods = [RecoveredMethod(name=f"M{i}")]
            rc.implements = ["IDisposable"] if i == 0 else []
            classes.append(rc)

        result = GraphGenerator().generate(classes)
        assert len(result.graphs) >= 2
        for g in result.graphs:
            assert g.node_count > 0
