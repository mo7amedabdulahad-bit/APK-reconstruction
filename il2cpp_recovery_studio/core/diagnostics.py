"""Startup diagnostics: structured dependency reporting.

Runs before the pipeline and reports each dependency as REQUIRED,
OPTIONAL, DEGRADED, or INFO with a one-line impact explanation so
the user knows exactly what is available, what is missing, and what
that means for output quality.
"""
from __future__ import annotations

import os
import shutil
import subprocess
import sys
from dataclasses import dataclass, field
from enum import Enum, auto
from pathlib import Path
from typing import Callable


class DependencyLevel(Enum):
    """Severity / classification of a dependency check."""

    REQUIRED  = auto()   # App cannot function without this
    OPTIONAL  = auto()   # Feature unavailable if missing, but app works
    DEGRADED  = auto()   # Present but in a degraded state
    INFO      = auto()   # Informational - no action needed


@dataclass
class DependencyStatus:
    """Result of a single dependency check."""

    name: str
    level: DependencyLevel
    available: bool
    impact: str
    detail: str = ""

    @property
    def icon(self) -> str:
        if self.level == DependencyLevel.REQUIRED:
            return "[X]" if not self.available else "[OK]"
        if self.level == DependencyLevel.OPTIONAL:
            return "[--]" if not self.available else "[OK]"
        if self.level == DependencyLevel.DEGRADED:
            return "[!!]"
        return "[i]"

    @property
    def level_tag(self) -> str:
        return self.level.name

    def format_line(self) -> str:
        status = "available" if self.available else "NOT available"
        parts = [
            f"  {self.icon} {self.level_tag:<9} {self.name:<28} {status}",
        ]
        if self.impact:
            parts.append(f"    \\- {self.impact}")
        if self.detail and not self.available:
            parts.append(f"    \\- {self.detail}")
        return "\n".join(parts)


def _can_import(module_name: str) -> bool:
    try:
        __import__(module_name)
        return True
    except ImportError:
        return False


def _find_java() -> str | None:
    """Quick Java discovery (subset of app.py logic)."""
    j = shutil.which("java")
    if j:
        return j
    java_home = os.environ.get("JAVA_HOME")
    if java_home:
        cand = Path(java_home) / "bin" / ("java.exe" if sys.platform == "win32" else "java")
        if cand.exists():
            return str(cand)
    return None


def _find_node() -> str | None:
    """Quick Node.js discovery."""
    for candidate in ("node", "node.exe", "nodejs"):
        path = shutil.which(candidate)
        if path:
            return path
    return None


def _find_il2cppdumper() -> str | None:
    """Quick Il2CppDumper discovery (local tools dir only)."""
    tools_dir = Path(__file__).resolve().parent.parent / "gui" / "tools"
    # Local v39 version
    local_v39 = tools_dir.parent / "tools" / "Il2CppDumper-win-x64-net8-v39" / "Il2CppDumper.exe"
    if local_v39.is_file():
        return str(local_v39)
    # Auto-downloaded version
    il2cpp_dir = tools_dir / "il2cppdumper"
    if il2cpp_dir.exists():
        candidates = list(il2cpp_dir.rglob("Il2CppDumper.exe"))
        if candidates:
            return str(candidates[0])
    return None


def _has_catalog(raw_dir: Path | None) -> bool:
    """Check if an addressables catalog.bin exists under raw_dir."""
    if raw_dir is None or not raw_dir.exists():
        return False
    for p in raw_dir.rglob("catalog.bin"):
        return True
    return False


@dataclass
class StartupDiagnostics:
    """Runs all startup dependency checks and produces a summary.

    Usage::

        diag = StartupDiagnostics()
        diag.run()
        for line in diag.format_summary():
            print(line)
    """

    raw_dir: Path | None = None
    log_fn: Callable[[str], None] | None = None

    _results: list[DependencyStatus] = field(default_factory=list, init=False)

    @property
    def results(self) -> list[DependencyStatus]:
        return list(self._results)

    @property
    def has_blocking(self) -> bool:
        return any(
            r.level == DependencyLevel.REQUIRED and not r.available
            for r in self._results
        )

    @property
    def has_degraded(self) -> bool:
        return any(
            r.level in (DependencyLevel.OPTIONAL, DependencyLevel.DEGRADED)
            and not r.available
            for r in self._results
        )

    def run(self) -> None:
        """Execute all dependency checks."""
        self._results.clear()
        self._check_unitypy()
        self._check_pillow()
        self._check_customtkinter()
        self._check_requests()
        self._check_addressablestools()
        self._check_typetree_generator()
        self._check_java()
        self._check_node()
        self._check_il2cppdumper()
        self._check_catalog()
        self._check_feature_flags()

    def format_summary(self) -> list[str]:
        """Return formatted lines for display in the log box."""
        lines: list[str] = []
        lines.append("")
        lines.append("=" * 72)
        lines.append("  STARTUP DIAGNOSTICS")
        lines.append("=" * 72)

        # Group by level
        required = [r for r in self._results if r.level == DependencyLevel.REQUIRED]
        optional = [r for r in self._results if r.level == DependencyLevel.OPTIONAL]
        degraded = [r for r in self._results if r.level == DependencyLevel.DEGRADED]
        info     = [r for r in self._results if r.level == DependencyLevel.INFO]

        if required:
            lines.append("")
            lines.append("  REQUIRED -- app cannot function without these")
            lines.append("  " + "-" * 68)
            for r in required:
                lines.append(r.format_line())

        if optional:
            lines.append("")
            lines.append("  OPTIONAL -- features unavailable if missing")
            lines.append("  " + "-" * 68)
            for r in optional:
                lines.append(r.format_line())

        if degraded:
            lines.append("")
            lines.append("  DEGRADED -- present but reduced quality")
            lines.append("  " + "-" * 68)
            for r in degraded:
                lines.append(r.format_line())

        if info:
            lines.append("")
            lines.append("  INFO")
            lines.append("  " + "-" * 68)
            for r in info:
                lines.append(r.format_line())

        lines.append("")
        lines.append("=" * 72)
        return lines

    def emit(self, log_fn: Callable[[str], None] | None = None) -> None:
        """Write formatted summary to a log function."""
        fn = log_fn or self.log_fn
        if fn is None:
            return
        for line in self.format_summary():
            fn(line)

    # ── individual checks ────────────────────────────────────────────────

    def _check_unitypy(self) -> None:
        available = _can_import("UnityPy")
        self._results.append(DependencyStatus(
            name="UnityPy",
            level=DependencyLevel.REQUIRED,
            available=available,
            impact="Asset extraction and parsing disabled" if not available else "",
            detail="pip install UnityPy>=1.5.0",
        ))

    def _check_pillow(self) -> None:
        available = _can_import("PIL")
        self._results.append(DependencyStatus(
            name="Pillow",
            level=DependencyLevel.REQUIRED,
            available=available,
            impact="Image processing disabled" if not available else "",
            detail="pip install Pillow>=9.0",
        ))

    def _check_customtkinter(self) -> None:
        available = _can_import("customtkinter")
        self._results.append(DependencyStatus(
            name="customtkinter",
            level=DependencyLevel.REQUIRED,
            available=available,
            impact="GUI will not launch" if not available else "",
            detail="pip install customtkinter>=5.2.0",
        ))

    def _check_requests(self) -> None:
        available = _can_import("requests")
        self._results.append(DependencyStatus(
            name="requests",
            level=DependencyLevel.REQUIRED,
            available=available,
            impact="Tool auto-download disabled" if not available else "",
            detail="pip install requests>=2.28",
        ))

    def _check_addressablestools(self) -> None:
        available = _can_import("AddressablesTools")
        self._results.append(DependencyStatus(
            name="addressablestools",
            level=DependencyLevel.OPTIONAL,
            available=available,
            impact="Addressable catalog enrichment disabled; "
                   "address-based sprite mappings will not be loaded",
            detail="pip install addressablestools>=0.1.7",
        ))

    def _check_typetree_generator(self) -> None:
        available = _can_import("UnityPy.helpers.TypeTreeGenerator")
        typetree_env = os.environ.get("IL2CPP_TYPETREE", "0") == "1"
        if available and not typetree_env:
            self._results.append(DependencyStatus(
                name="TypeTreeGeneratorAPI",
                level=DependencyLevel.DEGRADED,
                available=True,
                impact="Installed but not attached (IL2CPP_TYPETREE!=1); "
                       "using UnityPy built-in typetree. "
                       "Set IL2CPP_TYPETREE=1 to enable C# generator.",
            ))
        elif available:
            self._results.append(DependencyStatus(
                name="TypeTreeGeneratorAPI",
                level=DependencyLevel.OPTIONAL,
                available=True,
                impact="Typetree fidelity: full C# generator active",
            ))
        else:
            self._results.append(DependencyStatus(
                name="TypeTreeGeneratorAPI",
                level=DependencyLevel.OPTIONAL,
                available=False,
                impact="Typetree fidelity reduced on protected MonoBehaviours; "
                       "using UnityPy built-in typetree reader",
                detail="pip install TypeTreeGeneratorAPI>=0.0.10",
            ))

    def _check_java(self) -> None:
        path = _find_java()
        available = path is not None
        if available:
            self._results.append(DependencyStatus(
                name="Java",
                level=DependencyLevel.OPTIONAL,
                available=True,
                impact=f"Found: {path}",
            ))
        else:
            self._results.append(DependencyStatus(
                name="Java",
                level=DependencyLevel.OPTIONAL,
                available=False,
                impact="APK decoding (apktool) disabled; "
                       "raw extraction only - smali and IL2CPP metadata may be incomplete",
                detail="Install JDK 11+ and ensure java is on PATH",
            ))

    def _check_node(self) -> None:
        path = _find_node()
        available = path is not None
        if available:
            self._results.append(DependencyStatus(
                name="Node.js",
                level=DependencyLevel.OPTIONAL,
                available=True,
                impact=f"Found: {path}",
            ))
        else:
            self._results.append(DependencyStatus(
                name="Node.js",
                level=DependencyLevel.OPTIONAL,
                available=False,
                impact="Normalized UI trees (Stage 5) not generated; "
                       "raw UI dumps will be used instead",
                detail="Install Node.js 18+ and ensure node is on PATH",
            ))

    def _check_il2cppdumper(self) -> None:
        path = _find_il2cppdumper()
        available = path is not None
        if available:
            self._results.append(DependencyStatus(
                name="Il2CppDumper",
                level=DependencyLevel.OPTIONAL,
                available=True,
                impact=f"Found: {path}",
            ))
        else:
            self._results.append(DependencyStatus(
                name="Il2CppDumper",
                level=DependencyLevel.OPTIONAL,
                available=False,
                impact="Type metadata recovery limited; "
                       "MonoBehaviours will fall back to raw bytes",
                detail="Will auto-download on first run, or set path in GUI",
            ))

    def _check_catalog(self) -> None:
        if self.raw_dir is None:
            self._results.append(DependencyStatus(
                name="Addressables catalog",
                level=DependencyLevel.INFO,
                available=False,
                impact="Not checked - no raw directory provided yet; "
                       "will be verified at pipeline runtime",
            ))
            return
        available = _has_catalog(self.raw_dir)
        self._results.append(DependencyStatus(
            name="Addressables catalog",
            level=DependencyLevel.OPTIONAL if not available else DependencyLevel.INFO,
            available=available,
            impact="Dynamic sprite binding accuracy reduced" if not available else "Found in raw directory",
        ))

    def _check_feature_flags(self) -> None:
        from il2cpp_recovery_studio.core.config import FeatureFlags
        flags = FeatureFlags()
        flag_lines = []
        for name, value in [
            ("dynamic_text", flags.enable_dynamic_text),
            ("atlas_binding", flags.enable_atlas_binding),
            ("low_confidence_asset_copy", flags.enable_low_confidence_asset_copy),
            ("addressable_enrichment", flags.enable_addressable_enrichment),
        ]:
            status = "ON" if value else "OFF"
            flag_lines.append(f"{name}={status}")
        self._results.append(DependencyStatus(
            name="Feature flags",
            level=DependencyLevel.INFO,
            available=True,
            impact=", ".join(flag_lines),
        ))
