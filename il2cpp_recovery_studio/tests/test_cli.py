"""Tests for CLI entry point, build scripts, and .exe build."""
from __future__ import annotations

import os
import subprocess
import sys
from pathlib import Path

import pytest

_PACKAGE_DIR = Path(__file__).resolve().parent.parent
_REPO_DIR = _PACKAGE_DIR.parent


class TestCLI:
    def test_version_flag(self):
        result = subprocess.run(
            [sys.executable, "-m", "il2cpp_recovery_studio.__main__", "--version"],
            capture_output=True,
            text=True,
            cwd=str(_REPO_DIR),
            env={**os.environ, "PYTHONPATH": str(_REPO_DIR)},
        )
        assert result.returncode == 0, result.stderr
        assert "1.0.0" in result.stdout

    def test_help_flag(self):
        result = subprocess.run(
            [sys.executable, "-m", "il2cpp_recovery_studio.__main__", "--help"],
            capture_output=True,
            text=True,
            cwd=str(_REPO_DIR),
            env={**os.environ, "PYTHONPATH": str(_REPO_DIR)},
        )
        assert result.returncode == 0, result.stderr
        assert "apk" in result.stdout.lower() or "APK" in result.stdout

    def test_no_args_has_gui_branch(self):
        import il2cpp_recovery_studio.__main__ as mod
        src = mod.main.__code__.co_consts
        assert any("gui" in str(c).lower() for c in src if isinstance(c, str))

    def test_nonexistent_apk(self, tmp_path):
        result = subprocess.run(
            [sys.executable, "-m", "il2cpp_recovery_studio.__main__", "--apk", str(tmp_path / "no.apk")],
            capture_output=True,
            text=True,
            cwd=str(_REPO_DIR),
            env={**os.environ, "PYTHONPATH": str(_REPO_DIR)},
        )
        assert result.returncode != 0


class TestFrozenDetection:
    def test_is_frozen_false(self):
        from il2cpp_recovery_studio.__main__ import _is_frozen
        assert _is_frozen() is False

    def test_is_frozen_with_mock(self, monkeypatch):
        import il2cpp_recovery_studio.__main__ as mod
        monkeypatch.setattr(sys, "frozen", True, raising=False)
        monkeypatch.setattr(sys, "_MEIPASS", "/tmp", raising=False)
        assert mod._is_frozen() is True
        monkeypatch.delattr(sys, "frozen", raising=False)
        monkeypatch.delattr(sys, "_MEIPASS", raising=False)


class TestBuildExe:
    def test_import_build_exe(self):
        from il2cpp_recovery_studio.build_exe import clean, run_pyinstaller, verify, main
        assert callable(clean)
        assert callable(run_pyinstaller)
        assert callable(verify)
        assert callable(main)

    def test_clean_removes_dist(self, tmp_path, monkeypatch):
        import il2cpp_recovery_studio.build_exe as mod
        monkeypatch.setattr(mod, "_root", lambda: tmp_path)
        dist = tmp_path / "dist"
        build = tmp_path / "build"
        dist.mkdir()
        build.mkdir()
        (dist / "test.txt").write_text("x")
        mod.clean()
        assert not dist.exists()
        assert not build.exists()

    def test_verify_no_exe(self, tmp_path, monkeypatch):
        import il2cpp_recovery_studio.build_exe as mod
        monkeypatch.setattr(mod, "_root", lambda: tmp_path)
        dist = tmp_path / "dist"
        dist.mkdir()
        assert mod.verify() is False

    def test_verify_with_exe(self, tmp_path, monkeypatch):
        import il2cpp_recovery_studio.build_exe as mod
        monkeypatch.setattr(mod, "_root", lambda: tmp_path)
        dist = tmp_path / "dist"
        dist.mkdir()
        exe = dist / "IL2CPP_Recovery_Studio.exe"
        exe.write_bytes(b"\x00" * 1024)
        assert mod.verify() is True

    def test_spec_file_exists(self):
        spec = _PACKAGE_DIR / "IL2CPP_Recovery_Studio.spec"
        assert spec.exists()

    def test_build_exe_script_exists(self):
        build = _PACKAGE_DIR / "build_exe.py"
        assert build.exists()

    def test_spec_contains_entry(self):
        spec = _PACKAGE_DIR / "IL2CPP_Recovery_Studio.spec"
        content = spec.read_text()
        assert "__main__.py" in content
        assert "IL2CPP_Recovery_Studio" in content
        assert "noconsole" in content or "console=False" in content

    def test_build_exe_contains_pyinstaller(self):
        build = _PACKAGE_DIR / "build_exe.py"
        content = build.read_text()
        assert "PyInstaller" in content
        assert "clean" in content.lower() or "verify" in content.lower()


class TestBuildRelease:
    def test_import_build_release(self):
        from il2cpp_recovery_studio.build_release import clean_dist, run_tests
        assert callable(clean_dist)
        assert callable(run_tests)

    def test_clean_dist(self, tmp_path, monkeypatch):
        from il2cpp_recovery_studio.build_release import clean_dist
        monkeypatch.chdir(tmp_path)
        dist = tmp_path / "dist"
        dist.mkdir()
        (dist / "test.txt").write_text("x")
        clean_dist()
        assert not dist.exists()
