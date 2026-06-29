@echo off
title IL2CPP Recovery Studio
echo ============================================================
echo   IL2CPP Recovery Studio
echo   Unity APK Extraction, Editing ^& Rebuild Tool
echo ============================================================
echo.

REM Try to find Python
where python >nul 2>&1
if %ERRORLEVEL% == 0 (
    python "%~dp0launch.py"
    goto :end
)

REM Try py launcher
where py >nul 2>&1
if %ERRORLEVEL% == 0 (
    py "%~dp0launch.py"
    goto :end
)

REM Try python3
where python3 >nul 2>&1
if %ERRORLEVEL% == 0 (
    python3 "%~dp0launch.py"
    goto :end
)

echo ERROR: Python not found.
echo Please install Python 3.10+ from https://www.python.org/downloads/
echo.
pause

:end
