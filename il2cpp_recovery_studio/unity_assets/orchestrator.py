"""Main orchestrator for Phase 21 - Intelligent Asset Reconstruction."""

from __future__ import annotations

import time
import json
from pathlib import Path
from typing import Any, Optional

from .models import (
    ReconstructionResult, ExtractedAsset, AssetCategory,
    UnityVersion,
)
from .extractor import APKAssetExtractor
from .atlas import SpriteAtlasReconstructor
from .categorizer import AssetCategorizer
from .relationships import AssetRelationshipEngine
from .features import GameFeatureGrouper
from .classifier import ImageClassifier
from .duplicates import DuplicateDetector
from .reconstructor import ProjectReconstructor
from .search import AssetSearchEngine
from .documentation import DocumentationGenerator


class UnityAssetReconstructor:
    """Main orchestrator for intelligent Unity asset reconstruction."""

    def __init__(self, output_dir: Path, verbose: bool = False):
        self.output_dir = output_dir
        self.verbose = verbose
        self.extractor = APKAssetExtractor()
        self.atlas_reconstructor = SpriteAtlasReconstructor()
        self.categorizer = AssetCategorizer()
        self.relationship_engine = AssetRelationshipEngine()
        self.feature_grouper = GameFeatureGrouper()
        self.image_classifier = ImageClassifier()
        self.duplicate_detector = DuplicateDetector()
        self.search_engine = AssetSearchEngine()
        self.doc_generator = DocumentationGenerator(output_dir)

    def reconstruct(self, apk_path: Path,
                    recovered_classes: list[Any] | None = None) -> ReconstructionResult:
        """Run the full reconstruction pipeline."""
        start_time = time.time()
        result = ReconstructionResult(output_path=self.output_dir)

        self._log(f"Starting Unity Asset Reconstruction for: {apk_path}")

        # Phase 1: Extract assets from APK
        self._log("Phase 1: Extracting assets from APK...")
        result = self.extractor.extract_from_apk(apk_path, self.output_dir / "raw")
        self._log(f"  Extracted {result.total_assets} assets")

        # Phase 2: Reconstruct sprite atlases
        self._log("Phase 2: Reconstructing sprite atlases...")
        self._reconstruct_sprites(result)
        self._log(f"  Extracted {result.total_sprites_extracted} individual sprites")

        # Phase 3: Classify images using CV
        self._log("Phase 3: Classifying images with computer vision...")
        self._classify_images(result)

        # Phase 4: Intelligent categorization
        self._log("Phase 4: Categorizing assets...")
        self.categorizer.categorize_batch(result.assets)
        result.categories = {}
        for asset in result.assets:
            cat = asset.category.value
            result.categories[cat] = result.categories.get(cat, 0) + 1

        # Phase 5: Game feature grouping
        self._log("Phase 5: Grouping assets by game features...")
        feature_groups = self.feature_grouper.group_assets(result.assets)
        result.feature_groups = {
            feat: sum(len(a) for a in subcats.values())
            for feat, subcats in feature_groups.items()
        }

        # Phase 6: Asset relationship mapping
        self._log("Phase 6: Mapping asset relationships...")
        self.relationship_engine.analyze_relationships(
            result.assets, recovered_classes
        )
        result.relationships = self.relationship_engine.relationships
        result.relationships_mapped = len(result.relationships)

        # Phase 7: Duplicate detection
        self._log("Phase 7: Detecting duplicates...")
        result.duplicates = self.duplicate_detector.detect_duplicates(result.assets)
        result.duplicates_found = len(result.duplicates)

        # Phase 8: Build project structure
        self._log("Phase 8: Building project structure...")
        project_reconstructor = ProjectReconstructor(self.output_dir)
        project_reconstructor.reconstruct(result)

        # Phase 9: Generate search index
        self._log("Phase 9: Generating search index...")
        self.search_engine.build_index(result.assets)
        self.search_engine.save_to_file(self.output_dir / "SearchIndex.json")

        # Phase 10: Generate documentation
        self._log("Phase 10: Generating documentation...")
        self.doc_generator.generate(result)

        # Phase 11: Generate asset metadata
        self._log("Phase 11: Writing metadata files...")
        self._write_metadata(result)

        elapsed = time.time() - start_time
        self._log(f"\nReconstruction complete in {elapsed:.1f}s")
        self._log(f"  Total assets: {result.total_assets}")
        self._log(f"  Sprites extracted: {result.total_sprites_extracted}")
        self._log(f"  Categories: {len(result.categories)}")
        self._log(f"  Feature groups: {len(result.feature_groups)}")
        self._log(f"  Relationships: {result.relationships_mapped}")
        self._log(f"  Duplicates: {result.duplicates_found}")

        return result

    def _reconstruct_sprites(self, result: ReconstructionResult) -> None:
        """Reconstruct sprites from atlases."""
        atlas_assets = [
            a for a in result.assets
            if a.asset_type in ("SpriteAtlas", "Texture2D") and
            any(k in a.name.lower() for k in ("atlas", "sheet", "spritesheet", "sprite_atlas"))
        ]

        for atlas_asset in atlas_assets:
            sprites = self.atlas_reconstructor.reconstruct_from_atlas(atlas_asset)
            result.sprites.extend(sprites)

        # Also try to reconstruct from any remaining texture assets
        texture_assets = [
            a for a in result.assets
            if a.asset_type == "Texture2D" and
            a not in atlas_assets and
            a.width > 0 and a.height > 0
        ]

        for tex_asset in texture_assets:
            # Check if metadata suggests it's a spritesheet
            if tex_asset.metadata.get("sprites"):
                sprites = self.atlas_reconstructor.reconstruct_from_spritesheet(
                    tex_asset.data, tex_asset.metadata, tex_asset.name
                )
                result.sprites.extend(sprites)

        result.total_sprites_extracted = len(result.sprites)

    def _classify_images(self, result: ReconstructionResult) -> None:
        """Classify images using computer vision."""
        image_assets = [
            a for a in result.assets
            if a.asset_type in ("Texture2D", "Sprite") and a.data
        ]

        for asset in image_assets:
            classification, confidence = self.image_classifier.classify(asset)
            asset.sprite_classification = classification
            asset.cv_confidence = confidence

    def _write_metadata(self, result: ReconstructionResult) -> None:
        """Write all metadata files."""
        # AssetMetadata.json
        metadata = {
            "unity_version": result.unity_version.value,
            "total_assets": result.total_assets,
            "categories": result.categories,
            "feature_groups": result.feature_groups,
            "duplicates_found": result.duplicates_found,
            "relationships_mapped": result.relationships_mapped,
            "assets": [
                {
                    "name": a.name,
                    "type": a.asset_type,
                    "category": a.category.value,
                    "feature_group": a.feature_group,
                    "path": a.path,
                    "guid": a.guid,
                    "width": a.width,
                    "height": a.height,
                    "size": len(a.data),
                    "hash_md5": a.hash_md5,
                    "hash_sha256": a.hash_sha256,
                    "confidence": a.confidence,
                    "cv_classification": a.sprite_classification.value,
                    "cv_confidence": a.cv_confidence,
                    "metadata": a.metadata,
                }
                for a in result.assets
            ],
        }

        with open(self.output_dir / "AssetMetadata.json", "w", encoding="utf-8") as f:
            json.dump(metadata, f, indent=2, ensure_ascii=False)

        # AssetReferences.json
        ref_map = self.relationship_engine.export_reference_map()
        with open(self.output_dir / "AssetReferences.json", "w", encoding="utf-8") as f:
            json.dump(ref_map, f, indent=2, ensure_ascii=False)

        # DuplicateReport.json
        dup_report = self.duplicate_detector.generate_report(result.duplicates)
        with open(self.output_dir / "DuplicateReport.json", "w", encoding="utf-8") as f:
            json.dump(dup_report, f, indent=2, ensure_ascii=False)

    def _log(self, message: str) -> None:
        """Log a message if verbose."""
        if self.verbose:
            print(message)
