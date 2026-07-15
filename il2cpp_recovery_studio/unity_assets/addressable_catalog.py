"""Addressable catalog name map (Phase 5, Task 5.2).

Unity Addressables ships a runtime ``assets/aa/catalog.json`` that maps an
addressable *key* (the address an asset is loaded by) to its location.  For
sprite/texture assets the key can be turned into the sprite's asset name,
which lets the UI-dump stage resolve ``Image`` components that reference a
sprite via its addressable address rather than a raw PPtr.

This module reads ``assets/aa/catalog.json`` either:

    * directly from an ``.apk`` / ``.xapk`` / ``.zip`` archive (catalog may
      be nested inside an inner APK for XAPK packages), or
    * from an already-extracted directory (searches for
      ``assets/aa/catalog.json`` recursively).

It returns ``{addressable_key: sprite_name}``.

All heavy imports (``json``, ``zipfile``) are local so the module imports
cleanly even when no Unity package tooling is installed.
"""
from __future__ import annotations

from pathlib import Path
from typing import Dict


def _read_catalog_from_zip(zf) -> str | None:
    """Find and return the text of ``assets/aa/catalog.json`` inside a zip.

    Tries the ``aa``-prefixed path first, then any ``catalog.json``.
    """
    names = zf.namelist()
    for n in names:
        if n.endswith("catalog.json") and "aa" in n.lower():
            try:
                return zf.read(n).decode("utf-8", errors="replace")
            except Exception:
                pass
    for n in names:
        if n.endswith("catalog.json"):
            try:
                return zf.read(n).decode("utf-8", errors="replace")
            except Exception:
                pass
    return None


def _sprite_name_from_key(key: str) -> str | None:
    """Derive a sprite/texture asset name from an addressable key.

    Keys look like ``Assets/Sprites/Foo.png`` or a plain address ``Foo``.
    GUID-style keys (``GUID:...``) carry no usable name and are rejected.
    """
    if not key or "GUID:" in key:
        return None
    last = key.split("/")[-1]
    for ext in (".png", ".jpg", ".jpeg", ".asset", ".spriteatlas",
                ".bytes", ".tga", ".exr"):
        if last.lower().endswith(ext):
            last = last[: -len(ext)]
            break
    return last or None


def _parse_catalog(cat: dict) -> Dict[str, str]:
    """Turn a parsed catalog.json into ``{addressable_key: sprite_name}``.

    Handles the common Addressables catalog shapes:
        * ``m_ResourceLocations.locations`` (list of location objects)
        * ``m_Locator.m_Locations`` (dict keyed by address -> list/dict)
        * top-level ``m_Locations`` (list)
    """
    locations: list = []

    rl = cat.get("m_ResourceLocations")
    if isinstance(rl, dict):
        locs = rl.get("locations")
        if isinstance(locs, list):
            locations.extend(locs)

    loc = cat.get("m_Locator")
    if isinstance(loc, dict):
        ml = loc.get("m_Locations")
        if isinstance(ml, dict):
            for v in ml.values():
                if isinstance(v, list):
                    locations.extend(v)
                elif isinstance(v, dict):
                    locations.append(v)
        elif isinstance(ml, list):
            locations.extend(ml)

    if isinstance(cat.get("m_Locations"), list):
        locations.extend(cat["m_Locations"])

    result: Dict[str, str] = {}
    for item in locations:
        if not isinstance(item, dict):
            continue
        key = (item.get("m_PrimaryKey")
               or item.get("m_InternalId")
               or item.get("key"))
        if not key:
            continue
        rtype = item.get("m_ResourceType") or ""
        # Only keep sprite/texture assets — those are what fill Image slots.
        if rtype and not any(t in rtype for t in ("Sprite", "Texture", "Texture2D")):
            continue
        sprite_name = _sprite_name_from_key(key)
        if sprite_name:
            result[key] = sprite_name
    return result


def load_addressable_catalog(apk_path) -> Dict[str, str]:
    """Read ``assets/aa/catalog.json`` and return ``{addressable_key: sprite_name}``.

    Parameters
    ----------
    apk_path : str | Path
        Path to the APK/XAPK/zip archive, *or* to an already-extracted
        directory containing ``assets/aa/catalog.json``.

    Returns
    -------
    dict
        ``{addressable_key: sprite_name}``.  Empty dict if no catalog is
        found or it cannot be parsed (non-fatal).
    """
    import json
    import zipfile

    p = Path(apk_path)
    raw_text: str | None = None

    if p.is_file():
        # Direct catalog inside the archive.
        try:
            with zipfile.ZipFile(p) as z:
                raw_text = _read_catalog_from_zip(z)
        except Exception:
            raw_text = None
        # XAPK: catalog may live inside an inner APK.
        if raw_text is None:
            try:
                with zipfile.ZipFile(p) as outer:
                    for n in outer.namelist():
                        if not n.endswith(".apk"):
                            continue
                        try:
                            with outer.open(n) as f, zipfile.ZipFile(f) as inner:
                                raw_text = _read_catalog_from_zip(inner)
                                if raw_text is not None:
                                    break
                        except Exception:
                            continue
            except Exception:
                pass
    elif p.is_dir():
        candidates = list(p.rglob("assets/aa/catalog.json"))
        if not candidates:
            candidates = list(p.rglob("**/aa/catalog.json"))
        if not candidates:
            candidates = list(p.rglob("catalog.json"))
        for c in candidates:
            try:
                raw_text = c.read_text(encoding="utf-8", errors="replace")
                if raw_text:
                    break
            except Exception:
                continue

    if not raw_text:
        return {}

    try:
        cat = json.loads(raw_text)
    except Exception:
        return {}

    if not isinstance(cat, dict):
        return {}

    return _parse_catalog(cat)
