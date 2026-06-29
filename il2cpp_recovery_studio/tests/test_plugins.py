"""Tests for Phase 17: Plugin system."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.plugins.manager import (
    AnalyzerPlugin,
    ExporterPlugin,
    ParserPlugin,
    PluginBase,
    PluginInfo,
    PluginManager,
    PluginType,
)


class DummyAnalyzerPlugin(AnalyzerPlugin):
    def __init__(self) -> None:
        self.initialized = False
        self.shutdown_called = False

    @property
    def info(self) -> PluginInfo:
        return PluginInfo(name="dummy", version="1.0.0", plugin_type=PluginType.ANALYZER)

    def initialize(self) -> None:
        self.initialized = True

    def shutdown(self) -> None:
        self.shutdown_called = True

    def analyze(self, data: dict) -> dict:
        return {"analyzed": True}


class DummyParserPlugin(ParserPlugin):
    @property
    def info(self) -> PluginInfo:
        return PluginInfo(name="parser1", plugin_type=PluginType.PARSER)

    def initialize(self) -> None:
        pass

    def shutdown(self) -> None:
        pass

    def parse(self, file_path: str) -> dict:
        return {"parsed": True}


class FailingPlugin(AnalyzerPlugin):
    @property
    def info(self) -> PluginInfo:
        return PluginInfo(name="failing", plugin_type=PluginType.ANALYZER)

    def initialize(self) -> None:
        raise RuntimeError("Init failed")

    def shutdown(self) -> None:
        pass

    def analyze(self, data: dict) -> dict:
        return {}


class TestPluginManager:
    def test_register(self):
        mgr = PluginManager()
        plugin = DummyAnalyzerPlugin()
        mgr.register(plugin)
        assert len(mgr.registered_plugins) == 1

    def test_unregister(self):
        mgr = PluginManager()
        plugin = DummyAnalyzerPlugin()
        mgr.register(plugin)
        assert mgr.unregister("dummy")
        assert len(mgr.registered_plugins) == 0

    def test_unregister_nonexistent(self):
        mgr = PluginManager()
        assert not mgr.unregister("nope")

    def test_get_plugin(self):
        mgr = PluginManager()
        plugin = DummyAnalyzerPlugin()
        mgr.register(plugin)
        assert mgr.get_plugin("dummy") is plugin
        assert mgr.get_plugin("nope") is None

    def test_initialize_all(self):
        mgr = PluginManager()
        plugin = DummyAnalyzerPlugin()
        mgr.register(plugin)
        mgr.initialize_all()
        assert plugin.initialized

    def test_shutdown_all(self):
        mgr = PluginManager()
        plugin = DummyAnalyzerPlugin()
        mgr.register(plugin)
        mgr.initialize_all()
        mgr.shutdown_all()
        assert plugin.shutdown_called

    def test_failing_initialize(self):
        mgr = PluginManager()
        mgr.register(FailingPlugin())
        mgr.initialize_all()
        assert len(mgr.registered_plugins) == 1

    def test_get_by_type(self):
        mgr = PluginManager()
        mgr.register(DummyAnalyzerPlugin())
        mgr.register(DummyParserPlugin())
        assert len(mgr.get_by_type(PluginType.ANALYZER)) == 1
        assert len(mgr.get_by_type(PluginType.PARSER)) == 1

    def test_load_nonexistent_dir(self):
        mgr = PluginManager()
        assert mgr.load_from_directory("/nonexistent") == 0

    def test_replace_plugin(self):
        mgr = PluginManager()
        p1 = DummyAnalyzerPlugin()
        p2 = DummyAnalyzerPlugin()
        mgr.register(p1)
        mgr.register(p2)
        assert len(mgr.registered_plugins) == 1
        assert mgr.get_plugin("dummy") is p2
