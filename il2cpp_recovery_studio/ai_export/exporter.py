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


_DEFAULT_FRAMEWORK = "Flutter"


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

        - SCREEN_REPORT.md (with agent prompt + layout table)
        - sprites/ (copies of matching sprite PNGs)
        - strings.json
        - components.json
        - methods.json
        - {screen_name}_PREVIEW.png (visual reference)
        - {screen_name}_tokens.json (design tokens)
        - MISSING_ASSETS.md (placeholder guidance)

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

        # 5. Load UI screen JSON if available (for layout + tokens + preview)
        screen_json = self._load_screen_json(screen_name, extracted_assets_dir)
        canvas_size = screen_json.get("canvas_size", {"width": 1920, "height": 1080}) if screen_json else {"width": 1920, "height": 1080}
        element_count = len(screen_json.get("elements", [])) if screen_json else 0

        # 6. Render preview image
        if screen_json:
            self._render_preview(screen_json, screen_name, screen_dir, extracted_assets_dir)

        # 7. Extract and write design tokens
        if screen_json:
            self._write_tokens(screen_json, screen_name, screen_dir, extracted_assets_dir)

        # 8. Generate SCREEN_REPORT.md (with dynamic prompt + layout table)
        framework = self._read_framework()
        report_path = screen_dir / "SCREEN_REPORT.md"
        self._write_screen_report(
            report_path, screen_name, copied_sprites, strings, components,
            methods, screen_json, canvas_size, element_count, framework,
        )
        self._log(f"  Report written: {report_path}")

        # 9. Generate MISSING_ASSETS.md
        self._write_missing_assets(
            screen_name, screen_dir, screen_json, components,
        )

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
        screen_json: Optional[dict] = None,
        canvas_size: Optional[dict] = None,
        element_count: int = 0,
        framework: str = _DEFAULT_FRAMEWORK,
    ) -> None:
        """Write the SCREEN_REPORT.md for a single screen."""
        if canvas_size is None:
            canvas_size = {"width": 1920, "height": 1080}

        lines: list[str] = []
        lines.append(f"# Screen: {screen_name}")
        lines.append("")
        lines.append(f"*Generated: {datetime.now(timezone.utc).strftime('%Y-%m-%d %H:%M UTC')}*")
        lines.append("")
        lines.append("---")
        lines.append("")

        # Dynamic agent prompt at the top
        lines.append(self._build_agent_prompt(
            screen_name, canvas_size, framework, element_count,
        ))
        lines.append("")
        lines.append("---")
        lines.append("")

        # Layout table (framework-ready coordinates)
        if screen_json:
            layout_lines = self._build_layout_table(screen_json, canvas_size)
            lines.extend(layout_lines)
            lines.append("")
            lines.append("---")
            lines.append("")

        # Sprites
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

        # Attached files reference
        lines.append("---")
        lines.append("")
        lines.append("## Attached Files")
        lines.append("")
        lines.append(f"- `{screen_name}_PREVIEW.png` — visual reference, use it to verify your output")
        lines.append(f"- `{screen_name}_tokens.json` — all colors, font sizes, and spacing values")
        lines.append(f"- `sprites/` — all sprite PNGs referenced in this screen")
        lines.append(f"- `strings.json` — all text strings")
        lines.append(f"- `components.json` — raw Unity component data")
        lines.append(f"- `MISSING_ASSETS.md` — assets that could not be found (use placeholders)")
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

    # ── New helpers for upgraded export ────────────────────────────────

    @staticmethod
    def _build_agent_prompt(
        screen_name: str,
        canvas_size: dict,
        framework: str,
        element_count: int,
    ) -> str:
        """Build a detailed, dynamic agent instruction prompt."""
        cw = canvas_size.get("width", 1920)
        ch = canvas_size.get("height", 1080)
        return (
            f"## Agent Instructions\n"
            f"You are implementing the **{screen_name}** screen of a mobile game UI.\n"
            f"Target framework: **{framework}**\n"
            f"Canvas size: **{cw} x {ch} px**\n"
            f"Total elements to implement: **{element_count}**\n"
            f"\n"
            f"### Rules - follow all of them exactly:\n"
            f"1. Implement EVERY element listed in the Layout table below. Do not skip any.\n"
            f"2. Use the \"Left%\" and \"Top%\" columns for positioning (percentage-based layout).\n"
            f"3. Use the \"Width%\" and \"Height%\" columns for sizing.\n"
            f"4. Use ONLY the sprite files listed in `asset_manifest.sprites_used` - no placeholders.\n"
            f"5. Use ONLY the font files listed in `asset_manifest.fonts_used`.\n"
            f"6. Use the EXACT hex color codes from `design_tokens.json`.\n"
            f"7. Every Button must have a named handler stub: `on_{{button_name}}_pressed`.\n"
            f"8. Every Text element must use the EXACT string from the JSON - do not paraphrase.\n"
            f"9. Implement as a single self-contained component/widget file.\n"
            f"10. At the end of your response, list every element and confirm it was implemented.\n"
            f"\n"
            f"### Coordinate system note:\n"
            f"- All positions in the Layout table are already converted to top-left origin, Y-down.\n"
            f"- Percentages are relative to canvas size ({cw}x{ch}).\n"
            f"- Use these percentages directly in your layout (Positioned, Stack, absolute CSS, etc.)\n"
            f"\n"
            f"### Files attached to this report:\n"
            f"- `{screen_name}_PREVIEW.png` - visual reference, use it to verify your output\n"
            f"- `{screen_name}_tokens.json` - all colors, font sizes, and spacing values\n"
            f"- `sprites/` - all sprite PNGs referenced in this screen\n"
            f"- `strings.json` - all text strings\n"
            f"- `components.json` - raw Unity component data"
        )

    @staticmethod
    def _to_pixel_coords(element: dict, canvas_size: dict) -> dict:
        """Convert a single element's Unity coords to pixel layout values."""
        pos = element.get("position", {"x": 0, "y": 0})
        size = element.get("size", {"width": 0, "height": 0})
        cw = canvas_size.get("width", 1)
        ch = canvas_size.get("height", 1)

        left = cw / 2 + pos.get("x", 0) - size.get("width", 0) / 2
        top = ch / 2 - pos.get("y", 0) - size.get("height", 0) / 2
        w = size.get("width", 0)
        h = size.get("height", 0)

        return {
            "left": round(left, 1),
            "top": round(top, 1),
            "width": round(w, 1),
            "height": round(h, 1),
            "left_pct": round(left / cw * 100, 1) if cw else 0,
            "top_pct": round(top / ch * 100, 1) if ch else 0,
            "width_pct": round(w / cw * 100, 1) if cw else 0,
            "height_pct": round(h / ch * 100, 1) if ch else 0,
        }

    @classmethod
    def _build_layout_table(
        cls, screen_json: dict, canvas_size: dict
    ) -> list[str]:
        """Build the markdown layout table with framework-ready coordinates."""
        elements = screen_json.get("elements", [])
        cw = canvas_size.get("width", 0)
        ch = canvas_size.get("height", 0)

        lines: list[str] = []
        lines.append(f"## Layout (Framework-Ready Coordinates)")
        lines.append("")
        lines.append(f"Canvas: {int(cw)} x {int(ch)} px")
        lines.append("")
        lines.append(
            "| Element | Type | Left | Top | Width | Height | Left% | Top% | Width% | Height% |"
        )
        lines.append(
            "|---------|------|------|-----|-------|--------|-------|------|--------|---------|"
        )

        for el in elements:
            name = el.get("name", el.get("id", "?"))
            el_type = el.get("type", "?")
            coords = cls._to_pixel_coords(el, canvas_size)
            lines.append(
                f"| {name} | {el_type} "
                f"| {int(coords['left'])} | {int(coords['top'])} "
                f"| {int(coords['width'])} | {int(coords['height'])} "
                f"| {coords['left_pct']}% | {coords['top_pct']}% "
                f"| {coords['width_pct']}% | {coords['height_pct']}% |"
            )

        return lines

    def _load_screen_json(
        self, screen_name: str, extracted_assets_dir: Path
    ) -> Optional[dict]:
        """Try to load the UI screen JSON from UI_Screens/."""
        ui_dir = extracted_assets_dir / "UI_Screens"
        if not ui_dir.exists():
            return None
        for json_path in ui_dir.rglob(f"{screen_name}.json"):
            try:
                return json.loads(json_path.read_text(encoding="utf-8"))
            except Exception:
                pass
        return None

    def _render_preview(
        self,
        screen_json: dict,
        screen_name: str,
        screen_dir: Path,
        extracted_assets_dir: Path,
    ) -> None:
        """Render a preview PNG and save it alongside the export."""
        try:
            from il2cpp_recovery_studio.ai_export.renderer import UIPreviewRenderer
            renderer = UIPreviewRenderer(extracted_assets_dir, self._log)
            preview_path = screen_dir / f"{screen_name}_PREVIEW.png"
            renderer.render_screen(screen_json, preview_path)
        except Exception as exc:
            self._log(f"  [Preview] Render failed: {exc}")

    def _write_tokens(
        self,
        screen_json: dict,
        screen_name: str,
        screen_dir: Path,
        extracted_assets_dir: Path,
    ) -> None:
        """Extract design tokens and write them to the export folder."""
        try:
            from il2cpp_recovery_studio.ai_export.token_extractor import (
                DesignTokenExtractor,
            )
            extractor = DesignTokenExtractor(extracted_assets_dir)
            tokens = extractor.extract_for_screen(screen_json)
            tokens_path = screen_dir / f"{screen_name}_tokens.json"
            tokens_path.write_text(
                json.dumps(tokens, indent=2, ensure_ascii=False),
                encoding="utf-8",
            )
            self._log(f"  Tokens written: {tokens_path.name}")
        except Exception as exc:
            self._log(f"  [Tokens] Extraction failed: {exc}")

    def _write_missing_assets(
        self,
        screen_name: str,
        screen_dir: Path,
        screen_json: Optional[dict],
        components: list[dict],
    ) -> None:
        """Generate MISSING_ASSETS.md for assets that could not be found."""
        missing_sprites: list[tuple[str, str]] = []
        missing_fonts: list[tuple[str, str]] = []

        # Scan screen_json elements
        if screen_json:
            for el in screen_json.get("elements", []):
                el_name = el.get("name", el.get("id", "?"))
                sprite = el.get("sprite_file", "") or el.get("sprite_name", "")
                if sprite and (sprite.startswith("MISSING:") or not Path(sprite).is_file()):
                    missing_sprites.append((sprite, el_name))
                for fkey in ("font_file", "label_font_file"):
                    ff = el.get(fkey, "")
                    if ff and (ff.startswith("MISSING:") or not Path(ff).is_file()):
                        missing_fonts.append((ff, el_name))

        # Also scan components for sprite references
        for comp in components:
            comp_name = comp.get("name", comp.get("script_name", "?"))
            sprite = comp.get("sprite_name", "")
            if sprite and (sprite.startswith("MISSING:") or not Path(sprite).is_file()):
                entry = (sprite, comp_name)
                if entry not in missing_sprites:
                    missing_sprites.append(entry)

        if not missing_sprites and not missing_fonts:
            return

        lines: list[str] = []
        lines.append(f"# Missing Assets - {screen_name}")
        lines.append("")
        lines.append(
            "The following assets were referenced in the UI hierarchy but could not be found "
            "in the extracted output. The agent should use a placeholder color for these."
        )
        lines.append("")

        if missing_sprites:
            lines.append("## Missing Sprites")
            lines.append("")
            for path, el_name in missing_sprites:
                lines.append(f"- `{path}`  <- referenced by element \"{el_name}\"")
            lines.append("")

        if missing_fonts:
            lines.append("## Missing Fonts")
            lines.append("")
            for path, el_name in missing_fonts:
                lines.append(f"- `{path}`  <- used by element \"{el_name}\"")
            lines.append("")

        missing_path = screen_dir / "MISSING_ASSETS.md"
        missing_path.write_text("\n".join(lines), encoding="utf-8")
        self._log(f"  Missing assets report: {missing_path.name}")

    def _read_framework(self) -> str:
        """Read the AI export framework from .gui_config.json."""
        config_path = (
            Path(__file__).resolve().parent.parent.parent / ".gui_config.json"
        )
        if config_path.exists():
            try:
                cfg = json.loads(config_path.read_text(encoding="utf-8"))
                fw = cfg.get("ai_export_framework", "")
                if fw:
                    return fw
            except Exception:
                pass
        return _DEFAULT_FRAMEWORK
