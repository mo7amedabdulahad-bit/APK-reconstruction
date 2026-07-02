#!/usr/bin/env python3
"""
extract_ui_full.py — Full Unity UI Extractor using UnityPy

Dumps every UI-relevant field from Unity serialized files / AssetBundles.
Outputs ONE JSON file per source bundle (preserving path_id namespaces)
plus a global sprite_name_map.json for resolving Image.m_Sprite → PNG filename.

Usage:
    python extract_ui_full.py <src_folder> [output_folder]

Examples:
    python extract_ui_full.py "UnityDataAssetPack/assets/bin/Data" "ui_dump/assetpack"
    python extract_ui_full.py "com.traviangames.travianlegendsmobile/assets/bin/Data" "ui_dump/main"

Install deps:
    pip install "UnityPy>=1.20" Pillow
"""
import os
import json
import sys
from pathlib import Path

try:
    import UnityPy
except ImportError:
    print("ERROR: UnityPy not installed. Run: pip install 'UnityPy>=1.20'")
    sys.exit(1)

# ── Types we care about ──────────────────────────────────────────────────────
WANT_TYPES = {
    "GameObject", "Transform", "RectTransform",
    "Canvas", "CanvasScaler", "CanvasGroup", "GraphicRaycaster", "CanvasRenderer",
    "Image", "RawImage", "Text",
    "TextMeshProUGUI", "TMP_Text",
    "Button", "Toggle", "Slider", "ScrollRect",
    "InputField", "TMP_InputField",
    "Mask", "RectMask2D",
    "HorizontalLayoutGroup", "VerticalLayoutGroup",
    "GridLayoutGroup", "LayoutElement", "ContentSizeFitter",
    "AspectRatioFitter",
    "Sprite", "Texture2D", "SpriteAtlas",
    "MonoBehaviour",
    "Font", "TMP_FontAsset",
}

# ── Helpers ──────────────────────────────────────────────────────────────────
def pptr(obj):
    """Resolve a PPtr-like object to {path_id, name}."""
    if obj is None:
        return None
    try:
        pid = getattr(obj, "path_id", None)
        name = None
        if hasattr(obj, "read"):
            try:
                read = obj.read()
                name = getattr(read, "m_Name", None) or getattr(read, "name", None)
            except Exception:
                pass
        return {"path_id": pid, "name": name}
    except Exception:
        return None


def vec(v, keys=("x", "y", "z", "w")):
    if v is None:
        return None
    return {k: getattr(v, k, None) for k in keys if hasattr(v, k)}


def color(c):
    if c is None:
        return None
    return {"r": getattr(c, "r", None), "g": getattr(c, "g", None),
            "b": getattr(c, "b", None), "a": getattr(c, "a", None)}


def safe_get(obj, field, default=None):
    try:
        return getattr(obj, field, default)
    except Exception:
        return default


# ── Per-type field extraction ────────────────────────────────────────────────
def dump_obj(o):
    t = o.type.name
    try:
        d = o.read()
    except Exception as e:
        return {"path_id": o.path_id, "type": t, "_error": f"read() failed: {e}"}

    out = {
        "path_id": o.path_id,
        "type": t,
        "name": safe_get(d, "m_Name") or safe_get(d, "name"),
    }

    try:
        if t == "GameObject":
            out["layer"] = safe_get(d, "m_Layer")
            out["is_active"] = safe_get(d, "m_IsActive")
            comps = safe_get(d, "m_Component", [])
            out["components"] = [
                pptr(c.component) if hasattr(c, "component") else pptr(c)
                for c in comps
            ]

        elif t in ("Transform", "RectTransform"):
            for f in ("m_LocalPosition", "m_LocalRotation", "m_LocalScale",
                      "m_AnchorMin", "m_AnchorMax", "m_AnchoredPosition",
                      "m_SizeDelta", "m_OffsetMin", "m_OffsetMax", "m_Pivot"):
                if hasattr(d, f):
                    out[f] = vec(getattr(d, f))
            out["m_Father"] = pptr(safe_get(d, "m_Father"))
            out["m_Children"] = [pptr(c) for c in safe_get(d, "m_Children", [])]

        elif t == "Canvas":
            for f in ("m_RenderMode", "m_SortingOrder", "m_PixelPerfect",
                      "m_PlaneDistance", "m_OverrideSorting", "m_OverridePixelPerfect"):
                out[f] = safe_get(d, f)

        elif t == "CanvasScaler":
            for f in ("m_UiScaleMode", "m_ReferenceResolution", "m_ScreenMatchMode",
                      "m_MatchWidthOrHeight", "m_ReferencePixelsPerUnit",
                      "m_ScaleFactor", "m_PhysicalUnit", "m_FallbackScreenDPI",
                      "m_DefaultSpriteDPI"):
                v = safe_get(d, f)
                out[f] = vec(v) if hasattr(v, "x") else v

        elif t in ("CanvasGroup", "GraphicRaycaster", "CanvasRenderer"):
            for f in dir(d):
                if f.startswith("m_"):
                    try:
                        out[f] = safe_get(d, f)
                    except Exception:
                        pass

        elif t == "Image":
            out["m_Sprite"] = pptr(safe_get(d, "m_Sprite"))
            out["m_Material"] = pptr(safe_get(d, "m_Material"))
            out["m_Color"] = color(safe_get(d, "m_Color"))
            for f in ("m_Type", "m_PreserveAspect", "m_FillMethod", "m_FillAmount",
                      "m_FillCenter", "m_FillOrigin", "m_FillClockwise",
                      "m_RaycastTarget", "m_Maskable"):
                out[f] = safe_get(d, f)

        elif t == "RawImage":
            out["m_Texture"] = pptr(safe_get(d, "m_Texture"))
            out["m_Color"] = color(safe_get(d, "m_Color"))
            out["m_UVRect"] = vec(safe_get(d, "m_UVRect"), ("x", "y", "width", "height"))
            out["m_RaycastTarget"] = safe_get(d, "m_RaycastTarget")

        elif t == "Text":
            font_data = safe_get(d, "m_FontData")
            out["m_Text"] = safe_get(d, "m_Text")
            out["m_Color"] = color(safe_get(d, "m_Color"))
            if font_data:
                out["m_Font"] = pptr(safe_get(font_data, "m_Font"))
                for f in ("m_FontSize", "m_FontStyle", "m_Alignment",
                          "m_AlignByGeometry", "m_RichText", "m_HorizontalOverflow",
                          "m_VerticalOverflow", "m_LineSpacing"):
                    out[f] = safe_get(font_data, f)

        elif t in ("TextMeshProUGUI", "TMP_Text"):
            out["m_text"] = safe_get(d, "m_text")
            out["m_fontAsset"] = pptr(safe_get(d, "m_fontAsset"))
            out["m_sharedMaterial"] = pptr(safe_get(d, "m_sharedMaterial"))
            out["m_color"] = color(safe_get(d, "m_color"))
            for f in ("m_fontSize", "m_fontSizeMin", "m_fontSizeMax",
                      "m_enableAutoSizing", "m_fontStyle", "m_alignment",
                      "m_margin", "m_richText", "m_overflowMode",
                      "m_isOrthographic", "m_enableWordWrapping",
                      "m_characterSpacing", "m_wordSpacing", "m_lineSpacing",
                      "m_paragraphSpacing"):
                out[f] = safe_get(d, f)

        elif t == "Button":
            out["m_Interactable"] = safe_get(d, "m_Interactable")
            out["m_TargetGraphic"] = pptr(safe_get(d, "m_TargetGraphic"))
            out["m_Transition"] = safe_get(d, "m_Transition")
            colors = safe_get(d, "m_Colors")
            if colors:
                out["m_Colors"] = {
                    "normalColor": color(safe_get(colors, "m_NormalColor")),
                    "highlightedColor": color(safe_get(colors, "m_HighlightedColor")),
                    "pressedColor": color(safe_get(colors, "m_PressedColor")),
                    "disabledColor": color(safe_get(colors, "m_DisabledColor")),
                    "fadeDuration": safe_get(colors, "m_ColorMultiplier"),
                }
            on_click = safe_get(d, "m_OnClick")
            if on_click:
                calls = safe_get(on_click, "m_PersistentCalls")
                if calls:
                    out["m_OnClick"] = [{
                        "target": pptr(safe_get(c, "m_Target")),
                        "method": safe_get(c, "m_MethodName"),
                        "enabled": safe_get(c, "m_CallState"),
                    } for c in safe_get(calls, "m_Calls", [])]

        elif t == "Toggle":
            out["m_IsOn"] = safe_get(d, "m_IsOn")
            out["m_Interactable"] = safe_get(d, "m_Interactable")
            out["m_Graphic"] = pptr(safe_get(d, "m_Graphic"))
            out["m_TargetGraphic"] = pptr(safe_get(d, "m_TargetGraphic"))
            out["m_Group"] = pptr(safe_get(d, "m_Group"))

        elif t == "Slider":
            out["m_Value"] = safe_get(d, "m_Value")
            out["m_MinValue"] = safe_get(d, "m_MinValue")
            out["m_MaxValue"] = safe_get(d, "m_MaxValue")
            out["m_WholeNumbers"] = safe_get(d, "m_WholeNumbers")
            out["m_Direction"] = safe_get(d, "m_Direction")
            out["m_FillRect"] = pptr(safe_get(d, "m_FillRect"))
            out["m_HandleRect"] = pptr(safe_get(d, "m_HandleRect"))

        elif t == "ScrollRect":
            out["m_Content"] = pptr(safe_get(d, "m_Content"))
            out["m_Viewport"] = pptr(safe_get(d, "m_Viewport"))
            out["m_HorizontalScrollbar"] = pptr(safe_get(d, "m_HorizontalScrollbar"))
            out["m_VerticalScrollbar"] = pptr(safe_get(d, "m_VerticalScrollbar"))
            for f in ("m_Horizontal", "m_Vertical", "m_MovementType",
                      "m_Elasticity", "m_Inertia", "m_DecelerationRate",
                      "m_ScrollSensitivity"):
                out[f] = safe_get(d, f)

        elif t in ("InputField", "TMP_InputField"):
            out["m_Text"] = safe_get(d, "m_Text")
            out["m_ContentType"] = safe_get(d, "m_ContentType")
            out["m_CharacterLimit"] = safe_get(d, "m_CharacterLimit")
            out["m_Placeholder"] = pptr(safe_get(d, "m_Placeholder"))
            out["m_TextComponent"] = pptr(safe_get(d, "m_TextComponent"))

        elif t in ("Mask", "RectMask2D"):
            for f in ("m_ShowMaskGraphic", "m_Padding", "m_Softness"):
                out[f] = safe_get(d, f)

        elif t in ("HorizontalLayoutGroup", "VerticalLayoutGroup"):
            padding = safe_get(d, "m_Padding")
            if padding:
                out["m_Padding"] = {"left": safe_get(padding, "m_Left"),
                                     "right": safe_get(padding, "m_Right"),
                                     "top": safe_get(padding, "m_Top"),
                                     "bottom": safe_get(padding, "m_Bottom")}
            for f in ("m_Spacing", "m_ChildAlignment",
                      "m_ChildControlWidth", "m_ChildControlHeight",
                      "m_ChildScaleWidth", "m_ChildScaleHeight",
                      "m_ChildForceExpandWidth", "m_ChildForceExpandHeight",
                      "m_ReverseArrangement"):
                out[f] = safe_get(d, f)

        elif t == "GridLayoutGroup":
            padding = safe_get(d, "m_Padding")
            if padding:
                out["m_Padding"] = {"left": safe_get(padding, "m_Left"),
                                     "right": safe_get(padding, "m_Right"),
                                     "top": safe_get(padding, "m_Top"),
                                     "bottom": safe_get(padding, "m_Bottom")}
            for f in ("m_CellSize", "m_Spacing"):
                out[f] = vec(safe_get(d, f), ("x", "y"))
            for f in ("m_Constraint", "m_ConstraintCount", "m_StartCorner",
                      "m_StartAxis", "m_ChildAlignment"):
                out[f] = safe_get(d, f)

        elif t == "LayoutElement":
            for f in ("m_MinWidth", "m_MinHeight", "m_PreferredWidth",
                      "m_PreferredHeight", "m_FlexibleWidth", "m_FlexibleHeight",
                      "m_LayoutPriority", "m_IgnoreLayout"):
                out[f] = safe_get(d, f)

        elif t == "ContentSizeFitter":
            out["m_HorizontalFit"] = safe_get(d, "m_HorizontalFit")
            out["m_VerticalFit"] = safe_get(d, "m_VerticalFit")

        elif t == "AspectRatioFitter":
            out["m_AspectMode"] = safe_get(d, "m_AspectMode")
            out["m_AspectRatio"] = safe_get(d, "m_AspectRatio")

        elif t == "Sprite":
            out["rect"] = vec(safe_get(d, "m_Rect"), ("x", "y", "width", "height"))
            out["pivot"] = vec(safe_get(d, "m_Pivot"), ("x", "y"))
            out["pixels_per_unit"] = safe_get(d, "m_PixelsPerUnit")
            out["border"] = vec(safe_get(d, "m_Border"), ("x", "y", "z", "w"))
            rd = safe_get(d, "m_RD")
            if rd:
                out["texture"] = pptr(safe_get(rd, "texture"))
                out["atlas"] = pptr(safe_get(rd, "alphaTexture"))

        elif t == "Texture2D":
            out["width"] = safe_get(d, "m_Width")
            out["height"] = safe_get(d, "m_Height")
            out["format"] = safe_get(d, "m_TextureFormat")

        elif t == "SpriteAtlas":
            out["m_IsVariant"] = safe_get(d, "m_IsVariant")
            packed = safe_get(d, "m_PackedSprites")
            if packed:
                out["m_PackedSprites"] = [pptr(s) for s in packed]

        elif t in ("Font", "TMP_FontAsset"):
            out["m_LineSpacing"] = safe_get(d, "m_LineSpacing")
            out["m_FontSize"] = safe_get(d, "m_FontSize")
            out["m_AtlasTexture"] = pptr(safe_get(d, "m_AtlasTexture"))
            out["m_AtlasTextures"] = [
                pptr(t_) for t_ in safe_get(d, "m_AtlasTextures", [])
            ]

        elif t == "MonoBehaviour":
            out["script"] = pptr(safe_get(d, "m_Script"))
            for f in dir(d):
                if f.startswith("m_") and f != "m_Script":
                    try:
                        v = safe_get(d, f)
                        if isinstance(v, (int, float, str, bool, type(None))):
                            out[f] = v
                    except Exception:
                        pass

    except Exception as e:
        out["_error"] = str(e)

    return out


# ── Main ─────────────────────────────────────────────────────────────────────
def main():
    src = sys.argv[1] if len(sys.argv) > 1 else r"UnityDataAssetPack/assets/bin/Data"
    out_dir = Path(sys.argv[2] if len(sys.argv) > 2 else "ui_dump")
    out_dir.mkdir(parents=True, exist_ok=True)

    sprite_name_map = {}  # {bundle_source: {path_id: sprite_name}}
    processed = 0
    skipped = 0

    print(f"Scanning: {src}")
    print(f"Output:   {out_dir}")
    print()

    for root, _, files in os.walk(src):
        for fn in files:
            fp = os.path.join(root, fn)
            try:
                env = UnityPy.load(fp)
            except Exception:
                skipped += 1
                continue

            objs = []
            bundle_sprites = {}

            for o in env.objects:
                if o.type.name not in WANT_TYPES:
                    continue
                dumped = dump_obj(o)
                objs.append(dumped)

                # Build sprite name map entry
                if o.type.name == "Sprite" and dumped.get("name"):
                    bundle_sprites[o.path_id] = dumped["name"]

            if not objs:
                skipped += 1
                continue

            # Safe output filename: bundle_name + parent_folder suffix
            rel = os.path.relpath(fp, src).replace(os.sep, "_").replace(" ", "_")
            safe_name = rel[:200]  # keep filenames reasonable
            out_file = out_dir / f"{safe_name}.json"
            out_file.parent.mkdir(parents=True, exist_ok=True)

            out_file.write_text(
                json.dumps({"source": fp, "objects": objs}, default=str, ensure_ascii=False),
                encoding="utf-8"
            )

            if bundle_sprites:
                sprite_name_map[fp] = bundle_sprites

            processed += 1
            if processed % 50 == 0:
                print(f"  Processed {processed} files...")

    # Write global sprite name map
    map_file = out_dir / "sprite_name_map.json"
    map_file.write_text(
        json.dumps(sprite_name_map, indent=2, ensure_ascii=False),
        encoding="utf-8"
    )

    print()
    print(f"Done!")
    print(f"  Bundles processed : {processed}")
    print(f"  Bundles skipped   : {skipped}")
    print(f"  Output folder     : {out_dir}")
    print(f"  Sprite name map   : {map_file}")
    print()
    print("Next step: run scripts/parse-unity-bundle.mjs to build the normalized UI tree.")


if __name__ == "__main__":
    main()
