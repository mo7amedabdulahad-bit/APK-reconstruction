"""Documentation generator for recovered assets."""

from __future__ import annotations

import json
from pathlib import Path
from typing import Any
from collections import defaultdict

from .models import (
    ExtractedAsset, ExtractedSprite, AssetRelationship,
    ReconstructionResult, AssetCategory,
)


class DocumentationGenerator:
    """Generate comprehensive documentation for all recovered assets."""

    def __init__(self, output_dir: Path):
        self.output_dir = output_dir

    def generate(self, result: ReconstructionResult) -> None:
        """Generate all documentation."""
        doc_dir = self.output_dir / "Documentation"
        doc_dir.mkdir(exist_ok=True)

        self._generate_main_readme(result, doc_dir)
        self._generate_asset_catalog(result, doc_dir)
        self._generate_category_docs(result, doc_dir)
        self._generate_feature_docs(result, doc_dir)
        self._generate_relationship_doc(result, doc_dir)
        self._generate_sprite_doc(result, doc_dir)
        self._generate_duplicate_doc(result, doc_dir)
        self._generate_html_docs(result, doc_dir)

    def _generate_main_readme(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate main README."""
        lines = [
            "# Recovered Unity Project Documentation",
            "",
            "## Overview",
            "",
            f"- **Unity Version:** {result.unity_version.value}",
            f"- **Total Assets Extracted:** {result.total_assets}",
            f"- **Sprites Extracted:** {result.total_sprites_extracted}",
            f"- **Duplicate Groups:** {result.duplicates_found}",
            f"- **Relationships Mapped:** {result.relationships_mapped}",
            "",
            "## Asset Categories",
            "",
            "| Category | Count |",
            "|----------|-------|",
        ]

        for cat, count in sorted(result.categories.items(), key=lambda x: x[1], reverse=True):
            lines.append(f"| {cat} | {count} |")

        lines.extend([
            "",
            "## Feature Groups",
            "",
            "| Feature | Count |",
            "|---------|-------|",
        ])

        for feat, count in sorted(result.feature_groups.items(), key=lambda x: x[1], reverse=True):
            lines.append(f"| {feat} | {count} |")

        lines.extend([
            "",
            "## Project Structure",
            "",
            "```",
            "RecoveredProject/",
            "├── Characters/         # Heroes, units, NPCs",
            "│   ├── Images/",
            "│   ├── Animations/",
            "│   ├── Prefabs/",
            "│   ├── Icons/",
            "│   └── Audio/",
            "├── Buildings/          # Village structures",
            "├── Resources/          # Resource icons",
            "├── UI/                 # Interface elements",
            "│   ├── Buttons/",
            "│   ├── Panels/",
            "│   ├── HUD/",
            "│   └── Icons/",
            "├── World/              # Maps, terrain",
            "├── Audio/              # Music, SFX",
            "├── Effects/            # Particles, VFX",
            "├── Loading/            # Screens, logos",
            "├── General/            # Uncategorized",
            "├── SpriteMetadata/     # Sprite JSON data",
            "├── Documentation/      # This folder",
            "├── AssetMetadata.json  # Full asset catalog",
            "├── AssetReferences.json # Reference map",
            "├── DuplicateReport.json",
            "├── SearchIndex.json",
            "└── Gallery.html        # Visual browser",
            "```",
            "",
            "## Usage",
            "",
            "### Visual Browsing",
            "Open `Gallery.html` in any web browser to visually browse all assets.",
            "",
            "### Programmatic Access",
            "- `AssetMetadata.json` - Complete metadata for all assets",
            "- `SearchIndex.json` - Pre-built search index",
            "- `AssetReferences.json` - Asset dependency graph",
            "",
            "### Search",
            "Use `SearchIndex.json` with the following structure:",
            "```json",
            '{',
            '  "by_type": {"Texture2D": ["asset1", "asset2"]},',
            '  "by_category": {"Characters": ["hero1"]},',
            '  "by_feature": {"Hero": ["hero_portrait"]}',
            '}',
            "```",
        ])

        (doc_dir / "README.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_asset_catalog(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate complete asset catalog."""
        catalog = {
            "metadata": {
                "unity_version": result.unity_version.value,
                "total_assets": result.total_assets,
                "total_sprites": result.total_sprites_extracted,
                "categories": result.categories,
                "feature_groups": result.feature_groups,
            },
            "assets": [],
        }

        for asset in result.assets:
            catalog["assets"].append({
                "name": asset.name,
                "type": asset.asset_type,
                "category": asset.category.value,
                "feature_group": asset.feature_group,
                "path": asset.path,
                "guid": asset.guid,
                "dimensions": f"{asset.width}x{asset.height}" if asset.width > 0 else "N/A",
                "file_size": len(asset.data),
                "hash_md5": asset.hash_md5,
                "hash_sha256": asset.hash_sha256,
                "confidence": asset.confidence,
                "dependencies": asset.dependencies,
                "referenced_by": asset.referenced_by,
                "scenes": asset.scenes,
                "prefabs": asset.prefabs,
                "classes": asset.classes,
                "metadata": asset.metadata,
            })

        (doc_dir / "AssetCatalog.json").write_text(
            json.dumps(catalog, indent=2, ensure_ascii=False), encoding="utf-8"
        )

    def _generate_category_docs(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate per-category documentation."""
        cat_dir = doc_dir / "Categories"
        cat_dir.mkdir(exist_ok=True)

        # Group assets by category
        by_category: dict[str, list[ExtractedAsset]] = defaultdict(list)
        for asset in result.assets:
            by_category[asset.category.value].append(asset)

        for cat_name, assets in by_category.items():
            lines = [
                f"# {cat_name}",
                "",
                f"**Total Assets:** {len(assets)}",
                "",
                "## Assets",
                "",
                "| Name | Type | Dimensions | Size | Feature |",
                "|------|------|-----------|------|---------|",
            ]

            for asset in sorted(assets, key=lambda a: a.name):
                dim = f"{asset.width}x{asset.height}" if asset.width > 0 else "N/A"
                size = f"{len(asset.data)} bytes"
                lines.append(f"| {asset.name} | {asset.asset_type} | {dim} | {size} | {asset.feature_group} |")

            (cat_dir / f"{cat_name}.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_feature_docs(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate per-feature documentation."""
        feat_dir = doc_dir / "Features"
        feat_dir.mkdir(exist_ok=True)

        by_feature: dict[str, list[ExtractedAsset]] = defaultdict(list)
        for asset in result.assets:
            by_feature[asset.feature_group].append(asset)

        for feat_name, assets in by_feature.items():
            lines = [
                f"# {feat_name}",
                "",
                f"**Total Assets:** {len(assets)}",
                "",
            ]

            # Group by subcategory
            by_subcat: dict[str, list[ExtractedAsset]] = defaultdict(list)
            for asset in assets:
                by_subcat[asset.category.value].append(asset)

            for subcat, sub_assets in sorted(by_subcat.items()):
                lines.append(f"## {subcat} ({len(sub_assets)})")
                lines.append("")
                for asset in sub_assets[:30]:
                    dim = f" ({asset.width}x{asset.height})" if asset.width > 0 else ""
                    lines.append(f"- **{asset.name}** - {asset.asset_type}{dim}")
                if len(sub_assets) > 30:
                    lines.append(f"- ... and {len(sub_assets) - 30} more")
                lines.append("")

            (feat_dir / f"{feat_name}.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_relationship_doc(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate relationship documentation."""
        lines = [
            "# Asset Relationships",
            "",
            f"**Total Relationships:** {len(result.relationships)}",
            "",
            "## Relationship Types",
            "",
        ]

        type_counts: dict[str, int] = defaultdict(int)
        for rel in result.relationships:
            type_counts[rel.relationship_type] += 1

        for rtype, count in sorted(type_counts.items(), key=lambda x: x[1], reverse=True):
            lines.append(f"- **{rtype}**: {count}")

        lines.extend([
            "",
            "## Most Referenced Assets",
            "",
        ])

        ref_counts: dict[str, int] = defaultdict(int)
        for rel in result.relationships:
            ref_counts[rel.target] += 1

        for name, count in sorted(ref_counts.items(), key=lambda x: x[1], reverse=True)[:20]:
            lines.append(f"- **{name}**: referenced by {count} assets")

        (doc_dir / "Relationships.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_sprite_doc(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate sprite documentation."""
        if not result.sprites:
            return

        lines = [
            "# Sprite Metadata",
            "",
            f"**Total Sprites Extracted:** {len(result.sprites)}",
            "",
            "## Sprites",
            "",
            "| Name | Atlas | Dimensions | Pivot | Classification |",
            "|------|-------|-----------|-------|----------------|",
        ]

        for sprite in result.sprites:
            lines.append(
                f"| {sprite.name} | {sprite.atlas_name} | {sprite.width}x{sprite.height} "
                f"| ({sprite.pivot_x:.2f}, {sprite.pivot_y:.2f}) | {sprite.classification.value} |"
            )

        (doc_dir / "Sprites.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_duplicate_doc(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate duplicate report documentation."""
        lines = [
            "# Duplicate Analysis",
            "",
            f"**Duplicate Groups Found:** {result.duplicates_found}",
            "",
        ]

        for i, dup in enumerate(result.duplicates, 1):
            lines.extend([
                f"## Group {i} ({dup.duplicate_type.value})",
                "",
                f"- **Primary:** {dup.primary}",
                f"- **Confidence:** {dup.confidence:.2f}",
                f"- **Variants:** {len(dup.assets)}",
                "",
            ])
            for name in dup.assets:
                lines.append(f"  - {name}")
            lines.append("")

        (doc_dir / "Duplicates.md").write_text("\n".join(lines), encoding="utf-8")

    def _generate_html_docs(self, result: ReconstructionResult, doc_dir: Path) -> None:
        """Generate HTML documentation with navigation."""
        html = f"""<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Unity Asset Recovery Documentation</title>
<style>
body {{ font-family: -apple-system, sans-serif; background: #1e1e2e; color: #cdd6f4; margin: 0; }}
.sidebar {{ position: fixed; width: 250px; height: 100vh; background: #181825;
            border-right: 1px solid #313244; overflow-y: auto; padding: 20px; }}
.sidebar h2 {{ color: #89b4fa; margin-bottom: 20px; }}
.sidebar a {{ display: block; color: #a6adc8; text-decoration: none;
              padding: 8px 12px; border-radius: 6px; margin: 2px 0; }}
.sidebar a:hover {{ background: #313244; color: #cdd6f4; }}
.main {{ margin-left: 270px; padding: 30px; }}
h1 {{ color: #89b4fa; }}
h2 {{ color: #a6e3a1; margin-top: 30px; }}
table {{ width: 100%; border-collapse: collapse; margin: 15px 0; }}
th, td {{ padding: 10px; text-align: left; border-bottom: 1px solid #313244; }}
th {{ background: #181825; color: #f9e2af; }}
.card {{ background: #181825; border-radius: 8px; padding: 15px; margin: 10px 0;
         border: 1px solid #313244; }}
.stat {{ display: inline-block; background: #181825; padding: 15px 25px;
         border-radius: 8px; margin: 5px; text-align: center; border: 1px solid #313244; }}
.stat .num {{ font-size: 2em; color: #89b4fa; }}
.stat .label {{ color: #6c7086; font-size: 0.9em; }}
</style>
</head>
<body>
<div class="sidebar">
    <h2>Documentation</h2>
    <a href="#overview">Overview</a>
    <a href="#categories">Categories</a>
    <a href="#features">Features</a>
    <a href="#relationships">Relationships</a>
    <a href="#sprites">Sprites</a>
    <a href="#duplicates">Duplicates</a>
    <a href="#search">Search Index</a>
</div>
<div class="main">
    <h1 id="overview">Unity Asset Recovery Documentation</h1>
    <div class="stat"><div class="num">{result.total_assets}</div><div class="label">Total Assets</div></div>
    <div class="stat"><div class="num">{result.total_sprites_extracted}</div><div class="label">Sprites</div></div>
    <div class="stat"><div class="num">{result.duplicates_found}</div><div class="label">Duplicates</div></div>
    <div class="stat"><div class="num">{result.relationships_mapped}</div><div class="label">Relationships</div></div>
    <div class="stat"><div class="num">{len(result.categories)}</div><div class="label">Categories</div></div>
    <div class="stat"><div class="num">{len(result.feature_groups)}</div><div class="label">Features</div></div>

    <h2 id="categories">Categories</h2>
    <table><tr><th>Category</th><th>Count</th></tr>"""

        for cat, count in sorted(result.categories.items(), key=lambda x: x[1], reverse=True):
            html += f"<tr><td>{cat}</td><td>{count}</td></tr>"

        html += """</table>

    <h2 id="features">Feature Groups</h2>
    <table><tr><th>Feature</th><th>Count</th></tr>"""

        for feat, count in sorted(result.feature_groups.items(), key=lambda x: x[1], reverse=True):
            html += f"<tr><td>{feat}</td><td>{count}</td></tr>"

        html += """</table>

    <h2 id="relationships">Relationships</h2>
    <p>Total relationships mapped: """ + str(len(result.relationships)) + """</p>

    <h2 id="sprites">Sprites</h2>
    <p>Total sprites extracted: """ + str(len(result.sprites)) + """</p>

    <h2 id="duplicates">Duplicates</h2>
    <p>Duplicate groups found: """ + str(result.duplicates_found) + """</p>

    <h2 id="search">Search Index</h2>
    <p>Pre-built index available in SearchIndex.json</p>
</div>
</body>
</html>"""

        (doc_dir / "index.html").write_text(html, encoding="utf-8")
