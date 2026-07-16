#!/usr/bin/env node
/**
 * parse-unity-bundle.mjs
 * Reads the per-bundle JSON dumps produced by extract_ui_full.py,
 * resolves PPtrs within each bundle, and builds a normalized UI element tree
 * ready for the React/Tailwind code-generation agent.
 *
 * Usage:
 *   node scripts/parse-unity-bundle.mjs <ui_dump_folder> [output_folder]
 *
 * Example:
 *   node scripts/parse-unity-bundle.mjs ui_dump/assetpack normalized_ui
 */

import fs from "fs";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));

const [, , srcDir = "ui_dump", outDir = "normalized_ui"] = process.argv;

if (!fs.existsSync(srcDir)) {
  console.error(`ERROR: Source folder not found: ${srcDir}`);
  process.exit(1);
}

fs.mkdirSync(outDir, { recursive: true });

// ── Helpers ──────────────────────────────────────────────────────────────────

/** Build a path_id → object map for one bundle's objects array */
function buildIndex(objects) {
  const idx = new Map();
  for (const obj of objects) {
    if (obj.path_id != null) idx.set(obj.path_id, obj);
  }
  return idx;
}

/** Resolve a PPtr {path_id, name} to the full object in the index */
function resolve(pptr, idx) {
  if (!pptr || pptr.path_id == null) return null;
  return idx.get(pptr.path_id) ?? null;
}

/** Convert Unity RGBA floats (0-1) → CSS rgba() string */
function toCSS(c) {
  if (!c) return null;
  const r = Math.round((c.r ?? 1) * 255);
  const g = Math.round((c.g ?? 1) * 255);
  const b = Math.round((c.b ?? 1) * 255);
  const a = (c.a ?? 1).toFixed(3);
  return `rgba(${r},${g},${b},${a})`;
}

/** Convert Unity AnchorMin/Max + SizeDelta + AnchoredPosition → CSS layout hint */
function rectToCss(rt) {
  if (!rt) return {};
  return {
    anchorMin: rt.m_AnchorMin ?? null,
    anchorMax: rt.m_AnchorMax ?? null,
    anchoredPosition: rt.m_AnchoredPosition ?? null,
    sizeDelta: rt.m_SizeDelta ?? null,
    pivot: rt.m_Pivot ?? null,
    offsetMin: rt.m_OffsetMin ?? null,
    offsetMax: rt.m_OffsetMax ?? null,
    localScale: rt.m_LocalScale ?? null,
    localRotation: rt.m_LocalRotation ?? null,
  };
}

/** Find the RectTransform attached to a GameObject */
function getRectTransform(go, idx) {
  for (const comp of go.components ?? []) {
    // New format: component carries type directly
    if (comp.type === "RectTransform") {
      const resolved = resolve(comp, idx);
      if (resolved) return resolved;
    }
    // Legacy format: resolve and check
    const resolved = resolve(comp, idx);
    if (resolved?.type === "RectTransform") return resolved;
  }
  return null;
}

/** Find a component by type attached to a GameObject */
function getComponent(go, typeName, idx) {
  for (const comp of go.components ?? []) {
    // New format: component entry carries _class_name directly from MonoScript
    if (comp._class_name === typeName || comp.type === typeName) {
      // Try to resolve the full object from the index for detailed fields
      const resolved = resolve(comp, idx);
      if (resolved) return resolved;
      // If no full object in index, return the component entry itself
      return comp;
    }
    // Legacy format: resolve and check
    const resolved = resolve(comp, idx);
    if (resolved) {
      if (resolved.type === typeName || resolved._class_name === typeName) {
        return resolved;
      }
    }
  }
  return null;
}

/** Find a component where _class_name contains any of the given substrings */
function getComponentFuzzy(go, substrings, idx) {
  const subs = Array.isArray(substrings) ? substrings : [substrings];
  for (const comp of go.components ?? []) {
    const cn = comp._class_name ?? "";
    if (cn && subs.some(s => cn.includes(s))) {
      const resolved = resolve(comp, idx);
      return resolved ?? comp;
    }
    const resolved = resolve(comp, idx);
    if (resolved) {
      const rcn = resolved._class_name ?? "";
      if (rcn && subs.some(s => rcn.includes(s))) {
        return resolved;
      }
    }
  }
  return null;
}

// ── Normalize one GameObject into a UI element node ──────────────────────────
function normalizeNode(go, idx, spriteMap, depth = 0) {
  if (!go || depth > 64) return null; // guard against cycles

  const rt = getRectTransform(go, idx);
  const image = getComponent(go, "Image", idx);
  const rawImage = getComponent(go, "RawImage", idx);
  // Standard TMP or common subclasses (RTLTextMeshPro, etc.)
  const tmp = getComponent(go, "TextMeshProUGUI", idx)
    ?? getComponent(go, "TMP_Text", idx)
    ?? getComponentFuzzy(go, ["RTLTextMeshPro", "TextMeshPro"], idx);
  const legacyText = getComponent(go, "Text", idx);
  const button = getComponent(go, "Button", idx)
    ?? getComponentFuzzy(go, ["ToggledButton"], idx);
  const toggle = getComponent(go, "Toggle", idx)
    ?? getComponentFuzzy(go, ["SwitchButton"], idx);
  const slider = getComponent(go, "Slider", idx);
  const scrollRect = getComponent(go, "ScrollRect", idx);
  const inputField = getComponent(go, "InputField", idx)
    ?? getComponent(go, "TMP_InputField", idx);
  const canvasGroup = getComponent(go, "CanvasGroup", idx);
  const canvas = getComponent(go, "Canvas", idx);
  const canvasScaler = getComponent(go, "CanvasScaler", idx);
  const hLayout = getComponent(go, "HorizontalLayoutGroup", idx)
    ?? getComponentFuzzy(go, ["RTLHorizontalLayoutGroup"], idx);
  const vLayout = getComponent(go, "VerticalLayoutGroup", idx)
    ?? getComponentFuzzy(go, ["RTLVerticalLayoutGroup"], idx);
  const gridLayout = getComponent(go, "GridLayoutGroup", idx);
  const layoutEl = getComponent(go, "LayoutElement", idx);
  const sizeFitter = getComponent(go, "ContentSizeFitter", idx);
  const aspectFitter = getComponent(go, "AspectRatioFitter", idx);
  const mask = getComponent(go, "Mask", idx)
    ?? getComponent(go, "RectMask2D", idx);

  const node = {
    path_id: go.path_id,
    name: go.name,
    is_active: go.is_active ?? true,
    layer: go.layer,
    layout: rt ? rectToCss(rt) : null,
  };

  // ── Visual ──
  if (image) {
    const spriteName = image.m_Sprite?.name
      ?? spriteMap[image.m_Sprite?.path_id]
      ?? null;
    node.image = {
      sprite: spriteName,
      sprite_path_id: image.m_Sprite?.path_id ?? null,
      type: image.m_Type,   // 0=Simple,1=Sliced,2=Tiled,3=Filled
      color: toCSS(image.m_Color),
      preserveAspect: image.m_PreserveAspect,
      fillMethod: image.m_FillMethod,
      fillAmount: image.m_FillAmount,
      raycastTarget: image.m_RaycastTarget,
    };
  }

  if (rawImage) {
    node.rawImage = {
      texture_path_id: rawImage.m_Texture?.path_id ?? null,
      texture_name: rawImage.m_Texture?.name ?? null,
      color: toCSS(rawImage.m_Color),
      uvRect: rawImage.m_UVRect,
    };
  }

  // ── Text ──
  if (tmp) {
    node.text = {
      content: tmp.m_text ?? null,
      font: tmp.m_fontAsset?.name ?? null,
      font_path_id: tmp.m_fontAsset?.path_id ?? null,
      fontSize: tmp.m_fontSize,
      fontSizeMin: tmp.m_fontSizeMin,
      fontSizeMax: tmp.m_fontSizeMax,
      autoSize: tmp.m_enableAutoSizing,
      style: tmp.m_fontStyle,      // bitmask: Bold=1, Italic=2, etc.
      alignment: tmp.m_alignment,  // see TMP TextAlignmentOptions enum
      color: toCSS(tmp.m_color),
      margin: tmp.m_margin,
      richText: tmp.m_richText,
      overflow: tmp.m_overflowMode,
      wordWrap: tmp.m_enableWordWrapping,
      engine: "TMP",
    };
  } else if (legacyText) {
    node.text = {
      content: legacyText.m_Text ?? null,
      font: null,
      fontSize: legacyText.m_FontSize,
      style: legacyText.m_FontStyle,
      alignment: legacyText.m_Alignment,
      color: toCSS(legacyText.m_Color),
      engine: "Legacy",
    };
  }

  // ── Interaction ──
  if (button) {
    node.button = {
      interactable: button.m_Interactable,
      transition: button.m_Transition,
      colors: button.m_Colors ?? null,
      onClick: button.m_OnClick ?? null,
    };
  }
  if (toggle) node.toggle = { isOn: toggle.m_IsOn, interactable: toggle.m_Interactable };
  if (slider) node.slider = { value: slider.m_Value, min: slider.m_MinValue, max: slider.m_MaxValue, direction: slider.m_Direction };
  if (scrollRect) node.scrollRect = { horizontal: scrollRect.m_Horizontal, vertical: scrollRect.m_Vertical, movementType: scrollRect.m_MovementType };
  if (inputField) node.inputField = { text: inputField.m_Text, contentType: inputField.m_ContentType, charLimit: inputField.m_CharacterLimit };

  // ── Layout ──
  const layoutGroup = hLayout ?? vLayout ?? gridLayout;
  if (layoutGroup) {
    node.layoutGroup = {
      type: layoutGroup.type,
      padding: layoutGroup.m_Padding,
      spacing: layoutGroup.m_Spacing,
      childAlignment: layoutGroup.m_ChildAlignment,
      cellSize: layoutGroup.m_CellSize ?? null,
      gridSpacing: layoutGroup.m_Spacing ?? null,
    };
  }
  if (layoutEl) node.layoutElement = { minWidth: layoutEl.m_MinWidth, minHeight: layoutEl.m_MinHeight, preferredWidth: layoutEl.m_PreferredWidth, preferredHeight: layoutEl.m_PreferredHeight };
  if (sizeFitter) node.contentSizeFitter = { horizontal: sizeFitter.m_HorizontalFit, vertical: sizeFitter.m_VerticalFit };
  if (aspectFitter) node.aspectRatioFitter = { mode: aspectFitter.m_AspectMode, ratio: aspectFitter.m_AspectRatio };
  if (mask) node.mask = { show: mask.m_ShowMaskGraphic, padding: mask.m_Padding, softness: mask.m_Softness };

  // ── Canvas ──
  if (canvas) {
    node.canvas = { renderMode: canvas.m_RenderMode, sortingOrder: canvas.m_SortingOrder };
    if (canvasScaler) {
      node.canvasScaler = {
        scaleMode: canvasScaler.m_UiScaleMode,
        referenceResolution: canvasScaler.m_ReferenceResolution,
        matchWidthOrHeight: canvasScaler.m_MatchWidthOrHeight,
      };
    }
  }

  if (canvasGroup) node.canvasGroup = { alpha: canvasGroup.m_Alpha, blocksRaycasts: canvasGroup.m_BlocksRaycasts, interactable: canvasGroup.m_Interactable };

  // ── Children (recursive) ──
  if (rt?.m_Children?.length) {
    node.children = rt.m_Children
      .map((childPPtr) => {
        const childRt = resolve(childPPtr, idx);
        if (!childRt) return null;
        // The RectTransform's father/children chain: need to find the GO that owns this RT
        // We do this by finding a GO whose components include this RT's path_id
        const childGo = findGoForRt(childPPtr.path_id, idx);
        return childGo ? normalizeNode(childGo, idx, spriteMap, depth + 1) : null;
      })
      .filter(Boolean);
  }

  return node;
}

/** Find the GameObject that owns a given RectTransform path_id */
function findGoForRt(rtPathId, idx) {
  for (const [, obj] of idx) {
    if (obj.type !== "GameObject") continue;
    for (const comp of obj.components ?? []) {
      if (comp?.path_id === rtPathId) return obj;
    }
  }
  return null;
}

/** Find root GameObjects (those whose RectTransform has no father, or father path_id = 0) */
function findRoots(objects, idx) {
  return objects.filter((obj) => {
    if (obj.type !== "GameObject") return false;
    const rt = getRectTransform(obj, idx);
    if (!rt) return false;
    return !rt.m_Father || rt.m_Father.path_id === 0 || rt.m_Father.path_id == null;
  });
}

// ── Process one bundle file ───────────────────────────────────────────────────
function processBundle(jsonPath, spriteMap, outFolder) {
  let bundle;
  try {
    bundle = JSON.parse(fs.readFileSync(jsonPath, "utf-8"));
  } catch (e) {
    console.warn(`  SKIP (parse error): ${jsonPath}`);
    return;
  }

  const objects = bundle.objects ?? [];
  if (!objects.length) return;

  const idx = buildIndex(objects);
  const roots = findRoots(objects, idx);

  if (!roots.length) {
    // No UI roots found — still emit a raw index for the agent
    const outFile = path.join(outFolder, path.basename(jsonPath));
    fs.writeFileSync(outFile, JSON.stringify({ source: bundle.source, roots: [], raw_count: objects.length }, null, 2));
    return;
  }

  const trees = roots.map((go) => normalizeNode(go, idx, spriteMap));
  const out = {
    source: bundle.source,
    bundle_file: jsonPath,
    root_count: roots.length,
    roots: trees,
  };

  const outFile = path.join(outFolder, path.basename(jsonPath));
  fs.writeFileSync(outFile, JSON.stringify(out, null, 2), "utf-8");
}

// ── Main ─────────────────────────────────────────────────────────────────────
const spriteMapPath = path.join(srcDir, "sprite_name_map.json");
let spriteMap = {};
if (fs.existsSync(spriteMapPath)) {
  try {
    const raw = JSON.parse(fs.readFileSync(spriteMapPath, "utf-8"));
    // Flatten: {bundlePath: {path_id: name}} → {path_id: name}  (may collide across bundles, but useful for quick lookup)
    for (const bundleMap of Object.values(raw)) {
      Object.assign(spriteMap, bundleMap);
    }
    console.log(`Loaded sprite name map: ${Object.keys(spriteMap).length} entries`);
  } catch (e) {
    console.warn("Could not load sprite_name_map.json:", e.message);
  }
}

const jsonFiles = fs.readdirSync(srcDir).filter((f) => f.endsWith(".json") && f !== "sprite_name_map.json");
console.log(`Processing ${jsonFiles.length} bundle dumps from ${srcDir}`);

let done = 0;
for (const f of jsonFiles) {
  processBundle(path.join(srcDir, f), spriteMap, outDir);
  done++;
  if (done % 100 === 0) console.log(`  ${done}/${jsonFiles.length}...`);
}

console.log(`\nDone! Normalized trees written to: ${outDir}`);
console.log(`Next step: feed the JSON files from ${outDir}/ to your AI agent for React/Tailwind generation.`);
