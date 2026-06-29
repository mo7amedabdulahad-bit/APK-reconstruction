"""Data models for the recovery pipeline."""
from __future__ import annotations

import sqlite3
from dataclasses import dataclass, field
from enum import Enum, auto
from typing import Optional


class ToolStatus(Enum):
    """Execution status of a recovery tool."""

    PENDING = auto()
    RUNNING = auto()
    SUCCESS = auto()
    FAILED = auto()
    SKIPPED = auto()
    TIMEOUT = auto()


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
