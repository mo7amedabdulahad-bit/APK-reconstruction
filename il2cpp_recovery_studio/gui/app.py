#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — app.py v15

Changes vs v14:
- BUGFIX: Added missing `run_gui()` function that launch.py imports.
- BUGFIX: Smali / apktool silent hang fixed — heartbeat thread now logs
  every 30 s AND logs the current smali output directory file-count so
  you can see real progress. The previous heartbeat only printed a ping
  with no size/count info, making it look frozen.
- BUGFIX: Smali skip logic — if the smali/ directory already exists AND
  Force Refresh is OFF, the whole apktool step is skipped with a clear
  [SKIP] log line and a file-count summary. Previously the code had no
  such guard so it always re-ran apktool.
- AI outputs (ai_scene_map.json, ai_asset_index.json) are still
  generated alongside the HTML report.
- Version label updated to v15.
"""
from __future__ import annotations

import json
import os
import queue
import shutil
import subprocess
import sys
import threading
import time
import urllib.request
import zipfile
from pathlib import Path

import customtkinter as ctk
from tkinter import filedialog, messagebox

try:
    from PIL import Image as PILImage
except ImportError:
    PILImage = None  # type: ignore

BG_DEEP = "#0a0a0f"; BG_CARD = "#111128"; BG_PANEL = "#0d0d22"
NEON_CYAN = "#00ffe7"; NEON_PURP = "#bf80ff"; NEON_GREEN = "#00ff88"
NEON_PINK = "#ff4488"; NEON_YEL = "#ffe040"
TEXT_WHITE = "#ffffff"; TEXT_BRIGHT = "#e8f0ff"; TEXT_DIM = "#8888bb"
BTN_HOVER = "#1e1e44"
FNT_TITLE = ("Segoe UI", 18, "bold"); FNT_HEAD = ("Segoe UI", 14, "bold")
FNT_BODY = ("Segoe UI", 13, "bold"); FNT_SMALL = ("Segoe UI", 11)
FNT_MONO = ("Courier New", 12); FNT_MONO_B = ("Courier New", 12, "bold")
FNT_RUN = ("Segoe UI", 16, "bold")

APKTOOL_VER = "3.0.2"
APKTOOL_URL = (
    f"https://github.com/iBotPeaches/Apktool/releases/download/"
    f"v{APKTOOL_VER}/apktool_{APKTOOL_VER}.jar"
)
TOOLS_DIR = Path(__file__).parent / "tools"
CONFIG_FILE = TOOLS_DIR / "config.json"
APKTOOL_TIMEOUT = 3600
JVM_HEAP_FLAGS = ["-Xmx2g", "-Xms256m"]
HEARTBEAT_INTERVAL = 30   # seconds between apktool alive-pings

# Heuristic keywords → guessed screen purpose for AI map
_PURPOSE_HINTS: list[tuple[list[str], str]] = [
    (["lobby", "main_menu", "mainmenu", "home"], "Main Menu / Lobby"),
    (["village", "map", "world"], "Village / World Map"),
    (["battle", "combat", "fight", "attack"], "Battle / Combat Screen"),
    (["hero", "portrait", "avatar"], "Hero / Character Screen"),
    (["building", "construction", "upgrade"], "Building / Construction UI"),
    (["resource", "field", "farm", "lumber", "clay", "iron", "crop"], "Resource Field"),
    (["unit", "troop", "army", "soldier"], "Troop / Army Screen"),
    (["hud", "header", "statusbar"], "HUD / Status Bar"),
    (["popup", "dialog", "modal", "alert", "confirm"], "Popup / Dialog"),
    (["settings", "option", "config"], "Settings Screen"),
    (["login", "splash", "loading", "intro"], "Login / Loading Screen"),
    (["shop", "store", "premium", "gold", "purchase"], "Shop / Store"),
    (["quest", "task", "mission", "daily"], "Quest / Mission Screen"),
    (["chat", "message", "mail", "inbox"], "Chat / Messaging"),
    (["alliance", "clan", "tribe"], "Alliance Screen"),
    (["ranking", "leaderboard", "score"], "Ranking / Leaderboard"),
    (["tutorial", "guide", "onboard"], "Tutorial / Onboarding"),
]


def _guess_purpose(names: list[str]) -> str:
    combined = " ".join(names).lower()
    for keywords, label in _PURPOSE_HINTS:
        if any(k in combined for k in keywords):
            return label
    return "Unknown / Generic"


# ── config helpers ────────────────────────────────────────────────
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


# ── helpers ───────────────────────────────────────────────────────
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
    """Return the existing file path if it already exists, else None (caller should write)."""
    p = dest / f"{stem}{ext}"
    return p if p.exists() else None


# ── Java discovery ────────────────────────────────────────────────
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
        pf   = Path(os.environ.get("ProgramFiles",  r"C:\Program Files"))
        pf86 = Path(os.environ.get("ProgramFiles(x86)", r"C:\Program Files (x86)"))
        la   = Path(os.environ.get("LOCALAPPDATA", r"C:\Users\Default\AppData\Local"))
        user = Path(os.environ.get("USERPROFILE", r"C:\Users\Default"))
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


# ── apktool download ──────────────────────────────────────────────
def _ensure_apktool(log) -> Path | None:
    jar = TOOLS_DIR / f"apktool_{APKTOOL_VER}.jar"
    wrapper = TOOLS_DIR / "apktool.bat"
    if jar.exists():
        return jar
    log(f"[INFO ] Downloading apktool {APKTOOL_VER}…")
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    try:
        urllib.request.urlretrieve(APKTOOL_URL, jar)
        log(f"[OK   ] apktool downloaded → {jar}")
        # write a helper wrapper bat
        wrapper.write_text(
            f"@echo off\njava {' '.join(JVM_HEAP_FLAGS)} -jar \"{jar}\" %*\n",
            encoding="utf-8",
        )
        return jar
    except Exception as exc:
        log(f"[ERROR] Could not download apktool: {exc}")
        return None


# ── apktool heartbeat (fixes the silent hang) ─────────────────────
def _apktool_heartbeat(proc: subprocess.Popen, smali_dir: Path, log, stop_evt: threading.Event):
    """
    Background thread: every HEARTBEAT_INTERVAL seconds log how many smali
    files have been written so far so it's clear the process is still alive.
    """
    t0 = time.time()
    while not stop_evt.wait(timeout=HEARTBEAT_INTERVAL):
        if proc.poll() is not None:
            break
        elapsed = int(time.time() - t0)
        count = _count_files(smali_dir)
        log(
            f"[INFO ] apktool still running… {elapsed}s elapsed, "
            f"{count} smali files written so far"
        )


# ── XAPK / APK extraction ─────────────────────────────────────────
def _extract_xapk(src: Path, raw_dir: Path, log, force: bool):
    """Unzip the XAPK/APK outer archive into raw_dir, one sub-dir per APK."""
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
                log(f"[OK   ]   {name} → {stem}/")
    else:
        stem = src.stem
        dest = raw_dir / stem
        dest.mkdir(parents=True, exist_ok=True)
        with zipfile.ZipFile(src, "r") as z:
            z.extractall(dest)
        log(f"[OK   ]   {src.name} → {stem}/")


# ── Unity-asset extraction (skip existing files) ──────────────────
def _dump_env(env, dest: Path, log, force: bool) -> tuple[int, int]:
    """
    Write every readable asset in *env* to *dest*.
    Returns (written, skipped) counts.
    """
    try:
        import UnityPy  # noqa: F401 — already imported by caller
    except ImportError:
        pass

    written = skipped = 0
    for obj in env.objects:
        try:
            data = obj.read()
        except Exception:
            continue
        name = getattr(data, "m_Name", "") or f"{obj.type.name}_{obj.path_id}"
        stem = _safe_name(name)
        t = obj.type.name

        if t == "Texture2D":
            if not force:
                ep = _skip_path(dest, stem, ".png")
                if ep:
                    skipped += 1
                    continue
            try:
                img = data.image
                if img:
                    out = _unique_path(dest, stem, ".png") if force else (dest / f"{stem}.png")
                    out.parent.mkdir(parents=True, exist_ok=True)
                    img.save(str(out))
                    written += 1
            except Exception:
                pass

        elif t == "Sprite":
            if not force:
                ep = _skip_path(dest, stem, ".png")
                if ep:
                    skipped += 1
                    continue
            try:
                img = data.image
                if img:
                    out = _unique_path(dest, stem, ".png") if force else (dest / f"{stem}.png")
                    out.parent.mkdir(parents=True, exist_ok=True)
                    img.save(str(out))
                    written += 1
            except Exception:
                pass

        elif t == "TextAsset":
            script = getattr(data, "m_Script", "") or ""
            raw = script.encode() if isinstance(script, str) else (script if isinstance(script, bytes) else b"")
            if not raw:
                continue
            ext = ".json" if raw[:1] in (b"{", b"[") else ".txt"
            if not force:
                ep = _skip_path(dest, stem, ext)
                if ep:
                    skipped += 1
                    continue
            out = _unique_path(dest, stem, ext) if force else (dest / f"{stem}{ext}")
            out.parent.mkdir(parents=True, exist_ok=True)
            out.write_bytes(raw)
            written += 1

        elif t == "MonoBehaviour":
            if not force:
                ep = _skip_path(dest, stem, ".json")
                if ep:
                    skipped += 1
                    continue
            try:
                info = {"name": name, "type": t}
                out = _unique_path(dest, stem, ".json") if force else (dest / f"{stem}.json")
                out.parent.mkdir(parents=True, exist_ok=True)
                out.write_text(json.dumps(info, indent=2, ensure_ascii=False), encoding="utf-8")
                written += 1
            except Exception:
                pass

    return written, skipped


# ── AI export helpers ─────────────────────────────────────────────
def _build_ai_scene_map(unity_dir: Path) -> list[dict]:
    """
    Walk unity_assets/ and build a per-scene/UI-page descriptor that an
    AI agent can use to understand what each screen looks like.
    """
    scenes: list[dict] = []
    if not unity_dir.exists():
        return scenes
    for child in sorted(unity_dir.iterdir()):
        if not child.is_dir():
            continue
        files = list(child.rglob("*"))
        file_names = [f.name for f in files if f.is_file()]
        type_counts: dict[str, int] = {}
        sprites: list[str] = []
        textures: list[str] = []
        for f in files:
            if not f.is_file():
                continue
            ext = f.suffix.lower()
            type_counts[ext] = type_counts.get(ext, 0) + 1
            if ext == ".png":
                if "sprite" in f.parent.name.lower():
                    sprites.append(f.name)
                else:
                    textures.append(f.name)
        scenes.append({
            "scene_dir": child.name,
            "guessed_purpose": _guess_purpose([child.name] + file_names),
            "total_files": len(file_names),
            "type_counts": type_counts,
            "sample_sprites": sprites[:20],
            "sample_textures": textures[:20],
            "all_file_names": file_names,
        })
    return scenes


def _build_ai_asset_index(output_dir: Path) -> list[dict]:
    """
    Flat searchable index of every extracted file — path, type, name.
    AI agents can use this to locate any asset quickly.
    """
    index: list[dict] = []
    if not output_dir.exists():
        return index
    for f in sorted(output_dir.rglob("*")):
        if not f.is_file():
            continue
        rel = f.relative_to(output_dir).as_posix()
        index.append({
            "path": rel,
            "name": f.stem,
            "ext": f.suffix.lower(),
            "size_bytes": f.stat().st_size,
        })
    return index


# ── smali decompile (skip + heartbeat fix) ───────────────────────
def _run_smali(
    apk_path: Path,
    smali_dir: Path,
    java_bin: Path | str,
    apktool_jar: Path,
    log,
    force: bool,
    thread_count: int = 8,
):
    """
    Run apktool on *apk_path* and write smali into *smali_dir*.

    Skip logic (fixes the silent hang):
      - If smali_dir already has files AND force is False → skip entirely.
      - Otherwise wipe & rebuild.

    Heartbeat thread: logs progress every HEARTBEAT_INTERVAL seconds so
    the UI is never silent for more than 30 s.
    """
    apk_name = apk_path.name
    dest = smali_dir / apk_path.stem

    # ── skip guard ────────────────────────────────────────────────
    if dest.exists() and not force:
        existing = _count_files(dest)
        log(
            f"[SKIP ] smali/{apk_path.stem}/ already exists "
            f"({existing} files) — skipping apktool. "
            "Tick 'Force Refresh' to re-run."
        )
        return

    if dest.exists():
        log(f"[INFO ] Force refresh — wiping smali/{apk_path.stem}/")
        shutil.rmtree(dest, ignore_errors=True)
    dest.mkdir(parents=True, exist_ok=True)

    cmd = [
        str(java_bin),
        *JVM_HEAP_FLAGS,
        "-jar", str(apktool_jar),
        "d", str(apk_path),
        "-o", str(dest),
        "-f",
        "--jobs", str(thread_count),
    ]
    log(f"[INFO ] Running apktool on: {apk_name}  (timeout {APKTOOL_TIMEOUT}s)")
    log(f"[INFO ] Output dir: {dest}")

    stop_evt = threading.Event()
    try:
        proc = subprocess.Popen(
            cmd,
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding="utf-8",
            errors="replace",
        )
        # start heartbeat
        hb = threading.Thread(
            target=_apktool_heartbeat,
            args=(proc, dest, log, stop_evt),
            daemon=True,
        )
        hb.start()

        # stream apktool output line-by-line
        assert proc.stdout
        for line in proc.stdout:
            line = line.rstrip()
            if line:
                log(f"[INFO ] I: {line}")

        proc.wait(timeout=APKTOOL_TIMEOUT)
        stop_evt.set()
        hb.join(timeout=5)

        if proc.returncode == 0:
            n = _count_files(dest)
            log(f"[OK   ] apktool finished — {n} smali files in {dest.name}/")
        else:
            log(f"[ERROR] apktool exited with code {proc.returncode}")
    except subprocess.TimeoutExpired:
        stop_evt.set()
        proc.kill()
        log(f"[ERROR] apktool timed out after {APKTOOL_TIMEOUT}s")
    except Exception as exc:
        stop_evt.set()
        log(f"[ERROR] apktool failed: {exc}")


# ── main pipeline ────────────────────────────────────────────────
def _run_pipeline(src: Path, out_dir: Path, force: bool, java_override: str | None, log):
    """
    Full extraction pipeline called from the GUI worker thread.
    """
    try:
        import UnityPy
    except ImportError:
        log("[ERROR] UnityPy not installed. Run: pip install UnityPy")
        return

    raw_dir      = out_dir / "raw"
    unity_dir    = out_dir / "unity_assets"
    il2cpp_dir   = out_dir / "il2cpp_meta"
    smali_dir    = out_dir / "smali"
    ai_dir       = out_dir / "ai_export"

    log(f"[INFO ] Output → {out_dir}")
    log(f"[STEP ] Extracting package…")
    _extract_xapk(src, raw_dir, log, force)

    # ── Unity assets ──────────────────────────────────────────────
    log(f"[STEP ] Extracting Unity assets…")
    if unity_dir.exists() and not force:
        n = _count_files(unity_dir)
        log(f"[SKIP ] unity_assets/ already exists ({n} files) — skipping")
    else:
        if force:
            log("[INFO ] Force refresh — rebuilding unity_assets/")
            _wipe_dir(unity_dir)
        else:
            unity_dir.mkdir(parents=True, exist_ok=True)

        data_dirs = list(raw_dir.rglob("assets/bin/Data"))
        log(f"[INFO ]   Found {len(data_dirs)} Data dir(s) to scan")
        total_files = total_scene = total_ui = 0
        for dd in data_dirs:
            log(f"[INFO ]   Loading Data dir: {dd}")
            try:
                env = UnityPy.load(str(dd))
                w, sk = _dump_env(env, unity_dir, log, force)
                sc = sum(1 for o in env.objects if o.type.name == "SceneAsset")
                ui = sum(1 for o in env.objects if o.type.name == "Canvas")
                total_files += w + sk
                total_scene += sc
                total_ui += ui
                log(f"[OK   ]   {dd.parent.parent.parent.name}: {w+sk} file(s), {sc} scene, {ui} UI  [{sk} skipped]")
            except Exception as exc:
                log(f"[WARN ] Failed to load {dd}: {exc}")

        # bundles
        bundle_dirs = list(raw_dir.rglob("*.bundle"))
        log(f"[INFO ]   Found {len(bundle_dirs)} bundle file(s) — loading…")
        for bf in bundle_dirs:
            try:
                env = UnityPy.load(str(bf))
                w, sk = _dump_env(env, unity_dir, log, force)
                log(f"[OK   ]   bundle:{bf.name}: {w+sk} file(s), 0 scene, 0 UI  [{sk} skipped]")
                total_files += w + sk
            except Exception as exc:
                log(f"[WARN ] Failed bundle {bf.name}: {exc}")

        log(f"[OK   ] Total saved: {total_files} files → {unity_dir}")
        log(f"[INFO ] Scene entries: {total_scene}")

    # ── IL2CPP metadata ───────────────────────────────────────────
    log(f"[STEP ] Parsing IL2CPP metadata…")
    if il2cpp_dir.exists() and not force:
        n = _count_files(il2cpp_dir)
        log(f"[SKIP ] il2cpp_meta/ already exists ({n} files) — skipping")
    else:
        if force:
            log("[INFO ] Force refresh — rebuilding il2cpp_meta/")
        _wipe_dir(il2cpp_dir)
        metadata_src = list(raw_dir.rglob("global-metadata.dat"))
        so_arm64 = list(raw_dir.rglob("arm64-v8a/libil2cpp.so"))
        so_armv7 = list(raw_dir.rglob("armeabi-v7a/libil2cpp.so"))
        for f in metadata_src + so_arm64 + so_armv7:
            dst_name = f.name
            # prefix with arch for .so files to avoid collision
            if f.name == "libil2cpp.so":
                arch = f.parent.name
                dst_name = f"{arch}_{f.name}"
            shutil.copy2(f, il2cpp_dir / dst_name)
            log(f"[OK   ]   Copied: {dst_name}")
        log(f"[OK   ] IL2CPP → {il2cpp_dir}")
        log(f"[INFO ] Use Il2CppDumper or Ghidra on these files.")

    # ── Smali decompile (skip-aware + heartbeat) ──────────────────
    log(f"[STEP ] Decompiling Smali…")
    java = _find_java(java_override)
    if java is None:
        log("[ERROR] Java not found — cannot run apktool. Skipping smali step.")
    else:
        log(f"[INFO ] Java → {java}")
        apktool_jar = _ensure_apktool(log)
        if apktool_jar is None:
            log("[ERROR] apktool not available — skipping smali step.")
        else:
            if force:
                log("[INFO ] Force refresh — rebuilding smali/")
            else:
                log(f"[INFO ] Smali skip-check enabled — existing dirs will be reused.")
            smali_dir.mkdir(parents=True, exist_ok=True)
            # find the main APK inside raw/
            main_apks = [p for p in raw_dir.rglob("*.apk")
                         if "config." not in p.name]
            if not main_apks:
                main_apks = list(raw_dir.rglob("*.apk"))
            for apk in main_apks:
                _run_smali(apk, smali_dir, java, apktool_jar, log, force)

    # ── AI export ─────────────────────────────────────────────────
    log(f"[STEP ] Building AI export files…")
    ai_dir.mkdir(parents=True, exist_ok=True)

    scene_map = _build_ai_scene_map(unity_dir)
    scene_map_path = ai_dir / "ai_scene_map.json"
    scene_map_path.write_text(
        json.dumps(scene_map, indent=2, ensure_ascii=False), encoding="utf-8"
    )
    log(f"[OK   ] ai_scene_map.json — {len(scene_map)} scene/page entries")

    asset_index = _build_ai_asset_index(out_dir)
    asset_index_path = ai_dir / "ai_asset_index.json"
    asset_index_path.write_text(
        json.dumps(asset_index, indent=2, ensure_ascii=False), encoding="utf-8"
    )
    log(f"[OK   ] ai_asset_index.json — {len(asset_index)} files indexed")

    log(f"[DONE ] Pipeline complete → {out_dir}")


# ── GUI ───────────────────────────────────────────────────────────
class App(ctk.CTk):
    VERSION = "v15"

    def __init__(self):
        super().__init__()
        self.title(f"IL2CPP Recovery Studio {self.VERSION}")
        self.geometry("1100x780")
        self.configure(fg_color=BG_DEEP)
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("dark-blue")

        self._cfg = _load_config()
        self._q: queue.Queue[str] = queue.Queue()
        self._running = False

        self._build_ui()
        self._restore_from_config()
        self.after(100, self._poll_queue)

    # ── UI construction ───────────────────────────────────────────
    def _build_ui(self):
        self.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(2, weight=1)

        # title bar
        title = ctk.CTkLabel(
            self, text=f"⚙  IL2CPP Recovery Studio  {self.VERSION}",
            font=FNT_TITLE, text_color=NEON_CYAN, fg_color=BG_PANEL,
        )
        title.grid(row=0, column=0, sticky="ew", padx=0, pady=0)

        # ── input card ────────────────────────────────────────────
        card = ctk.CTkFrame(self, fg_color=BG_CARD, corner_radius=12)
        card.grid(row=1, column=0, sticky="ew", padx=16, pady=8)
        card.grid_columnconfigure(1, weight=1)

        ctk.CTkLabel(card, text="APK / XAPK", font=FNT_BODY,
                     text_color=TEXT_DIM).grid(row=0, column=0, padx=12, pady=6, sticky="w")
        self._apk_var = ctk.StringVar(value=self._cfg.get("last_apk", ""))
        ctk.CTkEntry(card, textvariable=self._apk_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(
            row=0, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL,
                      fg_color=NEON_PURP, hover_color=BTN_HOVER,
                      command=self._browse_apk).grid(row=0, column=2, padx=8, pady=6)

        ctk.CTkLabel(card, text="Output dir", font=FNT_BODY,
                     text_color=TEXT_DIM).grid(row=1, column=0, padx=12, pady=6, sticky="w")
        self._out_var = ctk.StringVar(value=self._cfg.get("last_out", ""))
        ctk.CTkEntry(card, textvariable=self._out_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(
            row=1, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL,
                      fg_color=NEON_PURP, hover_color=BTN_HOVER,
                      command=self._browse_out).grid(row=1, column=2, padx=8, pady=6)

        ctk.CTkLabel(card, text="Java path (opt.)", font=FNT_BODY,
                     text_color=TEXT_DIM).grid(row=2, column=0, padx=12, pady=6, sticky="w")
        self._java_var = ctk.StringVar(value=self._cfg.get("java_path", ""))
        ctk.CTkEntry(card, textvariable=self._java_var, font=FNT_SMALL,
                     fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(
            row=2, column=1, padx=4, pady=6, sticky="ew")

        self._force_var = ctk.BooleanVar(value=self._cfg.get("force_refresh", False))
        ctk.CTkCheckBox(
            card, text="Force Refresh (re-extract everything)",
            variable=self._force_var, font=FNT_SMALL,
            text_color=NEON_YEL, fg_color=NEON_PURP,
        ).grid(row=3, column=0, columnspan=3, padx=12, pady=6, sticky="w")

        # ── run button ────────────────────────────────────────────
        self._run_btn = ctk.CTkButton(
            self, text="▶  Run Extraction",
            font=FNT_RUN, height=48,
            fg_color=NEON_CYAN, text_color=BG_DEEP, hover_color=NEON_GREEN,
            command=self._on_run,
        )
        self._run_btn.grid(row=2, column=0, padx=16, pady=4, sticky="ew")

        # ── log panel ─────────────────────────────────────────────
        log_frame = ctk.CTkFrame(self, fg_color=BG_PANEL, corner_radius=8)
        log_frame.grid(row=3, column=0, sticky="nsew", padx=16, pady=(0, 12))
        log_frame.grid_rowconfigure(0, weight=1)
        log_frame.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(3, weight=1)

        self._log_box = ctk.CTkTextbox(
            log_frame, font=FNT_MONO, text_color=NEON_GREEN,
            fg_color=BG_DEEP, wrap="none",
        )
        self._log_box.grid(row=0, column=0, sticky="nsew", padx=4, pady=4)

        # ── status bar ────────────────────────────────────────────
        self._status = ctk.CTkLabel(
            self, text="Ready.", font=FNT_SMALL,
            text_color=TEXT_DIM, fg_color=BG_PANEL, anchor="w",
        )
        self._status.grid(row=4, column=0, sticky="ew", padx=16, pady=2)

    # ── config restore ────────────────────────────────────────────
    def _restore_from_config(self):
        pass  # vars already set via StringVar defaults

    # ── browse callbacks ──────────────────────────────────────────
    def _browse_apk(self):
        p = filedialog.askopenfilename(
            title="Select APK or XAPK",
            filetypes=[("APK / XAPK", "*.apk *.xapk"), ("All", "*.*")],
        )
        if p:
            self._apk_var.set(p)

    def _browse_out(self):
        p = filedialog.askdirectory(title="Select output directory")
        if p:
            self._out_var.set(p)

    # ── run ───────────────────────────────────────────────────────
    def _on_run(self):
        if self._running:
            messagebox.showinfo("Busy", "Extraction already in progress.")
            return
        src = self._apk_var.get().strip()
        out = self._out_var.get().strip()
        if not src or not out:
            messagebox.showerror("Missing", "Please set both APK path and output directory.")
            return
        src_path = Path(src)
        out_path = Path(out)
        if not src_path.exists():
            messagebox.showerror("Not found", f"APK/XAPK not found:\n{src_path}")
            return

        self._cfg.update({
            "last_apk": src,
            "last_out": out,
            "java_path": self._java_var.get().strip(),
            "force_refresh": self._force_var.get(),
        })
        _save_config(self._cfg)

        self._log_box.delete("1.0", "end")
        self._running = True
        self._run_btn.configure(state="disabled", text="Running…")
        self._status.configure(text="Running extraction…")

        t = threading.Thread(
            target=self._worker,
            args=(src_path, out_path, self._force_var.get(),
                  self._java_var.get().strip() or None),
            daemon=True,
        )
        t.start()

    def _worker(self, src: Path, out: Path, force: bool, java_override: str | None):
        def log(msg: str):
            self._q.put(msg)
        try:
            _run_pipeline(src, out, force, java_override, log)
        except Exception as exc:
            import traceback
            log(f"[FATAL] Unhandled error: {exc}")
            log(traceback.format_exc())
        finally:
            self._q.put("__DONE__")

    # ── queue polling ─────────────────────────────────────────────
    def _poll_queue(self):
        try:
            while True:
                msg = self._q.get_nowait()
                if msg == "__DONE__":
                    self._running = False
                    self._run_btn.configure(state="normal", text="▶  Run Extraction")
                    self._status.configure(text="Done.")
                else:
                    self._log_box.insert("end", msg + "\n")
                    self._log_box.see("end")
        except queue.Empty:
            pass
        self.after(100, self._poll_queue)


# ── public entry point (imported by launch.py) ────────────────────
def run_gui() -> None:
    """Create and run the GUI application. Called by launch.py."""
    app = App()
    app.mainloop()


if __name__ == "__main__":
    run_gui()
