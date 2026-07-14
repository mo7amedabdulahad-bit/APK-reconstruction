# Debug Session: unity-apk-rev-crash

## Session Info
- **Session ID**: unity-apk-rev-crash
- **Date Created**: 2026-07-12
- **Status**: [CLOSED]
- **Problem Description**: The Unity APK reverse-engineering app was crashing/freezing after Stage 4 starts.

## Hypotheses & Evidence
1. **Hypothesis #1 (Native Crash)**: [CONFIRMED] The `TypeTreeGenerator` interop (C#) was causing a native segfault when calling `read_typetree()` on a protected/obfuscated IL2CPP build. This crash is uncatchable by Python and causes the process to terminate silently.
2. **Hypothesis #2 (Slow Loop)**: [CONFIRMED] Iterating over 217,744 objects with expensive `o.read()` calls was making the app appear frozen.
3. **Hypothesis #3 (Duplicate Assets)**: [RESOLVED] Stage 2 was duplicating assets due to `.split` and `.resS` files being processed multiple times.

## Fixes Applied
1. **Fix A (TypeTree Gating)**: Gated the C# `TypeTreeGenerator` behind the `IL2CPP_TYPETREE=1` environment variable. It now defaults to `OFF`, using UnityPy's built-in (and safer) typetree reader for protected builds.
2. **Fix B (Performance)**: Replaced expensive `o.read()` in the MonoBehaviour class map loop with a cheap, native-safe `_parse_monobehaviour_header(o)` byte parse.
3. **Fix C (Duplicate Assets)**: Added a `processed_stems` set in Stage 2 to skip duplicate asset files.
4. **Fix D (UX)**: Added frequent `log()` progress updates to the Stage 4 loops so the user sees activity in the GUI.

## Verification
- Headless harness `debug_run_stage4.py` successfully completed the entire pipeline (Stages 4, 5, and 6) in ~100 seconds without crashes.
- Debug logs confirmed `s4-loop-done` and `pipeline-stage6-exit`.
