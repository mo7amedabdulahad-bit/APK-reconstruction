"""Extract complete Unity UI hierarchy from asset bundles.

Walks every GameObject in every bundle, recursively reads m_Component
lists, and outputs one self-contained JSON "screen spec" file per Canvas
root.  The JSON follows the screen-spec schema designed for AI coding agents.
"""
from __future__ import annotations

from io import BytesIO
from pathlib import Path
from typing import Callable, Optional

from .anchor_resolver import resolve_anchor
from .asset_linker import AssetLinker
from .component_reader import (
    ComponentReader,
    _safe_bool,
    _safe_float,
    _safe_int,
    _safe_str,
)
from .screen_writer import ScreenWriter


class UIHierarchyExtractor:
    """Extract UI screen hierarchies from Unity asset bundles.

    For every Canvas found in a bundle, builds a flat element list and
    writes one ``<screen_name>.json`` file to ``output_dir/UI_Screens/``.
    """

    def __init__(
        self,
        output_dir: Path,
        extracted_assets_dir: Optional[Path] = None,
        log_callback: Optional[Callable[[str], None]] = None,
    ) -> None:
        self._output_dir = Path(output_dir)
        self._extracted_assets_dir = (
            Path(extracted_assets_dir) if extracted_assets_dir else self._output_dir
        )
        self._log = log_callback or (lambda m: print(m))
        self._reader = ComponentReader()
        self._writer = ScreenWriter(self._output_dir)
        self._linker = AssetLinker(self._extracted_assets_dir)
        self._linker.build_index()

    # ── public API ───────────────────────────────────────────────────────

    def extract_from_all_bundles(self, apk_path: Path) -> int:
        """Walk every ``.bundle`` inside *apk_path* (APK or XAPK)."""
        import zipfile

        total = 0
        apk_path = Path(apk_path)
        with zipfile.ZipFile(str(apk_path), "r") as z:
            inner_apks = [n for n in z.namelist() if n.endswith(".apk")]
            if not inner_apks:
                return 0
            main_apk = max(inner_apks, key=lambda n: z.getinfo(n).file_size)
            apk_data = z.read(main_apk)

        import tempfile

        tp = Path(tempfile.gettempdir()) / "ui_extract_all.apk"
        tp.write_bytes(apk_data)
        del apk_data

        with zipfile.ZipFile(str(tp), "r") as z:
            bundle_files = [n for n in z.namelist() if n.endswith(".bundle")]
            for bi, bname in enumerate(bundle_files):
                try:
                    bdata = z.read(bname)
                    n = self.extract_from_bundle(bdata, bname)
                    total += n
                    if n > 0:
                        self._log(
                            f"  [{bi+1}/{len(bundle_files)}] "
                            f"{Path(bname).name} -> {n} screen(s)"
                        )
                    del bdata
                except Exception as exc:
                    self._log(f"  [{bi+1}/{len(bundle_files)}] ERROR: {exc}")

        try:
            tp.unlink()
        except Exception:
            pass

        return total

    def extract_from_bundle(self, bundle_data: bytes, bundle_name: str) -> int:
        """Load a bundle and extract all Canvas root hierarchies.

        Returns the number of Canvas roots processed.
        """
        try:
            import UnityPy
        except ImportError:
            self._log("  UnityPy not installed, skipping UI hierarchy extraction.")
            return 0

        try:
            env = UnityPy.load(BytesIO(bundle_data))
        except Exception as exc:
            self._log(f"  Could not load bundle for UI extraction: {exc}")
            return 0

        canvas_roots = self._find_canvas_roots(env)
        if not canvas_roots:
            return 0

        for go_data, canvas_comp in canvas_roots:
            screen_name = _safe_str(
                getattr(go_data, "m_Name", None), f"Canvas_{id(go_data)}"
            )
            screen_spec = self._build_screen_spec(
                screen_name, go_data, canvas_comp, bundle_name, env
            )
            try:
                out_path = self._writer.write(screen_spec, bundle_name)
                self._log(f"    Wrote {out_path.name}")
            except Exception as exc:
                self._log(f"  Error writing screen {screen_name}: {exc}")

        return len(canvas_roots)

    # ── Canvas discovery ────────────────────────────────────────────────

    def _find_canvas_roots(self, env) -> list:
        """Return list of ``(go_data, canvas_data)`` for every Canvas."""
        go_by_path_id: dict[int, object] = {}
        for obj in env.objects:
            if obj.type.name == "GameObject":
                try:
                    go_by_path_id[obj.path_id] = obj.read()
                except Exception:
                    pass

        canvas_by_go: dict[int, object] = {}
        for obj in env.objects:
            if obj.type.name == "Canvas":
                try:
                    data = obj.read()
                    go_ref = getattr(data, "m_GameObject", None)
                    if go_ref is not None:
                        go_id = getattr(go_ref, "path_id", None)
                        if go_id:
                            canvas_by_go[go_id] = data
                except Exception:
                    pass

        results = []
        for go_id, canvas_data in canvas_by_go.items():
            if go_id in go_by_path_id:
                results.append((go_by_path_id[go_id], canvas_data))
        return results

    # ── Screen spec builder ─────────────────────────────────────────────

    def _build_screen_spec(
        self,
        screen_name: str,
        go_data,
        canvas_comp,
        bundle_name: str,
        env,
    ) -> dict:
        """Build the complete screen-spec dict for one Canvas."""
        canvas_data = self._reader.read_canvas(canvas_comp)
        canvas_size = self._determine_canvas_size(canvas_comp, go_data)
        bg_color = self._read_canvas_background(go_data)

        elements: list[dict] = []
        counter = [0]

        self._walk_tree(
            go_data, env, elements, counter, parent_id=None, layer_order=0
        )

        manifest = self._collect_asset_manifest(elements)

        return {
            "screen_name": screen_name,
            "source_bundle": bundle_name,
            "canvas_size": canvas_size,
            "background_color": bg_color,
            "elements": elements,
            "asset_manifest": manifest,
        }

    def _determine_canvas_size(self, canvas_comp, go_data) -> dict:
        """Try to infer canvas pixel dimensions."""
        scaler_ref = getattr(canvas_comp, "m_UiScaleMode", None)
        ref_res = getattr(canvas_comp, "m_ReferenceResolution", None)
        if ref_res is not None:
            w = _safe_float(getattr(ref_res, "x", None), 1920)
            h = _safe_float(getattr(ref_res, "y", None), 1080)
            return {"width": w, "height": h}

        rt = self._get_rect_transform(go_data)
        if rt is not None:
            sd = getattr(rt, "m_SizeDelta", None)
            if sd is not None:
                return {
                    "width": _safe_float(getattr(sd, "x", None), 1920),
                    "height": _safe_float(getattr(sd, "y", None), 1080),
                }

        return {"width": 1920, "height": 1080}

    def _read_canvas_background(self, go_data) -> dict:
        """Read a background colour from the Canvas GameObject if available."""
        canvas_group = self._find_component(go_data, "CanvasGroup")
        if canvas_group is not None:
            alpha = _safe_float(getattr(canvas_group, "m_Alpha", None), 1.0)
            if alpha < 1.0:
                return {"r": 0.0, "g": 0.0, "b": 0.0, "a": alpha}

        image = self._find_mono_by_script(go_data, "Image")
        if image is not None:
            c = getattr(image, "m_Color", None)
            if c is not None:
                return {
                    "r": _safe_float(getattr(c, "r", None), 0.0),
                    "g": _safe_float(getattr(c, "g", None), 0.0),
                    "b": _safe_float(getattr(c, "b", None), 0.0),
                    "a": _safe_float(getattr(c, "a", None), 1.0),
                }

        return {"r": 0.0, "g": 0.0, "b": 0.0, "a": 1.0}

    # ── Tree walking ────────────────────────────────────────────────────

    def _walk_tree(
        self,
        go_data,
        env,
        elements: list[dict],
        counter: list[int],
        parent_id: Optional[str],
        layer_order: int,
    ) -> None:
        """Recursively walk a GameObject and its children, appending elements."""
        node_id = f"el_{counter[0]:03d}"
        counter[0] += 1

        name = _safe_str(getattr(go_data, "m_Name", ""), "")
        active = _safe_bool(getattr(go_data, "m_IsActive", True), True)

        rt = self._get_rect_transform(go_data)
        if rt is not None:
            rt_dict = self._reader.read_rect_transform(rt)
        else:
            rt_dict = {}

        position = rt_dict.get("anchored_position", {"x": 0.0, "y": 0.0})
        size = rt_dict.get("size_delta", {"width": 0.0, "height": 0.0})
        anchor_min = rt_dict.get("anchor_min", {"x": 0.0, "y": 0.0})
        anchor_max = rt_dict.get("anchor_max", {"x": 0.0, "y": 0.0})
        pivot = rt_dict.get("pivot", {"x": 0.5, "y": 0.5})
        local_rot = rt_dict.get("local_rotation", {"x": 0.0, "y": 0.0, "z": 0.0, "w": 1.0})
        local_scale = rt_dict.get("local_scale", {"x": 1.0, "y": 1.0, "z": 1.0})

        anchor_label = resolve_anchor(anchor_min, anchor_max)

        comp_type, comp_data = self._read_primary_component(go_data)

        element: dict = {
            "id": node_id,
            "name": name,
            "type": comp_type,
            "layer_order": layer_order,
            "active": active,
            "position": {"x": position.get("x", 0.0), "y": position.get("y", 0.0)},
            "size": {
                "width": size.get("x", 0.0) if "x" in size else size.get("width", 0.0),
                "height": size.get("y", 0.0) if "y" in size else size.get("height", 0.0),
            },
            "anchor": anchor_label,
            "pivot": pivot,
            "rotation": _safe_float(
                local_rot.get("z", 0.0) if isinstance(local_rot, dict) else 0.0, 0.0
            ),
            "scale": {
                "x": _safe_float(local_scale.get("x", 1.0) if isinstance(local_scale, dict) else 1.0, 1.0),
                "y": _safe_float(local_scale.get("y", 1.0) if isinstance(local_scale, dict) else 1.0, 1.0),
            },
            "parent_id": parent_id,
            "children": [],
        }

        if comp_data:
            element.update(comp_data)

        elements.append(element)

        # Discover child GameObjects
        child_ids = self._get_child_ids(go_data)
        go_by_path_id = self._index_game_objects(env)

        child_element_ids: list[str] = []
        for order_offset, child_path_id in enumerate(child_ids):
            child_go = go_by_path_id.get(child_path_id)
            if child_go is None:
                continue
            child_el_id = f"el_{counter[0]:03d}"
            child_element_ids.append(child_el_id)
            self._walk_tree(
                child_go,
                env,
                elements,
                counter,
                parent_id=node_id,
                layer_order=layer_order + 1 + order_offset,
            )

        element["children"] = child_element_ids

    # ── Component helpers ────────────────────────────────────────────────

    def _read_primary_component(self, go_data) -> tuple[str, Optional[dict]]:
        """Return the most meaningful UI component type and its dict."""
        comp_refs = getattr(go_data, "m_Component", None)
        if comp_refs is None:
            return "Empty", None

        for comp_ref in comp_refs:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
            except Exception:
                continue

            type_name = comp_obj.type.name

            if type_name == "RectTransform":
                continue  # handled separately via _get_rect_transform

            if type_name == "MonoBehaviour":
                script_name = self._get_script_name(comp_obj)
                if script_name == "Image":
                    return "Image", self._reader.read_image(comp_obj)
                elif script_name == "Text":
                    return "Text", self._reader.read_text(comp_obj)
                elif script_name == "Button":
                    return "Button", self._reader.read_button(comp_obj)
                elif script_name == "RawImage":
                    return "RawImage", self._reader.read_raw_image(comp_obj)
                elif script_name == "Outline":
                    return "Outline", self._reader.read_outline(comp_obj)
                elif script_name == "Shadow":
                    return "Shadow", self._reader.read_shadow(comp_obj)
                elif script_name == "Toggle":
                    return "Toggle", self._reader.read_toggle(comp_obj)
                elif script_name == "Slider":
                    return "Slider", self._reader.read_slider(comp_obj)
                elif script_name == "InputField":
                    return "InputField", self._reader.read_input_field(comp_obj)
                elif script_name == "ScrollRect":
                    return "ScrollRect", self._reader.read_scroll_rect(comp_obj)
                elif script_name == "Dropdown":
                    return "Dropdown", self._reader.read_dropdown(comp_obj)
                else:
                    return "MonoBehaviour", self._reader.read_raw_mono(comp_obj)

            if type_name == "CanvasGroup":
                return "CanvasGroup", self._reader.read_canvas_group(comp_obj)

        return "Empty", None

    def _get_script_name(self, comp_obj) -> str:
        script_ref = getattr(comp_obj, "m_Script", None)
        if script_ref is None:
            return "Unknown"
        try:
            script_obj = script_ref.read()
            return _safe_str(getattr(script_obj, "m_Name", None), "Unknown")
        except Exception:
            return "Unknown"

    def _get_rect_transform(self, go_data):
        comp_refs = getattr(go_data, "m_Component", None)
        if comp_refs is None:
            return None
        for comp_ref in comp_refs:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
                if comp_obj.type.name == "RectTransform":
                    return comp_obj
            except Exception:
                pass
        return None

    def _find_component(self, go_data, type_name: str):
        comp_refs = getattr(go_data, "m_Component", None)
        if comp_refs is None:
            return None
        for comp_ref in comp_refs:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
                if comp_obj.type.name == type_name:
                    return comp_obj
            except Exception:
                pass
        return None

    def _find_mono_by_script(self, go_data, script_name: str):
        comp_refs = getattr(go_data, "m_Component", None)
        if comp_refs is None:
            return None
        for comp_ref in comp_refs:
            comp_id = getattr(comp_ref, "component", None)
            if comp_id is None:
                continue
            try:
                comp_obj = comp_id.read()
                if comp_obj.type.name != "MonoBehaviour":
                    continue
                if self._get_script_name(comp_obj) == script_name:
                    return comp_obj
            except Exception:
                pass
        return None

    # ── Child / object index helpers ────────────────────────────────────

    def _get_child_ids(self, go_data) -> list[int]:
        """Get the path_ids of child GameObjects via RectTransform.m_Children."""
        rt = self._get_rect_transform(go_data)
        if rt is None:
            return []
        children_refs = getattr(rt, "m_Children", None)
        if children_refs is None:
            return []
        ids = []
        for child_ref in children_refs:
            cid = getattr(child_ref, "path_id", None)
            if cid:
                ids.append(cid)
        return ids

    def _index_game_objects(self, env) -> dict[int, object]:
        idx: dict[int, object] = {}
        for obj in env.objects:
            if obj.type.name == "GameObject":
                try:
                    idx[obj.path_id] = obj.read()
                except Exception:
                    pass
        return idx

    # ── Asset manifest ──────────────────────────────────────────────────

    def _collect_asset_manifest(self, elements: list[dict]) -> dict:
        sprites_used: list[str] = []
        fonts_used: list[str] = []
        texts_found: list[str] = []
        colors_used: set[str] = set()

        for el in elements:
            el_type = el.get("type", "")

            # Sprites
            sprite = el.get("sprite_file", "") or el.get("sprite_name", "")
            if sprite:
                linked = self._linker.find_sprite(sprite)
                if linked and not linked.startswith("MISSING:"):
                    if linked not in sprites_used:
                        sprites_used.append(linked)

            # Fonts
            font = el.get("font_file", "") or el.get("font_name", "")
            if font:
                linked = self._linker.find_font(font)
                if linked and not linked.startswith("MISSING:"):
                    if linked not in fonts_used:
                        fonts_used.append(linked)

            # Texts
            if el_type == "Text":
                txt = el.get("text", "")
                if txt and txt not in texts_found:
                    texts_found.append(txt)

            # Button labels
            if el_type == "Button":
                label = el.get("label", "")
                if label and label not in texts_found:
                    texts_found.append(label)

            # Colours -> hex
            for color_key in ("color", "normal_color", "highlighted_color",
                              "pressed_color", "outline_color"):
                c = el.get(color_key)
                if c and isinstance(c, dict):
                    r = int(c.get("r", 0) * 255)
                    g = int(c.get("g", 0) * 255)
                    b = int(c.get("b", 0) * 255)
                    colors_used.add(f"#{r:02X}{g:02X}{b:02X}")

        return {
            "sprites_used": sprites_used,
            "fonts_used": fonts_used,
            "texts_found": texts_found,
            "colors_used": sorted(colors_used),
        }
