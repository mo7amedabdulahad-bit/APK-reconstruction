"""APK Rebuild Pipeline.

Decodes APK with apktool, copies modified assets back in, repacks,
aligns, generates a debug keystore if needed, and signs with jarsigner.

All tools are auto-detected or auto-downloaded to a tools/ directory
next to the package root.
"""
from __future__ import annotations

import os
import shutil
import subprocess
import sys
import tempfile
import time
import urllib.request
import zipfile
from pathlib import Path
from typing import Callable, Optional


TOOLS_DIR = Path(__file__).resolve().parent.parent / "tools"
APKTOOL_JAR = TOOLS_DIR / "apktool.jar"
APKTOOL_URL = "https://bitbucket.org/iBotPeaches/apktool/downloads/apktool_2.9.3.jar"
KEYSTORE_PATH = TOOLS_DIR / "debug.keystore"
KEYSTORE_ALIAS = "androiddebugkey"
KEYSTORE_PASS = "android"
KEYSTORE_DNAME = "CN=Debug,OU=Debug,O=Debug,L=Debug,ST=Debug,C=US"

_log_fn: Callable[[str], None] = print


def set_logger(fn: Callable[[str], None]) -> None:
    global _log_fn
    _log_fn = fn


def _log(msg: str) -> None:
    _log_fn(msg)


def _run(cmd: list[str], cwd: Optional[str] = None, timeout: int = 600) -> subprocess.CompletedProcess:
    _log(f"  > {' '.join(cmd)}")
    return subprocess.run(
        cmd,
        capture_output=True,
        text=True,
        timeout=timeout,
        cwd=cwd,
        creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
    )


# ---------------------------------------------------------------------------
# Tool discovery / download
# ---------------------------------------------------------------------------

def _ensure_java() -> bool:
    """Check that java is available."""
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


def _ensure_apktool() -> bool:
    """Download apktool.jar if not present."""
    if APKTOOL_JAR.exists():
        return True
    if not _ensure_java():
        _log("WARNING: Java not found. apktool requires JDK/JRE to run.")
        _log("         Install JDK 8+ and ensure 'java' is on PATH.")
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


def _find_jarsigner() -> Optional[str]:
    """Find jarsigner on PATH or in JAVA_HOME."""
    # Try PATH first
    for name in ("jarsigner", "jarsigner.exe"):
        r = shutil.which(name)
        if r:
            return r
    # Try JAVA_HOME
    java_home = os.environ.get("JAVA_HOME", "")
    if java_home:
        candidate = Path(java_home) / "bin" / "jarsigner.exe"
        if candidate.exists():
            return str(candidate)
        candidate = Path(java_home) / "bin" / "jarsigner"
        if candidate.exists():
            return str(candidate)
    # Try common locations
    for base in (
        Path(os.environ.get("ProgramFiles", "")) / "Java",
        Path(os.environ.get("ProgramFiles(x86)", "")) / "Java",
        Path(os.environ.get("LOCALAPPDATA", "")) / "Programs",
    ):
        if not base.exists():
            continue
        for jdk in base.glob("jdk*"):
            js = jdk / "bin" / "jarsigner.exe"
            if js.exists():
                return str(js)
    return None


def _find_keytool() -> Optional[str]:
    """Find keytool on PATH or in JAVA_HOME."""
    for name in ("keytool", "keytool.exe"):
        r = shutil.which(name)
        if r:
            return r
    java_home = os.environ.get("JAVA_HOME", "")
    if java_home:
        candidate = Path(java_home) / "bin" / "keytool.exe"
        if candidate.exists():
            return str(candidate)
        candidate = Path(java_home) / "bin" / "keytool"
        if candidate.exists():
            return str(candidate)
    for base in (
        Path(os.environ.get("ProgramFiles", "")) / "Java",
        Path(os.environ.get("ProgramFiles(x86)", "")) / "Java",
    ):
        if not base.exists():
            continue
        for jdk in base.glob("jdk*"):
            kt = jdk / "bin" / "keytool.exe"
            if kt.exists():
                return str(kt)
    return None


def _find_zipalign() -> Optional[str]:
    """Find zipalign on PATH or in Android SDK build-tools."""
    for name in ("zipalign", "zipalign.exe"):
        r = shutil.which(name)
        if r:
            return r
    # Check Android SDK
    android_home = os.environ.get("ANDROID_HOME", "") or os.environ.get("ANDROID_SDK_ROOT", "")
    if android_home:
        build_tools = Path(android_home) / "build-tools"
        if build_tools.exists():
            versions = sorted([d for d in build_tools.iterdir() if d.is_dir()], reverse=True)
            for vdir in versions:
                za = vdir / "zipalign.exe"
                if za.exists():
                    return str(za)
                za = vdir / "zipalign"
                if za.exists():
                    return str(za)
    # Check common locations
    local_app = Path(os.environ.get("LOCALAPPDATA", "")) / "Android" / "Sdk" / "build-tools"
    if local_app.exists():
        versions = sorted([d for d in local_app.iterdir() if d.is_dir()], reverse=True)
        for vdir in versions:
            za = vdir / "zipalign.exe"
            if za.exists():
                return str(za)
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

        # Step 1: Extract the inner APK if XAPK
        apk_to_decode = _extract_inner_apk(original_apk, output_dir)
        result.add_step(f"[1/7] APK identified: {apk_to_decode.name}")

        # Step 2: Decode with apktool
        decoded_dir = output_dir / "decoded_apk"
        if decoded_dir.exists():
            shutil.rmtree(decoded_dir)
        result.add_step("[2/7] Decoding APK with apktool...")
        if not _decode_apk(apk_to_decode, decoded_dir):
            result.error = "apktool decode failed. Ensure Java JDK 8+ is installed."
            return result
        result.add_step("  Decode complete.")

        # Step 3: Copy modified files into decoded APK
        result.add_step("[3/7] Copying modified files into decoded APK...")
        _copy_modified_files(modified_files_dir, decoded_dir)
        result.add_step("  Files copied.")

        # Step 4: Repack with apktool
        unsigned_apk = output_dir / "unsigned.apk"
        result.add_step("[4/7] Repacking APK with apktool...")
        if not _repack_apk(decoded_dir, unsigned_apk):
            result.error = "apktool repack failed."
            return result
        result.add_step("  Repack complete.")

        # Step 5: Zipalign
        aligned_apk = output_dir / "aligned.apk"
        result.add_step("[5/7] Aligning APK...")
        if not _align_apk(unsigned_apk, aligned_apk):
            # If zipalign not found, use unsigned directly
            result.add_step("  zipalign not found, using unaligned APK.")
            aligned_apk = unsigned_apk
        else:
            result.add_step("  Alignment complete.")

        # Step 6: Generate debug keystore if needed
        result.add_step("[6/7] Preparing signing key...")
        if not _ensure_debug_keystore():
            result.error = "Could not generate debug keystore. Ensure keytool is available."
            return result
        result.add_step("  Keystore ready.")

        # Step 7: Sign with jarsigner
        signed_apk = output_dir / f"modded_{original_apk.stem}.apk"
        result.add_step("[7/7] Signing APK...")
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
            # Pick the largest APK as the main one
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
        "-f",  # force overwrite
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
    """Recursively copy modified files from src into the decoded APK dst.

    Files from src overwrite existing files in dst. New files are added.
    """
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


def _align_apk(input_apk: Path, output_apk: Path) -> bool:
    """Align the APK using zipalign."""
    zipalign = _find_zipalign()
    if not zipalign:
        _log("  zipalign not found on PATH or in Android SDK.")
        return False
    cmd = [zipalign, "-f", "4", str(input_apk), str(output_apk)]
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

    # Copy to output location first
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
