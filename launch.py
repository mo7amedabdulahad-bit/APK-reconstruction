#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — Zero-Click Launcher (v4).

v4: Detects Windows Store stub Python and redirects to a real Python
    installation that has pip and packages available.

Fixes:
- Prevents PyInstaller EXE respawn loops with multiprocessing.freeze_support()
- Avoids calling pip from inside the frozen EXE
- Launches the GUI safely in both source and packaged modes
- Surfaces fatal errors in a message box (so a double-click failure is never silent)
"""
import os
import sys
import argparse
import subprocess
import multiprocessing
from pathlib import Path

# --- DEBUG LOGGING ---
try:
    with open("C:\\Users\\Mohamed\\OneDrive\\Desktop\\Unity Assets For hero\\APK\\launch_debug.log", "a") as debug_file:
        import datetime
        debug_file.write(f"[{datetime.datetime.now()}] Script invoked! sys.executable: {sys.executable}, sys.argv: {sys.argv}\n")
except Exception as e:
    pass
# ---------------------

# Critical for Windows/PyInstaller: prevents recursive child process spawning
multiprocessing.freeze_support()

REQUIRED_PYTHON = (3, 10)
IS_FROZEN = getattr(sys, "frozen", False)
REPO_ROOT = Path(sys.executable).resolve().parent if IS_FROZEN else Path(__file__).resolve().parent

REQUIRED_PKGS = {
    "UnityPy": "UnityPy>=1.5.0",
    "PIL": "Pillow>=9.0",
    "customtkinter": "customtkinter>=5.2.0",
    "requests": "requests>=2.28",
}
OPTIONAL_PKGS = {
    "addressablestools": "addressablestools>=0.1.7",
    "UnityPy.helpers.TypeTreeGenerator": "TypeTreeGeneratorAPI>=0.0.10",
}


def _is_store_stub() -> bool:
    """Detect Windows Store stub Python (WindowsApps path, no pip)."""
    exe = sys.executable.lower()
    return "windowsapps" in exe


def _find_real_python() -> str | None:
    """Find a real Python 3.10+ installation (not the Store stub)."""
    candidates = []

    # 1. Check common install locations on Windows
    if sys.platform == "win32":
        pf   = Path(os.environ.get("ProgramFiles",      r"C:\Program Files"))
        pf86 = Path(os.environ.get("ProgramFiles(x86)", r"C:\Program Files (x86)"))
        la   = Path(os.environ.get("LOCALAPPDATA",       r"C:\Users\Default\AppData\Local"))
        user = Path(os.environ.get("USERPROFILE",        r"C:\Users\Default"))
        for root in [pf, pf86, la / "Programs", user / "AppData" / "Local" / "Programs"]:
            if root.exists():
                for d in sorted(root.rglob("Python*"), reverse=True):
                    exe = d / "python.exe"
                    if exe.exists():
                        candidates.append(exe)

    # 2. Check PATH entries (excluding WindowsApps)
    for dir_str in os.environ.get("PATH", "").split(os.pathsep):
        d = Path(dir_str)
        exe = d / "python.exe"
        if exe.exists() and "windowsapps" not in str(exe).lower():
            candidates.append(exe)

    # 3. Try `py -3.X` launcher (py.exe)
    for minor in range(15, 9, -1):
        try:
            r = subprocess.run(
                ["py", f"-3.{minor}", "-c", "import sys; print(sys.executable)"],
                capture_output=True, text=True, timeout=5,
            )
            if r.returncode == 0 and r.stdout.strip():
                p = Path(r.stdout.strip())
                if p.exists():
                    candidates.append(p)
        except Exception:
            pass

    # 4. Filter out WindowsApps (Store stub) from all candidates
    candidates = [e for e in candidates if "windowsapps" not in str(e).lower()]

    # 5. Evaluate candidates: prefer one that has pip + our packages installed
    for exe in candidates:
        try:
            r = subprocess.run(
                [str(exe), "-c", "import UnityPy, customtkinter; print('ok')"],
                capture_output=True, text=True, timeout=10,
            )
            if r.returncode == 0:
                return str(exe)
        except Exception:
            pass

    # 6. Fallback: any non-Store Python 3.10+
    for exe in candidates:
        try:
            r = subprocess.run(
                [str(exe), "-c", "import sys; print(sys.version_info >= (3,10))"],
                capture_output=True, text=True, timeout=5,
            )
            if r.returncode == 0 and "True" in r.stdout:
                return str(exe)
        except Exception:
            pass

    return None


def _redirect_if_needed() -> None:
    """If running under Store stub, re-exec with a real Python."""
    if IS_FROZEN:
        return
    if not _is_store_stub():
        return

    real = _find_real_python()
    if real and real.lower() != sys.executable.lower():
        print(f"  i  Detected Store stub Python - switching to: {real}")
        # On Windows, os.execv() spawns a new process and kills the parent
        # terminal immediately, leaving an empty/crashed window. Use
        # subprocess.run() instead so the child inherits the console properly.
        result = subprocess.run([real] + sys.argv)
        sys.exit(result.returncode)
    else:
        print("  WARNING: Running under Windows Store Python stub.")
        print("     Some features may not work. Install a real Python from:")
        print("     https://www.python.org/downloads/")
        print(f"     Current: {sys.executable}")


def check_python_version() -> bool:
    if IS_FROZEN:
        return True
    if sys.version_info < REQUIRED_PYTHON:
        major, minor = REQUIRED_PYTHON
        _pause_or_error(
            "Python version too old",
            f"Python {major}.{minor}+ is required.\n"
            f"You are running {sys.version}\n\n"
            f"Download a recent Python from https://www.python.org/downloads/",
        )
        return False
    return True


def ensure_dependencies() -> bool:
    if IS_FROZEN:
        return True

    # Required packages - block on failure
    missing_required = [
        pip_name
        for import_name, pip_name in REQUIRED_PKGS.items()
        if not _can_import(import_name)
    ]
    if missing_required:
        print("Installing / upgrading required packages...")
        try:
            subprocess.check_call(
                [sys.executable, "-m", "pip", "install", "--upgrade"] + missing_required,
                stdout=None if _verbose() else subprocess.DEVNULL,
                stderr=None if _verbose() else subprocess.DEVNULL,
            )
            print("  Packages ready.")
        except subprocess.CalledProcessError as exc:
            _pause_or_error(
                "Failed to install required packages",
                f"Could not install: {' '.join(missing_required)}\n\n"
                f"Run manually in a terminal:\n"
                f"    pip install {' '.join(missing_required)}\n\n"
                f"Original error: {exc}",
            )
            return False

    # Optional packages - warn but don't block
    missing_optional = [
        pip_name
        for import_name, pip_name in OPTIONAL_PKGS.items()
        if not _can_import(import_name)
    ]
    if missing_optional:
        print("  Optional packages not found. Installing...")
        try:
            subprocess.check_call(
                [sys.executable, "-m", "pip", "install", "--upgrade"] + missing_optional,
                stdout=None if _verbose() else subprocess.DEVNULL,
                stderr=None if _verbose() else subprocess.DEVNULL,
            )
            print("  Optional packages ready.")
        except subprocess.CalledProcessError:
            print("  Optional packages failed to install - continuing without them.")
            print(f"       Install manually if needed: pip install {' '.join(missing_optional)}")

    return True


def self_update() -> None:
    if IS_FROZEN:
        return
    git = _find_git()
    if not git:
        print("  Git not found - skipping update.")
        return
    print("Pulling latest version from GitHub...")
    try:
        result = subprocess.run(
            [git, "-C", str(REPO_ROOT), "pull", "--ff-only"],
            capture_output=True, text=True, timeout=30,
        )
        if result.returncode == 0:
            print(f"  {result.stdout.strip() or 'Already up to date.'}")
        else:
            print(f"  Git pull warning: {result.stderr.strip()}")
    except Exception as exc:
        print(f"  Update failed: {exc}")


def _can_import(name: str) -> bool:
    try:
        __import__(name)
        return True
    except ImportError:
        return False


def _verbose() -> bool:
    return os.environ.get("IL2CPP_RECOVERY_VERBOSE", "") == "1"


def _has_console() -> bool:
    """True if we are attached to an interactive console we can print/pause in."""
    if IS_FROZEN:
        return False
    try:
        return sys.stdin is not None and sys.stdin.isatty()
    except Exception:
        return False


def _show_error(title: str, message: str) -> None:
    """Surface a fatal error both to the user and to a log file.

    If we have no interactive console (e.g. double-clicked a .py with no
    visible terminal), pop a message box so the failure is not silent.
    """
    try:
        err_path = REPO_ROOT / "startup_error.log"
        with open(err_path, "a", encoding="utf-8") as fh:
            fh.write(f"[{__import__('datetime').datetime.now()}] {title}\n{message}\n\n")
    except Exception:
        pass

    if _has_console():
        print(f"\n  ERROR: {title}\n{message}")
    else:
        try:
            import tkinter as _tk
            root = _tk.Tk()
            root.withdraw()
            _tk.messagebox.showerror("IL2CPP Recovery Studio", f"{title}\n\n{message}")
            root.destroy()
        except Exception:
            pass


def _pause_or_error(title: str, message: str) -> None:
    """Show an error, then pause (console) or wait for the message box to close."""
    _show_error(title, message)
    if _has_console():
        try:
            input("Press Enter to exit...")
        except Exception:
            pass


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
            _show_error("Failed to launch GUI", traceback.format_exc())


def main() -> None:
    parser = argparse.ArgumentParser(add_help=False)
    parser.add_argument("--update", action="store_true", help="Pull latest from GitHub before launch")
    args, _ = parser.parse_known_args()

    os.chdir(REPO_ROOT)

    # Redirect away from Windows Store stub Python if needed
    _redirect_if_needed()

    if not check_python_version():
        return

    if args.update:
        self_update()

    if not ensure_dependencies():
        return

    launch_gui()


if __name__ == "__main__":
    import atexit
    log_path = Path(__file__).resolve().parent / "launch_debug.log"
    atexit.register(lambda: log_path.write_text(
        f"Exit. sys.executable={sys.executable}\nargv={sys.argv}\n",
        encoding="utf-8"))
    try:
        main()
    except SystemExit as e:
        log_path.write_text(f"SystemExit({e.code})\nsys.executable={sys.executable}\n")
        print(f"Exiting with code: {e.code}")
        input("Press Enter to exit...")
        raise
    except BaseException:
        import traceback
        tb = traceback.format_exc()
        log_path.write_text(tb, encoding="utf-8")
        print(tb)
        input("Press Enter to exit...")
