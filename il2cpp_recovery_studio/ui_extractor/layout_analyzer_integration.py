"""Integration shim: call LayoutAnalyzer inside the hierarchy extractor.

This is imported by hierarchy.py's _build_screen_spec so that
layout_hint fields are written into every element before the JSON is
written to disk.
"""
from __future__ import annotations

from .layout_analyzer import LayoutAnalyzer

_analyzer = LayoutAnalyzer()


def annotate_screen(screen_spec: dict) -> None:
    """In-place: add layout_hint fields + layout_summary to *screen_spec*."""
    elements = screen_spec.get("elements", [])
    canvas_size = screen_spec.get("canvas_size", {"width": 1080, "height": 1920})
    summary = _analyzer.analyze(elements, canvas_size)
    screen_spec["layout_summary"] = summary
