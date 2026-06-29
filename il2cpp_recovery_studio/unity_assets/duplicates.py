"""Duplicate detection system for extracted assets."""

from __future__ import annotations

import hashlib
from typing import Optional
from collections import defaultdict

from .models import ExtractedAsset, DuplicateGroup, DuplicateType


class DuplicateDetector:
    """Detect duplicate and similar assets."""

    def __init__(self, similarity_threshold: float = 0.95):
        self.similarity_threshold = similarity_threshold
        self.hash_index: dict[str, list[str]] = defaultdict(list)
        self.size_index: dict[int, list[str]] = defaultdict(list)
        self.name_index: dict[str, list[str]] = defaultdict(list)

    def detect_duplicates(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect all types of duplicates across assets."""
        self._build_indices(assets)

        groups: list[DuplicateGroup] = []
        groups.extend(self._detect_exact_duplicates(assets))
        groups.extend(self._detect_scaled_copies(assets))
        groups.extend(self._detect_format_variants(assets))
        groups.extend(self._detect_color_variants(assets))
        groups.extend(self._detect_name_variants(assets))

        return self._deduplicate_groups(groups)

    def _build_indices(self, assets: list[ExtractedAsset]) -> None:
        """Build lookup indices for efficient duplicate detection."""
        for asset in assets:
            if asset.hash_sha256:
                self.hash_index[asset.hash_sha256].append(asset.name)

            size_key = len(asset.data)
            self.size_index[size_key].append(asset.name)

            # Normalized name for variant detection
            normalized = self._normalize_name(asset.name)
            self.name_index[normalized].append(asset.name)

    def _detect_exact_duplicates(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect byte-for-byte identical assets."""
        groups = []
        asset_map = {a.name: a for a in assets}

        for sha, names in self.hash_index.items():
            if len(names) > 1:
                groups.append(DuplicateGroup(
                    duplicate_type=DuplicateType.EXACT,
                    assets=names,
                    primary=names[0],
                    confidence=1.0,
                ))

        return groups

    def _detect_scaled_copies(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect images that are scaled versions of each other."""
        groups = []

        # Group by similar file sizes (within 20%)
        size_groups: dict[int, list[str]] = defaultdict(list)
        for asset in assets:
            if asset.width > 0 and asset.height > 0:
                # Use aspect ratio bucket
                aspect = asset.width / asset.height
                bucket = round(aspect * 10)
                size_groups[bucket].append(asset.name)

        asset_map = {a.name: a for a in assets}

        for bucket, names in size_groups.items():
            if len(names) < 2:
                continue

            for i in range(len(names)):
                for j in range(i + 1, len(names)):
                    a1 = asset_map.get(names[i])
                    a2 = asset_map.get(names[j])
                    if not a1 or not a2:
                        continue

                    # Check if one is a scaled version
                    w1, h1 = a1.width, a1.height
                    w2, h2 = a2.width, a2.height

                    if w1 > 0 and h1 > 0 and w2 > 0 and h2 > 0:
                        ratio = (w1 / w2 + h1 / h2) / 2
                        if 0.4 < ratio < 0.6 or 1.8 < ratio < 2.2:
                            groups.append(DuplicateGroup(
                                duplicate_type=DuplicateType.SCALED,
                                assets=[names[i], names[j]],
                                primary=names[i] if w1 > w2 else names[j],
                                confidence=0.8,
                            ))

        return groups

    def _detect_format_variants(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect same image in different file formats."""
        groups = []
        asset_map = {a.name: a for a in assets}

        # Group by normalized name
        for normalized, names in self.name_index.items():
            if len(names) < 2:
                continue

            # Check if they have different extensions
            extensions = set()
            for name in names:
                ext = name.rsplit(".", 1)[-1].lower() if "." in name else ""
                extensions.add(ext)

            if len(extensions) > 1:
                groups.append(DuplicateGroup(
                    duplicate_type=DuplicateType.FORMAT_DIFF,
                    assets=names,
                    primary=names[0],
                    confidence=0.9,
                ))

        return groups

    def _detect_color_variants(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect color variants of the same image."""
        groups = []
        asset_map = {a.name: a for a in assets}

        # Group by size
        for size, names in self.size_index.items():
            if len(names) < 2 or size < 100:
                continue

            for i in range(len(names)):
                for j in range(i + 1, len(names)):
                    a1 = asset_map.get(names[i])
                    a2 = asset_map.get(names[j])
                    if not a1 or not a2:
                        continue

                    # Similar size but different hash -> potential color variant
                    if (a1.hash_sha256 != a2.hash_sha256 and
                        a1.width == a2.width and a1.height == a2.height):
                        groups.append(DuplicateGroup(
                            duplicate_type=DuplicateType.COLOR_VARIANT,
                            assets=[names[i], names[j]],
                            primary=names[i],
                            confidence=0.5,
                        ))

        return groups

    def _detect_name_variants(self, assets: list[ExtractedAsset]) -> list[DuplicateGroup]:
        """Detect assets with variant names (e.g., with/without suffixes)."""
        groups = []
        asset_map = {a.name: a for a in assets}

        # Look for name patterns like name, name_1, name_2, name@2x
        suffix_pattern = defaultdict(list)
        for asset in assets:
            base = asset.name
            # Remove common suffixes
            import re
            base = re.sub(r'[_@-](?:\d+|[24]x|hd|sd|low|high|mobile|desktop|retina)$', '', base, flags=re.IGNORECASE)
            suffix_pattern[base].append(asset.name)

        for base, names in suffix_pattern.items():
            if len(names) > 1:
                # Check if sizes differ
                sizes = set()
                for name in names:
                    a = asset_map.get(name)
                    if a:
                        sizes.add((a.width, a.height))

                if len(sizes) > 1:
                    primary = max(names, key=lambda n: asset_map[n].width * asset_map[n].height if n in asset_map else 0)
                    groups.append(DuplicateGroup(
                        duplicate_type=DuplicateType.SCALED,
                        assets=names,
                        primary=primary,
                        confidence=0.7,
                    ))

        return groups

    def _normalize_name(self, name: str) -> str:
        """Normalize asset name for comparison."""
        import re
        normalized = name.lower()
        normalized = re.sub(r'[_.\-]?(?:png|jpg|jpeg|tga|bmp|gif|psd|tiff)$', '', normalized)
        normalized = re.sub(r'[_@-](?:\d+|[24]x|hd|sd|low|high|mobile|desktop|retina)$', '', normalized, flags=re.IGNORECASE)
        normalized = re.sub(r'[_\-]+', '_', normalized)
        return normalized.strip('_')

    def _deduplicate_groups(self, groups: list[DuplicateGroup]) -> list[DuplicateGroup]:
        """Remove overlapping duplicate groups."""
        if not groups:
            return groups

        # Sort by confidence
        groups.sort(key=lambda g: g.confidence, reverse=True)

        seen_assets: set[str] = set()
        unique_groups = []

        for group in groups:
            # Only add if at least one asset hasn't been grouped yet
            new_assets = [a for a in group.assets if a not in seen_assets]
            if len(new_assets) >= 2 or (len(new_assets) == 1 and len(group.assets) > 1):
                unique_groups.append(group)
                seen_assets.update(group.assets)

        return unique_groups

    def generate_report(self, groups: list[DuplicateGroup]) -> dict:
        """Generate a duplicate detection report."""
        type_counts = defaultdict(int)
        total_duplicates = 0

        for group in groups:
            type_counts[group.duplicate_type.value] += 1
            total_duplicates += len(group.assets) - 1

        return {
            "total_duplicate_groups": len(groups),
            "total_duplicate_assets": total_duplicates,
            "type_distribution": dict(type_counts),
            "groups": [
                {
                    "type": g.duplicate_type.value,
                    "primary": g.primary,
                    "variants": g.assets,
                    "confidence": g.confidence,
                }
                for g in groups
            ],
        }
