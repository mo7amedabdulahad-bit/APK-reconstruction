"""Extract complete Unity UI hierarchy from asset bundles.

Walks every GameObject in every bundle, recursively reads m_Component
lists, and outputs one JSON file per Canvas root.
"""
from __future__ import annotations

import json
from io import BytesIO
from pathlib import Path
from typing import Callable, Optional


def _safe_float(v, default=0.0):
    if v is None:
        return default
    try:
        f = float(v)
        if f != f:  # NaN check
            return default
        return f
    except (TypeError, ValueError):
        return default


def _safe_int(v, default=0):
    if v is None:
        return default
    try:
        return int(v)
    except (TypeError, ValueError):
        return default


def _safe_str(v, default=""):
    if v is None:
        return default
    return str(v)


def _safe_bool(v, default=False):
    if v is None:
        return default
    try:
        return bool(v)
    except (TypeError, ValueError):
        return default


class UIHierarchyExtractor:
    """Extract UI screen hierarchies from Unity asset bundles.

    For every Canvas found in a bundle, builds a nested JSON tree
    of all child GameObjects and their components.
    """

    def __init__(self, output_dir: Path, log_callback: Optional[Callable[[str], None]] = None) -> None:
        self.output_dir = Path(output_dir)
        self._log = log_callback or (lambda m: print(m))

    def extract_from_bundle(self, bundle_data: bytes, bundle_name: str) -> int:
        """Load a bundle and extract all Canvas root hierarchies.

        Returns the number of Canvas roots found.
        """
        try:
            import UnityPy
        except ImportError:
            self._log("  UnityPy not installed, skipping UI hierarchy extraction.")
            return 0

        try:
            env = UnityPy.load(BytesIO(bundle_data))
        except Exception as exc:
            self._log(f"  Could not load bundle for UI extraction: {exc}")
            return 0

        canvas_roots = self._find_canvas_roots(env)
        if not canvas_roots:
            return 0

        for go_data, canvas_comp, canvas_parent_path in canvas_roots:
            screen_name = _safe_str(
                getattr(go_data, "m_Name", None),
                f"Canvas_{id(go_data)}",
            )
            faction, category = self._classify(bundle_name)
            screen_dir = self.output_dir / "UI_Screens" / faction / category
            screen_dir.mkdir(parents=True, exist_ok=True)
            out_path = screen_dir / f"{self._safe_filename(screen_name)}.json"

            tree = self._build_tree(screen_name, go_data, canvas_comp, bundle_name, env)

            try:
                out_path.write_text(json.dumps(tree, indent=2, ensure_ascii=False), encoding="utf-8")
            except Exception as exc:
                self._log(f"  Error writing {out_path}: {exc}")

        return len(canvas_roots)

    # ── Canvas discovery ──────────────────────────────────────────────

    def _find_canvas_roots(self, env) -> list:
        """Find all GameObjects that have a Canvas component."""
        results = []
        go_by_path_id = {}

        for obj in env.objects:
            if obj.type.name == "GameObject":
                try:
                    data = obj.read()
                    go_by_path_id[obj.path_id] = data
                except Exception:
                    pass

        canvas_by_go = {}
        for obj in env.objects:
            if obj.type.name == "Canvas":
                try:
                    data = obj.read()
                    go_ref = getattr(data, "m_GameObject", None)
                    if go_ref is not None:
                        go_id = getattr(go_ref, "path_id", None)
                        if go_id:
                            canvas_by_go[go_id] = data
                except Exception:
                    pass

        for go_id, canvas_data in canvas_by_go.items():
            if go_id in go_by_path_id:
                go_data = go_by_path_id[go_id]
                parent_path = self._get_parent_path(go_data, go_by_path_id)
                results.append((go_data, canvas_data, parent_path))

        return results

    def _get_parent_path(self, go_data, go_by_path_id: dict) -> str:
        transform = self._get_transform(go_data)
        if transform is None:
            return ""
        parent_ref = getattr(transform, "m_Father", None)
        if parent_ref is None:
            return ""
        parent_id = getattr(parent_ref, "path_id", None)
        if not parent_id or parent_id not in go_by_path_id:
            return ""
        parent_go = go_by_path_id[parent_id]
        return _safe_str(getattr(parent_go, "m_Name", ""), "")

    def _get_transform(self, go_data):
        components = getattr(go_data, "m_Component", None)
        if components is None:
            return None
        for comp_ref in components:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
                if comp_obj.type.name in ("RectTransform", "Transform"):
                    return comp_obj
            except Exception:
                pass
        return None

    # ── Tree building ─────────────────────────────────────────────────

    def _build_tree(self, screen_name, go_data, canvas_comp, bundle_name, env) -> dict:
        """Build the full JSON tree for a Canvas screen."""
        components = self._extract_all_components(go_data)
        canvas_fields = self._extract_canvas(canvas_comp)
        rect_fields = None
        for c in components:
            if c.get("type") == "RectTransform":
                rect_fields = c
                break

        children = self._get_children(go_data, env)

        return {
            "screen_name": screen_name,
            "source_bundle": bundle_name,
            "canvas": canvas_fields,
            "rect_transform": rect_fields,
            "children": children,
        }

    def _get_children(self, go_data, env) -> list:
        """Get child GameObjects of this GameObject via its RectTransform."""
        transform = self._get_transform(go_data)
        if transform is None:
            return []

        children_ids = []
        children_refs = getattr(transform, "m_Children", None)
        if children_refs is None:
            return []

        for child_ref in children_refs:
            child_id = getattr(child_ref, "path_id", None)
            if child_id:
                children_ids.append(child_id)

        if not children_ids:
            return []

        go_by_path_id = {}
        for obj in env.objects:
            if obj.type.name == "GameObject":
                try:
                    data = obj.read()
                    go_by_path_id[obj.path_id] = data
                except Exception:
                    pass

        result = []
        for child_id in children_ids:
            if child_id in go_by_path_id:
                child_go = go_by_path_id[child_id]
                node = self._build_node(child_go, env)
                result.append(node)

        return result

    def _build_node(self, go_data, env) -> dict:
        """Recursively build the JSON tree for a single GameObject."""
        name = _safe_str(getattr(go_data, "m_Name", ""), "")
        active = _safe_bool(getattr(go_data, "m_IsActive", True), True)
        layer = _safe_int(getattr(go_data, "m_Layer", 0), 0)

        components = self._extract_all_components(go_data)
        children = self._get_children(go_data, env)

        return {
            "name": name,
            "active": active,
            "layer": layer,
            "components": components,
            "children": children,
        }

    # ── Component extraction ──────────────────────────────────────────

    def _extract_all_components(self, go_data) -> list:
        """Extract all components attached to a GameObject."""
        components = []
        comp_refs = getattr(go_data, "m_Component", None)
        if comp_refs is None:
            return components

        for comp_ref in comp_refs:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
                comp_dict = self._extract_component(comp_obj)
                if comp_dict:
                    components.append(comp_dict)
            except Exception:
                pass

        return components

    def _extract_component(self, comp_obj) -> Optional[dict]:
        """Read a single component and return its structured dict."""
        type_name = comp_obj.type.name

        if type_name == "RectTransform":
            return self._extract_rect_transform(comp_obj)
        elif type_name == "Canvas":
            return self._extract_canvas(comp_obj)
        elif type_name == "CanvasGroup":
            return self._extract_canvas_group(comp_obj)
        elif type_name == "Transform":
            return self._extract_transform(comp_obj)
        elif type_name == "MonoBehaviour":
            return self._extract_monobehaviour(comp_obj)
        else:
            return {"type": type_name}

    # ── Specific component extractors ─────────────────────────────────

    def _extract_rect_transform(self, data) -> dict:
        anchored_position = self._vec2_to_dict(getattr(data, "m_AnchoredPosition", None))
        size_delta = self._vec2_to_dict(getattr(data, "m_SizeDelta", None))
        anchor_min = self._vec2_to_dict(getattr(data, "m_AnchorMin", None))
        anchor_max = self._vec2_to_dict(getattr(data, "m_AnchorMax", None))
        pivot = self._vec2_to_dict(getattr(data, "m_Pivot", None))

        local_scale = self._vec3_to_dict(getattr(data, "m_LocalScale", None))
        local_rotation = self._vec4_to_dict(getattr(data, "m_LocalRotation", None))

        return {
            "type": "RectTransform",
            "anchoredPosition": anchored_position,
            "sizeDelta": size_delta,
            "anchorMin": anchor_min,
            "anchorMax": anchor_max,
            "pivot": pivot,
            "localScale": local_scale,
            "localRotation": local_rotation,
        }

    def _extract_transform(self, data) -> dict:
        local_position = self._vec3_to_dict(getattr(data, "m_LocalPosition", None))
        local_scale = self._vec3_to_dict(getattr(data, "m_LocalScale", None))
        local_rotation = self._vec4_to_dict(getattr(data, "m_LocalRotation", None))
        return {
            "type": "Transform",
            "localPosition": local_position,
            "localScale": local_scale,
            "localRotation": local_rotation,
        }

    def _extract_canvas(self, data) -> dict:
        return {
            "type": "Canvas",
            "renderMode": _safe_int(getattr(data, "m_RenderMode", None), 0),
            "sortingOrder": _safe_int(getattr(data, "m_SortingOrder", None), 0),
            "referencePixelsPerUnit": _safe_float(
                getattr(data, "m_ReferencePixelsPerUnit", None), 100.0
            ),
        }

    def _extract_canvas_group(self, data) -> dict:
        return {
            "type": "CanvasGroup",
            "alpha": _safe_float(getattr(data, "m_Alpha", None), 1.0),
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
            "blocksRaycasts": _safe_bool(getattr(data, "m_BlocksRaycasts", None), True),
        }

    def _extract_monobehaviour(self, data) -> dict:
        script_name = self._get_script_name(data)

        if script_name == "Image":
            return self._extract_image(data, script_name)
        elif script_name == "Text":
            return self._extract_text(data, script_name)
        elif script_name == "Button":
            return self._extract_button(data, script_name)
        elif script_name == "RawImage":
            return self._extract_raw_image(data, script_name)
        elif script_name == "Outline":
            return self._extract_outline(data, script_name)
        elif script_name == "Shadow":
            return self._extract_shadow(data, script_name)
        elif script_name == "Toggle":
            return self._extract_toggle(data, script_name)
        elif script_name == "Slider":
            return self._extract_slider(data, script_name)
        elif script_name == "InputField":
            return self._extract_input_field(data, script_name)
        elif script_name == "ScrollRect":
            return self._extract_scroll_rect(data, script_name)
        elif script_name == "Dropdown":
            return self._extract_dropdown(data, script_name)
        else:
            return self._extract_generic_monobehaviour(data, script_name)

    def _get_script_name(self, data) -> str:
        script_ref = getattr(data, "m_Script", None)
        if script_ref is None:
            return "Unknown"
        try:
            script_obj = script_ref.read()
            return _safe_str(getattr(script_obj, "m_Name", None), "Unknown")
        except Exception:
            return "Unknown"

    def _extract_image(self, data, script_name) -> dict:
        sprite_name = ""
        sprite_ref = getattr(data, "m_Sprite", None)
        if sprite_ref is not None:
            try:
                sprite_obj = sprite_ref.read()
                sprite_name = _safe_str(getattr(sprite_obj, "m_Name", None), "")
            except Exception:
                pass

        color = self._color_to_dict(getattr(data, "m_Color", None))

        return {
            "type": "Image",
            "script_name": script_name,
            "sprite_name": sprite_name,
            "color": color,
            "imageType": _safe_int(getattr(data, "m_Type", None), 0),
            "fillAmount": _safe_float(getattr(data, "m_FillAmount", None), 1.0),
            "raycastTarget": _safe_bool(getattr(data, "m_RaycastTarget", None), True),
            "preserveAspect": _safe_bool(getattr(data, "m_PreserveAspect", None), False),
        }

    def _extract_raw_image(self, data, script_name) -> dict:
        sprite_name = ""
        tex_ref = getattr(data, "m_Texture", None)
        if tex_ref is not None:
            try:
                tex_obj = tex_ref.read()
                sprite_name = _safe_str(getattr(tex_obj, "m_Name", None), "")
            except Exception:
                pass

        color = self._color_to_dict(getattr(data, "m_Color", None))

        return {
            "type": "RawImage",
            "script_name": script_name,
            "texture_name": sprite_name,
            "color": color,
            "raycastTarget": _safe_bool(getattr(data, "m_RaycastTarget", None), True),
        }

    def _extract_text(self, data, script_name) -> dict:
        font_name = ""
        font_ref = getattr(data, "m_Font", None)
        if font_ref is not None:
            try:
                font_obj = font_ref.read()
                font_name = _safe_str(getattr(font_obj, "m_Name", None), "")
            except Exception:
                pass

        color = self._color_to_dict(getattr(data, "m_Color", None))

        return {
            "type": "Text",
            "script_name": script_name,
            "text": _safe_str(getattr(data, "m_Text", None), ""),
            "font_name": font_name,
            "fontSize": _safe_int(getattr(data, "m_FontSize", None), 14),
            "fontStyle": _safe_int(getattr(data, "m_FontStyle", None), 0),
            "color": color,
            "alignment": _safe_int(getattr(data, "m_Alignment", None), 4),
            "horizontalOverflow": _safe_int(getattr(data, "m_HorizontalOverflow", None), 0),
            "verticalOverflow": _safe_int(getattr(data, "m_VerticalOverflow", None), 0),
            "lineSpacing": _safe_float(getattr(data, "m_LineSpacing", None), 1.0),
            "supportRichText": _safe_bool(getattr(data, "m_SupportRichText", None), False),
            "bestFit": _safe_bool(getattr(data, "m_BestFit", None), False),
            "minSize": _safe_int(getattr(data, "m_FontSizeMin", None), 10),
            "maxSize": _safe_int(getattr(data, "m_FontSizeMax", None), 72),
        }

    def _extract_button(self, data, script_name) -> dict:
        colors = getattr(data, "m_Colors", None)
        normal_color = {"r": 1.0, "g": 1.0, "b": 1.0, "a": 1.0}
        highlighted_color = {"r": 0.9, "g": 0.9, "b": 0.9, "a": 1.0}
        pressed_color = {"r": 0.8, "g": 0.8, "b": 0.8, "a": 1.0}

        if colors is not None:
            normal_color = self._color_to_dict(getattr(colors, "m_NormalColor", None))
            highlighted_color = self._color_to_dict(getattr(colors, "m_HighlightedColor", None))
            pressed_color = self._color_to_dict(getattr(colors, "m_PressedColor", None))

        return {
            "type": "Button",
            "script_name": script_name,
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
            "transition": _safe_int(getattr(data, "m_Transition", None), 1),
            "normalColor": normal_color,
            "highlightedColor": highlighted_color,
            "pressedColor": pressed_color,
        }

    def _extract_outline(self, data, script_name) -> dict:
        return {
            "type": "Outline",
            "script_name": script_name,
            "effectColor": self._color_to_dict(getattr(data, "m_EffectColor", None)),
            "effectDistance": self._vec2_to_dict(getattr(data, "m_EffectDistance", None)),
        }

    def _extract_shadow(self, data, script_name) -> dict:
        return {
            "type": "Shadow",
            "script_name": script_name,
            "effectColor": self._color_to_dict(getattr(data, "m_EffectColor", None)),
            "effectDistance": self._vec2_to_dict(getattr(data, "m_EffectDistance", None)),
        }

    def _extract_toggle(self, data, script_name) -> dict:
        return {
            "type": "Toggle",
            "script_name": script_name,
            "isOn": _safe_bool(getattr(data, "m_IsOn", None), False),
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
        }

    def _extract_slider(self, data, script_name) -> dict:
        return {
            "type": "Slider",
            "script_name": script_name,
            "value": _safe_float(getattr(data, "m_Value", None), 0.0),
            "minValue": _safe_float(getattr(data, "m_MinValue", None), 0.0),
            "maxValue": _safe_float(getattr(data, "m_MaxValue", None), 1.0),
            "wholeNumbers": _safe_bool(getattr(data, "m_WholeNumbers", None), False),
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
        }

    def _extract_input_field(self, data, script_name) -> dict:
        return {
            "type": "InputField",
            "script_name": script_name,
            "text": _safe_str(getattr(data, "m_Text", None), ""),
            "characterLimit": _safe_int(getattr(data, "m_CharacterLimit", None), 0),
            "contentType": _safe_int(getattr(data, "m_ContentType", None), 0),
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
        }

    def _extract_scroll_rect(self, data, script_name) -> dict:
        return {
            "type": "ScrollRect",
            "script_name": script_name,
            "horizontal": _safe_bool(getattr(data, "m_Horizontal", None), True),
            "vertical": _safe_bool(getattr(data, "m_Vertical", None), True),
            "horizontalScrollbarVisibility": _safe_int(
                getattr(data, "m_HorizontalScrollbarVisibility", None), 0
            ),
            "verticalScrollbarVisibility": _safe_int(
                getattr(data, "m_VerticalScrollbarVisibility", None), 0
            ),
        }

    def _extract_dropdown(self, data, script_name) -> dict:
        options = []
        opt_refs = getattr(data, "m_Options", None)
        if opt_refs is not None:
            option_list = getattr(opt_refs, "m_Options", None)
            if option_list:
                for opt in option_list:
                    options.append(_safe_str(getattr(opt, "m_Text", None), ""))

        return {
            "type": "Dropdown",
            "script_name": script_name,
            "value": _safe_int(getattr(data, "m_Value", None), 0),
            "options": options,
            "interactable": _safe_bool(getattr(data, "m_Interactable", None), True),
        }

    def _extract_generic_monobehaviour(self, data, script_name) -> dict:
        """Extract generic fields from any unrecognised MonoBehaviour."""
        result = {
            "type": "MonoBehaviour",
            "script_name": script_name,
        }

        for attr_name in ("m_Enabled", "m_Enabled"):
            val = getattr(data, attr_name, None)
            if val is not None:
                result["enabled"] = _safe_bool(val, True)
                break

        floats = []
        strings = []
        ints = []
        bools = []

        if hasattr(data, "__dict__"):
            for key, val in data.__dict__.items():
                if key.startswith("m_") or key.startswith("_"):
                    continue
                if isinstance(val, float):
                    floats.append({"name": key, "value": _safe_float(val)})
                elif isinstance(val, int) and not isinstance(val, bool):
                    ints.append({"name": key, "value": _safe_int(val)})
                elif isinstance(val, str):
                    strings.append({"name": key, "value": _safe_str(val)})
                elif isinstance(val, bool):
                    bools.append({"name": key, "value": _safe_bool(val)})

        if floats:
            result["floats"] = floats[:30]
        if strings:
            result["strings"] = strings[:30]
        if ints:
            result["ints"] = ints[:30]
        if bools:
            result["bools"] = bools[:30]

        return result

    # ── Conversion helpers ────────────────────────────────────────────

    def _color_to_dict(self, color) -> dict:
        if color is None:
            return {"r": 1.0, "g": 1.0, "b": 1.0, "a": 1.0}
        return {
            "r": _safe_float(getattr(color, "r", None), 1.0),
            "g": _safe_float(getattr(color, "g", None), 1.0),
            "b": _safe_float(getattr(color, "b", None), 1.0),
            "a": _safe_float(getattr(color, "a", None), 1.0),
        }

    def _vec2_to_dict(self, v) -> dict:
        if v is None:
            return {"x": 0.0, "y": 0.0}
        return {
            "x": _safe_float(getattr(v, "x", None), 0.0),
            "y": _safe_float(getattr(v, "y", None), 0.0),
        }

    def _vec3_to_dict(self, v) -> dict:
        if v is None:
            return {"x": 0.0, "y": 0.0, "z": 0.0}
        return {
            "x": _safe_float(getattr(v, "x", None), 0.0),
            "y": _safe_float(getattr(v, "y", None), 0.0),
            "z": _safe_float(getattr(v, "z", None), 0.0),
        }

    def _vec4_to_dict(self, v) -> dict:
        if v is None:
            return {"x": 0.0, "y": 0.0, "z": 0.0, "w": 1.0}
        return {
            "x": _safe_float(getattr(v, "x", None), 0.0),
            "y": _safe_float(getattr(v, "y", None), 0.0),
            "z": _safe_float(getattr(v, "z", None), 0.0),
            "w": _safe_float(getattr(v, "w", None), 1.0),
        }

    # ── Classification ────────────────────────────────────────────────

    def _classify(self, source_name: str) -> tuple[str, str]:
        sn = source_name.lower()
        faction = "common"
        category = "misc"

        factions = [
            "romans", "egyptians", "gauls", "huns",
            "spartans", "teutons", "vikings",
        ]
        for f in factions:
            if f in sn:
                faction = f
                break

        if "building" in sn:
            category = "buildings"
        elif "unit" in sn:
            category = "units"
        elif "hero" in sn or "portrait" in sn:
            category = "heroes"
        elif "header" in sn:
            category = "ui/header"
        elif "lobby" in sn:
            category = "ui/lobby"
        elif "village" in sn:
            category = "village"
        elif "resource" in sn:
            category = "resources"
        elif "translation" in sn:
            category = "localization"
        elif "icon" in sn:
            category = "icons"
        elif "general" in sn:
            category = "general"
        elif "spriteatlas" in sn:
            category = "spriteatlases"

        return faction, category

    def _safe_filename(self, name: str) -> str:
        for c in '<>:"/\\|?*':
            name = name.replace(c, "_")
        return name[:200] if name else "unnamed"
