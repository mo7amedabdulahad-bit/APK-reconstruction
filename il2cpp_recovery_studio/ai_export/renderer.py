"""Render a flat composite PNG preview of a UI screen spec."""
from __future__ import annotations

from pathlib import Path
from typing import Optional, Callable

try:
    from PIL import Image, ImageDraw, ImageFont
except ImportError:
    Image = None  # type: ignore[assignment]
    ImageDraw = None  # type: ignore[assignment]
    ImageFont = None  # type: ignore[assignment]

# Cross-platform font fallback chain (FIX Issue A/C)
_FONT_FALLBACKS = [
    "arial.ttf",        # Windows
    "Arial.ttf",
    "DejaVuSans.ttf",   # Linux
    "LiberationSans-Regular.ttf",
    "FreeSans.ttf",
    "/System/Library/Fonts/Helvetica.ttc",  # macOS
    "/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf",
]


class UIPreviewRenderer:
    """Render a UI screen-spec JSON into a single composite PNG image."""

    def __init__(
        self,
        assets_dir: Path,
        log_callback: Optional[Callable[[str], None]] = None,
    ) -> None:
        self._assets_dir = Path(assets_dir)
        self._log = log_callback or (lambda m: print(m))

    def render_screen(self, screen_json: dict, output_path: Path) -> bool:
        if Image is None:
            self._log("  [Preview] Pillow not installed – skipping preview render.")
            return False

        canvas_size = screen_json.get("canvas_size")
        elements = screen_json.get("elements")
        if not canvas_size or not elements:
            self._log("  [Preview] Missing canvas_size or elements – skipping.")
            return False

        cw = int(canvas_size.get("width", 1920))
        ch = int(canvas_size.get("height", 1080))
        bg = screen_json.get("background_color", {})
        bg_color = (
            int(bg.get("r", 0) * 255),
            int(bg.get("g", 0) * 255),
            int(bg.get("b", 0) * 255),
        )

        canvas = Image.new("RGBA", (cw, ch), bg_color + (255,))
        draw = ImageDraw.Draw(canvas)
        sorted_elements = sorted(elements, key=lambda e: e.get("layer_order", 0))

        for el in sorted_elements:
            if not el.get("active", True):
                continue

            pos = el.get("position", {"x": 0, "y": 0})
            size = el.get("size", {"width": 0, "height": 0})
            sw = int(size.get("width", 0))
            sh = int(size.get("height", 0))

            # FIX (Issue A): skip zero-size elements — Pillow raises ValueError on resize((0,0))
            if sw <= 0 or sh <= 0:
                continue

            px, py = self._unity_pos_to_pixel(pos, size, {"width": cw, "height": ch})
            el_type = el.get("type", "")

            sprite_file = el.get("sprite_file", "") or el.get("sprite_name", "")
            if sprite_file:
                resolved = self._resolve_sprite(sprite_file)
                if resolved:
                    self._paste_sprite(canvas, resolved, (px, py), (sw, sh))

            if el_type == "Text":
                text_str = el.get("text", "")
                if text_str:
                    self._draw_text(
                        draw, text_str, (px, py), (sw, sh),
                        el.get("font_size", 14),
                        el.get("color", {"r": 1, "g": 1, "b": 1, "a": 1}),
                        el.get("font_file", ""),
                    )

            if el_type == "Button":
                label = el.get("label", "")
                if label:
                    self._draw_text(
                        draw, label, (px, py), (sw, sh),
                        el.get("label_font_size", 24),
                        el.get("label_color", {"r": 1, "g": 1, "b": 1, "a": 1}),
                        el.get("label_font_file", ""),
                    )

        output_path = Path(output_path)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        canvas.save(str(output_path), "PNG")
        self._log(f"  [Preview] Saved: {output_path.name}")
        return True

    @staticmethod
    def _unity_pos_to_pixel(pos: dict, size: dict, canvas_size: dict) -> tuple[int, int]:
        cx = canvas_size.get("width", 0) / 2
        cy = canvas_size.get("height", 0) / 2
        px = int(cx + pos.get("x", 0) - size.get("width", 0) / 2)
        py = int(cy - pos.get("y", 0) - size.get("height", 0) / 2)
        return px, py

    def _resolve_sprite(self, sprite_name: str) -> Optional[Path]:
        if not sprite_name:
            return None
        # Try as absolute or relative-to-assets path first
        candidate = Path(sprite_name)
        if candidate.is_absolute() and candidate.is_file():
            return candidate
        full = self._assets_dir / sprite_name
        if full.is_file():
            return full
        # Fallback: search by stem
        stem = candidate.stem.lower()
        for subdir in ("Sprites", "Images"):
            search = self._assets_dir / subdir
            if not search.is_dir():
                continue
            for png in search.rglob("*.png"):
                if png.stem.lower() == stem:
                    return png
        return None

    @staticmethod
    def _paste_sprite(canvas, sprite_path: Path, pos: tuple[int, int], size: tuple[int, int]) -> None:
        try:
            spr = Image.open(str(sprite_path)).convert("RGBA")
            spr = spr.resize(size, Image.LANCZOS)
            canvas.paste(spr, pos, spr)
        except Exception:
            pass

    @staticmethod
    def _draw_text(
        draw,
        text: str,
        pos: tuple[int, int],
        size: tuple[int, int],
        font_size: int,
        color: dict,
        font_file: str,
    ) -> None:
        r = int(color.get("r", 1) * 255)
        g = int(color.get("g", 1) * 255)
        b = int(color.get("b", 1) * 255)
        fill = (r, g, b, 255)

        font = ImageFont.load_default()
        # FIX (Issue C): cross-platform font fallback chain
        if font_file and Path(font_file).is_file():
            try:
                font = ImageFont.truetype(str(font_file), max(font_size, 8))
            except Exception:
                pass
        else:
            for fb in _FONT_FALLBACKS:
                try:
                    font = ImageFont.truetype(fb, max(font_size, 8))
                    break
                except Exception:
                    continue

        try:
            bbox = draw.textbbox((0, 0), text, font=font)
            tw = bbox[2] - bbox[0]
            th = bbox[3] - bbox[1]
        except Exception:
            tw, th = len(text) * 7, font_size
        x = pos[0] + (size[0] - tw) // 2
        y = pos[1] + (size[1] - th) // 2
        draw.text((x, y), text, fill=fill, font=font)
