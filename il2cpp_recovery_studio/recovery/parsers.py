"""Output parsers for recovery tools.

Each parser reads the output directory/files produced by a tool and
returns structured data suitable for merging into the recovery database.
"""
from __future__ import annotations

import csv
import json
import re
from pathlib import Path
from typing import Optional

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.recovery.models import (
    RecoveredClass,
    RecoveredEnum,
    RecoveredField,
    RecoveredMethod,
    RecoveredParameter,
    RecoveredProperty,
)

logger = get_logger("recovery.parsers")


def _safe_int(value: object, default: int = 0) -> int:
    """Safely convert a value to int, handling hex strings."""
    if isinstance(value, int):
        return value
    if isinstance(value, str):
        value = value.strip()
        if not value:
            return default
        try:
            return int(value, 0)  # auto-detect base (0x prefix → hex)
        except (ValueError, TypeError):
            return default
    return default


class Cpp2ILParser:
    """Parse Cpp2IL output (C# stub files + type definitions).

    Cpp2IL generates:
    - C# dummy DLLs or stubs
    - JSON / YAML type maps
    - Function pointer lists
    """

    NAME = "Cpp2IL"

    def parse(self, output_dir: Path) -> list[RecoveredClass]:
        """Parse Cpp2IL output directory."""
        classes: list[RecoveredClass] = []
        if not output_dir.is_dir():
            logger.warning("Cpp2IL output dir not found: %s", output_dir)
            return classes

        # Look for JSON type maps
        for json_file in output_dir.rglob("*.json"):
            try:
                data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                classes.extend(self._parse_json_type_map(data))
            except (json.JSONDecodeError, OSError) as exc:
                logger.debug("Failed to parse %s: %s", json_file, exc)

        # Look for C# stub files
        for cs_file in output_dir.rglob("*.cs"):
            try:
                classes.extend(self._parse_csharp_stub(cs_file))
            except Exception as exc:
                logger.debug("Failed to parse %s: %s", cs_file, exc)

        # Look for CSV function lists
        for csv_file in output_dir.rglob("*.csv"):
            try:
                classes.extend(self._parse_csv_functions(csv_file))
            except Exception as exc:
                logger.debug("Failed to parse %s: %s", csv_file, exc)

        logger.info("Cpp2IL: recovered %d classes from %s", len(classes), output_dir)
        return classes

    def _parse_json_type_map(self, data: dict) -> list[RecoveredClass]:
        classes = []
        if isinstance(data, dict) and "Types" in data:
            for type_entry in data["Types"]:
                cls = self._type_entry_to_class(type_entry)
                if cls:
                    classes.append(cls)
        elif isinstance(data, list):
            for item in data:
                if isinstance(item, dict):
                    cls = self._type_entry_to_class(item)
                    if cls:
                        classes.append(cls)
        return classes

    def _type_entry_to_class(self, entry: dict) -> Optional[RecoveredClass]:
        name = entry.get("Name", entry.get("name", ""))
        if not name:
            return None
        ns = entry.get("Namespace", entry.get("namespace", ""))
        methods = []
        for m in entry.get("Methods", entry.get("methods", [])):
            method = RecoveredMethod(
                name=m.get("Name", m.get("name", "")),
                native_address=_safe_int(m.get("Address", m.get("address", 0))),
                token=_safe_int(m.get("Token", m.get("token", 0))),
                declaring_class=f"{ns}.{name}" if ns else name,
                confidence=0.8,
            )
            methods.append(method)

        fields = []
        for f in entry.get("Fields", entry.get("fields", [])):
            field = RecoveredField(
                name=f.get("Name", f.get("name", "")),
                type_name=f.get("Type", f.get("type", "")),
                offset=_safe_int(f.get("Offset", f.get("offset", 0))),
                declaring_class=f"{ns}.{name}" if ns else name,
            )
            fields.append(field)

        return RecoveredClass(
            name=name,
            namespace=ns,
            full_name=f"{ns}.{name}" if ns else name,
            parent_class=entry.get("Parent", entry.get("parent", "")),
            fields=fields,
            methods=methods,
            source_tool=self.NAME,
            confidence=0.8,
        )

    def _parse_csharp_stub(self, path: Path) -> list[RecoveredClass]:
        classes = []
        content = path.read_text(encoding="utf-8", errors="replace")
        # Simple regex to find class declarations
        class_pattern = re.compile(
            r"(?:public\s+)?(?:partial\s+)?(?:class|struct|interface|enum)\s+(\w+)"
        )
        for match in class_pattern.finditer(content):
            cls_name = match.group(1)
            cls = RecoveredClass(
                name=cls_name,
                full_name=cls_name,
                source_tool=self.NAME,
                confidence=0.6,
            )
            classes.append(cls)
        return classes

    def _parse_csv_functions(self, path: Path) -> list[RecoveredClass]:
        classes = []
        try:
            with open(path, "r", encoding="utf-8", errors="replace") as f:
                reader = csv.DictReader(f)
                methods_by_class: dict[str, list[RecoveredMethod]] = {}
                for row in reader:
                    addr = int(row.get("Address", row.get("address", "0")) or "0", 0)
                    name = row.get("Name", row.get("name", ""))
                    if not name:
                        continue
                    # Try to extract class from name (Class::Method pattern)
                    parts = name.split("::")
                    if len(parts) == 2:
                        cls_name, method_name = parts
                    else:
                        cls_name = path.stem
                        method_name = name

                    method = RecoveredMethod(
                        name=method_name,
                        native_address=addr,
                        declaring_class=cls_name,
                        confidence=0.7,
                    )
                    methods_by_class.setdefault(cls_name, []).append(method)

                for cls_name, methods in methods_by_class.items():
                    classes.append(RecoveredClass(
                        name=cls_name,
                        full_name=cls_name,
                        methods=methods,
                        source_tool=self.NAME,
                        confidence=0.7,
                    ))
        except Exception as exc:
            logger.debug("CSV parse error: %s", exc)
        return classes


class Il2CppDumperParser:
    """Parse Il2CppDumper output (dump.cs, script.json, etc.).

    Il2CppDumper generates:
    - dump.cs: C# type/method/field declarations with native addresses
    - script.json: structured JSON with all type information
    - methodPointers.json: method address mapping
    """

    NAME = "Il2CppDumper"

    def parse(self, output_dir: Path) -> list[RecoveredClass]:
        classes: list[RecoveredClass] = []
        if not output_dir.is_dir():
            logger.warning("Il2CppDumper output dir not found: %s", output_dir)
            return classes

        # Parse script.json (primary structured output)
        script_json = output_dir / "script.json"
        if script_json.exists():
            classes.extend(self._parse_script_json(script_json))

        # Parse dump.cs (human-readable dump)
        dump_cs = output_dir / "dump.cs"
        if dump_cs.exists():
            classes.extend(self._parse_dump_cs(dump_cs))

        # Parse methodPointers.json
        mp_json = output_dir / "methodPointers.json"
        if mp_json.exists():
            self._annotate_method_pointers(classes, mp_json)

        logger.info("Il2CppDumper: recovered %d classes from %s", len(classes), output_dir)
        return classes

    def _parse_script_json(self, path: Path) -> list[RecoveredClass]:
        classes = []
        try:
            data = json.loads(path.read_text(encoding="utf-8", errors="replace"))
            if not isinstance(data, list):
                return classes
            for type_entry in data:
                cls = self._parse_script_type(type_entry)
                if cls:
                    classes.append(cls)
        except (json.JSONDecodeError, OSError) as exc:
            logger.debug("Failed to parse script.json: %s", exc)
        return classes

    def _parse_script_type(self, entry: dict) -> Optional[RecoveredClass]:
        name = entry.get("TypeName", entry.get("Name", ""))
        if not name:
            return None

        ns = entry.get("Namespace", "")
        methods = []
        for m in entry.get("Methods", []):
            params = []
            for p in m.get("Parameters", []):
                params.append(RecoveredParameter(
                    name=p.get("Name", ""),
                    type_name=p.get("TypeName", p.get("Type", "")),
                    position=p.get("Position", 0),
                ))
            method = RecoveredMethod(
                name=m.get("MethodName", m.get("Name", "")),
                return_type=m.get("ReturnType", ""),
                parameters=params,
                native_address=_safe_int(m.get("MethodAddress", m.get("Address", 0))),
                token=_safe_int(m.get("Token", 0)),
                declaring_class=f"{ns}.{name}" if ns else name,
                is_static=m.get("IsStatic", False),
                is_generic=m.get("IsGeneric", False),
                confidence=0.9,
            )
            methods.append(method)

        fields = []
        for f in entry.get("Fields", []):
            field = RecoveredField(
                name=f.get("FieldName", f.get("Name", "")),
                type_name=f.get("Type", ""),
                offset=_safe_int(f.get("Offset", 0)),
                is_static=f.get("IsStatic", False),
                declaring_class=f"{ns}.{name}" if ns else name,
                confidence=0.9,
            )
            fields.append(field)

        return RecoveredClass(
            name=name,
            namespace=ns,
            full_name=f"{ns}.{name}" if ns else name,
            parent_class=entry.get("ParentType", ""),
            fields=fields,
            methods=methods,
            is_interface=entry.get("IsInterface", False),
            is_enum=entry.get("IsEnum", False),
            is_abstract=entry.get("IsAbstract", False),
            is_sealed=entry.get("IsSealed", False),
            is_struct=entry.get("IsValueType", False),
            token=_safe_int(entry.get("TypeIndex", 0)),
            source_tool=self.NAME,
            confidence=0.9,
        )

    def _parse_dump_cs(self, path: Path) -> list[RecoveredClass]:
        classes = []
        try:
            content = path.read_text(encoding="utf-8", errors="replace")
            current_class: Optional[RecoveredClass] = None

            for line in content.splitlines():
                stripped = line.strip()

                # Class/struct declaration
                m = re.match(
                    r"// (?: RVA: )?(0x[0-9a-fA-F]+)?\s*",
                    stripped,
                )

                class_match = re.match(
                    r"(?:public\s+)?(?:internal\s+)?(?:sealed\s+)?(?:abstract\s+)?"
                    r"(?:partial\s+)?(?:class|struct)\s+(\w+)(?:\s*:\s*(.+))?",
                    stripped,
                )
                if class_match:
                    if current_class:
                        classes.append(current_class)
                    cls_name = class_match.group(1)
                    parent = (class_match.group(2) or "").strip()
                    current_class = RecoveredClass(
                        name=cls_name,
                        full_name=cls_name,
                        parent_class=parent,
                        source_tool=self.NAME,
                        confidence=0.7,
                    )
                    continue

                # Method with address
                method_match = re.match(
                    r".*?(?:public|private|protected|internal)\s+(?:static\s+)?(?:extern\s+)?"
                    r"(?:unsafe\s+)?(\S+)\s+(\w+)\s*\(([^)]*)\).*",
                    stripped,
                )
                if method_match and current_class:
                    ret_type = method_match.group(1)
                    method_name = method_match.group(2)
                    params_str = method_match.group(3)
                    params = []
                    if params_str.strip():
                        for i, p in enumerate(params_str.split(",")):
                            p = p.strip()
                            parts = p.rsplit(None, 1)
                            if len(parts) == 2:
                                params.append(RecoveredParameter(
                                    name=parts[1].strip(),
                                    type_name=parts[0].strip(),
                                    position=i,
                                ))
                    method = RecoveredMethod(
                        name=method_name,
                        return_type=ret_type,
                        parameters=params,
                        declaring_class=current_class.full_name,
                        confidence=0.7,
                    )
                    current_class.methods.append(method)

        except OSError as exc:
            logger.debug("Failed to parse dump.cs: %s", exc)

        if current_class:
            classes.append(current_class)
        return classes

    def _annotate_method_pointers(self, classes: list[RecoveredClass], path: Path) -> None:
        try:
            data = json.loads(path.read_text(encoding="utf-8", errors="replace"))
            if not isinstance(data, dict):
                return
            # Build address lookup
            addr_map: dict[str, int] = {}
            for key, value in data.items():
                if isinstance(value, (int, str)):
                    addr_map[key] = _safe_int(value)

            # Annotate classes
            for cls in classes:
                for method in cls.methods:
                    key = f"{cls.full_name}::{method.name}"
                    if key in addr_map:
                        method.native_address = addr_map[key]
                        method.confidence = max(method.confidence, 0.85)
        except (json.JSONDecodeError, OSError) as exc:
            logger.debug("Failed to annotate method pointers: %s", exc)


class Il2CppInspectorParser:
    """Parse Il2CppInspector output (DLL stubs, type maps).

    Il2CppInspector generates:
    - C# DLL stub files
    - Type information files
    - Ghidra scripts
    """

    NAME = "Il2CppInspector"

    def parse(self, output_dir: Path) -> list[RecoveredClass]:
        classes: list[RecoveredClass] = []
        if not output_dir.is_dir():
            logger.warning("Il2CppInspector output dir not found: %s", output_dir)
            return classes

        # Parse any JSON type maps
        for json_file in output_dir.rglob("*.json"):
            try:
                data = json.loads(json_file.read_text(encoding="utf-8", errors="replace"))
                classes.extend(self._parse_type_map(data))
            except (json.JSONDecodeError, OSError) as exc:
                logger.debug("Failed to parse %s: %s", json_file, exc)

        # Parse any CSV exports
        for csv_file in output_dir.rglob("*.csv"):
            try:
                classes.extend(self._parse_csv(csv_file))
            except Exception as exc:
                logger.debug("Failed to parse %s: %s", csv_file, exc)

        logger.info("Il2CppInspector: recovered %d classes from %s", len(classes), output_dir)
        return classes

    def _parse_type_map(self, data: dict | list) -> list[RecoveredClass]:
        classes = []
        items = data if isinstance(data, list) else data.get("types", data.get("Types", []))
        for item in items:
            if not isinstance(item, dict):
                continue
            name = item.get("name", item.get("Name", ""))
            if not name:
                continue
            ns = item.get("namespace", item.get("Namespace", ""))
            methods = []
            for m in item.get("methods", item.get("Methods", [])):
                methods.append(RecoveredMethod(
                    name=m.get("name", m.get("Name", "")),
                    native_address=_safe_int(m.get("address", m.get("Address", 0))),
                    declaring_class=f"{ns}.{name}" if ns else name,
                    confidence=0.85,
                ))
            classes.append(RecoveredClass(
                name=name,
                namespace=ns,
                full_name=f"{ns}.{name}" if ns else name,
                methods=methods,
                source_tool=self.NAME,
                confidence=0.85,
            ))
        return classes

    def _parse_csv(self, path: Path) -> list[RecoveredClass]:
        classes = []
        with open(path, "r", encoding="utf-8", errors="replace") as f:
            reader = csv.DictReader(f)
            for row in reader:
                name = row.get("TypeName", row.get("Name", ""))
                if not name:
                    continue
                classes.append(RecoveredClass(
                    name=name,
                    namespace=row.get("Namespace", ""),
                    full_name=row.get("FullName", name),
                    source_tool=self.NAME,
                    confidence=0.8,
                ))
        return classes
