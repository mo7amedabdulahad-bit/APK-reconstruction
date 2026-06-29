#!/usr/bin/env python3
"""IL2CPP Recovery Studio - Rebuild and Test Script (Cross-Platform).

Usage:
    python rebuild_and_test.py <path_to_apk>

Steps:
    1. Extract assets from the APK
    2. Rebuild and sign a modded APK
    3. Install on connected device via adb
    4. Launch the app on the device
"""
from __future__ import annotations

import platform
import shutil
import subprocess
import sys
from pathlib import Path


def _run(cmd: list[str], check: bool = True, **kwargs) -> subprocess.CompletedProcess:
    """Run a command and stream output."""
    print(f"  > {' '.join(cmd)}")
    return subprocess.run(cmd, check=check, **kwargs)


def _find_adb() -> str | None:
    """Find the adb executable."""
    found = shutil.which("adb")
    if found:
        return found
    # Common locations
    for candidate in [
        Path("C:/Users") / platform.expandvars("%USERNAME%") / "AppData/Local/Android/Sdk/platform-tools/adb.exe",
        Path.home() / "Android/Sdk/platform-tools/adb",
        Path("/usr/local/bin/adb"),
        Path("/opt/android-sdk/platform-tools/adb"),
    ]:
        if candidate.exists():
            return str(candidate)
    return None


def _get_package_name(apk_path: Path) -> str | None:
    """Extract package name from APK using the app's parser."""
    try:
        sys.path.insert(0, str(Path(__file__).resolve().parent.parent))
        from il2cpp_recovery_studio.apk.parser import APKParser
        parser = APKParser()
        info = parser.parse(apk_path)
        return info.manifest.package_name or None
    except Exception as exc:
        print(f"  WARNING: Could not parse package name: {exc}")
        return None


def main() -> int:
    if len(sys.argv) < 2:
        print("ERROR: No APK path provided.")
        print("Usage: python rebuild_and_test.py <path_to_apk>")
        return 1

    apk_path = Path(sys.argv[1]).resolve()
    if not apk_path.exists():
        print(f"ERROR: APK not found: {apk_path}")
        return 1

    script_dir = Path(__file__).resolve().parent
    project_root = script_dir.parent
    output_dir = project_root / "output"
    rebuild_dir = output_dir / "rebuild_output"

    print("=" * 60)
    print("  IL2CPP Recovery Studio - Rebuild and Test")
    print("=" * 60)
    print(f"  APK:       {apk_path}")
    print(f"  Output:    {output_dir}")
    print()

    # Step 1: Extract
    print("[1/4] Extracting assets from APK...")
    try:
        _run([
            sys.executable, "-m", "il2cpp_recovery_studio",
            "--cli", "--apk", str(apk_path),
            "--output", str(output_dir), "--reconstruct",
        ])
    except subprocess.CalledProcessError as exc:
        print(f"ERROR: Extraction failed (exit code {exc.returncode}).")
        return 1
    print("      Extraction complete.\n")

    # Step 2: Rebuild and sign
    print("[2/4] Rebuilding and signing APK...")
    try:
        _run([
            sys.executable, "-c",
            f"from il2cpp_recovery_studio.rebuild.pipeline import rebuild_apk; "
            f"from pathlib import Path; "
            f"r = rebuild_apk(Path(r'{apk_path}'), Path(r'{output_dir}'), Path(r'{rebuild_dir}')); "
            f"print('Output:', r.output_apk if r.success else r.error); "
            f"exit(0 if r.success else 1)",
        ])
    except subprocess.CalledProcessError as exc:
        print(f"ERROR: Rebuild failed (exit code {exc.returncode}).")
        return 1
    print("      Rebuild complete.\n")

    # Step 3: Install via adb
    print("[3/4] Installing APK on device...")
    adb = _find_adb()
    if not adb:
        print("      WARNING: adb not found. Install Android SDK platform-tools.")
        print("               https://developer.android.com/tools/releases/platform-tools")
        print("      Skipping install.\n")
        _skip_launch = True
    else:
        # Check if device is connected
        try:
            result = subprocess.run(
                [adb, "devices"],
                capture_output=True, text=True, timeout=10,
                creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
            )
            lines = [l for l in result.stdout.strip().splitlines()[1:] if l.strip() and "device" in l]
            if not lines:
                print("      WARNING: No Android device detected. Skipping install.")
                print("               Connect a device or start an emulator and retry.\n")
                _skip_launch = True
            else:
                _skip_launch = False
        except Exception:
            _skip_launch = True

    if not _skip_launch:
        # Find the signed APK
        signed_apks = list(rebuild_dir.glob("modded_*.apk"))
        if not signed_apks:
            print(f"      WARNING: No signed APK found in {rebuild_dir}")
            _skip_launch = True
        else:
            signed_apk = signed_apks[0]
            try:
                _run([adb, "install", "-r", str(signed_apk)])
                print("      Install complete.\n")
            except subprocess.CalledProcessError:
                print("      WARNING: adb install failed. Device may not be connected.\n")
                _skip_launch = True

    # Step 4: Launch
    if not _skip_launch:
        print("[4/4] Launching app on device...")
        package_name = _get_package_name(apk_path)
        if package_name:
            print(f"      Package: {package_name}")
            try:
                _run([adb, "shell", "monkey", "-p", package_name, "1"])
                print("      App launched.\n")
            except subprocess.CalledProcessError:
                print("      WARNING: Failed to launch app.\n")
        else:
            print("      WARNING: Could not determine package name. Please launch manually.\n")
    else:
        print("[4/4] Skipping launch (no device or install skipped).\n")

    print("=" * 60)
    print("  Done! Check your device for the app.")
    print("=" * 60)
    return 0


if __name__ == "__main__":
    sys.exit(main())
