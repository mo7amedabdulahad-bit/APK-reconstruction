"""dynamic_text_extractor.py — Recover dynamic UI strings from IL2CPP metadata.

Phase 7: ``extract_dynamic_ui_strings(metadata_path)`` reads the raw
``global-metadata.dat`` bytes (no UnityPy — it is a flat binary, not a
Unity asset) and recovers the string literals the game compiled in.

IL2CPP stores user string literals as UTF-16LE runs inside the metadata
blob.  We scan the raw bytes for printable UTF-16LE runs, then group each
literal under the IL2CPP class (``TypeDefinition``) whose definition
precedes it in the file — giving a ``dict[class_name, list[str]]``.

The consumer (``ai_ui_compiler``) uses this to inject recovered text into
scenes whose UI dump captured no Text components.
"""
from __future__ import annotations

import struct
from pathlib import Path
from typing import Dict, List

METADATA_MAGIC = 0xAF1BB1FA

# Tight printable set: ASCII + common Latin-1 + a few punctuation/symbols.
# Kept narrow on purpose — a broad set produces garbage from random binary.
_PRINTABLE = set(chr(c) for c in range(0x20, 0x7F))
_PRINTABLE |= set(
    "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞß"
    "àáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿ"
    "€£¥©®™°±×÷–—‘’“”…•"
)


def _scan_utf16_strings(data: bytes, min_len: int = 4) -> List[tuple[int, str]]:
    """Yield ``(byte_offset, text)`` for each printable UTF-16LE run.

    Walks the bytes two-at-a-time interpreting each pair as a UTF-16LE code
    unit.  Runs shorter than ``min_len`` are discarded to suppress noise.
    """
    out: List[tuple[int, str]] = []
    current: List[str] = []
    start = -1
    n = len(data)
    i = 0
    while i + 1 < n:
        code = data[i] | (data[i + 1] << 8)
        ch = chr(code) if code < 0x10000 else "�"
        if ch in _PRINTABLE:
            if not current:
                start = i
            current.append(ch)
        else:
            if len(current) >= min_len:
                out.append((start, "".join(current)))
            current = []
        i += 2
    if len(current) >= min_len:
        out.append((start, "".join(current)))
    return out


def _read_header_pairs(data: bytes) -> List[tuple[int, int]]:
    """Return the 40 ``(offset, count)`` pairs that start at byte 8."""
    pairs: List[tuple[int, int]] = []
    pos = 8
    for _ in range(40):
        if pos + 8 > len(data):
            break
        off = struct.unpack_from("<I", data, pos)[0]
        cnt = struct.unpack_from("<I", data, pos + 4)[0]
        pairs.append((off, cnt))
        pos += 8
    return pairs


def _read_string_heap(data: bytes, pairs: List[tuple[int, int]]) -> List[str]:
    """Read the UTF-8 null-separated string heap (header pair index 1)."""
    if len(pairs) <= 1:
        return []
    offset, count = pairs[1]
    if offset == 0 or count == 0 or offset + count > len(data):
        return []
    raw = data[offset:offset + count]
    strings: List[str] = []
    buf = bytearray()
    for b in raw:
        if b == 0:
            if buf:
                strings.append(buf.decode("utf-8", errors="replace"))
                buf = bytearray()
        else:
            buf.append(b)
    if buf:
        strings.append(buf.decode("utf-8", errors="replace"))
    return strings


def _read_type_defs(
    data: bytes, pairs: List[tuple[int, int]], strings: List[str], version: int
) -> List[tuple[int, str]]:
    """Recover ``(definition_offset, class_name)`` from the type table.

    The type table lives at header pair index 2.  Returns entries sorted by
    offset so literals can be attributed to the nearest preceding class.
    """
    if len(pairs) <= 2:
        return []
    offset, count = pairs[2]
    if offset == 0 or count == 0:
        return []
    struct_size = 72 if version >= 29 else 68
    num = count // struct_size
    if num < 1 or num > 2_000_000:
        return []

    defs: List[tuple[int, str]] = []
    for i in range(num):
        pos = offset + i * struct_size
        if pos + struct_size > len(data):
            break
        name_index = struct.unpack_from("<i", data, pos)[0]
        name = strings[name_index] if 0 <= name_index < len(strings) else ""
        if name:
            defs.append((pos, name))
    defs.sort(key=lambda t: t[0])
    return defs


def extract_dynamic_ui_strings(metadata_path) -> Dict[str, List[str]]:
    """Scan an IL2CPP ``global-metadata.dat`` and return UI strings by class.

    Args:
        metadata_path: Path to ``global-metadata.dat``.

    Returns:
        ``{class_name: [string, ...]}``.  A synthetic ``"__global__"`` key
        holds every recovered literal so callers without a class match can
        still use the full recovered set.  Empty dict on any failure.
    """
    result: Dict[str, List[str]] = {}
    try:
        data = Path(metadata_path).read_bytes()
    except Exception:
        return result

    if len(data) < 12:
        return result

    magic = struct.unpack_from(">I", data, 0)[0]
    if magic != METADATA_MAGIC:
        return result
    version = struct.unpack_from("<I", data, 4)[0]

    pairs = _read_header_pairs(data)
    strings = _read_string_heap(data, pairs)
    type_defs = _read_type_defs(data, pairs, strings, version)

    literals = _scan_utf16_strings(data, min_len=4)
    if not literals:
        return result

    # All literals, de-duplicated, available under a global fallback key.
    global_seen: set[str] = set()
    global_list: List[str] = []
    for _off, text in literals:
        if text not in global_seen:
            global_seen.add(text)
            global_list.append(text)
    result["__global__"] = global_list

    # Best-effort per-class attribution: each literal goes to the nearest
    # preceding type definition by byte offset.
    if type_defs:
        def_offsets = [t[0] for t in type_defs]
        import bisect
        for off, text in literals:
            idx = bisect.bisect_right(def_offsets, off) - 1
            if idx >= 0:
                class_name = type_defs[idx][1]
                bucket = result.setdefault(class_name, [])
                if text not in bucket:
                    bucket.append(text)

    return result
