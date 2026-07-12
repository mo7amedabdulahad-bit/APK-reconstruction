import os
import json
import shutil
import xml.etree.ElementTree as ET
from pathlib import Path
from xml.dom import minidom

try:
    import UnityPy
    _HAS_UNITYPY = True
except ImportError:
    _HAS_UNITYPY = False


def _find_sprite_file(sprite_name: str, output_dir: Path, log=None) -> Path | None:
    """Find a sprite file in various locations."""
    # 1. unity_assets/ (Stage 2 extracted PNGs)
    unity_assets = output_dir / "unity_assets"
    for ext in (".png", ".txt", ".json"):
        p = unity_assets / f"{sprite_name}{ext}"
        if p.exists():
            return p
    
    # 2. ui_dump/ (Stage 4 output - may have sprite mapping)
    ui_dump = output_dir / "ui_dump"
    for json_file in ui_dump.glob("*.json"):
        try:
            data = json.loads(json_file.read_text(encoding="utf-8"))
            for obj in data.get("objects", []):
                if obj.get("name") == sprite_name or obj.get("path_id") == sprite_name:
                    # The sprite might be referenced by path_id
                    pass
        except Exception:
            pass
    
    # 3. Search in unity_assets subdirectories recursively
    unity_assets = output_dir / "unity_assets"
    if unity_assets.exists():
        for ext in (".png", ".txt", ".json"):
            matches = list(unity_assets.rglob(f"{sprite_name}{ext}"))
            if matches:
                return matches[0]
    
    return None


def _extract_sprite_on_demand(sprite_name: str, raw_dir: Path, output_dir: Path, log=None) -> Path | None:
    """Try to extract a sprite from raw asset files on-demand using UnityPy."""
    if not _HAS_UNITYPY:
        return None
    try:
        unity_data_dir = _find_unity_data_dir(raw_dir)
        if not unity_data_dir:
            return None
        data_dir = unity_data_dir / "assets" / "bin" / "Data"
        if not data_dir.exists():
            return None
        
        # Search all asset files for the sprite
        for asset_file in data_dir.glob("sharedassets*.assets*"):
            try:
                import UnityPy
                env = UnityPy.load(str(asset_file))
                for obj in env.objects:
                    if obj.type.name in ("Sprite", "Texture2D"):
                        try:
                            data = obj.read()
                            name = getattr(data, "m_Name", None) or getattr(data, "name", None) or ""
                            if name == sprite_name:
                                # Extract to unity_assets for future use
                                unity_assets = output_dir / "unity_assets"
                                unity_assets.mkdir(parents=True, exist_ok=True)
                                if obj.type.name == "Sprite" and hasattr(data, "image") and data.image:
                                    out_png = unity_assets / f"{sprite_name}.png"
                                    data.image.save(str(out_png))
                                    return out_png
                                elif obj.type.name == "Texture2D" and hasattr(data, "image") and data.image:
                                    out_png = unity_assets / f"{sprite_name}.png"
                                    data.image.save(str(out_png))
                                    return out_png
                        except Exception:
                            continue
            except Exception:
                continue
    except Exception:
        pass
    return None

try:
    import UnityPy
    _HAS_UNITYPY = True
except ImportError:
    _HAS_UNITYPY = False


def _prettify_xml(elem):
    rough_string = ET.tostring(elem, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty = reparsed.toprettyxml(indent="  ")
    return "\n".join([line for line in pretty.splitlines() if line.strip()])


def _clean_attrib(val):
    if val is None:
        return ""
    if isinstance(val, (dict, list)):
        return json.dumps(val)
    return str(val)


def _safe(val, default=""):
    return val if val else default


def build_xml_node(node):
    tag = "Panel"
    attribs = {"name": node.get("name", "GameObject")}

    if not node.get("is_active", True):
        attribs["active"] = "false"

    layout = node.get("layout", {}) or {}
    size = layout.get("sizeDelta", {}) or {}
    pos = layout.get("anchoredPosition", {}) or {}

    if size.get("x") is not None and size.get("y") is not None:
        if size["x"] != 0 or size["y"] != 0:
            attribs["size"] = f"{int(size['x'])}x{int(size['y'])}"
    if pos.get("x") is not None and pos.get("y") is not None:
        if pos["x"] != 0 or pos["y"] != 0:
            attribs["pos"] = f"{int(pos['x'])},{int(pos['y'])}"

    if "canvas" in node:
        tag = "Canvas"
        c = node["canvas"]
        attribs["sortingOrder"] = _clean_attrib(c.get("sortingOrder"))
    elif "layoutGroup" in node:
        g = node["layoutGroup"]
        g_type = g.get("type", "")
        if "Horizontal" in g_type:
            tag = "HorizontalLayout"
        elif "Vertical" in g_type:
            tag = "VerticalLayout"
        elif "Grid" in g_type:
            tag = "GridLayout"
        else:
            tag = "LayoutGroup"
        if g.get("spacing"):
            attribs["spacing"] = _clean_attrib(g["spacing"])
        if g.get("padding"):
            p = g["padding"]
            attribs["padding"] = f"L:{p.get('m_Left',0)},R:{p.get('m_Right',0)},T:{p.get('m_Top',0)},B:{p.get('m_Bottom',0)}"
    elif "scrollRect" in node:
        tag = "ScrollView"
    elif "button" in node:
        tag = "Button"
    elif "toggle" in node:
        tag = "Toggle"
    elif "slider" in node:
        tag = "Slider"
    elif "inputField" in node:
        tag = "InputField"
    elif "image" in node:
        tag = "Image"
        img = node["image"]
        if img.get("sprite"):
            attribs["src"] = img["sprite"]
        if img.get("color"):
            attribs["color"] = img["color"]
    elif "rawImage" in node:
        tag = "RawImage"
        rimg = node["rawImage"]
        if rimg.get("texture_name"):
            attribs["src"] = rimg["texture_name"]
        if rimg.get("color"):
            attribs["color"] = rimg["color"]

    text_elem = None
    if "text" in node:
        txt = node["text"]
        content = txt.get("content", "") or ""
        text_elem = ET.Element("Text")
        text_elem.set("value", content)
        if txt.get("font"):
            text_elem.set("font", txt["font"])
        if txt.get("fontSize"):
            text_elem.set("size", str(int(txt["fontSize"])))
        if txt.get("color"):
            text_elem.set("color", txt["color"])

    elem = ET.Element(tag, attribs)
    if text_elem is not None:
        elem.append(text_elem)

    for child in node.get("children", []) or []:
        if child:
            elem.append(build_xml_node(child))

    return elem


def collect_scene_assets(node, parent_name="", assets=None):
    """Walk the normalized tree and collect every asset reference with context."""
    if assets is None:
        assets = {"sprites": [], "fonts": [], "texts": []}

    name = node.get("name", "GameObject")

    # Image sprites
    img = node.get("image", {}) or {}
    sprite = img.get("sprite")
    if sprite:
        assets["sprites"].append({
            "name": sprite,
            "element": name,
            "parent": parent_name,
            "color": img.get("color"),
            "type": "Image",
        })

    # RawImage textures
    rimg = node.get("rawImage", {}) or {}
    tex = rimg.get("texture_name")
    if tex:
        assets["sprites"].append({
            "name": tex,
            "element": name,
            "parent": parent_name,
            "color": rimg.get("color"),
            "type": "RawImage",
        })

    # Font references
    txt = node.get("text", {}) or {}
    font = txt.get("font")
    if font:
        assets["fonts"].append({
            "name": font,
            "element": name,
            "parent": parent_name,
            "fontSize": txt.get("fontSize"),
        })

    # Text content
    content = txt.get("content")
    if content:
        assets["texts"].append({
            "content": content,
            "element": name,
            "parent": parent_name,
            "fontSize": txt.get("fontSize"),
            "color": txt.get("color"),
            "engine": txt.get("engine", "unknown"),
        })

    # CanvasScaler font
    cs = node.get("canvasScaler", {}) or {}
    # recurse
    for child in node.get("children", []) or []:
        if child:
            collect_scene_assets(child, name, assets)

    return assets


def generate_companion_markdown(scene_name, xml_str, assets, raw_count):
    sprites = assets["sprites"]
    fonts = assets["fonts"]
    texts = assets["texts"]

    lines = [
        f"# Rebuild Companion: {scene_name}",
        "",
        "This companion package contains all the resources, layout specs, and context needed to perfectly implement the design UI of this screen in React/Tailwind, Flutter, or HTML.",
        "",
        "## Scene Overview",
        f"- **Scene Name**: `{scene_name}`",
        f"- **Unity GameObjects Parsed**: `{raw_count}`",
        f"- **Image/Texture Assets**: `{len(sprites)}`",
        f"- **Font Assets**: `{len(fonts)}`",
        f"- **Text Labels**: `{len(texts)}`",
        "",
    ]

    # ── Asset Manifest ─────────────────────────────────────────────────────
    if sprites:
        lines.append("## Image & Texture Assets")
        lines.append("")
        lines.append("These are the named image/texture assets used in this scene. Each asset is listed with the element that uses it so you can map them to the correct UI component.")
        lines.append("")
        lines.append("| Asset Name | Used By | Parent Element | Type | Color |")
        lines.append("|---|---|---|---|---|")
        for s in sorted(sprites, key=lambda x: x["name"]):
            color = s.get("color") or ""
            lines.append(f"| `{s['name']}` | {s['element']} | {s['parent']} | {s['type']} | {color} |")
        lines.append("")
        lines.append("Asset files are copied to the `./assets/` directory alongside this file. Reference them by the asset name above.")

    if fonts:
        lines.append("")
        lines.append("## Font Assets")
        lines.append("")
        lines.append("| Font Name | Used By | Font Size |")
        lines.append("|---|---|---|")
        for f in sorted(fonts, key=lambda x: x["name"]):
            lines.append(f"| `{f['name']}` | {f['element']} | {f.get('fontSize', 'N/A')} |")

    if texts:
        lines.append("")
        lines.append("## Text Labels (Content)")
        lines.append("")
        lines.append("These are the visible text strings in the scene. Use them as the default content when building the UI.")
        lines.append("")
        lines.append("| Text Content | Element | Parent | Font Size | Engine |")
        lines.append("|---|---|---|---|---|")
        for t in sorted(texts, key=lambda x: x["content"]):
            content_short = t["content"][:80] + ("..." if len(t["content"]) > 80 else "")
            lines.append(f"| {content_short} | {t['element']} | {t['parent']} | {t.get('fontSize', 'N/A')} | {t.get('engine', 'unknown')} |")

    # ── XML Layout ─────────────────────────────────────────────────────────
    lines.extend([
        "",
        "## Clean Layout Specs (Pseudo-HTML UI Markup)",
        "Use this XML layout to structure your screen. It reflects exact parent-child hierarchies, sizes, coordinates, alignments, and fonts:",
        "",
        "```xml",
        xml_str,
        "```",
    ])

    # ── Asset file list ────────────────────────────────────────────────────
    if sprites:
        lines.extend([
            "",
            "## Asset Files (Check `./assets/` folder)",
            "The following files have been copied into the `./assets/` directory:",
        ])
        for s in sorted(sprites, key=lambda x: x["name"]):
            lines.append(f"- `{s['name']}.png` -> used by **{s['element']}** ({s['type']})")

    # ── Instructions ───────────────────────────────────────────────────────
    lines.extend([
        "",
        "## Instructions for the Rebuilding Agent",
        "1. **Read Layout**: Parse the XML tree to define components. `<VerticalLayout>` maps to `flex flex-col`, `<HorizontalLayout>` maps to `flex flex-row`, `<Button>` maps to clickable buttons.",
        "2. **Render Images**: Reference images by their **Asset Name** from the table above. Each asset has been copied to `./assets/<AssetName>.png`.",
        "3. **Match Colors**: Use the hex/rgba colors defined in the node attributes and the asset table.",
        "4. **Set Text Content**: Use the text strings from the **Text Labels** table above as the default content for each text element.",
        "5. **Apply Fonts**: Where a font name is specified, use a matching Google Font or system font. Preserve font sizes from the table.",
        "6. **Preserve Hierarchy**: Keep parent-child constraints. Maintain layout groups (grid, horizontal, vertical layouts) exactly as specified.",
    ])
    return "\n".join(lines)


def run_ui_compiler(output_dir: Path, log, raw_dir: Path | None = None):
    log("[STEP ] Stage 6 — Building AI Prompt Companions & Slicing Scene assets…")

    norm_dir = output_dir / "normalized_ui"
    unity_assets_dir = output_dir / "unity_assets"
    ai_export_dir = output_dir / "ai_export"
    scenes_dir = ai_export_dir / "scenes"

    if not norm_dir.exists():
        log("[WARN ] normalized_ui/ directory does not exist. Run Stage 5 first.")
        return

    scenes_dir.mkdir(parents=True, exist_ok=True)
    manifest = {}

    json_files = list(norm_dir.glob("*.json"))
    log(f"[INFO ] Compiling prompt packages for {len(json_files)} UI scenes…")

    processed = 0
    for jf in json_files:
        try:
            data = json.loads(jf.read_text(encoding="utf-8"))
        except Exception as e:
            log(f"[WARN ] Failed to parse {jf.name}: {e}")
            continue

        roots = data.get("roots", []) or []
        if not roots:
            continue

        def _local_safe(raw_str):
            s = "".join(c if c.isalnum() or c in " _-." else "_" for c in str(raw_str)).strip()
            return s or "unnamed"

        root_names = [r.get("name") for r in roots if r and r.get("name") and r.get("name").lower() not in ("canvas", "gameobject", "panel", "root", "ui")]
        if root_names:
            scene_name = f"{_local_safe(root_names[0])}_{jf.stem[:8]}"
        else:
            first_name = roots[0].get("name") if (roots and roots[0]) else None
            if first_name and first_name.lower() not in ("gameobject", "panel"):
                scene_name = f"{_local_safe(first_name)}_{jf.stem[:8]}"
            else:
                scene_name = jf.stem

        scene_output_dir = scenes_dir / scene_name
        assets_dest_dir = scene_output_dir / "assets"

        xml_root = ET.Element("Scene", {"name": scene_name})
        all_assets = {"sprites": [], "fonts": [], "texts": []}

        for r in roots:
            if r:
                xml_root.append(build_xml_node(r))
                collect_scene_assets(r, assets=all_assets)

        xml_str = _prettify_xml(xml_root)

        if len(xml_root) == 0:
            continue

        scene_output_dir.mkdir(parents=True, exist_ok=True)
        (scene_output_dir / "layout.xml").write_text(xml_str, encoding="utf-8")

        copied_assets = []
        seen_sprites = set()
        if all_assets["sprites"]:
            assets_dest_dir.mkdir(parents=True, exist_ok=True)
            for s in all_assets["sprites"]:
                sprite_name = s["name"]
                if sprite_name in seen_sprites:
                    continue
                seen_sprites.add(sprite_name)
                
                # Try to find the sprite file in multiple locations
                src_file = _find_sprite_file(sprite_name, output_dir)
                
                # If not found, try on-demand extraction from raw assets
                if src_file is None and raw_dir is not None:
                    src_file = _extract_sprite_on_demand(sprite_name, raw_dir, output_dir, log)
                
                if src_file and src_file.exists():
                    ext = src_file.suffix
                    dest_file = assets_dest_dir / f"{sprite_name}{ext}"
                    shutil.copy2(src_file, dest_file)
                    copied_assets.append(f"{sprite_name}{ext}")
                    if log:
                        log(f"[INFO ] Copied asset: {sprite_name}{ext}")
                else:
                    if log:
                        log(f"[WARN ] Asset not found: {sprite_name}")

        markdown_str = generate_companion_markdown(
            scene_name, xml_str, all_assets, data.get("raw_count", 0)
        )
        (scene_output_dir / "PROMPT_COMPANION.md").write_text(markdown_str, encoding="utf-8")

        manifest[scene_name] = {
            "xml_path": str(Path("scenes") / scene_name / "layout.xml"),
            "prompt_path": str(Path("scenes") / scene_name / "PROMPT_COMPANION.md"),
            "assets_copied": len(copied_assets),
            "asset_names": sorted(seen_sprites),
            "font_count": len(all_assets["fonts"]),
            "text_count": len(all_assets["texts"]),
            "object_count": data.get("raw_count", 0),
        }

        processed += 1

    (ai_export_dir / "scenes_manifest.json").write_text(
        json.dumps(manifest, indent=2, ensure_ascii=False),
        encoding="utf-8"
    )

    log(f"[OK   ] Stage 6 complete — {processed} AI Prompt Companions generated under ai_export/scenes/")
    log("[INFO ] Check scenes_manifest.json for a list of all compiled screens.")
