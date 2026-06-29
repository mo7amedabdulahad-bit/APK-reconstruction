"""Recovery pipeline orchestrator.

Runs Cpp2IL → Il2CppDumper → Il2CppInspector in sequence.
If one tool fails, the pipeline continues with the next tool.
All outputs are collected, merged and stored in a unified database.
"""
from __future__ import annotations

import json
import os
import shutil
import subprocess
import tempfile
import time
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.apk.models import APKInfo
from il2cpp_recovery_studio.core.config import AppConfig
from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.recovery.database import RecoveryDatabase
from il2cpp_recovery_studio.recovery.models import (
    PipelineResult,
    RecoveredClass,
    ToolResult,
    ToolStatus,
)
from il2cpp_recovery_studio.recovery.parsers import (
    Cpp2ILParser,
    Il2CppDumperParser,
    Il2CppInspectorParser,
)
from il2cpp_recovery_studio.recovery.tool_registry import ToolRegistry

logger = get_logger("recovery.orchestrator")


class RecoveryOrchestrator:
    """Orchestrate the full recovery pipeline.

    Usage::

        orch = RecoveryOrchestrator(config=AppConfig())
        result = orch.run(apk_info)
        print(f"Recovered {result.classes_recovered} classes")
    """

    def __init__(self, config: Optional[AppConfig] = None) -> None:
        self._config = config or AppConfig()
        self._registry = ToolRegistry(self._config)
        self._output_base = Path(tempfile.mkdtemp(prefix="il2cpp_recovery_"))

    def run(self, apk_info: APKInfo, output_dir: Optional[Path] = None) -> PipelineResult:
        """Execute the full recovery pipeline.

        Parameters
        ----------
        apk_info:
            Parsed APK information from Phase 1.
        output_dir:
            Where to write pipeline outputs. Defaults to a temp directory.
        """
        start_time = time.monotonic()
        result = PipelineResult()

        if output_dir is None:
            output_dir = self._output_base
        output_dir.mkdir(parents=True, exist_ok=True)

        logger.info("Starting recovery pipeline → %s", output_dir)

        # ── 1. Discover tools ────────────────────────────────────────
        tools = self._registry.discover()
        available = self._registry.available_tools()
        unavailable = self._registry.unavailable_tools()

        logger.info(
            "Tools: %d available, %d unavailable",
            len(available),
            len(unavailable),
        )
        for t in unavailable:
            result.warnings.append(f"Tool not found: {t.display_name} ({t.error})")

        # ── 2. Run pipeline ──────────────────────────────────────────
        all_classes: list[RecoveredClass] = []

        # Cpp2IL
        cpp2il_result = self._run_cpp2il(apk_info, output_dir / "cpp2il")
        result.tool_results.append(cpp2il_result)
        if cpp2il_result.success:
            parser = Cpp2ILParser()
            classes = parser.parse(output_dir / "cpp2il")
            all_classes.extend(classes)
            result.classes_recovered += len(classes)

        # Il2CppDumper
        dumper_result = self._run_il2cpp_dumper(apk_info, output_dir / "il2cpp_dumper")
        result.tool_results.append(dumper_result)
        if dumper_result.success:
            parser = Il2CppDumperParser()
            classes = parser.parse(output_dir / "il2cpp_dumper")
            all_classes.extend(classes)
            result.classes_recovered += len(classes)

        # Il2CppInspector
        inspector_result = self._run_il2cpp_inspector(apk_info, output_dir / "il2cpp_inspector")
        result.tool_results.append(inspector_result)
        if inspector_result.success:
            parser = Il2CppInspectorParser()
            classes = parser.parse(output_dir / "il2cpp_inspector")
            all_classes.extend(classes)
            result.classes_recovered += len(classes)

        # ── 3. Merge results ─────────────────────────────────────────
        merged = self._merge_classes(all_classes)
        result.classes_recovered = len(merged)
        result.methods_recovered = sum(len(c.methods) for c in merged)
        result.fields_recovered = sum(len(c.fields) for c in merged)

        # ── 4. Store in database ─────────────────────────────────────
        db_path = output_dir / "recovery.db"
        db = RecoveryDatabase(db_path)
        db.store_classes(merged)
        db.close()

        result.total_time_ms = (time.monotonic() - start_time) * 1000
        logger.info(
            "Pipeline complete: %d classes, %d methods, %d fields in %.1fms",
            result.classes_recovered,
            result.methods_recovered,
            result.fields_recovered,
            result.total_time_ms,
        )
        return result

    # ── Tool runners ─────────────────────────────────────────────────

    def _run_cpp2il(self, apk_info: APKInfo, output_dir: Path) -> ToolResult:
        """Run Cpp2IL if available."""
        tool = self._registry.get_tool("cpp2il")
        if not tool or not tool.available:
            return ToolResult(
                tool_name="Cpp2IL",
                status=ToolStatus.SKIPPED,
                error_message="Tool not available",
            )

        output_dir.mkdir(parents=True, exist_ok=True)
        cmd = self._build_cpp2il_cmd(apk_info, output_dir)
        return self._execute_tool("Cpp2IL", cmd, output_dir)

    def _run_il2cpp_dumper(self, apk_info: APKInfo, output_dir: Path) -> ToolResult:
        """Run Il2CppDumper if available."""
        tool = self._registry.get_tool("il2cpp_dumper")
        if not tool or not tool.available:
            return ToolResult(
                tool_name="Il2CppDumper",
                status=ToolStatus.SKIPPED,
                error_message="Tool not available",
            )

        output_dir.mkdir(parents=True, exist_ok=True)
        cmd = self._build_dumper_cmd(apk_info, output_dir)
        return self._execute_tool("Il2CppDumper", cmd, output_dir)

    def _run_il2cpp_inspector(self, apk_info: APKInfo, output_dir: Path) -> ToolResult:
        """Run Il2CppInspector if available."""
        tool = self._registry.get_tool("il2cpp_inspector")
        if not tool or not tool.available:
            return ToolResult(
                tool_name="Il2CppInspector",
                status=ToolStatus.SKIPPED,
                error_message="Tool not available",
            )

        output_dir.mkdir(parents=True, exist_ok=True)
        cmd = self._build_inspector_cmd(apk_info, output_dir)
        return self._execute_tool("Il2CppInspector", cmd, output_dir)

    # ── Command builders ─────────────────────────────────────────────

    @staticmethod
    def _build_cpp2il_cmd(apk_info: APKInfo, output_dir: Path) -> list[str]:
        tool = ToolRegistry().get_tool("cpp2il") or type("", (), {"path": "Cpp2IL"})()
        cmd = [
            tool.path,
            "--apk", str(apk_info.file_path),
            "--output", str(output_dir),
            "--analyze",
        ]
        return cmd

    @staticmethod
    def _build_dumper_cmd(apk_info: APKInfo, output_dir: Path) -> list[str]:
        tool = ToolRegistry().get_tool("il2cpp_dumper") or type("", (), {"path": "Il2CppDumper"})()
        # Il2CppDumper typically needs libil2cpp.so and global-metadata.dat extracted
        # Find paths from APK info
        lib_path = ""
        md_path = ""
        for lib in apk_info.native_libraries:
            if lib.is_il2cpp:
                lib_path = lib.path
                break
        if apk_info.unity_build.has_global_metadata:
            md_path = apk_info.unity_build.global_metadata_path

        cmd = [tool.path]
        if lib_path:
            cmd.extend(["--lib", lib_path])
        if md_path:
            cmd.extend(["--metadata", md_path])
        cmd.extend(["--output", str(output_dir)])
        return cmd

    @staticmethod
    def _build_inspector_cmd(apk_info: APKInfo, output_dir: Path) -> list[str]:
        tool = ToolRegistry().get_tool("il2cpp_inspector") or type("", (), {"path": "Il2CppInspector"})()
        cmd = [
            tool.path,
            "--apk", str(apk_info.file_path),
            "--output", str(output_dir),
        ]
        return cmd

    # ── Executor ─────────────────────────────────────────────────────

    def _execute_tool(
        self,
        name: str,
        cmd: list[str],
        output_dir: Path,
        timeout_seconds: int = 3600,
    ) -> ToolResult:
        """Execute a tool as a subprocess and capture its output."""
        result = ToolResult(tool_name=name, status=ToolStatus.RUNNING)
        start = time.monotonic()

        try:
            logger.info("Executing %s: %s", name, " ".join(cmd))
            proc = subprocess.run(
                cmd,
                capture_output=True,
                text=True,
                timeout=timeout_seconds,
                cwd=str(output_dir),
                creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
            )
            result.stdout = proc.stdout
            result.stderr = proc.stderr
            result.return_code = proc.returncode
            result.status = ToolStatus.SUCCESS if proc.returncode == 0 else ToolStatus.FAILED

            if proc.returncode != 0:
                result.error_message = f"Exit code {proc.returncode}: {proc.stderr[:500]}"
                logger.warning("%s failed with code %d", name, proc.returncode)
            else:
                logger.info("%s completed successfully", name)

        except subprocess.TimeoutExpired:
            result.status = ToolStatus.TIMEOUT
            result.error_message = f"Timed out after {timeout_seconds}s"
            logger.warning("%s timed out after %ds", name, timeout_seconds)
        except FileNotFoundError as exc:
            result.status = ToolStatus.FAILED
            result.error_message = f"Executable not found: {exc}"
            logger.error("%s executable not found: %s", name, exc)
        except OSError as exc:
            result.status = ToolStatus.FAILED
            result.error_message = f"OS error: {exc}"
            logger.error("%s OS error: %s", name, exc)

        result.execution_time_ms = (time.monotonic() - start) * 1000
        return result

    # ── Merge ────────────────────────────────────────────────────────

    @staticmethod
    def _merge_classes(all_classes: list[RecoveredClass]) -> list[RecoveredClass]:
        """Merge classes from multiple tools, preferring higher confidence."""
        merged: dict[str, RecoveredClass] = {}

        # Sort by confidence descending so higher-confidence entries overwrite
        sorted_classes = sorted(all_classes, key=lambda c: c.confidence, reverse=True)

        for cls in sorted_classes:
            key = cls.full_name or cls.name
            if key not in merged:
                merged[key] = cls
            else:
                existing = merged[key]
                # Merge methods from lower-confidence sources if not already present
                existing_methods = {(m.name, m.declaring_class) for m in existing.methods}
                for method in cls.methods:
                    mk = (method.name, method.declaring_class)
                    if mk not in existing_methods:
                        existing.methods.append(method)
                        existing_methods.add(mk)

                # Merge fields
                existing_fields = {(f.name, f.declaring_class) for f in existing.fields}
                for field in cls.fields:
                    fk = (field.name, field.declaring_class)
                    if fk not in existing_fields:
                        existing.fields.append(field)
                        existing_fields.add(fk)

                # Update parent class if missing
                if not existing.parent_class and cls.parent_class:
                    existing.parent_class = cls.parent_class

                # Track source tools
                if cls.source_tool and cls.source_tool not in existing.source_tool:
                    existing.source_tool = f"{existing.source_tool},{cls.source_tool}"

        return list(merged.values())
