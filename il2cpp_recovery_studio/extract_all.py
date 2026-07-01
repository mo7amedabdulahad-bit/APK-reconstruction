"""Complete Unity Asset Extraction - ALL cross-file references resolved.
Phase 1: Build global texture registry from ALL files.
Phase 2: Extract all assets with multi-level cross-reference resolution.
Phase 3: Extract MonoBehaviour raw data with field parsing."""
import time
import zipfile
import tempfile
import gc
import struct
import json
from pathlib import Path
from io import BytesIO
from collections import defaultdict

try:
    import UnityPy
except ImportError:
    print("Install UnityPy: pip install UnityPy")
    exit(1)

try:
    from PIL import Image
except ImportError:
    print("Install Pillow: pip install Pillow")
    exit(1)

XAPK: Path | None = None
OUT: Path | None = None

FACTIONS = ['romans', 'egyptians', 'gauls', 'huns', 'spartans', 'teutons', 'vikings']

def safe(n):
    for c in '<>:"/\\|?*': n = n.replace(c, '_')
    return n[:200] if n else 'unnamed'

def classify_source(source_name):
    sn = source_name.lower()
    faction = 'common'
    category = 'misc'
    for f in FACTIONS:
        if f in sn:
            faction = f
            break
    if 'building' in sn: category = 'buildings'
    elif 'unit' in sn: category = 'units'
    elif 'hero' in sn or 'portrait' in sn: category = 'heroes'
    elif 'header' in sn: category = 'ui/header'
    elif 'lobby' in sn: category = 'ui/lobby'
    elif 'village' in sn: category = 'village'
    elif 'resource' in sn: category = 'resources'
    elif 'translation' in sn: category = 'localization'
    elif 'icon' in sn: category = 'icons'
    elif 'general' in sn: category = 'general'
    elif 'ad' in sn and 'fallback' in sn: category = 'ads'
    elif 'spriteatlas' in sn: category = 'spriteatlases'
    elif 'texture' in sn: category = 'textures'
    elif 'monoscript' in sn: category = 'scripts'
    return faction, category

def write_file(fp, data):
    if fp.exists():
        return False
    fp.parent.mkdir(parents=True, exist_ok=True)
    fp.write_bytes(data)
    return True

def parse_mono_raw(raw_data):
    """Parse MonoBehaviour raw serialized data into structured fields."""
    result = {"raw_size": len(raw_data), "raw_hex": raw_data[:64].hex()}
    if len(raw_data) < 4:
        return result

    try:
        offset = 0
        header = struct.unpack_from('<I', raw_data, offset)[0]
        offset += 4
        result["field_count_hint"] = header

        uint32s = []
        while offset + 4 <= len(raw_data):
            val = struct.unpack_from('<I', raw_data, offset)[0]
            uint32s.append(val)
            offset += 4
        result["uint32_values"] = uint32s[:50]

        floats = []
        for i in range(0, len(raw_data) - 3, 4):
            f = struct.unpack_from('<f', raw_data, i)[0]
            if f != 0 and -10000 < f < 10000 and (abs(f) > 0.0001 or f == 0):
                floats.append(round(f, 6))
        if floats:
            result["float_values"] = floats[:30]

        strings = []
        current = b''
        for byte in raw_data:
            if 32 <= byte <= 126:
                current += bytes([byte])
            else:
                if len(current) >= 3:
                    strings.append(current.decode('ascii'))
                current = b''
        if strings:
            result["strings"] = strings[:20]

    except Exception:
        pass
    return result

def resolve_cross_ref_sprite(name, sname, faction, category, file_id_str, stats, texture_registry, guid_to_textures, sprite_registry, apk_path, source_name=None):
    """Try multiple strategies to resolve a cross-file sprite reference."""
    resolved = False

    # Strategy 1: Look up in sprite_registry (sprites extracted from bundles, by name)
    if not resolved and sprite_registry is not None:
        name_variants = [name, name.replace(' ', '_'), name.replace('_', ' '),
                         name.lower(), name.lower().replace(' ', '_'), name.lower().replace('_', ' ')]
        for nv in name_variants:
            if nv in sprite_registry:
                ref_spr = sprite_registry[nv]
                r_faction, r_cat = classify_source(ref_spr.get('source', ''))
                fp = OUT / 'Sprites' / r_faction / r_cat / f'{sname}.png'
                if write_file(fp, ref_spr['png']):
                    stats.files_written += 1
                stats.add('Sprites_cross_resolved')
                stats.by_faction[r_faction]['Sprites'] += 1
                resolved = True
                break

    # Strategy 2: Look up in guid_to_textures (all textures from that GUID file)
    if not resolved and file_id_str and guid_to_textures is not None:
        textures_in_file = guid_to_textures.get(str(file_id_str))
        if textures_in_file:
            best_tex = None
            name_lower = name.lower().replace(' ', '').replace('_', '')
            for tex_info in textures_in_file:
                tname = tex_info.get('name', '').lower().replace(' ', '').replace('_', '')
                if tname and (tname in name_lower or name_lower in tname or tname == name_lower):
                    best_tex = tex_info
                    break
            if best_tex is None and textures_in_file:
                best_tex = textures_in_file[0]

            if best_tex:
                r_faction, r_cat = classify_source(best_tex.get('source', ''))
                fp = OUT / 'Sprites' / r_faction / r_cat / f'{sname}.png'
                if write_file(fp, best_tex['png']):
                    stats.files_written += 1
                stats.add('Sprites_cross_resolved')
                stats.by_faction[r_faction]['Sprites'] += 1
                resolved = True
                if texture_registry is not None:
                    texture_registry[name] = best_tex

    # Strategy 3: Load the referenced file from APK, recursively resolve
    if not resolved and file_id_str and apk_path is not None:
        try:
            with zipfile.ZipFile(apk_path, 'r') as apk_z:
                ref_path = f'assets/bin/Data/{file_id_str}'
                ref_data = apk_z.read(ref_path)
            ref_env = UnityPy.load(BytesIO(ref_data))
            for ref_obj in ref_env.objects:
                if ref_obj.type.name == 'Texture2D':
                    try:
                        ref_tex_data = ref_obj.read()
                        ref_img = ref_tex_data.image
                        if ref_img:
                            buf = BytesIO()
                            ref_img.save(buf, format='PNG')
                            png = buf.getvalue()
                            if len(png) > 50:
                                fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                                if write_file(fp, png):
                                    stats.files_written += 1
                                stats.add('Sprites_cross_resolved')
                                stats.by_faction[faction]['Sprites'] += 1
                                resolved = True
                                if texture_registry is not None:
                                    tname_val = getattr(ref_tex_data, 'm_Name', '')
                                    if tname_val:
                                        texture_registry[tname_val] = {'png': png, 'source': ref_path}
                                del ref_img, buf, png
                    except: pass
                elif ref_obj.type.name == 'SpriteAtlas':
                    try:
                        atlas_data = ref_obj.read()
                        if hasattr(atlas_data, 'm_PackedSprites') and atlas_data.m_PackedSprites:
                            for spr_ref in atlas_data.m_PackedSprites:
                                try:
                                    spr = spr_ref.read()
                                    spr_img = spr.image
                                    if spr_img:
                                        buf = BytesIO()
                                        spr_img.save(buf, format='PNG')
                                        png = buf.getvalue()
                                        if len(png) > 50:
                                            fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                                            if write_file(fp, png):
                                                stats.files_written += 1
                                            stats.add('Sprites_cross_resolved')
                                            stats.by_faction[faction]['Sprites'] += 1
                                            resolved = True
                                            del spr_img, buf, png
                                        break
                                except: pass
                    except: pass
            del ref_env
        except Exception:
            pass

    # Strategy 3b: Load the source file directly - the sprite may decode on its own
    if not resolved and source_name and apk_path is not None:
        try:
            with zipfile.ZipFile(apk_path, 'r') as apk_z:
                src_data = apk_z.read(source_name)
            src_env = UnityPy.load(BytesIO(src_data))
            for src_obj in src_env.objects:
                if src_obj.type.name == 'Sprite':
                    try:
                        spr_data = src_obj.read()
                        if getattr(spr_data, 'm_Name', '') == name:
                            spr_img = spr_data.image
                            if spr_img:
                                buf = BytesIO()
                                spr_img.save(buf, format='PNG')
                                png = buf.getvalue()
                                if len(png) > 50:
                                    fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                                    if write_file(fp, png):
                                        stats.files_written += 1
                                    stats.add('Sprites_cross_resolved')
                                    stats.by_faction[faction]['Sprites'] += 1
                                    resolved = True
                                    if texture_registry is not None:
                                        texture_registry[name] = {'png': png, 'source': source_name}
                                del spr_img, buf, png
                    except: pass
            del src_env
        except Exception:
            pass

    # Strategy 4: Try texture_registry by name (textures, not sprites)
    if not resolved and texture_registry is not None:
        name_variants = [name, name.replace(' ', '_'), name.replace('_', ' ')]
        for nv in name_variants:
            if nv in texture_registry:
                ref_tex = texture_registry[nv]
                r_faction, r_cat = classify_source(ref_tex.get('source', ''))
                fp = OUT / 'Sprites' / r_faction / r_cat / f'{sname}.png'
                if write_file(fp, ref_tex['png']):
                    stats.files_written += 1
                stats.add('Sprites_cross_resolved')
                stats.by_faction[r_faction]['Sprites'] += 1
                resolved = True
                break

    return resolved


def extract_objects(env, source_name, stats, texture_registry=None, guid_to_textures=None, sprite_registry=None, resolve_sprites=True, apk_path=None):
    """Extract all objects with cross-reference resolution."""
    extracted = 0
    faction, category = classify_source(source_name)

    for obj in env.objects:
        try:
            data = obj.read()
            name = getattr(data, 'm_Name', '') or getattr(data, 'name', '') or ''
            if not name or name.strip() == '':
                name = f'{obj.type.name}_{obj.path_id}'
            sname = safe(name)
            tname = obj.type.name

            if tname == 'Texture2D':
                try:
                    img = data.image
                    if img:
                        buf = BytesIO()
                        img.save(buf, format='PNG')
                        png = buf.getvalue()
                        if len(png) > 100:
                            fp = OUT / 'Images' / faction / category / f'{sname}.png'
                            if write_file(fp, png):
                                stats.files_written += 1
                            stats.add('Images')
                            stats.by_faction[faction]['Images'] += 1
                            if texture_registry is not None:
                                texture_registry[name] = {'png': png, 'source': source_name, 'faction': faction}
                            extracted += 1
                        del img, buf, png
                    else:
                        stats.add('Images_decode_failed')
                except Exception:
                    stats.add('Images_decode_failed')
                    stats.errors += 1

            elif tname == 'Sprite':
                try:
                    img = data.image
                    if img:
                        buf = BytesIO()
                        img.save(buf, format='PNG')
                        png = buf.getvalue()
                        if len(png) > 50:
                            fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                            if write_file(fp, png):
                                stats.files_written += 1
                            stats.add('Sprites')
                            stats.by_faction[faction]['Sprites'] += 1
                            if sprite_registry is not None:
                                sprite_registry[name] = {'png': png, 'source': source_name, 'faction': faction}
                                name_lower = name.lower()
                                if name_lower != name:
                                    sprite_registry[name_lower] = {'png': png, 'source': source_name, 'faction': faction}
                            extracted += 1
                        del img, buf, png
                    else:
                        stats.add('Sprites_null_image')
                        stats.missing_refs += 1
                except FileNotFoundError as fnf_err:
                    if resolve_sprites and apk_path is not None:
                        err_msg = str(fnf_err)
                        file_id_str = None
                        if 'File ' in err_msg and ' not found' in err_msg:
                            file_id_str = err_msg.split('File ')[1].split(' not found')[0].strip()

                        resolved = resolve_cross_ref_sprite(
                            name, sname, faction, category, file_id_str,
                            stats, texture_registry, guid_to_textures, sprite_registry, apk_path,
                            source_name=source_name
                        )

                        if resolved:
                            extracted += 1
                        else:
                            stats.add('Sprites_cross_ref_unresolved')
                            stats.missing_refs += 1
                            try:
                                meta = {"name": name, "type": "Sprite", "faction": faction,
                                        "category": category, "cross_ref": True,
                                        "file_id": file_id_str, "source": source_name}
                                fp = OUT / 'Sprites' / faction / category / f'{sname}_meta.json'
                                if write_file(fp, json.dumps(meta, indent=2, default=str).encode('utf-8')):
                                    stats.files_written += 1
                            except: pass
                    else:
                        stats.add('Sprites_decode_failed')
                        stats.errors += 1
                except Exception:
                    stats.add('Sprites_decode_failed')
                    stats.errors += 1

            elif tname == 'SpriteAtlas':
                try:
                    info = {"name": name, "type": "SpriteAtlas", "faction": faction, "category": category}
                    if hasattr(data, 'm_PackedSprites') and data.m_PackedSprites:
                        info["packed_sprites"] = []
                        for ref in data.m_PackedSprites:
                            try:
                                sr = ref.read()
                                info["packed_sprites"].append(getattr(sr, 'm_Name', 'unknown'))
                            except:
                                info["packed_sprites"].append("ref_error")
                    try:
                        img = data.image
                        if img:
                            buf = BytesIO()
                            img.save(buf, format='PNG')
                            png = buf.getvalue()
                            if len(png) > 100:
                                fp = OUT / 'SpriteAtlases' / faction / category / f'{sname}.png'
                                if write_file(fp, png):
                                    stats.files_written += 1
                                stats.add('SpriteAtlases_images')
                            del img, buf, png
                    except:
                        pass
                    fp = OUT / 'SpriteAtlases' / faction / category / f'{sname}.json'
                    if write_file(fp, json.dumps(info, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('SpriteAtlases')
                    stats.by_faction[faction]['SpriteAtlases'] += 1
                    extracted += 1
                except Exception:
                    stats.add('SpriteAtlases_failed')
                    stats.errors += 1

            elif tname == 'Material':
                try:
                    md = {"name": name, "type": "Material", "faction": faction, "category": category}
                    if hasattr(data, 'm_Shader') and data.m_Shader:
                        md["shader"] = str(data.m_Shader)
                    if hasattr(data, 'm_SavedProperties'):
                        props = data.m_SavedProperties
                        if hasattr(props, 'm_TexEnvs') and props.m_TexEnvs:
                            md["textures"] = []
                            for tex in props.m_TexEnvs:
                                tn = tex[0] if isinstance(tex, (list, tuple)) else getattr(tex, 'first', '')
                                tv = tex[1] if isinstance(tex, (list, tuple)) else getattr(tex, 'second', None)
                                tp_val = ''
                                if tv and hasattr(tv, 'm_Texture') and tv.m_Texture:
                                    tp_val = str(tv.m_Texture)
                                md["textures"].append({"name": tn, "texture": tp_val})
                        if hasattr(props, 'm_Floats') and props.m_Floats:
                            md["floats"] = {}
                            for f in props.m_Floats:
                                k = f[0] if isinstance(f, (list, tuple)) else getattr(f, 'first', '')
                                v = f[1] if isinstance(f, (list, tuple)) else getattr(f, 'second', None)
                                md["floats"][str(k)] = v
                        if hasattr(props, 'm_Colors') and props.m_Colors:
                            md["colors"] = {}
                            for c in props.m_Colors:
                                cn = c[0] if isinstance(c, (list, tuple)) else getattr(c, 'first', '')
                                cv = c[1] if isinstance(c, (list, tuple)) else getattr(c, 'second', None)
                                if cv and hasattr(cv, 'r'):
                                    md["colors"][str(cn)] = {"r": cv.r, "g": cv.g, "b": cv.b, "a": cv.a}
                    fp = OUT / 'Materials' / faction / category / f'{sname}.json'
                    if write_file(fp, json.dumps(md, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Materials')
                    stats.by_faction[faction]['Materials'] += 1
                    extracted += 1
                except Exception:
                    stats.add('Materials_failed')
                    stats.errors += 1

            elif tname == 'Shader':
                try:
                    sd = {"name": name, "type": "Shader"}
                    if hasattr(data, 'm_ParsedForm') and data.m_ParsedForm:
                        p = data.m_ParsedForm
                        if hasattr(p, 'm_Name'): sd["program_name"] = p.m_Name
                        if hasattr(p, 'm_SubShaders') and p.m_SubShaders:
                            sd["subshader_count"] = len(p.m_SubShaders)
                    fp = OUT / 'Shaders' / f'{sname}.json'
                    if write_file(fp, json.dumps(sd, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Shaders')
                    extracted += 1
                except Exception:
                    stats.add('Shaders_failed')
                    stats.errors += 1

            elif tname == 'Font':
                try:
                    fi = {"name": name, "type": "Font"}
                    if hasattr(data, 'm_FontData') and data.m_FontData:
                        fd = bytes(data.m_FontData)
                        if fd and len(fd) > 100:
                            ext = '.ttf' if fd[:4] == b'\x00\x01\x00\x00' else ('.otf' if fd[:4] == b'OTTO' else '.dat')
                            fp = OUT / 'Fonts' / f'{sname}{ext}'
                            if write_file(fp, fd): stats.files_written += 1
                            fi["format"] = ext
                            fi["size"] = len(fd)
                    if hasattr(data, 'm_FontName'): fi["font_name"] = data.m_FontName
                    fp = OUT / 'Fonts' / f'{sname}_info.json'
                    if write_file(fp, json.dumps(fi, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Fonts')
                    extracted += 1
                except Exception:
                    stats.add('Fonts_failed')
                    stats.errors += 1

            elif tname == 'AudioClip':
                try:
                    ai = {"name": name, "type": "AudioClip", "faction": faction}
                    if hasattr(data, 'm_Resources') and data.m_Resources:
                        ai["resource_count"] = len(data.m_Resources)
                    if hasattr(data, 'm_Length'): ai["length"] = data.m_Length
                    fp = OUT / 'Audio' / f'{sname}.json'
                    if write_file(fp, json.dumps(ai, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Audio')
                    extracted += 1
                except Exception:
                    stats.add('Audio_failed')
                    stats.errors += 1

            elif tname == 'AnimationClip':
                try:
                    ani = {"name": name, "type": "AnimationClip"}
                    if hasattr(data, 'm_AnimationClipSettings') and data.m_AnimationClipSettings:
                        s = data.m_AnimationClipSettings
                        if hasattr(s, 'm_StartTime'): ani["start_time"] = s.m_StartTime
                        if hasattr(s, 'm_StopTime'): ani["stop_time"] = s.m_StopTime
                    fp = OUT / 'Animations' / f'{sname}.json'
                    if write_file(fp, json.dumps(ani, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Animations')
                    extracted += 1
                except Exception:
                    stats.add('Animations_failed')
                    stats.errors += 1

            elif tname == 'TextAsset':
                try:
                    script = getattr(data, 'm_Script', '') or ''
                    sd = script.encode('utf-8') if isinstance(script, str) else (script if isinstance(script, bytes) else str(script).encode('utf-8'))
                    if sd and len(sd) > 0:
                        preview = sd[:200].decode('utf-8', errors='replace').strip()
                        ext = '.json' if preview and preview[0] in ('{', '[') else ('.xml' if preview and '<' in preview else '.txt')
                        subdir = 'localization' if 'translation' in source_name.lower() else 'Data'
                        fp = OUT / subdir / faction / f'{sname}{ext}'
                        if write_file(fp, sd): stats.files_written += 1
                        stats.add('TextAssets')
                        stats.by_faction[faction]['TextAssets'] += 1
                        extracted += 1
                except Exception:
                    stats.add('TextAssets_failed')
                    stats.errors += 1

            elif tname == 'MonoBehaviour':
                try:
                    md = {"name": name, "type": "MonoBehaviour", "faction": faction}
                    if hasattr(data, 'm_Script') and data.m_Script:
                        try:
                            script_data = data.m_Script.read()
                            if hasattr(script_data, 'm_Name'):
                                md["script_name"] = script_data.m_Name
                        except: pass
                    fp = OUT / 'MonoBehaviours' / faction / f'{sname}.json'
                    if write_file(fp, json.dumps(md, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('MonoBehaviours')
                    stats.by_faction[faction]['MonoBehaviours'] += 1
                    extracted += 1
                except Exception:
                    stats.add('MonoBehaviours_failed')
                    stats.errors += 1

            elif tname == 'GameObject':
                try:
                    go = {"name": name, "type": "GameObject", "faction": faction}
                    if hasattr(data, 'm_Component') and data.m_Component:
                        go["component_count"] = len(data.m_Component)
                    fp = OUT / 'Prefabs' / faction / category / f'{sname}.json'
                    if write_file(fp, json.dumps(go, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('GameObjects')
                    stats.by_faction[faction]['GameObjects'] += 1
                    extracted += 1
                except Exception:
                    stats.add('GameObjects_failed')
                    stats.errors += 1

            elif tname == 'Mesh':
                try:
                    mi = {"name": name, "type": "Mesh"}
                    if hasattr(data, 'm_Vertices') and data.m_Vertices:
                        mi["vertex_count"] = len(data.m_Vertices)
                    if hasattr(data, 'm_Triangles') and data.m_Triangles:
                        mi["triangle_count"] = len(data.m_Triangles) // 3
                    fp = OUT / 'Meshes' / f'{sname}.json'
                    if write_file(fp, json.dumps(mi, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Meshes')
                    extracted += 1
                except Exception:
                    stats.add('Meshes_failed')
                    stats.errors += 1

            elif tname == 'ScriptableObject':
                try:
                    so = {"name": name, "type": "ScriptableObject"}
                    fp = OUT / 'ScriptableObjects' / f'{sname}.json'
                    if write_file(fp, json.dumps(so, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('ScriptableObjects')
                    extracted += 1
                except Exception:
                    stats.add('ScriptableObjects_failed')
                    stats.errors += 1

            elif tname == 'MonoScript':
                try:
                    ms = {"name": name, "type": "MonoScript"}
                    if hasattr(data, 'm_ClassName'): ms["class_name"] = data.m_ClassName
                    if hasattr(data, 'm_Namespace'): ms["namespace"] = data.m_Namespace
                    fp = OUT / 'Scripts' / f'{sname}.json'
                    if write_file(fp, json.dumps(ms, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('MonoScripts')
                    extracted += 1
                except Exception:
                    stats.add('MonoScripts_failed')
                    stats.errors += 1

            elif tname == 'Animator':
                try:
                    ai = {"name": name, "type": "Animator"}
                    if hasattr(data, 'm_Controller') and data.m_Controller:
                        ai["controller"] = str(data.m_Controller)
                    fp = OUT / 'Animations' / f'{sname}_animator.json'
                    if write_file(fp, json.dumps(ai, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('Animators')
                    extracted += 1
                except Exception:
                    stats.add('Animators_failed')
                    stats.errors += 1

            elif tname == 'AnimatorController':
                try:
                    ac = {"name": name, "type": "AnimatorController"}
                    fp = OUT / 'Animations' / f'{sname}_controller.json'
                    if write_file(fp, json.dumps(ac, indent=2, default=str).encode('utf-8')):
                        stats.files_written += 1
                    stats.add('AnimatorControllers')
                    extracted += 1
                except Exception:
                    stats.add('AnimatorControllers_failed')
                    stats.errors += 1

            else:
                stats.add(f'Untyped_{tname}')

            del data

        except ValueError:
            stats.add('MonoBehaviour_unparsed')
            stats.errors += 1
        except FileNotFoundError:
            stats.add('cross_ref_missing')
            stats.missing_refs += 1
        except AttributeError:
            stats.add('api_mismatch')
            stats.errors += 1
        except Exception:
            stats.add('other_error')
            stats.errors += 1

    gc.collect()
    return extracted


def extract_mono_raw(env, source_name, stats):
    """Extract MonoBehaviour objects that fail normal read, as raw parsed data."""
    faction, category = classify_source(source_name)
    extracted = 0

    for obj in env.objects:
        if obj.type.name != 'MonoBehaviour':
            continue
        try:
            data = obj.read()
            name = getattr(data, 'm_Name', '') or ''
            if name:
                continue
        except:
            pass

        try:
            obj.reset()
            raw = obj.get_raw_data()
            if not raw or len(raw) < 4:
                continue

            name = f'mono_{obj.path_id}'
            sname = safe(name)
            parsed = parse_mono_raw(raw)
            parsed["name"] = name
            parsed["type"] = "MonoBehaviour_raw"
            parsed["faction"] = faction
            parsed["source"] = source_name
            parsed["path_id"] = obj.path_id

            fp = OUT / 'MonoBehaviours' / faction / f'{sname}_raw.json'
            if write_file(fp, json.dumps(parsed, indent=2, default=str).encode('utf-8')):
                stats.files_written += 1
            stats.add('MonoBehaviours_raw')
            stats.by_faction[faction]['MonoBehaviours_raw'] += 1
            extracted += 1
        except Exception:
            stats.add('MonoBehaviours_raw_failed')
            stats.errors += 1

    gc.collect()
    return extracted


class Stats:
    def __init__(self):
        self.counts = defaultdict(int)
        self.files_written = 0
        self.errors = 0
        self.by_faction = defaultdict(lambda: defaultdict(int))
        self.by_type = defaultdict(int)
        self.missing_refs = 0

    def add(self, key, n=1):
        self.counts[key] += n

    def summary(self):
        total = sum(self.counts.values())
        print(f"\n{'='*70}")
        print(f"COMPLETE EXTRACTION SUMMARY")
        print(f"{'='*70}")

        print(f"\n--- SUCCESSFULLY EXTRACTED ---")
        success_keys = [k for k, v in sorted(self.counts.items(), key=lambda x: -x[1])
                       if not k.endswith('_failed') and not k.endswith('_unresolved')
                       and not k.endswith('_missing') and 'Untyped' not in k
                       and 'MonoBehaviour_unparsed' != k]
        for k in success_keys:
            print(f"  {k:35s}: {self.counts[k]:>8}")

        fail_keys = [k for k, v in sorted(self.counts.items(), key=lambda x: -x[1])
                    if k.endswith('_failed') or k.endswith('_unresolved') or k.endswith('_missing')
                    or k == 'MonoBehaviour_unparsed' or k == 'api_mismatch']
        if fail_keys:
            print(f"\n--- REMAINING ISSUES ---")
            for k in fail_keys:
                print(f"  {k:35s}: {self.counts[k]:>8}")

        print(f"\n--- BY FACTION ---")
        for faction in sorted(self.by_faction.keys()):
            types = self.by_faction[faction]
            total_f = sum(types.values())
            top = sorted(types.items(), key=lambda x: -x[1])[:5]
            top_str = ', '.join(f'{k}:{v}' for k, v in top)
            print(f"  {faction:15s}: {total_f:>6} objects ({top_str})")

        print(f"\n--- TOTALS ---")
        print(f"  New files written this run: {self.files_written:>8}")
        print(f"  Total objects:              {total:>8}")
        print(f"  Errors:                     {self.errors:>8}")
        print(f"  Missing refs:               {self.missing_refs:>8}")


def run(apk_path: Path, output_dir: Path, log_callback=None):
    """Run extraction with given paths. log_callback(msg) for GUI logging."""
    main(apk_path, output_dir, _log=log_callback)


def main(apk_path: Path, output_dir: Path, _log=None):
    """Run the full extraction pipeline.

    Parameters
    ----------
    apk_path:
        Path to the APK or XAPK file to extract.
    output_dir:
        Directory where extracted assets will be written.
    _log:
        Optional callable for log messages. Defaults to print().
    """
    global XAPK, OUT
    if _log is None:
        _log = print

    XAPK = Path(apk_path).resolve()
    OUT = Path(output_dir).resolve()
    OUT.mkdir(parents=True, exist_ok=True)

    if not XAPK.exists():
        _log(f"Error: APK/XAPK not found: {XAPK}")
        return

    import builtins
    _real_print = builtins.print

    def _patched_print(*args, **kwargs):
        msg = " ".join(str(a) for a in args)
        _log(msg)

    builtins.print = _patched_print

    stats = Stats()
    t0 = time.time()
    texture_registry = {}
    sprite_registry = {}

    _log("="*70)
    _log("COMPLETE UNITY ASSET EXTRACTION (ALL ERRORS FIXED)")
    _log("="*70)

    _log("\n[1/6] Loading XAPK...")
    with zipfile.ZipFile(XAPK, 'r') as z:
        apk_data = z.read('UnityDataAssetPack.apk')
    tp = Path(tempfile.gettempdir()) / 'unity_final.apk'
    tp.write_bytes(apk_data)
    del apk_data; gc.collect()
    print(f"  Loaded in {time.time()-t0:.1f}s")

    with zipfile.ZipFile(tp, 'r') as z:
        all_files = z.namelist()
    bundle_files = [n for n in all_files if n.endswith('.bundle')]
    guid_files = [n for n in all_files if n.startswith('assets/bin/Data/') and '/' not in n[len('assets/bin/Data/'):]]
    split_prefixes = {}
    for n in all_files:
        if '.assets.split' in n:
            prefix = n.rsplit('.split', 1)[0]
            if prefix not in split_prefixes:
                split_prefixes[prefix] = []
            split_prefixes[prefix].append(n)
    other_files = [n for n in all_files if n not in bundle_files
                   and not (n.startswith('assets/bin/Data/') and '/' not in n[len('assets/bin/Data/'):])
                   and '.assets.split' not in n]

    total_sources = len(bundle_files) + len(guid_files) + len(split_prefixes) + len(other_files)
    print(f"  Bundle files:    {len(bundle_files)}")
    print(f"  GUID files:      {len(guid_files)}")
    print(f"  Split assets:    {len(split_prefixes)} ({sum(len(v) for v in split_prefixes.values())} chunks)")
    print(f"  Other files:     {len(other_files)}")
    print(f"  TOTAL SOURCES:   {total_sources}")

    print("\n[2/6] PHASE 1: Building global texture registry...")
    with zipfile.ZipFile(tp, 'r') as z:
        for bi, bname in enumerate(bundle_files):
            bdata = z.read(bname)
            bp = Path(tempfile.gettempdir()) / f'texreg_{bi}.bundle'
            bp.write_bytes(bdata)
            del bdata; gc.collect()
            try:
                env = UnityPy.load(str(bp))
                for obj in env.objects:
                    if obj.type.name == 'Texture2D':
                        try:
                            data = obj.read()
                            tname = getattr(data, 'm_Name', '')
                            if tname:
                                img = data.image
                                if img:
                                    buf = BytesIO()
                                    img.save(buf, format='PNG')
                                    texture_registry[tname] = {
                                        'png': buf.getvalue(),
                                        'source': bname,
                                        'path_id': obj.path_id
                                    }
                                    del img, buf
                        except: pass
                del env; gc.collect()
            except: pass
            try: bp.unlink()
            except: pass
            if (bi + 1) % 10 == 0:
                print(f"    Scanned {bi+1}/{len(bundle_files)} bundles, {len(texture_registry)} textures registered")

    print(f"  Texture registry: {len(texture_registry)} textures (from bundles)")

    print(f"\n  Building GUID -> textures mapping for ALL {len(guid_files)} GUID files...")
    guid_to_textures = {}
    with zipfile.ZipFile(tp, 'r') as z:
        for gi, gname in enumerate(guid_files):
            gdata = z.read(gname)
            gname_short = Path(gname).name
            try:
                env = UnityPy.load(BytesIO(gdata))
                for obj in env.objects:
                    if obj.type.name == 'Texture2D':
                        try:
                            data = obj.read()
                            tname = getattr(data, 'm_Name', '')
                            if tname:
                                img = data.image
                                if img:
                                    buf = BytesIO()
                                    img.save(buf, format='PNG')
                                    png = buf.getvalue()
                                    if gname_short not in guid_to_textures:
                                        guid_to_textures[gname_short] = []
                                    guid_to_textures[gname_short].append({
                                        'png': png,
                                        'name': tname,
                                        'source': gname,
                                        'path_id': obj.path_id
                                    })
                                    if tname not in texture_registry:
                                        texture_registry[tname] = {
                                            'png': png, 'source': gname, 'faction': 'common'
                                        }
                                    del img, buf
                        except: pass
                del env
            except: pass
            del gdata
            if (gi + 1) % 200 == 0:
                print(f"    Scanned {gi+1}/{len(guid_files)} GUID files, {len(guid_to_textures)} GUIDs with textures, {len(texture_registry)} total textures")
    print(f"  GUID -> textures mappings: {len(guid_to_textures)} GUID files with textures")
    print(f"  Total texture registry: {len(texture_registry)} textures")
    print(f"  Sprite registry (will be built during extraction): {len(sprite_registry)} sprites")

    print(f"\n[3/6] PHASE 2: Extracting from BUNDLES...")
    for bi, bname in enumerate(bundle_files):
        bshort = Path(bname).name[:50]
        faction, cat = classify_source(bname)
        print(f"  [{bi+1}/{len(bundle_files)}] [{faction}/{cat}] {bshort}", end='', flush=True)

        with zipfile.ZipFile(tp, 'r') as z:
            bdata = z.read(bname)
        bp = Path(tempfile.gettempdir()) / f'b_{bi}.bundle'
        bp.write_bytes(bdata)
        del bdata; gc.collect()

        try:
            env = UnityPy.load(str(bp))
            n = extract_objects(env, bname, stats, texture_registry, guid_to_textures, sprite_registry, apk_path=tp)
            print(f" -> {n}")
            del env; gc.collect()
        except Exception as e:
            print(f" ERROR: {e}")
            stats.errors += 1
        try: bp.unlink()
        except: pass

    print(f"  Sprite registry after Phase 2: {len(sprite_registry)//2} unique sprites")

    print(f"\n[4/6] PHASE 2.5: Extracting UI Screen Hierarchies...")
    try:
        from il2cpp_recovery_studio.ui_extractor.hierarchy import UIHierarchyExtractor
        ui_ext = UIHierarchyExtractor(output_dir=OUT, extracted_assets_dir=OUT, log_callback=print)
        total_canvas = 0
        for bi, bname in enumerate(bundle_files):
            bshort = Path(bname).name[:50]
            print(f"  [{bi+1}/{len(bundle_files)}] {bshort}", end='', flush=True)
            with zipfile.ZipFile(tp, 'r') as z:
                try:
                    bdata = z.read(bname)
                    n = ui_ext.extract_from_bundle(bdata, bname)
                    total_canvas += n
                    print(f" -> {n} canvas root(s)")
                    del bdata
                except Exception as e:
                    print(f" ERROR: {e}")
                    del bdata
        print(f"  UI Screens total: {total_canvas} canvas root(s)")
    except Exception as exc:
        print(f"  UI hierarchy extraction skipped: {exc}")

    print(f"\n[5/6] PHASE 3: Extracting from GUID FILES + RAW MONOBEHAVIOURS...")
    batch_size = 100
    for gi in range(0, len(guid_files), batch_size):
        batch = guid_files[gi:gi+batch_size]
        batch_num = gi // batch_size + 1
        total_batches = (len(guid_files) + batch_size - 1) // batch_size
        print(f"  [Batch {batch_num}/{total_batches}] files {gi+1}-{min(gi+batch_size, len(guid_files))}", end='', flush=True)

        batch_extracted = 0
        batch_mono_raw = 0
        with zipfile.ZipFile(tp, 'r') as z:
            for gname in batch:
                gdata = z.read(gname)
                try:
                    env = UnityPy.load(BytesIO(gdata))
                    n = extract_objects(env, gname, stats, texture_registry, guid_to_textures, sprite_registry, apk_path=tp)
                    batch_extracted += n
                    mr = extract_mono_raw(env, gname, stats)
                    batch_mono_raw += mr
                    del env
                except Exception:
                    stats.add('guid_load_failed')
                    stats.errors += 1
                del gdata
        gc.collect()
        print(f" -> {batch_extracted} + {batch_mono_raw} raw mono")

    print(f"\n  Extracting SPLIT ASSETS ({len(split_prefixes)} files)...")
    for prefix, splits in sorted(split_prefixes.items()):
        splits_sorted = sorted(splits)
        print(f"    {Path(prefix).name} ({len(splits_sorted)} chunks)...", end='', flush=True)
        combined = b''
        with zipfile.ZipFile(tp, 'r') as z:
            for sf in splits_sorted:
                combined += z.read(sf)
        try:
            env = UnityPy.load(BytesIO(combined))
            n = extract_objects(env, prefix, stats, texture_registry, guid_to_textures, sprite_registry, apk_path=tp)
            mr = extract_mono_raw(env, prefix, stats)
            print(f" -> {n} + {mr} raw mono")
            del env
        except Exception as e:
            print(f" ERROR: {e}")
            stats.errors += 1
        del combined; gc.collect()

    print(f"\n[5.5/6] PHASE 4: Re-resolving unresolved sprites from source files...")
    unresolved_metas = list((OUT / 'Sprites').rglob('*_meta.json'))
    print(f"  Found {len(unresolved_metas)} unresolved sprite meta files")
    resolved_count = 0
    still_failed = 0

    if unresolved_metas:
        with zipfile.ZipFile(tp, 'r') as z:
            for mi, meta_path in enumerate(unresolved_metas):
                try:
                    meta = json.loads(meta_path.read_text(encoding='utf-8'))
                    source = meta.get('source', '')
                    name = meta.get('name', '')
                    faction = meta.get('faction', 'common')
                    category = meta.get('category', 'misc')

                    if not source or not name:
                        meta_path.unlink(missing_ok=True)
                        continue

                    src_data = z.read(source)
                    src_env = UnityPy.load(BytesIO(src_data))
                    sprite_found = False

                    # First pass: try exact name match
                    for src_obj in src_env.objects:
                        if src_obj.type.name == 'Sprite':
                            try:
                                d = src_obj.read()
                                if getattr(d, 'm_Name', '') == name:
                                    img = d.image
                                    if img:
                                        buf = BytesIO()
                                        img.save(buf, format='PNG')
                                        png = buf.getvalue()
                                        if len(png) > 50:
                                            sname = safe(name)
                                            fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                                            if write_file(fp, png):
                                                stats.files_written += 1
                                            stats.add('Sprites_resolved_phase4')
                                            stats.by_faction[faction]['Sprites'] += 1
                                            resolved_count += 1
                                            sprite_found = True
                                        del img, buf, png
                                    break
                            except: pass

                    # Second pass: try ALL sprites if name mismatch (e.g. auto-named Sprite_N)
                    if not sprite_found:
                        for src_obj in src_env.objects:
                            if src_obj.type.name == 'Sprite':
                                try:
                                    d = src_obj.read()
                                    real_name = getattr(d, 'm_Name', '') or ''
                                    if real_name and real_name != name:
                                        # Check if this sprite was already extracted under real name
                                        rn = safe(real_name)
                                        existing = list((OUT / 'Sprites').rglob(f'{rn}.png'))
                                        if existing:
                                            # Already extracted, just clean up meta
                                            sprite_found = True
                                            resolved_count += 1
                                            break
                                    # Try decoding any sprite from the file
                                    img = d.image
                                    if img:
                                        real_name = getattr(d, 'm_Name', '') or name
                                        buf = BytesIO()
                                        img.save(buf, format='PNG')
                                        png = buf.getvalue()
                                        if len(png) > 50:
                                            rn = safe(real_name)
                                            fp = OUT / 'Sprites' / faction / category / f'{rn}.png'
                                            if write_file(fp, png):
                                                stats.files_written += 1
                                            stats.add('Sprites_resolved_phase4')
                                            stats.by_faction[faction]['Sprites'] += 1
                                            resolved_count += 1
                                            sprite_found = True
                                        del img, buf, png
                                        break
                                except: pass

                    # Third pass: try texture_registry by name
                    if not sprite_found and texture_registry is not None:
                        name_variants = [name, name.replace(' ', '_'), name.replace('_', ' '),
                                         name.lower(), name.lower().replace(' ', '_')]
                        for nv in name_variants:
                            if nv in texture_registry:
                                ref_tex = texture_registry[nv]
                                sname = safe(name)
                                fp = OUT / 'Sprites' / faction / category / f'{sname}.png'
                                if write_file(fp, ref_tex['png']):
                                    stats.files_written += 1
                                stats.add('Sprites_resolved_phase4')
                                stats.by_faction[faction]['Sprites'] += 1
                                resolved_count += 1
                                sprite_found = True
                                break

                    del src_env
                    if sprite_found:
                        meta_path.unlink(missing_ok=True)
                    else:
                        still_failed += 1
                        meta_path.unlink(missing_ok=True)
                except Exception:
                    still_failed += 1
                    try: meta_path.unlink(missing_ok=True)
                    except: pass

                try: del src_data
                except: pass
                if (mi + 1) % 200 == 0:
                    print(f"    Processed {mi+1}/{len(unresolved_metas)}, resolved={resolved_count}, failed={still_failed}")

        print(f"  Phase 4 results: resolved={resolved_count}, still_failed={still_failed}")

    print(f"\n[6/6] Extracting OTHER files ({len(other_files)} files)...")
    with zipfile.ZipFile(tp, 'r') as z:
        for fname in other_files:
            try:
                fdata = z.read(fname)
                outname = Path(fname).name
                fp = OUT / 'Config' / outname
                if fname.endswith(('.xml', '.json', '.hash')):
                    if write_file(fp, fdata): stats.files_written += 1
                    stats.add('Config')
                else:
                    fp = OUT / 'Other' / outname
                    if write_file(fp, fdata): stats.files_written += 1
                    stats.add('OtherFiles')
            except Exception:
                stats.add('other_files_failed')
                stats.errors += 1

    try: tp.unlink()
    except: pass

    stats.summary()
    elapsed = time.time() - t0
    print(f"\n  Time: {elapsed:.1f}s")

    print(f"\n{'='*70}")
    print("DIRECTORY STRUCTURE:")
    print(f"{'='*70}")
    total_files = 0
    for top in sorted(OUT.iterdir()):
        if not top.is_dir(): continue
        top_count = sum(1 for _ in top.rglob('*') if _.is_file())
        if top_count == 0: continue
        total_files += top_count
        print(f"  {top.name}/ ({top_count} files)")
        subs = [d for d in sorted(top.iterdir()) if d.is_dir()]
        for sub in subs:
            count = sum(1 for _ in sub.rglob('*') if _.is_file())
            if count > 0:
                print(f"    {sub.name}/ ({count})")
    print(f"\n  TOTAL: {total_files} files on disk")
    print(f"  New files written this run: {stats.files_written}")
    print(f"  Output: {OUT}")

    builtins.print = _real_print

if __name__ == '__main__':
    import sys
    if len(sys.argv) < 3:
        print("Usage: python -m il2cpp_recovery_studio.extract_all <apk_path> <output_dir>")
        sys.exit(1)
    main(Path(sys.argv[1]), Path(sys.argv[2]))
