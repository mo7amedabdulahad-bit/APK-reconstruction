#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — app.py v22

v22: Merged UnityPy environment for cross-bundle sprite resolution.
     _run_stage4_ui_dump now loads ALL files into a single environment so
     cross-bundle PPtrs resolve natively.  Unresolved refs produce explicit
     {"unresolved": true, ...} dicts instead of null.
  1. DOWNLOAD FIX — urllib now sends a User-Agent header (GitHub blocks
     urlretrieve which sends no UA). Uses urllib.request.Request + urlopen.
  2. METADATA v39 FIX — Before running Il2CppDumper, writes a config.json
     next to the exe with ForceDump=true + ForceIl2CppVersion=true so the
     tool bypasses the "not a supported version" check for metadata v39.
  3. MANUAL PATH FALLBACK — GUI restores the Il2CppDumper path field.
     Priority order: (a) manual path if set, (b) auto-download, (c) skip.
     Path is saved to config.json between runs.
"""
from __future__ import annotations

import base64
import hashlib
import io
import json
import os
import os as _os
import queue
import shutil
import struct
import subprocess
from types import SimpleNamespace
import sys
import threading
import time
import urllib.request
import zipfile
from pathlib import Path


def _ensure_site_packages():
    """If optional imports are failing, try adding real Python site-packages."""
    try:
        import UnityPy.helpers.TypeTreeGenerator  # noqa: F401
        return  # already available
    except ImportError:
        pass

    if sys.platform != "win32":
        return

    # Locate the real Python 3.13+ that has packages installed
    pf   = Path(os.environ.get("ProgramFiles",    r"C:\Program Files"))
    la   = Path(os.environ.get("LOCALAPPDATA",    r"C:\Users\Default\AppData\Local"))
    user = Path(os.environ.get("USERPROFILE",     r"C:\Users\Default"))
    search_roots = [
        pf / "Python*",
        pf / "Programs" / "Python" / "Python*",
        la / "Programs" / "Python" / "Python*",
        user / "AppData" / "Local" / "Programs" / "Python" / "Python*",
    ]
    for pattern in search_roots:
        for d in sorted(Path(pattern.parent).glob(pattern.name), reverse=True):
            site = d / "Lib" / "site-packages"
            if not site.exists():
                continue
            # Verify it has the packages we need
            if (site / "addressablestools").is_dir() or (site / "UnityPy" / "helpers" / "TypeTreeGenerator.py").exists():
                if str(site) not in sys.path:
                    sys.path.insert(0, str(site))
                    print(f"[INFO ] Added site-packages: {site}")


_ensure_site_packages()


from il2cpp_recovery_studio.gui.sprite_resolver import (
    build_global_env,
    build_global_sprite_index,
    write_sprite_mapping_report,
)
from il2cpp_recovery_studio.gui.ai_ui_compiler import run_ui_compiler

import customtkinter as ctk
from tkinter import filedialog, messagebox

try:
    from PIL import Image as PILImage
except ImportError:
    PILImage = None  # type: ignore

BG_DEEP   = "#0a0a0f"; BG_CARD  = "#111128"; BG_PANEL = "#0d0d22"
NEON_CYAN = "#00ffe7"; NEON_PURP = "#bf80ff"; NEON_GREEN  = "#00ff88"
NEON_PINK = "#ff4488"; NEON_YEL  = "#ffe040"; NEON_ORANGE = "#ff9933"
TEXT_WHITE = "#ffffff"; TEXT_BRIGHT = "#e8f0ff"; TEXT_DIM = "#8888bb"
BTN_HOVER  = "#1e1e44"
FNT_TITLE  = ("Segoe UI", 18, "bold"); FNT_HEAD  = ("Segoe UI", 14, "bold")
FNT_BODY   = ("Segoe UI", 13, "bold"); FNT_SMALL = ("Segoe UI", 11)
FNT_MONO   = ("Courier New", 12);      FNT_MONO_B = ("Courier New", 12, "bold")
FNT_RUN    = ("Segoe UI", 16, "bold")

APKTOOL_VER = "3.0.2"
APKTOOL_URL = (
    f"https://github.com/iBotPeaches/Apktool/releases/download/"
    f"v{APKTOOL_VER}/apktool_{APKTOOL_VER}.jar"
)

IL2CPPDUMPER_VER      = "v6.7.46"
IL2CPPDUMPER_ZIP_NAME = f"Il2CppDumper-net6-win-{IL2CPPDUMPER_VER}.zip"
IL2CPPDUMPER_URL = (
    f"https://github.com/Perfare/Il2CppDumper/releases/download/"
    f"{IL2CPPDUMPER_VER}/{IL2CPPDUMPER_ZIP_NAME}"
)

# config.json written beside Il2CppDumper.exe to bypass metadata version check
IL2CPP_FORCE_CONFIG = {
    "DumpMethod":           True,
    "DumpField":            True,
    "DumpProperty":         True,
    "DumpAttribute":        True,
    "DumpFieldOffset":      True,
    "DumpMethodOffset":     True,
    "DumpTypeDefIndex":     True,
    "DummyDll":             True,
    "MakeFunction":         True,
    "ForceIl2CppVersion":   True,
    "ForceVersion":         31,
    "ForceDump":            True,
}

TOOLS_DIR        = Path(__file__).parent / "tools"
CONFIG_FILE      = TOOLS_DIR / "config.json"
APKTOOL_TIMEOUT  = 3600
JVM_HEAP_FLAGS   = ["-Xmx2g", "-Xms256m"]
HEARTBEAT_INTERVAL = 30

REPO_ROOT     = Path(__file__).resolve().parent.parent.parent
PARSER_SCRIPT = REPO_ROOT / "scripts" / "parse-unity-bundle.mjs"

DL_HEADERS = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) IL2CPP-Recovery-Studio/20"
}



_PURPOSE_HINTS: list[tuple[list[str], str]] = [
    (["lobby", "main_menu", "mainmenu", "home"],                  "Main Menu / Lobby"),
    (["village", "map", "world"],                                  "Village / World Map"),
    (["battle", "combat", "fight", "attack"],                     "Battle / Combat Screen"),
    (["hero", "portrait", "avatar"],                              "Hero / Character Screen"),
    (["building", "construction", "upgrade"],                     "Building / Construction UI"),
    (["resource", "field", "farm", "lumber", "clay", "iron", "crop"], "Resource Field"),
    (["unit", "troop", "army", "soldier"],                        "Troop / Army Screen"),
    (["hud", "header", "statusbar"],                              "HUD / Status Bar"),
    (["popup", "dialog", "modal", "alert", "confirm"],            "Popup / Dialog"),
    (["settings", "option", "config"],                            "Settings Screen"),
    (["login", "splash", "loading", "intro"],                     "Login / Loading Screen"),
    (["shop", "store", "premium", "gold", "purchase"],            "Shop / Store"),
    (["quest", "task", "mission", "daily"],                       "Quest / Mission Screen"),
    (["chat", "message", "mail", "inbox"],                        "Chat / Messaging"),
    (["alliance", "clan", "tribe"],                               "Alliance Screen"),
    (["ranking", "leaderboard", "score"],                         "Ranking / Leaderboard"),
    (["tutorial", "guide", "onboard"],                            "Tutorial / Onboarding"),
]


def _guess_purpose(names: list[str]) -> str:
    combined = " ".join(names).lower()
    for keywords, label in _PURPOSE_HINTS:
        if any(k in combined for k in keywords):
            return label
    return "Unknown / Generic"


# ── config helpers ───────────────────────────────────────────────────────────
def _load_config() -> dict:
    if CONFIG_FILE.exists():
        try:
            return json.loads(CONFIG_FILE.read_text(encoding="utf-8"))
        except Exception:
            pass
    return {}


def _save_config(cfg: dict):
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    CONFIG_FILE.write_text(json.dumps(cfg, indent=2, ensure_ascii=False), encoding="utf-8")


# ── general helpers ──────────────────────────────────────────────────────────
def _count_files(path: Path) -> int:
    return sum(1 for p in path.rglob("*") if p.is_file()) if path.exists() else 0


def _wipe_dir(path: Path):
    if path.exists():
        shutil.rmtree(path, ignore_errors=True)
    path.mkdir(parents=True, exist_ok=True)


def _safe_name(raw: str, fallback: str = "unnamed") -> str:
    s = "".join(c if c.isalnum() or c in " _-." else "_" for c in str(raw)).strip()
    return s or fallback


def _unique_path(dest: Path, stem: str, ext: str) -> Path:
    p = dest / f"{stem}{ext}"
    if not p.exists():
        return p
    i = 2
    while True:
        p = dest / f"{stem}_{i}{ext}"
        if not p.exists():
            return p
        i += 1


def _skip_path(dest: Path, stem: str, ext: str) -> Path | None:
    p = dest / f"{stem}{ext}"
    return p if p.exists() else None


# ── download helper (with User-Agent) ────────────────────────────────────────
def _download(url: str, dest: Path, log) -> bool:
    """
    Download url -> dest using a proper User-Agent so GitHub doesn't block us.
    Returns True on success.
    """
    log(f"[INFO ] Downloading {dest.name}…")
    try:
        req = urllib.request.Request(url, headers=DL_HEADERS)
        with urllib.request.urlopen(req, timeout=120) as resp, open(dest, "wb") as f:
            chunk_size = 65536
            total = 0
            while True:
                chunk = resp.read(chunk_size)
                if not chunk:
                    break
                f.write(chunk)
                total += len(chunk)
        log(f"[OK   ] Downloaded {dest.name} ({total // 1024} KB)")
        return True
    except Exception as exc:
        log(f"[ERROR] Download failed for {dest.name}: {exc}")
        if dest.exists():
            dest.unlink(missing_ok=True)
        return False


# ── Java discovery ───────────────────────────────────────────────────────────
def _java_works(path: Path | str) -> bool:
    try:
        r = subprocess.run([str(path), "-version"], capture_output=True, timeout=8)
        return r.returncode == 0
    except Exception:
        return False


def _find_java_from_registry() -> Path | None:
    if sys.platform != "win32":
        return None
    hives = ["HKLM", "HKCU"]
    keys = [
        r"SOFTWARE\JavaSoft\JDK",
        r"SOFTWARE\JavaSoft\Java Development Kit",
        r"SOFTWARE\JavaSoft\JRE",
        r"SOFTWARE\JavaSoft\Java Runtime Environment",
        r"SOFTWARE\WOW6432Node\JavaSoft\JDK",
        r"SOFTWARE\WOW6432Node\JavaSoft\Java Development Kit",
        r"SOFTWARE\WOW6432Node\JavaSoft\JRE",
        r"SOFTWARE\WOW6432Node\JavaSoft\Java Runtime Environment",
        r"SOFTWARE\Eclipse Adoptium\JDK",
        r"SOFTWARE\Eclipse Adoptium\JRE",
        r"SOFTWARE\Eclipse Foundation\JDK",
        r"SOFTWARE\Semeru\JDK",
        r"SOFTWARE\Amazon\Corretto\JDK",
    ]
    for hive in hives:
        for key in keys:
            full = f"{hive}\\{key}"
            try:
                r = subprocess.run(["reg", "query", full, "/s"],
                                   capture_output=True, text=True,
                                   encoding="utf-8", errors="replace", timeout=10)
                if r.returncode != 0:
                    continue
                for line in r.stdout.splitlines():
                    if "JavaHome" in line or "InstallDir" in line:
                        parts = line.split()
                        if parts:
                            home = Path(parts[-1].strip())
                            cand = home / "bin" / "java.exe"
                            if cand.exists():
                                return cand
            except Exception:
                pass
    return None


def _find_java(override: str | Path | None = None) -> Path | str | None:
    if override:
        p = Path(override)
        if p.exists() and _java_works(p):
            return p
    j = shutil.which("java")
    if j and _java_works(j):
        return j
    java_home = os.environ.get("JAVA_HOME")
    if java_home:
        cand = Path(java_home) / "bin" / ("java.exe" if sys.platform == "win32" else "java")
        if cand.exists() and _java_works(cand):
            return cand
    if sys.platform == "win32":
        reg = _find_java_from_registry()
        if reg and _java_works(reg):
            return reg
        pf   = Path(os.environ.get("ProgramFiles",        r"C:\Program Files"))
        pf86 = Path(os.environ.get("ProgramFiles(x86)",   r"C:\Program Files (x86)"))
        la   = Path(os.environ.get("LOCALAPPDATA",         r"C:\Users\Default\AppData\Local"))
        user = Path(os.environ.get("USERPROFILE",          r"C:\Users\Default"))
        roots = [
            pf / "Java", pf / "Eclipse Adoptium", pf / "AdoptOpenJDK",
            pf / "Microsoft", pf / "Zulu", pf / "BellSoft",
            pf / "Amazon Corretto", pf / "Semeru",
            pf86 / "Java", pf86 / "Eclipse Adoptium",
            la / "Programs" / "Eclipse Adoptium",
            la / "Programs" / "Microsoft" / "jdk",
            user / "scoop" / "shims",
            Path(r"C:\ProgramData\chocolatey\bin"),
            Path(r"C:\tools\jdk"), Path(r"C:\java"),
        ]
        for root in roots:
            if root.exists():
                for cand in sorted(root.rglob("java.exe"), reverse=True):
                    if _java_works(cand):
                        return cand
    return None


# ── Node.js discovery ────────────────────────────────────────────────────────
def _find_node() -> str | None:
    for candidate in ("node", "node.exe", "nodejs"):
        path = shutil.which(candidate)
        if path:
            try:
                r = subprocess.run([path, "--version"], capture_output=True, timeout=8)
                if r.returncode == 0:
                    return path
            except Exception:
                pass
    if sys.platform == "win32":
        pf   = Path(os.environ.get("ProgramFiles",  r"C:\Program Files"))
        la   = Path(os.environ.get("LOCALAPPDATA",   r"C:\Users\Default\AppData\Local"))
        user = Path(os.environ.get("USERPROFILE",    r"C:\Users\Default"))
        candidates = [
            pf   / "nodejs" / "node.exe",
            la   / "Programs" / "nodejs" / "node.exe",
            user / "scoop" / "shims" / "node.exe",
            Path(r"C:\ProgramData\chocolatey\bin\node.exe"),
            Path(r"C:\tools\nodejs\node.exe"),
        ]
        for cand in candidates:
            if cand.exists():
                try:
                    r = subprocess.run([str(cand), "--version"], capture_output=True, timeout=8)
                    if r.returncode == 0:
                        return str(cand)
                except Exception:
                    pass
    return None


def _find_unity_data_dir(raw_dir: Path) -> Path | None:
    """Find the Unity data directory containing assets/bin/Data.

    Handles various XAPK/APK extraction structures:
    - raw/<apk_stem>/assets/bin/Data (expected)
    - raw/UnityDataAssetPack/assets/bin/Data (actual Google Play XAPK)
    - raw/*/assets/bin/Data (fallback)

    Returns the directory CONTAINING assets/bin/Data (i.e., the dir with assets/ subdir)
    """
    # 1. Check expected location (raw/<apk_stem>/assets/bin/Data)
    for stem_dir in raw_dir.iterdir():
        if stem_dir.is_dir():
            candidate = stem_dir / "assets" / "bin" / "Data"
            if candidate.exists():
                return stem_dir  # Return the dir containing assets/

    # 2. Check UnityDataAssetPack (common for Google Play XAPKs)
    unity_pack = raw_dir / "UnityDataAssetPack"
    if unity_pack.exists():
        candidate = unity_pack / "assets" / "bin" / "Data"
        if candidate.exists():
            return unity_pack

    # 3. Fallback: search all subdirs
    for candidate in raw_dir.rglob("assets/bin/Data"):
        if candidate.exists():
            return candidate.parent.parent  # Return the dir containing assets/

    return None


# ── apktool download ─────────────────────────────────────────────────────────
def _ensure_apktool(log) -> Path | None:
    jar = TOOLS_DIR / f"apktool_{APKTOOL_VER}.jar"
    if jar.exists():
        return jar
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    if not _download(APKTOOL_URL, jar, log):
        return None
    (TOOLS_DIR / "apktool.bat").write_text(
        f"@echo off\njava {' '.join(JVM_HEAP_FLAGS)} -jar \"{jar}\" %*\n",
        encoding="utf-8",
    )
    return jar


# ── Il2CppDumper: resolve exe (manual -> local v39 -> auto-download -> None) ────────────────
def _ensure_il2cppdumper(log, manual_path: str | None = None) -> Path | None:
    """
    Priority:
      1. manual_path  — if set and exe exists, use it directly.
      2. local v39 version at tools/Il2CppDumper-win-x64-net8-v39/ — supports metadata v39.
      3. auto-download into tools/il2cppdumper/ — cached after first run.
      4. None — warn and skip Stage 4a.

    Also writes IL2CPP_FORCE_CONFIG next to the resolved exe so that
    metadata version 29–39+ is accepted via ForceDump / ForceVersion.
    """
    # 1. Manual override
    if manual_path and manual_path.strip():
        mp = Path(manual_path.strip())
        if mp.is_file() and mp.suffix.lower() == ".exe":
            log(f"[INFO ] Il2CppDumper — using manual path: {mp}")
            _write_il2cpp_config(mp.parent, log)
            return mp
        else:
            log(f"[WARN ] Il2CppDumper manual path not valid ({mp}) — falling back to local v39 version")

    # 2. Local v39-compatible version (supports metadata v39 natively)
    local_v39 = TOOLS_DIR.parent / "tools" / "Il2CppDumper-win-x64-net8-v39" / "Il2CppDumper.exe"
    if local_v39.is_file():
        log(f"[INFO ] Il2CppDumper — using local v39 version: {local_v39}")
        _write_il2cpp_config(local_v39.parent, log)
        return local_v39

    # 3. Auto-download (fallback to v6.7.46 for older metadata versions)
    il2cpp_dir = TOOLS_DIR / "il2cppdumper"
    # search for exe that may already be there (any subfolder)
    existing = list(il2cpp_dir.rglob("Il2CppDumper.exe")) if il2cpp_dir.exists() else []
    if existing:
        exe = existing[0]
        log(f"[INFO ] Il2CppDumper already present: {exe}")
        _write_il2cpp_config(exe.parent, log)
        return exe

    log(f"[INFO ] Il2CppDumper not found — auto-downloading {IL2CPPDUMPER_VER}…")
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    zip_path = TOOLS_DIR / IL2CPPDUMPER_ZIP_NAME

    if not _download(IL2CPPDUMPER_URL, zip_path, log):
        log("[WARN ] Auto-download failed. Set the path manually in the GUI.")
        return None

    try:
        il2cpp_dir.mkdir(parents=True, exist_ok=True)
        with zipfile.ZipFile(zip_path, "r") as z:
            z.extractall(il2cpp_dir)
        zip_path.unlink(missing_ok=True)
        log(f"[OK   ] Il2CppDumper extracted -> {il2cpp_dir}")
    except Exception as exc:
        log(f"[ERROR] Extraction failed: {exc}")
        return None

    candidates = list(il2cpp_dir.rglob("Il2CppDumper.exe"))
    if not candidates:
        log(f"[ERROR] Il2CppDumper.exe not found after extraction in {il2cpp_dir}")
        return None

    exe = candidates[0]
    log(f"[OK   ] Il2CppDumper ready -> {exe}")
    _write_il2cpp_config(exe.parent, log)
    return exe


def _write_il2cpp_config(exe_dir: Path, log):
    """
    Write config.json next to Il2CppDumper.exe.
    ForceDump=true + ForceVersion=31 bypasses the metadata version check
    so metadata v29–v39 (Unity 2019–2023+) is accepted.
    """
    cfg_path = exe_dir / "config.json"
    try:
        cfg_path.write_text(
            json.dumps(IL2CPP_FORCE_CONFIG, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )
        log(f"[INFO ] Il2CppDumper config.json written (ForceDump=true, ForceVersion=31)")
    except Exception as exc:
        log(f"[WARN ] Could not write Il2CppDumper config.json: {exc}")


# ── apktool heartbeat ────────────────────────────────────────────────────────
def _apktool_heartbeat(proc, smali_dir: Path, log, stop_evt: threading.Event):
    t0 = time.time()
    while not stop_evt.wait(timeout=HEARTBEAT_INTERVAL):
        if proc.poll() is not None:
            break
        elapsed = int(time.time() - t0)
        count   = _count_files(smali_dir)
        log(f"[INFO ] apktool still running… {elapsed}s elapsed, {count} smali files written so far")


# ── XAPK / APK extraction ────────────────────────────────────────────────────
def _extract_xapk(src: Path, raw_dir: Path, log, force: bool):
    if raw_dir.exists() and not force:
        n = _count_files(raw_dir)
        log(f"[SKIP ] raw/ already exists ({n} files) — skipping XAPK extraction")
        return
    log("[INFO ] Force refresh — rebuilding raw/")
    _wipe_dir(raw_dir)
    suffix = src.suffix.lower()
    if suffix == ".xapk":
        log("[INFO ] XAPK — extracting outer archive…")
        with zipfile.ZipFile(src, "r") as z:
            for name in z.namelist():
                if not name.endswith(".apk"):
                    continue
                stem = Path(name).stem
                dest = raw_dir / stem
                dest.mkdir(parents=True, exist_ok=True)
                with z.open(name) as src_f, zipfile.ZipFile(src_f) as inner:
                    inner.extractall(dest)
                log(f"[OK   ]   {name} -> {stem}/")
    else:
        stem = src.stem
        dest = raw_dir / stem
        dest.mkdir(parents=True, exist_ok=True)
        with zipfile.ZipFile(src, "r") as z:
            z.extractall(dest)
        log(f"[OK   ]   {src.name} -> {stem}/")


# ── Unity-asset extraction (PNGs / text) ─────────────────────────────────────
def _dump_env(env, dest: Path, log, force: bool, seen: set | None = None) -> tuple[int, int]:
    written = skipped = 0
    for obj in env.objects:
        try:
            data = obj.read()
        except Exception:
            continue
        name = getattr(data, "m_Name", "") or f"{obj.type.name}_{obj.path_id}"
        stem = _safe_name(name)
        t    = obj.type.name
        if t == "Texture2D":
            if not force and _skip_path(dest, stem, ".png"):
                skipped += 1; continue
            try:
                img = data.image
                if img:
                    # Render once to PNG bytes so identical images can be
                    # deduplicated by content. The same texture often ships in
                    # both the main APK and expansion packs (and in split
                    # bundles); the old code extracted it into every scene
                    # folder, producing thousands of byte-identical duplicate
                    # PNGs. Keeping each unique image once is safe because the
                    # AI resolves sprites by name across the whole tree.
                    buf = io.BytesIO()
                    img.save(buf, format="PNG")
                    raw = buf.getvalue()
                    if seen is not None:
                        h = hashlib.md5(raw).hexdigest()
                        if h in seen:
                            skipped += 1; continue
                        seen.add(h)
                    out = _unique_path(dest, stem, ".png") if force else dest / f"{stem}.png"
                    out.parent.mkdir(parents=True, exist_ok=True)
                    out.write_bytes(raw); written += 1
            except Exception: pass
        elif t == "Sprite":
            if not force and _skip_path(dest, stem, ".png"):
                skipped += 1; continue
            try:
                img = data.image
                if img:
                    buf = io.BytesIO()
                    img.save(buf, format="PNG")
                    raw = buf.getvalue()
                    if seen is not None:
                        h = hashlib.md5(raw).hexdigest()
                        if h in seen:
                            skipped += 1; continue
                        seen.add(h)
                    out = _unique_path(dest, stem, ".png") if force else dest / f"{stem}.png"
                    out.parent.mkdir(parents=True, exist_ok=True)
                    out.write_bytes(raw); written += 1
            except Exception: pass
        elif t == "TextAsset":
            script = getattr(data, "m_Script", "") or ""
            raw    = script.encode() if isinstance(script, str) else (script if isinstance(script, bytes) else b"")
            if not raw: continue
            ext = ".json" if raw[:1] in (b"{", b"[") else ".txt"
            if not force and _skip_path(dest, stem, ext):
                skipped += 1; continue
            out = _unique_path(dest, stem, ext) if force else dest / f"{stem}{ext}"
            out.parent.mkdir(parents=True, exist_ok=True)
            out.write_bytes(raw); written += 1
        elif t == "AudioClip":
            if not force and _skip_path(dest, stem, ".wav"):
                skipped += 1; continue
            try:
                for name, sample_data in data.samples.items():
                    out = _unique_path(dest, stem, ".wav") if force else dest / f"{stem}.wav"
                    out.parent.mkdir(parents=True, exist_ok=True)
                    out.write_bytes(sample_data); written += 1
            except Exception: pass
        elif t == "MonoBehaviour":
            if not force and _skip_path(dest, stem, ".json"):
                skipped += 1; continue
            try:
                out = _unique_path(dest, stem, ".json") if force else dest / f"{stem}.json"
                out.parent.mkdir(parents=True, exist_ok=True)
                out.write_text(json.dumps({"name": name, "type": t}, indent=2, ensure_ascii=False), encoding="utf-8")
                written += 1
            except Exception: pass
    return written, skipped


# ── AI export helpers ────────────────────────────────────────────────────────
def _build_ai_scene_map(unity_dir: Path) -> list[dict]:
    scenes: list[dict] = []
    if not unity_dir.exists():
        return scenes
    for child in sorted(unity_dir.iterdir()):
        if not child.is_dir(): continue
        files      = list(child.rglob("*"))
        file_names = [f.name for f in files if f.is_file()]
        type_counts: dict[str, int] = {}
        sprites: list[str] = []; textures: list[str] = []
        for f in files:
            if not f.is_file(): continue
            ext = f.suffix.lower()
            type_counts[ext] = type_counts.get(ext, 0) + 1
            if ext == ".png":
                (sprites if "sprite" in f.parent.name.lower() else textures).append(f.name)
        scenes.append({
            "scene_dir":       child.name,
            "guessed_purpose": _guess_purpose([child.name] + file_names),
            "total_files":     len(file_names),
            "type_counts":     type_counts,
            "sample_sprites":  sprites[:20],
            "sample_textures": textures[:20],
            "all_file_names":  file_names,
        })
    return scenes


def _build_ai_asset_index(output_dir: Path) -> list[dict]:
    index: list[dict] = []
    if not output_dir.exists(): return index
    for f in sorted(output_dir.rglob("*")):
        if not f.is_file(): continue
        rel = f.relative_to(output_dir).as_posix()
        index.append({"path": rel, "name": f.stem, "ext": f.suffix.lower(), "size_bytes": f.stat().st_size})
    return index


# ── smali decompile ──────────────────────────────────────────────────────────
def _run_smali(apk_path, smali_dir, java_bin, apktool_jar, log, force, thread_count=8):
    dest = smali_dir / apk_path.stem
    if dest.exists() and not force:
        log(f"[SKIP ] smali/{apk_path.stem}/ already exists ({_count_files(dest)} files) — skipping apktool.")
        return
    if dest.exists(): shutil.rmtree(dest, ignore_errors=True)
    dest.mkdir(parents=True, exist_ok=True)
    cmd = [str(java_bin), *JVM_HEAP_FLAGS, "-jar", str(apktool_jar),
           "d", str(apk_path), "-o", str(dest), "-f", "--jobs", str(thread_count)]
    log(f"[INFO ] Running apktool on: {apk_path.name}  (timeout {APKTOOL_TIMEOUT}s)")
    stop_evt = threading.Event()
    try:
        proc = subprocess.Popen(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT,
                                text=True, encoding="utf-8", errors="replace")
        hb = threading.Thread(target=_apktool_heartbeat, args=(proc, dest, log, stop_evt), daemon=True)
        hb.start()
        assert proc.stdout
        for line in proc.stdout:
            line = line.rstrip()
            if line: log(f"[INFO ] I: {line}")
        proc.wait(timeout=APKTOOL_TIMEOUT)
        stop_evt.set(); hb.join(timeout=5)
        if proc.returncode == 0:
            log(f"[OK   ] apktool finished — {_count_files(dest)} smali files")
        else:
            log(f"[ERROR] apktool exited with code {proc.returncode}")
    except subprocess.TimeoutExpired:
        stop_evt.set(); proc.kill()
        log(f"[ERROR] apktool timed out after {APKTOOL_TIMEOUT}s")
    except Exception as exc:
        stop_evt.set()
        log(f"[ERROR] apktool failed: {exc}")


# ────────────────────────────────────────────────────────────────────────────
# STAGE 4a — Resolve + run Il2CppDumper -> DummyDll + script.json
# ────────────────────────────────────────────────────────────────────────────

def _run_stage4a_il2cppdumper(
    il2cpp_dir: Path,
    out_dir:    Path,
    log,
    manual_exe_path: str | None = None,
) -> Path | None:
    dump_dir    = out_dir / "il2cpp_dump"
    script_json = dump_dir / "script.json"
    dll_dir     = dump_dir / "DummyDll"

    if script_json.exists() and dll_dir.exists() and any(dll_dir.glob("*.dll")):
        dll_count = len(list(dll_dir.glob("*.dll")))
        log(f"[SKIP ] il2cpp_dump/ already exists ({dll_count} DLLs + script.json) — skipping Stage 4a")
        return dump_dir

    so_file   = next(il2cpp_dir.glob("*libil2cpp.so"), None)
    meta_file = il2cpp_dir / "global-metadata.dat"

    if not so_file or not meta_file.exists():
        log("[WARN ] il2cpp_meta/ missing libil2cpp.so or global-metadata.dat — skipping Stage 4a")
        return None

    exe = _ensure_il2cppdumper(log, manual_path=manual_exe_path)
    if exe is None:
        log("[WARN ] Il2CppDumper not available — Stage 4a skipped.")
        log("[INFO ] Set the Il2CppDumper.exe path in the GUI field and re-run.")
        return None

    log(f"[STEP ] Stage 4a — Generating IL2CPP type trees ({IL2CPPDUMPER_VER})…")
    log(f"[INFO ] libil2cpp : {so_file.name}")
    log(f"[INFO ] metadata  : {meta_file.name}")
    log(f"[INFO ] exe       : {exe}")
    dump_dir.mkdir(parents=True, exist_ok=True)

    cmd = [str(exe), str(so_file), str(meta_file), str(dump_dir)]
    try:
        proc = subprocess.Popen(
            cmd,
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            stdin=subprocess.PIPE,
            text=True, encoding="utf-8", errors="replace",
        )
        # Send "0\n" to stdin to auto-answer the "force continue" prompt,
        # then capture all output. This avoids the deadlock where the process
        # waits for stdin while we're blocked reading stdout.
        # Use explicit write/flush first to ensure input is sent immediately
        if proc.stdin:
            proc.stdin.write("0\n")
            proc.stdin.flush()
        stdout_data, _ = proc.communicate(timeout=300)

        for line in stdout_data.splitlines():
            line = line.rstrip()
            if line:
                log(f"[INFO ] Il2CppDumper: {line}")

        if proc.returncode == 0 and script_json.exists():
            dll_count = len(list(dll_dir.glob("*.dll"))) if dll_dir.exists() else 0
            log(f"[OK   ] Stage 4a complete — {dll_count} DummyDlls + script.json -> {dump_dir}")
            return dump_dir
        else:
            log(f"[WARN ] Il2CppDumper exited {proc.returncode} or script.json missing — "
                f"MonoBehaviours will fall back to raw bytes")
            # Partial success: if script.json was created despite non-zero exit, still use it
            if script_json.exists():
                log("[INFO ] script.json found despite non-zero exit — using it")
                return dump_dir
            return None
    except subprocess.TimeoutExpired:
        proc.kill()
        log("[ERROR] Il2CppDumper timed out after 300s")
        return None
    except Exception as exc:
        log(f"[ERROR] Il2CppDumper failed: {exc}")
        return None


# ────────────────────────────────────────────────────────────────────────────
# STAGE 4 — Full UnityPy UI field extraction (v20)
# ────────────────────────────────────────────────────────────────────────────

WANT_TYPES = {
    "GameObject", "Transform", "RectTransform",
    "Canvas", "CanvasScaler", "CanvasGroup", "GraphicRaycaster", "CanvasRenderer",
    "Image", "RawImage", "Text",
    "TextMeshProUGUI", "TMP_Text",
    "Button", "Toggle", "Slider", "ScrollRect",
    "InputField", "TMP_InputField",
    "Mask", "RectMask2D",
    "HorizontalLayoutGroup", "VerticalLayoutGroup",
    "GridLayoutGroup", "LayoutElement", "ContentSizeFitter",
    "AspectRatioFitter",
    "Sprite", "Texture2D", "SpriteAtlas",
    "MonoBehaviour", "MonoScript", "Font", "TMP_FontAsset",
    "Animator", "AnimationClip", "AnimatorController", "AnimatorOverrideController",
    "TextAsset", "AudioClip",
}


def _sg(obj, field, default=None):
    try:
        return getattr(obj, field, default)
    except Exception:
        return default


def _pptr(obj, sprite_index=None, current_file=""):
    if obj is None:
        return None
    try:
        pid  = getattr(obj, "path_id", None)
        fid  = getattr(obj, "file_id", None)
        name = None
        if hasattr(obj, "read"):
            try:
                read = obj.read()
                name = getattr(read, "m_Name", None) or getattr(read, "name", None)
            except Exception:
                pass

        # If local read failed to get a name and we have a global index,
        # try cross-bundle resolution
        if not name and sprite_index is not None:
            try:
                from il2cpp_recovery_studio.gui.sprite_resolver import resolve_pptr_global
                return resolve_pptr_global(obj, current_file, sprite_index)
            except Exception:
                pass

        result = {"path_id": pid}
        if fid is not None and fid != 0:
            result["file_id"] = fid
        if name:
            result["name"] = name
        return result
    except Exception:
        return None


def _vec(v, keys=("x", "y", "z", "w")):
    if v is None:
        return None
    return {k: getattr(v, k, None) for k in keys if hasattr(v, k)}


def _color(c):
    if c is None:
        return None
    return {"r": getattr(c, "r", None), "g": getattr(c, "g", None),
            "b": getattr(c, "b", None), "a": getattr(c, "a", None)}


def _get_precise_raw_bytes(obj) -> tuple[str | None, int]:
    try:
        raw = obj.get_raw_data()
        if raw and isinstance(raw, (bytes, bytearray)) and len(raw) > 0:
            return base64.b64encode(raw).decode("ascii"), len(raw)
    except Exception:
        pass
    try:
        reader     = getattr(obj, "reader", None) or getattr(obj, "_reader", None)
        if reader is None:
            return None, 0
        byte_size  = (
            getattr(obj,    "byte_size",  None)
            or getattr(reader, "byte_size",  None)
            or getattr(reader, "byteSize",   None)
        )
        data_offset = (
            getattr(obj,    "data_offset", None)
            or getattr(reader, "data_offset", None)
            or getattr(reader, "dataOffset",  None)
        )
        if byte_size and byte_size > 0:
            if data_offset is not None and hasattr(reader, "stream"):
                stream   = reader.stream
                old_pos  = stream.tell() if hasattr(stream, "tell") else None
                stream.seek(data_offset)
                raw      = stream.read(byte_size)
                if old_pos is not None:
                    stream.seek(old_pos)
            elif hasattr(reader, "Position"):
                reader.Position = 0
                raw = reader.read(byte_size) if hasattr(reader, "read") else None
            else:
                raw = None
            if raw and isinstance(raw, (bytes, bytearray)) and len(raw) > 0:
                return base64.b64encode(raw).decode("ascii"), len(raw)
    except Exception:
        pass
    try:
        raw = getattr(obj, "raw_data", None) or getattr(obj, "data", None)
        if raw and isinstance(raw, (bytes, bytearray)):
            return base64.b64encode(raw).decode("ascii"), len(raw)
    except Exception:
        pass
    return None, 0


def _parse_monobehaviour_header(obj) -> dict:
    result = {}
    try:
        raw_b64, _ = _get_precise_raw_bytes(obj)
        if not raw_b64:
            reader = getattr(obj, "reader", None) or getattr(obj, "_reader", None)
            if reader is not None:
                byte_start = getattr(obj, "byte_start", 0)
                if hasattr(reader, "Position"):
                    reader.Position = byte_start
                elif hasattr(reader, "seek"):
                    reader.seek(byte_start)
                raw_bytes = reader.read(64) if hasattr(reader, "read") else None
            else:
                raw_bytes = None
        else:
            raw_bytes = base64.b64decode(raw_b64)

        if not raw_bytes or len(raw_bytes) < 28:
            return result

        go_fid = struct.unpack_from("<i", raw_bytes,  0)[0]
        go_pid = struct.unpack_from("<q", raw_bytes,  4)[0]
        result["m_GameObject"] = {"file_id": go_fid, "path_id": go_pid}

        m_enabled = struct.unpack_from("<B", raw_bytes, 12)[0]
        result["m_Enabled"] = bool(m_enabled)

        script_fid = struct.unpack_from("<i", raw_bytes, 16)[0]
        script_pid = struct.unpack_from("<q", raw_bytes, 20)[0]
        result["m_Script"] = {"file_id": script_fid, "path_id": script_pid}

        if len(raw_bytes) >= 32:
            name_len = struct.unpack_from("<i", raw_bytes, 28)[0]
            if 0 < name_len < 512 and len(raw_bytes) >= 32 + name_len:
                result["m_Name"] = raw_bytes[32:32 + name_len].decode("utf-8", errors="replace")
            # Offset of the first component-specific serialized field (right
            # after the m_Name AlignedString, aligned up to 4 bytes). This is
            # where m_Sprite / m_Texture / m_text live for known UI components.
            n = name_len if (0 < name_len < 512) else 0
            result["_field_start"] = ((32 + n + 3) // 4) * 4
    except Exception:
        pass
    return result


# ── UI component field recovery (protected/obfuscated IL2CPP builds) ──────────
# On builds where the embedded type tree is broken, UnityPy's o.read() /
# read_typetree() raise (they never segfault, but they return nothing useful).
# However the component fields are still stored in the raw MonoBehaviour bytes
# at well-defined offsets, so we recover the essential ones directly.  The
# first component field sits at _field_start; for built-in UI types that field
# is the primary asset/text reference.
_UI_COMPONENT_TYPES = {
    "Image", "RawImage", "Text", "TextMeshProUGUI",
    "RTLTextMeshPro", "RTLTextMeshProWithSettings", "TMProTextRenderer",
    "Button", "Toggle", "Slider", "ScrollRect", "InputField",
}

# Substring-based detection for text components (the game uses RTL-wrapped
# TMP variants whose serialized layout still starts with the TMP_Text m_text
# field).
def _is_text_component(class_name: str) -> bool:
    if not class_name:
        return False
    return (class_name in ("Text", "TextMeshProUGUI")
            or "TextMeshPro" in class_name
            or "RTLTextMeshPro" in class_name)


def _resolve_pptr_fields(pid, fid, sprite_index, source_file):
    """Resolve a (file_id, path_id) PPtr to a name via the global sprite index."""
    if pid is None or pid == 0:
        return None
    ns = SimpleNamespace(path_id=pid, file_id=fid or 0)
    return _pptr(ns, sprite_index=sprite_index, current_file=source_file)


def _parse_ui_component_fields(raw_bytes, class_name, field_start,
                               sprite_index, source_file) -> dict:
    """Recover the essential fields of a known UI MonoBehaviour from raw bytes.

    Returns a dict with the same keys the Stage-5 Node parser expects
    (m_Sprite, m_Color, m_Texture, m_text, m_fontAsset, ...).  Any field that
    cannot be read safely is simply omitted.
    """
    out: dict = {}
    if not raw_bytes or field_start is None or field_start + 12 > len(raw_bytes):
        return out
    try:
        if class_name == "Image":
            fid = struct.unpack_from("<i", raw_bytes, field_start)[0]
            pid = struct.unpack_from("<q", raw_bytes, field_start + 4)[0]
            sp = _resolve_pptr_fields(pid, fid, sprite_index, source_file)
            if sp:
                out["m_Sprite"] = sp
            # m_Color (RGBA32, 4 floats) sits 24 bytes after the field start
            # (m_Sprite PPtr + m_Material PPtr on this Unity version).
            co = field_start + 24
            if co + 16 <= len(raw_bytes):
                r, g, b, a = struct.unpack_from("<4f", raw_bytes, co)
                out["m_Color"] = {"r": r, "g": g, "b": b, "a": a}

        elif class_name == "RawImage":
            fid = struct.unpack_from("<i", raw_bytes, field_start)[0]
            pid = struct.unpack_from("<q", raw_bytes, field_start + 4)[0]
            tx = _resolve_pptr_fields(pid, fid, sprite_index, source_file)
            if tx:
                out["m_Texture"] = tx

        elif _is_text_component(class_name):
            # AlignedString layout: 4-byte length, then string bytes, then padding
            # Parse length from field_start, then extract string from next bytes
            if len(raw_bytes) >= field_start + 4:
                nlen = struct.unpack_from('<i', raw_bytes[field_start:field_start+4])[0]
                # Check bounds before extracting
                if 0 <= nlen < 8192 and field_start + 4 + nlen <= len(raw_bytes):
                    s = raw_bytes[field_start+4:field_start+4+nlen]
                    out["m_text"] = s.decode('utf-8', 'replace')


def _dump_ui_obj(
    o,
    source_file:      str        = "",
    script_map:       dict | None = None,
    typetree_decoded: dict | None = None,
    sprite_index:     dict | None = None,
    local_type_index: dict | None = None,
    monoscript_index: dict | None = None,
) -> dict:
    t   = o.type.name
    out: dict = {
        "path_id":    o.path_id,
        "type":       t,
        "source_file": source_file,
    }

    if typetree_decoded:
        out["_typetree_decoded"] = True
        out.update(typetree_decoded)
        return out

    # Local binding so all _pptr calls inside this function pass through
    # the global sprite_index and source_file for cross-bundle resolution.
    _p = lambda obj: _pptr(obj, sprite_index=sprite_index, current_file=source_file)

    # For MonoBehaviour on protected/obfuscated IL2CPP builds, a full o.read()
    # is slow and can hit native faults UnityPy cannot catch. Recover the
    # essential fields (class name via m_Script, GameObject, enabled state,
    # name) cheaply from raw bytes instead of deserializing the whole object.
    if t == "MonoBehaviour":
        base = _parse_monobehaviour_header(o)
        if base:
            out["name"]         = base.get("m_Name")
            out["m_GameObject"] = base.get("m_GameObject")
            out["m_Enabled"]    = base.get("m_Enabled")
            out["m_Script"]     = base.get("m_Script")
            class_name = None
            # monoscript_index is keyed by the MonoBehaviour's OWN path_id
            # (reliable); script_map is keyed by TypeDefIndex (fallback).
            # Resolve the component class so we can recover its fields from
            # raw bytes below.
            if monoscript_index:
                class_name = monoscript_index.get(o.path_id)
            if not class_name and script_map and base.get("m_Script"):
                pid = str(base["m_Script"].get("path_id", ""))
                class_name = script_map.get(pid)
            if class_name:
                out["_class_name"] = class_name
                leaf = class_name.split(".")[-1]
                if leaf in _UI_COMPONENT_TYPES:
                    class_name = leaf
            # Recover UI component fields (sprite / texture / text / color)
            # directly from raw bytes. o.read()/read_typetree() fail on this
            # protected build, so we parse the well-defined component layout
            # and resolve asset PPtrs through the global sprite index.
            if class_name in _UI_COMPONENT_TYPES:
                try:
                    raw_b64, _ = _get_precise_raw_bytes(o)
                    if raw_b64:
                        rb = base64.b64decode(raw_b64)
                        out.update(_parse_ui_component_fields(
                            rb, class_name, base.get("_field_start"),
                            sprite_index, source_file))
                except Exception:
                    pass
            out["_decode"] = "header"
            return out

    try:
        d = o.read()
        out["name"] = _sg(d, "m_Name") or _sg(d, "name")
    except Exception as e:
        base = _parse_monobehaviour_header(o)
        out["name"]         = base.get("m_Name")
        out["m_GameObject"] = base.get("m_GameObject")
        out["m_Enabled"]    = base.get("m_Enabled")
        out["m_Script"]     = base.get("m_Script")
        if script_map and base.get("m_Script"):
            pid = str(base["m_Script"].get("path_id", ""))
            cls = script_map.get(pid)
            if cls:
                out["_class_name"] = cls
        out["_decode_failed"] = True
        out["_decode_error"]  = str(e)
        raw_b64, raw_len      = _get_precise_raw_bytes(o)
        out["_raw_b64"]       = raw_b64
        out["_raw_byte_size"] = raw_len
        return out

    try:
        if t == "MonoBehaviour":
            out["m_Script"] = _p(_sg(d, "m_Script"))
            if script_map:
                pid = str(out["m_Script"].get("path_id", "")) if out["m_Script"] else ""
                cls = script_map.get(pid)
                if cls:
                    out["_class_name"] = cls

        if t == "GameObject":
            out["layer"]     = _sg(d, "m_Layer")
            out["is_active"] = _sg(d, "m_IsActive")
            comps = _sg(d, "m_Component", [])
            # Resolve components using local object type index to avoid
            # cross-bundle path_id collisions with the global sprite index.
            resolved_comps = []
            for c in comps:
                ptr = c.component if hasattr(c, "component") else c
                pid = getattr(ptr, "path_id", None)
                if pid is not None and local_type_index and pid in local_type_index:
                    comp_type = local_type_index[pid]
                    comp_entry = {"path_id": pid, "type": comp_type}
                    # For MonoBehaviours, resolve the script class name
                    if comp_type == "MonoBehaviour" and monoscript_index:
                        # Get the script class via script_map (from header parsing)
                        # or from the monoscript_index built during env scan
                        if pid in monoscript_index:
                            comp_entry["_class_name"] = monoscript_index[pid]
                    resolved_comps.append(comp_entry)
                else:
                    # Fallback to legacy _pptr resolution for external refs
                    resolved_comps.append(_p(ptr))
            out["components"] = resolved_comps

        elif t in ("Transform", "RectTransform"):
            out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
            for f in ("m_LocalPosition", "m_LocalRotation", "m_LocalScale",
                      "m_AnchorMin", "m_AnchorMax", "m_AnchoredPosition",
                      "m_SizeDelta", "m_OffsetMin", "m_OffsetMax", "m_Pivot"):
                if hasattr(d, f):
                    out[f] = _vec(getattr(d, f))
            out["m_Father"]   = _p(_sg(d, "m_Father"))
            out["m_Children"] = [_p(c) for c in _sg(d, "m_Children", [])]

        elif t == "CanvasRenderer":
            out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
            for f in dir(d):
                if f.startswith("m_") and f != "m_GameObject":
                    try: out[f] = _sg(d, f)
                    except Exception: pass

        elif t == "Canvas":
            for f in ("m_RenderMode", "m_SortingOrder", "m_PixelPerfect", "m_PlaneDistance"):
                out[f] = _sg(d, f)

        elif t == "CanvasScaler":
            for f in ("m_UiScaleMode", "m_ScreenMatchMode", "m_MatchWidthOrHeight",
                      "m_ReferencePixelsPerUnit", "m_ScaleFactor"):
                out[f] = _sg(d, f)
            v = _sg(d, "m_ReferenceResolution")
            out["m_ReferenceResolution"] = _vec(v) if v is not None else None

        elif t in ("CanvasGroup", "GraphicRaycaster"):
            for f in dir(d):
                if f.startswith("m_"):
                    try: out[f] = _sg(d, f)
                    except Exception: pass

        elif t == "MonoScript":
            out["m_ClassName"]    = _sg(d, "m_ClassName")
            out["m_Namespace"]    = _sg(d, "m_Namespace")
            out["m_AssemblyName"] = _sg(d, "m_AssemblyName")

        elif t == "Image":
            out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
            out["m_Sprite"]     = _p(_sg(d, "m_Sprite"))
            out["m_Material"]   = _p(_sg(d, "m_Material"))
            out["m_Color"]      = _color(_sg(d, "m_Color"))
            for f in ("m_Type", "m_PreserveAspect", "m_FillMethod", "m_FillAmount",
                      "m_FillCenter", "m_RaycastTarget", "m_Maskable"):
                out[f] = _sg(d, f)

        elif t == "RawImage":
            out["m_GameObject"]  = _p(_sg(d, "m_GameObject"))
            out["m_Texture"]     = _p(_sg(d, "m_Texture"))
            out["m_Color"]       = _color(_sg(d, "m_Color"))
            out["m_UVRect"]      = _vec(_sg(d, "m_UVRect"), ("x", "y", "width", "height"))
            out["m_RaycastTarget"] = _sg(d, "m_RaycastTarget")

        elif t == "Text":
            out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
            fd = _sg(d, "m_FontData")
            out["m_Text"]  = _sg(d, "m_Text")
            out["m_Color"] = _color(_sg(d, "m_Color"))
            if fd:
                out["m_Font"] = _p(_sg(fd, "m_Font"))
                for f in ("m_FontSize", "m_FontStyle", "m_Alignment", "m_RichText",
                          "m_HorizontalOverflow", "m_VerticalOverflow", "m_LineSpacing"):
                    out[f] = _sg(fd, f)

        elif t in ("TextMeshProUGUI", "TMP_Text"):
            out["m_GameObject"]    = _p(_sg(d, "m_GameObject"))
            out["m_text"]          = _sg(d, "m_text")
            out["m_fontAsset"]     = _p(_sg(d, "m_fontAsset"))
            out["m_sharedMaterial"] = _p(_sg(d, "m_sharedMaterial"))
            out["m_color"]         = _color(_sg(d, "m_color"))
            for f in ("m_fontSize", "m_fontSizeMin", "m_fontSizeMax", "m_enableAutoSizing",
                      "m_fontStyle", "m_alignment", "m_margin", "m_richText",
                      "m_overflowMode", "m_enableWordWrapping"):
                out[f] = _sg(d, f)

        elif t == "Button":
            out["m_GameObject"]   = _p(_sg(d, "m_GameObject"))
            out["m_Interactable"] = _sg(d, "m_Interactable")
            out["m_TargetGraphic"] = _p(_sg(d, "m_TargetGraphic"))
            out["m_Transition"]   = _sg(d, "m_Transition")
            colors = _sg(d, "m_Colors")
            if colors:
                out["m_Colors"] = {
                    "normalColor":   _color(_sg(colors, "m_NormalColor")),
                    "pressedColor":  _color(_sg(colors, "m_PressedColor")),
                    "disabledColor": _color(_sg(colors, "m_DisabledColor")),
                }
            on_click = _sg(d, "m_OnClick")
            if on_click:
                calls = _sg(on_click, "m_PersistentCalls")
                if calls:
                    out["m_OnClick"] = [
                        {"target": _p(_sg(c, "m_Target")), "method": _sg(c, "m_MethodName")}
                        for c in _sg(calls, "m_Calls", [])
                    ]

        elif t in ("Toggle", "Slider", "ScrollRect", "InputField", "TMP_InputField",
                   "Mask", "RectMask2D", "HorizontalLayoutGroup", "VerticalLayoutGroup",
                   "GridLayoutGroup", "LayoutElement", "ContentSizeFitter", "AspectRatioFitter"):
            out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
            for f in dir(d):
                if f.startswith("m_"):
                    try:
                        v = _sg(d, f)
                        out[f] = _p(v) if hasattr(v, "path_id") else v
                    except Exception:
                        pass

        elif t == "Sprite":
            out["rect"]            = _vec(_sg(d, "m_Rect"),   ("x", "y", "width", "height"))
            out["pivot"]           = _vec(_sg(d, "m_Pivot"),  ("x", "y"))
            out["pixels_per_unit"] = _sg(d, "m_PixelsPerUnit")
            out["border"]          = _vec(_sg(d, "m_Border"), ("x", "y", "z", "w"))
            rd = _sg(d, "m_RD")
            if rd:
                out["texture"] = _p(_sg(rd, "texture"))

        elif t == "Texture2D":
            out["width"]  = _sg(d, "m_Width")
            out["height"] = _sg(d, "m_Height")
            out["format"] = _sg(d, "m_TextureFormat")

        elif t == "SpriteAtlas":
            packed = _sg(d, "m_PackedSprites")
            if packed:
                out["m_PackedSprites"] = [_p(s) for s in packed]

        elif t in ("Font", "TMP_FontAsset"):
            out["m_AtlasTexture"] = _p(_sg(d, "m_AtlasTexture"))
            out["m_FontSize"]     = _sg(d, "m_FontSize")
            out["m_LineSpacing"]  = _sg(d, "m_LineSpacing")

        elif t in ("MonoBehaviour", "Animator", "AnimationClip", "AnimatorController", "AnimatorOverrideController"):
            if t == "MonoBehaviour":
                out["m_GameObject"] = _p(_sg(d, "m_GameObject"))
                out["m_Enabled"]    = _sg(d, "m_Enabled")
            for f in dir(d):
                if f.startswith("m_") and f not in ("m_Script", "m_GameObject"):
                    try:
                        v = _sg(d, f)
                        if isinstance(v, (int, float, str, bool, type(None))):
                            out[f] = v
                        elif hasattr(v, "path_id"):
                            out[f] = _p(v)
                    except Exception:
                        pass
        elif t == "TextAsset":
            out["m_Name"] = _sg(d, "m_Name")
            out["text"] = getattr(d, "m_Script", "") or getattr(d, "m_Text", "") or getattr(d, "text", "")
            if isinstance(out["text"], bytes):
                try: out["text"] = out["text"].decode("utf-8")
                except: out["text"] = "<binary_data>"
        elif t == "AudioClip":
            out["m_Name"] = _sg(d, "m_Name")
            out["m_Length"] = _sg(d, "m_Length")
            out["m_Frequency"] = _sg(d, "m_Frequency")

    except Exception as e:
        out["_field_error"] = str(e)

    return out


def _get_env_external_refs(env) -> list[dict]:
    refs = []
    try:
        cabs = getattr(env, "cabs", None) or getattr(env, "files", {})
        if isinstance(cabs, dict):
            for name in cabs:
                refs.append({"index": len(refs), "name": name})
        elif hasattr(cabs, "__iter__"):
            for i, cab in enumerate(cabs):
                refs.append({"index": i, "name": str(cab)})
    except Exception:
        pass
    try:
        for i, dep in enumerate(getattr(env, "dependencies", []) or []):
            path = getattr(dep, "path", None) or str(dep)
            if not any(r.get("name") == path for r in refs):
                refs.append({"index": i, "name": path})
    except Exception:
        pass
    return refs


def _load_script_map(dump_dir: Path | None) -> dict:
    if dump_dir is None:
        return {}
    script_json = dump_dir / "script.json"
    if not script_json.exists():
        return {}
    try:
        entries = json.loads(script_json.read_text(encoding="utf-8"))
        by_typedef: dict[str, str] = {}
        for e in entries:
            idx  = e.get("TypeDefIndex")
            name = e.get("Name") or e.get("ClassName") or e.get("class")
            if idx is not None and name:
                by_typedef[str(idx)] = name
        return by_typedef
    except Exception:
        return {}


def _try_typetree_decode(o, env) -> dict | None:
    """Try to decode typetree using UnityPy's built-in reader (no TypeTreeGenerator needed).
    
    This never crashes - it uses UnityPy's built-in typetree reader which handles
    most cases. TypeTreeGenerator is an optional enhancement loaded separately.
    """
    try:
        tt = o.read_typetree()
        if tt and isinstance(tt, dict) and len(tt) > 4:
            return tt
    except Exception:
        pass
    return None


class _SuppressCSharpOutput:
    """Context manager that redirects ALL C# interop output.

    TypeTreeGeneratorAPI.dll writes 'Error generating tree nodes: Object
    reference not set...' via Console.Error/Console.Out which goes to
    the process-level fds 1 and 2 — NOT Python's sys.stderr object.
    We must redirect the actual OS file descriptors to suppress it.
    """

    def __enter__(self):
        self._old_fd1 = os.dup(1)
        self._old_fd2 = os.dup(2)
        devnull = os.open(os.devnull, os.O_WRONLY)
        os.dup2(devnull, 1)
        os.dup2(devnull, 2)
        os.close(devnull)
        return self

    def __exit__(self, *args):
        os.dup2(self._old_fd1, 1)
        os.dup2(self._old_fd2, 2)
        os.close(self._old_fd1)
        os.close(self._old_fd2)


def _run_stage4_ui_dump(
    raw_dir:     Path,
    ui_dump_dir: Path,
    log,
    force:       bool,
    dump_dir:    Path | None = None,
    progress_cb=None,
):
    if ui_dump_dir.exists() and not force:
        n = _count_files(ui_dump_dir)
        log(f"[SKIP ] ui_dump/ already exists ({n} files) — skipping Stage 4")
        log("[INFO ] Tick 'Force Refresh' to re-run Stage 4.")
        return

    log("[STEP ] Stage 4 — Full Unity UI field extraction (per-file, v22)…")
    _wipe_dir(ui_dump_dir)

    # 1. Load global environment and sprite index
    env = build_global_env(raw_dir, log)
# 1b. Configure TypeTreeGenerator using DummyDlls (optional enhancement)
    typetree_available = False
    if dump_dir and (dump_dir / "DummyDll").exists():
        try:
            from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator
            unity_ver = "2021.3.11f1"
            if env.objects:
                unity_ver = getattr(env.objects[0].assets_file, "unity_version", unity_ver)
            
            generator = TypeTreeGenerator(unity_ver)
            with _SuppressCSharpOutput():
                for dll_file in (dump_dir / "DummyDll").glob("*.dll"):
                    generator.load_dll(dll_file.read_bytes())
            
            # Patch generator to cache failed class lookups
            original_get_nodes_up = generator.get_nodes_up
            failed_keys = set()
            
            def patched_get_nodes_up(assembly: str, fullname: str):
                key = (assembly, fullname)
                if key in failed_keys:
                    raise ValueError(f"Cached TypeTree generation failure for {fullname} of {assembly}")
                with _SuppressCSharpOutput():
                    try:
                        return original_get_nodes_up(assembly, fullname)
                    except Exception as e:
                        failed_keys.add(key)
                        raise e
            
            generator.get_nodes_up = patched_get_nodes_up
            # Attach the C# generator ONLY when explicitly opted in. On protected/
            # obfuscated IL2CPP builds (this game's metadata reported "may be
            # protected"), read_typetree() through this interop can segfault the
            # whole process — a native fault Python cannot catch, which presents
            # as a hard "crash" with no traceback. UnityPy's built-in typetree
            # reader handles the common cases without the native dependency.
            if _os.environ.get("IL2CPP_TYPETREE", "0") == "1":
                env.typetree_generator = generator
                typetree_available = True
                log(f"[INFO ] TypeTreeGenerator attached {len(list((dump_dir / 'DummyDll').glob('*.dll')))} DummyDlls (Unity {unity_ver}).")
            else:
                log(f"[INFO ] TypeTreeGenerator loaded but NOT attached (protected build) — using UnityPy built-in typetree. Set IL2CPP_TYPETREE=1 to force the C# generator.")
        except ImportError:
            log("[INFO ] TypeTreeGeneratorAPI not installed — using UnityPy built-in typetree reading.")
        except Exception as e:
            log(f"[WARN ] TypeTreeGenerator unavailable, falling back to UnityPy: {e}")
            
    with _SuppressCSharpOutput():
        sprite_index = build_global_sprite_index(env, log)
    script_map = _load_script_map(dump_dir)

    # 2a. Build global MonoScript class map: (assetsfile_name, path_id) -> class_name
    monoscript_class_map = {}
    _ms_counter = 0
    for o in env.objects:
        _ms_counter += 1
        if _ms_counter % 10000 == 0:
            log(f"[INFO ] Scanning MonoScripts: {_ms_counter}/{len(env.objects)}...")
            if progress_cb:
                progress_cb(0.20 + 0.10 * (_ms_counter / len(env.objects)),
                            f"Stage 4: scanning MonoScripts {_ms_counter}/{len(env.objects)}")
        if o.type.name == "MonoScript":
            af = getattr(o, "assets_file", None)
            afn = getattr(af, "name", "") if af else ""
            try:
                d = o.read()
                cn = getattr(d, "m_ClassName", None)
                if cn:
                    ns = getattr(d, "m_Namespace", "")
                    monoscript_class_map[(afn, o.path_id)] = f"{ns}.{cn}" if ns else cn
            except Exception:
                pass
    log(f"[INFO ] Built global MonoScript class map with {len(monoscript_class_map)} entries")

    def resolve_monoscript(o, fid, pid):
        if not pid:
            return None
        af = getattr(o, "assets_file", None)
        if af is None:
            return None
        externals = getattr(af, "externals", [])
        script_file = ""
        if fid > 0 and fid <= len(externals):
            ext = externals[fid - 1]
            script_file = getattr(ext, "name", str(ext))
        elif fid == 0:
            script_file = getattr(af, "name", "")
        
        # Try direct lookup
        cls = monoscript_class_map.get((script_file, pid))
        if cls:
            return cls
        # Fallback: path_id only match
        for (fn, p), cn in monoscript_class_map.items():
            if p == pid:
                return cn
        return None

    # 2b. Build per-file local type indices and MonoBehaviour->class mappings.
    local_type_indices: dict[str, dict[int, str]] = {}  # file -> {pid -> type}
    monoscript_indices: dict[str, dict[int, str]] = {}  # file -> {pid -> class_name}
    _lt_counter = 0
    _lt_mb = 0
    for o in env.objects:
        _lt_counter += 1
        if _lt_counter % 10000 == 0:
            log(f"[INFO ] Scanning local types: {_lt_counter}/{len(env.objects)}...")
            if progress_cb:
                progress_cb(0.30 + 0.20 * (_lt_counter / len(env.objects)),
                            f"Stage 4: scanning object {_lt_counter}/{len(env.objects)}")
        af = getattr(o, "assets_file", None)
        fn = getattr(af, "name", "unknown") if af else "unknown"
        if fn not in local_type_indices:
            local_type_indices[fn] = {}
            monoscript_indices[fn] = {}
        local_type_indices[fn][o.path_id] = o.type.name
        
        if o.type.name == "MonoBehaviour":
            resolved_cls = None
            _lt_mb += 1
            if _lt_mb % 100 == 0:
                log(f"[INFO ] Resolving MonoBehaviour {_lt_mb} (at object {_lt_counter})...")
            # Recover the m_Script PPtr from the raw MonoBehaviour header — this
            # is a cheap, native-safe byte parse that does NOT deserialize the
            # whole object. On protected/obfuscated IL2CPP builds a full
            # o.read() is slow and can hit native faults Python cannot catch,
            # so it is only used as a last-resort fallback below.
            try:
                base = _parse_monobehaviour_header(o)
                script_ref = base.get("m_Script")
                if script_ref:
                    sfid = script_ref.get("file_id", 0)
                    spid = script_ref.get("path_id", 0)
                    resolved_cls = resolve_monoscript(o, sfid, spid)
            except Exception:
                pass

            if not resolved_cls:
                try:
                    d = o.read()
                    script_ptr = getattr(d, "m_Script", None)
                    if script_ptr:
                        sfid = getattr(script_ptr, "file_id", 0)
                        spid = getattr(script_ptr, "path_id", 0)
                        resolved_cls = resolve_monoscript(o, sfid, spid)
                except Exception:
                    pass

            if resolved_cls:
                short_cls = resolved_cls.split(".")[-1]
                monoscript_indices[fn][o.path_id] = short_cls

    resolved_mono_count = sum(len(v) for v in monoscript_indices.values())
    log(f"[INFO ] Resolved {resolved_mono_count} MonoBehaviour class names")

    # 2b. Group objects by source file and dump them
    objects_by_file: dict[str, list] = {}
    total_objects = 0
    skipped_objects = 0
    processed_counter = 0
    log(f"[INFO ] Processing {len(env.objects)} Unity objects...")
    # Suppress ALL C# interop output (TypeTreeGeneratorAPI.dll writes
    # 'Error generating tree nodes: ...' directly to process fds 1+2)
    # for the entire object processing loop.
    _mb_counter = 0
    with _SuppressCSharpOutput():
        for o in env.objects:
            processed_counter += 1
            if processed_counter % 10000 == 0:
                log(f"[INFO ] Dumping UI objects: {processed_counter}/{len(env.objects)}...")
                if progress_cb:
                    progress_cb(0.5 + 0.3 * (processed_counter / len(env.objects)), f"Stage 4: Processed {processed_counter}/{len(env.objects)} objects")
            
            if o.type.name not in WANT_TYPES:
                continue
            
            # Determine source file name
            source_name = "unknown"
            if getattr(o, "assets_file", None) is not None:
                source_name = getattr(o.assets_file, "name", "unknown") or "unknown"
            
            if source_name not in objects_by_file:
                objects_by_file[source_name] = []
            
            try:
                typetree_decoded = None
                if o.type.name == "MonoBehaviour":
                    _mb_counter += 1
                    # Full typetree decode of EVERY MonoBehaviour is extremely slow
                    # (it deserializes the whole object) and, when the C# generator
                    # is attached, is the native-crash risk on protected/obfuscated
                    # builds. Default to cheap header-only extraction; full decode
                    # can be forced with IL2CPP_TYPETREE=1 for well-behaved builds.
                    if _os.environ.get("IL2CPP_TYPETREE", "0") == "1":
                        typetree_decoded = _try_typetree_decode(o, env)
                
                dumped = _dump_ui_obj(
                    o,
                    source_file=source_name,
                    script_map=script_map,
                    typetree_decoded=typetree_decoded,
                    sprite_index=sprite_index,
                    local_type_index=local_type_indices.get(source_name),
                    monoscript_index=monoscript_indices.get(source_name),
                )
                objects_by_file[source_name].append(dumped)
                total_objects += 1
            except Exception as exc:
                skipped_objects += 1
                if skipped_objects <= 5:
                    log(f"[WARN ] Skipping {o.type.name} path_id={o.path_id}: {exc}")
                elif skipped_objects == 6:
                    log(f"[WARN ] Further skip messages suppressed...")

    log(f"[OK   ] Stage 4 dump complete — {total_objects} objects written, {skipped_objects} skipped")

    # 3. Track coverage stats
    stats = {"resolved": 0, "unresolved": 0, "per_bundle": {}}

    def _count_pptrs(data):
        if isinstance(data, dict):
            # A PPtr dict has "path_id" — check if it was resolved
            if "path_id" in data and data["path_id"] is not None:
                if data.get("unresolved"):
                    stats["unresolved"] += 1
                elif data.get("name"):
                    stats["resolved"] += 1
            for v in data.values():
                _count_pptrs(v)
        elif isinstance(data, list):
            for v in data:
                _count_pptrs(v)

    # 4. Write per-source JSONs
    for source_name, objs in objects_by_file.items():
        _count_pptrs(objs)
        stats["per_bundle"][source_name] = len(objs)
        
        out_file = ui_dump_dir / f"{source_name.replace(os.sep, '_')}.json"
        out_file.write_text(
            json.dumps({"source": source_name, "objects": objs},
                       default=str, ensure_ascii=False),
            encoding="utf-8",
        )

    # 5. Write sprite mapping report
    write_sprite_mapping_report(ui_dump_dir, stats, log)

    if dump_dir and (dump_dir / "script.json").exists():
        shutil.copy2(dump_dir / "script.json", ui_dump_dir / "script.json")
        log("[OK   ] script.json copied to ui_dump/")

    log(f"[OK   ] Stage 4 complete — {total_objects} objects processed"
        + (f" ({skipped_objects} skipped due to errors)" if skipped_objects else ""))



# ────────────────────────────────────────────────────────────────────────────
# STAGE 5 — Bundle parser (Node.js)
# ────────────────────────────────────────────────────────────────────────────

def _run_stage5_bundle_parser(
    ui_dump_dir:     Path,
    normalized_ui_dir: Path,
    log,
    force:           bool,
    progress_cb=None,
):
    if normalized_ui_dir.exists() and not force:
        n = _count_files(normalized_ui_dir)
        log(f"[SKIP ] normalized_ui/ already exists ({n} files) — skipping Stage 5")
        return
    log("[STEP ] Stage 5 — Building normalized UI trees (Node.js bundle parser)…")
    node = _find_node()
    if node is None:
        log("[WARN ] Node.js not found — skipping Stage 5.")
        log("[INFO ] Install Node.js 18+ from https://nodejs.org to enable automatic tree normalization.")
        return
    if not PARSER_SCRIPT.exists():
        log(f"[WARN ] Parser script not found at {PARSER_SCRIPT} — skipping Stage 5.")
        return
    log(f"[INFO ] Node.js -> {node}")
    log(f"[INFO ] Parser  -> {PARSER_SCRIPT}")
    normalized_ui_dir.mkdir(parents=True, exist_ok=True)
    if progress_cb:
        progress_cb(0.05, "Stage 5: starting Node.js parser…")
    try:
        proc = subprocess.Popen(
            [node, str(PARSER_SCRIPT), str(ui_dump_dir), str(normalized_ui_dir)],
            stdout=subprocess.PIPE, stderr=subprocess.STDOUT,
            text=True, encoding="utf-8", errors="replace",
            cwd=str(REPO_ROOT),
        )
        assert proc.stdout
        for line in proc.stdout:
            line = line.rstrip()
            if line:
                log(f"[INFO ] {line}")
                if progress_cb and "/" in line:
                    try:
                        parts = line.strip().split("/")
                        done  = int(parts[0].split()[-1])
                        total = int(parts[1].split()[0])
                        progress_cb(done / max(total, 1), f"Stage 5: {done}/{total} bundles parsed")
                    except Exception:
                        pass
        proc.wait(timeout=600)
        if proc.returncode == 0:
            n = _count_files(normalized_ui_dir)
            log(f"[OK   ] Stage 5 complete — {n} normalized tree file(s) -> {normalized_ui_dir}")
        else:
            log(f"[ERROR] Stage 5 exited with code {proc.returncode}")
    except subprocess.TimeoutExpired:
        proc.kill()
        log("[ERROR] Stage 5 timed out after 600s")
    except Exception as exc:
        log(f"[ERROR] Stage 5 failed: {exc}")
    if progress_cb:
        progress_cb(1.0, "Stage 5: complete")


# ── main pipeline ─────────────────────────────────────────────────────────────
def _run_pipeline(
    src:             Path,
    out_dir:         Path,
    force:           bool,
    java_override:   str | None,
    il2cpp_exe_path: str | None,
    log,
    progress_cb=None,
):
    try:
        try:
            import UnityPy
        except ImportError:
            log("[ERROR] UnityPy not installed. Run: pip install UnityPy")
            return

        raw_dir     = out_dir / "raw"
        unity_dir   = out_dir / "unity_assets"
        il2cpp_dir  = out_dir / "il2cpp_meta"
        smali_dir   = out_dir / "smali"
        ai_dir      = out_dir / "ai_export"
        ui_dump_dir = out_dir / "ui_dump"
        norm_ui_dir = out_dir / "normalized_ui"

        log(f"[INFO ] Output -> {out_dir}")
    
        if progress_cb: progress_cb(0.00, "Stage 1: Extracting package…")
        log("[STEP ] Stage 1 — Extracting package…")
        _extract_xapk(src, raw_dir, log, force)
    
        if progress_cb: progress_cb(0.10, "Stage 2: Extracting Unity assets (PNG/text)…")
        log("[STEP ] Stage 2 — Extracting Unity assets (PNG / text)…")
        if unity_dir.exists() and not force:
            log(f"[SKIP ] unity_assets/ already exists ({_count_files(unity_dir)} files)")
        else:
            if force: _wipe_dir(unity_dir)
            else:     unity_dir.mkdir(parents=True, exist_ok=True)
    
        # Shared content-hash set so identical images extracted from the main
        # APK, expansion packs, and split bundles are written only once.
        seen_images: set[str] = set()

        # 1. Extract assets/bin/Data directories (each becomes a scene subdirectory)
        for dd in raw_dir.rglob("assets/bin/Data"):
            try:
                import UnityPy
                env = UnityPy.load(str(dd))
                # Use the parent directory name (e.g., com.traviangames.travianlegendsmobile) as scene folder
                scene_name = _safe_name(dd.parent.parent.parent.name)
                scene_dir = unity_dir / scene_name
                scene_dir.mkdir(parents=True, exist_ok=True)
                w, sk = _dump_env(env, scene_dir, log, force, seen_images)
                log(f"[OK   ]   {scene_name}: {w+sk} file(s) [{sk} skipped]")
            except Exception as exc:
                log(f"[WARN ] Failed to load {dd}: {exc}")
    
        # 2. Extract split asset files (sharedassets*.assets*) - each becomes a subdirectory
        unity_data_dir = _find_unity_data_dir(raw_dir)
        if unity_data_dir:
            data_dir = unity_data_dir / "assets" / "bin" / "Data"
            if data_dir.exists():
                # Track processed file stems to avoid duplicates from .splitN files
                processed_stems = set()
                for asset_file in data_dir.glob("sharedassets*.assets*"):
                    try:
                        # Skip split files (.split0, .split1, ...) and .resS files
                        name = asset_file.name
                        if ".split" in name or name.endswith(".resS"):
                            continue
                        import UnityPy
                        env = UnityPy.load(str(asset_file))
                        # Use the asset file stem as scene folder
                        scene_name = _safe_name(asset_file.stem)
                        # Skip if we already processed this stem (to avoid duplicates)
                        if scene_name in processed_stems:
                            continue
                        processed_stems.add(scene_name)
                        scene_dir = unity_dir / scene_name
                        scene_dir.mkdir(parents=True, exist_ok=True)
                        w, sk = _dump_env(env, scene_dir, log, force, seen_images)
                        log(f"[OK   ]   {scene_name}: {w+sk} file(s) [{sk} skipped]")
                    except Exception as exc:
                        log(f"[WARN ] Failed to load split asset {asset_file.name}: {exc}")
    
        # 3. Extract bundle files (*.bundle) - each becomes a subdirectory
        for bf in raw_dir.rglob("*.bundle"):
            try:
                import UnityPy
                env = UnityPy.load(str(bf))
                # Use the bundle file stem as scene folder
                scene_name = _safe_name(bf.stem)
                scene_dir = unity_dir / scene_name
                scene_dir.mkdir(parents=True, exist_ok=True)
                _dump_env(env, scene_dir, log, force, seen_images)
                log(f"[OK   ]   {scene_name}: extracted")
            except Exception as exc:
                log(f"[WARN ] Failed bundle {bf.name}: {exc}")
    
        log(f"[OK   ] Stage 2 complete -> {unity_dir}")
    
        if progress_cb: progress_cb(0.25, "Stage 3: IL2CPP metadata…")
        log("[STEP ] Stage 3 — IL2CPP metadata…")
        if not (il2cpp_dir.exists() and not force):
            _wipe_dir(il2cpp_dir)
            for f in (
                list(raw_dir.rglob("global-metadata.dat"))
                + list(raw_dir.rglob("arm64-v8a/libil2cpp.so"))
                + list(raw_dir.rglob("armeabi-v7a/libil2cpp.so"))
            ):
                dst_name = f"{f.parent.name}_{f.name}" if f.name == "libil2cpp.so" else f.name
                shutil.copy2(f, il2cpp_dir / dst_name)
                log(f"[OK   ]   Copied: {dst_name}")
            log(f"[OK   ] Stage 3 complete -> {il2cpp_dir}")
        else:
            log(f"[SKIP ] il2cpp_meta/ already exists ({_count_files(il2cpp_dir)} files)")
    
        if progress_cb: progress_cb(0.30, "Stage 3b: Smali decompile…")
        log("[STEP ] Stage 3b — Smali decompile…")
        java = _find_java(java_override)
        if java is None:
            log("[WARN ] Java not found — skipping smali step.")
        else:
            apktool_jar = _ensure_apktool(log)
            if apktool_jar:
                smali_dir.mkdir(parents=True, exist_ok=True)
                main_apks = [p for p in raw_dir.rglob("*.apk") if "config." not in p.name] \
                            or list(raw_dir.rglob("*.apk"))
                for apk in main_apks:
                    _run_smali(apk, smali_dir, java, apktool_jar, log, force)
    
        if progress_cb: progress_cb(0.40, "Stage 3c: Building AI export…")
        log("[STEP ] Stage 3c — AI export files…")
        ai_dir.mkdir(parents=True, exist_ok=True)
        scene_map = _build_ai_scene_map(unity_dir)
        (ai_dir / "ai_scene_map.json").write_text(
            json.dumps(scene_map, indent=2, ensure_ascii=False), encoding="utf-8")
        log(f"[OK   ] ai_scene_map.json — {len(scene_map)} entries")
    
        # Parse and export Addressables catalog if it exists
        catalog_bin = None
        for p in raw_dir.rglob("catalog.bin"):
            catalog_bin = p
            break
        if catalog_bin:
            try:
                from addressablestools import parse_binary
                catalog = parse_binary(catalog_bin.read_bytes())
                out_catalog = {
                    "locator_id": catalog.locator_id,
                    "build_result_hash": catalog.build_result_hash,
                    "resources": {}
                }
                for key, locations in catalog.resources.items():
                    key_str = str(key)
                    out_locations = []
                    for loc in locations:
                        loc_dict = {
                            "primary_key": loc.primary_key,
                            "internal_id": loc.internal_id,
                            "provider_id": loc.provider_id,
                            "type": loc.type.class_name if loc.type else None,
                            "dependencies": [dep.primary_key for dep in loc.dependencies] if loc.dependencies else []
                        }
                        out_locations.append(loc_dict)
                    out_catalog["resources"][key_str] = out_locations
                (ai_dir / "addressables_catalog.json").write_text(
                    json.dumps(out_catalog, indent=2, ensure_ascii=False), encoding="utf-8")
                log(f"[OK   ] addressables_catalog.json — {len(out_catalog['resources'])} keys parsed")
            except ImportError:
                log("[WARN ] addressablestools not installed. Run:")
                log("[WARN ]   pip install addressablestools")
                log(f"[WARN ]   (Current Python: {sys.executable})")
            except Exception as exc:
                log(f"[WARN ] Failed to parse addressables catalog: {exc}")
        else:
            log("[INFO ] No catalog.bin found — skipping Addressables catalog export")
    
        asset_index = _build_ai_asset_index(out_dir)
        (ai_dir / "ai_asset_index.json").write_text(
            json.dumps(asset_index, indent=2, ensure_ascii=False), encoding="utf-8")
        log(f"[OK   ] ai_asset_index.json — {len(asset_index)} files indexed")
    
        if progress_cb: progress_cb(0.42, "Stage 4a: Il2CppDumper…")
        dump_dir = _run_stage4a_il2cppdumper(
            il2cpp_dir, out_dir, log, manual_exe_path=il2cpp_exe_path
        )
    
        if progress_cb: progress_cb(0.50, "Stage 4: UI field dump (per-file, v20)…")
        _run_stage4_ui_dump(
            raw_dir, ui_dump_dir, log, force,
            dump_dir=dump_dir,
            progress_cb=lambda p, msg: progress_cb(0.50 + p * 0.35, msg) if progress_cb else None,
        )
    
        if progress_cb: progress_cb(0.85, "Stage 5: Normalized UI trees (Node.js)…")
        _run_stage5_bundle_parser(
            ui_dump_dir, norm_ui_dir, log, force,
            progress_cb=lambda p, msg: progress_cb(0.85 + p * 0.08, msg) if progress_cb else None,
        )
    
        if progress_cb: progress_cb(0.93, "Stage 6: AI Prompt Companions & Scene Slices…")
        run_ui_compiler(out_dir, log, raw_dir=raw_dir)
    
        # Rebuild ai_asset_index now that all stages have produced their output
        log("[STEP ] Rebuilding AI asset index (post-pipeline)…")
        ai_dir.mkdir(parents=True, exist_ok=True)
        asset_index = _build_ai_asset_index(out_dir)
        (ai_dir / "ai_asset_index.json").write_text(
            json.dumps(asset_index, indent=2, ensure_ascii=False), encoding="utf-8")
        log(f"[OK   ] ai_asset_index.json — {len(asset_index)} files indexed")
    
        if progress_cb: progress_cb(1.0, "All stages complete!")
        log(f"[DONE ] All stages complete -> {out_dir}")
        log("")
        log("[INFO ] ✔ Stage 1  — APK/XAPK extracted")
        log("[INFO ] ✔ Stage 2  — PNGs + text assets")
        log("[INFO ] ✔ Stage 3  — IL2CPP metadata + smali")
        log(f"[INFO ] {'✔' if dump_dir else 'ℹ'} Stage 4a — Il2CppDumper "
            f"{'complete — DummyDll + script.json' if dump_dir else 'unavailable'}")
        log("[INFO ] ✔ Stage 4  — UI field dump per-file")
        log("[INFO ] ✔ Stage 5  — Normalized UI trees")
        log("[INFO ] ✔ Stage 6  — AI Prompt Companions generated")
        log("[INFO ] Next: open your scene prompt packages under ai_export/scenes/ in your AI agent for React/Tailwind generation.")
    
    except Exception as exc:
        import traceback
        log("[ERROR] Pipeline failed:")
        log(traceback.format_exc())
        if progress_cb:
            progress_cb(0.0, "Failed!")

# ── GUI ───────────────────────────────────────────────────────────────────────
class App(ctk.CTk):
    VERSION = "v23"

    def __init__(self):
        super().__init__()
        self.title(f"IL2CPP Recovery Studio {self.VERSION}")
        self.geometry("1100x920")
        self.configure(fg_color=BG_DEEP)
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("dark-blue")

        self._cfg     = _load_config()
        self._q: queue.Queue = queue.Queue()
        self._running = False

        self._build_ui()
        self._restore_from_config()
        self.after(100, self._poll_queue)

    # ── build UI ──────────────────────────────────────────────────────────────
    def _build_ui(self):
        self.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(4, weight=1)

        ctk.CTkLabel(
            self, text=f"⚙  IL2CPP Recovery Studio  {self.VERSION}",
            font=FNT_TITLE, text_color=NEON_CYAN, fg_color=BG_PANEL,
        ).grid(row=0, column=0, sticky="ew", padx=0, pady=0)

        card = ctk.CTkFrame(self, fg_color=BG_CARD, corner_radius=12)
        card.grid(row=1, column=0, sticky="ew", padx=16, pady=8)
        card.grid_columnconfigure(1, weight=1)

        # Row 0 — APK / XAPK
        ctk.CTkLabel(card, text="APK / XAPK", font=FNT_BODY, text_color=TEXT_DIM
                     ).grid(row=0, column=0, padx=12, pady=6, sticky="w")
        self._apk_var = ctk.StringVar(value=self._cfg.get("last_apk", ""))
        ctk.CTkEntry(card, textvariable=self._apk_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT
                     ).grid(row=0, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL,
                      fg_color=NEON_PURP, hover_color=BTN_HOVER,
                      command=self._browse_apk
                      ).grid(row=0, column=2, padx=8, pady=6)

        # Row 1 — Output dir
        ctk.CTkLabel(card, text="Output dir", font=FNT_BODY, text_color=TEXT_DIM
                     ).grid(row=1, column=0, padx=12, pady=6, sticky="w")
        self._out_var = ctk.StringVar(value=self._cfg.get("last_out", ""))
        ctk.CTkEntry(card, textvariable=self._out_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT
                     ).grid(row=1, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL,
                      fg_color=NEON_PURP, hover_color=BTN_HOVER,
                      command=self._browse_out
                      ).grid(row=1, column=2, padx=8, pady=6)

        # Row 2 — Java path
        ctk.CTkLabel(card, text="Java path (opt.)", font=FNT_BODY, text_color=TEXT_DIM
                     ).grid(row=2, column=0, padx=12, pady=6, sticky="w")
        self._java_var = ctk.StringVar(value=self._cfg.get("java_path", ""))
        ctk.CTkEntry(card, textvariable=self._java_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT
                     ).grid(row=2, column=1, padx=4, pady=6, sticky="ew")

        # Row 3 — Il2CppDumper path (manual fallback)
        ctk.CTkLabel(
            card,
            text="Il2CppDumper.exe\n(auto-dl or manual)",
            font=FNT_SMALL, text_color=NEON_ORANGE, justify="left",
        ).grid(row=3, column=0, padx=12, pady=6, sticky="w")
        self._il2cpp_var = ctk.StringVar(value=self._cfg.get("il2cpp_path", ""))
        ctk.CTkEntry(
            card, textvariable=self._il2cpp_var, font=FNT_SMALL,
            fg_color=BG_DEEP, text_color=NEON_ORANGE,
            placeholder_text="Leave blank to auto-download",
        ).grid(row=3, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(
            card, text="Browse", width=80, font=FNT_SMALL,
            fg_color=NEON_ORANGE, hover_color=BTN_HOVER,
            command=self._browse_il2cpp,
        ).grid(row=3, column=2, padx=8, pady=6)

        # Row 4 — Force Refresh
        self._force_var = ctk.BooleanVar(value=self._cfg.get("force_refresh", False))
        ctk.CTkCheckBox(
            card, text="Force Refresh (re-extract everything)",
            variable=self._force_var, font=FNT_SMALL,
            text_color=NEON_YEL, fg_color=NEON_PURP,
        ).grid(row=4, column=0, columnspan=3, padx=12, pady=6, sticky="w")

        # Legend
        legend = ctk.CTkFrame(self, fg_color=BG_CARD, corner_radius=8)
        legend.grid(row=2, column=0, sticky="ew", padx=16, pady=(0, 4))
        legend.grid_columnconfigure((0, 1, 2, 3, 4, 5), weight=1)
        for col, (label, color) in enumerate([
            ("1 • Unpack APK",        NEON_CYAN),
            ("2 • PNG Assets",        NEON_CYAN),
            ("3 • IL2CPP + Smali",    NEON_CYAN),
            ("4a • Type Trees",       NEON_ORANGE),
            ("4 • UI Dump",           NEON_ORANGE),
            ("5 • Normalize Trees",   NEON_GREEN),
        ]):
            ctk.CTkLabel(legend, text=label, font=FNT_SMALL, text_color=color
                         ).grid(row=0, column=col, padx=6, pady=4)

        # Run button + progress
        run_frame = ctk.CTkFrame(self, fg_color="transparent")
        run_frame.grid(row=3, column=0, sticky="ew", padx=16, pady=4)
        run_frame.grid_columnconfigure(0, weight=1)

        self._run_btn = ctk.CTkButton(
            run_frame, text="▶  Run All Stages",
            font=FNT_RUN, height=52,
            fg_color=NEON_CYAN, text_color=BG_DEEP, hover_color=NEON_GREEN,
            command=self._on_run,
        )
        self._run_btn.grid(row=0, column=0, sticky="ew", pady=(0, 4))

        self._progress_bar = ctk.CTkProgressBar(
            run_frame, height=14, progress_color=NEON_ORANGE, fg_color=BG_PANEL)
        self._progress_bar.set(0)
        self._progress_bar.grid(row=1, column=0, sticky="ew", pady=(0, 2))

        self._progress_label = ctk.CTkLabel(
            run_frame, text="", font=FNT_SMALL, text_color=NEON_ORANGE)
        self._progress_label.grid(row=2, column=0, sticky="w")

        # Log box
        log_frame = ctk.CTkFrame(self, fg_color=BG_PANEL, corner_radius=8)
        log_frame.grid(row=4, column=0, sticky="nsew", padx=16, pady=(0, 4))
        log_frame.grid_rowconfigure(0, weight=1)
        log_frame.grid_columnconfigure(0, weight=1)

        self._log_box = ctk.CTkTextbox(
            log_frame, font=FNT_MONO, text_color=NEON_GREEN,
            fg_color=BG_DEEP, wrap="none")
        self._log_box.grid(row=0, column=0, sticky="nsew", padx=4, pady=4)

        self._status = ctk.CTkLabel(
            self,
            text="Ready — set APK path and output dir, then click Run All Stages.",
            font=FNT_SMALL, text_color=TEXT_DIM, fg_color=BG_PANEL, anchor="w",
        )
        self._status.grid(row=5, column=0, sticky="ew", padx=16, pady=2)

    def _restore_from_config(self):
        pass  # values already loaded via StringVar defaults

    # ── browse callbacks ──────────────────────────────────────────────────────
    def _browse_apk(self):
        p = filedialog.askopenfilename(
            title="Select APK or XAPK",
            filetypes=[("APK / XAPK", "*.apk *.xapk"), ("All", "*.*")])
        if p: self._apk_var.set(p)

    def _browse_out(self):
        p = filedialog.askdirectory(title="Select output directory")
        if p: self._out_var.set(p)

    def _browse_il2cpp(self):
        p = filedialog.askopenfilename(
            title="Select Il2CppDumper.exe",
            filetypes=[("Executable", "*.exe"), ("All", "*.*")])
        if p: self._il2cpp_var.set(p)

    # ── run ───────────────────────────────────────────────────────────────────
    def _on_run(self):
        if self._running:
            messagebox.showinfo("Busy", "Pipeline already running.")
            return
        src = self._apk_var.get().strip()
        out = self._out_var.get().strip()
        if not src or not out:
            messagebox.showerror("Missing", "Please set both APK path and output directory.")
            return
        src_path = Path(src)
        if not src_path.exists():
            messagebox.showerror("Not found", f"APK/XAPK not found:\n{src_path}")
            return

        self._cfg.update({
            "last_apk":      src,
            "last_out":      out,
            "java_path":     self._java_var.get().strip(),
            "il2cpp_path":   self._il2cpp_var.get().strip(),
            "force_refresh": self._force_var.get(),
        })
        _save_config(self._cfg)

        self._log_box.delete("1.0", "end")
        self._progress_bar.set(0)
        self._progress_label.configure(text="Starting…")
        self._running = True
        self._run_btn.configure(state="disabled", text="Running…")
        self._status.configure(text="Pipeline running — all stages will complete in order.")

        threading.Thread(
            target=self._worker,
            args=(
                src_path,
                Path(out),
                self._force_var.get(),
                self._java_var.get().strip() or None,
                self._il2cpp_var.get().strip() or None,
            ),
            daemon=True,
        ).start()

    def _worker(
        self,
        src:             Path,
        out:             Path,
        force:           bool,
        java_override:   str | None,
        il2cpp_exe_path: str | None,
    ):
        def log(msg: str):                   self._q.put(("log",      msg))
        def progress(value: float, label: str): self._q.put(("progress", value, label))
        try:
            _run_pipeline(
                src, out, force,
                java_override, il2cpp_exe_path,
                log, progress_cb=progress,
            )
        except Exception as exc:
            import traceback
            log(f"[FATAL] Unhandled error: {exc}")
            log(traceback.format_exc())
        finally:
            self._q.put(("done",))

    def _poll_queue(self):
        try:
            while True:
                item = self._q.get_nowait()
                if item[0] == "done":
                    self._running = False
                    self._run_btn.configure(state="normal", text="▶  Run All Stages")
                    self._status.configure(text="✔ All stages complete.")
                    self._progress_bar.set(1.0)
                    self._progress_label.configure(text="All stages complete!")
                elif item[0] == "log":
                    self._log_box.insert("end", item[1] + "\n")
                    self._log_box.see("end")
                elif item[0] == "progress":
                    self._progress_bar.set(max(0.0, min(1.0, item[1])))
                    self._progress_label.configure(text=item[2])
        except queue.Empty:
            pass
        self.after(100, self._poll_queue)


def run_gui() -> None:
    app = App()
    app.mainloop()


if __name__ == "__main__":
    run_gui()