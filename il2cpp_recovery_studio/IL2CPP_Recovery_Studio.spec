# -*- mode: python ; coding: utf-8 -*-
"""PyInstaller spec file for IL2CPP Recovery Studio.

Produces a single-folder or single-file .exe that launches the GUI automatically.
Run: python build_exe.py
"""
from __future__ import annotations

import os
import sys
from pathlib import Path

block_cipher = None

ROOT = Path(os.path.abspath(SPEC)).parent
SRC = ROOT

a = Analysis(
    [str(SRC / "__main__.py")],
    pathex=[str(SRC)],
    binaries=[],
    datas=[],
    hiddenimports=[
        "il2cpp_recovery_studio",
        "il2cpp_recovery_studio.gui.app",
        "il2cpp_recovery_studio.gui.styles",
        "il2cpp_recovery_studio.core.config",
        "il2cpp_recovery_studio.core.logging",
        "il2cpp_recovery_studio.apk.parser",
        "il2cpp_recovery_studio.apk.models",
        "il2cpp_recovery_studio.binary.analyzer",
        "il2cpp_recovery_studio.binary.models",
        "il2cpp_recovery_studio.recovery.orchestrator",
        "il2cpp_recovery_studio.recovery.models",
        "il2cpp_recovery_studio.recovery.database",
        "il2cpp_recovery_studio.recovery.parsers",
        "il2cpp_recovery_studio.recovery.tool_registry",
        "il2cpp_recovery_studio.metadata.parser",
        "il2cpp_recovery_studio.metadata.models",
        "il2cpp_recovery_studio.methodmap.engine",
        "il2cpp_recovery_studio.methodmap.models",
        "il2cpp_recovery_studio.unity.analyzer",
        "il2cpp_recovery_studio.unity.models",
        "il2cpp_recovery_studio.network.analyzer",
        "il2cpp_recovery_studio.network.models",
        "il2cpp_recovery_studio.strings.analyzer",
        "il2cpp_recovery_studio.strings.models",
        "il2cpp_recovery_studio.assets.analyzer",
        "il2cpp_recovery_studio.assets.models",
        "il2cpp_recovery_studio.graphs.generator",
        "il2cpp_recovery_studio.graphs.models",
        "il2cpp_recovery_studio.search.engine",
        "il2cpp_recovery_studio.search.models",
        "il2cpp_recovery_studio.ghidra.engine",
        "il2cpp_recovery_studio.ghidra.models",
        "il2cpp_recovery_studio.plugins.manager",
        "il2cpp_recovery_studio.exporters.exporters",
        "il2cpp_recovery_studio.performance",
        "il2cpp_recovery_studio.performance.cache",
        "il2cpp_recovery_studio.performance.utils",
        # Dependencies
        "PySide6",
        "PySide6.QtCore",
        "PySide6.QtGui",
        "PySide6.QtWidgets",
        "lief",
        "rich",
        "rich.console",
        "rich.progress",
        "yaml",
        "networkx",
    ],
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[
        "tkinter",
        "matplotlib",
        "numpy",
        "scipy",
        "pandas",
        "PIL",
        "pytest",
        "mypy",
        "ruff",
    ],
    win_no_prefer_redirects=False,
    win_private_assemblies=False,
    cipher=block_cipher,
    noarchive=False,
)

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.zipfiles,
    a.datas,
    [],
    name="IL2CPP_Recovery_Studio",
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=False,
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
    icon=None,
)
