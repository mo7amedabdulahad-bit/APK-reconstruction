"""IL2CPP global-metadata.dat parser."""
from __future__ import annotations

import struct
import zipfile
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger
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

logger = get_logger("metadata.parser")

METADATA_MAGIC = 0xAF1BB1FA
KNOWN_METADATA_PATHS = (
    "assets/bin/Data/Managed/Metadata/global-metadata.dat",
    "assets/bin/Data/global-metadata.dat",
)


class MetadataParser:
    """Parse IL2CPP global-metadata.dat binary files."""

    def parse(self, data: bytes) -> MetadataRecoveryResult:
        result = MetadataRecoveryResult()
        if len(data) < 8:
            result.errors.append("Metadata too small")
            return result

        magic = struct.unpack_from(">I", data, 0)[0]
        if magic != METADATA_MAGIC:
            result.errors.append(f"Invalid magic: 0x{magic:08X}")
            return result

        result.version = struct.unpack_from("<I", data, 4)[0]
        logger.info("Metadata version: %d", result.version)

        self._read_header_pairs(data, result)
        self._read_string_table(data, result)
        self._parse_type_definitions(data, result)
        self._parse_method_definitions(data, result)
        self._parse_field_definitions(data, result)
        self._parse_parameter_definitions(data, result)
        self._parse_property_definitions(data, result)
        self._parse_event_definitions(data, result)
        self._parse_image_definitions(data, result)
        self._resolve_names(result)

        logger.info("Recovered %d types, %d methods, %d fields, %d images",
                     result.total_types, result.total_methods,
                     result.total_fields, result.total_images)
        return result

    def parse_from_apk(self, apk_path: Path) -> MetadataRecoveryResult:
        try:
            with zipfile.ZipFile(str(apk_path), "r") as zf:
                for md_path in KNOWN_METADATA_PATHS:
                    if md_path in zf.namelist():
                        return self.parse(zf.read(md_path))
                for name in zf.namelist():
                    if name.endswith(".apk"):
                        try:
                            import tempfile, os
                            raw = zf.read(name)
                            tmp = os.path.join(tempfile.gettempdir(),
                                               f"il2cpp_md_{name.replace('/', '_')}")
                            with open(tmp, "wb") as f:
                                f.write(raw)
                            with zipfile.ZipFile(tmp, "r") as izf:
                                for md_path in KNOWN_METADATA_PATHS:
                                    if md_path in izf.namelist():
                                        return self.parse(izf.read(md_path))
                        except Exception:
                            continue
        except (zipfile.BadZipFile, OSError) as exc:
            r = MetadataRecoveryResult()
            r.errors.append(f"Failed to read APK: {exc}")
            return r
        r = MetadataRecoveryResult()
        r.errors.append("global-metadata.dat not found")
        return r

    # ── Header pairs ─────────────────────────────────────────────────

    def _read_header_pairs(self, data: bytes, result: MetadataRecoveryResult) -> None:
        result._header_pairs = []
        pos = 8
        for _ in range(40):
            if pos + 8 > len(data):
                break
            offset = struct.unpack_from("<I", data, pos)[0]
            count = struct.unpack_from("<I", data, pos + 4)[0]
            result._header_pairs.append((offset, count))
            pos += 8

    def _get_pair(self, result: MetadataRecoveryResult, idx: int) -> tuple[int, int]:
        if idx < len(result._header_pairs):
            return result._header_pairs[idx]
        return (0, 0)

    # ── String table ─────────────────────────────────────────────────

    def _read_string_table(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 1)
            if offset + count > len(data) or count == 0:
                return
            raw = data[offset:offset + count]
            current = bytearray()
            for b in raw:
                if b == 0:
                    if current:
                        result.strings.append(current.decode("utf-8", errors="replace"))
                        current = bytearray()
                else:
                    current.append(b)
            if current:
                result.strings.append(current.decode("utf-8", errors="replace"))
            logger.info("Read %d strings", len(result.strings))
        except Exception as exc:
            result.warnings.append(f"String table error: {exc}")

    def _get_string(self, result: MetadataRecoveryResult, index: int) -> str:
        if 0 <= index < len(result.strings):
            return result.strings[index]
        return ""

    # ── Type definitions ─────────────────────────────────────────────

    def _parse_type_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            struct_size = 72 if result.version >= 29 else 68
            for pair_idx in range(2, min(len(result._header_pairs), 8)):
                offset, count = self._get_pair(result, pair_idx)
                if count == 0 or offset == 0:
                    continue
                num = count // struct_size
                if num < 10 or num > 1_000_000:
                    continue
                for i in range(num):
                    pos = offset + i * struct_size
                    if pos + struct_size > len(data):
                        break
                    td = self._read_type_def(data, pos, i, struct_size)
                    result.type_definitions.append(td)
                if result.type_definitions:
                    logger.info("Parsed %d types from pair %d", len(result.type_definitions), pair_idx)
                    break
        except Exception as exc:
            result.warnings.append(f"Type def error: {exc}")

    def _read_type_def(self, data: bytes, pos: int, index: int, size: int) -> TypeDefinition:
        td = TypeDefinition(index=index)
        td.name_index = struct.unpack_from("<i", data, pos)[0]
        td.namespace_index = struct.unpack_from("<i", data, pos + 4)[0]
        td.byval_type_index = struct.unpack_from("<i", data, pos + 8)[0]
        td.declaring_type_index = struct.unpack_from("<i", data, pos + 12)[0]
        td.parent_index = struct.unpack_from("<i", data, pos + 16)[0]
        td.element_type_index = struct.unpack_from("<i", data, pos + 20)[0]
        td.field_start = struct.unpack_from("<i", data, pos + 24)[0]
        td.field_count = struct.unpack_from("<i", data, pos + 28)[0]
        td.method_start = struct.unpack_from("<i", data, pos + 32)[0]
        td.method_count = struct.unpack_from("<i", data, pos + 36)[0]
        td.event_start = struct.unpack_from("<i", data, pos + 40)[0]
        td.event_count = struct.unpack_from("<i", data, pos + 44)[0]
        td.property_start = struct.unpack_from("<i", data, pos + 48)[0]
        td.property_count = struct.unpack_from("<i", data, pos + 52)[0]
        td.nested_type_start = struct.unpack_from("<i", data, pos + 56)[0]
        td.nested_type_count = struct.unpack_from("<i", data, pos + 60)[0]
        td.vtable_start = struct.unpack_from("<i", data, pos + 64)[0]
        td.vtable_count = struct.unpack_from("<i", data, pos + 68)[0]
        if size >= 72:
            td.interfaces_start = struct.unpack_from("<i", data, pos + 72)[0]
            td.interfaces_count = struct.unpack_from("<i", data, pos + 76)[0] if size > 76 else 0
        td.bitfield = struct.unpack_from("<I", data, pos + 28 if size < 72 else pos + 80)[0] if size > 80 else 0
        td.token = struct.unpack_from("<I", data, pos + (size - 4))[0]
        return td

    # ── Method definitions ───────────────────────────────────────────

    def _parse_method_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 6)
            if count == 0 or offset == 0:
                return
            struct_size = 28 if result.version >= 29 else 24
            num = count // struct_size
            for i in range(min(num, 1_000_000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                md = MethodDefinition(index=i)
                md.name_index = struct.unpack_from("<i", data, pos)[0]
                md.declaring_type_index = struct.unpack_from("<i", data, pos + 4)[0]
                md.return_type_index = struct.unpack_from("<i", data, pos + 8)[0]
                md.parameter_start = struct.unpack_from("<i", data, pos + 12)[0]
                md.parameter_count = struct.unpack_from("<i", data, pos + 16)[0]
                md.generic_container_index = struct.unpack_from("<i", data, pos + 20)[0]
                md.token = struct.unpack_from("<I", data, pos + (struct_size - 4))[0]
                result.method_definitions.append(md)
            logger.info("Parsed %d methods", len(result.method_definitions))
        except Exception as exc:
            result.warnings.append(f"Method def error: {exc}")

    # ── Field definitions ────────────────────────────────────────────

    def _parse_field_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 8)
            if count == 0 or offset == 0:
                return
            struct_size = 12
            num = count // struct_size
            for i in range(min(num, 1_000_000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                fd = FieldDefinition(index=i)
                fd.name_index = struct.unpack_from("<i", data, pos)[0]
                fd.type_index = struct.unpack_from("<i", data, pos + 4)[0]
                fd.token = struct.unpack_from("<I", data, pos + 8)[0]
                result.field_definitions.append(fd)
            logger.info("Parsed %d fields", len(result.field_definitions))
        except Exception as exc:
            result.warnings.append(f"Field def error: {exc}")

    # ── Parameter definitions ────────────────────────────────────────

    def _parse_parameter_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 10)
            if count == 0 or offset == 0:
                return
            struct_size = 16
            num = count // struct_size
            for i in range(min(num, 1_000_000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                pd = ParameterDefinition(index=i)
                pd.name_index = struct.unpack_from("<i", data, pos)[0]
                pd.token = struct.unpack_from("<I", data, pos + 4)[0]
                pd.type_index = struct.unpack_from("<i", data, pos + 8)[0]
                result.parameter_definitions.append(pd)
            logger.info("Parsed %d parameters", len(result.parameter_definitions))
        except Exception as exc:
            result.warnings.append(f"Parameter def error: {exc}")

    # ── Property definitions ─────────────────────────────────────────

    def _parse_property_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 4)
            if count == 0 or offset == 0:
                return
            struct_size = 20
            num = count // struct_size
            for i in range(min(num, 1_000_000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                pd = PropertyDefinition(index=i)
                pd.name_index = struct.unpack_from("<i", data, pos)[0]
                pd.set_method_index = struct.unpack_from("<i", data, pos + 4)[0]
                pd.get_method_index = struct.unpack_from("<i", data, pos + 8)[0]
                pd.token = struct.unpack_from("<I", data, pos + 12)[0]
                result.property_definitions.append(pd)
            logger.info("Parsed %d properties", len(result.property_definitions))
        except Exception as exc:
            result.warnings.append(f"Property def error: {exc}")

    # ── Event definitions ────────────────────────────────────────────

    def _parse_event_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 3)
            if count == 0 or offset == 0:
                return
            struct_size = 20
            num = count // struct_size
            for i in range(min(num, 1_000_000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                ed = EventDefinition(index=i)
                ed.name_index = struct.unpack_from("<i", data, pos)[0]
                ed.add_method_index = struct.unpack_from("<i", data, pos + 4)[0]
                ed.remove_method_index = struct.unpack_from("<i", data, pos + 8)[0]
                ed.raise_method_index = struct.unpack_from("<i", data, pos + 12)[0]
                ed.token = struct.unpack_from("<I", data, pos + 16)[0]
                result.event_definitions.append(ed)
            logger.info("Parsed %d events", len(result.event_definitions))
        except Exception as exc:
            result.warnings.append(f"Event def error: {exc}")

    # ── Image definitions ────────────────────────────────────────────

    def _parse_image_definitions(self, data: bytes, result: MetadataRecoveryResult) -> None:
        try:
            offset, count = self._get_pair(result, 14)
            if count == 0 or offset == 0:
                return
            struct_size = 40 if result.version >= 29 else 36
            num = count // struct_size
            for i in range(min(num, 1000)):
                pos = offset + i * struct_size
                if pos + struct_size > len(data):
                    break
                img = ImageDefinition(index=i)
                img.name_index = struct.unpack_from("<i", data, pos)[0]
                img.assembly_index = struct.unpack_from("<i", data, pos + 4)[0]
                img.type_start = struct.unpack_from("<i", data, pos + 8)[0]
                img.type_count = struct.unpack_from("<i", data, pos + 12)[0]
                img.exported_type_start = struct.unpack_from("<i", data, pos + 16)[0]
                img.exported_type_count = struct.unpack_from("<i", data, pos + 20)[0]
                img.entry_point_index = struct.unpack_from("<i", data, pos + 24)[0]
                img.token = struct.unpack_from("<I", data, pos + (struct_size - 4))[0]
                result.image_definitions.append(img)
            logger.info("Parsed %d images", len(result.image_definitions))
        except Exception as exc:
            result.warnings.append(f"Image def error: {exc}")

    # ── Resolve names ────────────────────────────────────────────────

    def _resolve_names(self, result: MetadataRecoveryResult) -> None:
        for td in result.type_definitions:
            td.name = self._get_string(result, td.name_index)
            td.namespace = self._get_string(result, td.namespace_index)
        for md in result.method_definitions:
            md.name = self._get_string(result, md.name_index)
        for fd in result.field_definitions:
            fd.name = self._get_string(result, fd.name_index)
        for pd in result.parameter_definitions:
            pd.name = self._get_string(result, pd.name_index)
        for pd in result.property_definitions:
            pd.name = self._get_string(result, pd.name_index)
        for ed in result.event_definitions:
            ed.name = self._get_string(result, ed.name_index)
        for img in result.image_definitions:
            img.name = self._get_string(result, img.name_index)
