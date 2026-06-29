"""Unity Asset Reconstruction Engine - Phase 21.

Intelligent Unity asset reconstruction from APK/XAPK files.
Reconstructs project structure, extracts sprites, classifies assets,
maps relationships, and generates browsable documentation.
"""

from .models import (
    ExtractedAsset, ExtractedSprite, AssetCategory, SpriteClassification,
    DuplicateGroup, DuplicateType, AssetRelationship, ReconstructionResult,
    UnityVersion, SpriteRect, SpriteAtlasData,
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
from .orchestrator import UnityAssetReconstructor

__all__ = [
    "UnityAssetReconstructor",
    "APKAssetExtractor",
    "SpriteAtlasReconstructor",
    "AssetCategorizer",
    "AssetRelationshipEngine",
    "GameFeatureGrouper",
    "ImageClassifier",
    "DuplicateDetector",
    "ProjectReconstructor",
    "AssetSearchEngine",
    "DocumentationGenerator",
    "ExtractedAsset",
    "ExtractedSprite",
    "AssetCategory",
    "SpriteClassification",
    "DuplicateGroup",
    "DuplicateType",
    "AssetRelationship",
    "ReconstructionResult",
    "UnityVersion",
    "SpriteRect",
    "SpriteAtlasData",
]
