"""Data models for metadata recovery."""
from __future__ import annotations

from dataclasses import dataclass, field


@dataclass
class StringLiteral:
    index: int
    length: int
    data_index: int
    value: str = ""


@dataclass
class TypeDefinition:
    index: int
    name_index: int = 0
    namespace_index: int = 0
    name: str = ""
    namespace: str = ""
    byval_type_index: int = -1
    declaring_type_index: int = -1
    parent_index: int = -1
    element_type_index: int = -1
    field_start: int = 0
    field_count: int = 0
    method_start: int = 0
    method_count: int = 0
    event_start: int = 0
    event_count: int = 0
    property_start: int = 0
    property_count: int = 0
    nested_type_start: int = 0
    nested_type_count: int = 0
    interface_start: int = 0
    interface_count: int = 0
    vtable_start: int = 0
    vtable_count: int = 0
    interfaces_start: int = 0
    interfaces_count: int = 0
    bitfield: int = 0
    generic_container_index: int = -1
    token: int = 0

    @property
    def is_value_type(self) -> bool:
        return bool(self.bitfield & 0x01)

    @property
    def is_enum(self) -> bool:
        return bool(self.bitfield & 0x02)

    @property
    def full_name(self) -> str:
        if self.namespace:
            return f"{self.namespace}.{self.name}"
        return self.name


@dataclass
class MethodDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    declaring_type_index: int = -1
    return_type_index: int = -1
    parameter_start: int = 0
    parameter_count: int = 0
    generic_container_index: int = -1
    method_index: int = -1
    invoker_index: int = -1
    reverse_pinvoke_wrapper_index: int = -1
    token: int = 0
    flags: int = 0
    iflags: int = 0
    slot: int = -1
    parameter_count_actual: int = 0

    @property
    def is_static(self) -> bool:
        return bool(self.flags & 0x0010)

    @property
    def is_abstract(self) -> bool:
        return bool(self.flags & 0x0400)

    @property
    def is_generic(self) -> bool:
        return self.generic_container_index >= 0

    @property
    def is_constructor(self) -> bool:
        return self.name in (".ctor", ".cctor")


@dataclass
class FieldDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    type_index: int = -1
    token: int = 0


@dataclass
class ParameterDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    token: int = 0
    type_index: int = -1


@dataclass
class PropertyDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    set_method_index: int = -1
    get_method_index: int = -1
    token: int = 0


@dataclass
class EventDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    add_method_index: int = -1
    remove_method_index: int = -1
    raise_method_index: int = -1
    token: int = 0


@dataclass
class ImageDefinition:
    index: int
    name_index: int = 0
    name: str = ""
    assembly_index: int = 0
    type_start: int = 0
    type_count: int = 0
    exported_type_start: int = 0
    exported_type_count: int = 0
    entry_point_index: int = 0
    token: int = 0


@dataclass
class MetadataRecoveryResult:
    version: int = 0
    strings: list[str] = field(default_factory=list)
    string_literals: list[StringLiteral] = field(default_factory=list)
    type_definitions: list[TypeDefinition] = field(default_factory=list)
    method_definitions: list[MethodDefinition] = field(default_factory=list)
    field_definitions: list[FieldDefinition] = field(default_factory=list)
    parameter_definitions: list[ParameterDefinition] = field(default_factory=list)
    property_definitions: list[PropertyDefinition] = field(default_factory=list)
    event_definitions: list[EventDefinition] = field(default_factory=list)
    image_definitions: list[ImageDefinition] = field(default_factory=list)
    generic_parameters: list[dict] = field(default_factory=list)
    interface_offsets: list[dict] = field(default_factory=list)
    vtable_indices: list[int] = field(default_factory=list)
    errors: list[str] = field(default_factory=list)
    warnings: list[str] = field(default_factory=list)

    @property
    def total_types(self) -> int:
        return len(self.type_definitions)

    @property
    def total_methods(self) -> int:
        return len(self.method_definitions)

    @property
    def total_fields(self) -> int:
        return len(self.field_definitions)

    @property
    def total_images(self) -> int:
        return len(self.image_definitions)
