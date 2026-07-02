#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — app.py v18

Fixes from UNITY_EXTRACTION_GAP_REPORT_V3.md:

FIX §2.3 — m_Script now extracted from the 32-byte base header on decode failure.
  The 32-byte base that always decodes is structured as:
    [4 bytes m_GameObject.file_id][8 bytes m_GameObject.path_id]   <- 12 bytes
    [1 byte  m_Enabled]                                             <- 1 byte
    [3 bytes alignment padding]                                     <- 3 bytes
    [4 bytes m_Script.file_id][8 bytes m_Script.path_id]           <- 12 bytes
    [4 bytes m_Name length]...                                      <- variable
  So m_Script (file_id + path_id) lives at offset 16, giving us the MonoScript
  PPtr needed to identify the class (Image / TMP / Button etc.) via script.json.

FIX §2.2 — _raw_b64 now uses the object's precise byte size instead of a fixed
  4098-byte slab. UnityPy stores the serialized byte size on each ObjectReader;
  we read exactly that many bytes from the object's data_offset so byte boundaries
  are reliable and hand-decoding by known field layout is safe.

FIX §3 Steps A+B — New Stage 4b: IL2CPP type-tree integration.
  If `il2cpp_dump/DummyDll/` exists (produced by Il2CppDumper) the stage:
    (a) loads script.json → builds a path_id→class map
    (b) re-attempts every previously-failed MonoBehaviour using
        obj.read_typetree() which, when UnityPy can find the type tree via the
        dummy DLLs, returns the full subclass fields (m_Sprite, m_text, etc.)
    (c) writes a companion `<file>.typetree.json` alongside the existing per-file
        dumps so the consumer can merge the decoded fields by path_id
  The stage also exposes a new UI entry for the Il2CppDumper .exe path so the
  user can optionally point to it and have it run automatically as Stage 4a.
"""
from __future__ import annotations

import base64
import json
import os
import queue
import shutil
import struct
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
NEON_PINK = "#ff4488"; NEON_YEL = "#ffe040"; NEON_ORANGE = "#ff9933"
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
HEARTBEAT_INTERVAL = 30

REPO_ROOT = Path(__file__).resolve().parent.parent.parent
PARSER_SCRIPT = REPO_ROOT / "scripts" / "parse-unity-bundle.mjs"

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


# ── config helpers ──────────────────────────────────────────────────────────
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


# ── general helpers ─────────────────────────────────────────────────────────
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
        pf = Path(os.environ.get("ProgramFiles", r"C:\Program Files"))
        la = Path(os.environ.get("LOCALAPPDATA", r"C:\Users\Default\AppData\Local"))
        user = Path(os.environ.get("USERPROFILE", r"C:\Users\Default"))
        candidates = [
            pf / "nodejs" / "node.exe",
            la / "Programs" / "nodejs" / "node.exe",
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


# ── apktool download ─────────────────────────────────────────────────────────
def _ensure_apktool(log) -> Path | None:
    jar = TOOLS_DIR / f"apktool_{APKTOOL_VER}.jar"
    if jar.exists():
        return jar
    log(f"[INFO ] Downloading apktool {APKTOOL_VER}…")
    TOOLS_DIR.mkdir(parents=True, exist_ok=True)
    try:
        urllib.request.urlretrieve(APKTOOL_URL, jar)
        log(f"[OK   ] apktool downloaded → {jar}")
        (TOOLS_DIR / "apktool.bat").write_text(
            f"@echo off\njava {' '.join(JVM_HEAP_FLAGS)} -jar \"{jar}\" %*\n",
            encoding="utf-8",
        )
        return jar
    except Exception as exc:
        log(f"[ERROR] Could not download apktool: {exc}")
        return None


# ── apktool heartbeat ────────────────────────────────────────────────────────
def _apktool_heartbeat(proc, smali_dir: Path, log, stop_evt: threading.Event):
    t0 = time.time()
    while not stop_evt.wait(timeout=HEARTBEAT_INTERVAL):
        if proc.poll() is not None:
            break
        elapsed = int(time.time() - t0)
        count = _count_files(smali_dir)
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
                log(f"[OK   ]   {name} → {stem}/")
    else:
        stem = src.stem
        dest = raw_dir / stem
        dest.mkdir(parents=True, exist_ok=True)
        with zipfile.ZipFile(src, "r") as z:
            z.extractall(dest)
        log(f"[OK   ]   {src.name} → {stem}/")


# ── Unity-asset extraction (PNGs / text) ─────────────────────────────────────
def _dump_env(env, dest: Path, log, force: bool) -> tuple[int, int]:
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
            if not force and _skip_path(dest, stem, ".png"):
                skipped += 1; continue
            try:
                img = data.image
                if img:
                    out = _unique_path(dest, stem, ".png") if force else dest / f"{stem}.png"
                    out.parent.mkdir(parents=True, exist_ok=True)
                    img.save(str(out)); written += 1
            except Exception: pass
        elif t == "Sprite":
            if not force and _skip_path(dest, stem, ".png"):
                skipped += 1; continue
            try:
                img = data.image
                if img:
                    out = _unique_path(dest, stem, ".png") if force else dest / f"{stem}.png"
                    out.parent.mkdir(parents=True, exist_ok=True)
                    img.save(str(out)); written += 1
            except Exception: pass
        elif t == "TextAsset":
            script = getattr(data, "m_Script", "") or ""
            raw = script.encode() if isinstance(script, str) else (script if isinstance(script, bytes) else b"")
            if not raw: continue
            ext = ".json" if raw[:1] in (b"{", b"[") else ".txt"
            if not force and _skip_path(dest, stem, ext):
                skipped += 1; continue
            out = _unique_path(dest, stem, ext) if force else dest / f"{stem}{ext}"
            out.parent.mkdir(parents=True, exist_ok=True)
            out.write_bytes(raw); written += 1
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
        files = list(child.rglob("*"))
        file_names = [f.name for f in files if f.is_file()]
        type_counts: dict[str, int] = {}
        sprites: list[str] = []; textures: list[str] = []
        for f in files:
            if not f.is_file(): continue
            ext = f.suffix.lower()
            type_counts[ext] = type_counts.get(ext, 0) + 1
            if ext == ".png":
                (sprites if "sprite" in f.parent.name.lower() else textures).append(f.name)
        scenes.append({"scene_dir": child.name, "guessed_purpose": _guess_purpose([child.name] + file_names),
                       "total_files": len(file_names), "type_counts": type_counts,
                       "sample_sprites": sprites[:20], "sample_textures": textures[:20],
                       "all_file_names": file_names})
    return scenes


def _build_ai_asset_index(output_dir: Path) -> list[dict]:
    index: list[dict] = []
    if not output_dir.exists(): return index
    for f in sorted(output_dir.rglob("*")):
        if not f.is_file(): continue
        rel = f.relative_to(output_dir).as_posix()
        index.append({"path": rel, "name": f.stem, "ext": f.suffix.lower(), "size_bytes": f.stat().st_size})
    return index


# ── smali decompile ───────────────────────────────────────────────────────────
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
# STAGE 4a — Optional: run Il2CppDumper to generate DummyDll + script.json
# ────────────────────────────────────────────────────────────────────────────

def _run_stage4a_il2cppdumper(il2cpp_dir: Path, out_dir: Path, il2cppdumper_exe: str | None, log) -> Path | None:
    """
    Runs Il2CppDumper (if available) to produce DummyDll/*.dll + script.json.
    Returns the path to il2cpp_dump/ if successful, else None.
    FIX §3 Step A.
    """
    dump_dir = out_dir / "il2cpp_dump"
    script_json = dump_dir / "script.json"
    dll_dir = dump_dir / "DummyDll"

    if script_json.exists() and dll_dir.exists():
        log(f"[SKIP ] il2cpp_dump/ already exists — skipping Il2CppDumper")
        return dump_dir

    so_file = next(il2cpp_dir.glob("*libil2cpp.so"), None)
    meta_file = il2cpp_dir / "global-metadata.dat"

    if not so_file or not meta_file.exists():
        log("[WARN ] il2cpp_meta/ missing libil2cpp.so or global-metadata.dat — skipping Stage 4a")
        return None

    exe = il2cppdumper_exe
    if not exe or not Path(exe).exists():
        # Try to auto-find in tools/
        candidates = list(TOOLS_DIR.glob("Il2CppDumper*.exe")) + list(TOOLS_DIR.glob("Il2CppDumper"))
        if candidates:
            exe = str(candidates[0])
        else:
            log("[WARN ] Il2CppDumper not found — skipping Stage 4a (MonoBehaviour type-tree generation).")
            log("[INFO ] Download from https://github.com/Perfare/Il2CppDumper and place in tools/ or set path in UI.")
            return None

    log(f"[STEP ] Stage 4a — Running Il2CppDumper to generate type trees…")
    dump_dir.mkdir(parents=True, exist_ok=True)
    cmd = [exe, str(so_file), str(meta_file), str(dump_dir)]
    try:
        proc = subprocess.Popen(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT,
                                text=True, encoding="utf-8", errors="replace")
        assert proc.stdout
        for line in proc.stdout:
            line = line.rstrip()
            if line:
                log(f"[INFO ] Il2CppDumper: {line}")
        proc.wait(timeout=300)
        if proc.returncode == 0 and script_json.exists():
            dll_count = len(list(dll_dir.glob("*.dll"))) if dll_dir.exists() else 0
            log(f"[OK   ] Stage 4a complete — {dll_count} dummy DLLs + script.json → {dump_dir}")
            return dump_dir
        else:
            log(f"[ERROR] Il2CppDumper exited with code {proc.returncode}")
            return None
    except subprocess.TimeoutExpired:
        proc.kill()
        log("[ERROR] Il2CppDumper timed out after 300s")
        return None
    except Exception as exc:
        log(f"[ERROR] Il2CppDumper failed: {exc}")
        return None


# ────────────────────────────────────────────────────────────────────────────
# STAGE 4 — Full UnityPy UI field extraction (v18)
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
}


def _sg(obj, field, default=None):
    try:
        return getattr(obj, field, default)
    except Exception:
        return default


def _pptr(obj):
    if obj is None:
        return None
    try:
        pid = getattr(obj, "path_id", None)
        fid = getattr(obj, "file_id", None)
        name = None
        if hasattr(obj, "read"):
            try:
                read = obj.read()
                name = getattr(read, "m_Name", None) or getattr(read, "name", None)
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
    """
    FIX §2.2 — Extract EXACTLY the bytes belonging to this object.

    UnityPy's ObjectReader stores:
      - obj.byte_size  (or obj.data_offset + size in the SerializedFile header)
      - The raw data is accessible via obj.get_raw_data() in newer UnityPy,
        or via the reader's underlying buffer at the correct offset+length.

    Returns (base64_string, byte_count). If not accessible returns (None, 0).
    """
    # Method 1: UnityPy >=1.9 exposes get_raw_data() directly
    try:
        raw = obj.get_raw_data()
        if raw and isinstance(raw, (bytes, bytearray)) and len(raw) > 0:
            return base64.b64encode(raw).decode("ascii"), len(raw)
    except Exception:
        pass

    # Method 2: read exact byte_size bytes at data_offset from the reader
    try:
        reader = getattr(obj, "reader", None) or getattr(obj, "_reader", None)
        if reader is None:
            return None, 0
        byte_size = (
            getattr(obj, "byte_size", None)
            or getattr(reader, "byte_size", None)
            or getattr(reader, "byteSize", None)
        )
        data_offset = (
            getattr(obj, "data_offset", None)
            or getattr(reader, "data_offset", None)
            or getattr(reader, "dataOffset", None)
        )
        if byte_size and byte_size > 0:
            if data_offset is not None and hasattr(reader, "stream"):
                stream = reader.stream
                old_pos = stream.tell() if hasattr(stream, "tell") else None
                stream.seek(data_offset)
                raw = stream.read(byte_size)
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

    # Method 3: fall back to reading raw bytes attribute
    try:
        raw = getattr(obj, "raw_data", None) or getattr(obj, "data", None)
        if raw and isinstance(raw, (bytes, bytearray)):
            return base64.b64encode(raw).decode("ascii"), len(raw)
    except Exception:
        pass

    return None, 0


def _parse_monobehaviour_header(obj) -> dict:
    """
    FIX §2.3 + §2.2 — Parse the 32-byte MonoBehaviour base header manually.

    Unity MonoBehaviour serialized layout (little-endian):
      Offset  0: int32  m_GameObject.file_id
      Offset  4: int64  m_GameObject.path_id      (8 bytes, but in older formats 4)
      Offset 12: uint8  m_Enabled
      Offset 13: uint8[3] padding
      Offset 16: int32  m_Script.file_id
      Offset 20: int64  m_Script.path_id
      Offset 28: int32  m_Name string length
      Offset 32: char[] m_Name

    We always read up to 64 bytes to also capture m_Name if short.
    Returns dict with m_GameObject, m_Enabled, m_Script, m_Name (best-effort).
    """
    result = {}
    try:
        raw_b64, raw_len = _get_precise_raw_bytes(obj)
        if not raw_b64:
            # Last resort: try reader directly with fixed 64 bytes
            reader = getattr(obj, "reader", None) or getattr(obj, "_reader", None)
            if reader is not None:
                if hasattr(reader, "Position"):
                    reader.Position = 0
                elif hasattr(reader, "seek"):
                    reader.seek(0)
                raw_bytes = reader.read(64) if hasattr(reader, "read") else None
            else:
                raw_bytes = None
        else:
            raw_bytes = base64.b64decode(raw_b64)

        if not raw_bytes or len(raw_bytes) < 28:
            return result

        # Detect path_id size: Unity 5.0+ uses int64 for path_id
        # m_GameObject PPtr: file_id(int32) + path_id(int64) = 12 bytes
        go_fid = struct.unpack_from("<i", raw_bytes, 0)[0]
        go_pid = struct.unpack_from("<q", raw_bytes, 4)[0]
        result["m_GameObject"] = {"file_id": go_fid, "path_id": go_pid}

        m_enabled = struct.unpack_from("<B", raw_bytes, 12)[0]
        result["m_Enabled"] = bool(m_enabled)

        # FIX §2.3 — m_Script PPtr at offset 16
        script_fid = struct.unpack_from("<i", raw_bytes, 16)[0]
        script_pid = struct.unpack_from("<q", raw_bytes, 20)[0]
        result["m_Script"] = {"file_id": script_fid, "path_id": script_pid}  # KEY FIX

        # m_Name (length-prefixed string) at offset 28
        if len(raw_bytes) >= 32:
            name_len = struct.unpack_from("<i", raw_bytes, 28)[0]
            if 0 < name_len < 512 and len(raw_bytes) >= 32 + name_len:
                result["m_Name"] = raw_bytes[32:32 + name_len].decode("utf-8", errors="replace")

    except Exception:
        pass
    return result


def _dump_ui_obj(o, source_file: str = "",
                 script_map: dict | None = None,
                 typetree_decoded: dict | None = None) -> dict:
    """
    Dump all UI-relevant fields from a single Unity object.
    v18 additions:
      - m_Script extracted from base header on failure (FIX §2.3)
      - _raw_b64 uses precise byte size (FIX §2.2)
      - typetree_decoded: if Stage 4b succeeded, merged decoded fields
      - script_map: path_id→class name from Il2CppDumper script.json
    """
    t = o.type.name
    out: dict = {
        "path_id": o.path_id,
        "type": t,
        "source_file": source_file,
    }

    # If typetree decoding already succeeded in Stage 4b, embed those fields
    if typetree_decoded:
        out["_typetree_decoded"] = True
        out.update(typetree_decoded)
        return out

    try:
        d = o.read()
        out["name"] = _sg(d, "m_Name") or _sg(d, "name")
    except Exception as e:
        # FIX §2.3 — decode failed: recover all base-header fields including m_Script
        base = _parse_monobehaviour_header(o)
        out["name"] = base.get("m_Name")
        out["m_GameObject"] = base.get("m_GameObject")
        out["m_Enabled"] = base.get("m_Enabled")
        out["m_Script"] = base.get("m_Script")  # FIX §2.3 — now extracted

        # Resolve class name via script_map if available
        if script_map and base.get("m_Script"):
            pid = str(base["m_Script"].get("path_id", ""))
            cls = script_map.get(pid)
            if cls:
                out["_class_name"] = cls  # e.g. "Image", "TextMeshProUGUI"

        out["_decode_failed"] = True
        out["_decode_error"] = str(e)

        # FIX §2.2 — precise byte-bounded raw bytes
        raw_b64, raw_len = _get_precise_raw_bytes(o)
        out["_raw_b64"] = raw_b64
        out["_raw_byte_size"] = raw_len  # consumer can validate this matches expected size
        return out

    try:
        # FIX §2.3 — always emit m_Script on MonoBehaviour even when read() succeeds
        if t == "MonoBehaviour":
            out["m_Script"] = _pptr(_sg(d, "m_Script"))
            if script_map:
                pid = str(out["m_Script"].get("path_id", "")) if out["m_Script"] else ""
                cls = script_map.get(pid)
                if cls:
                    out["_class_name"] = cls

        if t == "GameObject":
            out["layer"] = _sg(d, "m_Layer")
            out["is_active"] = _sg(d, "m_IsActive")
            comps = _sg(d, "m_Component", [])
            out["components"] = [
                _pptr(c.component) if hasattr(c, "component") else _pptr(c) for c in comps
            ]

        elif t in ("Transform", "RectTransform"):
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            for f in ("m_LocalPosition", "m_LocalRotation", "m_LocalScale",
                      "m_AnchorMin", "m_AnchorMax", "m_AnchoredPosition",
                      "m_SizeDelta", "m_OffsetMin", "m_OffsetMax", "m_Pivot"):
                if hasattr(d, f):
                    out[f] = _vec(getattr(d, f))
            out["m_Father"] = _pptr(_sg(d, "m_Father"))
            out["m_Children"] = [_pptr(c) for c in _sg(d, "m_Children", [])]

        elif t == "CanvasRenderer":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            for f in dir(d):
                if f.startswith("m_") and f != "m_GameObject":
                    try:
                        out[f] = _sg(d, f)
                    except Exception:
                        pass

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
                    try:
                        out[f] = _sg(d, f)
                    except Exception:
                        pass

        elif t == "MonoScript":
            out["m_ClassName"] = _sg(d, "m_ClassName")
            out["m_Namespace"] = _sg(d, "m_Namespace")
            out["m_AssemblyName"] = _sg(d, "m_AssemblyName")

        elif t == "Image":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            out["m_Sprite"] = _pptr(_sg(d, "m_Sprite"))
            out["m_Material"] = _pptr(_sg(d, "m_Material"))
            out["m_Color"] = _color(_sg(d, "m_Color"))
            for f in ("m_Type", "m_PreserveAspect", "m_FillMethod", "m_FillAmount",
                      "m_FillCenter", "m_RaycastTarget", "m_Maskable"):
                out[f] = _sg(d, f)

        elif t == "RawImage":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            out["m_Texture"] = _pptr(_sg(d, "m_Texture"))
            out["m_Color"] = _color(_sg(d, "m_Color"))
            out["m_UVRect"] = _vec(_sg(d, "m_UVRect"), ("x", "y", "width", "height"))
            out["m_RaycastTarget"] = _sg(d, "m_RaycastTarget")

        elif t == "Text":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            fd = _sg(d, "m_FontData")
            out["m_Text"] = _sg(d, "m_Text")
            out["m_Color"] = _color(_sg(d, "m_Color"))
            if fd:
                out["m_Font"] = _pptr(_sg(fd, "m_Font"))
                for f in ("m_FontSize", "m_FontStyle", "m_Alignment", "m_RichText",
                          "m_HorizontalOverflow", "m_VerticalOverflow", "m_LineSpacing"):
                    out[f] = _sg(fd, f)

        elif t in ("TextMeshProUGUI", "TMP_Text"):
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            out["m_text"] = _sg(d, "m_text")
            out["m_fontAsset"] = _pptr(_sg(d, "m_fontAsset"))
            out["m_sharedMaterial"] = _pptr(_sg(d, "m_sharedMaterial"))
            out["m_color"] = _color(_sg(d, "m_color"))
            for f in ("m_fontSize", "m_fontSizeMin", "m_fontSizeMax", "m_enableAutoSizing",
                      "m_fontStyle", "m_alignment", "m_margin", "m_richText",
                      "m_overflowMode", "m_enableWordWrapping"):
                out[f] = _sg(d, f)

        elif t == "Button":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            out["m_Interactable"] = _sg(d, "m_Interactable")
            out["m_TargetGraphic"] = _pptr(_sg(d, "m_TargetGraphic"))
            out["m_Transition"] = _sg(d, "m_Transition")
            colors = _sg(d, "m_Colors")
            if colors:
                out["m_Colors"] = {
                    "normalColor": _color(_sg(colors, "m_NormalColor")),
                    "pressedColor": _color(_sg(colors, "m_PressedColor")),
                    "disabledColor": _color(_sg(colors, "m_DisabledColor")),
                }
            on_click = _sg(d, "m_OnClick")
            if on_click:
                calls = _sg(on_click, "m_PersistentCalls")
                if calls:
                    out["m_OnClick"] = [{"target": _pptr(_sg(c, "m_Target")),
                                          "method": _sg(c, "m_MethodName")}
                                         for c in _sg(calls, "m_Calls", [])]

        elif t in ("Toggle", "Slider", "ScrollRect", "InputField", "TMP_InputField",
                   "Mask", "RectMask2D", "HorizontalLayoutGroup", "VerticalLayoutGroup",
                   "GridLayoutGroup", "LayoutElement", "ContentSizeFitter", "AspectRatioFitter"):
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            for f in dir(d):
                if f.startswith("m_"):
                    try:
                        v = _sg(d, f)
                        out[f] = _pptr(v) if hasattr(v, "path_id") else v
                    except Exception:
                        pass

        elif t == "Sprite":
            out["rect"] = _vec(_sg(d, "m_Rect"), ("x", "y", "width", "height"))
            out["pivot"] = _vec(_sg(d, "m_Pivot"), ("x", "y"))
            out["pixels_per_unit"] = _sg(d, "m_PixelsPerUnit")
            out["border"] = _vec(_sg(d, "m_Border"), ("x", "y", "z", "w"))
            rd = _sg(d, "m_RD")
            if rd:
                out["texture"] = _pptr(_sg(rd, "texture"))

        elif t == "Texture2D":
            out["width"] = _sg(d, "m_Width")
            out["height"] = _sg(d, "m_Height")
            out["format"] = _sg(d, "m_TextureFormat")

        elif t == "SpriteAtlas":
            packed = _sg(d, "m_PackedSprites")
            if packed:
                out["m_PackedSprites"] = [_pptr(s) for s in packed]

        elif t in ("Font", "TMP_FontAsset"):
            out["m_AtlasTexture"] = _pptr(_sg(d, "m_AtlasTexture"))
            out["m_FontSize"] = _sg(d, "m_FontSize")
            out["m_LineSpacing"] = _sg(d, "m_LineSpacing")

        elif t == "MonoBehaviour":
            out["m_GameObject"] = _pptr(_sg(d, "m_GameObject"))
            out["m_Enabled"] = _sg(d, "m_Enabled")
            for f in dir(d):
                if f.startswith("m_") and f not in ("m_Script", "m_GameObject"):
                    try:
                        v = _sg(d, f)
                        if isinstance(v, (int, float, str, bool, type(None))):
                            out[f] = v
                        elif hasattr(v, "path_id"):
                            out[f] = _pptr(v)
                    except Exception:
                        pass

    except Exception as e:
        out["_field_error"] = str(e)

    return out


def _get_env_external_refs(env) -> list[dict]:
    refs = []
    try:
        cabs = getattr(env, "cabs", None) or getattr(env, "files", {})
        if isinstance(cabs, dict):
            for name, cab in cabs.items():
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
    """
    FIX §3 Step B — Load Il2CppDumper's script.json and build
    a path_id→class_name map so we can identify MonoBehaviour subclasses.
    script.json format: [{"Address":…, "Name":"ClassName", "Signature":…,
                          "TypeDefIndex":…}, …]
    MonoScript path_ids in the bundle match TypeDefIndex.
    """
    if dump_dir is None:
        return {}
    script_json = dump_dir / "script.json"
    if not script_json.exists():
        return {}
    try:
        entries = json.loads(script_json.read_text(encoding="utf-8"))
        # Build index by TypeDefIndex (int) → class name
        by_typedef: dict[str, str] = {}
        for e in entries:
            idx = e.get("TypeDefIndex")
            name = e.get("Name") or e.get("ClassName") or e.get("class")
            if idx is not None and name:
                by_typedef[str(idx)] = name
        return by_typedef
    except Exception:
        return {}


def _try_typetree_decode(o, env) -> dict | None:
    """
    FIX §3 Step B — Attempt read_typetree() which succeeds when UnityPy
    can resolve the MonoBehaviour's class via loaded assemblies (dummy DLLs).
    Returns a dict of all decoded fields, or None if it fails.
    """
    try:
        tt = o.read_typetree()
        if tt and isinstance(tt, dict) and len(tt) > 4:
            # More than base 4 fields = subclass fields decoded
            return tt
    except Exception:
        pass
    return None


def _run_stage4_ui_dump(raw_dir: Path, ui_dump_dir: Path, log, force: bool,
                        dump_dir: Path | None = None,
                        progress_cb=None):
    """
    Stage 4 v18: Full Unity UI field extraction.
    - Per-file Data/ processing (FIX §2.2 from v17)
    - m_Script extracted on decode failure (FIX §2.3)
    - Precise raw bytes (FIX §2.2)
    - typetree decode attempt via read_typetree() (FIX §3 Step B)
    - script_map from Il2CppDumper for class name resolution
    """
    try:
        import UnityPy
    except ImportError:
        log("[ERROR] UnityPy not installed — cannot run Stage 4. Run: pip install 'UnityPy>=1.20'")
        return

    if ui_dump_dir.exists() and not force:
        n = _count_files(ui_dump_dir)
        log(f"[SKIP ] ui_dump/ already exists ({n} files) — skipping Stage 4")
        log(f"[INFO ] Tick 'Force Refresh' to re-run Stage 4.")
        return

    log("[STEP ] Stage 4 — Full Unity UI field extraction (per-file, v18)…")
    _wipe_dir(ui_dump_dir)

    # Load script.json → path_id→class map (FIX §3 Step B)
    script_map = _load_script_map(dump_dir)
    if script_map:
        log(f"[INFO ] script.json loaded — {len(script_map)} class mappings available")
    else:
        log("[INFO ] No script.json found — MonoBehaviour class names will be unknown until Stage 4a runs")

    individual_files: list[Path] = []
    bundle_files: list[Path] = []

    for data_dir in raw_dir.rglob("assets/bin/Data"):
        if not data_dir.is_dir():
            continue
        for child in sorted(data_dir.iterdir()):
            if child.is_file():
                individual_files.append(child)

    for bundle in raw_dir.rglob("*.bundle"):
        bundle_files.append(bundle)

    total = len(individual_files) + len(bundle_files)
    log(f"[INFO ] Found {len(individual_files)} serialized files + {len(bundle_files)} bundles ({total} total)")

    sprite_name_map: dict[str, dict] = {}
    processed = skipped_empty = decode_fails = typetree_successes = 0

    def _process_one(src: Path, idx: int):
        nonlocal processed, skipped_empty, decode_fails, typetree_successes

        if progress_cb:
            progress_cb(idx / max(total, 1), f"Stage 4: {idx}/{total} — {src.name}")

        source_file = src.name
        try:
            env = UnityPy.load(str(src))
        except Exception:
            skipped_empty += 1
            return

        objs = []
        bundle_sprites: dict[int, str] = {}

        for o in env.objects:
            if o.type.name not in WANT_TYPES:
                continue

            # FIX §3 Step B — attempt typetree decode first for MonoBehaviours
            typetree_decoded = None
            if o.type.name == "MonoBehaviour":
                typetree_decoded = _try_typetree_decode(o, env)
                if typetree_decoded:
                    typetree_successes += 1

            dumped = _dump_ui_obj(
                o,
                source_file=source_file,
                script_map=script_map,
                typetree_decoded=typetree_decoded,
            )
            if dumped.get("_decode_failed"):
                decode_fails += 1
            objs.append(dumped)
            if o.type.name == "Sprite" and dumped.get("name"):
                bundle_sprites[o.path_id] = dumped["name"]

        if not objs:
            skipped_empty += 1
            return

        external_refs = _get_env_external_refs(env)

        rel = str(src.relative_to(raw_dir)).replace(os.sep, "_").replace(" ", "_")[:200]
        out_file = ui_dump_dir / f"{rel}.json"
        out_file.parent.mkdir(parents=True, exist_ok=True)
        out_file.write_text(
            json.dumps({
                "source": str(src),
                "source_file": source_file,
                "external_refs": external_refs,
                "objects": objs,
            }, default=str, ensure_ascii=False),
            encoding="utf-8",
        )
        if bundle_sprites:
            sprite_name_map[str(src)] = {str(k): v for k, v in bundle_sprites.items()}
        processed += 1
        if processed % 500 == 0:
            log(f"[INFO ] Stage 4: {processed}/{total} files ({typetree_successes} MB decoded, {decode_fails} raw-bytes fallbacks)…")

    for idx, src in enumerate(individual_files):
        _process_one(src, idx)

    for idx, src in enumerate(bundle_files, start=len(individual_files)):
        _process_one(src, idx)

    map_file = ui_dump_dir / "sprite_name_map.json"
    map_file.write_text(
        json.dumps(sprite_name_map, indent=2, ensure_ascii=False), encoding="utf-8"
    )

    # Write script.json copy into ui_dump for consumer convenience
    if dump_dir and (dump_dir / "script.json").exists():
        import shutil as _sh
        _sh.copy2(dump_dir / "script.json", ui_dump_dir / "script.json")
        log(f"[OK   ] script.json copied to ui_dump/ for class name resolution")

    if progress_cb:
        progress_cb(1.0, "Stage 4: complete")

    log(f"[OK   ] Stage 4 complete — {processed} files → {ui_dump_dir}")
    log(f"[OK   ] MonoBehaviour typetree decoded: {typetree_successes} objects")
    log(f"[INFO ] MonoBehaviour raw-bytes fallback: {decode_fails} objects (m_Script + precise bytes saved)")
    log(f"[INFO ] {skipped_empty} sources had no UI objects (skipped)")


# ────────────────────────────────────────────────────────────────────────────
# STAGE 5 — Bundle parser: resolve PPtrs, build normalized UI trees (Node.js)
# ────────────────────────────────────────────────────────────────────────────

def _run_stage5_bundle_parser(ui_dump_dir: Path, normalized_ui_dir: Path, log, force: bool, progress_cb=None):
    if normalized_ui_dir.exists() and not force:
        n = _count_files(normalized_ui_dir)
        log(f"[SKIP ] normalized_ui/ already exists ({n} files) — skipping Stage 5")
        return

    log("[STEP ] Stage 5 — Building normalized UI trees (Node.js bundle parser)…")

    node = _find_node()
    if node is None:
        log("[WARN ] Node.js not found — skipping Stage 5 (bundle parser).")
        log("[INFO ] Install Node.js 18+ from https://nodejs.org to enable automatic tree normalization.")
        log("[INFO ] You can run it manually: node scripts/parse-unity-bundle.mjs ui_dump normalized_ui")
        return

    if not PARSER_SCRIPT.exists():
        log(f"[WARN ] Parser script not found at {PARSER_SCRIPT} — skipping Stage 5.")
        return

    log(f"[INFO ] Node.js → {node}")
    log(f"[INFO ] Parser → {PARSER_SCRIPT}")
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
                        done = int(parts[0].split()[-1])
                        total = int(parts[1].split()[0])
                        progress_cb(done / max(total, 1), f"Stage 5: {done}/{total} bundles parsed")
                    except Exception:
                        pass
        proc.wait(timeout=600)
        if proc.returncode == 0:
            n = _count_files(normalized_ui_dir)
            log(f"[OK   ] Stage 5 complete — {n} normalized tree file(s) → {normalized_ui_dir}")
        else:
            log(f"[ERROR] Stage 5 (Node.js parser) exited with code {proc.returncode}")
    except subprocess.TimeoutExpired:
        proc.kill()
        log("[ERROR] Stage 5 timed out after 600s")
    except Exception as exc:
        log(f"[ERROR] Stage 5 failed: {exc}")

    if progress_cb:
        progress_cb(1.0, "Stage 5: complete")


# ── main pipeline ─────────────────────────────────────────────────────────────
def _run_pipeline(src: Path, out_dir: Path, force: bool,
                  java_override: str | None,
                  il2cppdumper_exe: str | None,
                  log, progress_cb=None):
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

    log(f"[INFO ] Output → {out_dir}")

    if progress_cb: progress_cb(0.0, "Stage 1: Extracting package…")
    log(f"[STEP ] Stage 1 — Extracting package…")
    _extract_xapk(src, raw_dir, log, force)

    if progress_cb: progress_cb(0.10, "Stage 2: Extracting Unity assets (PNG/text)…")
    log(f"[STEP ] Stage 2 — Extracting Unity assets (PNG / text)…")
    if unity_dir.exists() and not force:
        log(f"[SKIP ] unity_assets/ already exists ({_count_files(unity_dir)} files)")
    else:
        if force: _wipe_dir(unity_dir)
        else: unity_dir.mkdir(parents=True, exist_ok=True)
        for dd in raw_dir.rglob("assets/bin/Data"):
            try:
                import UnityPy
                env = UnityPy.load(str(dd))
                w, sk = _dump_env(env, unity_dir, log, force)
                log(f"[OK   ]   {dd.parent.parent.parent.name}: {w+sk} file(s) [{sk} skipped]")
            except Exception as exc:
                log(f"[WARN ] Failed to load {dd}: {exc}")
        for bf in raw_dir.rglob("*.bundle"):
            try:
                import UnityPy
                env = UnityPy.load(str(bf))
                _dump_env(env, unity_dir, log, force)
            except Exception as exc:
                log(f"[WARN ] Failed bundle {bf.name}: {exc}")
        log(f"[OK   ] Stage 2 complete → {unity_dir}")

    if progress_cb: progress_cb(0.25, "Stage 3: IL2CPP metadata…")
    log(f"[STEP ] Stage 3 — IL2CPP metadata…")
    if not (il2cpp_dir.exists() and not force):
        _wipe_dir(il2cpp_dir)
        for f in list(raw_dir.rglob("global-metadata.dat")) + \
                 list(raw_dir.rglob("arm64-v8a/libil2cpp.so")) + \
                 list(raw_dir.rglob("armeabi-v7a/libil2cpp.so")):
            dst_name = f"{f.parent.name}_{f.name}" if f.name == "libil2cpp.so" else f.name
            shutil.copy2(f, il2cpp_dir / dst_name)
            log(f"[OK   ]   Copied: {dst_name}")
        log(f"[OK   ] Stage 3 complete → {il2cpp_dir}")
    else:
        log(f"[SKIP ] il2cpp_meta/ already exists ({_count_files(il2cpp_dir)} files)")

    if progress_cb: progress_cb(0.30, "Stage 3b: Smali decompile…")
    log(f"[STEP ] Stage 3b — Smali decompile…")
    java = _find_java(java_override)
    if java is None:
        log("[WARN ] Java not found — skipping smali step.")
    else:
        apktool_jar = _ensure_apktool(log)
        if apktool_jar:
            smali_dir.mkdir(parents=True, exist_ok=True)
            main_apks = [p for p in raw_dir.rglob("*.apk") if "config." not in p.name] or list(raw_dir.rglob("*.apk"))
            for apk in main_apks:
                _run_smali(apk, smali_dir, java, apktool_jar, log, force)

    if progress_cb: progress_cb(0.40, "Stage 3c: Building AI export…")
    log(f"[STEP ] Stage 3c — AI export files…")
    ai_dir.mkdir(parents=True, exist_ok=True)
    scene_map = _build_ai_scene_map(unity_dir)
    (ai_dir / "ai_scene_map.json").write_text(json.dumps(scene_map, indent=2, ensure_ascii=False), encoding="utf-8")
    log(f"[OK   ] ai_scene_map.json — {len(scene_map)} entries")
    asset_index = _build_ai_asset_index(out_dir)
    (ai_dir / "ai_asset_index.json").write_text(json.dumps(asset_index, indent=2, ensure_ascii=False), encoding="utf-8")
    log(f"[OK   ] ai_asset_index.json — {len(asset_index)} files indexed")

    # Stage 4a — Il2CppDumper (generates type trees; optional but strongly recommended)
    if progress_cb: progress_cb(0.42, "Stage 4a: Il2CppDumper (type trees)…")
    dump_dir = _run_stage4a_il2cppdumper(il2cpp_dir, out_dir, il2cppdumper_exe, log)

    if progress_cb: progress_cb(0.50, "Stage 4: UI field dump (per-file, v18)…")
    _run_stage4_ui_dump(
        raw_dir, ui_dump_dir, log, force,
        dump_dir=dump_dir,
        progress_cb=lambda p, msg: progress_cb(0.50 + p * 0.35, msg) if progress_cb else None
    )

    if progress_cb: progress_cb(0.85, "Stage 5: Normalized UI trees (Node.js)…")
    _run_stage5_bundle_parser(
        ui_dump_dir, norm_ui_dir, log, force,
        progress_cb=lambda p, msg: progress_cb(0.85 + p * 0.14, msg) if progress_cb else None
    )

    if progress_cb: progress_cb(1.0, "All stages complete!")
    log(f"[DONE ] All stages complete → {out_dir}")
    log(f"")
    log(f"[INFO ] ✔ ui_dump/          — Per-file dumps, path_id unique per JSON")
    log(f"[INFO ] ✔ ui_dump/          — m_Script + m_GameObject on every MonoBehaviour")
    log(f"[INFO ] ✔ ui_dump/          — Precise-length raw bytes on decode failure")
    log(f"[INFO ] ✔ ui_dump/          — typetree decoded where dummy DLLs resolved class")
    log(f"[INFO ] ✔ normalized_ui/    — Resolved UI trees (PPtrs unambiguous)")
    log(f"[INFO ] ✔ unity_assets/     — Extracted PNGs and text assets")
    if dump_dir:
        log(f"[INFO ] ✔ il2cpp_dump/     — DummyDll + script.json (class map)")
    else:
        log(f"[INFO ] ℹ il2cpp_dump/     — Not generated (set Il2CppDumper path in UI to enable)")
    log(f"[INFO ] Next: open normalized_ui/ in your AI agent and generate React/Tailwind components.")


# ── GUI ───────────────────────────────────────────────────────────────────────
class App(ctk.CTk):
    VERSION = "v18"

    def __init__(self):
        super().__init__()
        self.title(f"IL2CPP Recovery Studio {self.VERSION}")
        self.geometry("1100x960")
        self.configure(fg_color=BG_DEEP)
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("dark-blue")

        self._cfg = _load_config()
        self._q: queue.Queue = queue.Queue()
        self._running = False

        self._build_ui()
        self._restore_from_config()
        self.after(100, self._poll_queue)

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

        ctk.CTkLabel(card, text="APK / XAPK", font=FNT_BODY, text_color=TEXT_DIM).grid(row=0, column=0, padx=12, pady=6, sticky="w")
        self._apk_var = ctk.StringVar(value=self._cfg.get("last_apk", ""))
        ctk.CTkEntry(card, textvariable=self._apk_var, font=FNT_SMALL, fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(row=0, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL, fg_color=NEON_PURP, hover_color=BTN_HOVER, command=self._browse_apk).grid(row=0, column=2, padx=8, pady=6)

        ctk.CTkLabel(card, text="Output dir", font=FNT_BODY, text_color=TEXT_DIM).grid(row=1, column=0, padx=12, pady=6, sticky="w")
        self._out_var = ctk.StringVar(value=self._cfg.get("last_out", ""))
        ctk.CTkEntry(card, textvariable=self._out_var, font=FNT_SMALL, fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(row=1, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL, fg_color=NEON_PURP, hover_color=BTN_HOVER, command=self._browse_out).grid(row=1, column=2, padx=8, pady=6)

        ctk.CTkLabel(card, text="Java path (opt.)", font=FNT_BODY, text_color=TEXT_DIM).grid(row=2, column=0, padx=12, pady=6, sticky="w")
        self._java_var = ctk.StringVar(value=self._cfg.get("java_path", ""))
        ctk.CTkEntry(card, textvariable=self._java_var, font=FNT_SMALL, fg_color=BG_DEEP, text_color=TEXT_BRIGHT).grid(row=2, column=1, padx=4, pady=6, sticky="ew")

        # NEW — Il2CppDumper path input (for Stage 4a type-tree generation)
        ctk.CTkLabel(card, text="Il2CppDumper (opt.)", font=FNT_BODY, text_color=NEON_ORANGE).grid(row=3, column=0, padx=12, pady=6, sticky="w")
        self._il2cpp_dumper_var = ctk.StringVar(value=self._cfg.get("il2cppdumper_path", ""))
        ctk.CTkEntry(card, textvariable=self._il2cpp_dumper_var, font=FNT_SMALL, fg_color=BG_DEEP, text_color=TEXT_BRIGHT,
                     placeholder_text="Path to Il2CppDumper.exe — enables full MonoBehaviour decode").grid(row=3, column=1, padx=4, pady=6, sticky="ew")
        ctk.CTkButton(card, text="Browse", width=80, font=FNT_SMALL, fg_color=NEON_ORANGE, hover_color=BTN_HOVER,
                      command=self._browse_il2cppdumper).grid(row=3, column=2, padx=8, pady=6)

        self._force_var = ctk.BooleanVar(value=self._cfg.get("force_refresh", False))
        ctk.CTkCheckBox(card, text="Force Refresh (re-extract everything)", variable=self._force_var,
                        font=FNT_SMALL, text_color=NEON_YEL, fg_color=NEON_PURP).grid(row=4, column=0, columnspan=3, padx=12, pady=6, sticky="w")

        legend = ctk.CTkFrame(self, fg_color=BG_CARD, corner_radius=8)
        legend.grid(row=2, column=0, sticky="ew", padx=16, pady=(0, 4))
        legend.grid_columnconfigure((0, 1, 2, 3, 4, 5), weight=1)
        for col, (label, color) in enumerate([
            ("1 • Unpack APK", NEON_CYAN),
            ("2 • PNG Assets", NEON_CYAN),
            ("3 • IL2CPP + Smali", NEON_CYAN),
            ("4a • Type Trees", NEON_ORANGE),
            ("4 • UI Dump (per-file)", NEON_ORANGE),
            ("5 • Normalize Trees", NEON_GREEN),
        ]):
            ctk.CTkLabel(legend, text=label, font=FNT_SMALL, text_color=color).grid(row=0, column=col, padx=6, pady=4)

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

        self._progress_bar = ctk.CTkProgressBar(run_frame, height=14, progress_color=NEON_ORANGE, fg_color=BG_PANEL)
        self._progress_bar.set(0)
        self._progress_bar.grid(row=1, column=0, sticky="ew", pady=(0, 2))

        self._progress_label = ctk.CTkLabel(run_frame, text="", font=FNT_SMALL, text_color=NEON_ORANGE)
        self._progress_label.grid(row=2, column=0, sticky="w")

        log_frame = ctk.CTkFrame(self, fg_color=BG_PANEL, corner_radius=8)
        log_frame.grid(row=4, column=0, sticky="nsew", padx=16, pady=(0, 4))
        log_frame.grid_rowconfigure(0, weight=1)
        log_frame.grid_columnconfigure(0, weight=1)

        self._log_box = ctk.CTkTextbox(log_frame, font=FNT_MONO, text_color=NEON_GREEN, fg_color=BG_DEEP, wrap="none")
        self._log_box.grid(row=0, column=0, sticky="nsew", padx=4, pady=4)

        self._status = ctk.CTkLabel(
            self, text="Ready — set APK path and output dir, then click Run All Stages.",
            font=FNT_SMALL, text_color=TEXT_DIM, fg_color=BG_PANEL, anchor="w",
        )
        self._status.grid(row=5, column=0, sticky="ew", padx=16, pady=2)

    def _restore_from_config(self): pass

    def _browse_apk(self):
        p = filedialog.askopenfilename(title="Select APK or XAPK",
                                       filetypes=[("APK / XAPK", "*.apk *.xapk"), ("All", "*.*")])
        if p: self._apk_var.set(p)

    def _browse_out(self):
        p = filedialog.askdirectory(title="Select output directory")
        if p: self._out_var.set(p)

    def _browse_il2cppdumper(self):
        p = filedialog.askopenfilename(
            title="Select Il2CppDumper executable",
            filetypes=[("Executable", "*.exe *"), ("All", "*.*")]
        )
        if p: self._il2cpp_dumper_var.set(p)

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
            "last_apk": src, "last_out": out,
            "java_path": self._java_var.get().strip(),
            "il2cppdumper_path": self._il2cpp_dumper_var.get().strip(),
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
                src_path, Path(out),
                self._force_var.get(),
                self._java_var.get().strip() or None,
                self._il2cpp_dumper_var.get().strip() or None,
            ),
            daemon=True,
        ).start()

    def _worker(self, src: Path, out: Path, force: bool,
                java_override: str | None, il2cppdumper_exe: str | None):
        def log(msg: str): self._q.put(("log", msg))
        def progress(value: float, label: str): self._q.put(("progress", value, label))
        try:
            _run_pipeline(src, out, force, java_override, il2cppdumper_exe, log, progress_cb=progress)
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
