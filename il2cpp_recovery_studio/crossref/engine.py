"""Cross-reference engine: merges metadata and recovery data into a unified index."""
from __future__ import annotations

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.crossref.models import CrossRefEntry, CrossRefResult
from il2cpp_recovery_studio.metadata.models import MetadataRecoveryResult
from il2cpp_recovery_studio.recovery.models import RecoveredClass, PipelineResult

logger = get_logger("crossref.engine")


class CrossRefEngine:
    """Merges metadata, recovery, and analysis results into a unified cross-reference index."""

    def cross_reference(
        self,
        metadata: MetadataRecoveryResult | None = None,
        recovery: PipelineResult | None = None,
        recovered_classes: list[RecoveredClass] | None = None,
    ) -> CrossRefResult:
        result = CrossRefResult()

        if metadata:
            self._add_metadata_entries(metadata, result)

        if recovered_classes:
            self._add_recovery_entries(recovered_classes, result)

        if metadata and recovered_classes:
            self._link_metadata_to_recovery(metadata, recovered_classes, result)

        if recovery:
            self._add_pipeline_stats(recovery, result)

        result.compute_statistics()
        logger.info(
            "Cross-referencing complete: %d entries, %.1f%% resolved",
            result.total_entries,
            result.resolution_rate * 100,
        )
        return result

    def _add_metadata_entries(self, metadata: MetadataRecoveryResult, result: CrossRefResult) -> None:
        for td in metadata.type_definitions:
            entry = CrossRefEntry(
                id=f"meta:type:{td.index}",
                name=td.name,
                namespace=td.namespace,
                kind="class",
                metadata_index=td.index,
                recovery_source="metadata",
                token=td.token,
                confidence=0.5,
                full_name=td.full_name,
                metadata={"field_count": td.field_count, "method_count": td.method_count},
            )
            result.entries.append(entry)

        for md in metadata.method_definitions:
            entry = CrossRefEntry(
                id=f"meta:method:{md.index}",
                name=md.name,
                kind="method",
                metadata_index=md.index,
                recovery_source="metadata",
                token=md.token,
                confidence=0.5,
                metadata={
                    "declaring_type_index": md.declaring_type_index,
                    "parameter_count": md.parameter_count,
                    "is_static": md.is_static,
                    "is_constructor": md.is_constructor,
                },
            )
            result.entries.append(entry)

        for fd in metadata.field_definitions:
            entry = CrossRefEntry(
                id=f"meta:field:{fd.index}",
                name=fd.name,
                kind="field",
                metadata_index=fd.index,
                recovery_source="metadata",
                token=fd.token,
                confidence=0.5,
                metadata={"type_index": fd.type_index},
            )
            result.entries.append(entry)

    def _add_recovery_entries(
        self, recovered_classes: list[RecoveredClass], result: CrossRefResult
    ) -> None:
        for rc in recovered_classes:
            full_name = rc.full_name or f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
            entry = CrossRefEntry(
                id=f"recovery:class:{full_name}",
                name=rc.name,
                namespace=rc.namespace,
                kind="class",
                recovery_source=rc.source_tool or "recovery",
                confidence=rc.confidence,
                full_name=full_name,
                parent_id=rc.parent_class,
                metadata={
                    "field_count": len(rc.fields),
                    "method_count": len(rc.methods),
                    "is_interface": rc.is_interface,
                    "is_enum": rc.is_enum,
                    "is_struct": rc.is_struct,
                },
            )
            result.entries.append(entry)

            for method in rc.methods:
                method_id = f"recovery:method:{full_name}.{method.name}"
                m_entry = CrossRefEntry(
                    id=method_id,
                    name=method.name,
                    kind="method",
                    recovery_source=rc.source_tool or "recovery",
                    native_address=method.native_address,
                    confidence=method.confidence,
                    parent_id=f"recovery:class:{full_name}",
                    metadata={
                        "return_type": method.return_type,
                        "parameter_count": len(method.parameters),
                        "is_static": method.is_static,
                    },
                )
                result.entries.append(m_entry)

            for field in rc.fields:
                field_id = f"recovery:field:{full_name}.{field.name}"
                f_entry = CrossRefEntry(
                    id=field_id,
                    name=field.name,
                    kind="field",
                    recovery_source=rc.source_tool or "recovery",
                    confidence=field.confidence,
                    parent_id=f"recovery:class:{full_name}",
                    metadata={"type_name": field.type_name, "offset": field.offset},
                )
                result.entries.append(f_entry)

    def _link_metadata_to_recovery(
        self,
        metadata: MetadataRecoveryResult,
        recovered_classes: list[RecoveredClass],
        result: CrossRefResult,
    ) -> None:
        type_map: dict[str, CrossRefEntry] = {}
        for entry in result.entries:
            if entry.kind == "class" and entry.full_name:
                type_map[entry.full_name] = entry

        for rc in recovered_classes:
            full_name = rc.full_name or f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
            meta_entry = None
            for entry in result.entries:
                if (
                    entry.kind == "class"
                    and entry.recovery_source == "metadata"
                    and entry.name == rc.name
                    and entry.namespace == rc.namespace
                ):
                    meta_entry = entry
                    break

            if meta_entry and full_name in type_map:
                recovery_entry = type_map[full_name]
                if recovery_entry.confidence > meta_entry.confidence:
                    meta_entry.confidence = recovery_entry.confidence
                    meta_entry.recovery_source = f"metadata+{recovery_entry.recovery_source}"
                else:
                    meta_entry.confidence = max(meta_entry.confidence, recovery_entry.confidence * 0.8)
                    meta_entry.recovery_source = f"metadata+{recovery_entry.recovery_source}"

    def _add_pipeline_stats(self, recovery: PipelineResult, result: CrossRefResult) -> None:
        result.metadata["pipeline"] = {
            "classes_recovered": recovery.classes_recovered,
            "methods_recovered": recovery.methods_recovered,
            "fields_recovered": recovery.fields_recovered,
            "strings_recovered": recovery.strings_recovered,
            "total_time_ms": recovery.total_time_ms,
        }
