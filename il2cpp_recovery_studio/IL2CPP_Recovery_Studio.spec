# -*- mode: python ; coding: utf-8 -*-
"""PyInstaller spec file for IL2CPP Recovery Studio.

Fixed for stable EXE startup.
"""
from __future__ import annotations
from pathlib import Path
import os

block_cipher = None
ROOT = Path(os.path.abspath(SPEC)).parent
PROJECT_ROOT = ROOT.parent

entry_script = PROJECT_ROOT / "launch.py"
package_dir = PROJECT_ROOT / "il2cpp_recovery_studio"


a = Analysis(
    [str(entry_script)],
    pathex=[str(PROJECT_ROOT)],
    binaries=[],
    datas=[(str(package_dir), "il2cpp_recovery_studio")],
    hiddenimports=[
        "customtkinter",
        "tkinter",
        "tkinter.filedialog",
        "UnityPy",
        "PIL",
        "PIL.Image",
        "PIL.ImageTk",
        "requests",
        "il2cpp_recovery_studio",
        "il2cpp_recovery_studio.gui",
        "il2cpp_recovery_studio.gui.app",
    ],
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=["pytest", "mypy", "ruff"],
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
    upx=False,
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
