"""Tests for metadata recovery (Phase 4)."""
from __future__ import annotations

import json
import struct
import tempfile
import zipfile
from pathlib import Path

import pytest

from il2cpp_recovery_studio.metadata.parser import MetadataParser, METADATA_MAGIC
from il2cpp_recovery_studio.metadata.exporters import JSONExporter, XMLExporter
from il2cpp_recovery_studio.metadata.models import (
    EventDefinition,
    FieldDefinition,
    ImageDefinition,
    MetadataRecoveryResult,
    MethodDefinition,
    ParameterDefinition,
    PropertyDefinition,
    StringLiteral,
    TypeDefinition,
)


def _pack_type_def(name_idx: int = 0, ns_idx: int = 0, field_count: int = 0,
                   method_count: int = 0, event_count: int = 0,
                   property_count: int = 0) -> bytes:
    """Pack a single TypeDefinition (72 bytes for v29)."""
    return struct.pack("<iiiiiiiiiiiiiiiiii",
                       name_idx, ns_idx,
                       -1, -1, -1, -1,
                       0, field_count, 0, method_count,
                       0, event_count, 0, property_count,
                       0, 0, 0, 0)


def _pack_method_def(name_idx: int = 0, declaring_idx: int = 0) -> bytes:
    """Pack a single MethodDefinition (28 bytes for v29)."""
    return struct.pack("<iiiiiiI",
                       name_idx, declaring_idx, -1, 0, 0, -1, 0)


def _pack_field_def(name_idx: int = 0) -> bytes:
    """Pack a single FieldDefinition (12 bytes)."""
    return struct.pack("<iiI", name_idx, -1, 0)


def _pack_param_def(name_idx: int = 0) -> bytes:
    """Pack a single ParameterDefinition (16 bytes)."""
    return struct.pack("<iIiI", name_idx, 0, -1, 0)


def _pack_property_def(name_idx: int = 0) -> bytes:
    """Pack a single PropertyDefinition (20 bytes)."""
    return struct.pack("<iiiiI", name_idx, -1, -1, 0, 0)


def _pack_event_def(name_idx: int = 0) -> bytes:
    """Pack a single EventDefinition (20 bytes)."""
    return struct.pack("<iiiiI", name_idx, -1, -1, -1, 0)


def _pack_image_def(name_idx: int = 0) -> bytes:
    """Pack a single ImageDefinition (40 bytes for v29)."""
    return struct.pack("<iiiiiiiiIi",
                       name_idx, 0, 0, 0, 0, 0, 0, 0, 0, 0)


HEADER_SIZE = 8 + 40 * 8  # magic + version + 40 pairs


def _build_metadata(version: int = 29, strings: list[str] | None = None,
                    num_types: int = 3, num_methods: int = 2,
                    num_fields: int = 2, num_params: int = 2,
                    num_properties: int = 2, num_events: int = 1,
                    num_images: int = 2) -> bytes:
    """Build a minimal but valid global-metadata.dat for testing.

    The header pairs are:
      [0]  stringLiteral       - (0,0) unused
      [1]  stringLiteralData   - offset/count of the string table
      [2..7] typeDefinitions    - parser scans these; needs >= 10 entries
      [3]  events               (actually pair index 3 in parser)
      [4]  properties           (pair index 4 in parser)
      [6]  methods              (pair index 6)
      [8]  fields               (pair index 8)
      [10] parameters           (pair index 10)
      [14] images               (pair index 14)
    """
    if strings is None:
        strings = []

    # Build string table
    string_table = bytearray()
    string_offsets: list[int] = []
    for s in strings:
        string_offsets.append(len(string_table))
        string_table += s.encode("utf-8") + b"\x00"

    # Build all data sections and compute where they go in the file.
    # The parser uses name_index as a sequential string table index (0,1,2,...)
    # not a byte offset. So we map each string to its sequential index.
    seq_index = {s: i for i, s in enumerate(strings)}
    sections: list[tuple[int, bytearray]] = []
    data_area = bytearray()

    def _add(data: bytes) -> tuple[int, int]:
        nonlocal data_area
        data_area += data
        return (len(data_area) - len(data), len(data))

    # pair 0: stringLiteral (unused)
    sections.append((0, bytearray()))
    # pair 1: stringLiteralData
    sections.append((1, string_table))
    # pair 2: type definitions (need >= 10 for parser)
    actual_types = max(num_types, 10)
    type_data = bytearray()
    for i in range(actual_types):
        name_idx = i % len(strings) if strings else 0
        ns_idx = (i + len(strings) // 2) % len(strings) if strings and len(strings) > 1 else 0
        type_data += _pack_type_def(name_idx, ns_idx)
    sections.append((2, type_data))
    # pair 3: events
    event_data = bytearray()
    for i in range(num_events):
        name_idx = i % len(strings) if strings else 0
        event_data += _pack_event_def(name_idx)
    sections.append((3, event_data))
    # pair 4: properties
    prop_data = bytearray()
    for i in range(num_properties):
        name_idx = i % len(strings) if strings else 0
        prop_data += _pack_property_def(name_idx)
    sections.append((4, prop_data))
    # pair 5: unused
    sections.append((5, bytearray()))
    # pair 6: methods
    method_data = bytearray()
    for i in range(num_methods):
        name_idx = i % len(strings) if strings else 0
        method_data += _pack_method_def(name_idx, i)
    sections.append((6, method_data))
    # pair 7: unused
    sections.append((7, bytearray()))
    # pair 8: fields
    field_data = bytearray()
    for i in range(num_fields):
        name_idx = i % len(strings) if strings else 0
        field_data += _pack_field_def(name_idx)
    sections.append((8, field_data))
    # pairs 9: unused
    sections.append((9, bytearray()))
    # pair 10: parameters
    param_data = bytearray()
    for i in range(num_params):
        name_idx = i % len(strings) if strings else 0
        param_data += _pack_param_def(name_idx)
    sections.append((10, param_data))
    # pairs 11-13: unused
    for p in range(11, 14):
        sections.append((p, bytearray()))
    # pair 14: images
    img_data = bytearray()
    for i in range(num_images):
        name_idx = i % len(strings) if strings else 0
        img_data += _pack_image_def(name_idx)
    sections.append((14, img_data))
    # pairs 15-39: unused
    for p in range(15, 40):
        sections.append((p, bytearray()))

    # Now compute the final layout:
    # header comes first, then data_area
    # Offsets in pairs are file-relative (from start of file)
    data_area = bytearray()
    pairs: list[tuple[int, int]] = [(0, 0)] * 40

    for pair_idx, section_data in sections:
        if section_data:
            offset = HEADER_SIZE + len(data_area)
            pairs[pair_idx] = (offset, len(section_data))
            data_area += section_data

    # Build header
    header = bytearray()
    header += struct.pack(">I", METADATA_MAGIC)
    header += struct.pack("<I", version)
    for off, cnt in pairs:
        header += struct.pack("<II", off, cnt)

    return bytes(header + data_area)


# ── MetadataParser tests ─────────────────────────────────────────────


class TestMetadataParserModels:
    def test_type_definition_full_name(self):
        td = TypeDefinition(index=0, name="Player", namespace="Game")
        assert td.full_name == "Game.Player"

    def test_type_definition_full_name_no_ns(self):
        td = TypeDefinition(index=0, name="Player", namespace="")
        assert td.full_name == "Player"

    def test_type_definition_is_enum(self):
        td = TypeDefinition(index=0, bitfield=0x02)
        assert td.is_enum is True

    def test_type_definition_is_value_type(self):
        td = TypeDefinition(index=0, bitfield=0x01)
        assert td.is_value_type is True

    def test_method_is_static(self):
        md = MethodDefinition(index=0, flags=0x0010)
        assert md.is_static is True

    def test_method_is_abstract(self):
        md = MethodDefinition(index=0, flags=0x0400)
        assert md.is_abstract is True

    def test_method_is_generic(self):
        md = MethodDefinition(index=0, generic_container_index=5)
        assert md.is_generic is True

    def test_method_is_constructor(self):
        md = MethodDefinition(index=0, name=".ctor")
        assert md.is_constructor is True

    def test_method_not_constructor(self):
        md = MethodDefinition(index=0, name="DoStuff")
        assert md.is_constructor is False


class TestMetadataParserBasic:
    def test_parse_empty_data(self):
        parser = MetadataParser()
        result = parser.parse(b"")
        assert len(result.errors) > 0

    def test_parse_invalid_magic(self):
        parser = MetadataParser()
        result = parser.parse(b"\x00\x00\x00\x00" + b"\x00" * 100)
        assert any("Invalid magic" in e for e in result.errors)

    def test_parse_valid_header(self):
        data = _build_metadata(version=29)
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.version == 29
        assert not result.errors

    def test_parse_various_versions(self):
        for ver in [24, 27, 29]:
            data = _build_metadata(version=ver)
            parser = MetadataParser()
            result = parser.parse(data)
            assert result.version == ver

    def test_parse_strings(self):
        data = _build_metadata(version=29, strings=["Player", "Enemy", "GameManager", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert len(result.strings) >= 6

    def test_parse_type_definitions(self):
        data = _build_metadata(version=29, strings=["Player", "Enemy", "GameManager", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.total_types >= 10

    def test_parse_method_definitions(self):
        data = _build_metadata(version=29, strings=["Start", "Update", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.total_methods == 2

    def test_parse_field_definitions(self):
        data = _build_metadata(version=29, strings=["health", "speed", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.total_fields == 2

    def test_parse_parameter_definitions(self):
        data = _build_metadata(version=29, strings=["amount", "target", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert len(result.parameter_definitions) == 2

    def test_parse_property_definitions(self):
        data = _build_metadata(version=29, strings=["Name", "Health", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert len(result.property_definitions) == 2

    def test_parse_event_definitions(self):
        data = _build_metadata(version=29, strings=["OnDeath", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert len(result.event_definitions) == 1

    def test_parse_image_definitions(self):
        data = _build_metadata(version=29, strings=["Assembly-CSharp.dll", "mscorlib.dll", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.total_images == 2

    def test_resolve_type_names(self):
        data = _build_metadata(version=29, strings=["Player", "Enemy", "GameManager", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.type_definitions[0].name == "Player"
        assert result.type_definitions[1].name == "Enemy"

    def test_resolve_method_names(self):
        data = _build_metadata(version=29, strings=["Start", "Update", "Player", "Enemy", "Game", "Logic", "Core"])
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.method_definitions[0].name == "Start"
        assert result.method_definitions[1].name == "Update"


class TestMetadataParserFromAPK:
    def test_parse_from_apk_with_metadata(self, tmp_path):
        metadata = _build_metadata(version=29, strings=["Test"])
        apk_path = tmp_path / "test.apk"
        with zipfile.ZipFile(str(apk_path), "w") as zf:
            zf.writestr(
                "assets/bin/Data/Managed/Metadata/global-metadata.dat",
                metadata,
            )
            zf.writestr("AndroidManifest.xml", b"\x00")

        parser = MetadataParser()
        result = parser.parse_from_apk(apk_path)
        assert result.version == 29

    def test_parse_from_xapk_with_inner_apk(self, tmp_path):
        metadata = _build_metadata(version=29, strings=["XAPKTest"])

        inner_apk_buf = bytearray()
        with zipfile.ZipFile(
            tmp_path / "inner.apk", "w"
        ) as izf:
            izf.writestr(
                "assets/bin/Data/Managed/Metadata/global-metadata.dat",
                metadata,
            )

        xapk_path = tmp_path / "test.xapk"
        with zipfile.ZipFile(str(xapk_path), "w") as xzf:
            with open(tmp_path / "inner.apk", "rb") as f:
                xzf.writestr("base.apk", f.read())

        parser = MetadataParser()
        result = parser.parse_from_apk(xapk_path)
        assert result.version == 29

    def test_parse_from_apk_no_metadata(self, tmp_path):
        apk_path = tmp_path / "no_metadata.apk"
        with zipfile.ZipFile(str(apk_path), "w") as zf:
            zf.writestr("AndroidManifest.xml", b"\x00")

        parser = MetadataParser()
        result = parser.parse_from_apk(apk_path)
        assert any("not found" in e.lower() for e in result.errors)

    def test_parse_from_nonexistent_apk(self):
        parser = MetadataParser()
        result = parser.parse_from_apk(Path("/nonexistent/path.apk"))
        assert len(result.errors) > 0

    def test_parse_from_corrupted_apk(self, tmp_path):
        apk_path = tmp_path / "corrupt.apk"
        apk_path.write_bytes(b"not a zip file")
        parser = MetadataParser()
        result = parser.parse_from_apk(apk_path)
        assert len(result.errors) > 0


# ── JSON Exporter tests ──────────────────────────────────────────────


class TestJSONExporter:
    def _make_result(self) -> MetadataRecoveryResult:
        r = MetadataRecoveryResult(version=29)
        r.strings = ["Test", "Player"]
        r.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game", field_count=3, method_count=2)
        ]
        r.method_definitions = [
            MethodDefinition(index=0, name="Start", parameter_count=0, flags=0),
            MethodDefinition(index=1, name=".ctor", parameter_count=0, flags=0),
        ]
        r.field_definitions = [FieldDefinition(index=0, name="health")]
        r.image_definitions = [ImageDefinition(index=0, name="Assembly-CSharp.dll")]
        return r

    def test_export_creates_file(self, tmp_path):
        result = self._make_result()
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        assert out.exists()

    def test_export_valid_json(self, tmp_path):
        result = self._make_result()
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        data = json.loads(out.read_text(encoding="utf-8"))
        assert data["version"] == 29

    def test_export_statistics(self, tmp_path):
        result = self._make_result()
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        data = json.loads(out.read_text(encoding="utf-8"))
        stats = data["statistics"]
        assert stats["total_types"] == 1
        assert stats["total_methods"] == 2
        assert stats["total_fields"] == 1
        assert stats["total_images"] == 1

    def test_export_types_content(self, tmp_path):
        result = self._make_result()
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        data = json.loads(out.read_text(encoding="utf-8"))
        t = data["types"][0]
        assert t["name"] == "Player"
        assert t["namespace"] == "Game"
        assert t["full_name"] == "Game.Player"
        assert t["field_count"] == 3

    def test_export_methods_content(self, tmp_path):
        result = self._make_result()
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        data = json.loads(out.read_text(encoding="utf-8"))
        m = data["methods"][0]
        assert m["name"] == "Start"
        assert m["is_constructor"] is False
        assert data["methods"][1]["is_constructor"] is True

    def test_export_empty_result(self, tmp_path):
        result = MetadataRecoveryResult(version=24)
        exporter = JSONExporter()
        out = exporter.export(result, tmp_path / "out.json")
        data = json.loads(out.read_text(encoding="utf-8"))
        assert data["statistics"]["total_types"] == 0


# ── XML Exporter tests ───────────────────────────────────────────────


class TestXMLExporter:
    def _make_result(self) -> MetadataRecoveryResult:
        r = MetadataRecoveryResult(version=29)
        r.type_definitions = [
            TypeDefinition(index=0, name="Player", namespace="Game")
        ]
        r.method_definitions = [MethodDefinition(index=0, name="Start")]
        r.field_definitions = [FieldDefinition(index=0, name="health")]
        return r

    def test_export_creates_file(self, tmp_path):
        result = self._make_result()
        exporter = XMLExporter()
        out = exporter.export(result, tmp_path / "out.xml")
        assert out.exists()

    def test_export_valid_xml(self, tmp_path):
        import xml.etree.ElementTree as ET

        result = self._make_result()
        exporter = XMLExporter()
        out = exporter.export(result, tmp_path / "out.xml")
        tree = ET.parse(str(out))
        root = tree.getroot()
        assert root.tag == "MetadataRecovery"
        assert root.get("version") == "29"

    def test_export_statistics_element(self, tmp_path):
        import xml.etree.ElementTree as ET

        result = self._make_result()
        exporter = XMLExporter()
        out = exporter.export(result, tmp_path / "out.xml")
        tree = ET.parse(str(out))
        stats = tree.find(".//Statistics")
        assert stats is not None
        assert stats.get("types") == "1"
        assert stats.get("methods") == "1"

    def test_export_types_element(self, tmp_path):
        import xml.etree.ElementTree as ET

        result = self._make_result()
        exporter = XMLExporter()
        out = exporter.export(result, tmp_path / "out.xml")
        tree = ET.parse(str(out))
        types_el = tree.find(".//Types")
        assert types_el is not None
        t = types_el.find("Type")
        assert t.get("name") == "Player"

    def test_export_empty_result(self, tmp_path):
        result = MetadataRecoveryResult(version=24)
        exporter = XMLExporter()
        out = exporter.export(result, tmp_path / "out.xml")
        assert out.exists()


# ── Integration tests ────────────────────────────────────────────────


class TestMetadataRecoveryResultModel:
    def test_statistics(self):
        r = MetadataRecoveryResult()
        r.type_definitions = [TypeDefinition(index=i) for i in range(10)]
        r.method_definitions = [MethodDefinition(index=i) for i in range(50)]
        r.field_definitions = [FieldDefinition(index=i) for i in range(20)]
        r.image_definitions = [ImageDefinition(index=i) for i in range(3)]
        assert r.total_types == 10
        assert r.total_methods == 50
        assert r.total_fields == 20
        assert r.total_images == 3

    def test_empty_statistics(self):
        r = MetadataRecoveryResult()
        assert r.total_types == 0
        assert r.total_methods == 0
        assert r.total_fields == 0
        assert r.total_images == 0


class TestEndToEndMetadataRecovery:
    def test_full_pipeline(self, tmp_path):
        data = _build_metadata(
            version=29,
            strings=[
                "Player", "Enemy", "GameManager",
                "Start", "Update", "Attack",
                "health", "speed",
                "amount", "target",
                "Name", "Level",
                "OnDeath",
                "Assembly-CSharp.dll", "mscorlib.dll",
                "Game", "Logic", "Core", "UI", "Net", "Data",
            ],
        )
        parser = MetadataParser()
        result = parser.parse(data)
        assert result.version == 29
        assert result.total_types >= 10
        assert result.total_methods == 2
        assert result.total_fields == 2
        assert len(result.parameter_definitions) == 2
        assert len(result.property_definitions) == 2
        assert len(result.event_definitions) == 1
        assert result.total_images == 2

        json_out = tmp_path / "meta.json"
        jexp = JSONExporter()
        jexp.export(result, json_out)
        jdata = json.loads(json_out.read_text(encoding="utf-8"))
        assert jdata["version"] == 29
        assert jdata["statistics"]["total_types"] >= 10

        xml_out = tmp_path / "meta.xml"
        xexp = XMLExporter()
        xexp.export(result, xml_out)
        assert xml_out.exists()
