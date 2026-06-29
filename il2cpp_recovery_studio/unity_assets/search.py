"""Search engine for recovered assets."""

from __future__ import annotations

import json
import re
from pathlib import Path
from typing import Any, Optional
from collections import defaultdict

from .models import ExtractedAsset, AssetCategory, SpriteClassification


class AssetSearchEngine:
    """Full-text and parameterized search for recovered assets."""

    def __init__(self):
        self.index: dict[str, Any] = {}
        self.assets: list[ExtractedAsset] = []

    def build_index(self, assets: list[ExtractedAsset]) -> None:
        """Build search index from assets."""
        self.assets = assets
        self.index = {
            "assets": {},
            "by_type": defaultdict(list),
            "by_category": defaultdict(list),
            "by_feature": defaultdict(list),
            "by_name_prefix": defaultdict(list),
            "by_guid": {},
            "by_size_range": defaultdict(list),
            "by_dimension": defaultdict(list),
        }

        for asset in assets:
            entry = {
                "name": asset.name,
                "type": asset.asset_type,
                "category": asset.category.value,
                "feature_group": asset.feature_group,
                "path": asset.path,
                "guid": asset.guid,
                "width": asset.width,
                "height": asset.height,
                "size": len(asset.data),
                "hash": asset.hash_sha256,
                "classification": asset.sprite_classification.value,
            }

            self.index["assets"][asset.name] = entry
            self.index["by_type"][asset.asset_type].append(asset.name)
            self.index["by_category"][asset.category.value].append(asset.name)
            self.index["by_feature"][asset.feature_group].append(asset.name)

            prefix = asset.name[:3].lower()
            self.index["by_name_prefix"][prefix].append(asset.name)

            if asset.guid:
                self.index["by_guid"][asset.guid] = asset.name

            # Size buckets
            size_kb = len(asset.data) // 1024
            if size_kb < 10:
                self.index["by_size_range"]["tiny"].append(asset.name)
            elif size_kb < 100:
                self.index["by_size_range"]["small"].append(asset.name)
            elif size_kb < 1000:
                self.index["by_size_range"]["medium"].append(asset.name)
            elif size_kb < 10000:
                self.index["by_size_range"]["large"].append(asset.name)
            else:
                self.index["by_size_range"]["huge"].append(asset.name)

    def search(self, query: str, scope: str = "all",
               search_type: str = "contains",
               category: Optional[str] = None,
               feature: Optional[str] = None,
               asset_type: Optional[str] = None,
               min_size: Optional[int] = None,
               max_size: Optional[int] = None,
               min_width: Optional[int] = None,
               max_width: Optional[int] = None,
               min_height: Optional[int] = None,
               max_height: Optional[int] = None) -> list[dict[str, Any]]:
        """Search assets with various filters."""
        results = []

        for name, entry in self.index.get("assets", {}).items():
            # Text search
            if query:
                if search_type == "exact":
                    if not self._exact_match(query, entry, scope):
                        continue
                elif search_type == "regex":
                    if not self._regex_match(query, entry, scope):
                        continue
                elif search_type == "fuzzy":
                    if not self._fuzzy_match(query, entry, scope):
                        continue
                else:  # contains
                    if not self._contains_match(query, entry, scope):
                        continue

            # Category filter
            if category and entry["category"] != category:
                continue

            # Feature filter
            if feature and entry["feature_group"] != feature:
                continue

            # Type filter
            if asset_type and entry["type"] != asset_type:
                continue

            # Size filters
            if min_size is not None and entry["size"] < min_size:
                continue
            if max_size is not None and entry["size"] > max_size:
                continue

            # Dimension filters
            if min_width is not None and entry["width"] < min_width:
                continue
            if max_width is not None and entry["width"] > max_width:
                continue
            if min_height is not None and entry["height"] < min_height:
                continue
            if max_height is not None and entry["height"] > max_height:
                continue

            results.append(entry)

        return results

    def search_by_image(self, image_hash: str) -> list[dict[str, Any]]:
        """Search for visually similar images."""
        results = []
        for asset in self.assets:
            if asset.hash_md5 == image_hash or asset.hash_sha256 == image_hash:
                results.append({
                    "name": asset.name,
                    "type": asset.asset_type,
                    "hash": asset.hash_sha256,
                    "match": "exact",
                })
        return results

    def search_by_reference(self, asset_name: str) -> list[dict[str, Any]]:
        """Search for assets that reference a given asset."""
        results = []
        for asset in self.assets:
            if asset_name in asset.referenced_by:
                results.append({
                    "name": asset.name,
                    "type": asset.asset_type,
                    "category": asset.category.value,
                })
        return results

    def search_by_color(self, target_color: tuple[int, int, int],
                        threshold: float = 30.0) -> list[dict[str, Any]]:
        """Search for images with similar dominant color."""
        results = []
        for asset in self.assets:
            if asset.asset_type in ("Texture2D", "Sprite"):
                hist = self._compute_dominant_color(asset)
                if hist:
                    distance = sum((a - b) ** 2 for a, b in zip(target_color, hist)) ** 0.5
                    if distance <= threshold:
                        results.append({
                            "name": asset.name,
                            "dominant_color": hist,
                            "distance": distance,
                        })
        return results

    def _contains_match(self, query: str, entry: dict, scope: str) -> bool:
        """Check if query is contained in entry fields."""
        q = query.lower()
        if scope == "all":
            return any(q in str(v).lower() for v in entry.values())
        if scope == "name":
            return q in entry["name"].lower()
        if scope == "type":
            return q in entry["type"].lower()
        if scope == "category":
            return q in entry["category"].lower()
        if scope == "feature":
            return q in entry["feature_group"].lower()
        if scope == "guid":
            return q in entry.get("guid", "").lower()
        return False

    def _exact_match(self, query: str, entry: dict, scope: str) -> bool:
        """Check for exact match."""
        q = query.lower()
        if scope == "name":
            return entry["name"].lower() == q
        if scope == "type":
            return entry["type"].lower() == q
        if scope == "category":
            return entry["category"].lower() == q
        return q in entry["name"].lower()

    def _regex_match(self, query: str, entry: dict, scope: str) -> bool:
        """Check for regex match."""
        try:
            pattern = re.compile(query, re.IGNORECASE)
            if scope == "name":
                return bool(pattern.search(entry["name"]))
            if scope == "type":
                return bool(pattern.search(entry["type"]))
            return bool(pattern.search(str(entry)))
        except re.error:
            return False

    def _fuzzy_match(self, query: str, entry: dict, scope: str) -> bool:
        """Simple fuzzy match based on character overlap."""
        q = query.lower()
        text = entry["name"].lower()

        if len(q) == 0:
            return True

        qi = 0
        for ch in text:
            if qi < len(q) and ch == q[qi]:
                qi += 1

        return qi / len(q) >= 0.6

    def _compute_dominant_color(self, asset: ExtractedAsset) -> Optional[tuple[int, int, int]]:
        """Compute dominant color of an image asset."""
        try:
            from PIL import Image
            from io import BytesIO
            if asset.data[:8] == b'\x89PNG\r\n\x1a\n' or asset.data[:3] == b'\xff\xd8\xff':
                img = Image.open(BytesIO(asset.data)).convert("RGB").resize((10, 10))
                pixels = list(img.getdata())
                r = sum(p[0] for p in pixels) // len(pixels)
                g = sum(p[1] for p in pixels) // len(pixels)
                b = sum(p[2] for p in pixels) // len(pixels)
                return (r, g, b)
        except Exception:
            pass
        return None

    def get_statistics(self) -> dict[str, Any]:
        """Get search index statistics."""
        return {
            "total_assets": len(self.index.get("assets", {})),
            "types": dict(self.index.get("by_type", {})),
            "categories": dict(self.index.get("by_category", {})),
            "features": dict(self.index.get("by_feature", {})),
            "size_ranges": dict(self.index.get("by_size_range", {})),
        }

    def load_from_file(self, index_path: Path) -> None:
        """Load index from JSON file."""
        with open(index_path, "r", encoding="utf-8") as f:
            self.index = json.load(f)

    def save_to_file(self, output_path: Path) -> None:
        """Save index to JSON file."""
        # Convert defaultdicts to regular dicts for JSON
        serializable = {
            "assets": self.index.get("assets", {}),
            "by_type": dict(self.index.get("by_type", {})),
            "by_category": dict(self.index.get("by_category", {})),
            "by_feature": dict(self.index.get("by_feature", {})),
            "by_name_prefix": dict(self.index.get("by_name_prefix", {})),
            "by_guid": self.index.get("by_guid", {}),
            "by_size_range": dict(self.index.get("by_size_range", {})),
        }
        with open(output_path, "w", encoding="utf-8") as f:
            json.dump(serializable, f, indent=2, ensure_ascii=False)
