#!/usr/bin/env python3
"""
IL2CPP Recovery Studio — Futuristic Neon GUI  (app.py)

Safe for both source and PyInstaller EXE builds.
"""
from __future__ import annotations

import os
import sys
import threading
import zipfile
import shutil
import time
import subprocess
from pathlib import Path

import customtkinter as ctk

# PIL is optional
try:
    from PIL import Image, ImageTk  # noqa: F401
except ImportError:
    Image = None  # type: ignore

BG_DEEP = "#0a0a0f"
BG_CARD = "#0f0f1a"
BG_PANEL = "#12122a"
NEON_CYAN = "#00ffe7"
NEON_PURP = "#a259ff"
NEON_GREEN = "#39ff14"
NEON_PINK = "#ff2d78"
TEXT_MAIN = "#e0e0ff"
TEXT_DIM = "#5c5c8a"
BTN_HOVER = "#1a1a40"


class NeonButton(ctk.CTkButton):
    def __init__(self, master, text, command=None, color=NEON_CYAN, **kw):
        super().__init__(
            master,
            text=text,
            command=command,
            fg_color=BG_CARD,
            border_width=2,
            border_color=color,
            text_color=color,
            hover_color=BTN_HOVER,
            corner_radius=8,
            font=("Courier New", 13, "bold"),
            **kw,
        )
        self._neon_color = color
        self._pulsing = False
        self.bind("<Enter>", self._on_enter)
        self.bind("<Leave>", self._on_leave)

    def _on_enter(self, _):
        self.configure(border_color=NEON_PINK, text_color=NEON_PINK)

    def _on_leave(self, _):
        self.configure(border_color=self._neon_color, text_color=self._neon_color)

    def start_pulse(self):
        self._pulsing = True
        self._pulse()

    def stop_pulse(self):
        self._pulsing = False
        self.configure(border_color=self._neon_color, text_color=self._neon_color)

    def _pulse(self):
        if not self._pulsing:
            return
        colors = [self._neon_color, NEON_PINK]
        cur = self.cget("border_color")
        nxt = colors[1] if cur == colors[0] else colors[0]
        self.configure(border_color=nxt, text_color=nxt)
        self.after(500, self._pulse)


class SectionCard(ctk.CTkFrame):
    def __init__(self, master, title: str, accent=NEON_CYAN, **kw):
        super().__init__(master, fg_color=BG_CARD, border_width=1, border_color=accent, corner_radius=10, **kw)
        ctk.CTkLabel(self, text=f"  {title}  ", font=("Courier New", 11, "bold"), text_color=accent, fg_color=BG_CARD).pack(anchor="nw", padx=12, pady=(8, 2))
        ctk.CTkFrame(self, height=1, fg_color=accent).pack(fill="x", padx=12)


class LogConsole(ctk.CTkTextbox):
    LEVEL_COLORS = {
        "INFO": NEON_CYAN,
        "OK": NEON_GREEN,
        "WARN": "#ffaa00",
        "ERROR": NEON_PINK,
        "SKIP": TEXT_DIM,
        "STEP": NEON_PURP,
    }

    def __init__(self, master, **kw):
        super().__init__(master, fg_color="#050508", text_color=TEXT_MAIN, font=("Courier New", 11), wrap="word", state="disabled", **kw)
        for tag, color in self.LEVEL_COLORS.items():
            self._textbox.tag_config(tag, foreground=color)

    def log(self, message: str, level: str = "INFO"):
        tag = level if level in self.LEVEL_COLORS else "INFO"
        self.configure(state="normal")
        self._textbox.insert("end", f"[{level:5s}] {message}\n", tag)
        self._textbox.see("end")
        self.configure(state="disabled")

    def clear(self):
        self.configure(state="normal")
        self.delete("0.0", "end")
        self.configure(state="disabled")


class OperationCheckbox(ctk.CTkCheckBox):
    def __init__(self, master, label: str, description: str, var, **kw):
        super().__init__(master, text=label, variable=var, font=("Courier New", 12, "bold"), text_color=NEON_CYAN, checkmark_color=BG_DEEP, fg_color=NEON_CYAN, hover_color=NEON_PURP, **kw)
        ctk.CTkLabel(master, text=f"   {description}", font=("Courier New", 10), text_color=TEXT_DIM, anchor="w").pack(anchor="w", padx=32, pady=(0, 6))


class IL2CPPStudio(ctk.CTk):
    APP_TITLE = "IL2CPP Recovery Studio  //  NEON v2"
    WIN_SIZE = "1100x750"

    def __init__(self):
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("dark-blue")
        super().__init__()
        self.title(self.APP_TITLE)
        self.geometry(self.WIN_SIZE)
        self.minsize(900, 650)
        self.configure(fg_color=BG_DEEP)

        self._apk_path = None
        self._output_dir = None
        self._running = False
        self._ops = {
            "extract_apk": ctk.BooleanVar(value=True),
            "extract_assets": ctk.BooleanVar(value=True),
            "extract_il2cpp": ctk.BooleanVar(value=True),
            "decompile_smali": ctk.BooleanVar(value=False),
            "gen_report": ctk.BooleanVar(value=True),
        }

        self._build_ui()
        self.after(100, self._animate_header)

    def _build_ui(self):
        header = ctk.CTkFrame(self, fg_color=BG_PANEL, height=60, corner_radius=0)
        header.pack(fill="x")
        self._header_lbl = ctk.CTkLabel(header, text=self.APP_TITLE, font=("Courier New", 16, "bold"), text_color=NEON_CYAN)
        self._header_lbl.pack(side="left", padx=20, pady=10)
        ctk.CTkLabel(header, text="⬡ SYSTEM ONLINE", font=("Courier New", 10), text_color=NEON_GREEN).pack(side="right", padx=20)

        body = ctk.CTkFrame(self, fg_color=BG_DEEP)
        body.pack(fill="both", expand=True, padx=10, pady=8)
        body.columnconfigure(0, weight=1)
        body.columnconfigure(1, weight=2)
        body.rowconfigure(0, weight=1)

        self._build_left(body)
        self._build_right(body)

        bar = ctk.CTkFrame(self, fg_color=BG_PANEL, height=30, corner_radius=0)
        bar.pack(fill="x", side="bottom")
        self._status_lbl = ctk.CTkLabel(bar, text="Ready.", font=("Courier New", 10), text_color=TEXT_DIM)
        self._status_lbl.pack(side="left", padx=14)

    def _build_left(self, parent):
        left = ctk.CTkFrame(parent, fg_color=BG_DEEP)
        left.grid(row=0, column=0, sticky="nsew", padx=(0, 6))

        drop_card = SectionCard(left, "[ INPUT FILE ]", accent=NEON_PURP)
        drop_card.pack(fill="x", pady=(0, 8))

        drop_zone = ctk.CTkFrame(drop_card, fg_color="#0d0d1f", border_width=2, border_color=NEON_PURP, corner_radius=8, height=80)
        drop_zone.pack(fill="x", padx=12, pady=8)
        drop_zone.pack_propagate(False)

        self._drop_lbl = ctk.CTkLabel(drop_zone, text="📂  Click to select .APK / .XAPK", font=("Courier New", 12), text_color=NEON_PURP)
        self._drop_lbl.pack(expand=True)
        drop_zone.bind("<Button-1>", lambda _: self._browse_apk())
        self._drop_lbl.bind("<Button-1>", lambda _: self._browse_apk())

        self._file_lbl = ctk.CTkLabel(drop_card, text="No file selected", font=("Courier New", 10), text_color=TEXT_DIM)
        self._file_lbl.pack(padx=12, pady=(0, 8))

        out_card = SectionCard(left, "[ OUTPUT DIRECTORY ]", accent=NEON_CYAN)
        out_card.pack(fill="x", pady=(0, 8))
        self._out_lbl = ctk.CTkLabel(out_card, text="Default: next to input file", font=("Courier New", 10), text_color=TEXT_DIM)
        self._out_lbl.pack(padx=12, pady=4)
        NeonButton(out_card, "  Browse Output…", command=self._browse_output, color=NEON_CYAN).pack(padx=12, pady=(0, 8), fill="x")

        ops_card = SectionCard(left, "[ OPERATIONS ]", accent=NEON_GREEN)
        ops_card.pack(fill="both", expand=True, pady=(0, 8))
        ops_def = [
            ("extract_apk", "Extract APK/XAPK contents", "Unzips the package into raw files"),
            ("extract_assets", "Extract Unity assets (UnityPy)", "Exports textures, audio, scenes"),
            ("extract_il2cpp", "Parse IL2CPP metadata", "Copies metadata and libil2cpp files"),
            ("decompile_smali", "Decompile to Smali (apktool)", "Requires apktool on PATH"),
            ("gen_report", "Generate HTML report", "Summary report in output folder"),
        ]
        for key, label, desc in ops_def:
            cb = OperationCheckbox(ops_card, label, desc, self._ops[key])
            cb.pack(anchor="w", padx=16, pady=(6, 0))

        self._run_btn = NeonButton(left, "  ▶  RUN ANALYSIS", command=self._start_analysis, color=NEON_GREEN, height=44)
        self._run_btn.pack(fill="x", pady=(0, 4))
        self._open_btn = NeonButton(left, "  📁  Open Output Folder", command=self._open_output, color=NEON_PURP, height=36)
        self._open_btn.pack(fill="x")

    def _build_right(self, parent):
        right = ctk.CTkFrame(parent, fg_color=BG_DEEP)
        right.grid(row=0, column=1, sticky="nsew")
        right.rowconfigure(1, weight=1)
        right.columnconfigure(0, weight=1)

        prog_card = SectionCard(right, "[ PROGRESS ]", accent=NEON_CYAN)
        prog_card.grid(row=0, column=0, sticky="ew", pady=(0, 6))
        self._progress = ctk.CTkProgressBar(prog_card, fg_color=BG_DEEP, progress_color=NEON_CYAN, border_width=1, border_color=NEON_PURP, height=18, corner_radius=6)
        self._progress.set(0)
        self._progress.pack(fill="x", padx=12, pady=8)
        self._prog_lbl = ctk.CTkLabel(prog_card, text="Idle", font=("Courier New", 10), text_color=TEXT_DIM)
        self._prog_lbl.pack(padx=12, pady=(0, 8))

        log_card = SectionCard(right, "[ LOG CONSOLE ]", accent=NEON_PURP)
        log_card.grid(row=1, column=0, sticky="nsew", pady=(0, 6))
        self._log = LogConsole(log_card)
        self._log.pack(fill="both", expand=True, padx=12, pady=8)

        res_card = SectionCard(right, "[ RESULTS & NEXT STEPS ]", accent=NEON_GREEN)
        res_card.grid(row=2, column=0, sticky="ew")
        self._results_txt = ctk.CTkTextbox(res_card, fg_color="#050508", text_color=NEON_GREEN, font=("Courier New", 11), height=90, state="disabled")
        self._results_txt.pack(fill="x", padx=12, pady=8)

    _HEADER_CHARS = list("▓▒░ ░▒▓")

    def _animate_header(self):
        if not self.winfo_exists():
            return
        idx = int(time.time() * 2) % len(self._HEADER_CHARS)
        ch = self._HEADER_CHARS[idx]
        self._header_lbl.configure(text=f"{ch} {self.APP_TITLE} {ch}")
        self.after(400, self._animate_header)

    def _animate_progress(self):
        if not self._running or not self.winfo_exists():
            return
        cur = self._progress.get()
        if cur < 0.95:
            self._progress.set(cur + 0.005)
        self.after(120, self._animate_progress)

    def _browse_apk(self):
        from tkinter import filedialog
        path = filedialog.askopenfilename(title="Select APK / XAPK file", filetypes=[("APK / XAPK files", "*.apk *.xapk"), ("All files", "*.*")])
        if path:
            self._apk_path = Path(path)
            self._drop_lbl.configure(text=f"✅  {self._apk_path.name}", text_color=NEON_GREEN)
            self._file_lbl.configure(text=str(self._apk_path), text_color=NEON_GREEN)
            self._status(f"File loaded: {self._apk_path.name}")
            if not self._output_dir:
                self._output_dir = self._apk_path.parent / (self._apk_path.stem + "_output")
                self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)

    def _browse_output(self):
        from tkinter import filedialog
        path = filedialog.askdirectory(title="Select output directory")
        if path:
            self._output_dir = Path(path)
            self._out_lbl.configure(text=str(self._output_dir), text_color=NEON_CYAN)

    def _start_analysis(self):
        if self._running:
            return
        if not self._apk_path or not self._apk_path.exists():
            self._log.log("No valid APK/XAPK file selected!", "ERROR")
            self._status("⚠  Select a file first.")
            return
        ops = {k: v.get() for k, v in self._ops.items()}
        if not any(ops.values()):
            self._log.log("Select at least one operation.", "WARN")
            return
        self._running = True
        self._run_btn.start_pulse()
        self._run_btn.configure(state="disabled")
        self._log.clear()
        self._set_results("")
        self._progress.set(0)
        self._animate_progress()
        threading.Thread(target=self._run_pipeline, args=(ops,), daemon=True).start()

    def _run_pipeline(self, ops):
        out = self._output_dir
        apk = self._apk_path
        try:
            out.mkdir(parents=True, exist_ok=True)
            self._log_main(f"Output → {out}", "INFO")
            if ops["extract_apk"]:
                raw_dir = out / "raw"
                self._step("Extracting package...")
                if raw_dir.exists() and any(raw_dir.iterdir()):
                    self._log_main("Raw extraction folder already exists — skipped.", "SKIP")
                else:
                    raw_dir.mkdir(exist_ok=True)
                    if apk.suffix.lower() == ".xapk":
                        self._log_main("XAPK detected — extracting inner APKs...", "INFO")
                        with zipfile.ZipFile(apk, "r") as z:
                            z.extractall(raw_dir)
                        base_apk = raw_dir / "base.apk"
                        if base_apk.exists():
                            apk_out = raw_dir / "base_extracted"
                            with zipfile.ZipFile(base_apk, "r") as z:
                                z.extractall(apk_out)
                            self._log_main(f"base.apk extracted to: {apk_out}", "OK")
                    else:
                        with zipfile.ZipFile(apk, "r") as z:
                            z.extractall(raw_dir)
                        self._log_main(f"APK extracted: {raw_dir}", "OK")
            if ops["extract_assets"]:
                assets_dir = out / "unity_assets"
                self._step("Extracting Unity assets (UnityPy)...")
                if assets_dir.exists() and any(assets_dir.iterdir()):
                    self._log_main("Unity assets folder already exists — skipped.", "SKIP")
                else:
                    assets_dir.mkdir(exist_ok=True)
                    try:
                        self._extract_unity_assets(out / "raw", assets_dir)
                    except Exception as e:
                        self._log_main(f"Asset extraction warning: {e}", "WARN")
            if ops["extract_il2cpp"]:
                meta_dir = out / "il2cpp_meta"
                self._step("Parsing IL2CPP metadata...")
                if meta_dir.exists() and any(meta_dir.iterdir()):
                    self._log_main("IL2CPP metadata folder already exists — skipped.", "SKIP")
                else:
                    meta_dir.mkdir(exist_ok=True)
                    try:
                        self._parse_il2cpp(out / "raw", meta_dir)
                    except Exception as e:
                        self._log_main(f"IL2CPP parse warning: {e}", "WARN")
            if ops["decompile_smali"]:
                smali_dir = out / "smali"
                self._step("Decompiling to Smali...")
                if smali_dir.exists() and any(smali_dir.iterdir()):
                    self._log_main("Smali folder already exists — skipped.", "SKIP")
                else:
                    self._run_apktool(apk, smali_dir)
            if ops["gen_report"]:
                self._step("Generating HTML report...")
                self._generate_report(out)
            self.after(0, lambda: self._progress.set(1.0))
            self._status("✅  Analysis complete!")
            self._log_main("All done!", "OK")
            self._show_results(out)
        except Exception as exc:
            import traceback
            self._log_main(f"Fatal error: {exc}", "ERROR")
            self._log_main(traceback.format_exc(), "ERROR")
            self._status("❌  Error — see log.")
        finally:
            self._running = False
            self.after(0, self._run_btn.stop_pulse)
            self.after(0, lambda: self._run_btn.configure(state="normal"))

    def _extract_unity_assets(self, raw_dir: Path, out: Path):
        import UnityPy
        sources = list(raw_dir.rglob("*.assets")) + list(raw_dir.rglob("level*"))
        if not sources:
            self._log_main("No Unity asset files found in raw dir.", "WARN")
            return
        for src in sources:
            self._log_main(f"  Loading: {src.name}", "INFO")
            env = UnityPy.load(str(src))
            for obj in env.objects:
                try:
                    data = obj.read()
                    if hasattr(data, "name") and data.name:
                        dest = out / obj.type.name
                        dest.mkdir(exist_ok=True)
                        if hasattr(data, "image"):
                            img_path = dest / f"{data.name}.png"
                            if not img_path.exists():
                                data.image.save(str(img_path))
                        elif hasattr(data, "m_Script"):
                            txt_path = dest / f"{data.name}.txt"
                            if not txt_path.exists():
                                txt_path.write_text(data.m_Script, encoding="utf-8", errors="replace")
                except Exception:
                    pass
        self._log_main(f"Unity assets written to: {out}", "OK")

    def _parse_il2cpp(self, raw_dir: Path, out: Path):
        meta_files = list(raw_dir.rglob("global-metadata.dat"))
        so_files = list(raw_dir.rglob("libil2cpp.so"))
        if not meta_files:
            self._log_main("global-metadata.dat not found — IL2CPP parse skipped.", "WARN")
            return
        for f in meta_files + so_files:
            dest = out / f.name
            if not dest.exists():
                shutil.copy2(f, dest)
                self._log_main(f"  Copied: {f.name}", "OK")
            else:
                self._log_main(f"  Already copied: {f.name}", "SKIP")
        self._log_main("Use Il2CppDumper or Ghidra to analyse these files.", "INFO")

    def _run_apktool(self, apk: Path, out: Path):
        apktool = shutil.which("apktool") or shutil.which("apktool.bat")
        if not apktool:
            self._log_main("apktool not found on PATH — Smali decompile skipped.", "WARN")
            self._log_main("  Install apktool: https://apktool.org", "INFO")
            return
        result = subprocess.run([apktool, "d", str(apk), "-o", str(out), "--force"], capture_output=True, text=True)
        if result.returncode == 0:
            self._log_main(f"Smali decompiled to: {out}", "OK")
        else:
            self._log_main(f"apktool error: {result.stderr[:300]}", "ERROR")

    def _generate_report(self, out: Path):
        report_path = out / "report.html"
        dirs = sorted(d.name for d in out.iterdir() if d.is_dir())
        files = sorted(f.name for f in out.iterdir() if f.is_file())
        dir_rows = "".join(f"<tr><td>📁</td><td>{d}</td></tr>" for d in dirs)
        file_rows = "".join(f"<tr><td>📄</td><td>{f}</td></tr>" for f in files)
        html = f"""<!DOCTYPE html><html lang='en'><head><meta charset='utf-8'><title>IL2CPP Recovery Studio — Report</title><style>body{{background:#0a0a0f;color:#e0e0ff;font-family:'Courier New',monospace;padding:30px}}h1{{color:#00ffe7;border-bottom:1px solid #a259ff;padding-bottom:8px}}table{{border-collapse:collapse;width:100%}}td{{padding:4px 12px;border-bottom:1px solid #1a1a40}}th{{color:#a259ff;text-align:left;padding:6px 12px}}</style></head><body><h1>⬡ IL2CPP Recovery Studio Report</h1><p>Output directory: <code>{out}</code></p><h2 style='color:#39ff14'>Folders</h2><table><tr><th></th><th>Name</th></tr>{dir_rows}</table><h2 style='color:#39ff14'>Files</h2><table><tr><th></th><th>Name</th></tr>{file_rows}</table><hr><p style='color:#5c5c8a'>Generated by IL2CPP Recovery Studio v2</p></body></html>"""
        report_path.write_text(html, encoding="utf-8")
        self._log_main(f"HTML report saved: {report_path}", "OK")

    def _show_results(self, out: Path):
        dirs = [d.name for d in out.iterdir() if d.is_dir()]
        lines = ["=" * 45, "  OUTPUT SUMMARY", "=" * 45]
        lines += [f"  📁  {d}" for d in sorted(dirs)]
        lines += ["", "  NEXT STEPS:", "  1. Open report.html in your browser", "  2. Inspect unity_assets/ for textures", "  3. Use Il2CppDumper on il2cpp_meta/", "  4. Click 'Open Output Folder' above"]
        self._set_results("\n".join(lines))

    def _set_results(self, text: str):
        self._results_txt.configure(state="normal")
        self._results_txt.delete("0.0", "end")
        if text:
            self._results_txt.insert("0.0", text)
        self._results_txt.configure(state="disabled")

    def _step(self, msg: str):
        self._log_main(msg, "STEP")
        self.after(0, lambda m=msg: self._prog_lbl.configure(text=m))
        self._status(msg)

    def _log_main(self, msg: str, level: str = "INFO"):
        self.after(0, lambda m=msg, l=level: self._log.log(m, l))

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
            self._status("No output folder yet.")


def run_gui():
    app = IL2CPPStudio()
    app.mainloop()


if __name__ == "__main__":
    run_gui()
