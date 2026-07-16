"""APK Rebuild Pipeline.

Decodes APK with apktool, copies modified assets back in, repacks,
aligns, generates a debug keystore if needed, and signs with jarsigner.

All tools are auto-detected or auto-downloaded to a tools/ directory
next to the package root.
"""
from __future__ import annotations

import json
import os
import platform
import shutil
import subprocess
import sys
import tempfile
import time
import urllib.request
import zipfile
from pathlib import Path
from typing import Callable, Optional


TOOLS_DIR = Path(__file__).resolve().parent.parent.parent / "tools"
APKTOOL_JAR = TOOLS_DIR / "apktool.jar"
APKTOOL_URL = "https://bitbucket.org/iBotPeaches/apktool/downloads/apktool_2.9.3.jar"
KEYSTORE_PATH = TOOLS_DIR / "debug.keystore"
KEYSTORE_ALIAS = "androiddebugkey"
KEYSTORE_PASS = "android"
KEYSTORE_DNAME = "CN=Debug,OU=Debug,O=Debug,L=Debug,ST=Debug,C=US"

_JAVA_VERSION = "21.0.4+7"
_JAVA_DIR_NAME = "jdk-21"
_JAVA_URL = (
    "https://download.java.net/java/GA/jdk21.0.4/f2283984656d49d69e91c558476027ac/35/GPL/openjdk-21.0.4_windows-x64_bin.zip"
)

_ANDROID_BUILDTOOLS_VERSION = "34.0.0"
_ANDROID_BUILDTOOLS_URL = (
    f"https://dl.google.com/android/repository/build-tools_r{_ANDROID_BUILDTOOLS_VERSION.replace('.', '-')}-windows.zip"
)

_CONFIG_PATH = Path(__file__).resolve().parent.parent.parent / ".gui_config.json"

_log_fn: Callable[[str], None] = print


def set_logger(fn: Callable[[str], None]) -> None:
    global _log_fn
    _log_fn = fn


def _log(msg: str) -> None:
    _log_fn(msg)


def _run(cmd: list[str], cwd: Optional[str] = None, timeout: int = 600,
         env: Optional[dict] = None) -> subprocess.CompletedProcess:
    _log(f"  > {' '.join(cmd)}")
    return subprocess.run(
        cmd,
        capture_output=True,
        text=True,
        timeout=timeout,
        cwd=cwd,
        env=env,
        creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
    )


def _load_config() -> dict:
    if _CONFIG_PATH.exists():
        try:
            return json.loads(_CONFIG_PATH.read_text(encoding="utf-8"))
        except Exception:
            pass
    return {}


def _save_config(cfg: dict) -> None:
    try:
        _CONFIG_PATH.write_text(json.dumps(cfg, indent=2), encoding="utf-8")
    except Exception:
        pass


# ---------------------------------------------------------------------------
# Java discovery / download
# ---------------------------------------------------------------------------

def _ensure_java() -> bool:
    """Check that java is available on PATH. If not, try auto-downloading."""
    if _check_java_on_path():
        return True
    return _ensure_java_auto()


def _check_java_on_path() -> bool:
    """Check if java is available on PATH."""
    try:
        r = subprocess.run(
            ["java", "-version"],
            capture_output=True,
            text=True,
            timeout=10,
            creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
        )
        return r.returncode == 0
    except (FileNotFoundError, subprocess.TimeoutExpired):
        return False


def _ensure_java_auto() -> bool:
    """Download a portable OpenJDK to tools/ if no Java found on PATH."""
    cfg = _load_config()
    saved_java = cfg.get("java_home")
    if saved_java:
        java_bin = Path(saved_java) / "bin" / "java.exe"
        if java_bin.exists():
            os.environ["JAVA_HOME"] = saved_java
            os.environ["PATH"] = str(Path(saved_java) / "bin") + ";" + os.environ.get("PATH", "")
            _log(f"  Using saved Java: {saved_java}")
            return True

    java_dir = TOOLS_DIR / _JAVA_DIR_NAME
    java_bin = java_dir / "bin" / "java.exe"

    if java_bin.exists():
        os.environ["JAVA_HOME"] = str(java_dir)
        os.environ["PATH"] = str(java_dir / "bin") + ";" + os.environ.get("PATH", "")
        return True

    _log("  Java not found on PATH. Downloading portable OpenJDK 21...")
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    zip_name = "openjdk-21-windows-x64.zip"
    zip_path = TOOLS_DIR / zip_name

    try:
        if not zip_path.exists():
            def _progress(block_num: int, block_size: int, total_size: int):
                if total_size > 0 and block_num % 20 == 0:
                    pct = min(100.0, block_num * block_size / total_size * 100)
                    _log(f"  Java download: {pct:.0f}%")

            urllib.request.urlretrieve(_JAVA_URL, str(zip_path), reporthook=_progress)
            _log("  Java download complete.")
        else:
            _log("  Using cached Java download.")

        _log("  Extracting Java...")
        with zipfile.ZipFile(str(zip_path), "r") as zf:
            zf.extractall(str(TOOLS_DIR))

        # Find the extracted directory (e.g. jdk-21.0.4+7)
        extracted_jdk = None
        for item in TOOLS_DIR.iterdir():
            if item.is_dir() and item.name.startswith("jdk-"):
                extracted_jdk = item
                break

        if extracted_jdk and (extracted_jdk / "bin" / "java.exe").exists():
            # Rename to consistent name
            target = TOOLS_DIR / _JAVA_DIR_NAME
            if extracted_jdk != target:
                if target.exists():
                    shutil.rmtree(str(target))
                extracted_jdk.rename(target)
            os.environ["JAVA_HOME"] = str(target)
            os.environ["PATH"] = str(target / "bin") + ";" + os.environ.get("PATH", "")
            cfg["java_home"] = str(target)
            _save_config(cfg)
            _log(f"  Java ready at: {target}")
            return True

        _log("  WARNING: Java extraction succeeded but java.exe not found.")
        return False

    except Exception as exc:
        _log(f"  ERROR downloading Java: {exc}")
        try:
            if zip_path.exists():
                zip_path.unlink()
        except Exception:
            pass
        return False


# ---------------------------------------------------------------------------
# Apktool
# ---------------------------------------------------------------------------

def _ensure_apktool() -> bool:
    """Download apktool.jar if not present."""
    if APKTOOL_JAR.exists():
        return True
    if not _ensure_java():
        _log("ERROR: Java is required for apktool.")
        _log("       Install JDK 8+ or let the tool download it automatically.")
        return False
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    _log(f"Downloading apktool.jar to {APKTOOL_JAR} ...")
    try:
        urllib.request.urlretrieve(APKTOOL_URL, str(APKTOOL_JAR))
        _log("  Download complete.")
        return True
    except Exception as exc:
        _log(f"  Download failed: {exc}")
        _log("  Please manually place apktool.jar in: " + str(TOOLS_DIR))
        return False


# ---------------------------------------------------------------------------
# jarsigner / keytool
# ---------------------------------------------------------------------------

def _find_jarsigner() -> Optional[str]:
    """Find jarsigner on PATH or in JAVA_HOME."""
    for name in ("jarsigner", "jarsigner.exe"):
        r = shutil.which(name)
        if r:
            return r
    java_home = os.environ.get("JAVA_HOME", "")
    if java_home:
        for ext in (".exe", ""):
            candidate = Path(java_home) / "bin" / f"jarsigner{ext}"
            if candidate.exists():
                return str(candidate)
    return None


def _find_keytool() -> Optional[str]:
    """Find keytool on PATH or in JAVA_HOME."""
    for name in ("keytool", "keytool.exe"):
        r = shutil.which(name)
        if r:
            return r
    java_home = os.environ.get("JAVA_HOME", "")
    if java_home:
        for ext in (".exe", ""):
            candidate = Path(java_home) / "bin" / f"keytool{ext}"
            if candidate.exists():
                return str(candidate)
    return None


# ---------------------------------------------------------------------------
# zipalign / apksigner with auto-download
# ---------------------------------------------------------------------------

def _ensure_zipalign() -> Optional[str]:
    """Find or auto-download zipalign. Returns path to zipalign executable."""
    # Try PATH
    for name in ("zipalign", "zipalign.exe"):
        r = shutil.which(name)
        if r:
            return r

    # Try Android SDK
    sdk_za = _find_zipalign_in_sdk()
    if sdk_za:
        return sdk_za

    # Try saved config
    cfg = _load_config()
    saved = cfg.get("zipalign_path")
    if saved and Path(saved).exists():
        return saved

    # Auto-download
    return _download_build_tools()


def _find_zipalign_in_sdk() -> Optional[str]:
    """Search for zipalign in Android SDK build-tools."""
    for env_var in ("ANDROID_HOME", "ANDROID_SDK_ROOT"):
        android_home = os.environ.get(env_var, "")
        if android_home:
            build_tools = Path(android_home) / "build-tools"
            if build_tools.exists():
                versions = sorted([d for d in build_tools.iterdir() if d.is_dir()], reverse=True)
                for vdir in versions:
                    for ext in (".exe", ""):
                        za = vdir / f"zipalign{ext}"
                        if za.exists():
                            return str(za)
    local_app = Path(os.environ.get("LOCALAPPDATA", "")) / "Android" / "Sdk" / "build-tools"
    if local_app.exists():
        versions = sorted([d for d in local_app.iterdir() if d.is_dir()], reverse=True)
        for vdir in versions:
            za = vdir / "zipalign.exe"
            if za.exists():
                return str(za)
    return None


def _ensure_apksigner() -> Optional[str]:
    """Find or auto-download apksigner. Returns path to apksigner.bat."""
    # Try PATH
    for name in ("apksigner", "apksigner.bat", "apksigner.exe"):
        r = shutil.which(name)
        if r:
            return r

    # Try Android SDK
    sdk_as = _find_apksigner_in_sdk()
    if sdk_as:
        return sdk_as

    # Try saved config
    cfg = _load_config()
    saved = cfg.get("apksigner_path")
    if saved and Path(saved).exists():
        return saved

    # Auto-download
    return _download_build_tools()


def _find_apksigner_in_sdk() -> Optional[str]:
    """Search for apksigner in Android SDK build-tools."""
    for env_var in ("ANDROID_HOME", "ANDROID_SDK_ROOT"):
        android_home = os.environ.get(env_var, "")
        if android_home:
            build_tools = Path(android_home) / "build-tools"
            if build_tools.exists():
                versions = sorted([d for d in build_tools.iterdir() if d.is_dir()], reverse=True)
                for vdir in versions:
                    for name in ("apksigner.bat", "apksigner", "apksigner.exe"):
                        as_path = vdir / name
                        if as_path.exists():
                            return str(as_path)
    local_app = Path(os.environ.get("LOCALAPPDATA", "")) / "Android" / "Sdk" / "build-tools"
    if local_app.exists():
        versions = sorted([d for d in local_app.iterdir() if d.is_dir()], reverse=True)
        for vdir in versions:
            as_path = vdir / "apksigner.bat"
            if as_path.exists():
                return str(as_path)
    return None


def _download_build_tools() -> Optional[str]:
    """Download Android build-tools and extract zipalign + apksigner."""
    cfg = _load_config()
    saved_bt = cfg.get("build_tools_dir")
    if saved_bt and Path(saved_bt).exists():
        za = _find_tool_in_dir(Path(saved_bt), "zipalign")
        if za:
            return za

    _log(f"  Downloading Android build-tools {_ANDROID_BUILDTOOLS_VERSION}...")
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    zip_name = f"build-tools-r{_ANDROID_BUILDTOOLS_VERSION.replace('.', '-')}-windows.zip"
    zip_path = TOOLS_DIR / zip_name

    try:
        if not zip_path.exists():
            urllib.request.urlretrieve(_ANDROID_BUILDTOOLS_URL, str(zip_path))
            _log("  Build-tools download complete.")
        else:
            _log("  Using cached build-tools download.")

        bt_dir = TOOLS_DIR / "build-tools"
        _log("  Extracting build-tools...")
        with zipfile.ZipFile(str(zip_path), "r") as zf:
            zf.extractall(str(bt_dir))

        # Find the extracted directory
        found_za = None
        for item in bt_dir.iterdir():
            if item.is_dir():
                za = _find_tool_in_dir(item, "zipalign")
                if za:
                    found_za = za
                    cfg["build_tools_dir"] = str(item)
                    _save_config(cfg)
                    break

        if found_za:
            _log(f"  Build-tools ready at: {bt_dir}")
            return found_za

        _log("  WARNING: Build-tools extraction succeeded but zipalign not found.")
        return None

    except Exception as exc:
        _log(f"  ERROR downloading build-tools: {exc}")
        try:
            if zip_path.exists():
                zip_path.unlink()
        except Exception:
            pass
        return None


def _find_tool_in_dir(directory: Path, tool_name: str) -> Optional[str]:
    """Search for a tool executable recursively in a directory."""
    for item in directory.rglob(f"{tool_name}*"):
        if item.is_file() and item.suffix in (".exe", ".bat", ""):
            return str(item)
    return None


# ---------------------------------------------------------------------------
# Main pipeline
# ---------------------------------------------------------------------------

class RebuildResult:
    """Result of an APK rebuild operation."""

    def __init__(self) -> None:
        self.success = False
        self.output_apk: Optional[Path] = None
        self.error: str = ""
        self.steps: list[str] = []
        self.elapsed_ms: float = 0.0

    def add_step(self, msg: str) -> None:
        self.steps.append(msg)
        _log(msg)


def rebuild_apk(
    original_apk: Path,
    modified_files_dir: Path,
    output_dir: Path,
    log_callback: Optional[Callable[[str], None]] = None,
) -> RebuildResult:
    """Rebuild a signed APK from modified assets.

    Parameters
    ----------
    original_apk:
        Path to the original APK or XAPK file.
    modified_files_dir:
        Directory containing the user's modified files. These will be
        overlaid onto the decoded APK resources.
    output_dir:
        Where to write the final signed APK.
    log_callback:
        Optional logging function for progress messages.

    Returns
    -------
    RebuildResult with success status and output path.
    """
    if log_callback:
        set_logger(log_callback)

    result = RebuildResult()
    t0 = time.time()

    try:
        original_apk = Path(original_apk).resolve()
        modified_files_dir = Path(modified_files_dir).resolve()
        output_dir = Path(output_dir).resolve()
        output_dir.mkdir(parents=True, exist_ok=True)

        if not original_apk.exists():
            result.error = f"Original APK not found: {original_apk}"
            return result

        # Step 0: Ensure Java is available
        result.add_step("[1/8] Checking Java availability...")
        if not _ensure_java():
            result.error = (
                "Java is required for APK rebuild.\n"
                "Install JDK 8+ or let the tool download it automatically."
            )
            return result
        result.add_step("  Java OK.")

        # Step 1: Extract the inner APK if XAPK
        apk_to_decode = _extract_inner_apk(original_apk, output_dir)
        result.add_step(f"[2/8] APK identified: {apk_to_decode.name}")

        # Step 2: Decode with apktool
        decoded_dir = output_dir / "decoded_apk"
        if decoded_dir.exists():
            shutil.rmtree(decoded_dir)
        result.add_step("[3/8] Decoding APK with apktool...")
        if not _decode_apk(apk_to_decode, decoded_dir):
            result.error = "apktool decode failed."
            return result
        result.add_step("  Decode complete.")

        # Step 3: Copy modified files into decoded APK
        result.add_step("[4/8] Copying modified files into decoded APK...")
        _copy_modified_files(modified_files_dir, decoded_dir)
        result.add_step("  Files copied.")

        # Step 4: Repack with apktool
        unsigned_apk = output_dir / "unsigned.apk"
        result.add_step("[5/8] Repacking APK with apktool...")
        if not _repack_apk(decoded_dir, unsigned_apk):
            result.error = "apktool repack failed."
            return result
        result.add_step("  Repack complete.")

        # Step 5: Zipalign (required)
        aligned_apk = output_dir / "aligned.apk"
        result.add_step("[6/8] Aligning APK...")
        zipalign_path = _ensure_zipalign()
        if not zipalign_path:
            result.error = (
                "zipalign not found and could not be downloaded.\n"
                "Install Android SDK build-tools or let the tool download them."
            )
            return result
        if not _align_apk(unsigned_apk, aligned_apk, zipalign_path):
            result.error = "zipalign failed. The APK may not work correctly."
            return result
        result.add_step("  Alignment complete.")

        # Step 6: Generate debug keystore if needed
        result.add_step("[7/8] Preparing signing key...")
        if not _ensure_debug_keystore():
            result.error = "Could not generate debug keystore. Ensure keytool is available."
            return result
        result.add_step("  Keystore ready.")

        # Step 7: Sign with jarsigner
        signed_apk = output_dir / f"modded_{original_apk.stem}.apk"
        result.add_step("[8/8] Signing APK...")
        if not _sign_apk(aligned_apk, signed_apk):
            result.error = "APK signing failed. Ensure jarsigner is available."
            return result
        result.add_step("  Signing complete.")

        # Cleanup temp files
        for f in (unsigned_apk, aligned_apk):
            if f.exists() and f != signed_apk:
                try:
                    f.unlink()
                except OSError:
                    pass

        result.output_apk = signed_apk
        result.success = True
        result.add_step(f"\nAPK rebuild complete: {signed_apk}")

    except Exception as exc:
        result.error = f"Rebuild failed: {exc}"
        _log(f"ERROR: {exc}")

    result.elapsed_ms = (time.time() - t0) * 1000
    return result


# ---------------------------------------------------------------------------
# Internal helpers
# ---------------------------------------------------------------------------

def _extract_inner_apk(original_apk: Path, output_dir: Path) -> Path:
    """If the file is an XAPK, extract the main APK. Otherwise return as-is."""
    try:
        with zipfile.ZipFile(str(original_apk), "r") as zf:
            apk_files = [n for n in zf.namelist() if n.endswith(".apk")]
            if not apk_files:
                return original_apk
            main_apk = max(apk_files, key=lambda n: zf.getinfo(n).file_size)
            _log(f"  XAPK detected. Extracting main APK: {main_apk}")
            raw = zf.read(main_apk)
            extracted = output_dir / Path(main_apk).name
            extracted.write_bytes(raw)
            return extracted
    except (zipfile.BadZipFile, OSError):
        return original_apk


def _decode_apk(apk_path: Path, output_dir: Path) -> bool:
    """Use apktool to decode the APK into an editable folder."""
    if not _ensure_apktool():
        return False
    cmd = [
        "java", "-jar", str(APKTOOL_JAR),
        "d", str(apk_path),
        "-o", str(output_dir),
        "-f",
    ]
    r = _run(cmd, timeout=600)
    if r.returncode != 0:
        _log(f"  apktool decode error: {r.stderr[:500]}")
        return False
    return True


def _repack_apk(decoded_dir: Path, output_apk: Path) -> bool:
    """Use apktool to repack the decoded folder into an unsigned APK."""
    if not _ensure_apktool():
        return False
    cmd = [
        "java", "-jar", str(APKTOOL_JAR),
        "b", str(decoded_dir),
        "-o", str(output_apk),
    ]
    r = _run(cmd, timeout=600)
    if r.returncode != 0:
        _log(f"  apktool repack error: {r.stderr[:500]}")
        return False
    return True


def _copy_modified_files(src: Path, dst: Path) -> None:
    """Recursively copy modified files from src into the decoded APK dst."""
    if not src.exists():
        _log(f"  Warning: modified files directory not found: {src}")
        return

    count = 0
    for item in src.rglob("*"):
        if item.is_dir():
            continue
        rel = item.relative_to(src)
        target = dst / rel
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(str(item), str(target))
        count += 1
    _log(f"  Copied {count} modified file(s).")


def _align_apk(input_apk: Path, output_apk: Path, zipalign_path: str) -> bool:
    """Align the APK using zipalign."""
    cmd = [zipalign_path, "-f", "4", str(input_apk), str(output_apk)]
    r = _run(cmd, timeout=300)
    if r.returncode != 0:
        _log(f"  zipalign error: {r.stderr[:300]}")
        return False
    return True


def _ensure_debug_keystore() -> bool:
    """Generate a debug keystore if one doesn't exist yet."""
    if KEYSTORE_PATH.exists():
        return True
    keytool = _find_keytool()
    if not keytool:
        _log("  keytool not found. Cannot generate debug keystore.")
        return False
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    cmd = [
        keytool,
        "-genkeypair",
        "-v",
        "-keystore", str(KEYSTORE_PATH),
        "-alias", KEYSTORE_ALIAS,
        "-keyalg", "RSA",
        "-keysize", "2048",
        "-validity", "10000",
        "-storepass", KEYSTORE_PASS,
        "-keypass", KEYSTORE_PASS,
        "-dname", KEYSTORE_DNAME,
    ]
    r = _run(cmd, timeout=30)
    if r.returncode != 0:
        _log(f"  keytool error: {r.stderr[:300]}")
        return False
    _log(f"  Debug keystore generated: {KEYSTORE_PATH}")
    return True


def _sign_apk(input_apk: Path, output_apk: Path) -> bool:
    """Sign an APK using jarsigner."""
    jarsigner = _find_jarsigner()
    if not jarsigner:
        _log("  jarsigner not found. Cannot sign APK.")
        return False

    shutil.copy2(str(input_apk), str(output_apk))

    cmd = [
        jarsigner,
        "-verbose",
        "-sigalg", "SHA256withRSA",
        "-digestalg", "SHA-256",
        "-keystore", str(KEYSTORE_PATH),
        "-storepass", KEYSTORE_PASS,
        "-keypass", KEYSTORE_PASS,
        str(output_apk),
        KEYSTORE_ALIAS,
    ]
    r = _run(cmd, timeout=120)
    if r.returncode != 0:
        _log(f"  jarsigner error: {r.stderr[:300]}")
        return False
    return True
