# Unity Sprite-to-UI Mapping Report (Updated for Assets Version 5)

## Verdict: Version 5 Partially Solves the Issue

### What Version 5 DOES Solve

| Problem | Status | Solution |
|---------|--------|----------|
| Missing sprites (nav icons, etc.) | **SOLVED** | All 9,089 PNGs extracted to `unity_assets/` — every sprite in the game is here |
| No C# code access | **PARTIALLY SOLVED** | `dump.cs` (40MB) has all class/field/method signatures, but method bodies are empty il2cpp stubs |
| No string literals | **SOLVED** | `stringliteral.json` (3.3MB) has all hardcoded strings |
| No UI hierarchy | **SOLVED** | 4,695 JSON files in `ui_dump/` + `normalized_ui/` show full prefab hierarchies |
| No asset bundles | **SOLVED** | 57 `.bundle` files + 4 `.assets` files present |

### What Version 5 DOES NOT Solve

| Problem | Why | Impact |
|---------|-----|--------|
| **Sprite-to-UI mapping** | Method bodies in `dump.cs` are `{ }` (empty il2cpp stubs) — can't see `Addressables.LoadAssetAsync<Sprite>("key")` calls | Can't auto-map which sprite goes to which UI element |
| **Addressables catalog** | `catalog.bin` is binary, not parsed — contains the key-to-asset mapping | Need a catalog parser (like UnityPy) to read it |
| **No GUID files** | Zero `.meta` files exist — Unity doesn't ship them in APKs | GUID-to-sprite resolution requires reading binary bundle files |
| **String literals don't contain sprite names** | `stringliteral.json` has NO "ic_gold" strings — Addressables uses serialized AssetReference GUIDs, not string keys | Can't search for sprite names in the string table |

---

## Why the Mapping Still Can't Be Fully Automated

### The il2cpp Limitation

The game uses Unity's **IL2CPP** backend (not Mono). This means:
- C# code is compiled to **native ARM assembly** (in `libil2cpp.so`, 100MB)
- `dump.cs` only contains **class structure** (fields, method signatures) — NOT method bodies
- Every method shows as `{ }` — we know a method exists but can't see what it does

```csharp
// What we see in dump.cs:
public class BuildingDetailWindowController : DetailWindowController
{
    protected virtual void UpdateUpgradeTabData(OwnVillage village) { }  // <-- EMPTY
    public static BuildingDetailWindowController Show(Building building) { }  // <-- EMPTY
}

// What we CAN'T see (the actual implementation):
protected virtual void UpdateUpgradeTabData(OwnVillage village)
{
    // This is where sprites would be assigned:
    tabButtons[0].icon.sprite = Addressables.LoadAssetAsync<Sprite>("ic_gold_upgradeBuilding").Result;
    // ^^^ This code EXISTS in libil2cpp.so as ARM assembly, NOT in dump.cs
}
```

### The Addressables Problem

The game uses **Unity Addressables** (not `Resources.Load`). This means:
- Sprites are referenced by **serialized AssetReference GUIDs**, not string keys
- The GUIDs are stored in the binary `.bundle` files and `catalog.bin`
- The string `"ic_gold_upgradeBuilding"` does NOT appear in `stringliteral.json` because the code uses `AssetReference` objects (GUID-based), not string lookups

Evidence:
```
Search for "ic_gold" in stringliteral.json → 0 results
Search for "upgradeBuilding" in stringliteral.json → 0 results
```

### The catalog.bin Problem

The Addressables catalog (`raw/UnityDataAssetPack/assets/aa/catalog.bin`) contains:
- The mapping from addressable keys → bundle names → asset GUIDs → sprite names
- But it's a **binary format** that requires a parser to read

Tools that can parse it:
- **UnityPy** (Python) — can read `catalog.bin` and resolve addressable mappings
- **AddressablesPlayMode** (Unity Editor) — can read it natively
- **Custom parser** — the format is documented in Unity's open-source code

---

## What Version 5 Gives Us (The Good News)

### 1. ALL 9,089 Sprites Extracted

Every sprite in the game is available as a PNG in `unity_assets/`:
- 93 `ic_gold_*.png` files (golden icons including nav icons)
- 122 `ic_flat_*.png` files (flat-style icons)
- 409 `ic_illu_*.png` files (illustration icons)
- Building icons, troop icons, UI frames, backgrounds, etc.

**This means we can find ANY sprite by name.** No more missing assets.

### 2. Full Class Structure in dump.cs (40MB)

We can see every class, field, and method signature:
```
TLMobile.Scripts.UIComponents.Windows.Barracks
├── InjectableUnitResearchRequirement
├── InjectableUnitsIntoTabHelperClass
├── TroopsTrainingListController : DetailWindowController
├── UnitResearchRequirement : ObservableModel
├── UnitsTrainingTabController (Namespace: ...Barracks)
└── etc.
```

### 3. Full Prefab Hierarchies in normalized_ui/

JSON files show the complete GameObject tree for every UI prefab:
- `5fc7c5b24700bbb488687e55ea4226f6.json` = BarracksWindowController prefab
- Shows TabButton1-6, CloseButton, PanelSelectionButtons, etc.
- Layout data (positions, sizes, anchors, colors)

### 4. Sprite Atlas Mapping

Found in `5c15b339862261647a6eda2b8efc6fb0.json`:
```json
{"name": "IconsGold", "m_PackedSprites": [
  "ic_gold_trap", "ic_gold_map_target", "ic_gold_celebrations",
  "ic_gold_upgradeBuilding", "ic_gold_information",
  "ic_gold_troopsTraining", "ic_gold_exit", ...
]}
```

This confirms which sprites exist and their atlas grouping.

### 5. Individual Sprite Definitions

Each sprite has its own JSON dump showing metadata:
```json
// d73e3ed3da8604a59a1ba732d0884466.json
{"name": "ic_gold_upgradeBuilding", "rect": {"width": 256, "height": 256}, "type": "Sprite"}
```

---

## How to Get the Remaining Mapping (The Last 10%)

### Option A: Parse catalog.bin with UnityPy (Recommended)

```python
import UnityPy

# Parse the Addressables catalog
env = UnityPy.load(r"C:\...\Assets Version 5\raw\UnityDataAssetPack\assets\aa")

# The catalog maps addressable keys to asset GUIDs
# Once parsed, we can see: "ic_gold_upgradeBuilding" → bundle X → path_id Y → sprite
```

This would give us the **addressable key → sprite** mapping, which combined with the prefab hierarchy, would complete the pipeline.

### Option B: Cross-reference path_ids between dumps

The `ui_dump/` JSONs reference sprites by `path_id`. If we cross-reference:
1. Prefab JSON (TabButton1.Icon has path_id reference)
2. Sprite JSON (path_id → sprite name)

We can build the mapping. This works for sprites that are IN THE SAME BUNDLE as the prefab, but NOT for cross-bundle references (which is what Addressables handles).

### Option C: Use the sprite naming convention

Since all 9,089 sprites have descriptive names (`ic_gold_upgradeBuilding`, `bg_unit_frame`, etc.), we can match by convention:
- Tab buttons → `ic_gold_*` prefix
- Backgrounds → `bg_*` prefix
- Icons → `ic_flat_*` or `ic_illu_*` prefix

Combined with the screenshots, this gives us high-confidence mappings.

---

## Summary

| What we need | Version 5 has it? | Path |
|---|---|---|
| All sprite PNGs | **YES** (9,089 files) | `unity_assets/*.png` |
| Class/field structure | **YES** (40MB) | `il2cpp_dump/dump.cs` |
| Method bodies (sprite assignment code) | **NO** (empty stubs) | Need native ARM disassembly of `libil2cpp.so` |
| String literals | **YES** (but no sprite names) | `il2cpp_dump/stringliteral.json` |
| Prefab hierarchies | **YES** (4,695 JSONs) | `normalized_ui/*.json` |
| Sprite atlas lists | **YES** | `ui_dump/5c15b339862261647a6eda2b8efc6fb0.json` |
| Addressables catalog | **BINARY** (needs parser) | `raw/.../aa/catalog.bin` |
| GUID-to-sprite mapping | **NO** (no .meta files) | Would need UnityPy to extract from bundles |

### Bottom Line

**Version 5 gives us ALL the sprites** (the biggest win), but the **automated mapping** (which sprite goes where) still requires one more step: parsing `catalog.bin` with UnityPy, or cross-referencing `path_id`s between the prefab dumps and sprite dumps.

For practical purposes, we can now:
1. Find ANY sprite by name in `unity_assets/`
2. Cross-reference with the prefab hierarchy in `normalized_ui/`
3. Match by naming convention + screenshots
4. This is sufficient for building accurate UI — we just need to look up sprite names manually