#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — app.py v10

Changes vs v9:
- apktool: Popen + streaming stdout/stderr → lines appear in log live.
  10-minute hard timeout; process is killed if it exceeds it.
- Unity: also scans raw/ for .bundle / .ab files and loads each via UnityPy.
- Unity: much wider type coverage — VideoClip, AnimationClip, AnimatorController,
  Cubemap, Sprite (explicit), plus a JSON fallback for any named object whose
  type doesn't match a known handler.
- Scene/UI dump limit raised to 20 000 entries per file.
- apktool target APK is always the main APK inside the XAPK, not the outer
  XAPK file itself (apktool cannot decompile XAPK directly).
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

APKTOOL_VER = "2.9.3"
APKTOOL_URL = (
    f"https://github.com/iBotPeaches/Apktool/releases/download/"
    f"v{APKTOOL_VER}/apktool_{APKTOOL_VER}.jar"
)
TOOLS_DIR = Path(__file__).parent / "tools"
APKTOOL_TIMEOUT = 600  # 10 minutes


def _count_files(path: Path) -> int:
    return sum(1 for p in path.rglob("*") if p.is_file()) if path.exists() else 0


def _wipe_dir(path: Path):
    if path.exists():
        shutil.rmtree(path, ignore_errors=True)
    path.mkdir(parents=True, exist_ok=True)


def _safe_name(raw: str, fallback: str = "unnamed") -> str:
    s = "".join(c if c.isalnum() or c in " _-." else "_" for c in str(raw)).strip()
    return s or fallback


def _find_apktool() -> tuple[str | None, Path | None]:
    for name in ("apktool.bat", "apktool"):
        found = shutil.which(name)
        if found:
            return found, None
    bat = TOOLS_DIR / "apktool.bat"
    jar = TOOLS_DIR / "apktool.jar"
    if bat.exists() and jar.exists():
        return str(bat), jar
    if jar.exists():
        return None, jar
    return None, None


def _install_apktool(log_fn) -> tuple[str | None, Path | None]:
    try:
        TOOLS_DIR.mkdir(parents=True, exist_ok=True)
        jar = TOOLS_DIR / "apktool.jar"
        bat = TOOLS_DIR / "apktool.bat"
        if not jar.exists():
            log_fn(f"Downloading apktool {APKTOOL_VER} (~22 MB) …", "INFO")
            tmp = jar.with_suffix(".tmp")
            for attempt in range(1, 4):
                try:
                    with urllib.request.urlopen(APKTOOL_URL, timeout=60) as resp:
                        total = int(resp.headers.get("Content-Length", 0))
                        done = 0
                        with open(tmp, "wb") as f:
                            while True:
                                chunk = resp.read(65536)
                                if not chunk:
                                    break
                                f.write(chunk)
                                done += len(chunk)
                    if total and done < total:
                        raise IOError(f"Incomplete: {done}/{total} bytes")
                    tmp.replace(jar)
                    log_fn(f"apktool.jar downloaded ({done // 1024} KB)", "OK")
                    break
                except Exception as e:
                    log_fn(f"  Attempt {attempt} failed: {e}", "WARN")
                    if tmp.exists():
                        tmp.unlink()
                    if attempt < 3:
                        time.sleep(2)
            else:
                log_fn("Download failed after 3 attempts.", "ERROR")
                return None, None
        else:
            log_fn("apktool.jar already cached.", "SKIP")
        if not bat.exists():
            bat.write_text(f'@echo off\ncall java -jar "{jar}" %*\n', encoding="ascii")
            log_fn(f"apktool.bat written → {bat}", "OK")
        r = subprocess.run(["java", "-version"], capture_output=True, text=True)
        if r.returncode != 0:
            log_fn("Java not found — install JRE/JDK 8+.", "WARN")
            return None, jar
        return str(bat), jar
    except Exception as e:
        log_fn(f"apktool install failed: {e}", "ERROR")
        return None, None


def make_btn(parent, text, command, color=NEON_CYAN, height=42, font=FNT_BODY):
    return ctk.CTkButton(parent, text=text, command=command,
                         fg_color=BG_CARD, hover_color=BTN_HOVER,
                         border_width=2, border_color=color, text_color=color,
                         corner_radius=8, font=font, height=height)


class SectionCard(ctk.CTkFrame):
    def __init__(self, master, title, accent=NEON_CYAN, **kw):
        super().__init__(master, fg_color=BG_CARD, border_width=1,
                         border_color=accent, corner_radius=10, **kw)
        ctk.CTkLabel(self, text=f"  {title}", font=FNT_HEAD,
                     text_color=accent, fg_color=BG_CARD).pack(anchor="nw", padx=14, pady=(10, 3))
        ctk.CTkFrame(self, height=1, fg_color=accent).pack(fill="x", padx=14)


class LogConsole(ctk.CTkTextbox):
    COLORS = {"INFO": NEON_CYAN, "OK": NEON_GREEN, "WARN": NEON_YEL,
              "ERROR": NEON_PINK, "SKIP": TEXT_DIM, "STEP": NEON_PURP}

    def __init__(self, master, **kw):
        super().__init__(master, fg_color="#06060e", text_color=TEXT_BRIGHT,
                         font=FNT_MONO, wrap="word", state="disabled", **kw)
        for tag, color in self.COLORS.items():
            self._textbox.tag_config(tag, foreground=color)

    def log(self, msg, level="INFO"):
        tag = level if level in self.COLORS else "INFO"
        self.configure(state="normal")
        self._textbox.insert("end", f"[{level:<5}] ", tag)
        self._textbox.insert("end", msg + "\n")
        self._textbox.see("end")
        self.configure(state="disabled")

    def clear(self):
        self.configure(state="normal")
        self.delete("0.0", "end")
        self.configure(state="disabled")


class IL2CPPStudio(ctk.CTk):
    APP_TITLE = "IL2CPP Recovery Studio  •  NEON v2"
    WIN_SIZE = "1200x780"

    def __init__(self):
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("dark-blue")
        super().__init__()
        self.title(self.APP_TITLE)
        self.geometry(self.WIN_SIZE)
        self.minsize(960, 680)
        self.configure(fg_color=BG_DEEP)
        self._apk_path: Path | None = None
        self._output_dir: Path | None = None
        self._running = False
        self._force_refresh = ctk.BooleanVar(value=True)
        self._ops = {
            "extract_apk":     ctk.BooleanVar(value=True),
            "extract_assets":  ctk.BooleanVar(value=True),
            "extract_il2cpp":  ctk.BooleanVar(value=True),
            "decompile_smali": ctk.BooleanVar(value=False),
            "gen_report":      ctk.BooleanVar(value=True),
        }
        self._build_ui()
        self.after(200, self._animate_header)

    # ── UI ────────────────────────────────────────────────────────
    def _build_ui(self):
        hdr = ctk.CTkFrame(self, fg_color=BG_PANEL, height=66, corner_radius=0)
        hdr.pack(fill="x")
        hdr.pack_propagate(False)
        self._hdr_lbl = ctk.CTkLabel(hdr, text=self.APP_TITLE, font=FNT_TITLE, text_color=NEON_CYAN)
        self._hdr_lbl.pack(side="left", padx=22)
        ctk.CTkLabel(hdr, text="● SYSTEM ONLINE", font=FNT_BODY, text_color=NEON_GREEN).pack(side="right", padx=22)
        body = ctk.CTkFrame(self, fg_color=BG_DEEP)
        body.pack(fill="both", expand=True, padx=12, pady=8)
        body.columnconfigure(0, weight=5); body.columnconfigure(1, weight=7)
        body.rowconfigure(0, weight=1)
        self._build_left(body); self._build_right(body)
        bar = ctk.CTkFrame(self, fg_color=BG_PANEL, height=32, corner_radius=0)
        bar.pack(fill="x", side="bottom")
        bar.pack_propagate(False)
        self._status_lbl = ctk.CTkLabel(bar, text="►  Ready — select a file.", font=FNT_SMALL, text_color=NEON_CYAN)
        self._status_lbl.pack(side="left", padx=16)

    def _build_left(self, parent):
        left = ctk.CTkScrollableFrame(parent, fg_color=BG_DEEP,
                                      scrollbar_button_color=BG_CARD,
                                      scrollbar_button_hover_color=NEON_PURP)
        left.grid(row=0, column=0, sticky="nsew", padx=(0, 8))
        fc = SectionCard(left, "📂  INPUT FILE", NEON_PURP)
        fc.pack(fill="x", pady=(0, 10))
        self._file_lbl = ctk.CTkLabel(fc, text="No file selected", font=FNT_BODY,
                                      text_color=TEXT_DIM, wraplength=340, anchor="w")
        self._file_lbl.pack(fill="x", padx=14, pady=(8, 4))
        make_btn(fc, "  Browse APK / XAPK…", self._browse_apk, NEON_PURP, 46).pack(fill="x", padx=14, pady=(4, 12))
        oc = SectionCard(left, "📁  OUTPUT DIRECTORY", NEON_CYAN)
        oc.pack(fill="x", pady=(0, 10))
        self._out_lbl = ctk.CTkLabel(oc, text="Auto: next to input file", font=FNT_BODY,
                                     text_color=TEXT_DIM, wraplength=340, anchor="w")
        self._out_lbl.pack(fill="x", padx=14, pady=(8, 4))
        make_btn(oc, "  Browse Output Folder…", self._browse_output, NEON_CYAN, 42).pack(fill="x", padx=14, pady=(4, 12))
        ops_card = SectionCard(left, "⚙  OPERATIONS", NEON_GREEN)
        ops_card.pack(fill="x", pady=(0, 10))
        for key, label, desc in [
            ("extract_apk",     "📦  Extract APK/XAPK",   "Rebuild raw/ from source"),
            ("extract_assets",  "🎨  Extract Unity assets","Textures, audio, meshes, bundles, scenes"),
            ("extract_il2cpp",  "🔍  Parse IL2CPP",         "global-metadata.dat + libil2cpp.so"),
            ("decompile_smali", "🖥  Decompile Smali",      "Uses apktool, auto-installs if needed"),
            ("gen_report",      "📝  HTML Report",          "Deep tree summary → report.html"),
        ]:
            row = ctk.CTkFrame(ops_card, fg_color="transparent")
            row.pack(fill="x", padx=14, pady=4)
            ctk.CTkCheckBox(row, text=label, variable=self._ops[key],
                            font=FNT_BODY, text_color=TEXT_WHITE,
                            checkmark_color=BG_DEEP, fg_color=NEON_GREEN,
                            hover_color=NEON_PURP, border_color=NEON_GREEN,
                            border_width=2).pack(anchor="w")
            ctk.CTkLabel(row, text=f"    {desc}", font=FNT_SMALL,
                         text_color=TEXT_DIM, anchor="w").pack(anchor="w", padx=26)
        ctk.CTkCheckBox(ops_card, text="♻  Force refresh selected outputs before run",
                        variable=self._force_refresh, font=FNT_BODY,
                        text_color=NEON_YEL, checkmark_color=BG_DEEP,
                        fg_color=NEON_YEL, hover_color=NEON_PURP,
                        border_color=NEON_YEL, border_width=2).pack(anchor="w", padx=14, pady=(8, 12))
        self._run_btn = make_btn(left, "  ▶   RUN ANALYSIS", self._start_analysis, NEON_GREEN, 52, FNT_RUN)
        self._run_btn.pack(fill="x", pady=(4, 6))
        make_btn(left, "  📁   Open Output Folder", self._open_output, NEON_PURP, 42).pack(fill="x")

    def _build_right(self, parent):
        right = ctk.CTkFrame(parent, fg_color=BG_DEEP)
        right.grid(row=0, column=1, sticky="nsew")
        right.rowconfigure(1, weight=1); right.columnconfigure(0, weight=1)
        pg = SectionCard(right, "⚡  PROGRESS", NEON_CYAN)
        pg.grid(row=0, column=0, sticky="ew", pady=(0, 8))
        self._progress = ctk.CTkProgressBar(pg, fg_color=BG_DEEP, progress_color=NEON_CYAN,
                                            border_width=1, border_color=NEON_PURP, height=20, corner_radius=6)
        self._progress.set(0)
        self._progress.pack(fill="x", padx=14, pady=(10, 4))
        self._prog_lbl = ctk.CTkLabel(pg, text="Idle…", font=FNT_BODY, text_color=TEXT_BRIGHT)
        self._prog_lbl.pack(padx=14, pady=(0, 10))
        lg = SectionCard(right, "🖥  LOG CONSOLE", NEON_PURP)
        lg.grid(row=1, column=0, sticky="nsew", pady=(0, 8))
        self._log = LogConsole(lg)
        self._log.pack(fill="both", expand=True, padx=14, pady=10)
        rs = SectionCard(right, "✅  RESULTS", NEON_GREEN)
        rs.grid(row=2, column=0, sticky="ew")
        self._results_txt = ctk.CTkTextbox(rs, fg_color="#06060e", text_color=NEON_GREEN,
                                           font=FNT_MONO_B, height=140, state="disabled")
        self._results_txt.pack(fill="x", padx=14, pady=10)

    _GLYPHS = ["■", "□", "▒", "░", "□", "■"]; _glyph_i = 0

    def _animate_header(self):
        if not self.winfo_exists(): return
        g = self._GLYPHS[self._glyph_i % len(self._GLYPHS)]
        self._hdr_lbl.configure(text=f"{g}  {self.APP_TITLE}  {g}")
        self._glyph_i += 1
        self.after(500, self._animate_header)

    def _animate_progress(self):
        if not self._running or not self.winfo_exists(): return
        v = self._progress.get()
        if v < 0.93: self._progress.set(v + 0.004)
        self.after(100, self._animate_progress)

    def _browse_apk(self):
        self.lift(); self.focus_force(); self.update()
        path = filedialog.askopenfilename(parent=self, title="Select APK or XAPK",
                                          filetypes=[("APK / XAPK", "*.apk *.xapk"), ("All", "*.*")])
        self.lift(); self.focus_force()
        if path:
            self._apk_path = Path(path)
            self._file_lbl.configure(text=f"✅  {self._apk_path.name}", text_color=NEON_GREEN)
            self._status(f"►  Loaded: {self._apk_path.name}")
            if not self._output_dir:
                self._output_dir = self._apk_path.parent / (self._apk_path.stem + "_output")
                self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)

    def _browse_output(self):
        self.lift(); self.focus_force(); self.update()
        path = filedialog.askdirectory(parent=self, title="Select output folder")
        self.lift(); self.focus_force()
        if path:
            self._output_dir = Path(path)
            self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)

    def _start_analysis(self):
        if self._running:
            self._status("⚠  Already running."); return
        if not self._apk_path:
            messagebox.showerror("No File", "Click 'Browse APK / XAPK' first.", parent=self); return
        if not self._apk_path.exists():
            messagebox.showerror("Not Found", f"{self._apk_path}\n\nFile missing — re-select.", parent=self); return
        ops = {k: v.get() for k, v in self._ops.items()}
        if not any(ops.values()):
            messagebox.showwarning("Nothing selected", "Tick at least one operation.", parent=self); return
        self._running = True
        self._run_btn.configure(state="disabled", text="  ⏳   RUNNING…")
        self._log.clear(); self._set_results("")
        self._progress.set(0)
        self._prog_lbl.configure(text="Starting…", text_color=NEON_CYAN)
        self._status("►  Running — please wait…")
        self._animate_progress()
        threading.Thread(target=self._run_pipeline, args=(ops,), daemon=True).start()

    # ── PIPELINE ──────────────────────────────────────────────────
    def _run_pipeline(self, ops: dict):
        out = self._output_dir
        apk = self._apk_path
        try:
            out.mkdir(parents=True, exist_ok=True)
            self._log_t(f"Output → {out}", "INFO")
            force = self._force_refresh.get()

            raw = out / "raw"
            if ops["extract_apk"]:
                self._step("Extracting package…")
                if force:
                    self._log_t("Force refresh — rebuilding raw/", "INFO")
                    _wipe_dir(raw)
                elif _count_files(raw) > 0:
                    self._log_t(f"raw/ has {_count_files(raw)} files — reusing.", "SKIP")
                else:
                    raw.mkdir(parents=True, exist_ok=True)
                if _count_files(raw) == 0:
                    self._extract_apk(apk, raw)

            if ops["extract_assets"]:
                adir = out / "unity_assets"
                self._step("Extracting Unity assets…")
                if force:
                    self._log_t("Force refresh — rebuilding unity_assets/", "INFO")
                    _wipe_dir(adir)
                else:
                    adir.mkdir(parents=True, exist_ok=True)
                    if _count_files(adir) > 0:
                        self._log_t(f"unity_assets/ has {_count_files(adir)} files — reusing.", "SKIP")
                if _count_files(adir) == 0:
                    self._do_unity(out, adir)

            if ops["extract_il2cpp"]:
                mdir = out / "il2cpp_meta"
                self._step("Parsing IL2CPP metadata…")
                if force:
                    self._log_t("Force refresh — rebuilding il2cpp_meta/", "INFO")
                    _wipe_dir(mdir)
                else:
                    mdir.mkdir(parents=True, exist_ok=True)
                    if _count_files(mdir) > 0:
                        self._log_t(f"il2cpp_meta/ has {_count_files(mdir)} files — reusing.", "SKIP")
                if _count_files(mdir) == 0:
                    self._do_il2cpp(out, mdir)

            if ops["decompile_smali"]:
                sdir = out / "smali"
                self._step("Decompiling Smali…")
                if force:
                    self._log_t("Force refresh — rebuilding smali/", "INFO")
                    _wipe_dir(sdir)
                else:
                    sdir.mkdir(parents=True, exist_ok=True)
                    if _count_files(sdir) > 0:
                        self._log_t(f"smali/ has {_count_files(sdir)} files — reusing.", "SKIP")
                if _count_files(sdir) == 0:
                    # apktool must target the main APK, not the outer XAPK
                    target = self._find_main_apk(raw, apk)
                    self._do_apktool(target, sdir)

            if ops["gen_report"]:
                self._step("Generating HTML report…")
                self._do_report(out)

            self.after(0, lambda: self._progress.set(1.0))
            self.after(0, lambda: self._prog_lbl.configure(text="Done! ✅", text_color=NEON_GREEN))
            self._status("✅  Complete!")
            self._log_t("All done!", "OK")
            self._show_results(out)
        except Exception as exc:
            import traceback
            self._log_t(f"FATAL: {exc}", "ERROR")
            self._log_t(traceback.format_exc(), "ERROR")
            self._status("❌  Error — check log.")
        finally:
            self._running = False
            self.after(0, lambda: self._run_btn.configure(state="normal", text="  ▶   RUN ANALYSIS"))

    def _extract_apk(self, apk: Path, raw: Path):
        if apk.suffix.lower() == ".xapk":
            self._log_t("XAPK — extracting outer archive…", "INFO")
            with zipfile.ZipFile(apk) as z:
                z.extractall(raw)
            for inner in sorted(raw.rglob("*.apk")):
                inner_out = inner.parent / inner.stem
                inner_out.mkdir(parents=True, exist_ok=True)
                with zipfile.ZipFile(inner) as z:
                    z.extractall(inner_out)
                self._log_t(f"  {inner.name} → {inner_out.name}/", "OK")
        else:
            with zipfile.ZipFile(apk) as z:
                z.extractall(raw)
            self._log_t(f"APK → {raw}", "OK")

    def _find_main_apk(self, raw: Path, fallback: Path) -> Path:
        """Return the main APK to pass to apktool (never the outer XAPK)."""
        if fallback.suffix.lower() != ".xapk":
            return fallback
        candidates = sorted(raw.rglob("*.apk"))
        for c in candidates:
            if "config." not in c.name:
                return c
        return candidates[0] if candidates else fallback

    # ── UNITY ─────────────────────────────────────────────────────
    def _do_unity(self, search_root: Path, out: Path):
        import UnityPy

        skip_dirs = {out, out.parent / "il2cpp_meta", out.parent / "smali"}

        # 1. Load each Data/ directory as a whole environment
        data_dirs = [
            p for p in search_root.rglob("Data")
            if p.is_dir() and not any(p.is_relative_to(s) for s in skip_dirs)
        ]
        env_list: list[tuple[str, object]] = []
        if data_dirs:
            for dd in data_dirs:
                label = str(dd.relative_to(search_root))
                self._log_t(f"  Loading Data dir: {label}", "INFO")
                try:
                    env_list.append((label, UnityPy.load(str(dd))))
                except Exception as e:
                    self._log_t(f"  Warning loading {label}: {e}", "WARN")
        else:
            for p in search_root.rglob("*.assets"):
                if not any(p.is_relative_to(s) for s in skip_dirs):
                    try:
                        env_list.append((p.name, UnityPy.load(str(p))))
                    except Exception as e:
                        self._log_t(f"  Skip {p.name}: {e}", "WARN")
            for p in search_root.rglob("level*"):
                if p.is_file() and not p.suffix and not any(p.is_relative_to(s) for s in skip_dirs):
                    try:
                        env_list.append((p.name, UnityPy.load(str(p))))
                    except Exception as e:
                        self._log_t(f"  Skip {p.name}: {e}", "WARN")

        # 2. Also load any .bundle / .ab files found in raw/
        bundle_exts = {".bundle", ".ab", ".assetbundle"}
        bundles = [
            p for p in search_root.rglob("*")
            if p.is_file() and p.suffix.lower() in bundle_exts
            and not any(p.is_relative_to(s) for s in skip_dirs)
        ]
        if bundles:
            self._log_t(f"  Found {len(bundles)} bundle file(s) — loading…", "INFO")
        for b in bundles:
            try:
                env_list.append((f"bundle:{b.name}", UnityPy.load(str(b))))
            except Exception as e:
                self._log_t(f"  Skip bundle {b.name}: {e}", "WARN")

        if not env_list:
            self._log_t("No Unity asset files found.", "WARN")
            return

        total_saved = 0
        total_scene = 0
        scenes_dir = out / "Scenes"; scenes_dir.mkdir(parents=True, exist_ok=True)
        ui_dir = out / "UI"; ui_dir.mkdir(parents=True, exist_ok=True)

        for label, env in env_list:
            saved, scene_entries, ui_entries = self._dump_env(env, out, label)
            if scene_entries:
                scene_file = scenes_dir / (_safe_name(label.replace(os.sep, "_").replace("/", "_"), "scene") + ".json")
                scene_file.write_text(
                    json.dumps(scene_entries[:20000], indent=2, ensure_ascii=False), encoding="utf-8")
                saved += 1
                total_scene += len(scene_entries)
            if ui_entries:
                ui_file = ui_dir / (_safe_name(label.replace(os.sep, "_").replace("/", "_"), "ui") + "_ui.json")
                ui_file.write_text(
                    json.dumps(ui_entries[:20000], indent=2, ensure_ascii=False), encoding="utf-8")
                saved += 1
            self._log_t(f"  {label}: {saved} file(s), {len(scene_entries)} scene, {len(ui_entries)} UI", "OK")
            total_saved += saved

        if total_saved == 0:
            self._log_t("WARNING: 0 files saved. Assets may be in encrypted bundles.", "WARN")
        else:
            self._log_t(f"Total saved: {total_saved} files → {out}", "OK")
            self._log_t(f"Scene entries: {total_scene}", "INFO")

    def _dump_env(self, env, out: Path, label: str) -> tuple[int, list, list]:
        saved = 0
        scene_entries: list[dict] = []
        ui_entries: list[dict] = []

        for obj in env.objects:
            try:
                data = obj.read()
                type_name = obj.type.name
                raw_name = (getattr(data, "name", None) or
                            getattr(data, "m_Name", None) or
                            f"obj_{obj.path_id}")
                safe = _safe_name(str(raw_name), f"obj_{obj.path_id}")
                dest = out / type_name
                dest.mkdir(parents=True, exist_ok=True)

                # ── Texture2D / Sprite / Cubemap ──────────────────
                if hasattr(data, "image") and PILImage:
                    try:
                        img = data.image
                        if img:
                            p = dest / f"{safe}.png"
                            if not p.exists():
                                img.save(str(p))
                                saved += 1
                    except Exception:
                        pass

                # ── AudioClip ─────────────────────────────────────
                elif type_name == "AudioClip":
                    try:
                        for clip_name, clip_data in data.samples.items():
                            cs = _safe_name(clip_name, safe)
                            p = dest / f"{cs}.wav"
                            if not p.exists():
                                p.write_bytes(clip_data)
                                saved += 1
                    except Exception:
                        pass

                # ── TextAsset / MonoBehaviour (text script) ───────
                elif hasattr(data, "m_Script") and data.m_Script:
                    p = dest / f"{safe}.txt"
                    if not p.exists():
                        content = data.m_Script
                        if isinstance(content, (bytes, bytearray)):
                            content = content.decode("utf-8", errors="replace")
                        p.write_text(str(content), encoding="utf-8", errors="replace")
                        saved += 1

                # ── VideoClip ─────────────────────────────────────
                elif type_name == "VideoClip":
                    try:
                        vdata = getattr(data, "m_VideoData", None)
                        if vdata:
                            p = dest / f"{safe}.mp4"
                            if not p.exists():
                                p.write_bytes(bytes(vdata))
                                saved += 1
                    except Exception:
                        pass

                # ── Mesh ──────────────────────────────────────────
                elif type_name == "Mesh":
                    try:
                        exported = data.export()
                        if exported:
                            p = dest / f"{safe}.obj"
                            if not p.exists():
                                p.write_text(str(exported), encoding="utf-8", errors="replace")
                                saved += 1
                    except Exception:
                        pass

                # ── Font ──────────────────────────────────────────
                elif type_name == "Font":
                    try:
                        fdata = getattr(data, "m_FontData", None)
                        if fdata:
                            p = dest / f"{safe}.ttf"
                            if not p.exists():
                                p.write_bytes(fdata)
                                saved += 1
                    except Exception:
                        pass

                # ── AnimationClip ─────────────────────────────────
                elif type_name == "AnimationClip":
                    try:
                        clip_info = {
                            "name": str(raw_name),
                            "m_Length": getattr(data, "m_MuscleClip", {}) and "present",
                            "m_WrapMode": getattr(data, "m_WrapMode", None),
                            "m_FrameRate": getattr(data, "m_SampleRate", None),
                        }
                        p = dest / f"{safe}.json"
                        if not p.exists():
                            p.write_text(json.dumps(clip_info, indent=2, ensure_ascii=False), encoding="utf-8")
                            saved += 1
                    except Exception:
                        pass

                # ── Generic binary fallback (m_Data) ──────────────
                elif hasattr(data, "m_Data") and getattr(data, "m_Data", None):
                    try:
                        raw_bytes = bytes(data.m_Data)
                        if raw_bytes:
                            p = dest / f"{safe}.bin"
                            if not p.exists():
                                p.write_bytes(raw_bytes)
                                saved += 1
                    except Exception:
                        pass

                # ── JSON fallback for any other named object ───────
                else:
                    try:
                        d = {k: v for k, v in vars(data).items()
                             if not k.startswith("_") and isinstance(v, (str, int, float, bool, list, dict, type(None)))}
                        if d:
                            p = dest / f"{safe}.json"
                            if not p.exists():
                                p.write_text(json.dumps(d, indent=2, ensure_ascii=False, default=str),
                                             encoding="utf-8")
                                saved += 1
                    except Exception:
                        pass

                # ── Scene / UI collection ─────────────────────────
                if type_name in {"GameObject", "Canvas", "RectTransform", "Transform", "MonoBehaviour"}:
                    entry: dict = {
                        "path_id": getattr(obj, "path_id", None),
                        "type": type_name,
                        "name": str(raw_name),
                    }
                    for attr in ("m_Layer", "m_TagString", "m_IsActive", "m_IsStatic"):
                        val = getattr(data, attr, None)
                        if val is not None:
                            try:
                                entry[attr] = val
                            except Exception:
                                pass
                    is_ui = (type_name in {"Canvas", "RectTransform"} or
                             any(x in str(raw_name).lower()
                                 for x in ["ui", "button", "panel", "hud", "menu", "canvas", "dialog", "popup"]))
                    (ui_entries if is_ui else scene_entries).append(entry)

            except Exception:
                pass

        return saved, scene_entries, ui_entries

    # ── IL2CPP ────────────────────────────────────────────────────
    def _do_il2cpp(self, search_root: Path, out: Path):
        metas = [p for p in search_root.rglob("global-metadata.dat") if not p.is_relative_to(out)]
        sos   = [p for p in search_root.rglob("libil2cpp.so")        if not p.is_relative_to(out)]
        extra = [p for p in search_root.rglob("*.so")
                 if "il2cpp" in p.name.lower() and p not in sos and not p.is_relative_to(out)]
        sos.extend(extra)
        if not metas: self._log_t("global-metadata.dat not found.", "WARN")
        if not sos:   self._log_t("libil2cpp.so not found.", "WARN")
        copied = 0
        for f in metas + sos:
            rel = f"{f.parent.name}_{f.name}" if f.name == "libil2cpp.so" else f.name
            d = out / rel
            if not d.exists():
                shutil.copy2(f, d)
                self._log_t(f"  Copied: {rel}", "OK")
                copied += 1
        if copied:
            self._log_t(f"IL2CPP → {out}", "OK")
            self._log_t("Use Il2CppDumper or Ghidra on these files.", "INFO")

    # ── APKTOOL (streaming) ───────────────────────────────────────
    def _do_apktool(self, apk: Path, out: Path):
        tool, jar = _find_apktool()
        if not tool and not jar:
            self._log_t("apktool not found — auto-installing…", "WARN")
            tool, jar = _install_apktool(self._log_t)
        if shutil.which("java") is None:
            self._log_t("Java not on PATH — install JRE/JDK 8+.", "ERROR")
            return

        use_shell = False
        if sys.platform == "win32":
            if tool and tool.lower().endswith(".bat"):
                cmd: str | list = f'"{tool}" d "{apk}" -o "{out}" --force'
                use_shell = True
            elif jar:
                cmd = ["java", "-jar", str(jar), "d", str(apk), "-o", str(out), "--force"]
            elif tool:
                cmd = [tool, "d", str(apk), "-o", str(out), "--force"]
            else:
                self._log_t("Cannot build apktool command.", "ERROR"); return
        else:
            if tool:
                cmd = [tool, "d", str(apk), "-o", str(out), "--force"]
            elif jar:
                cmd = ["java", "-jar", str(jar), "d", str(apk), "-o", str(out), "--force"]
            else:
                self._log_t("Cannot build apktool command.", "ERROR"); return

        self._log_t(f"Running apktool on: {apk.name}  (timeout {APKTOOL_TIMEOUT}s)", "INFO")

        # Stream stdout+stderr line-by-line so the user sees progress live
        q: queue.Queue[str | None] = queue.Queue()

        def _reader(pipe):
            try:
                for line in pipe:
                    q.put(line.rstrip())
            finally:
                q.put(None)

        proc = subprocess.Popen(
            cmd, shell=use_shell,
            stdout=subprocess.PIPE, stderr=subprocess.STDOUT,
            text=True, encoding="utf-8", errors="replace",
            bufsize=1,
        )
        t = threading.Thread(target=_reader, args=(proc.stdout,), daemon=True)
        t.start()

        deadline = time.monotonic() + APKTOOL_TIMEOUT
        finished_readers = 0
        while finished_readers < 1:
            try:
                line = q.get(timeout=1)
                if line is None:
                    finished_readers += 1
                else:
                    self._log_t(line, "INFO")
            except queue.Empty:
                pass
            if time.monotonic() > deadline:
                self._log_t(f"apktool exceeded {APKTOOL_TIMEOUT}s — killing process.", "ERROR")
                proc.kill()
                break

        proc.wait()
        if proc.returncode == 0:
            self._log_t(f"Smali → {out}", "OK")
        elif proc.returncode is not None:
            self._log_t(f"apktool exited with code {proc.returncode}", "ERROR")

    # ── REPORT ────────────────────────────────────────────────────
    def _do_report(self, out: Path):
        sections: dict[str, list[Path]] = {}
        for item in sorted(out.iterdir()):
            if item.is_dir() and item.name != "raw":
                sections[item.name] = [f for f in sorted(item.rglob("*")) if f.is_file()]
        top_files = sorted(f for f in out.iterdir() if f.is_file())
        sec_html = ""
        for sec, files in sections.items():
            by_type: dict[str, list[str]] = {}
            for f in files:
                rel = f.relative_to(out / sec)
                top = rel.parts[0] if len(rel.parts) > 1 else "—"
                by_type.setdefault(top, []).append(f.name)
            rows = ""
            for typ, names in sorted(by_type.items()):
                rows += (f"<tr><td style='color:{NEON_YEL}'>📂 {typ}</td>"
                         f"<td style='color:{TEXT_DIM}'>{len(names)} file(s)</td>"
                         f"<td style='color:{TEXT_DIM}'>{', '.join(names[:6])}{'...' if len(names) > 6 else ''}</td></tr>")
            sec_html += (f"<h2 style='color:{NEON_GREEN}'>📁 {sec}/ "
                         f"<span style='font-size:13px;color:{TEXT_DIM}'>{len(files)} total</span></h2>"
                         f"<table><tr><th>Type</th><th>Count</th><th>Samples</th></tr>{rows}</table>" if rows
                         else f"<h2 style='color:{NEON_YEL}'>📁 {sec}/ (empty)</h2>")
        top_rows = "".join(f"<tr><td>📄</td><td>{f.name}</td></tr>" for f in top_files)
        html = (
            "<!DOCTYPE html><html lang='en'><head><meta charset='utf-8'>"
            "<title>IL2CPP Recovery Studio — Report</title>"
            f"<style>body{{background:{BG_DEEP};color:{TEXT_BRIGHT};font-family:'Segoe UI',sans-serif;padding:30px;font-size:15px}}"
            f"h1{{color:{NEON_CYAN};border-bottom:2px solid {NEON_PURP};padding-bottom:8px}}"
            f"table{{border-collapse:collapse;width:100%;margin-bottom:20px}}"
            f"td,th{{padding:6px 14px;border-bottom:1px solid #1a1a40;text-align:left}}"
            f"th{{color:{NEON_PURP}}}</style></head><body>"
            f"<h1>● IL2CPP Recovery Studio — Report</h1>"
            f"<p>Output: <code style='color:{NEON_YEL}'>{out}</code></p>"
            f"{sec_html}"
            f"<h2 style='color:{NEON_CYAN}'>Top-level files</h2>"
            f"<table><tr><th></th><th>Name</th></tr>{top_rows}</table>"
            f"<hr><p style='color:#5c5c8a'>Generated by IL2CPP Recovery Studio v10</p>"
            "</body></html>"
        )
        rp = out / "report.html"
        rp.write_text(html, encoding="utf-8")
        self._log_t(f"Report → {rp}", "OK")

    # ── RESULTS ───────────────────────────────────────────────────
    def _show_results(self, out: Path):
        lines = ["=" * 48, "   OUTPUT SUMMARY", "=" * 48]
        for d in sorted(out.iterdir()):
            if d.is_dir():
                lines.append(f"  📁  {d.name}/  ({_count_files(d)} files)")
        for label, sub in [("🎬 Scenes", "unity_assets/Scenes"),
                            ("🖼 UI",     "unity_assets/UI")]:
            p = out / sub.replace("/", os.sep)
            if p.exists():
                lines.append(f"  {label}: {_count_files(p)} JSON file(s)")
        lines += ["", "  OPEN THESE FIRST:",
                  "  1.  unity_assets/Scenes/*.json",
                  "  2.  unity_assets/UI/*.json",
                  "  3.  report.html in browser",
                  "  4.  il2cpp_meta/ with Il2CppDumper"]
        self._set_results("\n".join(lines))

    def _set_results(self, text):
        self._results_txt.configure(state="normal")
        self._results_txt.delete("0.0", "end")
        if text: self._results_txt.insert("0.0", text)
        self._results_txt.configure(state="disabled")

    def _step(self, msg):
        self._log_t(msg, "STEP")
        self.after(0, lambda m=msg: self._prog_lbl.configure(text=m, text_color=NEON_PURP))
        self._status(f"►  {msg}")

    def _log_t(self, msg, level="INFO"):
        self.after(0, lambda m=msg, lv=level: self._log.log(m, lv))

    def _status(self, msg):
        self.after(0, lambda m=msg: self._status_lbl.configure(text=m))

    def _open_output(self):
        if self._output_dir and self._output_dir.exists():
            if sys.platform == "win32": os.startfile(self._output_dir)
            elif sys.platform == "darwin": subprocess.Popen(["open", str(self._output_dir)])
            else: subprocess.Popen(["xdg-open", str(self._output_dir)])
        else:
            messagebox.showinfo("No output yet", "Run the analysis first.", parent=self)


def run_gui():
    IL2CPPStudio().mainloop()


if __name__ == "__main__":
    run_gui()
