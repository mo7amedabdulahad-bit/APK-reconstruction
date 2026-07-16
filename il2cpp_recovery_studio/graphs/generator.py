"""Graph generation engine: builds various graph types from recovered Unity data."""
from __future__ import annotations

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.graphs.models import (
    EdgeType,
    GraphData,
    GraphEdge,
    GraphGenerationResult,
    GraphNode,
    GraphType,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod

logger = get_logger("graphs.generator")

NS_DELIM = "::"


def _class_id(c: RecoveredClass) -> str:
    ns = c.namespace or ""
    return f"{ns}{NS_DELIM}{c.name}" if ns else c.name


def _method_id(c: RecoveredClass, m: RecoveredMethod) -> str:
    return f"{_class_id(c)}.{m.name}"


class GraphGenerator:
    """Generates graphs from recovered Unity classes."""

    def generate(self, recovered_classes: list[RecoveredClass]) -> GraphGenerationResult:
        result = GraphGenerationResult()

        class_graph = self._build_class_graph(recovered_classes)
        if class_graph.node_count > 0:
            result.graphs.append(class_graph)

        ns_graph = self._build_namespace_graph(recovered_classes)
        if ns_graph.node_count > 0:
            result.graphs.append(ns_graph)

        call_graph = self._build_call_graph(recovered_classes)
        if call_graph.node_count > 0:
            result.graphs.append(call_graph)

        inheritance_graph = self._build_inheritance_graph(recovered_classes)
        if inheritance_graph.node_count > 0:
            result.graphs.append(inheritance_graph)

        result.compute_statistics()
        logger.info(
            "Graph generation: %d graphs, stats=%s",
            len(result.graphs),
            result.statistics,
        )
        return result

    def _build_class_graph(self, classes: list[RecoveredClass]) -> GraphData:
        g = GraphData(graph_type=GraphType.CLASS)
        for c in classes:
            g.nodes.append(GraphNode(
                id=_class_id(c),
                name=c.name,
                label=c.name,
                node_type="class",
                properties={"namespace": c.namespace or ""},
                metadata_token=c.token,
            ))
        for c in classes:
            cid = _class_id(c)
            for m in c.methods:
                g.nodes.append(GraphNode(
                    id=_method_id(c, m),
                    name=m.name,
                    label=m.name,
                    node_type="method",
                ))
                g.edges.append(GraphEdge(source=cid, target=_method_id(c, m), edge_type=EdgeType.CONTAINS))
        return g

    def _build_namespace_graph(self, classes: list[RecoveredClass]) -> GraphData:
        g = GraphData(graph_type=GraphType.NAMESPACE)
        namespaces: set[str] = set()
        ns_classes: dict[str, list[str]] = {}
        for c in classes:
            ns = c.namespace or "(global)"
            namespaces.add(ns)
            ns_classes.setdefault(ns, []).append(_class_id(c))

        for ns in sorted(namespaces):
            g.nodes.append(GraphNode(id=ns, name=ns, node_type="namespace"))
            class_ids = ns_classes[ns]
            for i, cid1 in enumerate(class_ids):
                for cid2 in class_ids[i + 1:]:
                    g.edges.append(GraphEdge(source=cid1, target=cid2, edge_type=EdgeType.IN_SAME_NAMESPACE))
        return g

    def _build_call_graph(self, classes: list[RecoveredClass]) -> GraphData:
        g = GraphData(graph_type=GraphType.CALL)
        for c in classes:
            for m in c.methods:
                g.nodes.append(GraphNode(
                    id=_method_id(c, m),
                    name=m.name,
                    label=f"{c.name}.{m.name}",
                    node_type="method",
                ))
        return g

    def _build_inheritance_graph(self, classes: list[RecoveredClass]) -> GraphData:
        g = GraphData(graph_type=GraphType.INHERITANCE)
        for c in classes:
            g.nodes.append(GraphNode(
                id=_class_id(c),
                name=c.name,
                node_type="class",
            ))
        for c in classes:
            if c.parent_class:
                g.nodes.append(GraphNode(id=c.parent_class, name=c.parent_class, node_type="base_class"))
                g.edges.append(GraphEdge(
                    source=_class_id(c),
                    target=c.parent_class,
                    edge_type=EdgeType.INHERITS,
                ))
            for iface in c.implements:
                g.nodes.append(GraphNode(id=iface, name=iface, node_type="interface"))
                g.edges.append(GraphEdge(
                    source=_class_id(c),
                    target=iface,
                    edge_type=EdgeType.IMPLEMENTS,
                ))
        return g
