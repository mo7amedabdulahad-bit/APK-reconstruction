@echo off
REM ============================================================
REM IL2CPP Recovery Studio - Rebuild and Test Script
REM ============================================================
REM Usage: rebuild_and_test.bat <path_to_apk>
REM
REM Steps:
REM   1. Extract assets from the APK
REM   2. Rebuild and sign a modded APK
REM   3. Install on connected device via adb
REM   4. Launch the app on the device
REM ============================================================

setlocal enabledelayedexpansion

if "%~1"=="" (
    echo ERROR: No APK path provided.
    echo Usage: rebuild_and_test.bat ^<path_to_apk^>
    exit /b 1
)

set "APK_PATH=%~1"
set "SCRIPT_DIR=%~dp0"
set "PROJECT_ROOT=%SCRIPT_DIR%.."
set "OUTPUT_DIR=%PROJECT_ROOT%\output"
set "REBUILD_DIR=%OUTPUT_DIR%\rebuild_output"

echo ============================================================
echo  IL2CPP Recovery Studio - Rebuild and Test
echo ============================================================
echo.
echo  APK:       %APK_PATH%
echo  Output:    %OUTPUT_DIR%
echo.

REM Step 1: Extract
echo [1/4] Extracting assets from APK...
python -m il2cpp_recovery_studio --cli --apk "%APK_PATH%" --output "%OUTPUT_DIR%" --reconstruct
if errorlevel 1 (
    echo ERROR: Extraction failed.
    exit /b 1
)
echo      Extraction complete.
echo.

REM Step 2: Rebuild and sign
echo [2/4] Rebuilding and signing APK...
python -c "from il2cpp_recovery_studio.rebuild.pipeline import rebuild_apk; from pathlib import Path; r = rebuild_apk(Path(r'%APK_PATH%'), Path(r'%OUTPUT_DIR%'), Path(r'%REBUILD_DIR%')); print('Output:', r.output_apk if r.success else r.error)"
if errorlevel 1 (
    echo ERROR: Rebuild failed.
    exit /b 1
)
echo      Rebuild complete.
echo.

REM Step 3: Install via adb
echo [3/4] Installing APK on device...
adb devices | findstr /r /c:"device$" >nul
if errorlevel 1 (
    echo WARNING: No Android device detected. Skipping install.
    echo          Connect a device or start an emulator and retry.
    goto :launch_skip
)

REM Find the signed APK
for %%f in ("%REBUILD_DIR%\modded_*.apk") do set "SIGNED_APK=%%f"

if not defined SIGNED_APK (
    echo WARNING: No signed APK found in %REBUILD_DIR%
    goto :launch_skip
)

adb install -r "%SIGNED_APK%"
if errorlevel 1 (
    echo WARNING: adb install failed. The device may not be connected.
    goto :launch_skip
)
echo      Install complete.
echo.

REM Step 4: Launch the app
echo [4/4] Launching app on device...

REM Extract package name from APK using aapt if available
set "PACKAGE_NAME="
for /f "tokens=2 delims= " %%a in ('aapt dump badging "%APK_PATH%" 2^>nul ^| findstr /r "package: name="') do (
    set "PACKAGE_NAME=%%a"
)

if not defined PACKAGE_NAME (
    echo WARNING: Could not determine package name. Trying common names...
    REM Try to read from the APK manifest output
    for /f "tokens=*" %%a in ('python -c "from il2cpp_recovery_studio.apk.parser import APKParser; p=APKParser(); i=p.parse(Path(r''%APK_PATH%'')); print(i.manifest.package_name)"') do (
        set "PACKAGE_NAME=%%a"
    )
)

if defined PACKAGE_NAME (
    echo      Package: !PACKAGE_NAME!
    adb shell monkey -p !PACKAGE_NAME! 1
    echo      App launched.
) else (
    echo WARNING: Could not determine package name. Please launch manually.
)

:launch_skip
echo.
echo ============================================================
echo  Done! Check your device for the app.
echo ============================================================

endlocal
