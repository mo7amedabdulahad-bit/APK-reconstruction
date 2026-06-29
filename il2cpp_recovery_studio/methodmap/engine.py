"""Method mapper engine: builds bidirectional method mappings from metadata and recovery data."""
from __future__ import annotations

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.methodmap.models import MappedMethod, MethodMap
from il2cpp_recovery_studio.metadata.models import MetadataRecoveryResult, MethodDefinition
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredMethod

logger = get_logger("methodmap.engine")


class MethodMapper:
    """Maps metadata method definitions to native functions using multiple data sources."""

    def build_map(
        self,
        metadata: MetadataRecoveryResult | None = None,
        recovered_classes: list[RecoveredClass] | None = None,
    ) -> MethodMap:
        method_map = MethodMap()

        if metadata:
            self._add_metadata_methods(metadata, method_map)

        if recovered_classes:
            self._add_recovery_methods(recovered_classes, method_map)

        if metadata and recovered_classes:
            self._merge_recovery_into_metadata(metadata, recovered_classes, method_map)

        logger.info(
            "Method mapping complete: %d total, %d mapped (%.1f%%)",
            method_map.total,
            method_map.mapped_count,
            method_map.mapping_rate * 100,
        )
        return method_map

    def _add_metadata_methods(
        self, metadata: MetadataRecoveryResult, method_map: MethodMap
    ) -> None:
        type_lookup: dict[int, tuple[str, str]] = {}
        for td in metadata.type_definitions:
            type_lookup[td.index] = (td.namespace, td.name)

        for md in metadata.method_definitions:
            ns, cls = type_lookup.get(md.declaring_type_index, ("", ""))
            mapped = MappedMethod(
                name=md.name,
                namespace=ns,
                class_name=cls,
                metadata_index=md.index,
                metadata_token=md.token,
                return_type="",
                is_static=md.is_static,
                is_constructor=md.is_constructor,
                is_abstract=md.is_abstract,
                is_generic=md.is_generic,
                confidence=0.3,
                source_tools=["metadata"],
            )
            method_map.add(mapped)

    def _add_recovery_methods(
        self, recovered_classes: list[RecoveredClass], method_map: MethodMap
    ) -> None:
        existing_by_name: set[str] = set()
        for m in method_map.all_methods:
            existing_by_name.add(m.full_name)

        for rc in recovered_classes:
            for rm in rc.methods:
                full_cls = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
                key = f"{full_cls}::{rm.name}"

                existing = method_map.by_address(rm.native_address) if rm.native_address else None
                if existing and rm.native_address != 0:
                    existing.caller_count = max(existing.caller_count, rm.caller_count)
                    existing.callee_count = max(existing.callee_count, rm.callee_count)
                    existing.function_size = max(existing.function_size, rm.function_size)
                    existing.confidence = max(existing.confidence, rm.confidence)
                    existing.source_tools.append(rc.source_tool or "recovery")
                    continue

                if key in existing_by_name:
                    continue

                mapped = MappedMethod(
                    name=rm.name,
                    namespace=rc.namespace,
                    class_name=rc.name,
                    native_address=rm.native_address,
                    function_size=rm.function_size,
                    caller_count=rm.caller_count,
                    callee_count=rm.callee_count,
                    confidence=rm.confidence,
                    return_type=rm.return_type,
                    parameters=[p.name for p in rm.parameters],
                    is_static=rm.is_static,
                    is_constructor=rm.name in (".ctor", ".cctor"),
                    is_abstract=rm.is_abstract,
                    is_generic=rm.is_generic,
                    source_tools=[rc.source_tool or "recovery"],
                )
                method_map.add(mapped)

    def _merge_recovery_into_metadata(
        self,
        metadata: MetadataRecoveryResult,
        recovered_classes: list[RecoveredClass],
        method_map: MethodMap,
    ) -> None:
        recovery_index: dict[str, RecoveredMethod] = {}
        for rc in recovered_classes:
            full_cls = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
            for rm in rc.methods:
                key = f"{full_cls}::{rm.name}"
                recovery_index[key] = rm

        for mapped in method_map.all_methods:
            if mapped.is_mapped:
                continue
            key = mapped.full_name
            rm = recovery_index.get(key)
            if rm is None:
                continue
            mapped.native_address = rm.native_address
            mapped.function_size = rm.function_size
            mapped.caller_count = rm.caller_count
            mapped.callee_count = rm.callee_count
            mapped.confidence = max(mapped.confidence, rm.confidence)
            mapped.return_type = rm.return_type or mapped.return_type
            if mapped.return_type:
                pass
            mapped.source_tools.append(rm.declaring_class or "recovery")
            logger.debug("Linked metadata method %s to native 0x%X", key, rm.native_address)
