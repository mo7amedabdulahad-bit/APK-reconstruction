"""Tkinter GUI for IL2CPP Recovery Studio.

Provides APK/XAPK opening, Unity asset extraction, file browsing,
editing, and APK rebuild & signing - all in a single window.
"""
from __future__ import annotations

import json
import os
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
                self._on_done(result)
        except Exception as exc:
            if self._on_error:
                self._on_error(exc)


# ---------------------------------------------------------------------------
# Main Application
# ---------------------------------------------------------------------------

class App(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("IL2CPP Recovery Studio")
        self.geometry("1100x750")
        self.minsize(800, 550)
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

        # PanedWindow: left = file tree, right = log + editor
        paned = tk.PanedWindow(self, orient=tk.HORIZONTAL, bg=_BG, sashwidth=4,
                                sashrelief=tk.FLAT)
        paned.pack(fill=tk.BOTH, expand=True, padx=6, pady=(6, 0))

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

        # Log area
        tk.Label(right_frame, text="Console Log", bg=_BG, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(anchor="w", padx=4, pady=(4, 2))

        self._log_text = scrolledtext.ScrolledText(
            right_frame, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, selectbackground=_BG_LIGHT,
            font=("Consolas", 9), state=tk.DISABLED, height=20,
        )
        self._log_text.pack(fill=tk.BOTH, expand=True, padx=4, pady=(0, 4))

        # Action buttons at bottom
        action_frame = tk.Frame(right_frame, bg=_BG)
        action_frame.pack(fill=tk.X, padx=4, pady=(0, 4))

        ttk.Button(action_frame, text="Start Extraction", style="Accent.TButton",
                    command=self._start_extraction).pack(side=tk.LEFT, padx=(0, 6))

        ttk.Button(action_frame, text="Rebuild & Sign APK", style="Green.TButton",
                    command=self._start_rebuild).pack(side=tk.LEFT)

        self._progress = ttk.Progressbar(action_frame, mode="indeterminate", length=200)
        self._progress.pack(side=tk.RIGHT, padx=(6, 0))

        # Status bar
        self._status_var = tk.StringVar(value="Ready")
        status_bar = tk.Label(self, textvariable=self._status_var, bg=_BG_DARK,
                               fg=_FG_DIM, anchor="w", padx=8)
        status_bar.pack(fill=tk.X, side=tk.BOTTOM)

    # -- Logging -------------------------------------------------------------

    def _log(self, msg: str):
        """Thread-safe logging to the console area."""
        def _append():
            self._log_text.configure(state=tk.NORMAL)
            self._log_text.insert(tk.END, msg + "\n")
            self._log_text.see(tk.END)
            self._log_text.configure(state=tk.DISABLED)
        self.after(0, _append)

    def _set_status(self, msg: str):
        self.after(0, lambda: self._status_var.set(msg))

    def _start_progress(self):
        self.after(0, lambda: self._progress.start(10))

    def _stop_progress(self):
        self.after(0, lambda: self._progress.stop())

    # -- Actions -------------------------------------------------------------

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

        WorkerThread(_run, on_done=_on_done, on_error=_on_error).start()

    def _start_rebuild(self):
        if not self._apk_path:
            messagebox.showwarning("No APK", "Please open an APK or XAPK file first.")
            return
        if not self._output_dir:
            messagebox.showwarning("No Output", "Please choose an output folder first.")
            return

        rebuild_dir = self._output_dir / "rebuild_output"
        rebuild_dir.mkdir(parents=True, exist_ok=True)

        # The modified files are whatever is in the output dir
        # (the user has edited them via the file browser)
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

        WorkerThread(_run, on_done=_on_done, on_error=_on_error).start()

    # -- File tree -----------------------------------------------------------

    def _refresh_file_tree(self):
        """Populate the file tree from the output directory."""
        self._file_tree.delete(*self._file_tree.get_children())
        if not self._output_dir or not self._output_dir.exists():
            return
        self._populate_tree("", self._output_dir)

    def _populate_tree(self, parent, directory: Path):
        """Recursively add directories and files to the treeview."""
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
        """Open a simple text editor for the selected file."""
        sel = self._file_tree.selection()
        if not sel:
            messagebox.showinfo("No Selection", "Select a file in the tree first.")
            return
        file_path_str = self._file_tree.item(sel[0], "values")[0]
        file_path = Path(file_path_str)
        if not file_path.exists() or file_path.is_dir():
            messagebox.showinfo("Not a File", "Selected item is not a file.")
            return

        # Check if it's text-editable
        try:
            content = file_path.read_text(encoding="utf-8")
        except (UnicodeDecodeError, PermissionError) as exc:
            messagebox.showerror("Cannot Edit", f"Cannot open file as text:\n{exc}")
            return

        # Open editor window
        editor = EditorWindow(self, file_path, content)


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

        # Toolbar
        toolbar = tk.Frame(self, bg=_BG_DARK, padx=6, pady=4)
        toolbar.pack(fill=tk.X)

        tk.Label(toolbar, text=str(file_path.name), bg=_BG_DARK, fg=_ACCENT,
                 font=("Segoe UI", 10, "bold")).pack(side=tk.LEFT)

        ttk.Button(toolbar, text="Save", style="Accent.TButton",
                    command=self._save).pack(side=tk.RIGHT, padx=(4, 0))
        ttk.Button(toolbar, text="Format JSON",
                    command=self._format_json).pack(side=tk.RIGHT, padx=(4, 0))

        # Editor area
        self._text = scrolledtext.ScrolledText(
            self, wrap=tk.WORD, bg=_BG_DARK, fg=_FG,
            insertbackground=_FG, selectbackground=_BG_LIGHT,
            font=("Consolas", 10),
        )
        self._text.pack(fill=tk.BOTH, expand=True, padx=6, pady=(6, 0))
        self._text.insert("1.0", content)

        # Status
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
