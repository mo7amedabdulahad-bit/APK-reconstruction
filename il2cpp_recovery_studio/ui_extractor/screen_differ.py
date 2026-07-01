"""Diff two UI screen-spec JSONs and report what changed.

Produces a ScreenDiff that lists:
- Added elements (present in new, absent from old)
- Removed elements (present in old, absent from new)
- Changed elements (same name but differing fields)
- Unchanged element count

This is useful for tracking UI changes across APK versions and for
validating that a reconstructed screen matches the original.
"""
from __future__ import annotations

from dataclasses import dataclass, field
from pathlib import Path
from typing import Optional
import json


_POSITIONAL_KEYS = {"position", "size", "anchor", "pivot", "rotation", "scale"}
_VISUAL_KEYS = {"color", "sprite_name", "sprite_file", "text", "font_size",
                "font_style", "image_type", "label", "active"}
_ALL_TRACKED = _POSITIONAL_KEYS | _VISUAL_KEYS


@dataclass
class ElementChange:
    name: str
    el_id: str
    changed_fields: dict[str, tuple]  # field -> (old_value, new_value)


@dataclass
class ScreenDiff:
    screen_name: str
    added: list[dict] = field(default_factory=list)
    removed: list[dict] = field(default_factory=list)
    changed: list[ElementChange] = field(default_factory=list)
    unchanged_count: int = 0

    @property
    def has_changes(self) -> bool:
        return bool(self.added or self.removed or self.changed)

    def summary(self) -> str:
        lines = [f"Screen diff: {self.screen_name}"]
        lines.append(f"  + Added:     {len(self.added)} element(s)")
        lines.append(f"  - Removed:   {len(self.removed)} element(s)")
        lines.append(f"  ~ Changed:   {len(self.changed)} element(s)")
        lines.append(f"  = Unchanged: {self.unchanged_count} element(s)")
        if self.changed:
            lines.append("")
            lines.append("  Changed elements:")
            for ec in self.changed:
                lines.append(f"    [{ec.el_id}] {ec.name}")
                for fld, (old, new) in ec.changed_fields.items():
                    lines.append(f"      {fld}: {old!r} → {new!r}")
        return "\n".join(lines)

    def to_dict(self) -> dict:
        return {
            "screen_name": self.screen_name,
            "added": self.added,
            "removed": self.removed,
            "changed": [
                {
                    "name": ec.name,
                    "id": ec.el_id,
                    "changed_fields": {
                        k: {"old": v[0], "new": v[1]}
                        for k, v in ec.changed_fields.items()
                    },
                }
                for ec in self.changed
            ],
            "unchanged_count": self.unchanged_count,
        }


class ScreenDiffer:
    """Compare two screen-spec dicts or JSON files and return a ScreenDiff."""

    def diff_dicts(self, old: dict, new: dict) -> ScreenDiff:
        """Diff two screen-spec dicts directly."""
        screen_name = new.get("screen_name", old.get("screen_name", "unknown"))
        result = ScreenDiff(screen_name=screen_name)

        old_elements = old.get("elements", [])
        new_elements = new.get("elements", [])

        old_by_name: dict[str, dict] = {e["name"]: e for e in old_elements if "name" in e}
        new_by_name: dict[str, dict] = {e["name"]: e for e in new_elements if "name" in e}

        old_names = set(old_by_name)
        new_names = set(new_by_name)

        result.added = [new_by_name[n] for n in sorted(new_names - old_names)]
        result.removed = [old_by_name[n] for n in sorted(old_names - new_names)]

        for name in sorted(old_names & new_names):
            ec = self._compare_elements(old_by_name[name], new_by_name[name])
            if ec.changed_fields:
                result.changed.append(ec)
            else:
                result.unchanged_count += 1

        return result

    def diff_files(self, old_path: Path, new_path: Path) -> ScreenDiff:
        """Load two screen-spec JSON files and diff them."""
        old = json.loads(Path(old_path).read_text(encoding="utf-8"))
        new = json.loads(Path(new_path).read_text(encoding="utf-8"))
        return self.diff_dicts(old, new)

    def diff_screen_versions(
        self,
        screens_dir_v1: Path,
        screens_dir_v2: Path,
        output_dir: Optional[Path] = None,
    ) -> list[ScreenDiff]:
        """Diff all matching screen JSONs across two version directories.

        If output_dir is given, writes one ``<screen>_diff.json`` per screen.
        """
        screens_dir_v1 = Path(screens_dir_v1)
        screens_dir_v2 = Path(screens_dir_v2)
        v1_files = {f.stem: f for f in screens_dir_v1.rglob("*.json")}
        v2_files = {f.stem: f for f in screens_dir_v2.rglob("*.json")}
        common = sorted(set(v1_files) & set(v2_files))

        diffs: list[ScreenDiff] = []
        for name in common:
            diff = self.diff_files(v1_files[name], v2_files[name])
            diffs.append(diff)
            if output_dir:
                out = Path(output_dir) / f"{name}_diff.json"
                out.parent.mkdir(parents=True, exist_ok=True)
                out.write_text(
                    json.dumps(diff.to_dict(), indent=2, ensure_ascii=False),
                    encoding="utf-8",
                )
        return diffs

    # ── helpers ─────────────────────────────────────────────────────────

    @staticmethod
    def _compare_elements(old_el: dict, new_el: dict) -> ElementChange:
        changed_fields: dict[str, tuple] = {}
        for key in _ALL_TRACKED:
            old_val = old_el.get(key)
            new_val = new_el.get(key)
            if old_val != new_val:
                changed_fields[key] = (old_val, new_val)
        return ElementChange(
            name=new_el.get("name", ""),
            el_id=new_el.get("id", ""),
            changed_fields=changed_fields,
        )
