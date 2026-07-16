"""Project reconstructor: generates C# source files from recovered data."""
from __future__ import annotations

import os
import re
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod
from il2cpp_recovery_studio.methodmap.models import MappedMethod, MethodMap

logger = get_logger("reconstructor.engine")


def _sanitize_name(name: str) -> str:
    safe = re.sub(r"[^\w]", "_", name)
    if safe and safe[0].isdigit():
        safe = "_" + safe
    return safe or "_"


class ProjectReconstructor:
    """Generates a RecoveredProject/ directory with C# stubs for each recovered class."""

    def reconstruct(
        self,
        recovered_classes: list[RecoveredClass],
        output_dir: Path,
        method_map: MethodMap | None = None,
    ) -> Path:
        project_dir = output_dir / "RecoveredProject"
        project_dir.mkdir(parents=True, exist_ok=True)

        ns_dirs: dict[str, Path] = {}
        file_count = 0

        for rc in recovered_classes:
            ns = rc.namespace or "DefaultNamespace"
            if ns not in ns_dirs:
                ns_dir = project_dir / _sanitize_name(ns)
                ns_dir.mkdir(parents=True, exist_ok=True)
                ns_dirs[ns] = ns_dir

            filename = _sanitize_name(rc.name) + ".cs"
            filepath = ns_dirs[ns] / filename
            content = self._generate_class_file(rc, method_map)
            filepath.write_text(content, encoding="utf-8")
            file_count += 1

        logger.info(
            "Reconstructed %d classes into %s", file_count, project_dir
        )
        return project_dir

    def _generate_class_file(
        self, rc: RecoveredClass, method_map: MethodMap | None = None
    ) -> str:
        lines: list[str] = []
        lines.append("// ═══════════════════════════════════════════════════════════")
        lines.append(f"// Recovered: {rc.full_name or rc.name}")
        lines.append(f"// Namespace: {rc.namespace or '(none)'}")
        if rc.parent_class:
            lines.append(f"// Parent: {rc.parent_class}")
        if rc.source_tool:
            lines.append(f"// Source: {rc.source_tool}")
        lines.append(f"// Confidence: {rc.confidence:.0%}")
        lines.append("// ═══════════════════════════════════════════════════════════")
        lines.append("")

        if rc.namespace:
            lines.append(f"namespace {rc.namespace}")
            lines.append("{")
            indent = "    "
        else:
            indent = ""

        modifiers = self._class_modifiers(rc)
        lines.append(f"{indent}{modifiers}class {rc.name}")
        inherits: list[str] = []
        if rc.parent_class:
            inherits.append(rc.parent_class)
        if inherits:
            lines.append(f"{indent}    : {', '.join(inherits)}")
        lines.append(f"{indent}{{")

        if rc.fields:
            lines.append(f"{indent}    // ── Fields ─────────────────────────────")
            for field in rc.fields:
                lines.extend(self._generate_field(field, indent + "    "))
            lines.append("")

        if rc.methods:
            lines.append(f"{indent}    // ── Methods ────────────────────────────")
            for method in rc.methods:
                lines.extend(self._generate_method(method, indent + "    ", rc, method_map))
                lines.append("")

        lines.append(f"{indent}}}")
        if rc.namespace:
            lines.append("}")
        lines.append("")

        return "\n".join(lines)

    def _class_modifiers(self, rc: RecoveredClass) -> str:
        parts: list[str] = ["public"]
        if rc.is_abstract:
            parts.append("abstract")
        if rc.is_sealed:
            parts.append("sealed")
        return " ".join(parts)

    def _generate_field(self, field: RecoveredField, indent: str) -> list[str]:
        lines: list[str] = []
        modifiers = "public"
        if field.is_static:
            modifiers += " static"
        if field.is_literal:
            modifiers += " const"

        type_name = field.type_name or "object"
        lines.append(f"{indent}// Token: 0x{field.token:X} | Offset: {field.offset} | Confidence: {field.confidence:.0%}")
        lines.append(f"{indent}{modifiers} {type_name} {field.name};")
        return lines

    def _generate_method(
        self,
        method: RecoveredMethod,
        indent: str,
        rc: RecoveredClass,
        method_map: MethodMap | None,
    ) -> list[str]:
        lines: list[str] = []

        mapped = None
        if method_map:
            full_cls = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
            key = f"{full_cls}::{method.name}"
            results = method_map.by_name(key)
            if results:
                mapped = results[0]

        address = mapped.native_address if mapped else method.native_address
        size = mapped.function_size if mapped else method.function_size
        callers = mapped.caller_count if mapped else method.caller_count
        callees = mapped.callee_count if mapped else method.callee_count
        conf = mapped.confidence if mapped else method.confidence
        token = mapped.metadata_token if mapped else method.token

        lines.append(f"{indent}// Address: 0x{address:X} | Size: {size} bytes | Token: 0x{token:X}")
        lines.append(f"{indent}// Confidence: {conf:.0%} | Callers: {callers} | Callees: {callees}")

        modifiers = "public"
        if method.is_static:
            modifiers += " static"
        if method.is_abstract:
            modifiers += " abstract"

        return_type = method.return_type or "void"
        param_str = ", ".join(
            f"{p.type_name or 'object'} {p.name}" for p in method.parameters
        ) if method.parameters else ""

        lines.append(f"{indent}{modifiers} {return_type} {method.name}({param_str})")
        if method.is_abstract:
            lines.append(f"{indent}    ;")
        else:
            lines.append(f"{indent}{{")
            lines.append(f"{indent}    // Native method body at 0x{address:X}")
            lines.append(f"{indent}    throw new System.NotImplementedException();")
            lines.append(f"{indent}}}")

        return lines
