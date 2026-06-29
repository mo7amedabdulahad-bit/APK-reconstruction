"""SQLite-backed unified recovery database."""
from __future__ import annotations

import json
import sqlite3
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

logger = get_logger("recovery.database")

_SCHEMA = """
CREATE TABLE IF NOT EXISTS classes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    namespace TEXT DEFAULT '',
    full_name TEXT NOT NULL UNIQUE,
    parent_class TEXT DEFAULT '',
    is_interface INTEGER DEFAULT 0,
    is_enum INTEGER DEFAULT 0,
    is_abstract INTEGER DEFAULT 0,
    is_sealed INTEGER DEFAULT 0,
    is_struct INTEGER DEFAULT 0,
    token INTEGER DEFAULT 0,
    image_index INTEGER DEFAULT 0,
    confidence REAL DEFAULT 0.0,
    source_tool TEXT DEFAULT '',
    implements TEXT DEFAULT '[]',
    generic_parameters TEXT DEFAULT '[]',
    nested_classes TEXT DEFAULT '[]'
);

CREATE TABLE IF NOT EXISTS fields (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    class_full_name TEXT NOT NULL,
    name TEXT NOT NULL,
    type_name TEXT DEFAULT '',
    offset INTEGER DEFAULT 0,
    is_static INTEGER DEFAULT 0,
    is_literal INTEGER DEFAULT 0,
    default_value TEXT DEFAULT '',
    token INTEGER DEFAULT 0,
    confidence REAL DEFAULT 0.0,
    FOREIGN KEY (class_full_name) REFERENCES classes(full_name)
);

CREATE TABLE IF NOT EXISTS methods (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    class_full_name TEXT NOT NULL,
    name TEXT NOT NULL,
    return_type TEXT DEFAULT '',
    native_address INTEGER DEFAULT 0,
    function_size INTEGER DEFAULT 0,
    token INTEGER DEFAULT 0,
    is_static INTEGER DEFAULT 0,
    is_abstract INTEGER DEFAULT 0,
    is_generic INTEGER DEFAULT 0,
    slot_index INTEGER DEFAULT -1,
    caller_count INTEGER DEFAULT 0,
    callee_count INTEGER DEFAULT 0,
    confidence REAL DEFAULT 0.0,
    FOREIGN KEY (class_full_name) REFERENCES classes(full_name)
);

CREATE TABLE IF NOT EXISTS parameters (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    method_id INTEGER NOT NULL,
    name TEXT NOT NULL,
    type_name TEXT DEFAULT '',
    position INTEGER DEFAULT 0,
    default_value TEXT DEFAULT '',
    FOREIGN KEY (method_id) REFERENCES methods(id)
);

CREATE TABLE IF NOT EXISTS properties (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    class_full_name TEXT NOT NULL,
    name TEXT NOT NULL,
    type_name TEXT DEFAULT '',
    getter_address INTEGER DEFAULT 0,
    setter_address INTEGER DEFAULT 0,
    FOREIGN KEY (class_full_name) REFERENCES classes(full_name)
);

CREATE TABLE IF NOT EXISTS enums (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    namespace TEXT DEFAULT '',
    full_name TEXT NOT NULL,
    enum_values TEXT DEFAULT '{}'
);

CREATE INDEX IF NOT EXISTS idx_classes_namespace ON classes(namespace);
CREATE INDEX IF NOT EXISTS idx_classes_name ON classes(name);
CREATE INDEX IF NOT EXISTS idx_methods_address ON methods(native_address);
CREATE INDEX IF NOT EXISTS idx_methods_class ON methods(class_full_name);
CREATE INDEX IF NOT EXISTS idx_fields_class ON fields(class_full_name);
"""


class RecoveryDatabase:
    """SQLite database storing recovered type information.

    Usage::

        db = RecoveryDatabase(Path("output/recovery.db"))
        db.store_classes(recovered_classes)
        results = db.search_classes("Player")
        db.close()
    """

    def __init__(self, db_path: Path | str) -> None:
        self._db_path = str(db_path)
        self._conn = sqlite3.connect(self._db_path)
        self._conn.row_factory = sqlite3.Row
        self._conn.executescript(_SCHEMA)
        self._conn.commit()
        logger.info("Recovery database opened: %s", self._db_path)

    def close(self) -> None:
        self._conn.close()

    # ── Store ────────────────────────────────────────────────────────

    def store_classes(self, classes: list[RecoveredClass]) -> int:
        """Store a list of recovered classes. Returns count stored."""
        count = 0
        for cls in classes:
            try:
                self._store_class(cls)
                count += 1
            except sqlite3.Error as exc:
                logger.debug("Failed to store class %s: %s", cls.full_name, exc)
        self._conn.commit()
        logger.info("Stored %d classes in database", count)
        return count

    def _store_class(self, cls: RecoveredClass) -> None:
        self._conn.execute(
            """INSERT OR REPLACE INTO classes
            (name, namespace, full_name, parent_class, is_interface, is_enum,
             is_abstract, is_sealed, is_struct, token, image_index,
             confidence, source_tool, implements, generic_parameters, nested_classes)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
            (
                cls.name,
                cls.namespace,
                cls.full_name,
                cls.parent_class,
                int(cls.is_interface),
                int(cls.is_enum),
                int(cls.is_abstract),
                int(cls.is_sealed),
                int(cls.is_struct),
                cls.token,
                cls.image_index,
                cls.confidence,
                cls.source_tool,
                json.dumps(cls.implements),
                json.dumps(cls.generic_parameters),
                json.dumps(cls.nested_classes),
            ),
        )

        for field in cls.fields:
            self._conn.execute(
                """INSERT INTO fields
                (class_full_name, name, type_name, offset, is_static,
                 is_literal, default_value, token, confidence)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                (
                    cls.full_name,
                    field.name,
                    field.type_name,
                    field.offset,
                    int(field.is_static),
                    int(field.is_literal),
                    field.default_value,
                    field.token,
                    field.confidence,
                ),
            )

        for method in cls.methods:
            cursor = self._conn.execute(
                """INSERT INTO methods
                (class_full_name, name, return_type, native_address, function_size,
                 token, is_static, is_abstract, is_generic, slot_index,
                 caller_count, callee_count, confidence)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                (
                    cls.full_name,
                    method.name,
                    method.return_type,
                    method.native_address,
                    method.function_size,
                    method.token,
                    int(method.is_static),
                    int(method.is_abstract),
                    int(method.is_generic),
                    method.slot_index,
                    method.caller_count,
                    method.callee_count,
                    method.confidence,
                ),
            )
            method_id = cursor.lastrowid

            for param in method.parameters:
                self._conn.execute(
                    """INSERT INTO parameters
                    (method_id, name, type_name, position, default_value)
                    VALUES (?, ?, ?, ?, ?)""",
                    (method_id, param.name, param.type_name, param.position, param.default_value),
                )

        for prop in cls.properties:
            self._conn.execute(
                """INSERT INTO properties
                (class_full_name, name, type_name, getter_address, setter_address)
                VALUES (?, ?, ?, ?, ?)""",
                (cls.full_name, prop.name, prop.type_name, prop.getter_address, prop.setter_address),
            )

    # ── Query ────────────────────────────────────────────────────────

    def search_classes(self, query: str, limit: int = 100) -> list[dict]:
        """Search classes by name (case-insensitive substring match)."""
        pattern = f"%{query}%"
        rows = self._conn.execute(
            "SELECT * FROM classes WHERE name LIKE ? OR full_name LIKE ? OR namespace LIKE ? LIMIT ?",
            (pattern, pattern, pattern, limit),
        ).fetchall()
        return [dict(row) for row in rows]

    def get_class(self, full_name: str) -> Optional[dict]:
        """Retrieve a class and its members by full name."""
        row = self._conn.execute(
            "SELECT * FROM classes WHERE full_name = ?", (full_name,)
        ).fetchone()
        if not row:
            return None
        result = dict(row)
        result["fields"] = self._get_fields(full_name)
        result["methods"] = self._get_methods(full_name)
        result["properties"] = self._get_properties(full_name)
        return result

    def search_methods(self, query: str, limit: int = 100) -> list[dict]:
        """Search methods by name."""
        pattern = f"%{query}%"
        rows = self._conn.execute(
            "SELECT * FROM methods WHERE name LIKE ? LIMIT ?",
            (pattern, limit),
        ).fetchall()
        return [dict(row) for row in rows]

    def get_method_by_address(self, address: int) -> Optional[dict]:
        """Look up a method by its native address."""
        row = self._conn.execute(
            "SELECT * FROM methods WHERE native_address = ?", (address,)
        ).fetchone()
        return dict(row) if row else None

    def search_fields(self, query: str, limit: int = 100) -> list[dict]:
        """Search fields by name."""
        pattern = f"%{query}%"
        rows = self._conn.execute(
            "SELECT * FROM fields WHERE name LIKE ? LIMIT ?",
            (pattern, limit),
        ).fetchall()
        return [dict(row) for row in rows]

    def get_statistics(self) -> dict:
        """Return aggregate statistics."""
        stats = {}
        stats["total_classes"] = self._conn.execute("SELECT COUNT(*) FROM classes").fetchone()[0]
        stats["total_methods"] = self._conn.execute("SELECT COUNT(*) FROM methods").fetchone()[0]
        stats["total_fields"] = self._conn.execute("SELECT COUNT(*) FROM fields").fetchone()[0]
        stats["total_properties"] = self._conn.execute("SELECT COUNT(*) FROM properties").fetchone()[0]
        stats["total_parameters"] = self._conn.execute("SELECT COUNT(*) FROM parameters").fetchone()[0]

        # Top source tools
        rows = self._conn.execute(
            "SELECT source_tool, COUNT(*) as cnt FROM classes GROUP BY source_tool ORDER BY cnt DESC"
        ).fetchall()
        stats["source_tools"] = {row["source_tool"]: row["cnt"] for row in rows}

        # Average confidence
        avg = self._conn.execute("SELECT AVG(confidence) FROM classes").fetchone()[0]
        stats["average_confidence"] = avg if avg else 0.0

        # Namespace distribution
        rows = self._conn.execute(
            "SELECT namespace, COUNT(*) as cnt FROM classes GROUP BY namespace ORDER BY cnt DESC LIMIT 20"
        ).fetchall()
        stats["top_namespaces"] = {row["namespace"] or "(global)": row["cnt"] for row in rows}

        return stats

    # ── Internal queries ─────────────────────────────────────────────

    def _get_fields(self, class_full_name: str) -> list[dict]:
        rows = self._conn.execute(
            "SELECT * FROM fields WHERE class_full_name = ?", (class_full_name,)
        ).fetchall()
        return [dict(row) for row in rows]

    def _get_methods(self, class_full_name: str) -> list[dict]:
        rows = self._conn.execute(
            "SELECT * FROM methods WHERE class_full_name = ?", (class_full_name,)
        ).fetchall()
        results = []
        for row in rows:
            d = dict(row)
            d["parameters"] = self._get_parameters(d["id"])
            results.append(d)
        return results

    def _get_parameters(self, method_id: int) -> list[dict]:
        rows = self._conn.execute(
            "SELECT * FROM parameters WHERE method_id = ? ORDER BY position", (method_id,)
        ).fetchall()
        return [dict(row) for row in rows]

    def _get_properties(self, class_full_name: str) -> list[dict]:
        rows = self._conn.execute(
            "SELECT * FROM properties WHERE class_full_name = ?", (class_full_name,)
        ).fetchall()
        return [dict(row) for row in rows]
