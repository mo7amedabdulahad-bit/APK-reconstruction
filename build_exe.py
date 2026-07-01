#!/usr/bin/env python3
"""
build_exe.py  —  One-click EXE builder for IL2CPP Recovery Studio.

Run this ONCE on your machine to produce:
    dist/IL2CPP_Recovery_Studio.exe

Requirements: Python 3.10+, internet connection (first run only).
"""
import subprocess
import sys
import os
from pathlib import Path

ROOT = Path(__file__).resolve().parent
SPEC = ROOT / "il2cpp_recovery_studio" / "IL2CPP_Recovery_Studio.spec"
ENTRY = ROOT / "launch.py"


def pip(*args):
    subprocess.check_call([sys.executable, "-m", "pip", "install", *args])


def main():
    print("=" * 60)
    print("  IL2CPP Recovery Studio — EXE Builder")
    print("=" * 60)

    # ── 1. Install / upgrade build deps ───────────────────────────
    print("\n[1/4] Installing build dependencies...")
    pip("--upgrade", "pip", "setuptools", "wheel")
    pip("pyinstaller>=6.0", "UnityPy>=1.5.0", "Pillow>=9.0", "customtkinter>=5.2.0", "requests")

    # ── 2. Decide whether to use the existing .spec or build fresh ─
    print("\n[2/4] Preparing build spec...")
    if SPEC.exists():
        print(f"  Using existing spec: {SPEC}")
        cmd = [sys.executable, "-m", "PyInstaller", str(SPEC), "--distpath", str(ROOT / "dist"), "--workpath", str(ROOT / "build")]
    else:
        print("  No spec found — generating one from launch.py")
        cmd = [
            sys.executable, "-m", "PyInstaller",
            "--onefile",
            "--windowed",
            "--name", "IL2CPP_Recovery_Studio",
            "--add-data", f"{ROOT / 'il2cpp_recovery_studio'}{os.pathsep}il2cpp_recovery_studio",
            "--distpath", str(ROOT / "dist"),
            "--workpath", str(ROOT / "build"),
            str(ENTRY),
        ]

    # ── 3. Run PyInstaller ─────────────────────────────────────────
    print("\n[3/4] Building EXE (this may take 1-3 minutes)...")
    subprocess.check_call(cmd)

    # ── 4. Report result ──────────────────────────────────────────
    exe = ROOT / "dist" / "IL2CPP_Recovery_Studio.exe"
    if not exe.exists():
        # PyInstaller sometimes creates a folder, not a single file
        exe_dir = ROOT / "dist" / "IL2CPP_Recovery_Studio"
        if exe_dir.exists():
            exe = exe_dir / "IL2CPP_Recovery_Studio.exe"

    print("\n[4/4] Done!")
    if exe.exists():
        print(f"\n  ✅  EXE created: {exe}")
        print("      Double-click that file to launch the app — no Python needed!")
    else:
        print("  ⚠️  EXE not found at expected path — check the 'dist' folder.")

    input("\nPress Enter to exit...")


if __name__ == "__main__":
    main()
