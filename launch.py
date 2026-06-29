#!/usr/bin/env python3
"""IL2CPP Recovery Studio — Zero-Click Launcher.

Auto-installs dependencies, checks Python version, and launches the GUI.
Double-click this file or run: python launch.py
"""
import os
import subprocess
import sys
from pathlib import Path

REQUIRED_PYTHON = (3, 10)
REPO_ROOT = Path(__file__).resolve().parent
PACKAGE_DIR = REPO_ROOT / "il2cpp_recovery_studio"


def check_python_version() -> bool:
    """Ensure Python >= 3.10."""
    if sys.version_info < REQUIRED_PYTHON:
        major, minor = REQUIRED_PYTHON
        print(f"ERROR: Python {major}.{minor}+ is required.")
        print(f"       You are running Python {sys.version}")
        print(f"       Download from: https://www.python.org/downloads/")
        input("Press Enter to exit...")
        return False
    return True


def ensure_dependencies() -> bool:
    """Install required packages if not already installed."""
    missing = []
    for pkg in ("UnityPy", "PIL"):
        try:
            __import__(pkg)
        except ImportError:
            missing.append(pkg)

    if not missing:
        return True

    req_file = REPO_ROOT / "requirements.txt"
    if req_file.exists():
        print("Installing required packages...")
        try:
            subprocess.check_call(
                [sys.executable, "-m", "pip", "install", "-r", str(req_file)],
                stdout=subprocess.DEVNULL if not _is_verbose() else None,
                stderr=subprocess.DEVNULL if not _is_verbose() else None,
            )
            print("Dependencies installed successfully.")
            return True
        except subprocess.CalledProcessError as exc:
            print(f"Failed to install dependencies: {exc}")
            print(f"Try manually: pip install -r {req_file}")
            input("Press Enter to exit...")
            return False
    else:
        print("Installing required packages...")
        try:
            subprocess.check_call(
                [sys.executable, "-m", "pip", "install", "UnityPy>=1.5.0", "Pillow>=9.0"],
                stdout=subprocess.DEVNULL if not _is_verbose() else None,
                stderr=subprocess.DEVNULL if not _is_verbose() else None,
            )
            print("Dependencies installed successfully.")
            return True
        except subprocess.CalledProcessError as exc:
            print(f"Failed to install dependencies: {exc}")
            input("Press Enter to exit...")
            return False


def _is_verbose() -> bool:
    return os.environ.get("IL2CPP_RECOVERY_VERBOSE", "") == "1"


def launch_gui() -> None:
    """Launch the IL2CPP Recovery Studio GUI."""
    # Ensure the package is importable
    if str(REPO_ROOT) not in sys.path:
        sys.path.insert(0, str(REPO_ROOT))

    try:
        from il2cpp_recovery_studio.gui.app import main
        main()
    except Exception as exc:
        print(f"Failed to launch GUI: {exc}")
        import traceback
        traceback.print_exc()
        input("Press Enter to exit...")


def main() -> None:
    os.chdir(REPO_ROOT)
    print("=" * 60)
    print("  IL2CPP Recovery Studio")
    print("  Unity APK Extraction, Editing & Rebuild Tool")
    print("=" * 60)
    print()

    if not check_python_version():
        return

    if not ensure_dependencies():
        return

    print("Launching GUI...")
    launch_gui()


if __name__ == "__main__":
    main()
