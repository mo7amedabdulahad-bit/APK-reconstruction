"""Binary utilities for AndroidManifest.xml parsing.

This module handles the low-level Android binary XML format used in
compiled AndroidManifest.xml files inside APKs.
"""
from __future__ import annotations

import struct
from typing import Any


class AndroidBinaryXMLParser:
    """Parser for Android compiled binary XML (AXML) format.

    Android compiles XML resources into a compact binary format.  This parser
    extracts string values, attribute data and namespace information so we can
    recover high-level manifest details such as package name, permissions and
    SDK versions.
    """

    CHUNK_TYPE_START_NAMESPACE = 0x0100
    CHUNK_TYPE_END_NAMESPACE = 0x0101
    CHUNK_TYPE_START_ELEMENT = 0x0102
    CHUNK_TYPE_END_ELEMENT = 0x0103
    CHUNK_TYPE_CDATA = 0x0104

    ATTRIBUTE_TYPE_STRING = 0x03

    def __init__(self, data: bytes) -> None:
        self._data = data
        self._strings: list[str] = []
        self._namespaces: dict[int, str] = {}
        self._attributes: dict[str, str] = {}
        self._current_element: str = ""
        self._xml_strings: list[str] = []
        self._parsed = False

    # ------------------------------------------------------------------
    # Public API
    # ------------------------------------------------------------------

    def parse(self) -> dict[str, Any]:
        """Parse the binary XML and return extracted data."""
        if self._parsed:
            return self._build_result()

        if len(self._data) < 8:
            return self._build_result()

        magic = struct.unpack_from("<H", self._data, 0)[0]
        if magic not in (0x0003, 0x0008):
            return self._build_result()

        self._parse_string_pool()
        self._parse_resource_ids()
        self._parse_xml_tree()
        self._parsed = True
        return self._build_result()

    # ------------------------------------------------------------------
    # Internal helpers
    # ------------------------------------------------------------------

    def _build_result(self) -> dict[str, Any]:
        return {
            "strings": list(self._xml_strings),
            "attributes": dict(self._attributes),
            "namespaces": dict(self._namespaces),
        }

    def _parse_string_pool(self) -> None:
        """Extract the UTF-16 string pool that precedes the XML tree."""
        if len(self._data) < 32:
            return
        offset = self._find_string_pool_start()
        if offset < 0:
            return
        try:
            chunk_type, chunk_size, string_count = struct.unpack_from("<HHI", self._data, offset)
            if chunk_type != 0x0001:
                return
            header_size = struct.unpack_from("<H", self._data, offset + 6)[0]
            strings_start_rel = struct.unpack_from("<I", self._data, offset + 8)[0]
            strings_start = offset + strings_start_rel
            str_offset = strings_start
            for _ in range(min(string_count, 10000)):
                if str_offset + 2 > len(self._data):
                    break
                char_count = struct.unpack_from("<H", self._data, str_offset)[0]
                str_offset += 2
                if char_count == 0:
                    self._xml_strings.append("")
                    continue
                byte_count = char_count * 2
                if str_offset + byte_count > len(self._data):
                    break
                raw = self._data[str_offset : str_offset + byte_count]
                try:
                    self._xml_strings.append(raw.decode("utf-16-le"))
                except Exception:
                    self._xml_strings.append("")
                str_offset += byte_count
                str_offset += (2 - (byte_count % 2)) % 2
        except struct.error:
            return

    def _find_string_pool_start(self) -> int:
        """Scan for the string pool chunk type in the first 512 bytes."""
        for i in range(0, min(512, len(self._data) - 4), 4):
            ct = struct.unpack_from("<H", self._data, i)[0]
            if ct == 0x0001:
                return i
        return -1

    def _parse_resource_ids(self) -> None:
        """Skip the resource-id mapping chunk."""
        pass

    def _parse_xml_tree(self) -> None:
        """Walk the XML element tree to extract attributes."""
        pos = 0
        while pos + 16 <= len(self._data):
            try:
                chunk_type, chunk_size = struct.unpack_from("<HH", self._data, pos)
            except struct.error:
                break

            if chunk_size < 16 or chunk_type == 0:
                break

            if chunk_type == self.CHUNK_TYPE_START_ELEMENT:
                self._parse_start_element(pos)

            pos += chunk_size
            if pos > len(self._data):
                break

    def _parse_start_element(self, pos: int) -> None:
        """Extract attributes from a ``START_ELEMENT`` chunk."""
        if pos + 36 > len(self._data):
            return
        try:
            line_number = struct.unpack_from("<I", self._data, pos + 16)[0]
            name_idx = struct.unpack_from("<I", self._data, pos + 28)[0]
            attr_count = struct.unpack_from("<H", self._data, pos + 34)[0]

            name = self._get_string(name_idx)
            self._current_element = name

            attr_pos = pos + 36
            for _ in range(attr_count):
                if attr_pos + 20 > len(self._data):
                    break
                ns_idx = struct.unpack_from("<i", self._data, attr_pos)[0]
                name_idx_a = struct.unpack_from("<i", self._data, attr_pos + 4)[0]
                value_idx = struct.unpack_from("<i", self._data, attr_pos + 8)[0]
                type_info = struct.unpack_from("<H", self._data, attr_pos + 14)[0]
                data_raw = struct.unpack_from("<i", self._data, attr_pos + 16)[0]

                attr_name = self._get_string(name_idx_a)
                if not attr_name:
                    attr_pos += 20
                    continue

                if type_info == self.ATTRIBUTE_TYPE_STRING:
                    value = self._get_string(data_raw)
                else:
                    value = str(data_raw)

                ns = self._get_string(ns_idx) if ns_idx >= 0 else ""
                key = f"{name}:{attr_name}" if name else attr_name
                self._attributes[key] = value
                self._attributes[attr_name] = value

                attr_pos += 20
        except struct.error:
            return

    def _get_string(self, idx: int) -> str:
        if 0 <= idx < len(self._xml_strings):
            return self._xml_strings[idx]
        return ""
