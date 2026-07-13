# Debug Session: unity-apk-rev-crash

## Session Info
- **Session ID**: unity-apk-rev-crash
- **Date Created**: 2026-07-12
- **Status**: [OPEN]
- **Problem Description**: The Unity APK reverse-engineering app is crashing after Stage 4 starts; user logs show it stops after "Built global MonoScript class map with 7552 entries".

## Hypotheses
1. **Hypothesis #1**: The code crashes when iterating over env.objects in _run_stage4_ui_dump
2. **Hypothesis #2**: There's an exception in _dump_ui_obj that's not being caught
3. **Hypothesis #3**: The code is hanging or blocking on something in the object loop (not crashing but seeming to)
4. **Hypothesis #4**: There's an out-of-memory issue due to processing large number of objects
5. **Hypothesis #5**: There's an issue with sprite index lookup

## Logs
### Pre-Fix Logs
- Logs from user's previous run (abbreviated): ... [INFO] TypeTreeGenerator loaded 160 DummyDlls (Unity 6000.3.12f1). ... [INFO] Built global MonoScript class map with 7552 entries ...

### Post-Fix Logs
- (to be added after fix)
