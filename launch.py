#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — Zero-Click Launcher (v3).

Fixes:
- Prevents PyInstaller EXE respawn loops with multiprocessing.freeze_support()
- Avoids calling pip from inside the frozen EXE
- Launches the GUI safely in both source and packaged modes
"""
import os
import sys
import argparse
import subprocess
import multiprocessing
from pathlib import Path

# Critical for Windows/PyInstaller: prevents recursive child process spawning
multiprocessing.freeze_support()

REQUIRED_PYTHON = (3, 10)
IS_FROZEN = getattr(sys, "frozen", False)
REPO_ROOT = Path(sys.executable).resolve().parent if IS_FROZEN else Path(__file__).resolve().parent

PKG_IMPORT_TO_PIP = {
    "UnityPy": "UnityPy>=1.5.0",
    "PIL": "Pillow>=9.0",
    "customtkinter": "customtkinter>=5.2.0",
    "requests": "requests>=2.28",
}


def check_python_version() -> bool:
    if IS_FROZEN:
        return True
    if sys.version_info < REQUIRED_PYTHON:
        major, minor = REQUIRED_PYTHON
        print(f"ERROR: Python {major}.{minor}+ is required.")
        print(f"       You are running Python {sys.version}")
        print("       Download: https://www.python.org/downloads/")
        input("Press Enter to exit...")
        return False
    return True


def ensure_dependencies() -> bool:
    if IS_FROZEN:
        return True

    missing = [
        pip_name
        for import_name, pip_name in PKG_IMPORT_TO_PIP.items()
        if not _can_import(import_name)
    ]
    if not missing:
        return True

    print("Installing / upgrading required packages...")
    try:
        subprocess.check_call(
            [sys.executable, "-m", "pip", "install", "--upgrade"] + missing,
            stdout=None if _verbose() else subprocess.DEVNULL,
            stderr=None if _verbose() else subprocess.DEVNULL,
        )
        print("  ✅  Packages ready.")
        return True
    except subprocess.CalledProcessError as exc:
        print(f"  ❌  Failed: {exc}")
        print(f"      Try manually: pip install {' '.join(missing)}")
        input("Press Enter to exit...")
        return False


def self_update() -> None:
    if IS_FROZEN:
        return
    git = _find_git()
    if not git:
        print("  ⚠️  Git not found — skipping update.")
        return
    print("Pulling latest version from GitHub...")
    try:
        result = subprocess.run(
            [git, "-C", str(REPO_ROOT), "pull", "--ff-only"],
            capture_output=True, text=True, timeout=30,
        )
        if result.returncode == 0:
            print(f"  ✅  {result.stdout.strip() or 'Already up to date.'}")
        else:
            print(f"  ⚠️  Git pull warning: {result.stderr.strip()}")
    except Exception as exc:
        print(f"  ⚠️  Update failed: {exc}")


def _can_import(name: str) -> bool:
    try:
        __import__(name)
        return True
    except ImportError:
        return False


def _verbose() -> bool:
    return os.environ.get("IL2CPP_RECOVERY_VERBOSE", "") == "1"


def _find_git():
    for candidate in ("git", "git.exe"):
        try:
            subprocess.run([candidate, "--version"], capture_output=True, check=True)
            return candidate
        except Exception:
            pass
    return None


def launch_gui() -> None:
    if not IS_FROZEN and str(REPO_ROOT) not in sys.path:
        sys.path.insert(0, str(REPO_ROOT))
    try:
        from il2cpp_recovery_studio.gui.app import run_gui
        run_gui()
    except Exception as exc:
        import traceback
        if IS_FROZEN:
            err_path = REPO_ROOT / "startup_error.log"
            err_path.write_text(traceback.format_exc(), encoding="utf-8")
        else:
            print(f"  ❌  Failed to launch GUI: {exc}")
            traceback.print_exc()
            input("Press Enter to exit...")


def main() -> None:
    parser = argparse.ArgumentParser(add_help=False)
    parser.add_argument("--update", action="store_true", help="Pull latest from GitHub before launch")
    args, _ = parser.parse_known_args()

    os.chdir(REPO_ROOT)

    if not check_python_version():
        return

    if args.update:
        self_update()

    if not ensure_dependencies():
        return

    launch_gui()


if __name__ == "__main__":
    main()
