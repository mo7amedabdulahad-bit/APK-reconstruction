# APK Reconstruction Pipeline — Session Summary

## What Was Done

### 1. Image Component Field Offset Fix (app.py)

**Problem:** Every Image component's `m_Sprite` was missing from the UI dump output.

**Root cause:** The `_parse_ui_component_fields` function assumed the wrong memory layout for Unity's `Image` MonoBehaviour. The original offsets were:
- m_Sprite at `field_start + 0`
- m_Color at `field_start + 24`

The actual Unity layout (verified by raw byte analysis) is:
- m_Material at `field_start + 0` (12 bytes, PPtr)
- m_Color at `field_start + 12` (16 bytes, 4 floats RGBA)
- m_RaycastTarget at `field_start + 28` (1 byte, bool)
- m_Sprite at `field_start + 32` (12 bytes, PPtr)

**Evidence of the bug:** `m_Color.g` consistently read as `0x00000001` (integer 1 interpreted as float = `1.4e-45`), which was actually `m_RaycastTarget = true` being read as a float at the wrong offset.

**Fix applied:**
```python
# Before (wrong)
sprite_off = field_start + 0
color_off = field_start + 24

# After (correct)
sprite_off = field_start + 32
color_off = field_start + 12
```

Same fix applied to `RawImage.m_Texture` (also at `field_start + 32`).

**File:** `il2cpp_recovery_studio/gui/app.py` lines 1186-1216

---

### 2. Sprite Resolver Path_id Fallback Fix (sprite_resolver.py)

**Problem:** The path_id-only fallback in `resolve_pptr_global` matched ANY object type (Texture2D, Material, Font) instead of only Sprite objects. This caused the same PNG (`sactx-0-2048x2048-Crunch-IconsBuildings_Spartans-0204cfa7`) to be copied to nearly every scene.

**Fix applied:** Added `entry.get("type") == "Sprite"` filter to the path_id-only fallback, plus reverse atlas lookup.

**File:** `il2cpp_recovery_studio/gui/sprite_resolver.py` line ~190

---

### 3. Pipeline Re-run Results

After the fixes, the full pipeline (Stage 4 → 6) was re-run:

| Stage | Result |
|-------|--------|
| Stage 4 (UI Dump) | 216,770 objects processed |
| Sprite Coverage | **91.9%** (194,946 / 212,123 resolved) — up from ~30% |
| Stage 5 (Normalization) | 2,153 normalized trees, **448 scenes with root nodes** |
| Stage 6 (AI Companions) | 448 AI Prompt Companions generated |

---

## Current Issues

### Issue 1: 99.99% of Image Components Have No Sprite

**Observation:** Of 18,967 Image components found, only **2** have an actual sprite PPtr assigned. The remaining 18,965 have `sprite: fid=0, pid=0` (null).

**Why:** This is how the game is designed. The game (Travian Legends Mobile) uses **colored rectangles** for most UI elements rather than sprite-based images. Image components are configured with:
- `m_Color`: RGBA color (e.g., `rgba(255,255,255,1.0)` for white backgrounds)
- `m_Sprite`: null (no texture)

This is a common pattern in mobile games — using Unity's Image component as a colored rect with runtime-generated or atlas-based sprites.

**Impact:** The UI dump correctly captures colors and hierarchy, but there are very few actual image files to export. The layout XML and color data are complete.

### Issue 2: "0 Unity GameObjects Parsed" Display Bug

**Observation:** Every AI Prompt Companion markdown file reports `Unity GameObjects Parsed: 0`, even for scenes with 94+ nodes in the tree.

**Root cause:** In `ai_ui_compiler.py` line 589:
```python
markdown_str = generate_companion_markdown(
    scene_name, xml_str, all_assets, data.get("raw_count", 0)
)
```

The normalized JSON files have two different formats:
- Files **without** roots: `{ source, raw_count, roots: [] }` — `raw_count` exists
- Files **with** roots: `{ source, bundle_file, root_count, roots: [...] }` — no `raw_count`

When `data.get("raw_count", 0)` is called on a file with roots, it returns 0 because the key doesn't exist.

**Impact:** Purely cosmetic — the XML layout, text labels, and image assets are all generated correctly. The markdown header just shows wrong statistics.

**Fix:** Count tree nodes when `raw_count` is missing:
```python
raw_count = data.get("raw_count")
if raw_count is None:
    # Count nodes in the tree
    def _count(n):
        c = 1
        for ch in n.get("children", []):
            c += _count(ch)
        return c
    raw_count = sum(_count(r) for r in data.get("roots", []))
```

### Issue 3: Dynamic Text Matching

**Observation:** Dynamic text injection fails for all scenes. There is only 1 class bucket with 175 strings, and its key doesn't match any scene name.

**Status:** Not critical — scenes already capture static text through the TMP text component parser. Dynamic text is a supplementary feature.

---

## Files Modified

| File | Change |
|------|--------|
| `il2cpp_recovery_studio/gui/app.py` | Image/RawImage field offset fix (+32/+12) |
| `il2cpp_recovery_studio/gui/sprite_resolver.py` | Path_id fallback type filter + reverse atlas |
| `il2cpp_recovery_studio/gui/ai_ui_compiler.py` | (pending fix for raw_count display bug) |

## Files NOT Modified

| File | Reason |
|------|--------|
| `scripts/parse-unity-bundle.mjs` | Node.js parser works correctly — produces proper trees |
| `normalized_ui/` | Regenerated by re-running Stage 5 |

---

## Architecture Notes

### How the Pipeline Works

```
Stage 4: Python (UnityPy) reads raw bundles → writes ui_dump/*.json
  - Each bundle → one JSON file with flat object list
  - Objects include: GameObjects, RectTransforms, MonoBehaviours, Sprites, etc.
  - MonoBehaviour fields parsed from raw bytes (not typetree) on protected builds

Stage 5: Node.js (parse-unity-bundle.mjs) reads ui_dump → writes normalized_ui/*.json
  - Builds parent-child tree from RectTransform m_Father/m_Children
  - Resolves component references (Image, Text, Button, etc.)
  - Produces normalized tree nodes with layout/visual/interaction data

Stage 6: Python (ai_ui_compiler.py) reads normalized_ui → writes ai_export/scenes/
  - Converts trees to XML layout
  - Collects asset references (sprites, fonts, text)
  - Generates AI Prompt Companion markdown files
```

### Data Flow for Image Components

```
Unity Bundle
  → UnityPy loads raw bytes
    → _parse_monobehaviour_header() extracts header (m_GameObject, m_Script, m_Name)
      → _parse_ui_component_fields() reads component fields from raw bytes
        → Image: m_Color at +12, m_Sprite PPtr at +32
          → _resolve_pptr_fields() looks up sprite name in global sprite_index
            → sprite_index built from all Sprite objects + SpriteAtlas unpacking
```

### Why Most Images Have No Sprite

The game uses Unity's `Image` component as a **colored rectangle**. The component has:
- A `m_Color` (RGBA) for the visual appearance
- No `m_Sprite` (null PPtr) — the default white texture is used

This is equivalent to a `<div style="background-color: rgba(...)"></div>` in HTML. The actual visual content comes from:
1. Sprite-based Image components (only 2 found)
2. RawImage components (which reference textures directly)
3. Runtime-generated content (not in static dumps)
