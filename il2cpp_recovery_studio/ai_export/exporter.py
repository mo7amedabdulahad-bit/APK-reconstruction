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
    """Export extracted Unity assets into AI-agent-ready bundles."""

    def __init__(self, log_callback: Optional[Callable[[str], None]] = None) -> None:
        self._log = log_callback or (lambda m: print(m))

    def export_screen(
        self,
        screen_name: str,
        extracted_assets_dir: Path,
        method_address_map: Optional[Path],
        output_dir: Path,
    ) -> Path:
        extracted_assets_dir = Path(extracted_assets_dir)
        output_dir = Path(output_dir)
        screen_dir = output_dir / screen_name
        screen_dir.mkdir(parents=True, exist_ok=True)
        sprites_dir = screen_dir / "sprites"
        sprites_dir.mkdir(exist_ok=True)

        self._log(f"[AI Export] Exporting screen: {screen_name}")

        sprites = self._find_sprites(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(sprites)} matching sprite(s)")
        copied_sprites = []
        for sprite_path in sprites:
            dest = sprites_dir / sprite_path.name
            if not dest.exists():
                shutil.copy2(str(sprite_path), str(dest))
            copied_sprites.append(str(Path(screen_name) / "sprites" / sprite_path.name))

        strings = self._find_strings(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(strings)} matching localization string(s)")
        strings_path = screen_dir / "strings.json"
        strings_path.write_text(json.dumps(strings, indent=2, ensure_ascii=False), encoding="utf-8")

        components = self._find_components(screen_name, extracted_assets_dir)
        self._log(f"  Found {len(components)} matching component(s)")
        components_path = screen_dir / "components.json"
        components_path.write_text(json.dumps(components, indent=2, ensure_ascii=False), encoding="utf-8")

        methods = self._find_methods(screen_name, method_address_map)
        self._log(f"  Found {len(methods)} matching method(s)")
        methods_path = screen_dir / "methods.json"
        methods_path.write_text(json.dumps(methods, indent=2, ensure_ascii=False), encoding="utf-8")

        screen_json = self._load_screen_json(screen_name, extracted_assets_dir)
        canvas_size = screen_json.get("canvas_size", {"width": 1920, "height": 1080}) if screen_json else {"width": 1920, "height": 1080}
        element_count = len(screen_json.get("elements", [])) if screen_json else 0

        if screen_json:
            self._render_preview(screen_json, screen_name, screen_dir, extracted_assets_dir)

        if screen_json:
            self._write_tokens(screen_json, screen_name, screen_dir, extracted_assets_dir)

        framework = self._read_framework()
        report_path = screen_dir / "SCREEN_REPORT.md"
        self._write_screen_report(
            report_path, screen_name, copied_sprites, strings, components,
            methods, screen_json, canvas_size, element_count, framework,
        )
        self._log(f"  Report written: {report_path}")

        # FIX (Issue B): pass extracted_assets_dir so relative paths resolve correctly
        self._write_missing_assets(screen_name, screen_dir, screen_json, components, extracted_assets_dir)

        return screen_dir

    def export_full_project(
        self,
        extracted_assets_dir: Path,
        method_address_map: Optional[Path],
        output_dir: Path,
    ) -> Path:
        extracted_assets_dir = Path(extracted_assets_dir)
        output_dir = Path(output_dir)
        output_dir.mkdir(parents=True, exist_ok=True)

        self._log("[AI Export] Starting full project export...")
        screen_names = self._discover_screens(extracted_assets_dir)
        self._log(f"  Discovered {len(screen_names)} screen/feature group(s)")

        index_entries: list[dict] = []
        for i, screen_name in enumerate(screen_names):
            self._log(f"  [{i+1}/{len(screen_names)}] Exporting: {screen_name}")
            screen_dir = self.export_screen(screen_name, extracted_assets_dir, method_address_map, output_dir)
            file_count = sum(1 for _ in screen_dir.rglob("*") if _.is_file())
            index_entries.append({"name": screen_name, "path": str(screen_name), "files": file_count})

        index_path = output_dir / "INDEX.md"
        self._write_index(index_path, index_entries)
        self._log(f"  INDEX.md written: {index_path}")
        self._log(f"[AI Export] Full project export complete: {output_dir}")
        return output_dir

    def export_ghidra_analysis(self, ghidra_results: list[dict], screen_name: str, output_dir: Path) -> Path:
        output_dir = Path(output_dir)
        screen_dir = output_dir / screen_name
        report_path = screen_dir / "SCREEN_REPORT.md"

        if not report_path.exists():
            report_path.parent.mkdir(parents=True, exist_ok=True)
            report_path.write_text(f"# {screen_name}\n\n*Generated from Ghidra analysis*\n", encoding="utf-8")

        existing = report_path.read_text(encoding="utf-8")
        lines: list[str] = []
        if "## Native Code Analysis (Ghidra ARM64 Pseudocode)" not in existing:
            lines += ["", "---", "", "## Native Code Analysis (Ghidra ARM64 Pseudocode)", ""]
            lines.append("> The following C pseudocode was generated by Ghidra's headless decompiler.")
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
                lines += ["```c", c_code.strip(), "```", ""]

        content = existing.rstrip() + "\n" + "\n".join(lines)
        report_path.write_text(content, encoding="utf-8")
        self._log(f"  Ghidra analysis appended to: {report_path}")
        return report_path

    # ── Internal search helpers ────────────────────────────────────────

    def _find_sprites(self, name: str, assets_dir: Path) -> list[Path]:
        results: list[Path] = []
        name_lower = name.lower()
        for subdir in ("Sprites", "Images", "SpriteAtlases", "Prefabs"):
            search_dir = assets_dir / subdir
            if not search_dir.exists():
                continue
            for png in search_dir.rglob("*.png"):
                if name_lower in png.stem.lower() or name_lower in str(png.parent).lower():
                    results.append(png)
        return results

    def _find_strings(self, name: str, assets_dir: Path) -> dict[str, str]:
        results: dict[str, str] = {}
        name_lower = name.lower()
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
        results: list[dict] = []
        name_lower = name.lower()
        for search_dir, key in ((assets_dir / "MonoBehaviours", "script_name"), (assets_dir / "Prefabs", "name")):
            if not search_dir.exists():
                continue
            for json_file in search_dir.rglob("*.json"):
                try:
                    data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                    if isinstance(data, dict):
                        if name_lower in str(data.get("name", "")).lower() or name_lower in str(data.get(key, "")).lower():
                            data["_source_file"] = str(json_file.relative_to(assets_dir))
                            results.append(data)
                except (json.JSONDecodeError, UnicodeDecodeError):
                    pass
        return results

    def _find_methods(self, name: str, method_address_map: Optional[Path]) -> list[dict]:
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
                        if name_lower in " ".join(row.values()).lower():
                            results.append(row)
        except Exception:
            pass
        return results

    def _discover_screens(self, assets_dir: Path) -> list[str]:
        screens: set[str] = set()
        for subdir in ("MonoBehaviours", "Sprites", "Prefabs"):
            d = assets_dir / subdir
            if d.exists():
                for fd in d.iterdir():
                    if fd.is_dir():
                        screens.add(fd.name)
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
        if canvas_size is None:
            canvas_size = {"width": 1920, "height": 1080}
        lines: list[str] = []
        lines += [f"# Screen: {screen_name}", "",
                  f"*Generated: {datetime.now(timezone.utc).strftime('%Y-%m-%d %H:%M UTC')}*",
                  "", "---", ""]
        lines.append(self._build_agent_prompt(screen_name, canvas_size, framework, element_count))
        lines += ["", "---", ""]
        if screen_json:
            lines.extend(self._build_layout_table(screen_json, canvas_size))
            lines += ["", "---", ""]
        lines += ["## Sprites", ""]
        lines += ([f"- `{sp}`" for sp in sprite_paths] if sprite_paths else ["*No matching sprites found.*"])
        lines += ["", "## Localization Strings", ""]
        lines += ([f"- **{k}**: {v}" for k, v in strings.items()] if strings else ["*No matching strings found.*"])
        lines += ["", "## MonoBehaviour / Component Data", ""]
        if components:
            for comp in components:
                cn = comp.get("name", comp.get("script_name", "unknown"))
                lines += [f"### `{cn}`", "", "```json", json.dumps(comp, indent=2, ensure_ascii=False), "```", ""]
        else:
            lines.append("*No matching components found.*")
        lines += ["", "## IL2CPP Method Signatures", ""]
        if methods:
            for m in methods:
                lines.append(f"- `{m.get('dotnet_signature','unknown')}` (address: `0x{m.get('address','0')}`, assembly: {m.get('assembly','unknown')})")
        else:
            lines.append("*No matching methods found.*")
        lines += ["", "---", "", "## Attached Files", ""]
        lines += [
            f"- `{screen_name}_PREVIEW.png` — visual reference",
            f"- `{screen_name}_tokens.json` — all colors, font sizes, and spacing",
            f"- `sprites/` — all sprite PNGs",
            f"- `strings.json` — all text strings",
            f"- `components.json` — raw Unity component data",
            f"- `MISSING_ASSETS.md` — assets that could not be found",
            "",
        ]
        report_path.write_text("\n".join(lines), encoding="utf-8")

    def _write_index(self, index_path: Path, entries: list[dict]) -> None:
        lines = ["# AI Export — Full Project Index", "",
                 f"*Generated: {datetime.now(timezone.utc).strftime('%Y-%m-%d %H:%M UTC')}*", "",
                 f"Total screens/features: **{len(entries)}**", "",
                 "| Screen | Path | Files |", "|--------|------|-------|"]
        for e in entries:
            lines.append(f"| {e['name']} | `{e['path']}` | {e['files']} |")
        lines += ["", "---", "", "Each screen folder contains:",
                  "- `SCREEN_REPORT.md`", "- `sprites/`", "- `strings.json`",
                  "- `components.json`", "- `methods.json`", ""]
        index_path.write_text("\n".join(lines), encoding="utf-8")

    # ── New helpers for upgraded export ────────────────────────────────

    @staticmethod
    def _build_agent_prompt(screen_name: str, canvas_size: dict, framework: str, element_count: int) -> str:
        cw = canvas_size.get("width", 1920)
        ch = canvas_size.get("height", 1080)
        return (
            f"## Agent Instructions\n"
            f"You are implementing the **{screen_name}** screen of a mobile game UI.\n"
            f"Target framework: **{framework}**\n"
            f"Canvas size: **{cw} x {ch} px**\n"
            f"Total elements to implement: **{element_count}**\n\n"
            f"### Rules — follow all of them exactly:\n"
            f"1. Implement EVERY element listed in the Layout table below. Do not skip any.\n"
            f"2. Use the \"Left%\" and \"Top%\" columns for positioning (percentage-based layout).\n"
            f"3. Use the \"Width%\" and \"Height%\" columns for sizing.\n"
            f"4. Use ONLY the sprite files listed in `asset_manifest.sprites_used` — no placeholders.\n"
            f"5. Use ONLY the font files listed in `asset_manifest.fonts_used`.\n"
            f"6. Use the EXACT hex color codes from `design_tokens.json`.\n"
            f"7. Every Button must have a named handler stub: `on_{{button_name}}_pressed`.\n"
            f"8. Every Text element must use the EXACT string from the JSON — do not paraphrase.\n"
            f"9. Implement as a single self-contained component/widget file.\n"
            f"10. At the end of your response, list every element and confirm it was implemented.\n\n"
            f"### Coordinate system note:\n"
            f"All positions are top-left origin, Y-down. Percentages are relative to canvas ({cw}x{ch}).\n\n"
            f"### Files attached:\n"
            f"- `{screen_name}_PREVIEW.png` — visual reference\n"
            f"- `{screen_name}_tokens.json` — colors, fonts, spacing\n"
            f"- `sprites/` — sprite PNGs\n"
            f"- `strings.json` — text strings\n"
            f"- `components.json` — raw Unity component data"
        )

    @staticmethod
    def _to_pixel_coords(element: dict, canvas_size: dict) -> dict:
        pos = element.get("position", {"x": 0, "y": 0})
        size = element.get("size", {"width": 0, "height": 0})
        cw = canvas_size.get("width", 1)
        ch = canvas_size.get("height", 1)
        left = cw / 2 + pos.get("x", 0) - size.get("width", 0) / 2
        top = ch / 2 - pos.get("y", 0) - size.get("height", 0) / 2
        w = size.get("width", 0)
        h = size.get("height", 0)
        return {
            "left": round(left, 1), "top": round(top, 1),
            "width": round(w, 1), "height": round(h, 1),
            "left_pct": round(left / cw * 100, 1) if cw else 0,
            "top_pct": round(top / ch * 100, 1) if ch else 0,
            "width_pct": round(w / cw * 100, 1) if cw else 0,
            "height_pct": round(h / ch * 100, 1) if ch else 0,
        }

    @classmethod
    def _build_layout_table(cls, screen_json: dict, canvas_size: dict) -> list[str]:
        elements = screen_json.get("elements", [])
        cw = canvas_size.get("width", 0)
        ch = canvas_size.get("height", 0)
        lines = [f"## Layout (Framework-Ready Coordinates)", "", f"Canvas: {int(cw)} x {int(ch)} px", "",
                 "| Element | Type | Left | Top | Width | Height | Left% | Top% | Width% | Height% |",
                 "|---------|------|------|-----|-------|--------|-------|------|--------|---------|"]
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

    def _load_screen_json(self, screen_name: str, extracted_assets_dir: Path) -> Optional[dict]:
        ui_dir = extracted_assets_dir / "UI_Screens"
        if not ui_dir.exists():
            return None
        for json_path in ui_dir.rglob(f"{screen_name}.json"):
            try:
                return json.loads(json_path.read_text(encoding="utf-8"))
            except Exception:
                pass
        return None

    def _render_preview(self, screen_json: dict, screen_name: str, screen_dir: Path, extracted_assets_dir: Path) -> None:
        try:
            from il2cpp_recovery_studio.ai_export.renderer import UIPreviewRenderer
            renderer = UIPreviewRenderer(extracted_assets_dir, self._log)
            preview_path = screen_dir / f"{screen_name}_PREVIEW.png"
            renderer.render_screen(screen_json, preview_path)
        except Exception as exc:
            self._log(f"  [Preview] Render failed: {exc}")

    def _write_tokens(self, screen_json: dict, screen_name: str, screen_dir: Path, extracted_assets_dir: Path) -> None:
        try:
            from il2cpp_recovery_studio.ai_export.token_extractor import DesignTokenExtractor
            extractor = DesignTokenExtractor(extracted_assets_dir)
            tokens = extractor.extract_for_screen(screen_json)
            tokens_path = screen_dir / f"{screen_name}_tokens.json"
            tokens_path.write_text(json.dumps(tokens, indent=2, ensure_ascii=False), encoding="utf-8")
            self._log(f"  Tokens written: {tokens_path.name}")
        except Exception as exc:
            self._log(f"  [Tokens] Extraction failed: {exc}")

    def _write_missing_assets(
        self,
        screen_name: str,
        screen_dir: Path,
        screen_json: Optional[dict],
        components: list[dict],
        extracted_assets_dir: Path,  # FIX: needed to resolve relative paths
    ) -> None:
        missing_sprites: list[tuple[str, str]] = []
        missing_fonts: list[tuple[str, str]] = []

        if screen_json:
            for el in screen_json.get("elements", []):
                el_name = el.get("name", el.get("id", "?"))
                sprite = el.get("sprite_file", "") or el.get("sprite_name", "")
                if sprite:
                    # FIX (Issue B): resolve against extracted_assets_dir, not cwd
                    full = extracted_assets_dir / sprite if not Path(sprite).is_absolute() else Path(sprite)
                    if sprite.startswith("MISSING:") or not full.is_file():
                        missing_sprites.append((sprite, el_name))
                for fkey in ("font_file", "label_font_file"):
                    ff = el.get(fkey, "")
                    if ff:
                        full_f = extracted_assets_dir / ff if not Path(ff).is_absolute() else Path(ff)
                        if ff.startswith("MISSING:") or not full_f.is_file():
                            missing_fonts.append((ff, el_name))

        for comp in components:
            comp_name = comp.get("name", comp.get("script_name", "?"))
            sprite = comp.get("sprite_name", "")
            if sprite:
                full = extracted_assets_dir / sprite if not Path(sprite).is_absolute() else Path(sprite)
                if sprite.startswith("MISSING:") or not full.is_file():
                    entry = (sprite, comp_name)
                    if entry not in missing_sprites:
                        missing_sprites.append(entry)

        if not missing_sprites and not missing_fonts:
            return

        lines = [f"# Missing Assets - {screen_name}", "",
                 "The following assets were referenced but could not be found. Use placeholder colors.", ""]
        if missing_sprites:
            lines += ["## Missing Sprites", ""]
            lines += [f"- `{p}`  <- referenced by \"{n}\"" for p, n in missing_sprites]
            lines.append("")
        if missing_fonts:
            lines += ["## Missing Fonts", ""]
            lines += [f"- `{p}`  <- used by \"{n}\"" for p, n in missing_fonts]
            lines.append("")

        missing_path = screen_dir / "MISSING_ASSETS.md"
        missing_path.write_text("\n".join(lines), encoding="utf-8")
        self._log(f"  Missing assets report: {missing_path.name}")

    def _read_framework(self) -> str:
        config_path = Path(__file__).resolve().parent.parent.parent / ".gui_config.json"
        if config_path.exists():
            try:
                cfg = json.loads(config_path.read_text(encoding="utf-8"))
                fw = cfg.get("ai_export_framework", "")
                if fw:
                    return fw
            except Exception:
                pass
        return _DEFAULT_FRAMEWORK
