# IL2CPP Recovery Studio

Production-quality Unity IL2CPP/Mono APK recovery and analysis tool.

## Quick Start (One-Click .exe)

1. Download `IL2CPP_Recovery_Studio.exe`
2. Double-click to launch
3. Click **Open APK** and select your `.apk` or `.xapk` file
4. Click **Run Analysis** - everything is automatic
5. Browse results across all 12 tabs (Overview, Metadata, Methods, Strings, etc.)
6. Click **Export** to save results

No installation. No commands. No setup.

## Building the .exe Yourself

### Prerequisites

```bash
pip install pyinstaller PySide6 lief rich PyYAML networkx
```

### Build

```bash
python build_exe.py
```

The .exe will be at `dist/IL2CPP_Recovery_Studio.exe`. Double-click to run.

## Features

- **APK Parsing** - Open/validate APKs, detect Unity version, architecture, build type
- **IL2CPP Detection** - Metadata version, encryption, obfuscation, protection analysis
- **Tool Orchestration** - Cpp2IL, Il2CppDumper, Il2CppInspector with auto-failover
- **Metadata Recovery** - Types, methods, fields, properties, events from global-metadata.dat
- **Native Binary Analysis** - LIEF + Capstone ELF analysis, function/symbol extraction
- **Method Mapping** - Bidirectional lookup (index, address, name, class, confidence)
- **Project Reconstruction** - Generate .cs files with fields, methods, native addresses
- **Unity Analysis** - Manager detection, singletons, ScriptableObjects, lifecycle methods
- **Network Analysis** - Protocol detection, URL extraction, auth methods
- **String Analysis** - Categorization: URLs, JSON, SQL, API keys, errors, debug
- **Asset Analysis** - Scenes, prefabs, textures, materials, shaders, fonts, audio
- **Dependency Graphs** - Class hierarchy, namespace, call, inheritance graphs
- **Ghidra Integration** - Headless analysis, decompilation, metadata merge
- **Full-text Search** - Indexed search with exact/contains/regex/fuzzy modes
- **Plugin System** - Parser, analyzer, exporter plugin SDK
- **Exporters** - JSON, CSV, SQLite, Markdown output
- **Dark Mode GUI** - 12 functional tabs with dockable panels

## Alternative: Install from Source

```bash
# CLI only
pip install il2cpp-recovery-studio

# With GUI
pip install il2cpp-recovery-studio[gui]

# Development
git clone <repo>
cd il2cpp_recovery_studio
pip install -e ".[dev,gui]"
```

## Command-Line Usage

```bash
# Analyze an APK from command line
il2cpp-recovery-studio --apk path/to/game.apk --output output/

# Launch GUI manually
il2cpp-recovery-studio --gui
```

## Python API

```python
from il2cpp_recovery_studio.apk.parser import APKParser
from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator
from il2cpp_recovery_studio.core.config import AppConfig

parser = APKParser()
apk_info = parser.parse(Path("game.apk"))

orch = RecoveryOrchestrator(config=AppConfig())
result = orch.run(apk_info)

print(f"Recovered {result.classes_recovered} classes")
print(f"Recovered {result.methods_recovered} methods")
```

## Testing

```bash
pytest
pytest --cov=il2cpp_recovery_studio
```

## Architecture

```
il2cpp_recovery_studio/
  apk/          # APK parsing and validation
  binary/       # Native binary analysis (LIEF + Capstone)
  core/         # Config, logging, exceptions
  crossref/     # Cross-reference analysis
  exporters/    # JSON, CSV, SQLite, Markdown exporters
  ghidra/       # Ghidra headless integration
  graphs/       # Dependency graph generation
  gui/          # PySide6 desktop GUI with dark mode
  metadata/     # IL2CPP metadata parser
  methodmap/    # Method mapping engine
  network/      # Network analysis
  performance/  # Caching, parallel processing
  plugins/      # Plugin SDK
  recovery/     # Recovery pipeline orchestrator
  search/       # Full-text search engine
  strings/      # String extraction and categorization
  tests/        # Comprehensive test suite (492 tests)
  unity/        # Unity-specific analysis
```

## License

MIT
