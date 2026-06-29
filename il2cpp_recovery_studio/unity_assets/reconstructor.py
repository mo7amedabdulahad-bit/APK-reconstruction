"""Project reconstruction engine - builds the RecoveredProject directory."""

from __future__ import annotations

import json
import shutil
from pathlib import Path
from typing import Any

from .models import (
    ExtractedAsset, ExtractedSprite, AssetRelationship, DuplicateGroup,
    ReconstructionResult, AssetCategory, SpriteClassification,
)
from .features import GameFeatureGrouper
from .relationships import AssetRelationshipEngine
from .categorizer import AssetCategorizer
from .duplicates import DuplicateDetector


class ProjectReconstructor:
    """Reconstruct Unity project directory structure from extracted assets."""

    def __init__(self, output_dir: Path):
        self.output_dir = output_dir
        self.grouper = GameFeatureGrouper()
        self.relationship_engine = AssetRelationshipEngine()
        self.categorizer = AssetCategorizer()
        self.duplicate_detector = DuplicateDetector()

    def reconstruct(self, result: ReconstructionResult) -> Path:
        """Full project reconstruction pipeline."""
        # 1. Categorize all assets
        for asset in result.assets:
            self.categorizer.categorize(asset)

        # 2. Build feature groups
        feature_groups = self.grouper.group_assets(result.assets)

        # 3. Analyze relationships
        self.relationship_engine.analyze_relationships(result.assets)

        # 4. Detect duplicates
        result.duplicates = self.duplicate_detector.detect_duplicates(result.assets)
        result.duplicates_found = len(result.duplicates)

        # 5. Build directory structure
        self._build_project_structure(result, feature_groups)

        # 6. Generate metadata files
        self._generate_metadata(result)

        # 7. Generate sprite metadata
        self._generate_sprite_metadata(result)

        # 8. Generate reference map
        self._generate_reference_map(result)

        # 9. Generate duplicate report
        self._generate_duplicate_report(result)

        # 10. Generate search index
        self._generate_search_index(result)

        # 11. Generate HTML gallery
        self._generate_html_gallery(result)

        # 12. Generate documentation
        self._generate_documentation(result)

        return self.output_dir

    def _build_project_structure(self, result: ReconstructionResult,
                                  feature_groups: dict[str, dict[str, list[ExtractedAsset]]]) -> None:
        """Build the RecoveredProject directory structure."""
        for feature, subcats in feature_groups.items():
            feature_dir = self.output_dir / feature

            for subcat, assets in subcats.items():
                subcat_dir = feature_dir / subcat
                subcat_dir.mkdir(parents=True, exist_ok=True)

                for asset in assets:
                    self._write_asset(asset, subcat_dir, feature)

        # Also write any uncategorized assets
        categorized_names = set()
        for feature in feature_groups.values():
            for subcat in feature.values():
                for asset in subcat:
                    categorized_names.add(asset.name)

        uncategorized_dir = self.output_dir / "General"
        for asset in result.assets:
            if asset.name not in categorized_names:
                cat_dir = uncategorized_dir / asset.category.value
                cat_dir.mkdir(parents=True, exist_ok=True)
                self._write_asset(asset, cat_dir, "General")

    def _write_asset(self, asset: ExtractedAsset, target_dir: Path, feature: str) -> None:
        """Write an asset to the target directory."""
        # Determine filename
        filename = self._sanitize_filename(asset.name)
        if not Path(filename).suffix and asset.asset_type:
            ext = self._get_extension_for_type(asset.asset_type)
            if ext:
                filename += ext

        target_path = target_dir / filename

        # Handle name conflicts
        counter = 1
        while target_path.exists():
            stem = target_path.stem
            suffix = target_path.suffix
            target_path = target_dir / f"{stem}_{counter}{suffix}"
            counter += 1

        # Write the file
        if asset.data:
            try:
                target_path.write_bytes(asset.data)
                asset.file_path = target_path
            except Exception:
                pass

    def _sanitize_filename(self, name: str) -> str:
        """Sanitize a filename for the filesystem."""
        # Replace invalid characters
        invalid = '<>:"/\\|?*'
        for ch in invalid:
            name = name.replace(ch, "_")
        # Limit length
        if len(name) > 200:
            name = name[:200]
        return name

    def _get_extension_for_type(self, asset_type: str) -> str:
        """Get file extension for an asset type."""
        type_ext_map = {
            "Texture2D": ".png",
            "Sprite": ".png",
            "Material": ".mat",
            "Prefab": ".prefab",
            "Scene": ".unity",
            "AudioClip": ".wav",
            "Font": ".ttf",
            "Shader": ".shader",
            "AnimationClip": ".anim",
            "AnimatorController": ".controller",
            "ScriptableObject": ".asset",
            "MonoBehaviour": ".cs",
            "TextAsset": ".txt",
            "AssetBundle": ".bundle",
            "VideoClip": ".mp4",
            "Mesh": ".fbx",
            "RenderTexture": ".renderTexture",
            "SpriteAtlas": ".spriteatlas",
        }
        return type_ext_map.get(asset_type, "")

    def _generate_metadata(self, result: ReconstructionResult) -> None:
        """Generate AssetMetadata.json."""
        metadata = {
            "total_assets": result.total_assets,
            "unity_version": result.unity_version.value,
            "categories": result.categories,
            "feature_groups": result.feature_groups,
            "duplicates_found": result.duplicates_found,
            "relationships_mapped": result.relationships_mapped,
            "assets": [],
        }

        for asset in result.assets:
            asset_meta = {
                "name": asset.name,
                "type": asset.asset_type,
                "category": asset.category.value,
                "subcategory": asset.subcategory,
                "feature_group": asset.feature_group,
                "path": asset.path,
                "guid": asset.guid,
                "width": asset.width,
                "height": asset.height,
                "size": len(asset.data),
                "hash_md5": asset.hash_md5,
                "hash_sha256": asset.hash_sha256,
                "confidence": asset.confidence,
                "metadata": asset.metadata,
                "dependencies": asset.dependencies,
                "referenced_by": asset.referenced_by,
                "scenes": asset.scenes,
                "prefabs": asset.prefabs,
                "classes": asset.classes,
            }
            metadata["assets"].append(asset_meta)

        out_path = self.output_dir / "AssetMetadata.json"
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(metadata, f, indent=2, ensure_ascii=False)

    def _generate_sprite_metadata(self, result: ReconstructionResult) -> None:
        """Generate sprite metadata files."""
        if not result.sprites:
            return

        sprites_dir = self.output_dir / "SpriteMetadata"
        sprites_dir.mkdir(exist_ok=True)

        for sprite in result.sprites:
            meta = {
                "name": sprite.name,
                "atlas_name": sprite.atlas_name,
                "width": sprite.width,
                "height": sprite.height,
                "pivot": {"x": sprite.pivot_x, "y": sprite.pivot_y},
                "border": {
                    "left": sprite.border_left,
                    "bottom": sprite.border_bottom,
                    "right": sprite.border_right,
                    "top": sprite.border_top,
                },
                "rotation": sprite.rotation,
                "packing_mode": sprite.packing_mode,
                "packing_tag": sprite.packing_tag,
                "pixels_per_unit": sprite.pixels_per_unit,
                "guid": sprite.guid,
                "classification": sprite.classification.value,
                "metadata": sprite.metadata,
                "dependencies": sprite.dependencies,
                "referenced_by": sprite.referenced_by,
            }

            out_path = sprites_dir / f"{sprite.name}.json"
            with open(out_path, "w", encoding="utf-8") as f:
                json.dump(meta, f, indent=2, ensure_ascii=False)

            # Also write the sprite image
            if sprite.image_data:
                img_path = sprites_dir / f"{sprite.name}.png"
                with open(img_path, "wb") as f:
                    f.write(sprite.image_data)

    def _generate_reference_map(self, result: ReconstructionResult) -> None:
        """Generate AssetReferences.json."""
        ref_map = self.relationship_engine.export_reference_map()

        # Enrich with relationship data
        enriched = {}
        for name, refs in ref_map.items():
            enriched[name] = {
                "referenced_by": refs["referenced_by"],
                "references": refs["references"],
                "relationship_types": [],
            }

        for rel in result.relationships:
            if rel.source in enriched:
                enriched[rel.source]["relationship_types"].append({
                    "target": rel.target,
                    "type": rel.relationship_type,
                })

        out_path = self.output_dir / "AssetReferences.json"
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(enriched, f, indent=2, ensure_ascii=False)

    def _generate_duplicate_report(self, result: ReconstructionResult) -> None:
        """Generate DuplicateReport.json."""
        report = self.duplicate_detector.generate_report(result.duplicates)

        out_path = self.output_dir / "DuplicateReport.json"
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(report, f, indent=2, ensure_ascii=False)

    def _generate_search_index(self, result: ReconstructionResult) -> None:
        """Generate SearchIndex.json for fast searching."""
        index = {
            "assets": {},
            "by_type": {},
            "by_category": {},
            "by_feature": {},
            "by_name": {},
            "by_guid": {},
        }

        for asset in result.assets:
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
            }

            index["assets"][asset.name] = entry

            # Type index
            if asset.asset_type not in index["by_type"]:
                index["by_type"][asset.asset_type] = []
            index["by_type"][asset.asset_type].append(asset.name)

            # Category index
            if asset.category.value not in index["by_category"]:
                index["by_category"][asset.category.value] = []
            index["by_category"][asset.category.value].append(asset.name)

            # Feature index
            if asset.feature_group not in index["by_feature"]:
                index["by_feature"][asset.feature_group] = []
            index["by_feature"][asset.feature_group].append(asset.name)

            # Name index (first 3 chars)
            prefix = asset.name[:3].lower()
            if prefix not in index["by_name"]:
                index["by_name"][prefix] = []
            index["by_name"][prefix].append(asset.name)

            # GUID index
            if asset.guid:
                index["by_guid"][asset.guid] = asset.name

        out_path = self.output_dir / "SearchIndex.json"
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(index, f, indent=2, ensure_ascii=False)

    def _generate_html_gallery(self, result: ReconstructionResult) -> None:
        """Generate an HTML gallery for visual browsing."""
        assets_with_images = [a for a in result.assets
                              if a.data[:8] == b'\x89PNG\r\n\x1a\n'
                              or a.data[:3] == b'\xff\xd8\xff'
                              or a.asset_type in ("Texture2D", "Sprite")]

        html = self._build_gallery_html(assets_with_images, result)

        out_path = self.output_dir / "Gallery.html"
        with open(out_path, "w", encoding="utf-8") as f:
            f.write(html)

    def _build_gallery_html(self, assets: list[ExtractedAsset], result: ReconstructionResult) -> str:
        """Build HTML gallery content."""
        categories_html = ""
        for cat in AssetCategory:
            cat_assets = [a for a in assets if a.category == cat]
            if not cat_assets:
                continue

            cards = ""
            for asset in cat_assets[:50]:  # Limit per category
                data_b64 = ""
                if asset.data[:8] == b'\x89PNG\r\n\x1a\n' or asset.data[:3] == b'\xff\xd8\xff':
                    import base64
                    data_b64 = base64.b64encode(asset.data).decode()

                img_tag = ""
                if data_b64:
                    mime = "image/png" if asset.data[:8] == b'\x89PNG\r\n\x1a\n' else "image/jpeg"
                    img_tag = f'<img src="data:{mime};base64,{data_b64}" alt="{asset.name}" loading="lazy">'

                cards += f'''
                <div class="card" data-name="{asset.name}" data-type="{asset.asset_type}"
                     data-category="{cat.value}" data-feature="{asset.feature_group}">
                    <div class="card-img">{img_tag if img_tag else '<div class="placeholder">No Preview</div>'}</div>
                    <div class="card-info">
                        <h3>{asset.name}</h3>
                        <p>Type: {asset.asset_type}</p>
                        <p>Feature: {asset.feature_group}</p>
                        <p>Size: {asset.width}x{asset.height}</p>
                    </div>
                </div>'''

            categories_html += f'''
            <div class="category" id="cat-{cat.value}">
                <h2>{cat.value} ({len(cat_assets)})</h2>
                <div class="grid">{cards}</div>
            </div>'''

        return f'''<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Recovered Unity Assets Gallery</title>
<style>
* {{ margin: 0; padding: 0; box-sizing: border-box; }}
body {{ font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, sans-serif;
       background: #1e1e2e; color: #cdd6f4; }}
.header {{ background: #181825; padding: 20px; text-align: center;
           border-bottom: 2px solid #89b4fa; }}
.header h1 {{ color: #89b4fa; margin-bottom: 10px; }}
.search-bar {{ padding: 15px; background: #11111b; position: sticky; top: 0; z-index: 100; }}
.search-bar input {{ width: 100%; padding: 10px 20px; border-radius: 8px;
                     border: 1px solid #45475a; background: #1e1e2e; color: #cdd6f4;
                     font-size: 16px; }}
.filter-bar {{ display: flex; gap: 10px; padding: 10px 15px; flex-wrap: wrap; }}
.filter-btn {{ padding: 6px 14px; border-radius: 20px; border: 1px solid #45475a;
               background: #1e1e2e; color: #cdd6f4; cursor: pointer; font-size: 13px; }}
.filter-btn.active {{ background: #89b4fa; color: #1e1e2e; border-color: #89b4fa; }}
.category {{ padding: 20px; }}
.category h2 {{ color: #a6e3a1; margin-bottom: 15px; font-size: 1.3em; }}
.grid {{ display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
         gap: 15px; }}
.card {{ background: #181825; border-radius: 10px; overflow: hidden;
         border: 1px solid #313244; transition: transform 0.2s; cursor: pointer; }}
.card:hover {{ transform: translateY(-3px); border-color: #89b4fa; }}
.card-img {{ width: 100%; height: 150px; display: flex; align-items: center;
             justify-content: center; background: #11111b; overflow: hidden; }}
.card-img img {{ max-width: 100%; max-height: 100%; object-fit: contain; }}
.placeholder {{ color: #6c7086; font-size: 12px; }}
.card-info {{ padding: 10px; }}
.card-info h3 {{ font-size: 0.85em; color: #cdd6f4; margin-bottom: 5px;
                overflow: hidden; text-overflow: ellipsis; white-space: nowrap; }}
.card-info p {{ font-size: 0.75em; color: #6c7086; }}
.stats {{ padding: 15px; background: #181825; margin: 10px 15px; border-radius: 8px; }}
.stats span {{ margin-right: 20px; color: #f9e2af; }}
.modal {{ display: none; position: fixed; top: 0; left: 0; width: 100%; height: 100%;
          background: rgba(0,0,0,0.9); z-index: 200; align-items: center; justify-content: center; }}
.modal.active {{ display: flex; }}
.modal-content {{ background: #1e1e2e; border-radius: 12px; max-width: 800px; width: 90%;
                  max-height: 90vh; overflow-y: auto; padding: 20px; }}
.modal-content img {{ max-width: 100%; border-radius: 8px; }}
.modal-info {{ margin-top: 15px; }}
.modal-info p {{ margin: 5px 0; }}
.close {{ position: absolute; top: 20px; right: 30px; color: #fff; font-size: 30px;
          cursor: pointer; }}
</style>
</head>
<body>
<div class="header">
    <h1>Recovered Unity Assets Gallery</h1>
    <p>Total: {result.total_assets} assets | Categories: {len(result.categories)} | Features: {len(result.feature_groups)}</p>
</div>
<div class="search-bar">
    <input type="text" id="searchInput" placeholder="Search assets by name, type, category, feature..." oninput="filterAssets()">
</div>
<div class="filter-bar" id="filterBar">
    <button class="filter-btn active" onclick="filterByCategory('all')">All</button>
</div>
<div class="stats">
    <span>Assets: {result.total_assets}</span>
    <span>Sprites: {result.total_sprites_extracted}</span>
    <span>Duplicates: {result.duplicates_found}</span>
    <span>Relationships: {result.relationships_mapped}</span>
</div>
<div id="gallery">{categories_html}</div>
<div class="modal" id="modal" onclick="closeModal()">
    <span class="close">&times;</span>
    <div class="modal-content" id="modalContent"></div>
</div>
<script>
const categories = {json.dumps([c.value for c in AssetCategory if any(a.category == c for a in assets)])};
const filterBar = document.getElementById('filterBar');
categories.forEach(cat => {{
    const btn = document.createElement('button');
    btn.className = 'filter-btn';
    btn.textContent = cat;
    btn.onclick = () => filterByCategory(cat);
    filterBar.appendChild(btn);
}});

function filterAssets() {{
    const query = document.getElementById('searchInput').value.toLowerCase();
    document.querySelectorAll('.card').forEach(card => {{
        const name = card.dataset.name.toLowerCase();
        const type = card.dataset.type.toLowerCase();
        const category = card.dataset.category.toLowerCase();
        const feature = card.dataset.feature.toLowerCase();
        const match = name.includes(query) || type.includes(query) ||
                     category.includes(query) || feature.includes(query);
        card.style.display = match ? '' : 'none';
    }});
}}

function filterByCategory(cat) {{
    document.querySelectorAll('.filter-btn').forEach(b => b.classList.remove('active'));
    event.target.classList.add('active');
    document.querySelectorAll('.category').forEach(section => {{
        section.style.display = (cat === 'all' || section.id === 'cat-' + cat) ? '' : 'none';
    }});
    document.querySelectorAll('.card').forEach(card => {{
        card.style.display = (cat === 'all' || card.dataset.category === cat) ? '' : 'none';
    }});
}}

document.querySelectorAll('.card').forEach(card => {{
    card.onclick = () => {{
        const modal = document.getElementById('modal');
        const content = document.getElementById('modalContent');
        const img = card.querySelector('img');
        content.innerHTML = `
            <h2>${{card.dataset.name}}</h2>
            ${{img ? '<img src="' + img.src + '">' : '<p>No preview</p>'}}
            <div class="modal-info">
                <p><b>Type:</b> ${{card.dataset.type}}</p>
                <p><b>Category:</b> ${{card.dataset.category}}</p>
                <p><b>Feature:</b> ${{card.dataset.feature}}</p>
            </div>`;
        modal.classList.add('active');
    }};
}});

function closeModal() {{
    document.getElementById('modal').classList.remove('active');
}}
</script>
</body>
</html>'''

    def _generate_documentation(self, result: ReconstructionResult) -> None:
        """Generate comprehensive documentation."""
        doc_dir = self.output_dir / "Documentation"
        doc_dir.mkdir(exist_ok=True)

        # Generate per-feature documentation
        for feature, subcats in self.grouper.feature_groups.items():
            feature_doc = self._generate_feature_doc(feature, subcats, result)
            doc_path = doc_dir / f"{feature}.md"
            with open(doc_path, "w", encoding="utf-8") as f:
                f.write(feature_doc)

        # Generate main README
        readme = self._generate_readme(result)
        readme_path = doc_dir / "README.md"
        with open(readme_path, "w", encoding="utf-8") as f:
            f.write(readme)

        # Generate relationship documentation
        rel_doc = self._generate_relationship_doc(result)
        rel_path = doc_dir / "Relationships.md"
        with open(rel_path, "w", encoding="utf-8") as f:
            f.write(rel_doc)

    def _generate_feature_doc(self, feature: str,
                               subcats: dict[str, list[ExtractedAsset]],
                               result: ReconstructionResult) -> str:
        """Generate documentation for a single feature."""
        lines = [
            f"# {feature}",
            "",
            f"**Total Assets:** {sum(len(a) for a in subcats.values())}",
            "",
            "## Contents",
            "",
        ]

        for subcat, assets in subcats.items():
            lines.append(f"### {subcat} ({len(assets)})")
            lines.append("")
            for asset in assets[:20]:
                lines.append(f"- **{asset.name}** ({asset.asset_type}) - {asset.width}x{asset.height}")
            if len(assets) > 20:
                lines.append(f"- ... and {len(assets) - 20} more")
            lines.append("")

        return "\n".join(lines)

    def _generate_readme(self, result: ReconstructionResult) -> str:
        """Generate main README documentation."""
        return f"""# Recovered Unity Project

## Overview

- **Unity Version:** {result.unity_version.value}
- **Total Assets:** {result.total_assets}
- **Sprites Extracted:** {result.total_sprites_extracted}
- **Duplicates Found:** {result.duplicates_found}
- **Relationships Mapped:** {result.relationships_mapped}

## Categories

| Category | Count |
|----------|-------|
{chr(10).join(f"| {k} | {v} |" for k, v in sorted(result.categories.items()))}

## Feature Groups

| Feature | Assets |
|---------|--------|
{chr(10).join(f"| {k} | {v} |" for k, v in sorted(result.feature_groups.items()))}

## Directory Structure

```
RecoveredProject/
├── Characters/       # Heroes, units, NPCs, enemies
├── Buildings/        # Village structures
├── Resources/        # Wood, clay, iron, crop icons
├── UI/               # Buttons, panels, HUD elements
├── World/            # Maps, terrain, backgrounds
├── Audio/            # Music, SFX, voice
├── Effects/          # Particles, VFX
├── Loading/          # Loading screens, logos
├── General/          # Uncategorized assets
├── SpriteMetadata/   # Individual sprite metadata
├── Documentation/    # This documentation
├── AssetMetadata.json    # Complete asset catalog
├── AssetReferences.json  # Asset relationship map
├── DuplicateReport.json  # Duplicate analysis
├── SearchIndex.json      # Search index
└── Gallery.html          # Visual asset browser
```

## Usage

- Open `Gallery.html` in a browser for visual browsing
- Use `SearchIndex.json` for programmatic searching
- Check `AssetReferences.json` for dependency mapping
- See `DuplicateReport.json` for duplicate analysis
"""

    def _generate_relationship_doc(self, result: ReconstructionResult) -> str:
        """Generate relationship documentation."""
        lines = [
            "# Asset Relationships",
            "",
            f"Total relationships mapped: {len(result.relationships)}",
            "",
            "## Most Referenced Assets",
            "",
        ]

        summary = self.relationship_engine.get_relationship_summary()
        for name, count in summary.get("most_referenced", []):
            lines.append(f"- **{name}** - referenced {count} times")

        lines.extend([
            "",
            "## Relationship Types",
            "",
        ])

        for rel_type, count in summary.get("type_distribution", {}).items():
            lines.append(f"- **{rel_type}**: {count}")

        return "\n".join(lines)
