"""Image classification using computer vision heuristics."""

from __future__ import annotations

import struct
import math
from io import BytesIO
from typing import Optional

from .models import ExtractedAsset, SpriteClassification

try:
    from PIL import Image, ImageStat, ImageFilter
    HAS_PIL = True
except ImportError:
    HAS_PIL = False


class ImageClassifier:
    """Classify images using computer vision heuristics."""

    # Aspect ratio thresholds
    ICON_MAX_SIZE = 128
    PORTRAIT_MIN_RATIO = 0.7
    PORTRAIT_MAX_RATIO = 0.9
    BUTTON_MIN_ASPECT = 2.0
    BACKGROUND_MIN_WIDTH = 500
    BACKGROUND_MIN_HEIGHT = 300

    def classify(self, asset: ExtractedAsset) -> tuple[SpriteClassification, float]:
        """Classify an image asset and return classification with confidence."""
        if not HAS_PIL:
            return SpriteClassification.UNKNOWN, 0.0

        image = self._load_image(asset)
        if image is None:
            return self._classify_by_metadata(asset)

        return self._classify_by_visual(image, asset)

    def classify_batch(self, assets: list[ExtractedAsset]) -> list[tuple[SpriteClassification, float]]:
        """Classify a batch of images."""
        return [self.classify(a) for a in assets]

    def _load_image(self, asset: ExtractedAsset) -> Optional[Image.Image]:
        """Load image from asset data."""
        if asset.data[:8] == b'\x89PNG\r\n\x1a\n':
            try:
                return Image.open(BytesIO(asset.data))
            except Exception:
                pass

        if asset.file_path and asset.file_path.exists():
            try:
                return Image.open(str(asset.file_path))
            except Exception:
                pass

        return None

    def _classify_by_visual(self, image: Image.Image, asset: ExtractedAsset) -> tuple[SpriteClassification, float]:
        """Classify image based on visual characteristics."""
        w, h = image.size
        aspect = w / max(h, 1)
        area = w * h

        scores: dict[SpriteClassification, float] = {}

        # Analyze color characteristics
        try:
            stat = ImageStat.Stat(image.convert("RGBA"))
            mean_r, mean_g, mean_b, mean_a = stat.mean
            std_r, std_g, std_b, std_a = stat.stddev
        except Exception:
            mean_a = 128
            std_r = std_g = std_b = std_a = 50

        # Analyze transparency
        if image.mode == "RGBA":
            try:
                alpha = image.split()[3]
                transparent_pct = sum(1 for p in alpha.getdata() if p == 0) / max(1, alpha.width * alpha.height)
            except Exception:
                transparent_pct = 0.0
        else:
            transparent_pct = 0.0

        # Analyze complexity (edge density)
        try:
            gray = image.convert("L")
            edges = gray.filter(ImageFilter.FIND_EDGES)
            edge_stat = ImageStat.Stat(edges)
            edge_density = edge_stat.mean[0] / 255.0
        except Exception:
            edge_density = 0.5

        # Small, square, low complexity -> icon
        if w <= self.ICON_MAX_SIZE and h <= self.ICON_MAX_SIZE and aspect > 0.8 and aspect < 1.2:
            scores[SpriteClassification.ICON] = scores.get(SpriteClassification.ICON, 0) + 0.5

        # Portrait aspect ratio
        if self.PORTRAIT_MIN_RATIO <= aspect <= self.PORTRAIT_MAX_RATIO:
            scores[SpriteClassification.PORTRAIT] = scores.get(SpriteClassification.PORTRAIT, 0) + 0.3

        # Background: large, high complexity
        if w >= self.BACKGROUND_MIN_WIDTH and h >= self.BACKGROUND_MIN_HEIGHT:
            scores[SpriteClassification.BACKGROUND] = scores.get(SpriteClassification.BACKGROUND, 0) + 0.3
            if edge_density > 0.3:
                scores[SpriteClassification.BACKGROUND] = scores.get(SpriteClassification.BACKGROUND, 0) + 0.2

        # Button: wide, short, high transparency
        if aspect > self.BUTTON_MIN_ASPECT and h < w * 0.5:
            scores[SpriteClassification.BUTTON] = scores.get(SpriteClassification.BUTTON, 0) + 0.4
            if transparent_pct > 0.3:
                scores[SpriteClassification.BUTTON] = scores.get(SpriteClassification.BUTTON, 0) + 0.2

        # UI Panel: moderate size, many colors, transparency
        if 100 < w < 800 and 50 < h < 600:
            if transparent_pct > 0.1:
                scores[SpriteClassification.UI_PANEL] = scores.get(SpriteClassification.UI_PANEL, 0) + 0.3
            if std_r + std_g + std_b > 100:
                scores[SpriteClassification.UI_PANEL] = scores.get(SpriteClassification.UI_PANEL, 0) + 0.1

        # Character: specific aspect, high complexity
        if 0.8 < aspect < 1.2 and 64 < w < 512:
            if edge_density > 0.2:
                scores[SpriteClassification.CHARACTER] = scores.get(SpriteClassification.CHARACTER, 0) + 0.2

        # Terrain: wide, high complexity, earth tones
        if aspect > 1.5 and w > 256:
            if mean_g > mean_r and mean_g > mean_b:
                scores[SpriteClassification.TERRAIN] = scores.get(SpriteClassification.TERRAIN, 0) + 0.3
            scores[SpriteClassification.MAP] = scores.get(SpriteClassification.MAP, 0) + 0.2

        # Logo: small-medium, high contrast
        if 64 < w < 512 and 64 < h < 512:
            if std_r + std_g + std_b > 80:
                scores[SpriteClassification.LOGO] = scores.get(SpriteClassification.LOGO, 0) + 0.2

        # Skill: small-medium, specific naming
        name_lower = asset.name.lower()
        if any(k in name_lower for k in ("skill", "spell", "ability", "power")):
            scores[SpriteClassification.SKILL] = scores.get(SpriteClassification.SKILL, 0) + 0.6

        # Weapon/Armor/Item
        if any(k in name_lower for k in ("weapon", "sword", "axe", "bow", "staff")):
            scores[SpriteClassification.WEAPON] = scores.get(SpriteClassification.WEAPON, 0) + 0.6
        if any(k in name_lower for k in ("armor", "helmet", "shield", "chest")):
            scores[SpriteClassification.ARMOR] = scores.get(SpriteClassification.ARMOR, 0) + 0.6
        if any(k in name_lower for k in ("item", "potion", "scroll", "ring")):
            scores[SpriteClassification.ITEM] = scores.get(SpriteClassification.ITEM, 0) + 0.6

        # Animation frame
        if any(k in name_lower for k in ("frame", "anim", "walk", "run", "idle", "attack")):
            scores[SpriteClassification.ANIMATION_FRAME] = scores.get(SpriteClassification.ANIMATION_FRAME, 0) + 0.5

        # Splash screen
        if w > 800 and h > 600:
            scores[SpriteClassification.SPLASH_SCREEN] = scores.get(SpriteClassification.SPLASH_SCREEN, 0) + 0.2

        # Select best
        if scores:
            best = max(scores, key=scores.get)
            confidence = min(1.0, scores[best] / 2.0)
            return best, confidence

        return SpriteClassification.UNKNOWN, 0.0

    def _classify_by_metadata(self, asset: ExtractedAsset) -> tuple[SpriteClassification, float]:
        """Classify by metadata when PIL is not available."""
        name = asset.name.lower()

        if any(k in name for k in ("icon", "ico_", "_icon")):
            return SpriteClassification.ICON, 0.6

        if any(k in name for k in ("portrait", "face", "avatar")):
            return SpriteClassification.PORTRAIT, 0.6

        if any(k in name for k in ("bg", "background", "backdrop")):
            return SpriteClassification.BACKGROUND, 0.6

        if any(k in name for k in ("btn", "button")):
            return SpriteClassification.BUTTON, 0.6

        if any(k in name for k in ("panel", "frame", "window", "dialog")):
            return SpriteClassification.UI_PANEL, 0.6

        if any(k in name for k in ("logo", "title", "splash")):
            return SpriteClassification.LOGO, 0.6

        if any(k in name for k in ("skill", "spell")):
            return SpriteClassification.SKILL, 0.6

        if any(k in name for k in ("terrain", "tile", "ground")):
            return SpriteClassification.TERRAIN, 0.6

        if asset.width > 0 and asset.height > 0:
            if asset.width <= 128 and asset.height <= 128:
                return SpriteClassification.ICON, 0.4
            if asset.width > 500 and asset.height > 300:
                return SpriteClassification.BACKGROUND, 0.4

        return SpriteClassification.UNKNOWN, 0.0

    def compute_image_hash(self, asset: ExtractedAsset) -> Optional[str]:
        """Compute a perceptual hash for duplicate detection."""
        if not HAS_PIL:
            return None

        image = self._load_image(asset)
        if image is None:
            return None

        try:
            # Simple average hash
            resized = image.convert("L").resize((8, 8), Image.LANCZOS)
            pixels = list(resized.getdata())
            avg = sum(pixels) / len(pixels)
            bits = "".join("1" if p > avg else "0" for p in pixels)
            return hex(int(bits, 2))[2:].zfill(16)
        except Exception:
            return None

    def compute_color_histogram(self, asset: ExtractedAsset) -> Optional[list[float]]:
        """Compute normalized color histogram for similarity comparison."""
        if not HAS_PIL:
            return None

        image = self._load_image(asset)
        if image is None:
            return None

        try:
            image = image.convert("RGB").resize((64, 64))
            hist = image.histogram()
            total = sum(hist)
            if total == 0:
                return [0.0] * len(hist)
            return [h / total for h in hist]
        except Exception:
            return None
