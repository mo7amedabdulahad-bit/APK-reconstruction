"""AI Exporter — generates AI-readable reports from extracted Unity assets.

Exports screen-specific or full-project data bundles optimized for
feeding directly to an AI agent (Claude, Gemini, etc.) for UI reconstruction.
"""
from __future__ import annotations

import json
import os
import shutil
from datetime import datetime, timezone
from pathlib import Path
from typing import Callable, Optional


_INSTRUCTIONS = (
    "You are receiving a complete dump of a Unity game screen. "
    "Use the sprites, strings, component data, and method signatures below "
    "to reconstruct this UI screen in [TARGET_FRAMEWORK]. "
    "Maintain exact layout, colors, text, and button placement as described."
)


class AIExporter:
    """Export extracted Unity assets into AI-agent-ready bundles.

    Parameters
    ----------
    log_callback:
        Optional callable for progress logging.
    """

    def __init__(self, log_callback: Optional[Callable[[str], None]] = None) -> None:
        self._log = log_callback or (lambda m: print(m))

    def export_screen(
        self,
        screen_name: str,
        extracted_assets_dir: Path,
        method_address_map: Optional[Path],
        output_dir: Path,
    ) -> Path:
        """Export data for a single screen/feature to an AI-ready bundle.

        Searches extracted assets and method maps for anything matching
        screen_name (case-insensitive) and produces a folder containing:

        - SCREEN_REPORT.md
        - sprites/ (copies of matching sprite PNGs)
        - strings.json
        - components.json
        - methods.json

        Returns the path to the screen output directory.
        """
        extracted_assets_dir = Path(extracted_assets_dir)
        output_dir = Path(output_dir)
        screen_dir = output_dir / screen_name
        screen_dir.mkdir(parents=True, exist_ok=True)
        sprites_dir = screen_dir / "sprites"
        sprites_dir.mkdir(exist_ok=True)

        self._log(f"[AI Export] Exporting screen: {screen_name}")

        # 1. Find matching sprites
        sprites = self._find_sprites(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(sprites)} matching sprite(s)")
        copied_sprites = []
        for sprite_path in sprites:
            dest = sprites_dir / sprite_path.name
            if not dest.exists():
                shutil.copy2(str(sprite_path), str(dest))
            copied_sprites.append(str(Path(screen_name) / "sprites" / sprite_path.name))

        # 2. Find matching localization strings
        strings = self._find_strings(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(strings)} matching localization string(s)")
        strings_path = screen_dir / "strings.json"
        strings_path.write_text(
            json.dumps(strings, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )

        # 3. Find matching MonoBehaviour / component data
        components = self._find_components(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(components)} matching component(s)")
        components_path = screen_dir / "components.json"
        components_path.write_text(
            json.dumps(components, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )

        # 4. Find matching methods
        methods = self._find_methods(screen_name, method_address_map)
        self._log(f"  Found {len(methods)} matching method(s)")
        methods_path = screen_dir / "methods.json"
        methods_path.write_text(
            json.dumps(methods, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )

        # 5. Generate SCREEN_REPORT.md
        report_path = screen_dir / "SCREEN_REPORT.md"
        self._write_screen_report(
            report_path, screen_name, copied_sprites, strings, components, methods
        )
        self._log(f"  Report written: {report_path}")

        return screen_dir

    def export_full_project(
        self,
        extracted_assets_dir: Path,
        method_address_map: Optional[Path],
        output_dir: Path,
    ) -> Path:
        """Export the entire extracted project organized by namespace/screen.

        Produces an INDEX.md at the root listing all screens and their file counts.

        Returns the path to the output directory.
        """
        extracted_assets_dir = Path(extracted_assets_dir)
        output_dir = Path(output_dir)
        output_dir.mkdir(parents=True, exist_ok=True)

        self._log("[AI Export] Starting full project export...")

        # Discover all screen names from the asset directory structure
        screen_names = self._discover_screens(extracted_assets_dir)
        self._log(f"  Discovered {len(screen_names)} screen/feature group(s)")

        index_entries: list[dict] = []
        for i, screen_name in enumerate(screen_names):
            self._log(f"  [{i+1}/{len(screen_names)}] Exporting: {screen_name}")
            screen_dir = self.export_screen(
                screen_name, extracted_assets_dir, method_address_map, output_dir
            )
            file_count = sum(1 for _ in screen_dir.rglob("*") if _.is_file())
            index_entries.append({
                "name": screen_name,
                "path": str(screen_name),
                "files": file_count,
            })

        # Generate INDEX.md
        index_path = output_dir / "INDEX.md"
        self._write_index(index_path, index_entries)
        self._log(f"  INDEX.md written: {index_path}")
        self._log(f"[AI Export] Full project export complete: {output_dir}")

        return output_dir

    def export_ghidra_analysis(
        self,
        ghidra_results: list[dict],
        screen_name: str,
        output_dir: Path,
    ) -> Path:
        """Append Ghidra decompilation results to a screen's SCREEN_REPORT.md.

        Adds a section "## Native Code Analysis (Ghidra ARM64 Pseudocode)"
        with each method formatted as a code block.
        """
        output_dir = Path(output_dir)
        screen_dir = output_dir / screen_name
        report_path = screen_dir / "SCREEN_REPORT.md"

        if not report_path.exists():
            # Create a minimal report first
            report_path.parent.mkdir(parents=True, exist_ok=True)
            report_path.write_text(
                f"# {screen_name}\n\n*Generated from Ghidra analysis*\n",
                encoding="utf-8",
            )

        existing = report_path.read_text(encoding="utf-8")

        lines: list[str] = []
        if "## Native Code Analysis (Ghidra ARM64 Pseudocode)" not in existing:
            lines.append("")
            lines.append("---")
            lines.append("")
            lines.append("## Native Code Analysis (Ghidra ARM64 Pseudocode)")
            lines.append("")
            lines.append("> The following C pseudocode was generated by Ghidra's headless decompiler "
                         "analyzing the compiled ARM64 native library. Use it to understand the "
                         "runtime behavior of each method.")
            lines.append("")

        for method in ghidra_results:
            sig = method.get("dotnet_signature", "unknown")
            address = method.get("address", "0")
            c_code = method.get("decompiled_c_code", "")
            error = method.get("error")

            lines.append(f"### `{sig}`")
            lines.append("")
            lines.append(f"- **Address:** `0x{address}`")
            lines.append("")

            if error:
                lines.append(f"**Error:** {error}")
                lines.append("")
            elif c_code:
                lines.append("```c")
                lines.append(c_code.strip())
                lines.append("```")
                lines.append("")

        content = existing.rstrip() + "\n" + "\n".join(lines)
        report_path.write_text(content, encoding="utf-8")
        self._log(f"  Ghidra analysis appended to: {report_path}")
        return report_path

    # ── Internal search helpers ────────────────────────────────────────

    def _find_sprites(self, name: str, assets_dir: Path) -> list[Path]:
        """Find sprite PNGs matching the given name."""
        results: list[Path] = []
        name_lower = name.lower()

        # Search common sprite directories
        for subdir in ("Sprites", "Images", "SpriteAtlases", "Prefabs"):
            search_dir = assets_dir / subdir
            if not search_dir.exists():
                continue
            for png in search_dir.rglob("*.png"):
                if name_lower in png.stem.lower() or name_lower in str(png.parent).lower():
                    results.append(png)

        return results

    def _find_strings(self, name: str, assets_dir: Path) -> dict[str, str]:
        """Find localization strings matching the given name."""
        results: dict[str, str] = {}
        name_lower = name.lower()

        # Search localization and text directories
        for subdir in ("localization", "Data", "Config", "Scripts"):
            search_dir = assets_dir / subdir
            if not search_dir.exists():
                continue
            for json_file in search_dir.rglob("*.json"):
                try:
                    data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                    if isinstance(data, dict):
                        for key, value in data.items():
                            if name_lower in str(key).lower() or name_lower in str(value).lower():
                                results[str(key)] = str(value)
                    elif isinstance(data, list):
                        for item in data:
                            if isinstance(item, dict):
                                for key, value in item.items():
                                    if name_lower in str(key).lower() or name_lower in str(value).lower():
                                        results[str(key)] = str(value)
                except (json.JSONDecodeError, UnicodeDecodeError):
                    pass

        # Also search .txt files
        for subdir in ("localization", "Data"):
            search_dir = assets_dir / subdir
            if not search_dir.exists():
                continue
            for txt_file in search_dir.rglob("*.txt"):
                try:
                    content = txt_file.read_text(encoding="utf-8", errors="replace")
                    for line in content.splitlines():
                        if name_lower in line.lower():
                            results[line.strip()[:100]] = str(txt_file.relative_to(assets_dir))
                except UnicodeDecodeError:
                    pass

        return results

    def _find_components(self, name: str, assets_dir: Path) -> list[dict]:
        """Find MonoBehaviour / component data matching the given name."""
        results: list[dict] = []
        name_lower = name.lower()

        # Search MonoBehaviours directory
        mono_dir = assets_dir / "MonoBehaviours"
        if mono_dir.exists():
            for json_file in mono_dir.rglob("*.json"):
                try:
                    data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                    if isinstance(data, dict):
                        name_val = str(data.get("name", "")).lower()
                        script_val = str(data.get("script_name", "")).lower()
                        if name_lower in name_val or name_lower in script_val:
                            data["_source_file"] = str(json_file.relative_to(assets_dir))
                            results.append(data)
                except (json.JSONDecodeError, UnicodeDecodeError):
                    pass

        # Also search Prefabs
        prefab_dir = assets_dir / "Prefabs"
        if prefab_dir.exists():
            for json_file in prefab_dir.rglob("*.json"):
                try:
                    data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                    if isinstance(data, dict):
                        name_val = str(data.get("name", "")).lower()
                        if name_lower in name_val:
                            data["_source_file"] = str(json_file.relative_to(assets_dir))
                            results.append(data)
                except (json.JSONDecodeError, UnicodeDecodeError):
                    pass

        return results

    def _find_methods(
        self, name: str, method_address_map: Optional[Path]
    ) -> list[dict]:
        """Find IL2CPP method signatures matching the given name."""
        results: list[dict] = []
        if not method_address_map or not method_address_map.exists():
            return results

        name_lower = name.lower()
        header = "address|dotnet_signature|cpp_name|namespace_class|assembly"

        try:
            with open(method_address_map, "r", encoding="utf-8", errors="replace") as f:
                for line in f:
                    line = line.rstrip("\n\r")
                    if not line or line.startswith("#") or line == header:
                        continue
                    parts = line.split("|")
                    if len(parts) >= 5:
                        row = {
                            "address": parts[0].strip(),
                            "dotnet_signature": parts[1].strip(),
                            "cpp_name": parts[2].strip(),
                            "namespace_class": parts[3].strip(),
                            "assembly": parts[4].strip(),
                        }
                        searchable = " ".join(row.values()).lower()
                        if name_lower in searchable:
                            results.append(row)
        except Exception:
            pass

        return results

    def _discover_screens(self, assets_dir: Path) -> list[str]:
        """Discover screen/feature names from the asset directory structure."""
        screens: set[str] = set()

        # From MonoBehaviours — group by faction/category
        mono_dir = assets_dir / "MonoBehaviours"
        if mono_dir.exists():
            for faction_dir in mono_dir.iterdir():
                if faction_dir.is_dir():
                    screens.add(faction_dir.name)

        # From Sprites — group by faction
        sprite_dir = assets_dir / "Sprites"
        if sprite_dir.exists():
            for faction_dir in sprite_dir.iterdir():
                if faction_dir.is_dir():
                    screens.add(faction_dir.name)

        # From Prefabs — group by faction
        prefab_dir = assets_dir / "Prefabs"
        if prefab_dir.exists():
            for faction_dir in prefab_dir.iterdir():
                if faction_dir.is_dir():
                    screens.add(faction_dir.name)

        # From Data directories — use folder names
        data_dir = assets_dir / "Data"
        if data_dir.exists():
            for item in data_dir.iterdir():
                if item.is_dir():
                    screens.add(item.name)

        return sorted(screens) if screens else ["default"]

    # ── Report writers ─────────────────────────────────────────────────

    def _write_screen_report(
        self,
        report_path: Path,
        screen_name: str,
        sprite_paths: list[str],
        strings: dict[str, str],
        components: list[dict],
        methods: list[dict],
    ) -> None:
        """Write the SCREEN_REPORT.md for a single screen."""
        lines: list[str] = []
        lines.append(f"# Screen: {screen_name}")
        lines.append("")
        lines.append(f"*Generated: {datetime.now(timezone.utc).strftime('%Y-%m-%d %H:%M UTC')}*")
        lines.append("")
        lines.append("---")
        lines.append("")
        lines.append("## Instructions for AI Agent")
        lines.append("")
        lines.append(_INSTRUCTIONS)
        lines.append("")

        # Sprites
        lines.append("---")
        lines.append("")
        lines.append("## Sprites")
        lines.append("")
        if sprite_paths:
            for sp in sprite_paths:
                lines.append(f"- `{sp}`")
        else:
            lines.append("*No matching sprites found.*")
        lines.append("")

        # Strings
        lines.append("## Localization Strings")
        lines.append("")
        if strings:
            for key, value in strings.items():
                lines.append(f"- **{key}**: {value}")
        else:
            lines.append("*No matching strings found.*")
        lines.append("")

        # Components
        lines.append("## MonoBehaviour / Component Data")
        lines.append("")
        if components:
            for comp in components:
                comp_name = comp.get("name", comp.get("script_name", "unknown"))
                lines.append(f"### `{comp_name}`")
                lines.append("")
                lines.append("```json")
                lines.append(json.dumps(comp, indent=2, ensure_ascii=False))
                lines.append("```")
                lines.append("")
        else:
            lines.append("*No matching components found.*")
        lines.append("")

        # Methods
        lines.append("## IL2CPP Method Signatures")
        lines.append("")
        if methods:
            for m in methods:
                lines.append(f"- `{m.get('dotnet_signature', 'unknown')}` "
                             f"(address: `0x{m.get('address', '0')}`, "
                             f"assembly: {m.get('assembly', 'unknown')})")
        else:
            lines.append("*No matching methods found.*")
        lines.append("")

        report_path.write_text("\n".join(lines), encoding="utf-8")

    def _write_index(self, index_path: Path, entries: list[dict]) -> None:
        """Write the INDEX.md for a full project export."""
        lines: list[str] = []
        lines.append("# AI Export — Full Project Index")
        lines.append("")
        lines.append(f"*Generated: {datetime.now(timezone.utc).strftime('%Y-%m-%d %H:%M UTC')}*")
        lines.append("")
        lines.append(f"Total screens/features: **{len(entries)}**")
        lines.append("")
        lines.append("| Screen | Path | Files |")
        lines.append("|--------|------|-------|")
        for entry in entries:
            lines.append(f"| {entry['name']} | `{entry['path']}` | {entry['files']} |")
        lines.append("")
        lines.append("---")
        lines.append("")
        lines.append("Each screen folder contains:")
        lines.append("- `SCREEN_REPORT.md` — AI-readable report with instructions")
        lines.append("- `sprites/` — Matching sprite PNGs")
        lines.append("- `strings.json` — Localization strings")
        lines.append("- `components.json` — MonoBehaviour data")
        lines.append("- `methods.json` — IL2CPP method signatures")
        lines.append("")

        index_path.write_text("\n".join(lines), encoding="utf-8")
