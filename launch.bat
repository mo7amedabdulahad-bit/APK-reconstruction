@echo off
title IL2CPP Recovery Studio
echo ============================================================
echo   IL2CPP Recovery Studio
echo   Unity APK Extraction, Editing ^& Rebuild Tool
echo ============================================================
echo.

REM Try to find Python in the standard locations
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

REM Try the known installation path for Python 3.14 (replace 'Mohamed' with your username)
if exist "%LOCALAPPDATA%\Programs\Python\Python314\python.exe" (
    "%LOCALAPPDATA%\Programs\Python\pythoncore-3.14-64\python.exe" "%~dp0launch.py"
    goto :end
)

echo ERROR: Python not found.
echo Please ensure Python 3.10+ is installed and the PATH is set correctly.
echo.
pause
:end