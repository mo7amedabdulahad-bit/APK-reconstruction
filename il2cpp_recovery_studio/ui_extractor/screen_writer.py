"""Write per-screen JSON spec files to the output directory."""
from __future__ import annotations

import json
import re
from pathlib import Path

FACTIONS = [
    "romans", "egyptians", "gauls", "huns",
    "spartans", "teutons", "vikings",
]


def _classify_source(source_name: str) -> tuple[str, str]:
    """Determine (faction, category) from a bundle path or name."""
    sn = source_name.lower()
    faction = "common"
    category = "misc"

    for f in FACTIONS:
        if f in sn:
            faction = f
            break

    if "building" in sn:
        category = "buildings"
    elif "unit" in sn:
        category = "units"
    elif "hero" in sn or "portrait" in sn:
        category = "heroes"
    elif "header" in sn:
        category = "ui/header"
    elif "lobby" in sn:
        category = "ui/lobby"
    elif "village" in sn:
        category = "village"
    elif "resource" in sn:
        category = "resources"
    elif "translation" in sn:
        category = "localization"
    elif "icon" in sn:
        category = "icons"
    elif "general" in sn:
        category = "general"
    elif "spriteatlas" in sn:
        category = "spriteatlases"

    return faction, category


def _safe_filename(name: str) -> str:
    name = re.sub(r'[<>:"/\\|?*]', "_", name)
    return name[:200] if name else "unnamed"


class ScreenWriter:
    """Writes screen-spec JSON files into ``output_dir/UI_Screens/``."""

    def __init__(self, output_dir: Path) -> None:
        self._output_dir = Path(output_dir)

    def write(self, screen_data: dict, bundle_name: str) -> Path:
        """Serialise *screen_data* and return the path written.

        The file is placed at
        ``output_dir/UI_Screens/{faction}/{category}/{screen_name}.json``.
        """
        screen_name = screen_data.get("screen_name", "UnnamedScreen")
        faction, category = _classify_source(bundle_name)

        screen_dir = self._output_dir / "UI_Screens" / faction / category
        screen_dir.mkdir(parents=True, exist_ok=True)

        fname = _safe_filename(screen_name) + ".json"
        out_path = screen_dir / fname

        out_path.write_text(
            json.dumps(screen_data, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )
        return out_path
