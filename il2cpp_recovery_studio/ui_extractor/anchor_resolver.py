"""Resolve Unity anchor min/max pairs into human-readable strings."""
from __future__ import annotations

ANCHOR_MAP: dict[tuple[tuple[float, float], tuple[float, float]], str] = {
    ((0, 0), (0, 0)): "bottom_left",
    ((0, 1), (0, 1)): "top_left",
    ((1, 0), (1, 0)): "bottom_right",
    ((1, 1), (1, 1)): "top_right",
    ((0.5, 0.5), (0.5, 0.5)): "middle_center",
    ((0, 0.5), (0, 0.5)): "middle_left",
    ((1, 0.5), (1, 0.5)): "middle_right",
    ((0.5, 0), (0.5, 0)): "bottom_center",
    ((0.5, 1), (0.5, 1)): "top_center",
    ((0, 0), (1, 0)): "stretch_bottom",
    ((0, 1), (1, 1)): "stretch_top",
    ((0, 0), (0, 1)): "stretch_left",
    ((1, 0), (1, 1)): "stretch_right",
    ((0, 0), (1, 1)): "stretch_full",
}


def resolve_anchor(anchor_min: dict, anchor_max: dict) -> str:
    """Convert Unity anchorMin/anchorMax Vector2 pair to a human-readable string.

    Rounds values to 1 decimal place before lookup.  Returns ``"custom"`` if
    the pair is not found in the predefined map.
    """
    min_x = round(float(anchor_min.get("x", 0)), 1)
    min_y = round(float(anchor_min.get("y", 0)), 1)
    max_x = round(float(anchor_max.get("x", 0)), 1)
    max_y = round(float(anchor_max.get("y", 0)), 1)

    key = ((min_x, min_y), (max_x, max_y))
    return ANCHOR_MAP.get(key, "custom")
