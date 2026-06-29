"""Unit tests for core configuration module."""
from __future__ import annotations

from pathlib import Path

from il2cpp_recovery_studio.core.config import AppConfig, AnalysisConfig, OutputConfig, ToolPaths


class TestToolPaths:
    def test_defaults(self) -> None:
        tp = ToolPaths()
        assert tp.cpp2il == "Cpp2IL"
        assert tp.il2cpp_dumper == "Il2CppDumper"
        assert tp.il2cpp_inspector == "Il2CppInspector"
        assert tp.ghidra_headless == "analyzeHeadless"
        assert tp.graphviz_dot == "dot"

    def test_custom(self) -> None:
        tp = ToolPaths(cpp2il="/opt/cpp2il", il2cpp_dumper="dump.exe")
        assert tp.cpp2il == "/opt/cpp2il"
        assert tp.il2cpp_dumper == "dump.exe"


class TestAnalysisConfig:
    def test_defaults(self) -> None:
        ac = AnalysisConfig()
        assert ac.max_file_size_gb == 4.0
        assert ac.extract_assets is True
        assert ac.generate_graphs is True
        assert ac.run_ghidra is False
        assert ac.parallel_workers == 4
        assert ac.cache_enabled is True

    def test_custom(self) -> None:
        ac = AnalysisConfig(max_file_size_gb=8.0, parallel_workers=8)
        assert ac.max_file_size_gb == 8.0
        assert ac.parallel_workers == 8


class TestOutputConfig:
    def test_defaults_are_paths(self) -> None:
        oc = OutputConfig()
        assert isinstance(oc.base_dir, Path)
        assert isinstance(oc.projects_dir, Path)
        assert isinstance(oc.reports_dir, Path)
        assert isinstance(oc.logs_dir, Path)
        assert isinstance(oc.databases_dir, Path)
        assert isinstance(oc.graphs_dir, Path)
        assert isinstance(oc.exports_dir, Path)


class TestAppConfig:
    def test_defaults(self) -> None:
        cfg = AppConfig()
        assert isinstance(cfg.tool_paths, ToolPaths)
        assert isinstance(cfg.analysis, AnalysisConfig)
        assert isinstance(cfg.output, OutputConfig)
        assert cfg.verbose is False
        assert cfg.log_level == "INFO"

    def test_to_dict_roundtrip(self, tmp_path: Path) -> None:
        cfg = AppConfig(verbose=True, log_level="DEBUG")
        d = cfg.to_dict()
        assert d["verbose"] is True
        assert d["log_level"] == "DEBUG"
        restored = AppConfig.from_dict(d)
        assert restored.verbose is True
        assert restored.log_level == "DEBUG"
        assert restored.tool_paths.cpp2il == "Cpp2IL"

    def test_ensure_directories(self, tmp_path: Path) -> None:
        out = tmp_path / "test_output"
        cfg = AppConfig(
            output=OutputConfig(
                base_dir=out / "base",
                projects_dir=out / "projects",
                reports_dir=out / "reports",
                logs_dir=out / "logs",
                databases_dir=out / "db",
                graphs_dir=out / "graphs",
                exports_dir=out / "exports",
            )
        )
        cfg.ensure_directories()
        for child in out.iterdir():
            assert child.is_dir()
