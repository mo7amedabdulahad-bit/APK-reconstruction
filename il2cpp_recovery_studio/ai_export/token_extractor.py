"""Extract design tokens from a UI screen-spec JSON."""
from __future__ import annotations

from collections import defaultdict
from pathlib import Path


class DesignTokenExtractor:
    """Produce a design_tokens dict from a UI screen-spec JSON."""

    def __init__(self, assets_dir: Path) -> None:
        self._assets_dir = Path(assets_dir)

    def extract_for_screen(self, screen_json: dict) -> dict:
        """Return a design tokens dict for the given screen."""
        elements = screen_json.get("elements", [])
        canvas_size = screen_json.get("canvas_size", {"width": 0, "height": 0})

        colors: dict[str, list[str]] = defaultdict(list)
        font_sizes: dict[str, list[str]] = defaultdict(list)
        font_files: dict[str, list[str]] = defaultdict(list)
        image_sizes: dict[str, dict] = {}

        for el in elements:
            el_name = el.get("name", el.get("id", "?"))

            # colours from the element itself
            for key in ("color", "normal_color", "highlighted_color",
                        "pressed_color", "outline_color", "label_color"):
                c = el.get(key)
                if c and isinstance(c, dict) and self._has_color_content(c):
                    hex_c = self._rgba_to_hex(c)
                    if hex_c not in colors:
                        colors[hex_c] = []
                    if el_name not in colors[hex_c]:
                        colors[hex_c].append(el_name)

            # font sizes
            fs = el.get("font_size") or el.get("label_font_size")
            if fs is not None:
                key = str(int(fs))
                if el_name not in font_sizes[key]:
                    font_sizes[key].append(el_name)

            # font files
            for fkey in ("font_file", "label_font_file"):
                ff = el.get(fkey, "")
                if ff:
                    if ff not in font_files:
                        font_files[ff] = []
                    if el_name not in font_files[ff]:
                        font_files[ff].append(el_name)

            # image sizes from sprite resolution
            sprite = el.get("sprite_file", "") or el.get("sprite_name", "")
            if sprite:
                resolved = self._resolve_sprite(sprite)
                if resolved:
                    try:
                        from PIL import Image as PILImage
                        with PILImage.open(str(resolved)) as img:
                            w, h = img.size
                        image_sizes[sprite] = {"width": w, "height": h}
                    except Exception:
                        size = el.get("size", {})
                        image_sizes[sprite] = {
                            "width": int(size.get("width", 0)),
                            "height": int(size.get("height", 0)),
                        }
                else:
                    size = el.get("size", {})
                    image_sizes[sprite] = {
                        "width": int(size.get("width", 0)),
                        "height": int(size.get("height", 0)),
                    }

        # spacing analysis — gaps between siblings sharing the same parent_id
        spacing = self._compute_spacing(elements, canvas_size)

        return {
            "colors": dict(colors),
            "font_sizes": dict(font_sizes),
            "font_files": dict(font_files),
            "spacing": spacing,
            "image_sizes": image_sizes,
        }

    # ── helpers ─────────────────────────────────────────────────────────

    @staticmethod
    def _rgba_to_hex(color: dict) -> str:
        r = int(color.get("r", 0) * 255)
        g = int(color.get("g", 0) * 255)
        b = int(color.get("b", 0) * 255)
        a = int(color.get("a", 1) * 255)
        if a == 255:
            return f"#{r:02X}{g:02X}{b:02X}"
        return f"#{r:02X}{g:02X}{b:02X}{a:02X}"

    @staticmethod
    def _has_color_content(c: dict) -> bool:
        return any(
            c.get(k, 0) not in (0, None)
            for k in ("r", "g", "b")
        )

    def _resolve_sprite(self, sprite_name: str) -> Path | None:
        stem = Path(sprite_name).stem.lower()
        for subdir in ("Sprites", "Images"):
            search = self._assets_dir / subdir
            if not search.is_dir():
                continue
            for png in search.rglob("*.png"):
                if png.stem.lower() == stem:
                    return png
        return None

    @staticmethod
    def _compute_spacing(elements: list[dict], canvas_size: dict) -> dict:
        """Compute gaps between sibling elements."""
        by_parent: dict[str | None, list[dict]] = defaultdict(list)
        for el in elements:
            by_parent[el.get("parent_id")].append(el)

        element_gaps: list[dict] = []
        margins: list[dict] = []

        cw = canvas_size.get("width", 0)
        ch = canvas_size.get("height", 0)

        for parent_id, children in by_parent.items():
            if len(children) < 2:
                continue
            sorted_children = sorted(
                children,
                key=lambda e: (
                    e.get("position", {}).get("y", 0),
                    e.get("position", {}).get("x", 0),
                ),
            )
            for i in range(len(sorted_children) - 1):
                a = sorted_children[i]
                b = sorted_children[i + 1]
                a_pos = a.get("position", {"x": 0, "y": 0})
                a_size = a.get("size", {"width": 0, "height": 0})
                b_pos = b.get("position", {"x": 0, "y": 0})
                b_size = b.get("size", {"width": 0, "height": 0})

                gap_y = (
                    b_pos.get("y", 0) - a_pos.get("y", 0)
                    - a_size.get("height", 0) / 2
                    - b_size.get("height", 0) / 2
                )
                gap_x = (
                    b_pos.get("x", 0) - a_pos.get("x", 0)
                    - a_size.get("width", 0) / 2
                    - b_size.get("width", 0) / 2
                )
                element_gaps.append({
                    "between": [a.get("name", "?"), b.get("name", "?")],
                    "gap_x": round(gap_x, 1),
                    "gap_y": round(gap_y, 1),
                })

        for el in elements:
            pos = el.get("position", {"x": 0, "y": 0})
            size = el.get("size", {"width": 0, "height": 0})
            left = cw / 2 + pos.get("x", 0) - size.get("width", 0) / 2
            top = ch / 2 - pos.get("y", 0) - size.get("height", 0) / 2
            right = left + size.get("width", 0)
            bottom = top + size.get("height", 0)
            margins.append({
                "element": el.get("name", "?"),
                "margin_left": round(left, 1),
                "margin_top": round(top, 1),
                "margin_right": round(cw - right, 1),
                "margin_bottom": round(ch - bottom, 1),
            })

        return {
            "element_gaps": element_gaps,
            "margins": margins,
        }
