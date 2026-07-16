"""APK asset extractor - extracts Unity assets from APK/XAPK files using UnityPy."""

from __future__ import annotations

import struct
import zipfile
import hashlib
import tempfile
import os
import json
from io import BytesIO
from pathlib import Path
from typing import Any, Optional

from .models import (
    ExtractedAsset, AssetCategory, SpriteRect, SpriteAtlasData,
    UnityVersion, ReconstructionResult, AssetBundleInfo,
)

try:
    import UnityPy
    HAS_UNITYPY = True
except ImportError:
    HAS_UNITYPY = False


class APKAssetExtractor:
    """Extracts Unity assets from APK/XAPK files using UnityPy."""

    # Types worth extracting
    EXTRACTABLE_TYPES = {
        "Texture2D", "Sprite", "AudioClip", "TextAsset", "Material",
        "Shader", "Font", "SpriteAtlas", "AnimationClip",
        "AnimatorController", "Mesh", "AssetBundle",
    }

    def __init__(self):
        self.extracted: list[ExtractedAsset] = []
        self.errors: list[str] = []
        self.warnings: list[str] = []
        self.unity_version = UnityVersion.UNKNOWN
        self.asset_bundles: list[AssetBundleInfo] = []
        self._seen_hashes: set[str] = set()

    def extract_from_apk(self, apk_path: Path, output_dir: Path) -> ReconstructionResult:
        """Extract all Unity assets from an APK or XAPK file."""
        result = ReconstructionResult(output_path=output_dir)

        if not apk_path.exists():
            result.errors.append(f"APK file not found: {apk_path}")
            return result

        if not HAS_UNITYPY:
            result.errors.append("UnityPy not installed. Run: pip install UnityPy")
            return result

        try:
            with zipfile.ZipFile(apk_path, 'r') as apk:
                entries = apk.namelist()

                # Check if this is an XAPK (contains inner APKs)
                inner_apks = [e for e in entries if e.endswith('.apk')]
                if inner_apks:
                    self._log(f"Detected XAPK with {len(inner_apks)} inner APKs")
                    for inner_apk in inner_apks:
                        self._log(f"  Processing: {inner_apk}")
                        inner_data = apk.read(inner_apk)
                        self._extract_from_data(inner_data, output_dir, inner_apk)
                else:
                    # Regular APK
                    for entry in entries:
                        data = apk.read(entry)
                        self._extract_from_data(data, output_dir, entry)

                # Detect Unity version
                self._detect_unity_version(apk)
        except zipfile.BadZipFile:
            result.errors.append(f"Invalid ZIP/APK file: {apk_path}")
            return result
        except Exception as e:
            result.errors.append(f"Error reading APK: {e}")
            return result

        result.assets = self.extracted
        result.warnings = self.warnings
        result.errors = self.errors
        result.unity_version = self.unity_version
        result.total_assets = len(self.extracted)

        # Count categories
        for asset in self.extracted:
            cat = asset.category.value
            result.categories[cat] = result.categories.get(cat, 0) + 1

        return result

    def _extract_from_data(self, data: bytes, output_dir: Path, source: str) -> None:
        """Extract Unity assets from raw data using UnityPy."""
        try:
            # Write to temp file for UnityPy
            with tempfile.NamedTemporaryFile(suffix='.apk', delete=False) as tmp:
                tmp.write(data)
                tmp_path = tmp.name

            try:
                env = UnityPy.load(tmp_path)

                for obj in env.objects:
                    if obj.type.name not in self.EXTRACTABLE_TYPES:
                        continue

                    try:
                        self._process_unity_object(obj, output_dir, source)
                    except Exception as e:
                        self.errors.append(f"Error processing {obj.type.name}: {e}")
            finally:
                try:
                    os.unlink(tmp_path)
                except:
                    pass
        except Exception as e:
            self.errors.append(f"Error loading with UnityPy: {e}")

    def _process_unity_object(self, obj, output_dir: Path, source: str) -> None:
        """Process a single Unity object and extract it."""
        data = obj.read()
        obj_type = obj.type.name

        # Get name
        obj_name = ""
        for attr in ('m_Name', 'name', 'Name'):
            if hasattr(data, attr):
                obj_name = getattr(data, attr)
                if obj_name:
                    break
        if not obj_name:
            obj_name = f"{obj_type}_{obj.path_id}"

        # Create asset entry
        asset = ExtractedAsset(
            name=str(obj_name),
            path=f"{source}:{obj.path_id}",
            asset_type=obj_type,
        )

        if obj_type == "Texture2D":
            self._extract_texture(data, asset, output_dir)
        elif obj_type == "Sprite":
            self._extract_sprite(data, asset, output_dir)
        elif obj_type == "TextAsset":
            self._extract_text_asset(data, asset, output_dir)
        elif obj_type == "Material":
            self._extract_material(data, asset, output_dir)
        elif obj_type == "Shader":
            self._extract_shader(data, asset, output_dir)
        elif obj_type == "Font":
            self._extract_font(data, asset, output_dir)
        elif obj_type == "AudioClip":
            self._extract_audio(data, asset, output_dir)
        elif obj_type == "SpriteAtlas":
            self._extract_sprite_atlas(data, asset, output_dir)
        elif obj_type == "AnimationClip":
            self._extract_animation(data, asset, output_dir)
        elif obj_type == "AnimatorController":
            self._extract_animator(data, asset, output_dir)
        elif obj_type == "Mesh":
            self._extract_mesh(data, asset, output_dir)
        elif obj_type == "AssetBundle":
            self._extract_asset_bundle(data, asset, output_dir)

    def _extract_texture(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Texture2D as PNG."""
        try:
            img = data.image
            if img is not None:
                buf = BytesIO()
                img.save(buf, format="PNG")
                asset.data = buf.getvalue()
                asset.width = img.width
                asset.height = img.height
                asset.category = AssetCategory.GENERAL
                self._save_asset(asset, output_dir, ".png")
        except Exception as e:
            self.errors.append(f"Texture {asset.name}: {e}")

    def _extract_sprite(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Sprite as PNG."""
        try:
            img = data.image
            if img is not None:
                buf = BytesIO()
                img.save(buf, format="PNG")
                asset.data = buf.getvalue()
                asset.width = img.width
                asset.height = img.height
                asset.category = AssetCategory.GENERAL

                # Store sprite metadata
                if hasattr(data, 'm_Rect'):
                    r = data.m_Rect
                    asset.metadata["rect"] = {"x": r.x, "y": r.y, "w": r.width, "h": r.height}
                if hasattr(data, 'm_Pivot'):
                    p = data.m_Pivot
                    asset.metadata["pivot"] = {"x": p.x, "y": p.y}
                if hasattr(data, 'mPixelsToUnits'):
                    asset.metadata["pixels_per_unit"] = data.mPixelsToUnits

                self._save_asset(asset, output_dir, ".png")
        except Exception as e:
            self.errors.append(f"Sprite {asset.name}: {e}")

    def _extract_text_asset(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract TextAsset."""
        try:
            text = getattr(data, 'm_Script', '') or ''
            if isinstance(text, str):
                asset.data = text.encode('utf-8')
            elif isinstance(text, bytes):
                asset.data = text
            else:
                asset.data = str(text).encode('utf-8')

            # Detect format
            try:
                content = asset.data.decode('utf-8', errors='replace')
                if content.strip().startswith('{') or content.strip().startswith('['):
                    asset.format = "json"
                elif content.strip().startswith('<'):
                    asset.format = "xml"
                else:
                    asset.format = "txt"
            except:
                asset.format = "txt"

            asset.category = AssetCategory.GENERAL
            ext = f".{asset.format}" if asset.format else ".txt"
            self._save_asset(asset, output_dir, ext)
        except Exception as e:
            self.errors.append(f"TextAsset {asset.name}: {e}")

    def _extract_material(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Material as JSON."""
        try:
            mat_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_Shader') and data.m_Shader:
                mat_data["shader"] = str(data.m_Shader)

            if hasattr(data, 'm_SavedProperties'):
                props = data.m_SavedProperties
                if hasattr(props, 'm_Floats'):
                    mat_data["floats"] = {str(k): v for k, v in props.m_Floats.items()}
                if hasattr(props, 'm_Colors'):
                    mat_data["colors"] = {str(k): {"r": v.r, "g": v.g, "b": v.b, "a": v.a}
                                          for k, v in props.m_Colors.items()}
                if hasattr(props, 'm_TexEnvs'):
                    mat_data["textures"] = [str(t) for t in props.m_TexEnvs]

            asset.data = json.dumps(mat_data, indent=2, ensure_ascii=False).encode('utf-8')
            asset.category = AssetCategory.MATERIALS
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"Material {asset.name}: {e}")

    def _extract_shader(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Shader as text."""
        try:
            # Try to get readable text
            if hasattr(data, 'm_ParsedForm'):
                parsed = data.m_ParsedForm
                if hasattr(parsed, 'm_SubPrograms'):
                    asset.data = f"Shader: {asset.name}\nSubPrograms: {len(parsed.m_SubPrograms)}".encode('utf-8')
                else:
                    asset.data = f"Shader: {asset.name}".encode('utf-8')
            else:
                asset.data = f"Shader: {asset.name}".encode('utf-8')

            asset.category = AssetCategory.SHADERS
            self._save_asset(asset, output_dir, ".shader")
        except Exception as e:
            self.errors.append(f"Shader {asset.name}: {e}")

    def _extract_font(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Font as TTF/OTF."""
        try:
            if hasattr(data, 'm_FontData') and data.m_FontData:
                font_data = bytes(data.m_FontData)
                if font_data and len(font_data) > 100:
                    # Check type
                    if font_data[:4] == b'\x00\x01\x00\x00':
                        ext = ".ttf"
                    elif font_data[:4] == b'OTTO':
                        ext = ".otf"
                    else:
                        ext = ".ttf"

                    asset.data = font_data
                    asset.category = AssetCategory.FONTS
                    self._save_asset(asset, output_dir, ext)
        except Exception as e:
            self.errors.append(f"Font {asset.name}: {e}")

    def _extract_audio(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract AudioClip."""
        try:
            if hasattr(data, 'm_AudioData') and data.m_AudioData:
                audio_data = bytes(data.m_AudioData)
                if audio_data and len(audio_data) > 100:
                    asset.data = audio_data
                    asset.category = AssetCategory.AUDIO
                    self._save_asset(asset, output_dir, ".wav")
        except Exception as e:
            self.errors.append(f"Audio {asset.name}: {e}")

    def _extract_sprite_atlas(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract SpriteAtlas as JSON."""
        try:
            atlas_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_RenderDataMap'):
                atlas_data["sprite_count"] = len(data.m_RenderDataMap)
                atlas_data["sprites"] = list(str(k) for k in data.m_RenderDataMap.keys())

            asset.data = json.dumps(atlas_data, indent=2, ensure_ascii=False).encode('utf-8')
            asset.category = AssetCategory.UI
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"SpriteAtlas {asset.name}: {e}")

    def _extract_animation(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract AnimationClip as JSON."""
        try:
            anim_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_AnimationClipSettings'):
                settings = data.m_AnimationClipSettings
                if hasattr(settings, 'm_StartTime'):
                    anim_data["start_time"] = settings.m_StartTime
                if hasattr(settings, 'm_StopTime'):
                    anim_data["stop_time"] = settings.m_StopTime

            asset.data = json.dumps(anim_data, indent=2).encode('utf-8')
            asset.category = AssetCategory.CHARACTERS
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"Animation {asset.name}: {e}")

    def _extract_animator(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract AnimatorController as JSON."""
        try:
            ctrl_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_AnimationClips'):
                clips = data.m_AnimationClips
                if clips:
                    ctrl_data["clip_count"] = len(clips)

            asset.data = json.dumps(ctrl_data, indent=2).encode('utf-8')
            asset.category = AssetCategory.CHARACTERS
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"Animator {asset.name}: {e}")

    def _extract_mesh(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract Mesh as JSON."""
        try:
            mesh_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_Vertices'):
                verts = data.m_Vertices
                if verts:
                    mesh_data["vertex_count"] = len(verts) // 3

            if hasattr(data, 'm_Triangles'):
                tris = data.m_Triangles
                if tris:
                    mesh_data["triangle_count"] = len(tris) // 3

            asset.data = json.dumps(mesh_data, indent=2).encode('utf-8')
            asset.category = AssetCategory.GENERAL
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"Mesh {asset.name}: {e}")

    def _extract_asset_bundle(self, data, asset: ExtractedAsset, output_dir: Path) -> None:
        """Extract AssetBundle as JSON."""
        try:
            bundle_data = {"name": getattr(data, 'm_Name', '')}

            if hasattr(data, 'm_Container'):
                containers = {}
                for k, v in data.m_Container.items():
                    containers[str(k)] = str(v)
                bundle_data["containers"] = containers

            asset.data = json.dumps(bundle_data, indent=2, ensure_ascii=False).encode('utf-8')
            asset.category = AssetCategory.GENERAL
            self._save_asset(asset, output_dir, ".json")
        except Exception as e:
            self.errors.append(f"AssetBundle {asset.name}: {e}")

    def _save_asset(self, asset: ExtractedAsset, output_dir: Path, ext: str) -> None:
        """Save asset to disk."""
        if not asset.data:
            return

        # Dedup
        import hashlib
        h = hashlib.md5(asset.data[:4096] + str(len(asset.data)).encode()).hexdigest()
        if h in self._seen_hashes:
            return
        self._seen_hashes.add(h)

        # Sanitize filename
        name = asset.name
        invalid = '<>:"/\\|?*'
        for ch in invalid:
            name = name.replace(ch, "_")
        if len(name) > 200:
            name = name[:200]

        # Create directory structure
        type_subdirs = {
            "Texture2D": "Images",
            "Sprite": "Sprites",
            "AudioClip": "Audio",
            "Font": "Fonts",
            "Shader": "Shaders",
            "Material": "Materials",
            "Mesh": "Meshes",
            "AnimationClip": "Animations",
            "AnimatorController": "Animations",
            "SpriteAtlas": "Atlases",
            "TextAsset": "Data",
            "AssetBundle": "Bundles",
        }
        subdir = type_subdirs.get(asset.asset_type, "Other")
        cat_dir = output_dir / asset.category.value / subdir
        cat_dir.mkdir(parents=True, exist_ok=True)

        target_path = cat_dir / f"{name}{ext}"

        # Handle name conflicts
        counter = 1
        while target_path.exists():
            target_path = cat_dir / f"{name}_{counter}{ext}"
            counter += 1

        try:
            target_path.write_bytes(asset.data)
            asset.file_path = target_path
        except Exception as e:
            self.warnings.append(f"Could not write {target_path}: {e}")

    def _detect_unity_version(self, apk: zipfile.ZipFile) -> None:
        """Detect Unity version from APK contents."""
        import re
        try:
            for name in apk.namelist():
                if "globalgamemanagers" in name.lower() and not name.endswith("/"):
                    data = apk.read(name)
                    text = data[:4096].decode('utf-8', errors='replace')
                    match = re.search(r'(\d{4}\.\d+\.\d+[a-f]\d+)', text)
                    if match:
                        self.unity_version = UnityVersion.from_string(match.group(1))
                        return
        except Exception:
            pass

    def _log(self, msg: str) -> None:
        """Log a message."""
        pass
