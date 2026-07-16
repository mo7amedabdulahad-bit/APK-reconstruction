"""Additive Scene Bundle Grouping (Phase 6, Task 6.1).

Loads a group of related scene bundles (and/or asset directories) into a
SINGLE shared UnityPy Environment so that PPtrs which reference objects in
*other* bundles — e.g. a shared icon/UI bundle referenced from a feature
bundle — resolve natively instead of producing unresolved stubs.

UnityPy's ``load()`` accepts multiple paths and merges them into one
Environment's file set, which is exactly the cross-bundle resolution we
need for the Stage-4 UI dump.  UnityPy is imported lazily so this module
stays import-safe (unit tests can monkeypatch ``UnityPy.load``).
"""
from __future__ import annotations

from typing import List


def load_scene_group(scene_bundle_paths: List[str]) -> Environment:
    """Load all related scene bundles into one shared UnityPy Environment.

    Parameters
    ----------
    scene_bundle_paths : list[str]
        Paths to bundle/asset files and/or asset directories that belong to
        the same scene group.  Directories are loaded recursively; multiple
        files are merged into one Environment so cross-bundle PPtrs resolve.

    Returns
    -------
    UnityPy.Environment
        A single Environment containing the objects of every path, with
        cross-bundle references resolved.

    Raises
    ------
    ValueError
        If ``scene_bundle_paths`` is empty.
    """
    if not scene_bundle_paths:
        raise ValueError("load_scene_group() requires at least one bundle path")

    from UnityPy import load as unitypy_load

    paths = [str(p) for p in scene_bundle_paths]
    # UnityPy.load(*paths) loads every path into ONE shared Environment.
    return unitypy_load(*paths)
