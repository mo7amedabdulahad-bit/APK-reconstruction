"""Tool discovery, validation and lifecycle management."""
from __future__ import annotations

import os
import shutil
import subprocess
from dataclasses import dataclass, field
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.core.config import AppConfig
from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("recovery.tool_registry")


@dataclass
class ToolInfo:
    """Metadata about an available recovery tool."""

    name: str
    display_name: str
    executable: str
    version_arg: str = "--version"
    version_output_pattern: str = ""
    available: bool = False
    version: str = ""
    path: str = ""
    error: str = ""


class ToolRegistry:
    """Discovers and validates external recovery tools.

    Supported tools:
    - Cpp2IL
    - Il2CppDumper
    - Il2CppInspector
    - Ghidra Headless (analyzeHeadless)
    """

    TOOL_DEFINITIONS: list[dict[str, str]] = [
        {
            "name": "cpp2il",
            "display_name": "Cpp2IL",
            "executable": "Cpp2IL",
            "version_arg": "--version",
        },
        {
            "name": "il2cpp_dumper",
            "display_name": "Il2CppDumper",
            "executable": "Il2CppDumper",
            "version_arg": "",
        },
        {
            "name": "il2cpp_inspector",
            "display_name": "Il2CppInspector",
            "executable": "Il2CppInspector",
            "version_arg": "--version",
        },
        {
            "name": "ghidra",
            "display_name": "Ghidra Headless",
            "executable": "analyzeHeadless",
            "version_arg": "--version",
        },
    ]

    def __init__(self, config: Optional[AppConfig] = None) -> None:
        self._config = config or AppConfig()
        self._tools: dict[str, ToolInfo] = {}

    def discover(self) -> dict[str, ToolInfo]:
        """Scan PATH and configured locations for all known tools."""
        self._tools.clear()
        for defn in self.TOOL_DEFINITIONS:
            info = self._probe_tool(defn)
            self._tools[info.name] = info
            status = "AVAILABLE" if info.available else "NOT FOUND"
            logger.info("Tool %s: %s (%s)", info.display_name, status, info.path or info.error)
        return dict(self._tools)

    def get_tool(self, name: str) -> Optional[ToolInfo]:
        """Return tool info by name, or None."""
        return self._tools.get(name.lower())

    def available_tools(self) -> list[ToolInfo]:
        """Return only tools that are available."""
        return [t for t in self._tools.values() if t.available]

    def unavailable_tools(self) -> list[ToolInfo]:
        """Return only tools that are NOT available."""
        return [t for t in self._tools.values() if not t.available]

    def validate_tools(self) -> dict[str, bool]:
        """Return a dict of tool_name -> is_available."""
        if not self._tools:
            self.discover()
        return {name: info.available for name, info in self._tools.items()}

    # ── Internal ─────────────────────────────────────────────────────

    def _probe_tool(self, defn: dict[str, str]) -> ToolInfo:
        """Try to locate and validate a single tool."""
        info = ToolInfo(
            name=defn["name"],
            display_name=defn["display_name"],
            executable=defn["executable"],
            version_arg=defn.get("version_arg", ""),
        )

        # Check configured paths first
        configured_path = self._get_configured_path(defn["name"])
        if configured_path:
            candidate = Path(configured_path)
            if candidate.is_file():
                info.path = str(candidate)
                info.available = True
                info.version = self._get_version(info)
                return info
            # Try as directory containing the executable
            if candidate.is_dir():
                for ext in ("", ".exe", ".cmd", ".bat"):
                    exe = candidate / (defn["executable"] + ext)
                    if exe.is_file():
                        info.path = str(exe)
                        info.available = True
                        info.version = self._get_version(info)
                        return info

        # Search PATH
        found = shutil.which(defn["executable"])
        if found:
            info.path = found
            info.available = True
            info.version = self._get_version(info)
            return info

        info.error = f"'{defn['executable']}' not found in PATH or configured paths"
        return info

    def _get_configured_path(self, tool_name: str) -> str:
        """Map tool name to configured path from AppConfig."""
        tp = self._config.tool_paths
        mapping = {
            "cpp2il": tp.cpp2il,
            "il2cpp_dumper": tp.il2cpp_dumper,
            "il2cpp_inspector": tp.il2cpp_inspector,
            "ghidra": tp.ghidra_headless,
        }
        return mapping.get(tool_name, "")

    def _get_version(self, info: ToolInfo) -> str:
        """Attempt to query the tool's version."""
        if not info.version_arg or not info.path:
            return ""
        try:
            result = subprocess.run(
                [info.path, info.version_arg],
                capture_output=True,
                text=True,
                timeout=10,
                creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
            )
            output = (result.stdout + result.stderr).strip()
            # Take first non-empty line
            for line in output.splitlines():
                if line.strip():
                    return line.strip()[:120]
            return output[:120] if output else ""
        except (subprocess.TimeoutExpired, FileNotFoundError, OSError) as exc:
            logger.debug("Version query failed for %s: %s", info.name, exc)
            return ""
