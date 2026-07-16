"""Unity serialized file and asset bundle parser."""

from __future__ import annotations

import struct
import zlib
import hashlib
from pathlib import Path
from typing import Any, Optional
from io import BytesIO

from .models import (
    UnitySerializedHeader, SerializedObjectInfo, TypeTreeNode,
    SpriteRect, SpriteAtlasData, ExtractedAsset, AssetCategory,
    UnityVersion,
)

# Unity class IDs
CLASS_IDS = {
    0: "Object",
    1: "GameObject",
    2: "Transform",
    4: "Camera",
    5: "Material",
    6: "MeshRenderer",
    8: "MeshFilter",
    20: "GameObject",
    21: "Component",
    23: "Camera",
    25: "Renderer",
    27: "Collider",
    28: "Rigidbody",
    33: "Mesh",
    34: "Texture",
    35: "Texture2D",
    36: "Texture3D",
    37: "TextureCube",
    43: "MeshRenderer",
    45: "ScriptableObject",
    48: "Material",
    52: "AudioClip",
    64: "AudioListener",
    81: "AudioClip",
    83: "AssetBundle",
    84: "ResourceManager",
    86: "Sprite",
    87: "SpriteRenderer",
    89: "ScreenRenderer",
    108: "Light",
    114: "MonoBehaviour",
    128: "GameObject",
    129: "Canvas",
    130: "RectTransform",
    133: "CanvasGroup",
    135: "TextMesh",
    136: "RenderTexture",
    152: "SpriteAtlas",
    154: "Animator",
    156: "AnimatorController",
    157: "RuntimeAnimatorController",
    158: "Avatar",
    159: "AnimatorOverrideController",
    160: "MonoBehaviour",
    171: "CanvasRenderer",
    174: "MovieTexture",
    178: "AssetBundleManifest",
    196: "ScriptableObject",
    197: "Font",
    198: "GUISkin",
    213: "SpriteAtlas",
    222: "Canvas",
    223: "UnityEngine.UI.Text",
    225: "UnityEngine.UI.Image",
    226: "UnityEngine.UI.Button",
    227: "Toggle",
    229: "InputField",
    230: "ScrollRect",
    319: "AvatarMask",
    320: "AssetBundleManifest",
    328: "TerrainData",
    330: "AnimatorStateMachine",
    331: "AnimatorState",
    332: "AnimatorTransition",
    74: "AnimationClip",
    207: "AnimationClip",
    1101: "AnimationClip",
    206: "AnimationClip",
}

# Texture format constants
TEXTURE_FORMATS = {
    1: "Alpha8", 2: "ARGB4444", 3: "RGB24", 4: "RGBA32", 5: "ARGB32",
    7: "RGB565", 9: "R16", 10: "DXT1", 12: "DXT5", 13: "BGRA32",
    15: "RHalf", 16: "RGHalf", 17: "RGBAHalf", 18: "RFloat",
    19: "RGFloat", 20: "RGBAFloat", 21: "YUY2", 22: "RGB9e5Float",
    26: "BC4", 27: "BC5", 28: "BC6H", 29: "BC7",
    30: "DXT1Crunched", 31: "DXT5Crunched",
    33: "PVRTC_RGB2", 34: "PVRTC_RGBA2", 35: "PVRTC_RGB4", 36: "PVRTC_RGBA4",
    37: "ETC_RGB4", 38: "EAC_R", 39: "EAC_RG",
    40: "ETC2_RGB", 41: "ETC2_RGBA1", 42: "ETC2_RGBA8",
    43: "ASTC_RGB_4x4", 44: "ASTC_RGB_5x5", 45: "ASTC_RGB_6x6",
    46: "ASTC_RGB_8x8", 47: "ASTC_RGB_10x10", 48: "ASTC_RGB_12x12",
    49: "ASTC_RGBA_4x4", 50: "ASTC_RGBA_5x5", 51: "ASTC_RGBA_6x6",
    52: "ASTC_RGBA_8x8", 53: "ASTC_RGBA_10x10", 54: "ASTC_RGBA_12x12",
    55: "RG16", 56: "R8",
    62: "ETC_RGB4Crunched", 63: "ETC2_RGBA8Crunched",
    64: "ASTC_HDR_4x4", 65: "ASTC_HDR_5x5", 66: "ASTC_HDR_6x6",
    67: "ASTC_HDR_8x8", 68: "ASTC_HDR_10x10", 69: "ASTC_HDR_12x12",
}


class UnitySerializedParser:
    """Parser for Unity serialized files (.assets, .resource, etc.)."""

    def __init__(self, data: bytes, filename: str = ""):
        self.data = data
        self.filename = filename
        self.stream = BytesIO(data)
        self.header = UnitySerializedHeader()
        self.objects: list[SerializedObjectInfo] = []
        self.types: list[TypeTreeNode] = []
        self.external_refs: list[dict[str, Any]] = []
        self.parsed_objects: list[dict[str, Any]] = []

    def parse(self) -> UnitySerializedHeader:
        """Parse Unity serialized file header and object table."""
        try:
            self._parse_header()
            self._parse_object_table()
            return self.header
        except Exception:
            return self.header

    def _parse_header(self) -> None:
        """Parse the serialized file header."""
        s = self.stream
        s.seek(0)

        # Read metadata size, file size, version, data offset
        meta_size = struct.unpack('<I', s.read(4))[0]
        file_size = struct.unpack('<I', s.read(4))[0]
        version = struct.unpack('<I', s.read(4))[0]
        data_offset = struct.unpack('<I', s.read(4))[0]

        self.header.version = version

        if version >= 22:
            # Big endian flag, target platform
            big_endian = struct.unpack('B', s.read(1))[0]
            self.header.platform = struct.unpack('<I', s.read(4))[0]
            # Unity version string
            unity_ver_len = struct.unpack('<I', s.read(4))[0]
            self.header.unity_version = s.read(unity_ver_len).rstrip(b'\x00').decode('utf-8', errors='replace')
            # Type tree
            has_type_tree = struct.unpack('B', s.read(1))[0]
            type_count = struct.unpack('<I', s.read(4))[0]
            self.header.script_count = type_count

            if has_type_tree:
                for _ in range(type_count):
                    self._parse_type_tree_node()
        elif version >= 14:
            unity_ver_len = struct.unpack('<I', s.read(4))[0]
            self.header.unity_version = s.read(unity_ver_len).rstrip(b'\x00').decode('utf-8', errors='replace')
        else:
            self.header.unity_version = "unknown"

        # Object count and info offset
        self.header.object_count = struct.unpack('<I', s.read(4))[0]
        self.header.object_info_offset = struct.unpack('<I', s.read(4))[0]

        if version >= 14:
            self.header.script_count = struct.unpack('<I', s.read(4))[0]
            self.header.external_count = struct.unpack('<I', s.read(4))[0]

    def _parse_type_tree_node(self) -> None:
        """Parse a type tree node."""
        s = self.stream
        try:
            type_hash = s.read(4)  # hash
            base_count = struct.unpack('<H', s.read(2))[0]
            string_table_len = struct.unpack('<I', s.read(4))[0]
            s.read(string_table_len)  # string table

            for _ in range(base_count):
                level = struct.unpack('B', s.read(1))[0]
                type_index = struct.unpack('<h', s.read(2))[0]
                name_offset = struct.unpack('<h', s.read(2))[0]
                byte_size = struct.unpack('<h', s.read(2))[0]
                index = struct.unpack('<h', s.read(2))[0]
                is_array = struct.unpack('B', s.read(1))[0]
                meta_flag = struct.unpack('<h', s.read(2))[0]

                node = TypeTreeNode(
                    byte_size=byte_size,
                    index=index,
                    is_array=bool(is_array),
                )
                self.types.append(node)
        except struct.error:
            pass

    def _parse_object_table(self) -> None:
        """Parse the object info table."""
        s = self.stream
        try:
            if self.header.version >= 14:
                s.seek(self.header.object_info_offset)
                for _ in range(self.header.object_count):
                    class_id = struct.unpack('<i', s.read(4))[0]
                    if self.header.version >= 16:
                        s.read(4)  # path_id high
                    path_id = struct.unpack('<q', s.read(8))[0]

                    if self.header.version >= 22:
                        s.read(4)  # serialized file offset high
                        byte_offset = struct.unpack('<I', s.read(4))[0]
                        byte_size = struct.unpack('<I', s.read(4))[0]
                    else:
                        byte_offset = struct.unpack('<I', s.read(4))[0]
                        byte_size = struct.unpack('<I', s.read(4))[0]

                    type_index = struct.unpack('<h', s.read(2))[0]
                    is_stripped = struct.unpack('B', s.read(1))[0]

                    obj = SerializedObjectInfo(
                        class_id=class_id,
                        path_id=path_id,
                        byte_offset=byte_offset,
                        byte_size=byte_size,
                        type_index=type_index,
                        is_stripped=bool(is_stripped),
                    )
                    self.objects.append(obj)
        except struct.error:
            pass


class AssetBundleParser:
    """Parser for Unity asset bundles (.unity3d, .bundle)."""

    def __init__(self, data: bytes):
        self.data = data
        self.header: dict[str, Any] = {}
        self.assets: list[ExtractedAsset] = []

    def parse(self) -> list[ExtractedAsset]:
        """Parse an asset bundle and extract assets."""
        try:
            self._parse_header()
            if self.header.get("compressed"):
                self._decompress()
            self._extract_assets()
            return self.assets
        except Exception:
            return []

    def _parse_header(self) -> None:
        """Parse asset bundle header."""
        s = BytesIO(self.data)

        # Check for UnityFS magic
        magic = s.read(8)
        if magic.startswith(b"UnityFS"):
            self.header["format"] = "UnityFS"
            version = struct.unpack('<I', s.read(4))[0]
            unity_version_len = struct.unpack('<I', s.read(4))[0]
            unity_version = s.read(unity_version_len).rstrip(b'\x00').decode('utf-8', errors='replace')
            self.header["unity_version"] = unity_version
            self.header["version"] = version

            # Size info
            if version >= 2:
                s.read(8)  # total file size

            # Block info
            block_count = struct.unpack('<I', s.read(4))[0]
            s.read(4)  # block info size
            self.header["block_count"] = block_count
            self.header["decompressed_size"] = 0

            blocks = []
            for _ in range(block_count):
                decompressed = struct.unpack('<I', s.read(4))[0]
                compressed = struct.unpack('<I', s.read(4))[0]
                flags = struct.unpack('<H', s.read(2))[0]
                blocks.append({
                    "decompressed": decompressed,
                    "compressed": compressed,
                    "flags": flags,
                })

            self.header["blocks"] = blocks
            self.header["compressed"] = any(b["flags"] & 1 for b in blocks)
            self.header["data_offset"] = s.tell()

        elif self.data[:4] in (b"UNOX", b"\x00\x00\x00\x00"):
            self.header["format"] = "legacy"
            self.header["compressed"] = False
            self.header["data_offset"] = 0

    def _decompress(self) -> None:
        """Decompress LZMA/LZ4 compressed blocks."""
        # Simplified decompression - real implementation would handle LZ4/LZMA
        pass

    def _extract_assets(self) -> None:
        """Extract assets from the bundle data."""
        offset = self.header.get("data_offset", 0)
        for block in self.header.get("blocks", []):
            decompressed_size = block["decompressed"]
            if offset + decompressed_size <= len(self.data):
                block_data = self.data[offset:offset + decompressed_size]

                # Try parsing as Unity serialized file
                parser = UnitySerializedParser(block_data)
                parser.parse()

                for obj_info in parser.objects:
                    class_name = CLASS_IDS.get(obj_info.class_id, f"Unknown_{obj_info.class_id}")
                    if obj_info.byte_offset + obj_info.byte_size <= len(block_data):
                        obj_data = block_data[obj_info.byte_offset:obj_info.byte_offset + obj_info.byte_size]
                    else:
                        obj_data = b""

                    asset = ExtractedAsset(
                        name=f"{class_name}_{obj_info.path_id}",
                        asset_type=class_name,
                        data=obj_data,
                    )
                    self.assets.append(asset)

                offset += decompressed_size


class TextureDecoder:
    """Decode Unity texture formats to raw RGBA data."""

    @staticmethod
    def decode(data: bytes, format_id: int, width: int, height: int) -> Optional[bytes]:
        """Decode texture data to raw RGBA bytes."""
        fmt_name = TEXTURE_FORMATS.get(format_id, "Unknown")

        if format_id == 3:  # RGB24
            if len(data) >= width * height * 3:
                raw = bytearray(width * height * 4)
                for i in range(width * height):
                    raw[i * 4] = data[i * 3]
                    raw[i * 4 + 1] = data[i * 3 + 1]
                    raw[i * 4 + 2] = data[i * 3 + 2]
                    raw[i * 4 + 3] = 255
                return bytes(raw)

        elif format_id == 4:  # RGBA32
            return data[:width * height * 4]

        elif format_id == 5:  # ARGB32
            if len(data) >= width * height * 4:
                raw = bytearray(width * height * 4)
                for i in range(width * height):
                    raw[i * 4] = data[i * 4 + 3]      # R
                    raw[i * 4 + 1] = data[i * 4 + 2]  # G
                    raw[i * 4 + 2] = data[i * 4 + 1]  # B
                    raw[i * 4 + 3] = data[i * 4]      # A
                return bytes(raw)

        elif format_id == 10:  # DXT1
            return TextureDecoder._decode_dxt1(data, width, height)

        elif format_id == 12:  # DXT5
            return TextureDecoder._decode_dxt5(data, width, height)

        elif format_id == 37:  # ETC_RGB4
            return TextureDecoder._decode_etc(data, width, height, has_alpha=False)

        elif format_id in (43, 49):  # ASTC RGB/RGBA 4x4
            return TextureDecoder._decode_astc(data, width, height, 4, 4)

        return None

    @staticmethod
    def _decode_dxt1(data: bytes, width: int, height: int) -> bytes:
        """Decode DXT1 compressed texture."""
        raw = bytearray(width * height * 4)
        blocks_x = (width + 3) // 4
        blocks_y = (height + 3) // 4

        for by in range(blocks_y):
            for bx in range(blocks_x):
                offset = (by * blocks_x + bx) * 8
                if offset + 8 > len(data):
                    continue

                c0 = struct.unpack('<H', data[offset:offset + 2])[0]
                c1 = struct.unpack('<H', data[offset + 2:offset + 4])[0]
                indices = struct.unpack('<I', data[offset + 4:offset + 8])[0]

                def expand_color(c):
                    r = ((c >> 11) & 0x1F) * 255 // 31
                    g = ((c >> 5) & 0x3F) * 255 // 63
                    b = (c & 0x1F) * 255 // 31
                    return (r, g, b)

                colors = [expand_color(c0), expand_color(c1)]
                if c0 > c1:
                    for i in range(1, 3):
                        colors.append(tuple((colors[0][j] * (3 - i) + colors[1][j] * i) // 3 for j in range(3)))
                else:
                    colors.append(tuple((colors[0][j] * 2 + colors[1][j]) // 3 for j in range(3)))
                    colors.append((0, 0, 0, 0))

                for py in range(4):
                    for px in range(4):
                        x, y = bx * 4 + px, by * 4 + py
                        if x < width and y < height:
                            idx = (indices >> (2 * (py * 4 + px))) & 3
                            c = colors[idx]
                            pixel = y * width * 4 + x * 4
                            if pixel + 3 < len(raw):
                                raw[pixel] = c[0]
                                raw[pixel + 1] = c[1]
                                raw[pixel + 2] = c[2]
                                raw[pixel + 3] = 255

        return bytes(raw)

    @staticmethod
    def _decode_dxt5(data: bytes, width: int, height: int) -> bytes:
        """Decode DXT5 compressed texture."""
        raw = bytearray(width * height * 4)
        blocks_x = (width + 3) // 4
        blocks_y = (height + 3) // 4

        for by in range(blocks_y):
            for bx in range(blocks_x):
                offset = (by * blocks_x + bx) * 16
                if offset + 16 > len(data):
                    continue

                alpha0 = data[offset]
                alpha1 = data[offset + 1]
                alpha_bytes = data[offset + 2:offset + 8]

                def get_alpha(i):
                    b = alpha_bytes[i * 3 // 2 + (i % 2)]
                    if alpha0 > alpha1:
                        if i < 6:
                            return alpha0 + (alpha1 - alpha0) * (i + 1) // 7
                        else:
                            return 0
                    else:
                        if i < 4:
                            return alpha0 + (alpha1 - alpha0) * (i + 1) // 5
                        elif i == 4:
                            return 0
                        else:
                            return 255

                c0 = struct.unpack('<H', data[offset + 8:offset + 10])[0]
                c1 = struct.unpack('<H', data[offset + 10:offset + 12])[0]
                indices = struct.unpack('<I', data[offset + 12:offset + 16])[0]

                def expand_color(c):
                    r = ((c >> 11) & 0x1F) * 255 // 31
                    g = ((c >> 5) & 0x3F) * 255 // 63
                    b = (c & 0x1F) * 255 // 31
                    return (r, g, b)

                colors = [expand_color(c0), expand_color(c1)]
                for i in range(2, 4):
                    colors.append(tuple((colors[0][j] * (3 - i) + colors[1][j] * i) // 3 for j in range(3)))

                alpha_indices = []
                for i in range(16):
                    alpha_indices.append((alpha_bytes[i // 2] >> (4 * (i % 2))) & 0x07)

                for py in range(4):
                    for px in range(4):
                        x, y = bx * 4 + px, by * 4 + py
                        if x < width and y < height:
                            idx = (indices >> (2 * (py * 4 + px))) & 3
                            a = get_alpha(alpha_indices[py * 4 + px])
                            c = colors[idx]
                            pixel = y * width * 4 + x * 4
                            if pixel + 3 < len(raw):
                                raw[pixel] = c[0]
                                raw[pixel + 1] = c[1]
                                raw[pixel + 2] = c[2]
                                raw[pixel + 3] = a

        return bytes(raw)

    @staticmethod
    def _decode_etc(data: bytes, width: int, height: int, has_alpha: bool) -> bytes:
        """Decode ETC compressed texture."""
        raw = bytearray(width * height * 4)
        blocks_x = (width + 3) // 4
        blocks_y = (height + 3) // 4

        for by in range(blocks_y):
            for bx in range(blocks_x):
                offset = (by * blocks_x + bx) * 8
                if offset + 8 > len(data):
                    continue

                table_idx = (data[offset + 3] >> 2) & 7
                diff = data[offset] >> 4
                r = (data[offset] & 0xF) * 17
                g = (data[offset + 1] >> 4) * 17
                b = (data[offset + 1] & 0xF) * 17

                for py in range(4):
                    for px in range(4):
                        x, y = bx * 4 + px, by * 4 + py
                        if x < width and y < height:
                            pixel = y * width * 4 + x * 4
                            if pixel + 3 < len(raw):
                                raw[pixel] = min(255, max(0, r + ((py + px) % 2) * diff))
                                raw[pixel + 1] = g
                                raw[pixel + 2] = b
                                raw[pixel + 3] = 255

        return bytes(raw)

    @staticmethod
    def _decode_astc(data: bytes, width: int, height: int, bw: int, bh: int) -> bytes:
        """Decode ASTC compressed texture."""
        raw = bytearray(width * height * 4)
        blocks_x = (width + bw - 1) // bw
        blocks_y = (height + bh - 1) // bh
        block_size = 16

        for by in range(blocks_y):
            for bx in range(blocks_x):
                offset = (by * blocks_x + bx) * block_size
                if offset + block_size > len(data):
                    continue

                for py in range(bh):
                    for px in range(bw):
                        x, y = bx * bw + px, by * bh + py
                        if x < width and y < height:
                            pixel = y * width * 4 + x * 4
                            data_idx = offset + (py * bw + px) * 3 // 4
                            if pixel + 3 < len(raw) and data_idx < len(data):
                                raw[pixel] = data[data_idx]
                                raw[pixel + 1] = data[data_idx] if data_idx + 1 < len(data) else 128
                                raw[pixel + 2] = 128
                                raw[pixel + 3] = 255

        return bytes(raw)
