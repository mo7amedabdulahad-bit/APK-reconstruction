"""JSON and XML exporters for recovered metadata."""
from __future__ import annotations

import json
import xml.etree.ElementTree as ET
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.metadata.models import MetadataRecoveryResult

logger = get_logger("metadata.exporters")


class JSONExporter:
    """Export recovered metadata to JSON."""

    def export(self, result: MetadataRecoveryResult, output_path: Path) -> Path:
        data = {
            "version": result.version,
            "statistics": {
                "total_types": result.total_types,
                "total_methods": result.total_methods,
                "total_fields": result.total_fields,
                "total_parameters": len(result.parameter_definitions),
                "total_properties": len(result.property_definitions),
                "total_events": len(result.event_definitions),
                "total_images": result.total_images,
                "total_strings": len(result.strings),
            },
            "images": [
                {
                    "name": img.name,
                    "type_start": img.type_start,
                    "type_count": img.type_count,
                    "token": img.token,
                }
                for img in result.image_definitions
            ],
            "types": [
                {
                    "index": td.index,
                    "name": td.name,
                    "namespace": td.namespace,
                    "full_name": td.full_name,
                    "is_enum": td.is_enum,
                    "is_value_type": td.is_value_type,
                    "field_count": td.field_count,
                    "method_count": td.method_count,
                    "property_count": td.property_count,
                    "event_count": td.event_count,
                    "nested_type_count": td.nested_type_count,
                    "interface_count": td.interface_count,
                    "parent_index": td.parent_index,
                    "token": td.token,
                }
                for td in result.type_definitions
            ],
            "methods": [
                {
                    "index": md.index,
                    "name": md.name,
                    "declaring_type_index": md.declaring_type_index,
                    "return_type_index": md.return_type_index,
                    "parameter_count": md.parameter_count,
                    "is_static": md.is_static,
                    "is_abstract": md.is_abstract,
                    "is_constructor": md.is_constructor,
                    "token": md.token,
                }
                for md in result.method_definitions
            ],
            "fields": [
                {
                    "index": fd.index,
                    "name": fd.name,
                    "type_index": fd.type_index,
                    "token": fd.token,
                }
                for fd in result.field_definitions
            ],
            "parameters": [
                {
                    "index": pd.index,
                    "name": pd.name,
                    "type_index": pd.type_index,
                    "token": pd.token,
                }
                for pd in result.parameter_definitions
            ],
            "properties": [
                {
                    "index": pr.index,
                    "name": pr.name,
                    "get_method_index": pr.get_method_index,
                    "set_method_index": pr.set_method_index,
                    "token": pr.token,
                }
                for pr in result.property_definitions
            ],
            "events": [
                {
                    "index": ev.index,
                    "name": ev.name,
                    "token": ev.token,
                }
                for ev in result.event_definitions
            ],
        }

        output_path.parent.mkdir(parents=True, exist_ok=True)
        output_path.write_text(json.dumps(data, indent=2, ensure_ascii=False), encoding="utf-8")
        logger.info("JSON exported to %s", output_path)
        return output_path


class XMLExporter:
    """Export recovered metadata to XML."""

    def export(self, result: MetadataRecoveryResult, output_path: Path) -> Path:
        root = ET.Element("MetadataRecovery")
        root.set("version", str(result.version))

        stats = ET.SubElement(root, "Statistics")
        stats.set("types", str(result.total_types))
        stats.set("methods", str(result.total_methods))
        stats.set("fields", str(result.total_fields))
        stats.set("parameters", str(len(result.parameter_definitions)))
        stats.set("properties", str(len(result.property_definitions)))
        stats.set("events", str(len(result.event_definitions)))
        stats.set("images", str(result.total_images))

        images_el = ET.SubElement(root, "Images")
        for img in result.image_definitions:
            el = ET.SubElement(images_el, "Image")
            el.set("name", img.name)
            el.set("type_start", str(img.type_start))
            el.set("type_count", str(img.type_count))

        types_el = ET.SubElement(root, "Types")
        for td in result.type_definitions:
            el = ET.SubElement(types_el, "Type")
            el.set("name", td.name)
            el.set("namespace", td.namespace)
            el.set("full_name", td.full_name)
            el.set("is_enum", str(td.is_enum))
            el.set("methods", str(td.method_count))
            el.set("fields", str(td.field_count))

        methods_el = ET.SubElement(root, "Methods")
        for md in result.method_definitions:
            el = ET.SubElement(methods_el, "Method")
            el.set("name", md.name)
            el.set("declaring_type_index", str(md.declaring_type_index))
            el.set("parameter_count", str(md.parameter_count))
            el.set("is_static", str(md.is_static))
            el.set("is_constructor", str(md.is_constructor))

        fields_el = ET.SubElement(root, "Fields")
        for fd in result.field_definitions:
            el = ET.SubElement(fields_el, "Field")
            el.set("name", fd.name)
            el.set("type_index", str(fd.type_index))

        tree = ET.ElementTree(root)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        tree.write(str(output_path), encoding="unicode", xml_declaration=True)
        logger.info("XML exported to %s", output_path)
        return output_path
