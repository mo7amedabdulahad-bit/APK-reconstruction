"""Ghidra integration engine: discovers Ghidra, runs headless analysis, merges results with metadata."""
from __future__ import annotations

import json
import os
import shutil
import subprocess
import tempfile
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.core.exceptions import ToolExecutionError
from il2cpp_recovery_studio.ghidra.models import (
    AnalysisType,
    GhidraDecompilation,
    GhidraFunction,
    GhidraResult,
    GhidraStatus,
)

logger = get_logger("ghidra.engine")

DEFAULT_SEARCH_PATHS = [
    r"C:\Program Files\Ghidra",
    r"C:\Program Files\ghidra",
    os.path.expanduser("~/ghidra"),
    "/opt/ghidra",
    "/usr/local/ghidra",
    os.path.expanduser("~/ghidra_*"),
]


class GhidraEngine:
    """Manages Ghidra headless analysis."""

    def __init__(self, ghidra_home: str | None = None) -> None:
        self.ghidra_home = ghidra_home or self._discover_ghidra()
        self.ghidra_run = self._find_ghidra_run()

    def _discover_ghidra(self) -> str | None:
        if self.ghidra_home and os.path.isdir(self.ghidra_home):
            return self.ghidra_home
        for path in DEFAULT_SEARCH_PATHS:
            expanded = os.path.expanduser(path)
            for p in Path(expanded).parent.glob("*ghidra*") if "*" in expanded else [Path(expanded)]:
                if p.is_dir() and (p / "support" / "analyzeHeadless").exists():
                    return str(p)
        return None

    def _find_ghidra_run(self) -> str | None:
        if not self.ghidra_home:
            return None
        candidate = Path(self.ghidra_home) / "support" / "analyzeHeadless"
        return str(candidate) if candidate.exists() else None

    @property
    def available(self) -> bool:
        return self.ghidra_run is not None

    def analyze(
        self,
        binary_path: str,
        analysis_type: AnalysisType = AnalysisType.FULL,
        timeout_sec: int = 300,
    ) -> GhidraResult:
        result = GhidraResult()

        if not self.available:
            result.status = GhidraStatus.NOT_FOUND
            result.warnings.append("Ghidra not found on system")
            logger.warning("Ghidra not found")
            return result

        if not os.path.isfile(binary_path):
            result.status = GhidraStatus.FAILED
            result.errors.append(f"Binary not found: {binary_path}")
            return result

        with tempfile.TemporaryDirectory() as tmpdir:
            script_path = self._write_analysis_script(tmpdir)
            cmd = [
                self.ghidra_run,
                binary_path,
                os.path.join(tmpdir, "project"),
                "-import",
                binary_path,
                "-postScript",
                script_path,
                "-scriptPath",
                tmpdir,
                "-deleteProject",
            ]

            result.status = GhidraStatus.RUNNING
            logger.info("Running Ghidra: %s", " ".join(cmd))

            try:
                proc = subprocess.run(
                    cmd,
                    capture_output=True,
                    text=True,
                    timeout=timeout_sec,
                )
                if proc.returncode == 0:
                    result.status = GhidraStatus.SUCCESS
                    result = self._parse_results(tmpdir, result)
                else:
                    result.status = GhidraStatus.FAILED
                    result.errors.append(proc.stderr[:500])
            except subprocess.TimeoutExpired:
                result.status = GhidraStatus.TIMEOUT
                result.errors.append(f"Ghidra timed out after {timeout_sec}s")
            except FileNotFoundError:
                result.status = GhidraStatus.FAILED
                result.errors.append("Ghidra executable not found")
            except Exception as e:
                result.status = GhidraStatus.FAILED
                result.errors.append(str(e))

        result.compute_statistics()
        logger.info(
            "Ghidra result: status=%s, functions=%d, decompilations=%d",
            result.status.name,
            result.total_functions,
            result.total_decompilations,
        )
        return result

    def _write_analysis_script(self, tmpdir: str) -> str:
        script = """\
from ghidra.app.decompiler import DecompInterface
from ghidra.util.task import ConsoleTaskMonitor
import json

monitor = ConsoleTaskMonitor()
decomp = DecompInterface()
decomp.openProgram(currentProgram)

fm = currentProgram.getFunctionManager()
functions = []
for func in fm.getFunctions(True):
    entry = func.getEntryPoint().getOffset()
    functions.append({
        "name": func.getName(),
        "address": entry,
        "size": func.getBody().getNumAddresses(),
        "calling_convention": str(func.getCallingConventionName()),
        "is_thunk": func.isThunk(),
        "parameter_count": func.getParameterCount(),
    })

result_path = getScriptArgs()[0] if getScriptArgs() else "ghidra_results.json"
with open(result_path, "w") as f:
    json.dump({"functions": functions}, f, indent=2)

decomp.dispose()
"""
        path = os.path.join(tmpdir, "analyze.py")
        with open(path, "w") as f:
            f.write(script)
        return path

    def _parse_results(self, tmpdir: str, result: GhidraResult) -> GhidraResult:
        results_file = os.path.join(tmpdir, "ghidra_results.json")
        if os.path.isfile(results_file):
            try:
                with open(results_file) as f:
                    data = json.load(f)
                for fd in data.get("functions", []):
                    result.functions.append(GhidraFunction(
                        name=fd.get("name", ""),
                        address=fd.get("address", 0),
                        size=fd.get("size", 0),
                        calling_convention=fd.get("calling_convention", ""),
                        is_thunk=fd.get("is_thunk", False),
                        parameter_count=fd.get("parameter_count", 0),
                    ))
            except (json.JSONDecodeError, IOError) as e:
                result.warnings.append(f"Failed to parse Ghidra results: {e}")
        return result

    def merge_with_metadata(
        self,
        ghidra_result: GhidraResult,
        metadata_classes: list,
    ) -> dict[int, str]:
        mapping: dict[int, str] = {}
        for func in ghidra_result.functions:
            for mc in metadata_classes:
                if hasattr(mc, "name") and mc.name in func.name:
                    mapping[func.address] = mc.name
                    func.metadata_token = getattr(mc, "token", 0)
                    break
        logger.info("Merged %d Ghidra functions with metadata", len(mapping))
        return mapping
