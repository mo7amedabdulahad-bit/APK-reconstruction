"""SpriteAtlas unpacking — recover sprites packed inside SpriteAtlases.

This is a standalone module (Phase 5, Task 5.1).  It walks a UnityPy
environment and reads every ``Sprite`` object directly via ``obj.read()``
(no MonoBehaviour involvement) to recover:

    * the sprite's ``path_id`` (stable cross-bundle identifier),
    * its ``rect`` (x/y/width/height within the atlas texture), and
    * the ``atlas`` texture it is packed into.

The result is keyed by sprite name so callers can merge the recovered
sprites into a global sprite index and resolve null-sprite ``Image``
components that would otherwise point at an un-named packed sprite.

UnityPy is imported lazily inside the function so this module is safe to
import even when UnityPy is not installed (e.g. in unit tests).
"""
from __future__ import annotations

from typing import Callable, Dict


def _safe_rect(m_rect) -> Dict[str, float | None] | None:
    """Extract an {x, y, width, height} rect from a Unity m_Rect struct."""
    if m_rect is None:
        return None
    try:
        return {
            "x": getattr(m_rect, "x", None),
            "y": getattr(m_rect, "y", None),
            "width": getattr(m_rect, "width", None),
            "height": getattr(m_rect, "height", None),
        }
    except Exception:
        return None


def _safe_name(obj) -> str | None:
    """Best-effort name from a read Sprite object."""
    return getattr(obj, "m_Name", None) or getattr(obj, "name", None) or None


def _resolve_atlas_name(data) -> str | None:
    """Find the atlas/texture name a sprite is packed into.

    Sprites carry their packing info in ``m_RD`` (SpriteRenderData), which
    references either the parent ``atlas`` (SpriteAtlas) or the underlying
    ``texture`` (Texture2D).  Either name is useful for grouping.
    """
    rd = getattr(data, "m_RD", None)
    if rd is None:
        return None
    for attr in ("atlas", "texture"):
        cand = getattr(rd, attr, None)
        if cand is None:
            continue
        name = getattr(cand, "m_Name", None) or getattr(cand, "name", None)
        if name:
            return name
    return None


def recover_atlas_sprites(env, log: Callable) -> Dict[str, dict]:
    """Recover every Sprite packed inside SpriteAtlases in the merged env.

    Parameters
    ----------
    env : UnityPy.Environment
        The merged UnityPy environment (all bundles loaded).
    log : Callable[[str], None]
        Progress/diagnostic logger.

    Returns
    -------
    dict
        ``{sprite_name: {"path_id": int, "rect": dict, "atlas": str|None}}``

        Sprites whose ``obj.read()`` fails (protected/obfuscated builds) or
        that have no name are skipped silently.  If two sprites share a name
        the later one wins (keyed by name per the contract).
    """
    result: Dict[str, dict] = {}

    objects = getattr(env, "objects", None)
    if objects is None:
        log("[WARN ] recover_atlas_sprites: env has no `objects` attribute")
        return result

    total = 0
    recovered = 0
    for obj in objects:
        total += 1
        # Only Sprite objects — never MonoBehaviour.
        obj_type = getattr(obj, "type", None)
        if obj_type is None or getattr(obj_type, "name", None) != "Sprite":
            continue
        try:
            data = obj.read()
        except Exception:
            # Protected build: native read failed — skip this sprite.
            continue

        name = _safe_name(data)
        if not name:
            continue

        result[name] = {
            "path_id": getattr(obj, "path_id", None),
            "rect": _safe_rect(getattr(data, "m_Rect", None)),
            "atlas": _resolve_atlas_name(data),
        }
        recovered += 1

    log(f"[OK   ] recover_atlas_sprites: scanned {total} objects, "
        f"recovered {recovered} atlas sprites")
    return result
