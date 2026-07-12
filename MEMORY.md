# Project Memory

## Project: IL2CPP Recovery Studio (Unity APK reverse-engineering GUI tool)
- NOT a finance/trading system. It extracts Unity APK assets, dumps IL2CPP via
  Il2CppDumper, parses Unity UI, and rebuilds modded APKs.
- Entry point: `launch.py` (run via `python launch.py` or `py.exe` on double-click).
- GUI module: `il2cpp_recovery_studio/gui/app.py` -> `run_gui()` (customtkinter).
- Python here: real CPython 3.13.7 at
  `C:\Users\Mohamed\AppData\Local\Programs\Python\Python313\python.exe`.
  `pandas` is NOT installed; `numpy` is. Keep new scripts numpy-only unless pandas added.

## launch.py double-click fix (2026-07-09)
- Symptom: "won't open when double-click launch.py". On this machine `.py` is
  associated with `C:\WINDOWS\py.exe` and the script DOES launch fine. The real
  risk was silent failures (console closes instantly) and a corrupted file.
- Fix applied: rewrote `launch.py` cleanly; fatal errors now surface in a
  tkinter messagebox + `startup_error.log` (never silent). `_has_console()` /
  `_show_error()` / `_pause_or_error()` helpers added.
- If double-click still does nothing for the user, the cause is the Windows
  `.py` file association (opens in an editor / Store stub). Fix: run
  `launch.bat` instead, or reassociate `.py` -> `py.exe`.

## Notes
- `temp_repo/` git worktree is created/removed by diagnostics; not persistent.
- Large `il2cpp_recovery_studio/gui/app.py` (~1886 lines); edit with care.
