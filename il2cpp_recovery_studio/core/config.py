"""Application configuration and feature flags.

Feature flags control unstable optional subsystems.  All flags are read
from environment variables at import time and default to enabled (True).
Set any variable to ``0`` / ``false`` / ``no`` to disable::

    APKREC_ENABLE_DYNAMIC_TEXT=0
    APKREC_ENABLE_ATLAS_BINDING=false
    APKREC_ENABLE_LOW_CONFIDENCE_ASSET_COPY=no
    APKREC_ENABLE_ADDRESSABLE_ENRICHMENT=0
"""
from __future__ import annotations

import os
import logging
from dataclasses import dataclass, field
from pathlib import Path
from typing import Any

logger = logging.getLogger(__name__)


def _env_bool(name: str, default: bool) -> bool:
    """Read a boolean feature flag from an environment variable.

    Recognises ``1/true/yes`` as True and ``0/false/no`` as False.
    Any other value (including empty string) falls back to *default*.
    """
    raw = os.environ.get(name, "").strip().lower()
    if raw in ("1", "true", "yes"):
        return True
    if raw in ("0", "false", "no"):
        return False
    return default


@dataclass(frozen=True)
class FeatureFlags:
    """Opt-in / opt-out gates for unstable recovery subsystems.

    All flags default to **True** (enabled) so existing users see no
    behaviour change.  Set the corresponding environment variable to
    ``0`` / ``false`` / ``no`` to disable a feature.

    Flags
    -----
    enable_dynamic_text:
        Append IL2CPP-recovered dynamic text strings to scene exports.
        Env: ``APKREC_ENABLE_DYNAMIC_TEXT``  (default: True)

    enable_atlas_binding:
        Use atlas-based sprite binding fallback (path_id-only match
        across all indexed files when file_id resolution fails).
        Env: ``APKREC_ENABLE_ATLAS_BINDING``  (default: True)

    enable_low_confidence_asset_copy:
        Copy assets with low categorisation confidence into the
        RecoveredProject output.
        Env: ``APKREC_ENABLE_LOW_CONFIDENCE_ASSET_COPY``  (default: True)

    enable_addressable_enrichment:
        Load Addressables catalog and merge address-based sprite name
        mappings into the global sprite index.
        Env: ``APKREC_ENABLE_ADDRESSABLE_ENRICHMENT``  (default: True)
    """

    enable_dynamic_text: bool = field(
        default_factory=lambda: _env_bool("APKREC_ENABLE_DYNAMIC_TEXT", True)
    )
    enable_atlas_binding: bool = field(
        default_factory=lambda: _env_bool("APKREC_ENABLE_ATLAS_BINDING", True)
    )
    enable_low_confidence_asset_copy: bool = field(
        default_factory=lambda: _env_bool("APKREC_ENABLE_LOW_CONFIDENCE_ASSET_COPY", True)
    )
    enable_addressable_enrichment: bool = field(
        default_factory=lambda: _env_bool("APKREC_ENABLE_ADDRESSABLE_ENRICHMENT", True)
    )

    def log_state(self, log_fn=None) -> None:
        """Emit one log line per flag at INFO level.

        If *log_fn* is provided it is called with the formatted string
        (useful for the GUI pipeline which uses a custom callback).
        Otherwise the standard ``logging`` module is used.
        """
        flags = [
            ("dynamic_text", self.enable_dynamic_text),
            ("atlas_binding", self.enable_atlas_binding),
            ("low_confidence_asset_copy", self.enable_low_confidence_asset_copy),
            ("addressable_enrichment", self.enable_addressable_enrichment),
        ]
        for name, enabled in flags:
            status = "ON" if enabled else "OFF"
            msg = f"[FEATURE] {name:<35} = {status}"
            if log_fn is not None:
                log_fn(msg)
            else:
                logger.info("[FEATURE] %-35s = %s", name, status)


@dataclass(frozen=True)
class ToolPaths:
    """External tool configuration."""

    cpp2il: str = "Cpp2IL"
    il2cpp_dumper: str = "Il2CppDumper"
    il2cpp_inspector: str = "Il2CppInspector"
    ghidra_headless: str = "analyzeHeadless"
    graphviz_dot: str = "dot"


@dataclass(frozen=True)
class AnalysisConfig:
    """Analysis behaviour configuration."""

    max_file_size_gb: float = 4.0
    extract_assets: bool = True
    generate_graphs: bool = True
    run_ghidra: bool = False
    parallel_workers: int = 4
    cache_enabled: bool = True


@dataclass(frozen=True)
class OutputConfig:
    """Output directory structure."""

    base_dir: Path = field(default_factory=lambda: Path("output"))
    projects_dir: Path = field(default_factory=lambda: Path("output/projects"))
    reports_dir: Path = field(default_factory=lambda: Path("output/reports"))
    logs_dir: Path = field(default_factory=lambda: Path("output/logs"))
    databases_dir: Path = field(default_factory=lambda: Path("output/databases"))
    graphs_dir: Path = field(default_factory=lambda: Path("output/graphs"))
    exports_dir: Path = field(default_factory=lambda: Path("output/exports"))


@dataclass
class AppConfig:
    """Top-level application configuration."""

    tool_paths: ToolPaths = field(default_factory=ToolPaths)
    analysis: AnalysisConfig = field(default_factory=AnalysisConfig)
    output: OutputConfig = field(default_factory=OutputConfig)
    features: FeatureFlags = field(default_factory=FeatureFlags)
    verbose: bool = False
    log_level: str = "INFO"

    def ensure_directories(self) -> None:
        """Create all output directories if they do not exist."""
        for attr_name in dir(self.output):
            if attr_name.startswith("_"):
                continue
            value = getattr(self.output, attr_name)
            if isinstance(value, Path):
                value.mkdir(parents=True, exist_ok=True)

    def to_dict(self) -> dict[str, Any]:
        """Serialize configuration to a plain dictionary."""
        return {
            "tool_paths": self.tool_paths.__dict__,
            "analysis": self.analysis.__dict__,
            "output": {
                k: str(v) for k, v in self.output.__dict__.items() if not k.startswith("_")
            },
            "features": self.features.__dict__,
            "verbose": self.verbose,
            "log_level": self.log_level,
        }

    @classmethod
    def from_dict(cls, data: dict[str, Any]) -> AppConfig:
        """Deserialize configuration from a plain dictionary."""
        tool_paths = ToolPaths(**data.get("tool_paths", {}))
        analysis = AnalysisConfig(**data.get("analysis", {}))
        output_data = data.get("output", {})
        output = OutputConfig(
            **{k: Path(v) for k, v in output_data.items() if not k.startswith("_")}
        )
        features = FeatureFlags(**data.get("features", {}))
        return cls(
            tool_paths=tool_paths,
            analysis=analysis,
            output=output,
            features=features,
            verbose=data.get("verbose", False),
            log_level=data.get("log_level", "INFO"),
        )
