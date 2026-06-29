from __future__ import annotations

import os
from dataclasses import dataclass, field
from pathlib import Path
from typing import Any


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
        return cls(
            tool_paths=tool_paths,
            analysis=analysis,
            output=output,
            verbose=data.get("verbose", False),
            log_level=data.get("log_level", "INFO"),
        )
