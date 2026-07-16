"""Ghidra headless analyzer for decompiling IL2CPP methods.

Provides GhidraAnalyzer which auto-detects Ghidra, decompiles individual
methods or entire classes, and searches the method address map.
"""
from __future__ import annotations

import glob
import json
import os
import platform
import shutil
import subprocess
import tempfile
import time
import urllib.request
import zipfile
from pathlib import Path
from typing import Callable, Optional


_DEFAULT_SEARCH_PATHS = [
    r"C:\ghidra*",
    r"C:\Program Files\ghidra*",
    r"C:\Program Files (x86)\ghidra*",
    os.path.expanduser("~/ghidra*"),
    "/opt/ghidra*",
    "/usr/local/ghidra*",
]

_HEADER = "address|dotnet_signature|cpp_name|namespace_class|assembly"

_GHIDRA_CONFIG_KEY = "ghidra_path"
_GHIDRA_VERSION = "11.3.1_PUBLIC"
_GHIDRA_URL = (
    f"https://github.com/NationalSecurityAgency/ghidra/releases/download/"
    f"Ghidra_{_GHIDRA_VERSION.replace('.', '_')}/ghidra_{_GHIDRA_VERSION}.zip"
)
_GHIDRA_SHA1_MAP: dict[str, str] = {}  # can be filled for verification

_CONFIG_PATH = Path(__file__).resolve().parent.parent.parent / ".gui_config.json"


def _load_config() -> dict:
    if _CONFIG_PATH.exists():
        try:
            return json.loads(_CONFIG_PATH.read_text(encoding="utf-8"))
        except Exception:
            pass
    return {}


def _save_config(cfg: dict) -> None:
    try:
        _CONFIG_PATH.write_text(json.dumps(cfg, indent=2), encoding="utf-8")
    except Exception:
        pass


class GhidraAnalyzer:
    """Auto-detect Ghidra and decompile IL2CPP methods from libil2cpp.so.

    Parameters
    ----------
    ghidra_path:
        Manually specified Ghidra installation folder. If None, auto-detect.
    libil2cpp_path:
        Path to the extracted libil2cpp.so binary.
    method_address_map_path:
        Path to the pipe-delimited method_address_map.txt file.
    output_dir:
        Where to write decompiled output files.
    """

    TOOLS_DIR = Path(__file__).resolve().parent.parent.parent / "tools"

    def __init__(
        self,
        ghidra_path: Optional[Path] = None,
        libil2cpp_path: Optional[Path] = None,
        method_address_map_path: Optional[Path] = None,
        output_dir: Optional[Path] = None,
        log_callback: Optional[Callable[[str], None]] = None,
    ) -> None:
        self.ghidra_path = Path(ghidra_path) if ghidra_path else None
        self.libil2cpp_path = Path(libil2cpp_path) if libil2cpp_path else None
        self.method_address_map_path = Path(method_address_map_path) if method_address_map_path else None
        self.output_dir = Path(output_dir) if output_dir else Path("output")
        self._log = log_callback or (lambda m: print(m))
        self._script_dir = Path(__file__).parent / "ghidra_scripts"
        self._method_cache: list[dict[str, str]] | None = None

    # -- Ghidra discovery & download -----------------------------------------

    def find_ghidra(self) -> Optional[Path]:
        """Auto-detect Ghidra installation on Windows/Linux.

        Checks C:\\ghidra*, C:\\Program Files\\ghidra*, and PATH.
        Falls back to auto-downloading Ghidra if not found.
        Returns the Ghidra root directory or None.
        """
        # If already set and valid, return it
        if self.ghidra_path and self.ghidra_path.is_dir():
            if (self.ghidra_path / "support" / "analyzeHeadless").exists():
                return self.ghidra_path

        # Check configured path first
        if self.ghidra_path:
            candidate = self.ghidra_path / "support" / "analyzeHeadless"
            if candidate.exists():
                return self.ghidra_path

        # Check saved config
        cfg = _load_config()
        saved = cfg.get(_GHIDRA_CONFIG_KEY)
        if saved:
            p = Path(saved)
            if p.is_dir() and (p / "support" / "analyzeHeadless").exists():
                self.ghidra_path = p
                self._log(f"  Found Ghidra (from config): {p}")
                return p

        # Glob-based search on common paths
        for pattern in _DEFAULT_SEARCH_PATHS:
            expanded = os.path.expanduser(pattern)
            for match in glob.glob(expanded):
                p = Path(match)
                if p.is_dir() and (p / "support" / "analyzeHeadless").exists():
                    self.ghidra_path = p
                    self._log(f"  Found Ghidra at: {p}")
                    cfg[_GHIDRA_CONFIG_KEY] = str(p)
                    _save_config(cfg)
                    return p

        # Search PATH for analyzeHeadless
        for name in ("analyzeHeadless", "analyzeHeadless.bat", "analyzeHeadless.exe"):
            found = shutil.which(name)
            if found:
                candidate = Path(found).resolve()
                for parent in candidate.parents:
                    if (parent / "support" / "analyzeHeadless").exists() or \
                       (parent / "support" / "analyzeHeadless.bat").exists():
                        self.ghidra_path = parent
                        self._log(f"  Found Ghidra at: {parent}")
                        cfg[_GHIDRA_CONFIG_KEY] = str(parent)
                        _save_config(cfg)
                        return parent

        # Not found — attempt auto-download
        self._log("  Ghidra not found locally. Attempting auto-download...")
        downloaded = self._auto_download_ghidra()
        if downloaded:
            cfg[_GHIDRA_CONFIG_KEY] = str(downloaded)
            _save_config(cfg)
            return downloaded

        self._log("  WARNING: Ghidra not found. Install from https://ghidra-sre.org/")
        return None

    def _auto_download_ghidra(self) -> Optional[Path]:
        """Download Ghidra from GitHub releases and extract to tools/ directory.

        Returns the extracted Ghidra root directory or None on failure.
        """
        try:
            self.TOOLS_DIR.mkdir(parents=True, exist_ok=True)
            zip_name = f"ghidra_{_GHIDRA_VERSION}.zip"
            zip_path = self.TOOLS_DIR / zip_name
            extract_dir = self.TOOLS_DIR

            if not zip_path.exists():
                self._log(f"  Downloading Ghidra {_GHIDRA_VERSION}...")
                self._log(f"  URL: {_GHIDRA_URL}")

                def _progress(block_num: int, block_size: int, total_size: int):
                    if total_size > 0 and block_num % 10 == 0:
                        pct = min(100.0, block_num * block_size / total_size * 100)
                        self._log(f"  Download: {pct:.0f}%")

                urllib.request.urlretrieve(_GHIDRA_URL, str(zip_path), reporthook=_progress)
                self._log(f"  Download complete: {zip_path} ({zip_path.stat().st_size} bytes)")
            else:
                self._log(f"  Using cached download: {zip_path}")

            self._log(f"  Extracting Ghidra to {extract_dir}...")
            with zipfile.ZipFile(str(zip_path), "r") as zf:
                zf.extractall(str(extract_dir))
            self._log("  Extraction complete.")

            # Find the extracted directory (usually ghidra_11.3.1_PUBLIC)
            ghidra_root = None
            for item in extract_dir.iterdir():
                if item.is_dir() and item.name.startswith("ghidra_") and "PUBLIC" in item.name:
                    ghidra_root = item
                    break

            if ghidra_root and (ghidra_root / "support" / "analyzeHeadless").exists():
                self.ghidra_path = ghidra_root
                self._log(f"  Ghidra ready at: {ghidra_root}")
                return ghidra_root

            self._log("  WARNING: Ghidra extraction succeeded but analyzeHeadless not found.")
            return None

        except Exception as exc:
            self._log(f"  ERROR downloading Ghidra: {exc}")
            # Clean up partial download
            try:
                if zip_path.exists():
                    zip_path.unlink()
            except Exception:
                pass
            return None

    def _get_analyze_headless(self) -> Optional[str]:
        """Return the full path to the analyzeHeadless script."""
        root = self.find_ghidra()
        if not root:
            return None
        for name in ("analyzeHeadless", "analyzeHeadless.bat", "analyzeHeadless.exe"):
            candidate = root / "support" / name
            if candidate.exists():
                return str(candidate)
        return None

    # -- Method map ----------------------------------------------------------

    def _load_method_map(self) -> list[dict[str, str]]:
        """Load the pipe-delimited method address map into memory."""
        if self._method_cache is not None:
            return self._method_cache

        if not self.method_address_map_path or not self.method_address_map_path.exists():
            self._log(f"  WARNING: Method address map not found: {self.method_address_map_path}")
            return []

        rows: list[dict[str, str]] = []
        try:
            with open(self.method_address_map_path, "r", encoding="utf-8", errors="replace") as f:
                for line in f:
                    line = line.rstrip("\n\r")
                    if not line or line.startswith("#") or line == _HEADER:
                        continue
                    parts = line.split("|")
                    if len(parts) >= 5:
                        rows.append({
                            "address": parts[0].strip(),
                            "dotnet_signature": parts[1].strip(),
                            "cpp_name": parts[2].strip(),
                            "namespace_class": parts[3].strip(),
                            "assembly": parts[4].strip(),
                        })
        except Exception as exc:
            self._log(f"  ERROR reading method map: {exc}")

        self._method_cache = rows
        return rows

    # -- Decompilation -------------------------------------------------------

    def decompile_method(self, method_name: str) -> dict:
        """Decompile a single method by name.

        Looks up the method in the address map, then runs Ghidra headless
        to decompile the function at that address.

        Returns a dict with keys: address, dotnet_signature, cpp_name,
        namespace_class, assembly, decompiled_c_code, error.
        """
        result = {
            "address": "",
            "dotnet_signature": method_name,
            "cpp_name": "",
            "namespace_class": "",
            "assembly": "",
            "decompiled_c_code": "",
            "error": None,
        }

        analyze_headless = self._get_analyze_headless()
        if not analyze_headless:
            result["error"] = (
                "Ghidra not found and could not be downloaded. "
                "Install Ghidra from https://ghidra-sre.org/ "
                "and set the Ghidra Path in the Code Analysis tab."
            )
            return result

        if not self.libil2cpp_path or not self.libil2cpp_path.exists():
            result["error"] = f"libil2cpp.so not found: {self.libil2cpp_path}"
            return result

        # Search for the method in the map
        rows = self._load_method_map()
        match = None
        method_lower = method_name.lower()
        for row in rows:
            if (method_lower in row["dotnet_signature"].lower() or
                method_lower in row["cpp_name"].lower() or
                method_lower in row["namespace_class"].lower()):
                match = row
                break

        if not match:
            result["error"] = f"Method '{method_name}' not found in address map."
            return result

        result.update({
            "address": match["address"],
            "dotnet_signature": match["dotnet_signature"],
            "cpp_name": match["cpp_name"],
            "namespace_class": match["namespace_class"],
            "assembly": match["assembly"],
        })

        # Run Ghidra headless decompilation
        try:
            c_code = self._run_decompile(match["address"])
            result["decompiled_c_code"] = c_code
        except Exception as exc:
            result["error"] = f"Ghidra decompilation failed: {exc}"

        return result

    def decompile_class(self, class_name: str) -> list[dict]:
        """Decompile all methods belonging to a class.

        Returns a list of dicts, one per method, each with the same
        keys as decompile_method() returns.
        """
        rows = self._load_method_map()
        class_lower = class_name.lower()
        matching = [
            row for row in rows
            if class_lower in row["namespace_class"].lower()
        ]

        if not matching:
            self._log(f"  No methods found for class '{class_name}' in address map.")
            return []

        self._log(f"  Decompiling {len(matching)} method(s) for class '{class_name}'...")
        results = []
        for i, row in enumerate(matching):
            self._log(f"    [{i+1}/{len(matching)}] {row['dotnet_signature'][:80]}")
            entry = {
                "address": row["address"],
                "dotnet_signature": row["dotnet_signature"],
                "cpp_name": row["cpp_name"],
                "namespace_class": row["namespace_class"],
                "assembly": row["assembly"],
                "decompiled_c_code": "",
                "error": None,
            }
            try:
                c_code = self._run_decompile(row["address"])
                entry["decompiled_c_code"] = c_code
            except Exception as exc:
                entry["error"] = f"Decompilation failed: {exc}"
            results.append(entry)

        return results

    def search_methods(self, query: str) -> list[dict]:
        """Search the method address map by class name, method name, or namespace.

        Returns matching entries without decompilation (metadata only).
        """
        rows = self._load_method_map()
        query_lower = query.lower()
        return [
            row for row in rows
            if (query_lower in row["dotnet_signature"].lower() or
                query_lower in row["cpp_name"].lower() or
                query_lower in row["namespace_class"].lower() or
                query_lower in row["assembly"].lower())
        ]

    def _run_decompile(self, address: str) -> str:
        """Run Ghidra headless to decompile a single function at the given address.

        Uses the DecompileSingle.java script.
        Returns the decompiled C pseudocode as a string.
        """
        analyze_headless = self._get_analyze_headless()
        if not analyze_headless:
            raise RuntimeError("Ghidra not found")

        script_path = self._script_dir / "DecompileSingle.java"
        if not script_path.exists():
            raise FileNotFoundError(
                f"Ghidra script not found: {script_path}\n"
                "Ensure ghidra_scripts/DecompileSingle.java exists."
            )

        self.output_dir.mkdir(parents=True, exist_ok=True)
        output_file = self.output_dir / f"decompiled_{address}.c"

        with tempfile.TemporaryDirectory() as tmpdir:
            project_dir = os.path.join(tmpdir, "ghidra_project")
            os.makedirs(project_dir, exist_ok=True)

            cmd = [
                analyze_headless,
                project_dir,
                "decompile_project",
                "-import", str(self.libil2cpp_path),
                "-postScript", str(script_path),
                address, str(output_file),
                "-scriptPath", str(self._script_dir),
                "-deleteProject",
            ]

            self._log(f"    Ghidra: decompiling {address}...")
            try:
                proc = subprocess.run(
                    cmd,
                    capture_output=True,
                    text=True,
                    timeout=180,
                    creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0),
                )
            except subprocess.TimeoutExpired:
                raise RuntimeError("Ghidra decompilation timed out after 180 seconds")
            except FileNotFoundError:
                raise RuntimeError(
                    f"analyzeHeadless not found at: {analyze_headless}\n"
                    "Ghidra installation may be corrupted. Re-download Ghidra."
                )

            if proc.returncode != 0:
                stderr = proc.stderr[:1000] if proc.stderr else "unknown error"
                stdout = proc.stdout[:500] if proc.stdout else ""
                raise RuntimeError(
                    f"Ghidra exited with code {proc.returncode}:\n"
                    f"stderr: {stderr}\nstdout: {stdout}"
                )

        # Read the output
        if output_file.exists():
            return output_file.read_text(encoding="utf-8", errors="replace")
        return "// Decompilation output file not created by Ghidra"
