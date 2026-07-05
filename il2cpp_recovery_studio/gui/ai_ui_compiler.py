import os
import json
import shutil
import xml.etree.ElementTree as ET
from pathlib import Path
from xml.dom import minidom

def _prettify_xml(elem):
    """Return a pretty-printed XML string for the Element."""
    rough_string = ET.tostring(elem, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    # Remove empty lines that minidom inserts when indenting
    pretty = reparsed.toprettyxml(indent="  ")
    return "\n".join([line for line in pretty.splitlines() if line.strip()])

def _clean_attrib(val):
    if val is None:
        return ""
    if isinstance(val, (dict, list)):
        return json.dumps(val)
    return str(val)

def build_xml_node(node):
    """Recursively convert a normalized UI node to an ElementTree Element."""
    # Determine element tag based on Unity UI components
    tag = "Panel"
    attribs = {"name": node.get("name", "GameObject")}
    
    # Layer / Active state
    if not node.get("is_active", True):
        attribs["active"] = "false"
        
    # Layout dimensions
    layout = node.get("layout", {}) or {}
    size = layout.get("sizeDelta", {}) or {}
    pos = layout.get("anchoredPosition", {}) or {}
    
    if size.get("x") is not None and size.get("y") is not None:
        if size["x"] != 0 or size["y"] != 0:
            attribs["size"] = f"{int(size['x'])}x{int(size['y'])}"
    if pos.get("x") is not None and pos.get("y") is not None:
        if pos["x"] != 0 or pos["y"] != 0:
            attribs["pos"] = f"{int(pos['x'])},{int(pos['y'])}"

    # Check components to specialize the tag
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

    # Special handling for text which can be attributes or child elements
    text_elem = None
    if "text" in node:
        txt = node["text"]
        content = txt.get("content", "") or ""
        # If it's a simple text block, we can make it a Text tag
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
        
    # Process children
    for child in node.get("children", []) or []:
        if child:
            elem.append(build_xml_node(child))
            
    return elem

def extract_referenced_sprites(node, sprites=None):
    if sprites is None:
        sprites = set()
    
    img = node.get("image", {}) or {}
    if img.get("sprite"):
        sprites.add(img["sprite"])
        
    rimg = node.get("rawImage", {}) or {}
    if rimg.get("texture_name"):
        sprites.add(rimg["texture_name"])
        
    for child in node.get("children", []) or []:
        if child:
            extract_referenced_sprites(child, sprites)
    return sprites

def generate_companion_markdown(scene_name, xml_str, sprites, raw_count):
    lines = [
        f"# Rebuild Companion: {scene_name}",
        "",
        "This companion package contains all the resources, layout specs, and context needed to perfectly implement the design UI of this screen in React/Tailwind, Flutter, or HTML.",
        "",
        "## Scene Overview",
        f"- **Scene Name**: `{scene_name}`",
        f"- **Unity GameObjects Parsed**: `{raw_count}`",
        f"- **UI Assets Linked**: `{len(sprites)}` (copied to the `./assets/` folder)",
        "",
        "## Clean Layout Specs (Pseudo-HTML UI Markup)",
        "Use this XML layout to structure your screen. It reflects exact parent-child hierarchies, sizes, coordinates, alignments, and fonts:",
        "",
        "```xml",
        xml_str,
        "```",
        "",
        "## Linked Assets (Check `./assets/` folder)",
        "The following assets are required for this UI. They have been copied into the `./assets/` directory relative to this file:",
    ]
    for s in sorted(sprites):
        lines.append(f"- `{s}.png`")
        
    lines.extend([
        "",
        "## Instructions for the Rebuilding Agent",
        "1. **Read Layout**: Parse the XML tree to define components. For instance, `<VerticalLayout>` maps to `flex flex-col`, and `<Button>` maps to clickable buttons.",
        "2. **Render Images**: Reference images inside the local `./assets/` directory. Use CSS background-size or HTML img tags to fit the sizes defined by the `size` attribute.",
        "3. **Match Colors**: Use the hex/rgba colors defined directly in the node attributes.",
        "4. **Preserve Hierarchy**: Keep parent-child constraints. Maintain layout groups (grid, horizontal, vertical layouts) exactly as specified.",
    ])
    return "\n".join(lines)

def run_ui_compiler(output_dir: Path, log):
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
            
        # Helper to sanitize names
        def _local_safe(raw_str):
            s = "".join(c if c.isalnum() or c in " _-." else "_" for c in str(raw_str)).strip()
            return s or "unnamed"

        # Determine a human-readable name based on roots
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
        
        # 1. Generate clean XML layout DSL
        xml_root = ET.Element("Scene", {"name": scene_name})
        all_sprites = set()
        
        for r in roots:
            if r:
                xml_root.append(build_xml_node(r))
                extract_referenced_sprites(r, all_sprites)
                
        xml_str = _prettify_xml(xml_root)
        
        # Skip scenes with completely empty UI structures
        if len(xml_root) == 0:
            continue
            
        scene_output_dir.mkdir(parents=True, exist_ok=True)
        (scene_output_dir / "layout.xml").write_text(xml_str, encoding="utf-8")
        
        # 2. Copy referenced asset files to `./assets/`
        copied_assets = []
        if all_sprites and unity_assets_dir.exists():
            assets_dest_dir.mkdir(parents=True, exist_ok=True)
            for sprite in all_sprites:
                # Unity assets could be png or wav
                src_png = unity_assets_dir / f"{sprite}.png"
                if src_png.exists():
                    shutil.copy2(src_png, assets_dest_dir / f"{sprite}.png")
                    copied_assets.append(f"{sprite}.png")
                else:
                    # Check text assets or other configs
                    src_txt = unity_assets_dir / f"{sprite}.txt"
                    if src_txt.exists():
                        shutil.copy2(src_txt, assets_dest_dir / f"{sprite}.txt")
                        copied_assets.append(f"{sprite}.txt")
                        
        # 3. Create PROMPT_COMPANION.md
        markdown_str = generate_companion_markdown(
            scene_name, xml_str, all_sprites, data.get("raw_count", 0)
        )
        (scene_output_dir / "PROMPT_COMPANION.md").write_text(markdown_str, encoding="utf-8")
        
        # Add to manifest
        manifest[scene_name] = {
            "xml_path": str(Path("scenes") / scene_name / "layout.xml"),
            "prompt_path": str(Path("scenes") / scene_name / "PROMPT_COMPANION.md"),
            "assets_copied": len(copied_assets),
            "object_count": data.get("raw_count", 0),
        }
        
        processed += 1
        
    # Write global scenes_manifest.json
    (ai_export_dir / "scenes_manifest.json").write_text(
        json.dumps(manifest, indent=2, ensure_ascii=False),
        encoding="utf-8"
    )
    
    log(f"[OK   ] Stage 6 complete — {processed} AI Prompt Companions generated under ai_export/scenes/")
    log("[INFO ] Check scenes_manifest.json for a list of all compiled screens.")
