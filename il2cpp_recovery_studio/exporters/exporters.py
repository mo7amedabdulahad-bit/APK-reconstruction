"""Exporters for recovered Unity data: JSON, CSV, SQLite, Markdown."""
from __future__ import annotations

import csv
import json
import os
import sqlite3
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField, RecoveredMethod

logger = get_logger("exporters")


def _class_to_dict(rc: RecoveredClass) -> dict:
    return {
        "name": rc.name,
        "namespace": rc.namespace,
        "parent_class": rc.parent_class,
        "implements": rc.implements,
        "token": rc.token,
        "confidence": rc.confidence,
        "fields": [{"name": f.name, "type": f.type_name, "default": f.default_value} for f in rc.fields],
        "methods": [{"name": m.name, "return": m.return_type, "params": ", ".join(m.parameters) if isinstance(m.parameters, list) else (m.parameters or ""), "address": m.native_address} for m in rc.methods],
    }


class JSONExporter:
    """Export recovered data to JSON."""

    def export(self, classes: list[RecoveredClass], output_path: str) -> str:
        data = [_class_to_dict(rc) for rc in classes]
        out = Path(output_path)
        out.mkdir(parents=True, exist_ok=True)
        file_path = out / "recovered.json"
        file_path.write_text(json.dumps(data, indent=2), encoding="utf-8")
        logger.info("Exported JSON: %s (%d classes)", file_path, len(data))
        return str(file_path)


class CSVExporter:
    """Export recovered data to CSV."""

    def export(self, classes: list[RecoveredClass], output_path: str) -> str:
        out = Path(output_path)
        out.mkdir(parents=True, exist_ok=True)
        file_path = out / "recovered.csv"

        with open(file_path, "w", newline="", encoding="utf-8") as f:
            writer = csv.writer(f)
            writer.writerow(["Class", "Namespace", "Method", "ReturnType", "Parameters", "NativeAddress"])
            for rc in classes:
                ns = rc.namespace or ""
                if rc.methods:
                    for m in rc.methods:
                        writer.writerow([rc.name, ns, m.name, m.return_type, ", ".join(m.parameters) if isinstance(m.parameters, list) else (m.parameters or ""), f"0x{m.native_address:X}" if m.native_address else ""])
                else:
                    writer.writerow([rc.name, ns, "", "", "", ""])

        logger.info("Exported CSV: %s", file_path)
        return str(file_path)


class SQLiteExporter:
    """Export recovered data to SQLite."""

    def export(self, classes: list[RecoveredClass], output_path: str) -> str:
        out = Path(output_path)
        out.mkdir(parents=True, exist_ok=True)
        db_path = out / "recovered.db"

        conn = sqlite3.connect(str(db_path))
        cur = conn.cursor()

        cur.execute("DROP TABLE IF EXISTS classes")
        cur.execute("DROP TABLE IF EXISTS methods")
        cur.execute("DROP TABLE IF EXISTS fields")

        cur.execute("""CREATE TABLE classes (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT, namespace TEXT, parent_class TEXT,
            token INTEGER, confidence REAL
        )""")
        cur.execute("""CREATE TABLE methods (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            class_id INTEGER, name TEXT, return_type TEXT,
            parameters TEXT, native_address INTEGER,
            FOREIGN KEY (class_id) REFERENCES classes(id)
        )""")
        cur.execute("""CREATE TABLE fields (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            class_id INTEGER, name TEXT, type_name TEXT,
            default_value TEXT,
            FOREIGN KEY (class_id) REFERENCES classes(id)
        )""")

        for rc in classes:
            cur.execute(
                "INSERT INTO classes (name, namespace, parent_class, token, confidence) VALUES (?, ?, ?, ?, ?)",
                (rc.name, rc.namespace, rc.parent_class, rc.token, rc.confidence),
            )
            class_id = cur.lastrowid
            for m in rc.methods:
                params_str = ", ".join(m.parameters) if isinstance(m.parameters, list) else (m.parameters or "")
                cur.execute(
                    "INSERT INTO methods (class_id, name, return_type, parameters, native_address) VALUES (?, ?, ?, ?, ?)",
                    (class_id, m.name, m.return_type, params_str, m.native_address),
                )
            for f in rc.fields:
                cur.execute(
                    "INSERT INTO fields (class_id, name, type_name, default_value) VALUES (?, ?, ?, ?)",
                    (class_id, f.name, f.type_name, f.default_value),
                )

        conn.commit()
        conn.close()
        logger.info("Exported SQLite: %s (%d classes)", db_path, len(classes))
        return str(db_path)


class MarkdownExporter:
    """Export recovered data to Markdown."""

    def export(self, classes: list[RecoveredClass], output_path: str) -> str:
        out = Path(output_path)
        out.mkdir(parents=True, exist_ok=True)
        file_path = out / "recovered.md"

        lines = ["# IL2CPP Recovery Report\n", f"Total classes: {len(classes)}\n"]
        for rc in classes:
            full = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name
            lines.append(f"\n## {full}\n")
            if rc.parent_class:
                lines.append(f"**Inherits:** {rc.parent_class}\n")
            if rc.fields:
                lines.append("### Fields\n")
                for f in rc.fields:
                    lines.append(f"- `{f.type_name}` **{f.name}**\n")
            if rc.methods:
                lines.append("### Methods\n")
                for m in rc.methods:
                    addr = f" `0x{m.native_address:X}`" if m.native_address else ""
                    params_str = ", ".join(m.parameters) if isinstance(m.parameters, list) else (m.parameters or "")
                    lines.append(f"- `{m.return_type}` **{m.name}**({params_str}){addr}\n")

        file_path.write_text("".join(lines), encoding="utf-8")
        logger.info("Exported Markdown: %s", file_path)
        return str(file_path)
