"""Asset relationship engine - maps dependencies between assets."""

from __future__ import annotations

import re
from typing import Any, Optional
from collections import defaultdict

from .models import (
    ExtractedAsset, AssetRelationship, ExtractedSprite,
    UnityVersion,
)


class AssetRelationshipEngine:
    """Analyze and map relationships between all extracted assets."""

    def __init__(self):
        self.relationships: list[AssetRelationship] = []
        self.reference_map: dict[str, list[str]] = defaultdict(list)
        self.dependency_map: dict[str, list[str]] = defaultdict(list)
        self.reverse_dependency_map: dict[str, list[str]] = defaultdict(list)
        self.asset_index: dict[str, ExtractedAsset] = {}
        self.name_to_guid: dict[str, str] = {}
        self.guid_to_name: dict[str, str] = {}

    def build_index(self, assets: list[ExtractedAsset]) -> None:
        """Build lookup indices for all assets."""
        for asset in assets:
            self.asset_index[asset.name] = asset
            if asset.guid:
                self.name_to_guid[asset.name] = asset.guid
                self.guid_to_name[asset.guid] = asset.name

    def analyze_relationships(self, assets: list[ExtractedAsset],
                              recovered_classes: list[Any] | None = None) -> list[AssetRelationship]:
        """Analyze all assets and determine their relationships."""
        self.build_index(assets)

        # Use type-based and name-based analysis (fast)
        self._analyze_type_relationships(assets)
        self._analyze_name_patterns(assets)

        # Only do binary scanning for small datasets or specific asset types
        small_assets = [a for a in assets if len(a.data) < 100000 and a.asset_type in
                        ("Prefab", "Scene", "Material", "AnimatorController", "ScriptableObject")]
        for asset in small_assets[:500]:  # Limit binary scanning
            self._analyze_asset_references(asset, assets)

        if recovered_classes:
            self._analyze_class_relationships(assets, recovered_classes)

        self._deduplicate_relationships()
        self._build_reverse_map()

        return self.relationships

    def _analyze_asset_references(self, asset: ExtractedAsset, all_assets: list[ExtractedAsset]) -> None:
        """Analyze direct references between assets."""
        # Only scan text-decodable data
        try:
            data = asset.data.decode('utf-8', errors='replace')
        except Exception:
            return

        # Look for GUID references in serialized data
        import re
        guid_pattern = re.compile(r'[0-9a-f]{32}')
        found_guids = guid_pattern.findall(data)[:20]  # Limit

        for guid in found_guids:
            if guid in self.guid_to_name:
                target_name = self.guid_to_name[guid]
                self._add_relationship(asset.name, target_name, "guid_reference")

        # Only check name references for small asset lists
        if len(all_assets) <= 1000:
            for other in all_assets:
                if other.name == asset.name:
                    continue
                if other.name.encode() in asset.data[:100000]:  # Only scan first 100KB
                    rel_type = self._infer_relationship_type(asset, other)
                    self._add_relationship(asset.name, other.name, rel_type)

    def _analyze_name_patterns(self, assets: list[ExtractedAsset]) -> None:
        """Analyze naming patterns to find relationships."""
        # Group assets by base name for efficient matching
        import re

        # Build base name index
        base_names: dict[str, list[ExtractedAsset]] = {}
        for asset in assets:
            base = re.sub(r'\.(png|jpg|jpeg|tga|bmp|prefab|mat|asset|controller|anim)$',
                         '', asset.name.lower())
            if base not in base_names:
                base_names[base] = []
            base_names[base].append(asset)

        # Find same-base-name relationships
        for base, group in base_names.items():
            if len(group) > 1 and len(group) <= 20:
                for i in range(len(group)):
                    for j in range(i + 1, len(group)):
                        self._add_relationship(
                            group[i].name, group[j].name,
                            "same_asset_different_format"
                        )

        # Find atlas-sprite relationships
        atlas_assets = [a for a in assets if a.asset_type == "SpriteAtlas"]
        sprite_assets = [a for a in assets if a.asset_type == "Sprite"]
        for atlas in atlas_assets:
            for sprite in sprite_assets:
                if atlas.name.lower() in sprite.name.lower() or sprite.name.lower().startswith(atlas.name.lower()):
                    self._add_relationship(atlas.name, sprite.name, "atlas_contains_sprite")

    def _analyze_path_relationships(self, asset: ExtractedAsset, all_assets: list[ExtractedAsset]) -> None:
        """Analyze relationships based on file paths."""
        asset_dir = str(Path(asset.path).parent).lower() if asset.path else ""

        for other in all_assets:
            if other.name == asset.name:
                continue

            other_dir = str(Path(other.path).parent).lower() if other.path else ""

            # Same directory implies related assets
            if asset_dir and other_dir and asset_dir == other_dir:
                self._add_relationship(asset.name, other.name, "same_directory")

    def _analyze_type_relationships(self, assets: list[ExtractedAsset]) -> None:
        """Analyze relationships based on asset types."""
        # Group assets by type
        type_groups: dict[str, list[str]] = {}
        for asset in assets:
            if asset.asset_type not in type_groups:
                type_groups[asset.asset_type] = []
            type_groups[asset.asset_type].append(asset.name)

        # Scene references many types
        for scene_name in type_groups.get("Scene", [])[:50]:
            for pref_name in type_groups.get("Prefab", [])[:100]:
                self._add_relationship(scene_name, pref_name, "scene_instantiates_prefab")

        # Prefab references components
        for prefab_name in type_groups.get("Prefab", [])[:100]:
            for mat_name in type_groups.get("Material", [])[:100]:
                self._add_relationship(prefab_name, mat_name, "prefab_uses_material")
            for mesh_name in type_groups.get("Mesh", [])[:50]:
                self._add_relationship(prefab_name, mesh_name, "prefab_uses_mesh")

        # Material references shaders
        for mat_name in type_groups.get("Material", [])[:100]:
            for shader_name in type_groups.get("Shader", [])[:50]:
                self._add_relationship(mat_name, shader_name, "material_uses_shader")

        # AnimatorController references animations
        for ctrl_name in type_groups.get("AnimatorController", [])[:50]:
            for clip_name in type_groups.get("AnimationClip", [])[:200]:
                self._add_relationship(ctrl_name, clip_name, "controller_references_clip")
            for avatar_name in type_groups.get("Avatar", [])[:50]:
                self._add_relationship(ctrl_name, avatar_name, "controller_references_avatar")

    def _analyze_cross_references(self, asset: ExtractedAsset, all_assets: list[ExtractedAsset]) -> None:
        """Cross-reference assets using multiple strategies."""
        # Check serialized data for path-based references
        if asset.data:
            try:
                text = asset.data.decode('utf-8', errors='replace')
                # Look for asset paths like "assets/..."
                path_refs = re.findall(r'(?i)assets/[\w/.-]+\.(?:png|jpg|mat|prefab|shader|controller|anim)', text)
                for ref in path_refs:
                    ref_name = Path(ref).stem
                    for other in all_assets:
                        if other.name.lower() == ref_name.lower():
                            self._add_relationship(asset.name, other.name, "path_reference")
            except Exception:
                pass

    def _analyze_class_relationships(self, assets: list[ExtractedAsset],
                                     recovered_classes: list[Any]) -> None:
        """Analyze relationships between assets and recovered IL2CPP classes."""
        for cls in recovered_classes:
            cls_name = getattr(cls, 'name', '') or getattr(cls, 'class_name', '')
            if not cls_name:
                continue

            # Check if class name matches any asset
            for asset in assets:
                if cls_name.lower() in asset.name.lower():
                    self._add_relationship(asset.name, cls_name, "class_references_asset")

                # Check fields for asset references
                fields = getattr(cls, 'fields', [])
                for field in fields:
                    field_name = getattr(field, 'name', '') or str(field)
                    if asset.name.lower() in field_name.lower():
                        self._add_relationship(cls_name, asset.name, "class_field_references_asset")

    def _infer_relationship_type(self, source: ExtractedAsset, target: ExtractedAsset) -> str:
        """Infer the type of relationship between two assets."""
        source_type = source.asset_type
        target_type = target.asset_type

        relationship_map = {
            ("Prefab", "Texture2D"): "prefab_uses_texture",
            ("Prefab", "Material"): "prefab_uses_material",
            ("Prefab", "Mesh"): "prefab_uses_mesh",
            ("Prefab", "AnimationClip"): "prefab_uses_animation",
            ("Prefab", "AnimatorController"): "prefab_uses_animator",
            ("Scene", "Prefab"): "scene_instantiates_prefab",
            ("Scene", "Texture2D"): "scene_uses_texture",
            ("Material", "Texture2D"): "material_uses_texture",
            ("Material", "Shader"): "material_uses_shader",
            ("AnimatorController", "AnimationClip"): "controller_references_clip",
            ("AnimatorController", "Avatar"): "controller_references_avatar",
            ("SpriteAtlas", "Sprite"): "atlas_contains_sprite",
        }

        return relationship_map.get((source_type, target_type), "related")

    def _add_relationship(self, source: str, target: str, rel_type: str) -> None:
        """Add a relationship between two assets."""
        self.relationships.append(AssetRelationship(
            source=source,
            target=target,
            relationship_type=rel_type,
        ))

    def _deduplicate_relationships(self) -> None:
        """Remove duplicate relationships."""
        seen = set()
        unique = []
        for rel in self.relationships:
            key = (rel.source, rel.target, rel.relationship_type)
            if key not in seen:
                seen.add(key)
                unique.append(rel)
        self.relationships = unique

    def _build_reverse_map(self) -> None:
        """Build reverse dependency map."""
        for rel in self.relationships:
            self.dependency_map[rel.source].append(rel.target)
            self.reverse_dependency_map[rel.target].append(rel.source)
            self.reference_map[rel.target].append(rel.source)

    def get_references_to(self, asset_name: str) -> list[str]:
        """Get all assets that reference a given asset."""
        return list(set(self.reverse_dependency_map.get(asset_name, []) +
                       self.reference_map.get(asset_name, [])))

    def get_dependencies_of(self, asset_name: str) -> list[str]:
        """Get all assets that a given asset depends on."""
        return list(set(self.dependency_map.get(asset_name, [])))

    def get_relationship_summary(self) -> dict[str, Any]:
        """Get a summary of all relationships."""
        type_counts: dict[str, int] = defaultdict(int)
        for rel in self.relationships:
            type_counts[rel.relationship_type] += 1

        return {
            "total_relationships": len(self.relationships),
            "type_distribution": dict(type_counts),
            "most_referenced": self._get_most_referenced(10),
            "most_referencing": self._get_most_referencing(10),
        }

    def _get_most_referenced(self, limit: int = 10) -> list[tuple[str, int]]:
        """Get the most referenced assets."""
        ref_counts: dict[str, int] = defaultdict(int)
        for rel in self.relationships:
            ref_counts[rel.target] += 1

        sorted_refs = sorted(ref_counts.items(), key=lambda x: x[1], reverse=True)
        return sorted_refs[:limit]

    def _get_most_referencing(self, limit: int = 10) -> list[tuple[str, int]]:
        """Get assets that reference the most other assets."""
        ref_counts: dict[str, int] = defaultdict(int)
        for rel in self.relationships:
            ref_counts[rel.source] += 1

        sorted_refs = sorted(ref_counts.items(), key=lambda x: x[1], reverse=True)
        return sorted_refs[:limit]

    def export_reference_map(self) -> dict[str, dict[str, list[str]]]:
        """Export the full reference map."""
        result = {}
        for rel in self.relationships:
            if rel.source not in result:
                result[rel.source] = {"referenced_by": [], "references": []}
            result[rel.source]["references"].append(rel.target)

            if rel.target not in result:
                result[rel.target] = {"referenced_by": [], "references": []}
            result[rel.target]["referenced_by"].append(rel.source)

        return result


from pathlib import Path
