"""Data models for the recovery pipeline."""
from __future__ import annotations

import sqlite3
from dataclasses import dataclass, field
from enum import Enum, auto
from pathlib import Path
from typing import Optional


class ToolStatus(Enum):
    """Execution status of a recovery tool."""

    PENDING = auto()
    RUNNING = auto()
    SUCCESS = auto()
    PARTIAL_SUCCESS = auto()
    FAILED = auto()
    SKIPPED = auto()
    TIMEOUT = auto()


class Il2CppDumperStatus(Enum):
    """Granular status for Il2CppDumper execution.

    These are machine-readable states that let downstream consumers
    distinguish clean runs from degraded ones without parsing log text.
    """

    CLEAN_SUCCESS = "CLEAN_SUCCESS"
    PARTIAL_SUCCESS_SCRIPT_JSON = "PARTIAL_SUCCESS_SCRIPT_JSON"
    HARD_FAILURE_NO_SCRIPT_JSON = "HARD_FAILURE_NO_SCRIPT_JSON"
    SKIPPED = "SKIPPED"
    TIMEOUT = "TIMEOUT"
    EXCEPTION = "EXCEPTION"


@dataclass
class Il2CppDumperRunResult:
    """Structured result from an Il2CppDumper run (GUI path)."""

    status: Il2CppDumperStatus = Il2CppDumperStatus.SKIPPED
    dump_dir: Path | None = None
    return_code: int = -1
    stdout: str = ""
    stderr: str = ""
    error_message: str = ""
    dll_count: int = 0
    has_script_json: bool = False
    has_readkey_crash: bool = False
    has_protected_warnings: bool = False

    @property
    def success(self) -> bool:
        return self.status == Il2CppDumperStatus.CLEAN_SUCCESS

    @property
    def usable(self) -> bool:
        """True if script.json exists (even if degraded)."""
        return self.status in (
            Il2CppDumperStatus.CLEAN_SUCCESS,
            Il2CppDumperStatus.PARTIAL_SUCCESS_SCRIPT_JSON,
        )

    def fidelity_warning(self) -> str | None:
        """Return a human-readable fidelity warning, or None if clean."""
        if self.status == Il2CppDumperStatus.PARTIAL_SUCCESS_SCRIPT_JSON:
            parts = ["Il2CppDumper: partial success — script.json recovered"]
            if self.has_readkey_crash:
                parts.append("ReadKey crash detected (stdin prompt issue)")
            if self.has_protected_warnings:
                parts.append("protected-file warnings in output")
            parts.append(
                "Downstream scene fidelity may be reduced; "
                "MonoBehaviour class names may be incomplete."
            )
            return "; ".join(parts)
        if self.status == Il2CppDumperStatus.HARD_FAILURE_NO_SCRIPT_JSON:
            return (
                "Il2CppDumper: hard failure — no script.json produced. "
                "MonoBehaviours will fall back to raw bytes. "
                "Scene reconstruction fidelity is significantly reduced."
            )
        return None

    def log_status(self, log_fn) -> None:
        """Emit a structured log line describing the run result."""
        tag = self.status.value
        if self.dump_dir:
            log_fn(f"[IL2CPPDUMPER_STATUS] {tag} dlls={self.dll_count} "
                   f"script_json={self.has_script_json} "
                   f"return_code={self.return_code}")
        else:
            log_fn(f"[IL2CPPDUMPER_STATUS] {tag}")
        warn = self.fidelity_warning()
        if warn:
            log_fn(f"[WARN ] {warn}")


@dataclass
class ToolResult:
    """Result of a single tool execution."""

    tool_name: str
    status: ToolStatus = ToolStatus.PENDING
    stdout: str = ""
    stderr: str = ""
    return_code: int = -1
    execution_time_ms: float = 0.0
    output_path: str = ""
    error_message: str = ""

    @property
    def success(self) -> bool:
        return self.status == ToolStatus.SUCCESS


@dataclass
class PipelineResult:
    """Aggregated result from the full recovery pipeline."""

    tool_results: list[ToolResult] = field(default_factory=list)
    total_time_ms: float = 0.0
    classes_recovered: int = 0
    methods_recovered: int = 0
    fields_recovered: int = 0
    strings_recovered: int = 0
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def any_success(self) -> bool:
        return any(r.success for r in self.tool_results)

    @property
    def all_failed(self) -> bool:
        return all(not r.success for r in self.tool_results) if self.tool_results else True

    def successful_tools(self) -> list[ToolResult]:
        return [r for r in self.tool_results if r.success]

    def failed_tools(self) -> list[ToolResult]:
        return [r for r in self.tool_results if not r.success]


# ── Recovered data structures ───────────────────────────────────────


@dataclass
class RecoveredParameter:
    """A recovered method parameter."""

    name: str
    type_name: str = ""
    position: int = 0
    default_value: str = ""


@dataclass
class RecoveredField:
    """A recovered class field."""

    name: str
    type_name: str = ""
    offset: int = 0
    is_static: bool = False
    is_literal: bool = False
    default_value: str = ""
    declaring_class: str = ""
    token: int = 0
    confidence: float = 0.0


@dataclass
class RecoveredProperty:
    """A recovered property."""

    name: str
    type_name: str = ""
    getter_address: int = 0
    setter_address: int = 0
    declaring_class: str = ""


@dataclass
class RecoveredMethod:
    """A recovered method."""

    name: str
    return_type: str = ""
    parameters: list[RecoveredParameter] = field(default_factory=list)
    native_address: int = 0
    function_size: int = 0
    token: int = 0
    declaring_class: str = ""
    is_static: bool = False
    is_abstract: bool = False
    is_generic: bool = False
    slot_index: int = -1
    caller_count: int = 0
    callee_count: int = 0
    confidence: float = 0.0


@dataclass
class RecoveredEnum:
    """A recovered enum type."""

    name: str
    namespace: str = ""
    values: dict[str, int] = field(default_factory=dict)
    declaring_class: str = ""


@dataclass
class RecoveredClass:
    """A recovered class / struct / interface."""

    name: str
    namespace: str = ""
    full_name: str = ""
    parent_class: str = ""
    implements: list[str] = field(default_factory=list)
    fields: list[RecoveredField] = field(default_factory=list)
    methods: list[RecoveredMethod] = field(default_factory=list)
    properties: list[RecoveredProperty] = field(default_factory=list)
    nested_classes: list[str] = field(default_factory=list)
    generic_parameters: list[str] = field(default_factory=list)
    is_interface: bool = False
    is_enum: bool = False
    is_abstract: bool = False
    is_sealed: bool = False
    is_struct: bool = False
    token: int = 0
    image_index: int = 0
    confidence: float = 0.0
    source_tool: str = ""


# ── Scene export confidence ────────────────────────────────────────


class SceneConfidenceLevel(Enum):
    """Simple confidence categories for scene exports."""

    HIGH = "HIGH"
    MEDIUM = "MEDIUM"
    LOW = "LOW"


@dataclass
class SceneConfidence:
    """Per-scene confidence label with explanation.

    Produced by ``compute_scene_confidence()`` and written into
    each ``PROMPT_COMPANION.md`` and ``scenes_manifest.json``.
    """

    level: SceneConfidenceLevel = SceneConfidenceLevel.HIGH
    reasons: list[str] = field(default_factory=list)

    # -- signal counters (for manifest consumers) --
    dumper_status: str = ""
    assets_copied: int = 0
    assets_total: int = 0
    unresolved_assets: int = 0
    dynamic_text_injected: bool = False
    dynamic_text_skipped: bool = False
    dynamic_text_disabled: bool = False

    def to_dict(self) -> dict:
        return {
            "level": self.level.value,
            "reasons": list(self.reasons),
            "dumper_status": self.dumper_status,
            "assets_copied": self.assets_copied,
            "assets_total": self.assets_total,
            "unresolved_assets": self.unresolved_assets,
            "dynamic_text_injected": self.dynamic_text_injected,
            "dynamic_text_skipped": self.dynamic_text_skipped,
            "dynamic_text_disabled": self.dynamic_text_disabled,
        }

    def format_markdown_section(self) -> str:
        """Return a markdown block for inclusion in PROMPT_COMPANION.md."""
        lines = [
            "## Data Quality / Confidence",
            "",
            f"- **Confidence Level**: `{self.level.value}`",
            "",
        ]
        if self.reasons:
            lines.append("**Why this confidence was assigned:**")
            lines.append("")
            for r in self.reasons:
                lines.append(f"- {r}")
            lines.append("")
        lines.append(
            "This section tells you how trustworthy the data in this export is. "
            "HIGH means most data came from direct extraction with no fallbacks. "
            "MEDIUM means some fallbacks were used but data is still usable. "
            "LOW means significant data gaps or fallbacks were used."
        )
        return "\n".join(lines)


def compute_scene_confidence(
    *,
    dumper_status: str = "SKIPPED",
    dumper_usable: bool = False,
    assets_copied: int = 0,
    assets_total: int = 0,
    unresolved_assets: int = 0,
    dynamic_text_injected: bool = False,
    dynamic_text_skipped: bool = False,
    dynamic_text_disabled: bool = False,
    has_text_components: bool = False,
    feature_flags: dict | None = None,
) -> SceneConfidence:
    """Compute the confidence level for a scene export.

    Scoring:
        - Starts at HIGH
        - Deducts for each negative signal
        - Finishes at MEDIUM if 1-2 deduction signals
        - Finishes at LOW if 3+ deduction signals
    """
    reasons: list[str] = []
    deductions = 0

    # -- Il2CppDumper status --
    if dumper_status in ("CLEAN_SUCCESS",):
        reasons.append("Il2CppDumper: clean success -- full type metadata available")
    elif dumper_status in ("PARTIAL_SUCCESS_SCRIPT_JSON",):
        reasons.append("Il2CppDumper: partial success -- script.json recovered but some class names may be incomplete")
        deductions += 1
    elif dumper_status in ("HARD_FAILURE_NO_SCRIPT_JSON",):
        reasons.append("Il2CppDumper: hard failure -- MonoBehaviours fall back to raw bytes")
        deductions += 2
    else:
        reasons.append(f"Il2CppDumper: {dumper_status} -- type metadata not available")
        deductions += 1

    # -- Asset binding --
    if assets_total > 0:
        resolved = assets_copied
        ratio = resolved / assets_total if assets_total else 0
        if unresolved_assets > 0:
            reasons.append(
                f"Asset binding: {resolved}/{assets_total} resolved, "
                f"{unresolved_assets} unresolved -- some images will be missing"
            )
            if ratio < 0.5:
                deductions += 2
            else:
                deductions += 1
        else:
            reasons.append(f"Asset binding: {resolved}/{assets_total} resolved -- all images available")
    else:
        reasons.append("Asset binding: no image/texture assets referenced in scene")

    # -- Dynamic text --
    if dynamic_text_disabled:
        reasons.append("Dynamic text recovery: disabled via feature flag")
    elif dynamic_text_injected:
        reasons.append("Dynamic text recovery: injected IL2CPP-recovered strings into text-less scene")
    elif dynamic_text_skipped:
        if has_text_components:
            reasons.append("Dynamic text recovery: skipped (scene already has text components from UI dump)")
        else:
            reasons.append("Dynamic text recovery: skipped (no confident class-name match)")
            # Not a deduction -- this is the system correctly refusing
            # to inject untrusted data when no confident match exists.
    else:
        reasons.append("Dynamic text recovery: not applicable")

    # -- Feature flags --
    if feature_flags:
        off_flags = [k for k, v in feature_flags.items() if v is False]
        if off_flags:
            reasons.append(f"Feature flags disabled: {', '.join(off_flags)}")

    # -- Determine level --
    if deductions == 0:
        level = SceneConfidenceLevel.HIGH
    elif deductions <= 2:
        level = SceneConfidenceLevel.MEDIUM
    else:
        level = SceneConfidenceLevel.LOW

    return SceneConfidence(
        level=level,
        reasons=reasons,
        dumper_status=dumper_status,
        assets_copied=assets_copied,
        assets_total=assets_total,
        unresolved_assets=unresolved_assets,
        dynamic_text_injected=dynamic_text_injected,
        dynamic_text_skipped=dynamic_text_skipped,
        dynamic_text_disabled=dynamic_text_disabled,
    )
