"""Tkinter GUI for IL2CPP Recovery Studio.

Provides APK/XAPK opening, Unity asset extraction, file browsing,
editing, APK rebuild & signing, Ghidra code analysis, and AI export
- all in a single window with tabbed interface.
"""
from __future__ import annotations

import json
import os
import platform
import subprocess
import sys
import threading
import tkinter as tk
from tkinter import filedialog, messagebox, scrolledtext, ttk
from pathlib import Path
from typing import Optional


# ---------------------------------------------------------------------------
# Color theme (Catppuccin Mocha)
# ---------------------------------------------------------------------------
_BG = "#1e1e2e"
_BG_DARK = "#181825"
_BG_LIGHT = "#313244"
_FG = "#cdd6f4"
_FG_DIM = "#a6adc8"
_ACCENT = "#89b4fa"
_GREEN = "#a6e3a1"
_YELLOW = "#f9e2af"
_RED = "#f38ba8"
_BTN_BG = "#313244"
_BTN_FG = "#cdd6f4"
_BTN_ACTIVE = "#45475a"

_CONFIG_PATH = Path(__file__).resolve().parent.parent.parent / ".gui_config.json"


# ---------------------------------------------------------------------------
# Config helpers
# ---------------------------------------------------------------------------

def _load_config() -> dict:
    if _CONFIG_PATH.exists():
        try:
            return json.loads(_CONFIG_PATH.read_text(encoding="utf-8"))
        except Exception:
            pass
    return {}


def _save_config(data: dict) -> None:
    try:
        _CONFIG_PATH.write_text(json.dumps(data, indent=2), encoding="utf-8")
    except Exception:
        pass


# ---------------------------------------------------------------------------
# Worker thread helper
# ---------------------------------------------------------------------------

class WorkerThread(threading.Thread):
    """Run a callable in a background thread, posting results to the GUI."""

    def __init__(self, target, *args, on_done=None, on_error=None, **kwargs):
        self._on_done = on_done
        self._on_error = on_error
        self._target = target
        self._args = args
        self._kwargs = kwargs
        super().__init__(daemon=True)

    def run(self):
        try:
            result = self._target(*self._args, **self._kwargs)
            if self._on_done:
                self.after(0, lambda: self._on_done(result))
        except Exception as exc:
            if self._on_error:
                self.after(0, lambda: self._on_error(exc))

    # Override after to work from non-main thread
    def after(self, ms, func=None, *args):
        # We don't have a tkinter after from a thread; the parent App handles it
        pass


def _run_in_thread(app: tk.Tk, target, *args, on_done=None, on_error=None, **kwargs):
    """Spawn a WorkerThread that posts results back to the tkinter mainloop."""
    def _done_wrapper(result):
        if on_done:
            on_done(result)

    def _error_wrapper(exc):
        if on_error:
            on_error(exc)

    class _SafeThread(threading.Thread):
        def __init__(self):
            super().__init__(daemon=True)
            self._result = None
            self._exc = None

        def run(self):
            try:
                self._result = target(*args, **kwargs)
                app.after(0, lambda: on_done(self._result) if on_done else None)
            except Exception as exc:
                app.after(0, lambda: on_error(exc) if on_error else None)

    t = _SafeThread()
    t.start()
    return t


# ---------------------------------------------------------------------------
# Main Application
# ---------------------------------------------------------------------------

class App(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("IL2CPP Recovery Studio")
        self.geometry("1200x800")
        self.minsize(900, 600)
        self.configure(bg=_BG)

        self._apk_path: Optional[Path] = None
        self._output_dir: Optional[Path] = None
        self._extract_done = False

        self._apply_theme()
        self._build_ui()

    # -- Theme ---------------------------------------------------------------

    def _apply_theme(self):
        style = ttk.Style(self)
        style.theme_use("clam")

        style.configure(".", background=_BG, foreground=_FG, fieldbackground=_BG_DARK)
        style.configure("TFrame", background=_BG)
        style.configure("TLabel", background=_BG, foreground=_FG)
        style.configure("TButton", background=_BTN_BG, foreground=_BTN_FG,
                         borderwidth=0, padding=(10, 4))
        style.map("TButton",
                   background=[("active", _BTN_ACTIVE), ("disabled", _BG_DARK)],
                   foreground=[("disabled", _FG_DIM)])
        style.configure("Accent.TButton", background=_ACCENT, foreground=_BG_DARK)
        style.map("Accent.TButton",
                   background=[("active", "#7ba8e8"), ("disabled", _BG_DARK)])
        style.configure("Green.TButton", background=_GREEN, foreground=_BG_DARK)
        style.map("Green.TButton", background=[("active", "#8cd494")])
        style.configure("Treeview", background=_BG_DARK, foreground=_FG,
                         fieldbackground=_BG_DARK, borderwidth=0)
        style.configure("Treeview.Heading", background=_BG_LIGHT, foreground=_FG_DIM)
        style.map("Treeview", background=[("selected", _BG_LIGHT)])
        style.configure("Horizontal.TProgressbar", background=_ACCENT,
                         troughcolor=_BG_DARK, borderwidth=0)
        style.configure("TNotebook", background=_BG, borderwidth=0)
        style.configure("TNotebook.Tab", background=_BG_DARK, foreground=_FG_DIM,
                         padding=(12, 6))
        style.map("TNotebook.Tab",
                   background=[("selected", _BG)],
                   foreground=[("selected", _ACCENT)])

    # -- UI construction -----------------------------------------------------

    def _build_ui(self):
        # Top toolbar
        toolbar = tk.Frame(self, bg=_BG_DARK, padx=8, pady=6)
        toolbar.pack(fill=tk.X)

        ttk.Button(toolbar, text="Open APK / XAPK", command=self._open_apk).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(toolbar, text="Output Folder", command=self._choose_output).pack(side=tk.LEFT, padx=(0, 6))

        self._apk_label = tk.Label(toolbar, text="No file selected", bg=_BG_DARK, fg=_FG_DIM, anchor="w")
        self._apk_label.pack(side=tk.LEFT, padx=(10, 0), fill=tk.X, expand=True)

        self._out_label = tk.Label(toolbar, text="No output folder", bg=_BG_DARK, fg=_FG_DIM, anchor="e")
        self._out_label.pack(side=tk.RIGHT, padx=(0, 10))

        # Notebook (tabs)
        self._notebook = ttk.Notebook(self)
        self._notebook.pack(fill=tk.BOTH, expand=True, padx=6, pady=(6, 0))

        # Tab 1: Main (extraction + file browser)
        self._build_main_tab()

        # Tab 2: Code Analysis (Ghidra)
        self._build_code_analysis_tab()

        # Tab 3: AI Export
        self._build_ai_export_tab()

        # Tab 4: UI Screens
        self._build_ui_screens_tab()

        # Status bar
        self._status_var = tk.StringVar(value="Ready")
        status_bar = tk.Label(self, textvariable=self._status_var, bg=_BG_DARK,
                               fg=_FG_DIM, anchor="w", padx=8)
        status_bar.pack(fill=tk.X, side=tk.BOTTOM)

    # ── Tab 1: Main ───────────────────────────────────────────────────

    def _build_main_tab(self):
        main_tab = tk.Frame(self._notebook, bg=_BG)
        self._notebook.add(main_tab, text="  Main  ")

        paned = tk.PanedWindow(main_tab, orient=tk.HORIZONTAL, bg=_BG, sashwidth=4,
                                sashrelief=tk.FLAT)
        paned.pack(fill=tk.BOTH, expand=True, padx=2, pady=2)

        # Left pane: file browser
        left_frame = tk.Frame(paned, bg=_BG)
        paned.add(left_frame, width=320, minsize=200)

        tk.Label(left_frame, text="Output Files", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(anchor="w", padx=4, pady=(4, 2))

        self._file_tree = ttk.Treeview(left_frame, show="tree", selectmode="browse")
        self._file_tree_scroll = ttk.Scrollbar(left_frame, orient=tk.VERTICAL,
                                               command=self._file_tree.yview)
        self._file_tree.configure(yscrollcommand=self._file_tree_scroll.set)
        self._file_tree_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        self._file_tree.pack(fill=tk.BOTH, expand=True, padx=(4, 0))

        btn_frame_left = tk.Frame(left_frame, bg=_BG)
        btn_frame_left.pack(fill=tk.X, padx=4, pady=4)
        ttk.Button(btn_frame_left, text="Refresh Tree", command=self._refresh_file_tree).pack(side=tk.LEFT, padx=(0, 4))
        ttk.Button(btn_frame_left, text="Edit Selected File", command=self._edit_selected_file).pack(side=tk.LEFT)

        # Right pane: log + actions
        right_frame = tk.Frame(paned, bg=_BG)
        paned.add(right_frame, minsize=400)

        tk.Label(right_frame, text="Console Log", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(anchor="w", padx=4, pady=(4, 2))

        self._log_text = scrolledtext.ScrolledText(
            right_frame, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, selectbackground=_BG_LIGHT,
            font=("Consolas", 9), state=tk.DISABLED, height=20,
        )
        self._log_text.pack(fill=tk.BOTH, expand=True, padx=4, pady=(0, 4))

        action_frame = tk.Frame(right_frame, bg=_BG)
        action_frame.pack(fill=tk.X, padx=4, pady=(0, 4))

        ttk.Button(action_frame, text="Start Extraction", style="Accent.TButton",
                    command=self._start_extraction).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(action_frame, text="Extract UI Screens", style="Accent.TButton",
                    command=self._start_ui_extract).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(action_frame, text="Rebuild & Sign APK", style="Green.TButton",
                    command=self._start_rebuild).pack(side=tk.LEFT)

        self._progress = ttk.Progressbar(action_frame, mode="indeterminate", length=200)
        self._progress.pack(side=tk.RIGHT, padx=(6, 0))

    # ── Tab 2: Code Analysis ──────────────────────────────────────────

    def _build_code_analysis_tab(self):
        tab = tk.Frame(self._notebook, bg=_BG)
        self._notebook.add(tab, text="  Code Analysis  ")

        # Top section: Ghidra path setting
        config_frame = tk.Frame(tab, bg=_BG)
        config_frame.pack(fill=tk.X, padx=8, pady=(8, 4))

        tk.Label(config_frame, text="Ghidra Path:", bg=_BG, fg=_FG,
                 font=("Segoe UI", 9)).pack(side=tk.LEFT, padx=(0, 6))
        self._ghidra_path_var = tk.StringVar(value=_load_config().get("ghidra_path", ""))
        self._ghidra_path_entry = tk.Entry(config_frame, textvariable=self._ghidra_path_var,
                                            bg=_BG_DARK, fg=_FG, insertbackground=_FG,
                                            font=("Consolas", 9), width=50)
        self._ghidra_path_entry.pack(side=tk.LEFT, padx=(0, 6), fill=tk.X, expand=True)
        ttk.Button(config_frame, text="Browse", command=self._browse_ghidra_path).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(config_frame, text="Save", command=self._save_ghidra_path).pack(side=tk.LEFT)

        # Search section
        search_frame = tk.Frame(tab, bg=_BG)
        search_frame.pack(fill=tk.X, padx=8, pady=4)

        tk.Label(search_frame, text="Search method or class name:", bg=_BG, fg=_FG,
                 font=("Segoe UI", 9)).pack(anchor="w")
        search_row = tk.Frame(search_frame, bg=_BG)
        search_row.pack(fill=tk.X, pady=(2, 0))

        self._ghidra_search_var = tk.StringVar()
        self._ghidra_search_entry = tk.Entry(search_row, textvariable=self._ghidra_search_var,
                                              bg=_BG_DARK, fg=_FG, insertbackground=_FG,
                                              font=("Consolas", 9))
        self._ghidra_search_entry.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=(0, 6))
        self._ghidra_search_entry.bind("<Return>", lambda e: self._ghidra_search())
        ttk.Button(search_row, text="Search", command=self._ghidra_search).pack(side=tk.LEFT)

        # Results list
        tk.Label(tab, text="Search Results:", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 9, "bold")).pack(anchor="w", padx=8, pady=(4, 2))

        results_frame = tk.Frame(tab, bg=_BG)
        results_frame.pack(fill=tk.BOTH, expand=True, padx=8, pady=(0, 4))

        self._ghidra_results_list = tk.Listbox(
            results_frame, bg=_BG_DARK, fg=_FG, selectbackground=_BG_LIGHT,
            font=("Consolas", 9), selectmode=tk.SINGLE, height=8,
        )
        ghidra_scroll = ttk.Scrollbar(results_frame, orient=tk.VERTICAL,
                                       command=self._ghidra_results_list.yview)
        self._ghidra_results_list.configure(yscrollcommand=ghidra_scroll.set)
        ghidra_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        self._ghidra_results_list.pack(fill=tk.BOTH, expand=True)

        # Decompile button + output
        action_row = tk.Frame(tab, bg=_BG)
        action_row.pack(fill=tk.X, padx=8, pady=(0, 4))
        ttk.Button(action_row, text="Decompile Selected", style="Accent.TButton",
                    command=self._ghidra_decompile).pack(side=tk.LEFT)
        self._ghidra_status = tk.Label(action_row, text="", bg=_BG, fg=_FG_DIM)
        self._ghidra_status.pack(side=tk.LEFT, padx=(10, 0))

        tk.Label(tab, text="Decompiled C Pseudocode:", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 9, "bold")).pack(anchor="w", padx=8, pady=(4, 2))

        self._ghidra_code_output = scrolledtext.ScrolledText(
            tab, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, font=("Consolas", 9),
            state=tk.DISABLED, height=12,
        )
        self._ghidra_code_output.pack(fill=tk.BOTH, expand=True, padx=8, pady=(0, 8))

        # Internal state
        self._ghidra_search_results: list[dict] = []

    # ── Tab 3: AI Export ──────────────────────────────────────────────

    def _build_ai_export_tab(self):
        tab = tk.Frame(self._notebook, bg=_BG)
        self._notebook.add(tab, text="  AI Export  ")

        # Screen name input
        input_frame = tk.Frame(tab, bg=_BG)
        input_frame.pack(fill=tk.X, padx=8, pady=(8, 4))

        tk.Label(input_frame, text="Screen / Feature Name:", bg=_BG, fg=_FG,
                 font=("Segoe UI", 9)).pack(anchor="w")
        name_row = tk.Frame(input_frame, bg=_BG)
        name_row.pack(fill=tk.X, pady=(2, 0))

        self._ai_screen_var = tk.StringVar()
        self._ai_screen_entry = tk.Entry(name_row, textvariable=self._ai_screen_var,
                                          bg=_BG_DARK, fg=_FG, insertbackground=_FG,
                                          font=("Consolas", 9))
        self._ai_screen_entry.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=(0, 6))
        self._ai_screen_entry.bind("<Return>", lambda e: self._ai_export_screen())

        ttk.Button(name_row, text="Export for AI", style="Accent.TButton",
                    command=self._ai_export_screen).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(name_row, text="Export Full Project", style="Green.TButton",
                    command=self._ai_export_full).pack(side=tk.LEFT)

        # Buttons row
        btn_row = tk.Frame(tab, bg=_BG)
        btn_row.pack(fill=tk.X, padx=8, pady=4)
        ttk.Button(btn_row, text="Open Export Folder", command=self._ai_open_export).pack(side=tk.LEFT)
        self._ai_export_status = tk.Label(btn_row, text="", bg=_BG, fg=_FG_DIM)
        self._ai_export_status.pack(side=tk.LEFT, padx=(10, 0))

        # Progress log
        tk.Label(tab, text="Export Log:", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 9, "bold")).pack(anchor="w", padx=8, pady=(4, 2))

        self._ai_log_text = scrolledtext.ScrolledText(
            tab, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, font=("Consolas", 9),
            state=tk.DISABLED, height=18,
        )
        self._ai_log_text.pack(fill=tk.BOTH, expand=True, padx=8, pady=(0, 8))

    # ── Tab 4: UI Screens ────────────────────────────────────────────

    def _build_ui_screens_tab(self):
        tab = tk.Frame(self._notebook, bg=_BG)
        self._notebook.add(tab, text="  UI Screens  ")

        paned = tk.PanedWindow(tab, orient=tk.HORIZONTAL, bg=_BG, sashwidth=4,
                                sashrelief=tk.FLAT)
        paned.pack(fill=tk.BOTH, expand=True, padx=2, pady=2)

        # Left pane: tree of JSON files
        left = tk.Frame(paned, bg=_BG)
        paned.add(left, width=300, minsize=180)

        tk.Label(left, text="UI Screen Files", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(anchor="w", padx=4, pady=(4, 2))

        self._ui_tree = ttk.Treeview(left, show="tree", selectmode="browse")
        ui_scroll = ttk.Scrollbar(left, orient=tk.VERTICAL, command=self._ui_tree.yview)
        self._ui_tree.configure(yscrollcommand=ui_scroll.set)
        ui_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        self._ui_tree.pack(fill=tk.BOTH, expand=True, padx=(4, 0))
        self._ui_tree.bind("<<TreeviewSelect>>", self._on_ui_tree_select)

        ui_btn_frame = tk.Frame(left, bg=_BG)
        ui_btn_frame.pack(fill=tk.X, padx=4, pady=4)
        ttk.Button(ui_btn_frame, text="Refresh", command=self._refresh_ui_tree).pack(side=tk.LEFT, padx=(0, 4))
        ttk.Button(ui_btn_frame, text="Open Folder", command=self._open_ui_folder).pack(side=tk.LEFT, padx=(0, 4))

        tk.Label(ui_btn_frame, text="Framework:", bg=_BG, fg=_FG_DIM,
                 font=("Segoe UI", 8)).pack(side=tk.LEFT, padx=(8, 2))
        self._framework_var = tk.StringVar(value="Flutter")
        framework_combo = ttk.Combobox(
            ui_btn_frame, textvariable=self._framework_var, width=14,
            values=["Flutter", "React Native", "HTML/CSS", "SwiftUI", "Jetpack Compose"],
            state="readonly",
        )
        framework_combo.pack(side=tk.LEFT, padx=(0, 4))

        ttk.Button(ui_btn_frame, text="Copy Agent Prompt",
                    command=self._copy_agent_prompt).pack(side=tk.LEFT)

        # Right pane: JSON + summary
        right = tk.Frame(paned, bg=_BG)
        paned.add(right, minsize=400)

        self._ui_json_text = scrolledtext.ScrolledText(
            right, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, font=("Consolas", 9),
            state=tk.DISABLED, height=25,
        )
        self._ui_json_text.pack(fill=tk.BOTH, expand=True, padx=4, pady=(4, 2))

        tk.Label(right, text="Summary", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 9, "bold")).pack(anchor="w", padx=4, pady=(2, 0))

        self._ui_summary_text = scrolledtext.ScrolledText(
            right, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, font=("Consolas", 9),
            state=tk.DISABLED, height=10,
        )
        self._ui_summary_text.pack(fill=tk.BOTH, expand=True, padx=4, pady=(0, 4))

        self._ui_screens_data: dict = {}

    def _refresh_ui_tree(self):
        self._ui_tree.delete(*self._ui_tree.get_children())
        self._ui_screens_data.clear()
        if not self._output_dir:
            return
        ui_dir = self._output_dir / "UI_Screens"
        if not ui_dir.exists():
            return
        for faction_dir in sorted(ui_dir.iterdir()):
            if not faction_dir.is_dir():
                continue
            f_id = self._ui_tree.insert("", "end", text=faction_dir.name, open=True)
            for cat_dir in sorted(faction_dir.iterdir()):
                if not cat_dir.is_dir():
                    continue
                c_id = self._ui_tree.insert(f_id, "end", text=cat_dir.name)
                for jf in sorted(cat_dir.glob("*.json")):
                    self._ui_tree.insert(c_id, "end", text=jf.name,
                                          values=(str(jf),))

    def _on_ui_tree_select(self, _event):
        sel = self._ui_tree.selection()
        if not sel:
            return
        item = sel[0]
        vals = self._ui_tree.item(item, "values")
        if not vals:
            return
        jpath = Path(vals[0])
        if not jpath.exists():
            return
        try:
            data = json.loads(jpath.read_text(encoding="utf-8"))
        except Exception:
            return

        self._ui_json_text.configure(state=tk.NORMAL)
        self._ui_json_text.delete("1.0", tk.END)
        self._ui_json_text.insert("1.0", json.dumps(data, indent=2, ensure_ascii=False))
        self._ui_json_text.configure(state=tk.DISABLED)

        summary = self._build_ui_summary(data)
        self._ui_summary_text.configure(state=tk.NORMAL)
        self._ui_summary_text.delete("1.0", tk.END)
        self._ui_summary_text.insert("1.0", summary)
        self._ui_summary_text.configure(state=tk.DISABLED)

    def _build_ui_summary(self, data: dict) -> str:
        elements = data.get("elements", [])
        manifest = data.get("asset_manifest", {})

        texts = manifest.get("texts_found", [])
        sprites = manifest.get("sprites_used", [])
        fonts = manifest.get("fonts_used", [])
        colors = manifest.get("colors_used", [])

        missing = []
        for s in sprites:
            if s.startswith("MISSING:"):
                missing.append(s)
        for f in fonts:
            if f.startswith("MISSING:"):
                missing.append(f)

        lines = [
            f"Screen: {data.get('screen_name', '?')}",
            f"Bundle: {data.get('source_bundle', '?')}",
            f"Canvas size: {data.get('canvas_size', {})}",
            f"Total elements: {len(elements)}",
            "",
            f"Texts found ({len(texts)}):",
        ]
        for t in texts[:50]:
            lines.append(f"  - {t}")
        if len(texts) > 50:
            lines.append(f"  ... and {len(texts) - 50} more")

        lines.append("")
        lines.append(f"Sprites used ({len(sprites)}):")
        for s in sprites[:50]:
            lines.append(f"  - {s}")
        if len(sprites) > 50:
            lines.append(f"  ... and {len(sprites) - 50} more")

        lines.append("")
        lines.append(f"Fonts used ({len(fonts)}):")
        for f in fonts[:30]:
            lines.append(f"  - {f}")

        if colors:
            lines.append("")
            lines.append(f"Colors ({len(colors)}):")
            for c in colors[:20]:
                lines.append(f"  - {c}")

        if missing:
            lines.append("")
            lines.append(f"Missing assets ({len(missing)}):")
            for m in missing[:20]:
                lines.append(f"  - {m}")

        return "\n".join(lines)

    def _open_ui_folder(self):
        if not self._output_dir:
            return
        ui_dir = self._output_dir / "UI_Screens"
        if ui_dir.exists():
            os.startfile(str(ui_dir))

    def _copy_agent_prompt(self):
        sel = self._ui_tree.selection()
        if not sel:
            messagebox.showinfo("No Selection", "Select a screen JSON file from the tree first.")
            return
        item = sel[0]
        vals = self._ui_tree.item(item, "values")
        if not vals:
            return
        jpath = Path(vals[0])
        if not jpath.exists():
            return
        try:
            data = json.loads(jpath.read_text(encoding="utf-8"))
        except Exception:
            return

        framework = self._framework_var.get()
        json_str = json.dumps(data, indent=2, ensure_ascii=False)

        prompt = (
            f"Implement this UI screen in {framework}. Here is the complete "
            f"screen specification:\n\n```json\n{json_str}\n```\n\n"
            "Rules:\n"
            "- Every element in the JSON must be implemented. Do not skip any.\n"
            "- Use the sprite_file paths exactly as listed in asset_manifest.sprites_used\n"
            "- Use the font_file paths exactly as listed in asset_manifest.fonts_used\n"
            "- Match position, size, color, and anchor values exactly\n"
            "- Every Button element must have a named onPress handler stub\n"
            "- Every Text element must use the exact text string from the JSON\n"
            "- Output a single self-contained component file"
        )

        self.clipboard_clear()
        self.clipboard_append(prompt)
        self._set_status("Agent prompt copied to clipboard.")
        messagebox.showinfo(
            "Copied",
            f"AI agent prompt ({framework}) copied to clipboard.\n"
            f"Length: {len(prompt):,} characters",
        )

    def _start_ui_extract(self):
        if not self._apk_path:
            messagebox.showwarning("No APK", "Open an APK/XAPK file first.")
            return
        if not self._output_dir:
            self._output_dir = self._apk_path.parent / "extracted_output"
            self._out_label.config(text=str(self._output_dir.name), fg=_FG)

        self._set_status("Extracting UI screens...")
        self._start_progress()
        self._log("Starting UI screen hierarchy extraction...")

        def _run():
            from il2cpp_recovery_studio.ui_extractor.hierarchy import UIHierarchyExtractor
            import zipfile, UnityPy
            ui_ext = UIHierarchyExtractor(
                output_dir=self._output_dir,
                extracted_assets_dir=self._output_dir,
                log_callback=self._log,
            )
            apk = self._apk_path
            total = 0
            with zipfile.ZipFile(str(apk), 'r') as z:
                inner_apks = [n for n in z.namelist() if n.endswith(".apk")]
                if not inner_apks:
                    return 0
                main_apk = max(inner_apks, key=lambda n: z.getinfo(n).file_size)
                apk_data = z.read(main_apk)
            import tempfile
            tp = Path(tempfile.gettempdir()) / "ui_extract.apk"
            tp.write_bytes(apk_data)
            del apk_data
            with zipfile.ZipFile(str(tp), 'r') as z:
                bundle_files = [n for n in z.namelist() if n.endswith('.bundle')]
                for bi, bname in enumerate(bundle_files):
                    try:
                        bdata = z.read(bname)
                        n = ui_ext.extract_from_bundle(bdata, bname)
                        total += n
                        del bdata
                    except Exception:
                        pass
            try: tp.unlink()
            except: pass
            return total

        def _on_done(count):
            self._stop_progress()
            self._set_status(f"UI extraction complete: {count} screen(s)")
            self._log(f"=== UI extraction complete: {count} screen(s) ===")
            self._refresh_ui_tree()
            messagebox.showinfo(
                "UI Extraction Complete",
                f"Found {count} UI screen(s).\n"
                f"Saved to: {self._output_dir}/UI_Screens/",
            )

        def _on_error(exc):
            self._stop_progress()
            self._set_status(f"UI extraction failed: {exc}")
            self._log(f"ERROR: {exc}")

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    # -- Logging -------------------------------------------------------------

    def _log(self, msg: str, **_kwargs):
        """Thread-safe logging to the main console area."""
        def _append():
            self._log_text.configure(state=tk.NORMAL)
            self._log_text.insert(tk.END, msg + "\n")
            self._log_text.see(tk.END)
            self._log_text.configure(state=tk.DISABLED)
        self.after(0, _append)

    def _ai_log(self, msg: str):
        """Thread-safe logging to the AI export console."""
        def _append():
            self._ai_log_text.configure(state=tk.NORMAL)
            self._ai_log_text.insert(tk.END, msg + "\n")
            self._ai_log_text.see(tk.END)
            self._ai_log_text.configure(state=tk.DISABLED)
        self.after(0, _append)

    def _set_status(self, msg: str):
        self.after(0, lambda: self._status_var.set(msg))

    def _start_progress(self):
        self.after(0, lambda: self._progress.start(10))

    def _stop_progress(self):
        self.after(0, lambda: self._progress.stop())

    # -- Actions: Main tab ---------------------------------------------------

    def _open_apk(self):
        path = filedialog.askopenfilename(
            title="Open APK / XAPK",
            filetypes=[("APK/XAPK files", "*.apk *.xapk"), ("All files", "*.*")],
        )
        if path:
            self._apk_path = Path(path)
            self._apk_label.config(text=self._apk_path.name, fg=_FG)
            self._log(f"Opened: {self._apk_path}")
            if self._output_dir is None:
                self._output_dir = self._apk_path.parent / "extracted_output"
                self._out_label.config(text=str(self._output_dir.name), fg=_FG)

    def _choose_output(self):
        d = filedialog.askdirectory(title="Select Output Folder")
        if d:
            self._output_dir = Path(d)
            self._out_label.config(text=self._output_dir.name, fg=_FG)
            self._log(f"Output folder: {self._output_dir}")

    def _start_extraction(self):
        if not self._apk_path:
            messagebox.showwarning("No APK", "Please open an APK or XAPK file first.")
            return
        if not self._output_dir:
            self._output_dir = self._apk_path.parent / "extracted_output"
            self._out_label.config(text=self._output_dir.name, fg=_FG)

        self._extract_done = False
        self._set_status("Extracting assets...")
        self._start_progress()
        self._log(f"Starting extraction: {self._apk_path.name} -> {self._output_dir}")

        def _run():
            from il2cpp_recovery_studio.extract_all import run as extract_run
            extract_run(
                apk_path=self._apk_path,
                output_dir=self._output_dir,
                log_callback=self._log,
            )

        def _on_done(_):
            self._stop_progress()
            self._extract_done = True
            self._set_status("Extraction complete.")
            self._log("=== Extraction complete ===")
            self._refresh_file_tree()

        def _on_error(exc):
            self._stop_progress()
            self._set_status(f"Extraction failed: {exc}")
            self._log(f"ERROR: {exc}")

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    def _start_rebuild(self):
        if not self._apk_path:
            messagebox.showwarning("No APK", "Please open an APK or XAPK file first.")
            return
        if not self._output_dir:
            messagebox.showwarning("No Output", "Please choose an output folder first.")
            return

        rebuild_dir = self._output_dir / "rebuild_output"
        rebuild_dir.mkdir(parents=True, exist_ok=True)

        self._set_status("Rebuilding & signing APK...")
        self._start_progress()
        self._log("Starting APK rebuild pipeline...")

        def _run():
            from il2cpp_recovery_studio.rebuild.pipeline import rebuild_apk
            return rebuild_apk(
                original_apk=self._apk_path,
                modified_files_dir=self._output_dir,
                output_dir=rebuild_dir,
                log_callback=self._log,
            )

        def _on_done(result):
            self._stop_progress()
            if result.success:
                self._set_status(f"APK ready: {result.output_apk.name}")
                self._log(f"SUCCESS: Signed APK at {result.output_apk}")
                messagebox.showinfo(
                    "APK Rebuilt",
                    f"Signed APK saved to:\n{result.output_apk}\n\n"
                    f"Elapsed: {result.elapsed_ms / 1000:.1f}s",
                )
                self._refresh_file_tree()
            else:
                self._set_status(f"Rebuild failed: {result.error}")
                self._log(f"ERROR: {result.error}")
                messagebox.showerror("Rebuild Failed", result.error)

        def _on_error(exc):
            self._stop_progress()
            self._set_status(f"Rebuild failed: {exc}")
            self._log(f"ERROR: {exc}")

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    # -- Actions: Code Analysis tab -----------------------------------------

    def _browse_ghidra_path(self):
        d = filedialog.askdirectory(title="Select Ghidra Installation Folder")
        if d:
            self._ghidra_path_var.set(d)

    def _save_ghidra_path(self):
        cfg = _load_config()
        cfg["ghidra_path"] = self._ghidra_path_var.get()
        _save_config(cfg)
        self._ghidra_status.config(text="Path saved.", fg=_GREEN)

    def _ghidra_search(self):
        query = self._ghidra_search_var.get().strip()
        if not query:
            messagebox.showinfo("Empty Query", "Enter a method or class name to search.")
            return

        if not self._output_dir:
            messagebox.showwarning("No Output", "Run extraction first to generate the method map.")
            return

        method_map = self._find_method_address_map()
        if not method_map:
            messagebox.showwarning("No Method Map", "No method_address_map.txt found in the output directory.")
            return

        self._ghidra_results_list.delete(0, tk.END)
        self._ghidra_search_results = []
        self._set_status(f"Searching for '{query}'...")

        def _run():
            from il2cpp_recovery_studio.ghidra.analyzer import GhidraAnalyzer
            analyzer = GhidraAnalyzer(
                ghidra_path=Path(self._ghidra_path_var.get()) if self._ghidra_path_var.get() else None,
                method_address_map_path=method_map,
            )
            return analyzer.search_methods(query)

        def _on_done(results):
            self._ghidra_search_results = results
            for row in results:
                display = (f"{row.get('namespace_class', '')} | "
                           f"{row.get('dotnet_signature', '')} | "
                           f"0x{row.get('address', '0')}")
                self._ghidra_results_list.insert(tk.END, display)
            self._set_status(f"Found {len(results)} result(s)")
            if not results:
                messagebox.showinfo("No Results", f"No methods found matching '{query}'.")

        def _on_error(exc):
            self._set_status(f"Search failed: {exc}")
            messagebox.showerror("Search Error", str(exc))

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    def _ghidra_decompile(self):
        # First-run warning for Ghidra analysis
        cfg = _load_config()
        if not cfg.get("ghidra_first_run_warned"):
            result = messagebox.askyesno(
                "Ghidra Code Analysis",
                "This feature uses Ghidra (NSA) to decompile native code from libil2cpp.so.\n\n"
                "• Ghidra and Java JDK will be auto-downloaded on first use (~600 MB)\n"
                "• Decompilation can take up to 2 minutes per method\n"
                "• Output is C pseudocode from the IL2CPP native binary\n\n"
                "Continue?",
            )
            cfg["ghidra_first_run_warned"] = True
            _save_config(cfg)
            if not result:
                return

        sel = self._ghidra_results_list.curselection()
        if not sel:
            messagebox.showinfo("No Selection", "Select a method from the search results first.")
            return

        idx = sel[0]
        if idx >= len(self._ghidra_search_results):
            return

        method = self._ghidra_search_results[idx]
        method_name = method.get("dotnet_signature") or method.get("cpp_name", "")

        if not self._output_dir:
            return

        method_map = self._find_method_address_map()
        libil2cpp = self._find_libil2cpp()

        if not libil2cpp:
            messagebox.showwarning(
                "libil2cpp.so Not Found",
                "Could not find libil2cpp.so in the extracted output.\n\n"
                "Ensure extraction is complete and the APK contains IL2CPP binaries."
            )
            return

        decompile_dir = self._output_dir / "ghidra_decompiled"
        decompile_dir.mkdir(parents=True, exist_ok=True)

        self._ghidra_status.config(text="Decompiling (may take up to 2 minutes)...", fg=_YELLOW)
        self._start_progress()

        def _run():
            from il2cpp_recovery_studio.ghidra.analyzer import GhidraAnalyzer
            analyzer = GhidraAnalyzer(
                ghidra_path=Path(self._ghidra_path_var.get()) if self._ghidra_path_var.get() else None,
                libil2cpp_path=libil2cpp,
                method_address_map_path=method_map,
                output_dir=decompile_dir,
            )
            return analyzer.decompile_method(method_name)

        def _on_done(result):
            self._stop_progress()
            self._ghidra_code_output.configure(state=tk.NORMAL)
            self._ghidra_code_output.delete("1.0", tk.END)
            if result.get("error"):
                self._ghidra_code_output.insert("1.0", f"Error: {result['error']}")
                self._ghidra_status.config(text="Decompilation failed.", fg=_RED)
            else:
                self._ghidra_code_output.insert("1.0", result.get("decompiled_c_code", ""))
                self._ghidra_status.config(text="Decompilation complete.", fg=_GREEN)
            self._ghidra_code_output.configure(state=tk.DISABLED)

        def _on_error(exc):
            self._stop_progress()
            self._ghidra_status.config(text=f"Error: {exc}", fg=_RED)

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    def _find_method_address_map(self) -> Optional[Path]:
        """Search the output directory for method_address_map.txt."""
        if not self._output_dir:
            return None
        for pattern in ("**/method_address_map.txt", "**/method_address_map*.txt"):
            for match in self._output_dir.rglob(pattern.split("/")[-1]):
                return match
        return None

    def _find_libil2cpp(self) -> Optional[Path]:
        """Search the output directory for libil2cpp.so."""
        if not self._output_dir:
            return None
        for match in self._output_dir.rglob("libil2cpp.so"):
            return match
        for match in self._output_dir.rglob("libil2cpp*"):
            return match
        return None

    # -- Actions: AI Export tab ---------------------------------------------

    def _ai_export_screen(self):
        screen_name = self._ai_screen_var.get().strip()
        if not screen_name:
            messagebox.showinfo("No Name", "Enter a screen/feature name to export.")
            return
        if not self._output_dir or not self._output_dir.exists():
            messagebox.showwarning("No Output", "Run extraction first.")
            return

        export_dir = self._output_dir / "ai_export"
        method_map = self._find_method_address_map()

        self._set_status(f"Exporting screen: {screen_name}...")
        self._start_progress()

        def _run():
            from il2cpp_recovery_studio.ai_export.exporter import AIExporter
            exporter = AIExporter(log_callback=self._ai_log)
            return exporter.export_screen(
                screen_name=screen_name,
                extracted_assets_dir=self._output_dir,
                method_address_map=method_map,
                output_dir=export_dir,
            )

        def _on_done(result):
            self._stop_progress()
            self._ai_export_status.config(text=f"Exported: {result}", fg=_GREEN)
            self._set_status(f"AI export complete: {screen_name}")

        def _on_error(exc):
            self._stop_progress()
            self._ai_export_status.config(text=f"Export failed: {exc}", fg=_RED)

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    def _ai_export_full(self):
        if not self._output_dir or not self._output_dir.exists():
            messagebox.showwarning("No Output", "Run extraction first.")
            return

        export_dir = self._output_dir / "ai_export"
        method_map = self._find_method_address_map()

        self._set_status("Exporting full project for AI...")
        self._start_progress()

        def _run():
            from il2cpp_recovery_studio.ai_export.exporter import AIExporter
            exporter = AIExporter(log_callback=self._ai_log)
            return exporter.export_full_project(
                extracted_assets_dir=self._output_dir,
                method_address_map=method_map,
                output_dir=export_dir,
            )

        def _on_done(result):
            self._stop_progress()
            self._ai_export_status.config(text=f"Full export complete: {result}", fg=_GREEN)
            self._set_status("Full AI export complete.")

        def _on_error(exc):
            self._stop_progress()
            self._ai_export_status.config(text=f"Export failed: {exc}", fg=_RED)

        _run_in_thread(self, _run, on_done=_on_done, on_error=_on_error)

    def _ai_open_export(self):
        export_dir = self._output_dir / "ai_export" if self._output_dir else None
        if not export_dir or not export_dir.exists():
            messagebox.showinfo("No Export", "No AI export folder found. Run an export first.")
            return

        if platform.system() == "Windows":
            os.startfile(str(export_dir))
        elif platform.system() == "Darwin":
            subprocess.Popen(["open", str(export_dir)])
        else:
            subprocess.Popen(["xdg-open", str(export_dir)])

    # -- File tree -----------------------------------------------------------

    def _refresh_file_tree(self):
        self._file_tree.delete(*self._file_tree.get_children())
        if not self._output_dir or not self._output_dir.exists():
            return
        self._populate_tree("", self._output_dir)

    def _populate_tree(self, parent, directory: Path):
        try:
            entries = sorted(directory.iterdir(), key=lambda e: (not e.is_dir(), e.name.lower()))
        except PermissionError:
            return
        for entry in entries:
            if entry.name.startswith(".") or entry.name == "__pycache__":
                continue
            display = entry.name + ("/" if entry.is_dir() else "")
            node = self._file_tree.insert(parent, "end", text=display,
                                           values=(str(entry),))
            if entry.is_dir():
                self._populate_tree(node, entry)

    def _edit_selected_file(self):
        sel = self._file_tree.selection()
        if not sel:
            messagebox.showinfo("No Selection", "Select a file in the tree first.")
            return
        file_path_str = self._file_tree.item(sel[0], "values")[0]
        file_path = Path(file_path_str)
        if not file_path.exists() or file_path.is_dir():
            messagebox.showinfo("Not a File", "Selected item is not a file.")
            return

        try:
            content = file_path.read_text(encoding="utf-8")
        except (UnicodeDecodeError, PermissionError) as exc:
            messagebox.showerror("Cannot Edit", f"Cannot open file as text:\n{exc}")
            return

        EditorWindow(self, file_path, content)


# ---------------------------------------------------------------------------
# Simple text/JSON editor window
# ---------------------------------------------------------------------------

class EditorWindow(tk.Toplevel):
    """A simple text editor for editing extracted files."""

    def __init__(self, parent: App, file_path: Path, content: str):
        super().__init__(parent)
        self._file_path = file_path
        self.title(f"Editing: {file_path.name}")
        self.geometry("750x550")
        self.configure(bg=_BG)
        self.transient(parent)

        toolbar = tk.Frame(self, bg=_BG_DARK, padx=6, pady=4)
        toolbar.pack(fill=tk.X)

        tk.Label(toolbar, text=str(file_path.name), bg=_BG_DARK, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(side=tk.LEFT)

        ttk.Button(toolbar, text="Save", style="Accent.TButton",
                    command=self._save).pack(side=tk.RIGHT, padx=(4, 0))
        ttk.Button(toolbar, text="Format JSON",
                    command=self._format_json).pack(side=tk.RIGHT, padx=(4, 0))

        self._text = scrolledtext.ScrolledText(
            self, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, selectbackground=_BG_LIGHT,
            font=("Consolas", 10),
        )
        self._text.pack(fill=tk.BOTH, expand=True, padx=6, pady=(6, 0))
        self._text.insert("1.0", content)

        self._status = tk.Label(self, text="Ready", bg=_BG_DARK, fg=_FG_DIM, anchor="w", padx=6)
        self._status.pack(fill=tk.X, side=tk.BOTTOM)

    def _save(self):
        content = self._text.get("1.0", tk.END).rstrip("\n")
        try:
            self._file_path.write_text(content, encoding="utf-8")
            self._status.config(text="Saved!", fg=_GREEN)
        except Exception as exc:
            self._status.config(text=f"Save failed: {exc}", fg=_RED)

    def _format_json(self):
        content = self._text.get("1.0", tk.END).strip()
        try:
            data = json.loads(content)
            formatted = json.dumps(data, indent=2, ensure_ascii=False)
            self._text.delete("1.0", tk.END)
            self._text.insert("1.0", formatted)
            self._status.config(text="JSON formatted", fg=_GREEN)
        except json.JSONDecodeError as exc:
            self._status.config(text=f"Invalid JSON: {exc}", fg=_RED)


# ---------------------------------------------------------------------------
# Entry point
# ---------------------------------------------------------------------------

def run_gui():
    """Launch the IL2CPP Recovery Studio GUI."""
    app = App()
    app.mainloop()


if __name__ == "__main__":
    run_gui()
