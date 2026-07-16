"""Analyze a flat element list and annotate it with layout pattern hints.

Detects common Unity UI patterns (vertical lists, horizontal stacks,
grid layouts, overlay groups) and adds a ``layout_hint`` field to each
element so the AI agent can use the correct layout widget instead of
guessing from raw coordinates alone.
"""
from __future__ import annotations

import math
from typing import Optional

# ── tuneable thresholds ──────────────────────────────────────────────────────
_ALIGN_TOLERANCE = 8.0      # px — positions within this are considered aligned
_SPACING_TOLERANCE = 6.0    # px — gaps within this are considered uniform
_GRID_MIN_COLS = 2          # minimum columns to call something a grid
_GRID_MIN_ROWS = 2
_OVERLAP_THRESHOLD = 0.40   # fraction of area overlap to call siblings an overlay


class LayoutAnalyzer:
    """Add ``layout_hint`` and ``layout_group`` annotations to elements.

    Call :meth:`analyze` with the full element list from a screen spec.  It
    operates in-place — each element dict gets a new ``layout_hint`` key.
    Returns a summary dict for the screen spec's top-level metadata.
    """

    def analyze(self, elements: list[dict], canvas_size: dict) -> dict:
        """Annotate elements and return a ``layout_summary`` dict."""
        cw = canvas_size.get("width", 1080)
        ch = canvas_size.get("height", 1920)

        # index by id for quick parent lookups
        by_id: dict[str, dict] = {el["id"]: el for el in elements}

        # group children by parent
        by_parent: dict[Optional[str], list[dict]] = {}
        for el in elements:
            pid = el.get("parent_id")
            by_parent.setdefault(pid, []).append(el)

        groups_detected: list[dict] = []

        for parent_id, children in by_parent.items():
            if len(children) < 2:
                # single child — no layout pattern possible
                for ch_el in children:
                    ch_el.setdefault("layout_hint", "single")
                continue

            # Sort by layer_order
            children_sorted = sorted(children, key=lambda e: e.get("layer_order", 0))

            hint = self._classify_group(children_sorted, cw, ch)

            group_info = {
                "parent_id": parent_id,
                "child_count": len(children_sorted),
                "layout": hint["layout"],
            }
            if "columns" in hint:
                group_info["columns"] = hint["columns"]
            if "rows" in hint:
                group_info["rows"] = hint["rows"]
            if "spacing" in hint:
                group_info["spacing"] = hint["spacing"]

            groups_detected.append(group_info)

            for child in children_sorted:
                child["layout_hint"] = hint["layout"]
                if "spacing" in hint:
                    child["layout_spacing"] = hint["spacing"]
                if "columns" in hint:
                    child["layout_columns"] = hint["columns"]

        # Annotate remaining elements that weren't in any group
        for el in elements:
            el.setdefault("layout_hint", "absolute")

        return {"layout_groups": groups_detected}

    # ── classification ───────────────────────────────────────────────────────

    def _classify_group(
        self, children: list[dict], canvas_w: float, canvas_h: float
    ) -> dict:
        """Return a hint dict for a list of sibling elements."""

        # Check for overlapping elements (overlay / ZStack)
        if self._is_overlay(children):
            return {"layout": "overlay"}

        positions = [el.get("position", {"x": 0, "y": 0}) for el in children]
        sizes = [el.get("size", {"width": 0, "height": 0}) for el in children]

        xs = [p.get("x", 0) for p in positions]
        ys = [p.get("y", 0) for p in positions]

        x_range = max(xs) - min(xs)
        y_range = max(ys) - min(ys)

        # Check VStack (all same X, varying Y)
        if x_range <= _ALIGN_TOLERANCE:
            spacing = self._uniform_spacing(ys, sizes, axis="y")
            if spacing is not None:
                return {"layout": "VStack", "spacing": spacing}
            return {"layout": "VStack", "spacing": None}

        # Check HStack (all same Y, varying X)
        if y_range <= _ALIGN_TOLERANCE:
            spacing = self._uniform_spacing(xs, sizes, axis="x")
            if spacing is not None:
                return {"layout": "HStack", "spacing": spacing}
            return {"layout": "HStack", "spacing": None}

        # Check Grid
        grid = self._detect_grid(children)
        if grid:
            return grid

        # Fallback
        return {"layout": "absolute"}

    @staticmethod
    def _is_overlay(children: list[dict]) -> bool:
        """Return True if most children overlap each other significantly."""
        if len(children) < 2:
            return False
        overlapping = 0
        pairs = 0
        for i in range(len(children)):
            for j in range(i + 1, len(children)):
                pairs += 1
                if LayoutAnalyzer._overlap_fraction(children[i], children[j]) > _OVERLAP_THRESHOLD:
                    overlapping += 1
        return (overlapping / pairs) > 0.5

    @staticmethod
    def _overlap_fraction(a: dict, b: dict) -> float:
        """Fraction of the smaller element's area covered by the intersection."""
        a_pos = a.get("position", {"x": 0, "y": 0})
        a_size = a.get("size", {"width": 0, "height": 0})
        b_pos = b.get("position", {"x": 0, "y": 0})
        b_size = b.get("size", {"width": 0, "height": 0})

        # Convert Unity center-origin to AABB min/max
        ax1 = a_pos.get("x", 0) - a_size.get("width", 0) / 2
        ax2 = ax1 + a_size.get("width", 0)
        ay1 = a_pos.get("y", 0) - a_size.get("height", 0) / 2
        ay2 = ay1 + a_size.get("height", 0)

        bx1 = b_pos.get("x", 0) - b_size.get("width", 0) / 2
        bx2 = bx1 + b_size.get("width", 0)
        by1 = b_pos.get("y", 0) - b_size.get("height", 0) / 2
        by2 = by1 + b_size.get("height", 0)

        ix = max(0, min(ax2, bx2) - max(ax1, bx1))
        iy = max(0, min(ay2, by2) - max(ay1, by1))
        intersection = ix * iy

        area_a = a_size.get("width", 0) * a_size.get("height", 0)
        area_b = b_size.get("width", 0) * b_size.get("height", 0)
        smaller = min(area_a, area_b)
        if smaller <= 0:
            return 0.0
        return intersection / smaller

    @staticmethod
    def _uniform_spacing(
        coords: list[float],
        sizes: list[dict],
        axis: str,
    ) -> Optional[float]:
        """Return the uniform gap between elements, or None if not uniform."""
        if len(coords) < 2:
            return None
        dim_key = "height" if axis == "y" else "width"
        # Sort coords and sizes together
        paired = sorted(zip(coords, sizes), key=lambda p: p[0])
        gaps = []
        for i in range(len(paired) - 1):
            c1, s1 = paired[i]
            c2, s2 = paired[i + 1]
            half1 = s1.get(dim_key, 0) / 2
            half2 = s2.get(dim_key, 0) / 2
            gap = c2 - half2 - (c1 + half1)
            gaps.append(gap)
        if not gaps:
            return None
        avg = sum(gaps) / len(gaps)
        if all(abs(g - avg) <= _SPACING_TOLERANCE for g in gaps):
            return round(avg, 1)
        return None

    def _detect_grid(
        self, children: list[dict]
    ) -> Optional[dict]:
        """Try to detect a grid layout. Returns hint dict or None."""
        if len(children) < _GRID_MIN_COLS * _GRID_MIN_ROWS:
            return None

        positions = [el.get("position", {"x": 0, "y": 0}) for el in children]
        xs = sorted(set(round(p.get("x", 0) / _ALIGN_TOLERANCE) * _ALIGN_TOLERANCE for p in positions))
        ys = sorted(set(round(p.get("y", 0) / _ALIGN_TOLERANCE) * _ALIGN_TOLERANCE for p in positions))

        cols = len(xs)
        rows = len(ys)

        if cols >= _GRID_MIN_COLS and rows >= _GRID_MIN_ROWS:
            # Verify element count roughly matches grid slots
            if abs(len(children) - cols * rows) <= max(1, cols):
                sizes = [el.get("size", {"width": 0, "height": 0}) for el in children]
                avg_w = sum(s.get("width", 0) for s in sizes) / len(sizes)
                avg_h = sum(s.get("height", 0) for s in sizes) / len(sizes)
                return {
                    "layout": "Grid",
                    "columns": cols,
                    "rows": rows,
                    "spacing": {
                        "x": round((xs[1] - xs[0] - avg_w) if len(xs) > 1 else 0, 1),
                        "y": round((ys[1] - ys[0] - avg_h) if len(ys) > 1 else 0, 1),
                    },
                }
        return None
