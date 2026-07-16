"""Sprite atlas reconstruction engine."""

from __future__ import annotations

import struct
import zlib
from io import BytesIO
from pathlib import Path
from typing import Optional

from .models import (
    ExtractedAsset, ExtractedSprite, SpriteRect, SpriteAtlasData,
    SpriteClassification, AssetCategory,
)

try:
    from PIL import Image, ImageDraw
    HAS_PIL = True
except ImportError:
    HAS_PIL = False


class SpriteAtlasReconstructor:
    """Reconstruct individual sprites from sprite atlases."""

    def __init__(self):
        self.atlases: list[SpriteAtlasData] = []
        self.reconstructed_sprites: list[ExtractedSprite] = []

    def reconstruct_from_atlas(self, atlas_asset: ExtractedAsset) -> list[ExtractedSprite]:
        """Reconstruct sprites from a sprite atlas asset."""
        sprites = []

        if not HAS_PIL:
            return sprites

        # Try to extract atlas data from the serialized asset
        atlas_data = self._parse_atlas_asset(atlas_asset)
        if not atlas_data:
            return sprites

        # Load the texture image
        texture_image = self._load_texture(atlas_asset)
        if not texture_image:
            return sprites

        # Extract each sprite from the atlas
        for rect in atlas_data.sprites:
            sprite = self._extract_sprite(texture_image, rect, atlas_data)
            if sprite:
                sprites.append(sprite)

        self.reconstructed_sprites.extend(sprites)
        return sprites

    def reconstruct_from_spritesheet(self, image_data: bytes, metadata: dict, name: str) -> list[ExtractedSprite]:
        """Reconstruct sprites from a spritesheet using metadata."""
        sprites = []

        if not HAS_PIL or not image_data:
            return sprites

        try:
            image = Image.open(BytesIO(image_data))
        except Exception:
            return sprites

        sprite_rects = metadata.get("sprites", [])
        if not sprite_rects:
            # Try to auto-detect sprite grid
            sprite_rects = self._auto_detect_sprites(image, metadata)

        for i, rect_info in enumerate(sprite_rects):
            rect = SpriteRect(
                x=rect_info.get("x", 0),
                y=rect_info.get("y", 0),
                width=rect_info.get("width", image.width),
                height=rect_info.get("height", image.height),
                name=rect_info.get("name", f"{name}_sprite_{i:03d}"),
                pivot_x=rect_info.get("pivotX", 0.5),
                pivot_y=rect_info.get("pivotY", 0.5),
            )

            try:
                crop_box = (rect.x, rect.y, rect.x + rect.width, rect.y + rect.height)
                cropped = image.crop(crop_box)

                img_buffer = BytesIO()
                cropped.save(img_buffer, format="PNG")
                img_data = img_buffer.getvalue()

                sprite = ExtractedSprite(
                    name=rect.name,
                    atlas_name=name,
                    x=rect.x,
                    y=rect.y,
                    width=rect.width,
                    height=rect.height,
                    pivot_x=rect.pivot_x,
                    pivot_y=rect.pivot_y,
                    image_data=img_data,
                    classification=SpriteClassification.UNKNOWN,
                    metadata={
                        "atlas_dimensions": f"{image.width}x{image.height}",
                        "rect": f"{rect.x},{rect.y},{rect.width},{rect.height}",
                    },
                )
                sprites.append(sprite)
            except Exception:
                continue

        self.reconstructed_sprites.extend(sprites)
        return sprites

    def reconstruct_from_texture_with_grid(self, image_data: bytes, grid_info: dict, name: str) -> list[ExtractedSprite]:
        """Reconstruct sprites from a texture using a grid pattern."""
        sprites = []

        if not HAS_PIL or not image_data:
            return sprites

        try:
            image = Image.open(BytesIO(image_data))
        except Exception:
            return sprites

        cols = grid_info.get("columns", 1)
        rows = grid_info.get("rows", 1)
        padding = grid_info.get("padding", 0)
        spacing_x = grid_info.get("spacingX", 0)
        spacing_y = grid_info.get("spacingY", 0)

        cell_width = (image.width - padding * 2 - spacing_x * (cols - 1)) // cols if cols > 0 else image.width
        cell_height = (image.height - padding * 2 - spacing_y * (rows - 1)) // rows if rows > 0 else image.height

        idx = 0
        for row in range(rows):
            for col in range(cols):
                x = padding + col * (cell_width + spacing_x)
                y = padding + row * (cell_height + spacing_y)

                if x + cell_width > image.width or y + cell_height > image.height:
                    continue

                try:
                    crop_box = (x, y, x + cell_width, y + cell_height)
                    cropped = image.crop(crop_box)

                    img_buffer = BytesIO()
                    cropped.save(img_buffer, format="PNG")
                    img_data = img_buffer.getvalue()

                    sprite_name = f"{name}_{idx:03d}"
                    sprite = ExtractedSprite(
                        name=sprite_name,
                        atlas_name=name,
                        x=x,
                        y=y,
                        width=cell_width,
                        height=cell_height,
                        image_data=img_data,
                        metadata={"grid_position": f"{row},{col}"},
                    )
                    sprites.append(sprite)
                    idx += 1
                except Exception:
                    continue

        self.reconstructed_sprites.extend(sprites)
        return sprites

    def _parse_atlas_asset(self, asset: ExtractedAsset) -> Optional[SpriteAtlasData]:
        """Parse a Unity SpriteAtlas serialized asset."""
        data = asset.data
        if len(data) < 16:
            return None

        atlas = SpriteAtlasData(
            name=asset.name,
            guid=asset.guid,
        )

        # Try to find sprite rectangles in the binary data
        # Unity stores sprite rects as sequences of float values
        try:
            sprite_rects = self._find_sprite_rects_in_data(data)
            if sprite_rects:
                atlas.sprites = sprite_rects
                return atlas
        except Exception:
            pass

        return None

    def _find_sprite_rects_in_data(self, data: bytes) -> list[SpriteRect]:
        """Search binary data for sprite rectangle patterns."""
        rects = []
        # Look for sequences of 4 consecutive floats that could be sprite rects
        # This is a heuristic approach for serialized Unity data
        for i in range(0, len(data) - 16, 4):
            try:
                x = struct.unpack('<f', data[i:i + 4])[0]
                y = struct.unpack('<f', data[i + 4:i + 8])[0]
                w = struct.unpack('<f', data[i + 8:i + 12])[0]
                h = struct.unpack('<f', data[i + 12:i + 16])[0]

                # Validate: reasonable sprite dimensions
                if 4 <= w <= 4096 and 4 <= h <= 4096 and x >= 0 and y >= 0:
                    # Check if next floats are reasonable pivot values (0-1)
                    if i + 24 <= len(data):
                        px = struct.unpack('<f', data[i + 16:i + 20])[0]
                        py = struct.unpack('<f', data[i + 20:i + 24])[0]
                        if 0 <= px <= 1 and 0 <= py <= 1:
                            rects.append(SpriteRect(
                                x=int(x), y=int(y),
                                width=int(w), height=int(h),
                                pivot_x=px, pivot_y=py,
                                name=f"Sprite_{len(rects):03d}",
                            ))
            except struct.error:
                continue

        # Deduplicate overlapping rects
        return self._deduplicate_rects(rects)

    def _deduplicate_rects(self, rects: list[SpriteRect]) -> list[SpriteRect]:
        """Remove overlapping sprite rectangles."""
        if not rects:
            return rects

        unique = []
        seen = set()

        for rect in rects:
            key = (rect.x, rect.y, rect.width, rect.height)
            if key not in seen:
                seen.add(key)
                unique.append(rect)

        return unique

    def _load_texture(self, asset: ExtractedAsset) -> Optional[Image.Image]:
        """Load texture image from asset data."""
        if not HAS_PIL:
            return None

        # Try direct image data first
        if asset.data[:8] == b'\x89PNG\r\n\x1a\n':
            try:
                return Image.open(BytesIO(asset.data))
            except Exception:
                pass

        # Try embedded texture in serialized data
        try:
            texture_data = self._extract_embedded_texture(asset.data)
            if texture_data:
                return Image.open(BytesIO(texture_data))
        except Exception:
            pass

        # Try the file path
        if asset.file_path and asset.file_path.exists():
            try:
                return Image.open(str(asset.file_path))
            except Exception:
                pass

        return None

    def _extract_embedded_texture(self, data: bytes) -> Optional[bytes]:
        """Extract embedded texture data from a serialized Unity asset."""
        # Look for PNG signature in the data
        png_start = data.find(b'\x89PNG\r\n\x1a\n')
        if png_start >= 0:
            # Find PNG end marker
            iend_pos = data.find(b'IEND', png_start)
            if iend_pos > 0:
                return data[png_start:iend_pos + 8]

        # Look for raw texture data after header
        if len(data) > 128:
            # Check if there's a large block of image data
            raw_start = len(data) // 3  # rough estimate
            sample = data[raw_start:raw_start + 100]
            # If it looks like raw RGBA data (non-zero, varied)
            if any(b > 0 for b in sample[:20]):
                return None  # Would need format info to decode

        return None

    def _auto_detect_sprites(self, image: Image.Image, metadata: dict) -> list[dict]:
        """Auto-detect sprites in an image by looking for transparent boundaries."""
        if not image.mode == "RGBA":
            image = image.convert("RGBA")

        width, height = image.size
        pixels = image.load()

        # Find vertical and horizontal transparent lines
        v_lines = []
        h_lines = []

        # Check for fully transparent columns
        for x in range(width):
            transparent = all(pixels[x, y][3] == 0 for y in range(0, height, max(1, height // 20)))
            if transparent:
                v_lines.append(x)

        # Check for fully transparent rows
        for y in range(height):
            transparent = all(pixels[x, y][3] == 0 for x in range(0, width, max(1, width // 20)))
            if transparent:
                h_lines.append(y)

        # Group consecutive transparent lines to find boundaries
        v_groups = self._group_consecutive(v_lines)
        h_groups = self._group_consecutive(h_lines)

        if not v_groups and not h_groups:
            return []

        # Create rectangles from boundaries
        sprites = []
        v_bounds = [0] + [g[-1] + 1 for g in v_groups if g[-1] + 1 < width] + [width]
        h_bounds = [0] + [g[-1] + 1 for g in h_groups if g[-1] + 1 < height] + [height]

        idx = 0
        for i in range(len(v_bounds) - 1):
            for j in range(len(h_bounds) - 1):
                x1, y1 = v_bounds[i], h_bounds[j]
                x2, y2 = v_bounds[i + 1], h_bounds[j + 1]
                w, h = x2 - x1, y2 - y1

                if w > 4 and h > 4:  # Minimum sprite size
                    sprites.append({
                        "x": x1, "y": y1,
                        "width": w, "height": h,
                        "name": f"sprite_{idx:03d}",
                        "pivotX": 0.5, "pivotY": 0.5,
                    })
                    idx += 1

        return sprites

    def _group_consecutive(self, values: list[int], gap: int = 2) -> list[list[int]]:
        """Group consecutive numbers."""
        if not values:
            return []

        groups = [[values[0]]]
        for v in values[1:]:
            if v - groups[-1][-1] <= gap:
                groups[-1].append(v)
            else:
                groups.append([v])
        return groups

    def _extract_sprite(self, image: Image.Image, rect: SpriteRect, atlas: SpriteAtlasData) -> Optional[ExtractedSprite]:
        """Extract a single sprite from the atlas image."""
        try:
            crop_box = (rect.x, rect.y, rect.x + rect.width, rect.y + rect.height)
            cropped = image.crop(crop_box)

            img_buffer = BytesIO()
            cropped.save(img_buffer, format="PNG")
            img_data = img_buffer.getvalue()

            # Auto-classify sprite
            classification = self._classify_sprite(cropped, rect)

            return ExtractedSprite(
                name=rect.name,
                atlas_name=atlas.name,
                x=rect.x,
                y=rect.y,
                width=rect.width,
                height=rect.height,
                pivot_x=rect.pivot_x,
                pivot_y=rect.pivot_y,
                border_left=rect.border_left,
                border_bottom=rect.border_bottom,
                border_right=rect.border_right,
                border_top=rect.border_top,
                rotation=rect.rotation,
                packing_mode=rect.packing_mode,
                packing_tag=rect.packing_tag,
                image_data=img_data,
                classification=classification,
                metadata={
                    "atlas_dimensions": f"{atlas.texture_width}x{atlas.texture_height}",
                    "atlas_name": atlas.name,
                    "rect": f"{rect.x},{rect.y},{rect.width},{rect.height}",
                    "pivot": f"{rect.pivot_x},{rect.pivot_y}",
                    "border": f"{rect.border_left},{rect.border_bottom},{rect.border_right},{rect.border_top}",
                    "rotation": rect.rotation,
                    "packing_mode": rect.packing_mode,
                },
            )
        except Exception:
            return None

    def _classify_sprite(self, image: Image.Image, rect: SpriteRect) -> SpriteClassification:
        """Classify a sprite based on its visual characteristics."""
        w, h = image.size
        aspect = w / max(h, 1)

        # Size-based heuristics
        if w <= 64 and h <= 64:
            return SpriteClassification.ICON

        if w > 200 and h > 200:
            if aspect < 1.2:
                return SpriteClassification.PORTRAIT
            else:
                return SpriteClassification.BACKGROUND

        if 0.8 < aspect < 1.2 and 32 <= w <= 128:
            return SpriteClassification.ICON

        if aspect > 2.0:
            return SpriteClassification.BUTTON

        if w > 500 and h > 300:
            return SpriteClassification.BACKGROUND

        return SpriteClassification.UNKNOWN
