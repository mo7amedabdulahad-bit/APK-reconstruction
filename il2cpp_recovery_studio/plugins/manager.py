"""Plugin system: plugin manager, base classes, and registration."""
from __future__ import annotations

from abc import ABC, abstractmethod
from dataclasses import dataclass, field
from enum import Enum, auto
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("plugins.manager")


class PluginType(Enum):
    """Types of plugins."""

    PARSER = auto()
    ANALYZER = auto()
    EXPORTER = auto()
    REPORT = auto()
    GUI_PAGE = auto()


@dataclass
class PluginInfo:
    """Metadata about a registered plugin."""

    name: str
    version: str = "1.0.0"
    plugin_type: PluginType = PluginType.ANALYZER
    description: str = ""
    author: str = ""
    enabled: bool = True


class PluginBase(ABC):
    """Base class for all plugins."""

    @property
    @abstractmethod
    def info(self) -> PluginInfo:
        ...

    @abstractmethod
    def initialize(self) -> None:
        ...

    @abstractmethod
    def shutdown(self) -> None:
        ...


class ParserPlugin(PluginBase):
    """Base for parser plugins."""

    @abstractmethod
    def parse(self, file_path: str) -> dict:
        ...


class AnalyzerPlugin(PluginBase):
    """Base for analyzer plugins."""

    @abstractmethod
    def analyze(self, data: dict) -> dict:
        ...


class ExporterPlugin(PluginBase):
    """Base for exporter plugins."""

    @abstractmethod
    def export(self, data: dict, output_path: str) -> str:
        ...


class PluginManager:
    """Manages plugin discovery, registration, and lifecycle."""

    def __init__(self) -> None:
        self._plugins: dict[str, PluginBase] = {}
        self._initialized: dict[str, bool] = {}

    @property
    def registered_plugins(self) -> list[PluginInfo]:
        return [p.info for p in self._plugins.values()]

    def register(self, plugin: PluginBase) -> None:
        info = plugin.info
        if info.name in self._plugins:
            logger.warning("Plugin %s already registered, replacing", info.name)
        self._plugins[info.name] = plugin
        self._initialized[info.name] = False
        logger.info("Registered plugin: %s v%s", info.name, info.version)

    def unregister(self, name: str) -> bool:
        if name in self._plugins:
            self._plugins[name].shutdown()
            del self._plugins[name]
            self._initialized.pop(name, None)
            logger.info("Unregistered plugin: %s", name)
            return True
        return False

    def get_plugin(self, name: str) -> PluginBase | None:
        return self._plugins.get(name)

    def initialize_all(self) -> None:
        for name, plugin in self._plugins.items():
            if not self._initialized.get(name, False):
                try:
                    plugin.initialize()
                    self._initialized[name] = True
                    logger.info("Initialized plugin: %s", name)
                except Exception as e:
                    logger.error("Failed to initialize %s: %s", name, e)

    def shutdown_all(self) -> None:
        for name, plugin in self._plugins.items():
            if self._initialized.get(name, False):
                try:
                    plugin.shutdown()
                    self._initialized[name] = False
                except Exception as e:
                    logger.error("Failed to shutdown %s: %s", name, e)

    def get_by_type(self, plugin_type: PluginType) -> list[PluginBase]:
        return [p for p in self._plugins.values() if p.info.plugin_type == plugin_type]

    def load_from_directory(self, directory: str) -> int:
        loaded = 0
        plugin_dir = Path(directory)
        if not plugin_dir.is_dir():
            return 0
        for py_file in plugin_dir.glob("*.py"):
            if py_file.name.startswith("_"):
                continue
            logger.info("Discovered plugin file: %s", py_file.name)
            loaded += 1
        return loaded
