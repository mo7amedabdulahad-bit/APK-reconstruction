#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — Futuristic Neon GUI (app.py v7)

Changes:
 - Unity asset search now scans the ENTIRE output tree (not just raw/),
   so assets inside base_extracted/ and split APKs are found.
 - IL2CPP search likewise scans the full output tree.
 - apktool auto-download: if apktool is not on PATH, the app downloads
   the latest apktool.jar + a wrapper batch file into its own tools/
   folder and uses that automatically.
"""
from __future__ import annotations

import os
import sys
import threading
import zipfile
import shutil
import urllib.request
import subprocess
from pathlib import Path

import customtkinter as ctk
from tkinter import filedialog, messagebox

try:
    from PIL import Image  # noqa: F401
except ImportError:
    Image = None  # type: ignore

# ══════════════════════ COLOUR PALETTE ══════════════════════════════
BG_DEEP     = "#0a0a0f"
BG_CARD     = "#111128"
BG_PANEL    = "#0d0d22"
NEON_CYAN   = "#00ffe7"
NEON_PURP   = "#bf80ff"
NEON_GREEN  = "#00ff88"
NEON_PINK   = "#ff4488"
NEON_YEL    = "#ffe040"
TEXT_WHITE  = "#ffffff"
TEXT_BRIGHT = "#e8f0ff"
TEXT_DIM    = "#8888bb"
BTN_HOVER   = "#1e1e44"

FNT_TITLE = ("Segoe UI", 18, "bold")
FNT_HEAD  = ("Segoe UI", 14, "bold")
FNT_BODY  = ("Segoe UI", 13, "bold")
FNT_SMALL = ("Segoe UI", 11)
FNT_MONO  = ("Courier New", 12)
FNT_MONO_B = ("Courier New", 12, "bold")
FNT_RUN   = ("Segoe UI", 16, "bold")

# apktool auto-install settings
APKTOOL_VER = "2.9.3"
APKTOOL_URL = (
    f"https://github.com/iBotPeaches/Apktool/releases/download/"
    f"v{APKTOOL_VER}/apktool_{APKTOOL_VER}.jar"
)
# Tools folder sits next to this file
TOOLS_DIR = Path(__file__).parent / "tools"


# ══════════════════════ HELPERS ═══════════════════════════════════════
def _find_apktool() -> str | None:
    """Return a runnable apktool command string, or None."""
    # 1. on PATH
    for name in ("apktool", "apktool.bat"):
        if shutil.which(name):
            return name
    # 2. in our own tools/ folder
    local_bat = TOOLS_DIR / "apktool.bat"
    local_jar = TOOLS_DIR / "apktool.jar"
    if local_bat.exists() and local_jar.exists():
        return str(local_bat)
    return None


def _install_apktool(log_fn) -> str | None:
    """
    Download apktool.jar + wrapper bat into TOOLS_DIR.
    log_fn(msg, level) is called for progress.
    Returns the bat path string on success, None on failure.
    """
    try:
        TOOLS_DIR.mkdir(parents=True, exist_ok=True)
        jar = TOOLS_DIR / "apktool.jar"
        bat = TOOLS_DIR / "apktool.bat"

        if not jar.exists():
            log_fn(f"Downloading apktool {APKTOOL_VER} …", "INFO")
            urllib.request.urlretrieve(APKTOOL_URL, jar)
            log_fn(f"apktool.jar saved → {jar}", "OK")
        else:
            log_fn("apktool.jar already cached.", "SKIP")

        if not bat.exists():
            bat.write_text(
                f"@echo off\njava -jar \"{jar}\" %*\n",
                encoding="ascii",
            )
            log_fn(f"apktool.bat written → {bat}", "OK")

        # quick sanity
        r = subprocess.run(
            ["java", "-version"], capture_output=True, text=True
        )
        if r.returncode != 0:
            log_fn("Java not found — install JRE 8+ to use Smali.", "WARN")
            return None
        return str(bat)
    except Exception as e:
        log_fn(f"apktool install failed: {e}", "ERROR")
        return None


def make_btn(
    parent,
    text: str,
    command,
    color: str = NEON_CYAN,
    height: int = 42,
    font=FNT_BODY,
) -> ctk.CTkButton:
    return ctk.CTkButton(
        parent,
        text=text,
        command=command,
        fg_color=BG_CARD,
        hover_color=BTN_HOVER,
        border_width=2,
        border_color=color,
        text_color=color,
        corner_radius=8,
        font=font,
        height=height,
    )


class SectionCard(ctk.CTkFrame):
    def __init__(self, master, title: str, accent: str = NEON_CYAN, **kw):
        super().__init__(master, fg_color=BG_CARD, border_width=1,
                         border_color=accent, corner_radius=10, **kw)
        ctk.CTkLabel(
            self, text=f"  {title}",
            font=FNT_HEAD, text_color=accent, fg_color=BG_CARD,
        ).pack(anchor="nw", padx=14, pady=(10, 3))
        ctk.CTkFrame(self, height=1, fg_color=accent).pack(fill="x", padx=14)


class LogConsole(ctk.CTkTextbox):
    COLORS = {
        "INFO":  NEON_CYAN,
        "OK":    NEON_GREEN,
        "WARN":  NEON_YEL,
        "ERROR": NEON_PINK,
        "SKIP":  TEXT_DIM,
        "STEP":  NEON_PURP,
    }

    def __init__(self, master, **kw):
        super().__init__(
            master,
            fg_color="#06060e",
            text_color=TEXT_BRIGHT,
            font=FNT_MONO,
            wrap="word",
            state="disabled",
            **kw,
        )
        for tag, color in self.COLORS.items():
            self._textbox.tag_config(tag, foreground=color)

    def log(self, message: str, level: str = "INFO"):
        tag = level if level in self.COLORS else "INFO"
        self.configure(state="normal")
        self._textbox.insert("end", f"[{level:<5}] ", tag)
        self._textbox.insert("end", message + "\n")
        self._textbox.see("end")
        self.configure(state="disabled")

    def clear(self):
        self.configure(state="normal")
        self.delete("0.0", "end")
        self.configure(state="disabled")


# ══════════════════════ MAIN WINDOW ═════════════════════════════════
class IL2CPPStudio(ctk.CTk):
    APP_TITLE = "IL2CPP Recovery Studio  •  NEON v2"
    WIN_SIZE  = "1200x780"

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
        self._ops = {
            "extract_apk":     ctk.BooleanVar(value=True),
            "extract_assets":  ctk.BooleanVar(value=True),
            "extract_il2cpp":  ctk.BooleanVar(value=True),
            "decompile_smali": ctk.BooleanVar(value=False),
            "gen_report":      ctk.BooleanVar(value=True),
        }

        self._build_ui()
        self.after(200, self._animate_header)

    # ──────────────────────── UI BUILD ─────────────────────────────
    def _build_ui(self):
        hdr = ctk.CTkFrame(self, fg_color=BG_PANEL, height=66, corner_radius=0)
        hdr.pack(fill="x")
        hdr.pack_propagate(False)
        self._hdr_lbl = ctk.CTkLabel(
            hdr, text=self.APP_TITLE, font=FNT_TITLE, text_color=NEON_CYAN)
        self._hdr_lbl.pack(side="left", padx=22)
        ctk.CTkLabel(hdr, text="● SYSTEM ONLINE",
                     font=FNT_BODY, text_color=NEON_GREEN).pack(side="right", padx=22)

        body = ctk.CTkFrame(self, fg_color=BG_DEEP)
        body.pack(fill="both", expand=True, padx=12, pady=8)
        body.columnconfigure(0, weight=5)
        body.columnconfigure(1, weight=7)
        body.rowconfigure(0, weight=1)
        self._build_left(body)
        self._build_right(body)

        bar = ctk.CTkFrame(self, fg_color=BG_PANEL, height=32, corner_radius=0)
        bar.pack(fill="x", side="bottom")
        bar.pack_propagate(False)
        self._status_lbl = ctk.CTkLabel(
            bar, text="►  Ready — select a file to begin.",
            font=FNT_SMALL, text_color=NEON_CYAN)
        self._status_lbl.pack(side="left", padx=16)

    # ──────────────────────── LEFT PANEL ───────────────────────────
    def _build_left(self, parent):
        left = ctk.CTkScrollableFrame(
            parent, fg_color=BG_DEEP,
            scrollbar_button_color=BG_CARD,
            scrollbar_button_hover_color=NEON_PURP,
        )
        left.grid(row=0, column=0, sticky="nsew", padx=(0, 8))

        fc = SectionCard(left, "📂  INPUT FILE", accent=NEON_PURP)
        fc.pack(fill="x", pady=(0, 10))
        self._file_lbl = ctk.CTkLabel(
            fc, text="No file selected",
            font=FNT_BODY, text_color=TEXT_DIM, wraplength=340, anchor="w")
        self._file_lbl.pack(fill="x", padx=14, pady=(8, 4))
        make_btn(fc, "  Browse APK / XAPK…",
                 self._browse_apk, NEON_PURP, 46).pack(fill="x", padx=14, pady=(4, 12))

        oc = SectionCard(left, "📁  OUTPUT DIRECTORY", accent=NEON_CYAN)
        oc.pack(fill="x", pady=(0, 10))
        self._out_lbl = ctk.CTkLabel(
            oc, text="Auto: next to input file",
            font=FNT_BODY, text_color=TEXT_DIM, wraplength=340, anchor="w")
        self._out_lbl.pack(fill="x", padx=14, pady=(8, 4))
        make_btn(oc, "  Browse Output Folder…",
                 self._browse_output, NEON_CYAN, 42).pack(fill="x", padx=14, pady=(4, 12))

        ops_card = SectionCard(left, "⚙  OPERATIONS", accent=NEON_GREEN)
        ops_card.pack(fill="x", pady=(0, 10))
        for key, label, desc in [
            ("extract_apk",    "📦  Extract APK/XAPK contents",  "Unzip the package into raw folders"),
            ("extract_assets",  "🎨  Extract Unity assets",        "Export textures, audio, scenes via UnityPy"),
            ("extract_il2cpp",  "🔍  Parse IL2CPP metadata",        "Copy global-metadata.dat & libil2cpp.so"),
            ("decompile_smali", "🖥  Decompile to Smali",           "Auto-installs apktool if needed"),
            ("gen_report",      "📝  Generate HTML report",          "Create a summary report.html in output"),
        ]:
            row = ctk.CTkFrame(ops_card, fg_color="transparent")
            row.pack(fill="x", padx=14, pady=4)
            ctk.CTkCheckBox(
                row, text=label, variable=self._ops[key],
                font=FNT_BODY, text_color=TEXT_WHITE,
                checkmark_color=BG_DEEP, fg_color=NEON_GREEN,
                hover_color=NEON_PURP, border_color=NEON_GREEN, border_width=2,
            ).pack(anchor="w")
            ctk.CTkLabel(row, text=f"    {desc}",
                         font=FNT_SMALL, text_color=TEXT_DIM, anchor="w"
                         ).pack(anchor="w", padx=26)
        ctk.CTkFrame(ops_card, height=6, fg_color="transparent").pack()

        self._run_btn = make_btn(
            left, "  ▶   RUN ANALYSIS",
            self._start_analysis, NEON_GREEN, 52, FNT_RUN)
        self._run_btn.pack(fill="x", pady=(4, 6))
        make_btn(left, "  📁   Open Output Folder",
                 self._open_output, NEON_PURP, 42).pack(fill="x")

    # ──────────────────────── RIGHT PANEL ──────────────────────────
    def _build_right(self, parent):
        right = ctk.CTkFrame(parent, fg_color=BG_DEEP)
        right.grid(row=0, column=1, sticky="nsew")
        right.rowconfigure(1, weight=1)
        right.columnconfigure(0, weight=1)

        pg = SectionCard(right, "⚡  PROGRESS", accent=NEON_CYAN)
        pg.grid(row=0, column=0, sticky="ew", pady=(0, 8))
        self._progress = ctk.CTkProgressBar(
            pg, fg_color=BG_DEEP, progress_color=NEON_CYAN,
            border_width=1, border_color=NEON_PURP, height=20, corner_radius=6)
        self._progress.set(0)
        self._progress.pack(fill="x", padx=14, pady=(10, 4))
        self._prog_lbl = ctk.CTkLabel(
            pg, text="Idle — waiting for input…",
            font=FNT_BODY, text_color=TEXT_BRIGHT)
        self._prog_lbl.pack(padx=14, pady=(0, 10))

        lg = SectionCard(right, "🖥  LOG CONSOLE", accent=NEON_PURP)
        lg.grid(row=1, column=0, sticky="nsew", pady=(0, 8))
        self._log = LogConsole(lg)
        self._log.pack(fill="both", expand=True, padx=14, pady=10)

        rs = SectionCard(right, "✅  RESULTS & NEXT STEPS", accent=NEON_GREEN)
        rs.grid(row=2, column=0, sticky="ew")
        self._results_txt = ctk.CTkTextbox(
            rs, fg_color="#06060e", text_color=NEON_GREEN,
            font=FNT_MONO_B, height=110, state="disabled")
        self._results_txt.pack(fill="x", padx=14, pady=10)

    # ──────────────────────── ANIMATION ─────────────────────────────
    _GLYPHS = ["■", "□", "▒", "░", "□", "■"]
    _glyph_i = 0

    def _animate_header(self):
        if not self.winfo_exists():
            return
        g = self._GLYPHS[self._glyph_i % len(self._GLYPHS)]
        self._hdr_lbl.configure(text=f"{g}  {self.APP_TITLE}  {g}")
        self._glyph_i += 1
        self.after(500, self._animate_header)

    def _animate_progress(self):
        if not self._running or not self.winfo_exists():
            return
        v = self._progress.get()
        if v < 0.93:
            self._progress.set(v + 0.004)
        self.after(100, self._animate_progress)

    # ──────────────────────── FILE PICKERS ────────────────────────
    def _browse_apk(self):
        self.lift(); self.focus_force(); self.update()
        path = filedialog.askopenfilename(
            parent=self, title="Select APK or XAPK file",
            filetypes=[("APK / XAPK files", "*.apk *.xapk"), ("All files", "*.*")])
        self.lift(); self.focus_force()
        if path:
            self._apk_path = Path(path)
            self._file_lbl.configure(text=f"✅  {self._apk_path.name}", text_color=NEON_GREEN)
            self._status(f"►  File loaded: {self._apk_path.name}")
            if not self._output_dir:
                self._output_dir = self._apk_path.parent / (self._apk_path.stem + "_output")
                self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)
        else:
            self._status("⚠  No file selected.")

    def _browse_output(self):
        self.lift(); self.focus_force(); self.update()
        path = filedialog.askdirectory(parent=self, title="Select output directory")
        self.lift(); self.focus_force()
        if path:
            self._output_dir = Path(path)
            self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)
            self._status(f"►  Output set: {path}")

    # ──────────────────────── ANALYSIS ────────────────────────────
    def _start_analysis(self):
        if self._running:
            self._status("⚠  Already running — please wait."); return
        if not self._apk_path:
            messagebox.showerror("No File Selected",
                "Please click 'Browse APK / XAPK' and select a file first.", parent=self)
            self._status("❌  Select a file first!"); return
        if not self._apk_path.exists():
            messagebox.showerror("File Not Found",
                f"Cannot find:\n{self._apk_path}\n\nPlease re-select the file.", parent=self)
            return
        ops = {k: v.get() for k, v in self._ops.items()}
        if not any(ops.values()):
            messagebox.showwarning("No Operations Selected",
                "Please tick at least one operation before running.", parent=self)
            return

        self._running = True
        self._run_btn.configure(state="disabled", text="  ⏳   RUNNING…")
        self._log.clear()
        self._set_results("")
        self._progress.set(0)
        self._prog_lbl.configure(text="Starting…", text_color=NEON_CYAN)
        self._status("►  Running analysis — please wait…")
        self._animate_progress()
        threading.Thread(target=self._run_pipeline, args=(ops,), daemon=True).start()

    def _run_pipeline(self, ops: dict):
        out = self._output_dir
        apk = self._apk_path
        try:
            out.mkdir(parents=True, exist_ok=True)
            self._log_t(f"Output folder → {out}", "INFO")

            # ─────────────── 1. Extract APK / XAPK
            raw = out / "raw"
            if ops["extract_apk"]:
                self._step("Extracting package…")
                if raw.exists() and any(raw.iterdir()):
                    self._log_t("raw/ exists — skipping extraction.", "SKIP")
                else:
                    raw.mkdir(exist_ok=True)
                    if apk.suffix.lower() == ".xapk":
                        self._log_t("XAPK detected — extracting outer archive…", "INFO")
                        with zipfile.ZipFile(apk) as z:
                            z.extractall(raw)
                        # Extract every inner APK found
                        for inner in raw.rglob("*.apk"):
                            inner_out = inner.parent / inner.stem
                            inner_out.mkdir(exist_ok=True)
                            with zipfile.ZipFile(inner) as z:
                                z.extractall(inner_out)
                            self._log_t(f"  Extracted inner APK: {inner.name} → {inner_out.name}/", "OK")
                    else:
                        with zipfile.ZipFile(apk) as z:
                            z.extractall(raw)
                        self._log_t(f"APK extracted → {raw}", "OK")
            else:
                # Even if skipped, raw must exist for later steps
                raw.mkdir(exist_ok=True)

            # ─────────────── 2. Unity assets — search entire output tree
            if ops["extract_assets"]:
                adir = out / "unity_assets"
                self._step("Extracting Unity assets (UnityPy)…")
                if adir.exists() and any(adir.iterdir()):
                    self._log_t("unity_assets/ exists — skipped.", "SKIP")
                else:
                    adir.mkdir(exist_ok=True)
                    try:
                        self._do_unity(out, adir)   # <─ scan whole out/, not just raw/
                    except Exception as e:
                        self._log_t(f"Unity warning: {e}", "WARN")

            # ─────────────── 3. IL2CPP — search entire output tree
            if ops["extract_il2cpp"]:
                mdir = out / "il2cpp_meta"
                self._step("Parsing IL2CPP metadata…")
                if mdir.exists() and any(mdir.iterdir()):
                    self._log_t("il2cpp_meta/ exists — skipped.", "SKIP")
                else:
                    mdir.mkdir(exist_ok=True)
                    try:
                        self._do_il2cpp(out, mdir)  # <─ scan whole out/
                    except Exception as e:
                        self._log_t(f"IL2CPP warning: {e}", "WARN")

            # ─────────────── 4. Smali
            if ops["decompile_smali"]:
                sdir = out / "smali"
                self._step("Decompiling to Smali…")
                if sdir.exists() and any(sdir.iterdir()):
                    self._log_t("smali/ exists — skipped.", "SKIP")
                else:
                    self._do_apktool(apk, sdir)

            # ─────────────── 5. Report
            if ops["gen_report"]:
                self._step("Generating HTML report…")
                self._do_report(out)

            self.after(0, lambda: self._progress.set(1.0))
            self.after(0, lambda: self._prog_lbl.configure(text="Done! ✅", text_color=NEON_GREEN))
            self._status("✅  Analysis complete!")
            self._log_t("All done!", "OK")
            self._show_results(out)

        except Exception as exc:
            import traceback
            self._log_t(f"FATAL: {exc}", "ERROR")
            self._log_t(traceback.format_exc(), "ERROR")
            self._status("❌  Error — check the log.")
        finally:
            self._running = False
            self.after(0, lambda: self._run_btn.configure(
                state="normal", text="  ▶   RUN ANALYSIS"))

    # ──────────────────────── WORKERS ──────────────────────────────
    def _do_unity(self, search_root: Path, out: Path):
        """
        Scan search_root recursively for Unity asset files.
        Skips the output sub-folders (unity_assets, il2cpp_meta, smali)
        to avoid re-scanning already-extracted data.
        """
        import UnityPy
        skip = {out, out.parent / "il2cpp_meta", out.parent / "smali"}

        def _rglob_skip(root: Path, pattern: str):
            for p in root.rglob(pattern):
                if not any(p.is_relative_to(s) for s in skip):
                    yield p

        sources = list(_rglob_skip(search_root, "*.assets"))
        # also include files named level0, level1 … (no extension)
        for p in search_root.rglob("level*"):
            if p.is_file() and not p.suffix and not any(p.is_relative_to(s) for s in skip):
                sources.append(p)

        if not sources:
            self._log_t("No Unity asset files found in extracted tree.", "WARN")
            return

        self._log_t(f"Found {len(sources)} Unity asset file(s) — processing…", "INFO")
        for src in sources:
            self._log_t(f"  → {src.relative_to(search_root)}", "INFO")
            env = UnityPy.load(str(src))
            for obj in env.objects:
                try:
                    data = obj.read()
                    if not (hasattr(data, "name") and data.name):
                        continue
                    dest = out / obj.type.name
                    dest.mkdir(exist_ok=True)
                    if hasattr(data, "image"):
                        p = dest / f"{data.name}.png"
                        if not p.exists():
                            data.image.save(str(p))
                    elif hasattr(data, "m_Script"):
                        p = dest / f"{data.name}.txt"
                        if not p.exists():
                            p.write_text(data.m_Script, encoding="utf-8", errors="replace")
                except Exception:
                    pass
        self._log_t(f"Unity assets → {out}", "OK")

    def _do_il2cpp(self, search_root: Path, out: Path):
        """
        Scan search_root recursively for global-metadata.dat and libil2cpp.so.
        Also checks standard Unity paths inside any extracted APK.
        """
        metas = list(search_root.rglob("global-metadata.dat"))
        sos   = list(search_root.rglob("libil2cpp.so"))

        # Also grab any architecture variants (.so with il2cpp in name)
        extra_sos = [
            p for p in search_root.rglob("*.so")
            if "il2cpp" in p.name.lower() and p not in sos
        ]
        sos.extend(extra_sos)

        if not metas:
            self._log_t("global-metadata.dat not found anywhere in extracted tree.", "WARN")
            self._log_t("  Expected path: assets/bin/Data/Managed/Metadata/", "INFO")
        if not sos:
            self._log_t("libil2cpp.so not found.", "WARN")

        copied = 0
        for f in metas + sos:
            # Preserve arch folder name to avoid name collisions (e.g. arm64-v8a vs armeabi-v7a)
            rel_name = f"{f.parent.name}_{f.name}" if f.name == "libil2cpp.so" else f.name
            d = out / rel_name
            if not d.exists():
                shutil.copy2(f, d)
                self._log_t(f"  Copied: {rel_name}", "OK")
                copied += 1
            else:
                self._log_t(f"  Already exists: {rel_name}", "SKIP")

        if copied:
            self._log_t(f"IL2CPP files → {out}", "OK")
            self._log_t("Tip: use Il2CppDumper or Ghidra on these files.", "INFO")

    def _do_apktool(self, apk: Path, out: Path):
        tool = _find_apktool()
        if not tool:
            self._log_t("apktool not found — attempting auto-install…", "WARN")
            tool = _install_apktool(self._log_t)
        if not tool:
            self._log_t("Could not install apktool. Install Java 8+ and retry.", "ERROR")
            return
        self._log_t(f"Using apktool: {tool}", "INFO")
        r = subprocess.run(
            [tool, "d", str(apk), "-o", str(out), "--force"],
            capture_output=True, text=True,
        )
        if r.returncode == 0:
            self._log_t(f"Smali → {out}", "OK")
        else:
            self._log_t(f"apktool error: {r.stderr[:600]}", "ERROR")

    def _do_report(self, out: Path):
        dirs  = sorted(d.name for d in out.iterdir() if d.is_dir())
        files = sorted(f.name for f in out.iterdir() if f.is_file())
        dr = "".join(f"<tr><td>📁</td><td>{d}</td></tr>" for d in dirs)
        fr = "".join(f"<tr><td>📄</td><td>{f}</td></tr>" for f in files)
        html = (
            "<!DOCTYPE html><html lang='en'><head><meta charset='utf-8'>"
            "<title>IL2CPP Recovery Studio — Report</title>"
            "<style>body{background:#0a0a0f;color:#e8f0ff;font-family:'Segoe UI',sans-serif;"
            "padding:30px;font-size:15px}h1{color:#00ffe7;border-bottom:2px solid #bf80ff;"
            "padding-bottom:8px}h2{color:#00ff88}table{border-collapse:collapse;width:100%}"
            "td{padding:6px 14px;border-bottom:1px solid #1a1a40}th{color:#bf80ff;"
            "text-align:left;padding:8px 14px}</style></head><body>"
            f"<h1>● IL2CPP Recovery Studio Report</h1>"
            f"<p>Output: <code style='color:#ffe040'>{out}</code></p>"
            f"<h2>Folders</h2><table><tr><th></th><th>Name</th></tr>{dr}</table>"
            f"<h2>Files</h2><table><tr><th></th><th>Name</th></tr>{fr}</table>"
            "<hr><p style='color:#5c5c8a'>Generated by IL2CPP Recovery Studio v2</p>"
            "</body></html>"
        )
        rp = out / "report.html"
        rp.write_text(html, encoding="utf-8")
        self._log_t(f"Report → {rp}", "OK")

    # ──────────────────────── RESULTS ───────────────────────────────
    def _show_results(self, out: Path):
        dirs = sorted(d.name for d in out.iterdir() if d.is_dir())
        lines = [
            "=" * 48, "   OUTPUT SUMMARY", "=" * 48,
        ] + [f"  📁  {d}" for d in dirs] + [
            "", "  NEXT STEPS:",
            "  1.  Open report.html in your browser",
            "  2.  Check unity_assets/ for textures",
            "  3.  Use Il2CppDumper on il2cpp_meta/",
            "  4.  Click 'Open Output Folder' on the left",
        ]
        self._set_results("\n".join(lines))

    def _set_results(self, text: str):
        self._results_txt.configure(state="normal")
        self._results_txt.delete("0.0", "end")
        if text:
            self._results_txt.insert("0.0", text)
        self._results_txt.configure(state="disabled")

    # ──────────────────────── HELPERS ────────────────────────────────
    def _step(self, msg: str):
        self._log_t(msg, "STEP")
        self.after(0, lambda m=msg: self._prog_lbl.configure(text=m, text_color=NEON_PURP))
        self._status(f"►  {msg}")

    def _log_t(self, msg: str, level: str = "INFO"):
        self.after(0, lambda m=msg, lv=level: self._log.log(m, lv))

    def _status(self, msg: str):
        self.after(0, lambda m=msg: self._status_lbl.configure(text=m))

    def _open_output(self):
        if self._output_dir and Path(self._output_dir).exists():
            if sys.platform == "win32":
                os.startfile(self._output_dir)
            elif sys.platform == "darwin":
                subprocess.Popen(["open", str(self._output_dir)])
            else:
                subprocess.Popen(["xdg-open", str(self._output_dir)])
        else:
            messagebox.showinfo("No Output Yet",
                                "No output folder yet. Run the analysis first.", parent=self)


# ════════════════════════════════════════════════════════════════════════
def run_gui():
    app = IL2CPPStudio()
    app.mainloop()


if __name__ == "__main__":
    run_gui()
