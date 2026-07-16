"""Merged-environment sprite resolution for cross-bundle PPtr lookups.

When Unity bundles reference sprites in *other* bundles (shared icon/UI
bundles loaded separately from feature-specific bundles), the per-file
UnityPy.load() call cannot resolve those PPtrs.  This module loads ALL
files into a single merged environment so cross-bundle resolution works
natively, and provides explicit unresolved markers for anything that
still can't be resolved.
"""
from __future__ import annotations

import json
import os
from pathlib import Path
from typing import Callable, Optional


def _find_unity_data_dir(raw_dir: Path) -> Path | None:
    """Find the Unity data directory containing assets/bin/Data.

    Handles various XAPK/APK extraction structures:
    - raw/<apk_stem>/assets/bin/Data (expected)
    - raw/UnityDataAssetPack/assets/bin/Data (actual Google Play XAPK)
    - raw/*/assets/bin/Data (fallback)

    Returns the directory CONTAINING assets/bin/Data (i.e., the dir with assets/ subdir)
    """
    # 1. Check expected location (raw/<apk_stem>/assets/bin/Data)
    for stem_dir in raw_dir.iterdir():
        if stem_dir.is_dir():
            candidate = stem_dir / "assets" / "bin" / "Data"
            if candidate.exists():
                return stem_dir  # Return the dir containing assets/

    # 2. Check UnityDataAssetPack (common for Google Play XAPKs)
    unity_pack = raw_dir / "UnityDataAssetPack"
    if unity_pack.exists():
        candidate = unity_pack / "assets" / "bin" / "Data"
        if candidate.exists():
            return unity_pack

    # 3. Fallback: search all subdirs
    for candidate in raw_dir.rglob("assets/bin/Data"):
        if candidate.exists():
            return candidate.parent.parent  # Return the dir containing assets/

    return None


def build_global_env(raw_dir: Path, log: Callable) -> object:
    """Load ALL serialized files + .bundle files into ONE merged environment.

    Returns a UnityPy Environment that contains every object from every
    source file, enabling native cross-bundle PPtr resolution.
    """
    import UnityPy

    # Count files for info message
    all_files: list[Path] = []
    for data_dir in raw_dir.rglob("assets/bin/Data"):
        if data_dir.is_dir():
            for child in sorted(data_dir.iterdir()):
                if child.is_file():
                    all_files.append(child)
    # Also include split asset files (sharedassets*.assets*)
    unity_data_dir = _find_unity_data_dir(raw_dir)
    if unity_data_dir:
        data_dir = unity_data_dir / "assets" / "bin" / "Data"
        if data_dir.exists():
            processed_stems = set()
            for asset_file in data_dir.glob("sharedassets*.assets*"):
                if asset_file.is_file():
                    # Skip split files (.split0, .split1, ...) and .resS files
                    name = asset_file.name
                    if ".split" in name or name.endswith(".resS"):
                        continue
                    # Avoid adding same file multiple times (stem check)
                    stem = asset_file.stem
                    if stem in processed_stems:
                        continue
                    processed_stems.add(stem)
                    all_files.append(asset_file)
    for bundle in raw_dir.rglob("*.bundle"):
        all_files.append(bundle)

    log(f"[INFO ] Building merged environment from {len(all_files)} files…")

    # UnityPy.load() with a directory recursively loads all Unity asset files
    env = UnityPy.load(str(raw_dir))

    total_objects = sum(1 for _ in env.objects)
    log(f"[OK   ] Merged environment ready — {total_objects} objects across {len(all_files)} files")
    return env


def build_global_sprite_index(env, log: Callable) -> dict[str, dict]:
    """Pre-pass that indexes every Sprite/Texture2D/Material/Font/TMP_FontAsset.

    Returns a dict keyed by ``"{assetsfile_name}|{path_id}"`` mapping to
    ``{"name": ..., "type": ...}``.
    """
    index: dict[str, dict] = {}
    for o in env.objects:
        if o.type.name not in ("Sprite", "Texture2D", "Material",
                               "Font", "TMP_FontAsset"):
            continue
        try:
            data = o.read()
            name = getattr(data, "m_Name", None) or getattr(data, "name", None) or ""
        except Exception:
            name = ""
        file_name = ""
        if getattr(o, "assets_file", None) is not None:
            file_name = getattr(o.assets_file, "name", "") or ""
        key = f"{file_name}|{o.path_id}"
        index[key] = {"name": name, "type": o.type.name, "path_id": o.path_id,
                      "file_name": file_name}

    log(f"[INFO ] Global sprite index: {len(index)} entries")
    return index


def resolve_pptr_global(
    pptr_obj,
    current_file: str,
    sprite_index: dict[str, dict],
    log: Optional[Callable] = None,
) -> dict:
    """Resolve a PPtr that failed local resolution using the global index.

    1. Try the pointer's own file_id -> externals table lookup (native).
    2. Fall back to a path_id-only match across all indexed files.
    3. If still unresolved, return an explicit ``{"unresolved": True, ...}``
       dict — NEVER None, NEVER silently omitted.
    """
    if pptr_obj is None:
        return {"unresolved": True, "reason": "null_pointer"}

    pid = getattr(pptr_obj, "path_id", None)
    fid = getattr(pptr_obj, "file_id", None)

    # Try native read first (works if the object is in the same merged env)
    name = None
    if hasattr(pptr_obj, "read"):
        try:
            read = pptr_obj.read()
            name = getattr(read, "m_Name", None) or getattr(read, "name", None)
            type_name = None
            if hasattr(read, "type"):
                type_name = getattr(read.type, "name", None)
            
            # If this is a component or MonoBehaviour, return it directly.
            # Do NOT resolve it globally as a sprite/texture.
            if type_name and type_name not in ("Sprite", "Texture2D", "Material", "Font", "TMP_FontAsset"):
                result = {"path_id": pid}
                if fid is not None and fid != 0:
                    result["file_id"] = fid
                result["type"] = type_name
                if name:
                    result["name"] = name
                return result
        except Exception:
            pass

    if name:
        result = {"path_id": pid}
        if fid is not None and fid != 0:
            result["file_id"] = fid
        result["name"] = name
        return result

    # Try file_id-based lookup via externals
    if fid is not None and fid != 0 and hasattr(pptr_obj, "file_id"):
        try:
            externals = getattr(pptr_obj, "externals", None)
            if externals and fid < len(externals):
                target_file = externals[fid]
                lookup_key = f"{target_file}|{pid}"
                if lookup_key in sprite_index:
                    entry = sprite_index[lookup_key]
                    return {"path_id": pid, "file_id": fid,
                            "name": entry["name"], "resolved_global": True}
        except Exception:
            pass

    # Fallback: path_id-only match across all indexed files
    # GATED: controlled by APKREC_ENABLE_ATLAS_BINDING env var.
    from il2cpp_recovery_studio.core.config import FeatureFlags
    _ff = FeatureFlags()
    if _ff.enable_atlas_binding and pid is not None:
        # 1) Direct Sprite match by path_id
        for key, entry in sprite_index.items():
            if entry.get("path_id") == pid and entry.get("type") == "Sprite":
                return {"path_id": pid, "name": entry["name"],
                        "resolved_global": True, "match_strategy": "path_id_only"}
        # 2) Reverse atlas lookup: if path_id matches a Texture2D, find a
        #    Sprite whose "atlas" field names that texture.
        tex_name = None
        for key, entry in sprite_index.items():
            if entry.get("path_id") == pid and entry.get("type") == "Texture2D":
                tex_name = entry.get("name")
                break
        if tex_name:
            for key, entry in sprite_index.items():
                if entry.get("type") == "Sprite" and entry.get("atlas") == tex_name:
                    return {"path_id": pid, "name": entry["name"],
                            "resolved_global": True,
                            "match_strategy": "atlas_reverse_lookup"}

    # Truly unresolved — return explicit marker
    result = {"path_id": pid, "unresolved": True}
    if fid is not None and fid != 0:
        result["file_id"] = fid
    if log:
        log(f"[WARN ] Unresolved PPtr: path_id={pid} file_id={fid} from {current_file}")
    return result


def write_sprite_mapping_report(
    ui_dump_dir: Path,
    stats: dict,
    log: Callable,
) -> None:
    """Write ui_dump/sprite_mapping_report.json with per-bundle coverage."""
    report = {
        "total_resolved": stats.get("resolved", 0),
        "total_unresolved": stats.get("unresolved", 0),
        "total_pptrs": stats.get("resolved", 0) + stats.get("unresolved", 0),
        "coverage_pct": 0.0,
        "per_bundle": stats.get("per_bundle", {}),
    }
    total = report["total_pptrs"]
    if total > 0:
        report["coverage_pct"] = round(report["total_resolved"] / total * 100, 2)

    out_path = ui_dump_dir / "sprite_mapping_report.json"
    out_path.write_text(
        json.dumps(report, indent=2, ensure_ascii=False),
        encoding="utf-8",
    )
    log(f"[OK   ] Sprite mapping report: {report['coverage_pct']}% coverage "
        f"({report['total_resolved']}/{total} resolved)")
