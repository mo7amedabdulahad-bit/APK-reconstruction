"""Read individual Unity component types into plain dicts.

Every public method accepts a UnityPy-read component object and returns a
dictionary suitable for JSON serialisation.  Field access always uses
``getattr(data, field, default)`` so that missing data never causes crashes.
"""
from __future__ import annotations


# ── helpers ──────────────────────────────────────────────────────────────────

def _safe_float(v, default: float = 0.0) -> float:
    if v is None:
        return default
    try:
        f = float(v)
        return default if f != f else f
    except (TypeError, ValueError):
        return default


def _safe_int(v, default: int = 0) -> int:
    if v is None:
        return default
    try:
        return int(v)
    except (TypeError, ValueError):
        return default


def _safe_str(v, default: str = "") -> str:
    return str(v) if v is not None else default


def _safe_bool(v, default: bool = False) -> bool:
    if v is None:
        return default
    try:
        return bool(v)
    except (TypeError, ValueError):
        return default


def _vec2(v) -> dict:
    if v is None:
        return {"x": 0.0, "y": 0.0}
    return {
        "x": _safe_float(getattr(v, "x", None)),
        "y": _safe_float(getattr(v, "y", None)),
    }


def _vec3(v) -> dict:
    if v is None:
        return {"x": 0.0, "y": 0.0, "z": 0.0}
    return {
        "x": _safe_float(getattr(v, "x", None)),
        "y": _safe_float(getattr(v, "y", None)),
        "z": _safe_float(getattr(v, "z", None)),
    }


def _vec4(v) -> dict:
    if v is None:
        return {"x": 0.0, "y": 0.0, "z": 0.0, "w": 1.0}
    return {
        "x": _safe_float(getattr(v, "x", None)),
        "y": _safe_float(getattr(v, "y", None)),
        "z": _safe_float(getattr(v, "z", None)),
        "w": _safe_float(getattr(v, "w", None), 1.0),
    }


def _color(v) -> dict:
    if v is None:
        return {"r": 1.0, "g": 1.0, "b": 1.0, "a": 1.0}
    return {
        "r": _safe_float(getattr(v, "r", None), 1.0),
        "g": _safe_float(getattr(v, "g", None), 1.0),
        "b": _safe_float(getattr(v, "b", None), 1.0),
        "a": _safe_float(getattr(v, "a", None), 1.0),
    }


# ── image type / font style / alignment maps ────────────────────────────────

IMAGE_TYPES = {0: "Simple", 1: "Sliced", 2: "Tiled", 3: "Filled"}
FONT_STYLES = {0: "Normal", 1: "Bold", 2: "Italic", 3: "BoldItalic"}

_ALIGNMENT_MAP = {
    0: "UpperLeft", 1: "UpperCenter", 2: "UpperRight",
    3: "MiddleLeft", 4: "MiddleCenter", 5: "MiddleRight",
    6: "LowerLeft", 7: "LowerCenter", 8: "LowerRight",
}


# ── ComponentReader ──────────────────────────────────────────────────────────

class ComponentReader:
    """Reads Unity component objects into plain dicts for JSON serialisation."""

    # ── RectTransform ────────────────────────────────────────────────────

    @staticmethod
    def read_rect_transform(data) -> dict:
        local_pos = _vec3(getattr(data, "m_LocalPosition", None))
        size_delta = _vec2(getattr(data, "m_SizeDelta", None))
        anchor_min = _vec2(getattr(data, "m_AnchorMin", None))
        anchor_max = _vec2(getattr(data, "m_AnchorMax", None))
        pivot = _vec2(getattr(data, "m_Pivot", None))
        local_scale = _vec3(getattr(data, "m_LocalScale", None))
        local_rot = _vec4(getattr(data, "m_LocalRotation", None))

        anchored_pos = _vec2(getattr(data, "m_AnchoredPosition", None))

        return {
            "type": "RectTransform",
            "local_position": local_pos,
            "anchored_position": anchored_pos,
            "size_delta": size_delta,
            "anchor_min": anchor_min,
            "anchor_max": anchor_max,
            "pivot": pivot,
            "local_scale": local_scale,
            "local_rotation": local_rot,
        }

    # ── Canvas ───────────────────────────────────────────────────────────

    @staticmethod
    def read_canvas(data) -> dict:
        return {
            "type": "Canvas",
            "render_mode": _safe_int(getattr(data, "m_RenderMode", None), 0),
            "sorting_order": _safe_int(getattr(data, "m_SortingOrder", None), 0),
            "reference_pixels_per_unit": _safe_float(
                getattr(data, "m_ReferencePixelsPerUnit", None), 100.0
            ),
            "pixel_perfect": _safe_bool(
                getattr(data, "m_PixelPerfect", None), False
            ),
        }

    # ── Image (UI.Image MonoBehaviour) ──────────────────────────────────

    @staticmethod
    def read_image(data) -> dict:
        sprite_name = ""
        sprite_ref = getattr(data, "m_Sprite", None)
        if sprite_ref is not None:
            try:
                sprite_obj = sprite_ref.read()
                sprite_name = _safe_str(getattr(sprite_obj, "m_Name", None))
            except Exception:
                pass

        raw_type = _safe_int(getattr(data, "m_Type", None), 0)
        return {
            "type": "Image",
            "sprite_name": sprite_name,
            "color": _color(getattr(data, "m_Color", None)),
            "image_type": IMAGE_TYPES.get(raw_type, "Simple"),
            "fill_amount": _safe_float(getattr(data, "m_FillAmount", None), 1.0),
            "raycast_target": _safe_bool(getattr(data, "m_RaycastTarget", None), True),
            "preserve_aspect": _safe_bool(
                getattr(data, "m_PreserveAspect", None), False
            ),
        }

    # ── Text (UI.Text MonoBehaviour) ────────────────────────────────────

    @staticmethod
    def read_text(data) -> dict:
        font_name = ""
        font_ref = getattr(data, "m_Font", None)
        if font_ref is not None:
            try:
                font_obj = font_ref.read()
                font_name = _safe_str(getattr(font_obj, "m_Name", None))
            except Exception:
                pass

        raw_style = _safe_int(getattr(data, "m_FontStyle", None), 0)
        raw_align = _safe_int(getattr(data, "m_Alignment", None), 4)

        return {
            "type": "Text",
            "text": _safe_str(getattr(data, "m_Text", None)),
            "font_name": font_name,
            "font_size": _safe_int(getattr(data, "m_FontSize", None), 14),
            "font_style": FONT_STYLES.get(raw_style, "Normal"),
            "color": _color(getattr(data, "m_Color", None)),
            "alignment": _ALIGNMENT_MAP.get(raw_align, "MiddleCenter"),
            "horizontal_overflow": _safe_int(
                getattr(data, "m_HorizontalOverflow", None), 0
            ),
            "vertical_overflow": _safe_int(
                getattr(data, "m_VerticalOverflow", None), 0
            ),
            "line_spacing": _safe_float(
                getattr(data, "m_LineSpacing", None), 1.0
            ),
            "support_rich_text": _safe_bool(
                getattr(data, "m_SupportRichText", None), False
            ),
            "best_fit": _safe_bool(getattr(data, "m_BestFit", None), False),
            "font_size_min": _safe_int(
                getattr(data, "m_FontSizeMin", None), 10
            ),
            "font_size_max": _safe_int(
                getattr(data, "m_FontSizeMax", None), 72
            ),
        }

    # ── Button (UI.Button MonoBehaviour) ─────────────────────────────────

    @staticmethod
    def read_button(data) -> dict:
        colors = getattr(data, "m_Colors", None)
        normal = _color(getattr(colors, "m_NormalColor", None) if colors else None)
        highlighted = _color(
            getattr(colors, "m_HighlightedColor", None) if colors else None
        )
        pressed = _color(
            getattr(colors, "m_PressedColor", None) if colors else None
        )
        disabled = _color(
            getattr(colors, "m_DisabledColor", None) if colors else None
        )

        return {
            "type": "Button",
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
            "transition": _safe_int(getattr(data, "m_Transition", None), 1),
            "normal_color": normal,
            "highlighted_color": highlighted,
            "pressed_color": pressed,
            "disabled_color": disabled,
        }

    # ── CanvasGroup ──────────────────────────────────────────────────────

    @staticmethod
    def read_canvas_group(data) -> dict:
        return {
            "type": "CanvasGroup",
            "alpha": _safe_float(getattr(data, "m_Alpha", None), 1.0),
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
            "blocks_raycasts": _safe_bool(
                getattr(data, "m_BlocksRaycasts", None), True
            ),
        }

    # ── RawImage ─────────────────────────────────────────────────────────

    @staticmethod
    def read_raw_image(data) -> dict:
        tex_name = ""
        tex_ref = getattr(data, "m_Texture", None)
        if tex_ref is not None:
            try:
                tex_obj = tex_ref.read()
                tex_name = _safe_str(getattr(tex_obj, "m_Name", None))
            except Exception:
                pass

        return {
            "type": "RawImage",
            "texture_name": tex_name,
            "color": _color(getattr(data, "m_Color", None)),
            "raycast_target": _safe_bool(
                getattr(data, "m_RaycastTarget", None), True
            ),
        }

    # ── Outline / Shadow ─────────────────────────────────────────────────

    @staticmethod
    def read_outline(data) -> dict:
        return {
            "type": "Outline",
            "effect_color": _color(getattr(data, "m_EffectColor", None)),
            "effect_distance": _vec2(
                getattr(data, "m_EffectDistance", None)
            ),
        }

    @staticmethod
    def read_shadow(data) -> dict:
        return {
            "type": "Shadow",
            "effect_color": _color(getattr(data, "m_EffectColor", None)),
            "effect_distance": _vec2(
                getattr(data, "m_EffectDistance", None)
            ),
        }

    # ── Toggle ───────────────────────────────────────────────────────────

    @staticmethod
    def read_toggle(data) -> dict:
        return {
            "type": "Toggle",
            "is_on": _safe_bool(getattr(data, "m_IsOn", None), False),
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
        }

    # ── Slider ───────────────────────────────────────────────────────────

    @staticmethod
    def read_slider(data) -> dict:
        return {
            "type": "Slider",
            "value": _safe_float(getattr(data, "m_Value", None), 0.0),
            "min_value": _safe_float(getattr(data, "m_MinValue", None), 0.0),
            "max_value": _safe_float(getattr(data, "m_MaxValue", None), 1.0),
            "whole_numbers": _safe_bool(
                getattr(data, "m_WholeNumbers", None), False
            ),
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
        }

    # ── InputField ───────────────────────────────────────────────────────

    @staticmethod
    def read_input_field(data) -> dict:
        return {
            "type": "InputField",
            "text": _safe_str(getattr(data, "m_Text", None)),
            "character_limit": _safe_int(
                getattr(data, "m_CharacterLimit", None), 0
            ),
            "content_type": _safe_int(
                getattr(data, "m_ContentType", None), 0
            ),
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
        }

    # ── ScrollRect ───────────────────────────────────────────────────────

    @staticmethod
    def read_scroll_rect(data) -> dict:
        return {
            "type": "ScrollRect",
            "horizontal": _safe_bool(
                getattr(data, "m_Horizontal", None), True
            ),
            "vertical": _safe_bool(
                getattr(data, "m_Vertical", None), True
            ),
            "horizontal_scrollbar_visibility": _safe_int(
                getattr(data, "m_HorizontalScrollbarVisibility", None), 0
            ),
            "vertical_scrollbar_visibility": _safe_int(
                getattr(data, "m_VerticalScrollbarVisibility", None), 0
            ),
        }

    # ── Dropdown ─────────────────────────────────────────────────────────

    @staticmethod
    def read_dropdown(data) -> dict:
        options: list[str] = []
        opt_wrapper = getattr(data, "m_Options", None)
        if opt_wrapper is not None:
            option_list = getattr(opt_wrapper, "m_Options", None)
            if option_list:
                for opt in option_list:
                    options.append(_safe_str(getattr(opt, "m_Text", None)))

        return {
            "type": "Dropdown",
            "value": _safe_int(getattr(data, "m_Value", None), 0),
            "options": options,
            "interactable": _safe_bool(
                getattr(data, "m_Interactable", None), True
            ),
        }

    # ── Generic MonoBehaviour ────────────────────────────────────────────

    @staticmethod
    def read_raw_mono(data) -> dict:
        """Read the script name and collect all readable raw fields."""
        script_name = "Unknown"
        script_ref = getattr(data, "m_Script", None)
        if script_ref is not None:
            try:
                script_obj = script_ref.read()
                script_name = _safe_str(
                    getattr(script_obj, "m_Name", None), "Unknown"
                )
            except Exception:
                pass

        result: dict = {"type": "MonoBehaviour", "script_name": script_name}

        raw_fields: dict = {}
        if hasattr(data, "__dict__"):
            for key, val in data.__dict__.items():
                # Skip Python dunder/internal attributes, keep Unity m_ fields
                if key.startswith("__"):
                    continue
                if isinstance(val, float):
                    raw_fields[key] = _safe_float(val)
                elif isinstance(val, int) and not isinstance(val, bool):
                    raw_fields[key] = _safe_int(val)
                elif isinstance(val, str):
                    raw_fields[key] = _safe_str(val)
                elif isinstance(val, bool):
                    raw_fields[key] = _safe_bool(val)

        if raw_fields:
            result["raw_fields"] = raw_fields

        return result
