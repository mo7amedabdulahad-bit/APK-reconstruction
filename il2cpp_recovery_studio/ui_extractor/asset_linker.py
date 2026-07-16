"""Link extracted sprite and font names to their actual file paths."""
from __future__ import annotations

from pathlib import Path


class AssetLinker:
    """Scans an extracted-assets directory and maps names to relative paths."""

    def __init__(self, extracted_assets_dir: Path) -> None:
        self._base = Path(extracted_assets_dir)
        self._sprite_index: dict[str, str] = {}
        self._font_index: dict[str, str] = {}

    # ── index building ───────────────────────────────────────────────────

    def build_index(self) -> None:
        """Scan ``Sprites/`` and ``Images/`` for PNGs, ``Fonts/`` for TTF/OTF."""
        self._sprite_index.clear()
        self._font_index.clear()

        for sub in ("Sprites", "Images"):
            folder = self._base / sub
            if not folder.is_dir():
                continue
            for png in folder.rglob("*.png"):
                rel = str(png.relative_to(self._base)).replace("\\", "/")
                stem = png.stem.lower()
                self._sprite_index[stem] = rel

        fonts_dir = self._base / "Fonts"
        if fonts_dir.is_dir():
            for ext in ("*.ttf", "*.otf"):
                for fp in fonts_dir.rglob(ext):
                    rel = str(fp.relative_to(self._base)).replace("\\", "/")
                    stem = fp.stem.lower()
                    self._font_index[stem] = rel

    # ── lookups ──────────────────────────────────────────────────────────

    def find_sprite(self, sprite_name: str) -> str:
        """Return the relative path for *sprite_name* or ``MISSING:<name>``."""
        if not sprite_name:
            return ""
        key = sprite_name.lower()
        if key in self._sprite_index:
            return self._sprite_index[key]
        # try stripping common prefixes/suffixes
        for suffix in ("_sprite", "_icon", "sprite_", "icon_"):
            stripped = key.replace(suffix, "")
            if stripped in self._sprite_index:
                return self._sprite_index[stripped]
        return f"MISSING:{sprite_name}"

    def find_font(self, font_name: str) -> str:
        """Return the relative path for *font_name* or ``MISSING:<name>``."""
        if not font_name:
            return ""
        key = font_name.lower()
        if key in self._font_index:
            return self._font_index[key]
        for ext in ("", "bold", "regular", "light"):
            candidate = f"{key}-{ext}" if ext else key
            if candidate in self._font_index:
                return self._font_index[candidate]
        return f"MISSING:{font_name}"
