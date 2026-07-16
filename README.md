# APK Reconstruction — Travian Legends Mobile UI Extractor

A two-stage pipeline to extract **pixel-exact Unity UI data** from the Travian Legends Mobile APK and convert it into normalized JSON trees ready for React/Tailwind code generation.

---

## Pipeline Overview

```
APK / AssetBundles
       │
       ▼
 [Stage 1]  extract_ui_full.py      →  ui_dump/          (one JSON per bundle)
       │
       ▼
 [Stage 2]  scripts/parse-unity-bundle.mjs  →  normalized_ui/  (resolved UI trees)
       │
       ▼
 [Stage 3]  AI Agent  →  React/Tailwind components
```

---

## Requirements

```bash
pip install -r requirements.txt
node --version   # v18+ required for the parser script
```

---

## Stage 1 — Full Unity Asset Extraction

> **Script:** `extract_ui_full.py`  
> **Engine:** [UnityPy](https://github.com/K0lb3/UnityPy) ≥ 1.20  
> **Why:** The previous IL2CPP Recovery Studio tool only captured object names and loose PNGs. It left `m_Position = null` in all 37,223 RectTransform files and empty MonoBehaviour components — making pixel-exact layout reconstruction impossible. UnityPy reads all serialized fields natively.

### Run

```bash
# Extract the main APK data
python extract_ui_full.py "path/to/com.traviangames.travianlegendsmobile/assets/bin/Data" "ui_dump/main"

# Extract the asset pack (most UI bundles live here)
python extract_ui_full.py "path/to/UnityDataAssetPack/assets/bin/Data" "ui_dump/assetpack"
```

### Output

- `ui_dump/<subfolder>/<bundle_name>.json` — one file per source bundle, `path_id` unique within each file
- `ui_dump/<subfolder>/sprite_name_map.json` — maps every Sprite `path_id` → PNG filename for resolving `Image.m_Sprite`

### What is extracted per object type

| Type | Key fields captured |
|---|---|
| `RectTransform` | `m_AnchorMin/Max`, `m_AnchoredPosition`, `m_SizeDelta`, `m_OffsetMin/Max`, `m_Pivot`, `m_LocalScale`, `m_Father`, `m_Children` |
| `Image` | `m_Sprite` (path_id + name), `m_Color` (RGBA), `m_Type` (Simple/Sliced/Tiled/Filled), `m_FillMethod/Amount` |
| `TextMeshProUGUI` | `m_text`, `m_fontAsset`, `m_fontSize`, `m_fontStyle`, `m_alignment`, `m_color`, `m_margin` |
| `Button` | `m_Interactable`, `m_Colors`, `m_OnClick` (target + method name) |
| `CanvasScaler` | `m_UiScaleMode`, `m_ReferenceResolution`, `m_MatchWidthOrHeight` |
| `LayoutGroup` | `m_Padding`, `m_Spacing`, `m_ChildAlignment`, expand/control flags |
| `Sprite` | `m_Rect`, `m_Pivot`, `m_PixelsPerUnit`, `m_Border` (for 9-slice) |
| `ScrollRect`, `Slider`, `Toggle`, `InputField` | All layout and value fields |
| `Font` / `TMP_FontAsset` | Atlas texture reference, line spacing |

---

## Stage 2 — Bundle Parser & UI Tree Builder

> **Script:** `scripts/parse-unity-bundle.mjs`  
> **Runtime:** Node.js 18+

Reads the per-bundle JSONs from Stage 1, resolves PPtrs within each bundle, and builds a normalized element tree (layout, sprite, text, color, children) per UI window root.

### Run

```bash
node scripts/parse-unity-bundle.mjs ui_dump/assetpack normalized_ui
```

### Output format (one file per bundle)

```jsonc
{
  "source": "b_mapcellinfo_assets_all_xxx.bundle",
  "roots": [
    {
      "path_id": 40,
      "name": "MapCellInfoWindow",
      "is_active": true,
      "layout": {
        "anchorMin": { "x": 0, "y": 0 },
        "anchorMax": { "x": 1, "y": 1 },
        "sizeDelta": { "x": 0, "y": 0 }
      },
      "image": { "sprite": "panel_bg", "color": "rgba(255,255,255,1.000)", "type": 1 },
      "text": null,
      "children": [ ... ]
    }
  ]
}
```

---

## Stage 3 — AI Agent Code Generation

Feed the normalized JSON files from `normalized_ui/` to your AI agent with the prompt:

> "Generate a pixel-exact React/Tailwind component for the UI tree in this JSON. Use absolute positioning derived from the `layout.anchorMin/Max/anchoredPosition/sizeDelta` fields. Reference sprites from `public/travian-ui/<screen>/<sprite>.png`. Apply colors from the `color` fields. Use the `text.content`, `text.fontSize`, and `text.color` fields for all text nodes."

### Recommended validation order

1. **MapCellInfoWindow** — small, self-contained, good first test
2. Village overview screen
3. Building detail panels
4. Navigation / HUD elements

---

## Folder Structure

```
APK-reconstruction/
├── extract_ui_full.py          ← Stage 1: UnityPy extractor
├── scripts/
│   └── parse-unity-bundle.mjs ← Stage 2: Node.js bundle parser
├── ui_dump/                    ← Stage 1 output (gitignored, large)
│   └── sprite_name_map.json
├── normalized_ui/              ← Stage 2 output (gitignored, large)
├── il2cpp_recovery_studio/     ← Existing IL2CPP code recovery tool
├── extracted_assets/           ← Existing extracted PNGs
├── requirements.txt
└── README.md
```

---

## Known Limitations

- **3D splash/loading screen hero** cannot be reconstructed from this pipeline. It requires exporting the SkinnedMesh to `.gltf/.glb` via Unity Editor or a dedicated mesh exporter.
- **Dynamic/localized text**: `m_text` captures the inspector-default string. Runtime-localized strings are in `extracted_assets/localization/` — match them by the localization key stored in the `MonoBehaviour` component of each TMP object.
- **Cross-bundle PPtrs** (`m_FileID != 0`) are noted in the output but not auto-resolved. If a sprite lives in a shared atlas bundle, search `sprite_name_map.json` by name.
