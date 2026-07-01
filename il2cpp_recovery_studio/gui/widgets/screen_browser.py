"""ScreenBrowserPanel — a dockable panel showing extracted UI screens.

Displays a scrollable grid of screen cards, each with:
- A scaled-down thumbnail of the PREVIEW png
- Screen name and element count
- Three action buttons: Export (AI), Diff, Codegen (Flutter)

The panel can be embedded in the main window as a QDockWidget or used
stand-alone inside any layout.

Usage::

    browser = ScreenBrowserPanel(parent=main_window)
    browser.load_screens_dir(Path("output/AI_Export"))
    dock = QDockWidget("Screen Browser", main_window)
    dock.setWidget(browser)
    main_window.addDockWidget(Qt.RightDockWidgetArea, dock)
"""
from __future__ import annotations

from pathlib import Path
from typing import Callable, Optional
import json

try:
    from PyQt5.QtWidgets import (
        QWidget, QVBoxLayout, QHBoxLayout, QScrollArea,
        QLabel, QPushButton, QLineEdit, QFrame, QSizePolicy,
        QGridLayout, QApplication,
    )
    from PyQt5.QtGui import QPixmap, QImage
    from PyQt5.QtCore import Qt, pyqtSignal, QSize
    _HAS_QT = True
except ImportError:
    _HAS_QT = False


if _HAS_QT:
    class _ScreenCard(QFrame):
        """Single screen entry card widget."""

        export_clicked = pyqtSignal(str)   # screen_name
        diff_clicked = pyqtSignal(str)
        codegen_clicked = pyqtSignal(str)

        _THUMB_SIZE = QSize(160, 90)

        def __init__(self, screen_name: str, screen_dir: Path, parent=None):
            super().__init__(parent)
            self._screen_name = screen_name
            self._screen_dir = screen_dir
            self.setObjectName("screenCard")
            self.setFrameShape(QFrame.StyledPanel)
            self._build_ui()

        def _build_ui(self) -> None:
            layout = QVBoxLayout(self)
            layout.setContentsMargins(8, 8, 8, 8)
            layout.setSpacing(4)

            # Thumbnail
            thumb_label = QLabel()
            thumb_label.setObjectName("screenThumb")
            thumb_label.setFixedSize(self._THUMB_SIZE)
            thumb_label.setAlignment(Qt.AlignCenter)
            preview_png = self._screen_dir / f"{self._screen_name}_PREVIEW.png"
            if preview_png.exists():
                pix = QPixmap(str(preview_png)).scaled(
                    self._THUMB_SIZE, Qt.KeepAspectRatio, Qt.SmoothTransformation
                )
                thumb_label.setPixmap(pix)
            else:
                thumb_label.setText("No Preview")
                thumb_label.setStyleSheet("color: #6c7086; font-size: 11px;")
            layout.addWidget(thumb_label, alignment=Qt.AlignHCenter)

            # Name
            name_lbl = QLabel(self._screen_name)
            name_lbl.setObjectName("screenTitle")
            name_lbl.setWordWrap(True)
            name_lbl.setAlignment(Qt.AlignCenter)
            layout.addWidget(name_lbl)

            # Element count badge
            count_str = self._read_element_count()
            count_lbl = QLabel(count_str)
            count_lbl.setObjectName("screenCount")
            count_lbl.setAlignment(Qt.AlignCenter)
            layout.addWidget(count_lbl)

            # Action buttons
            btn_row = QHBoxLayout()
            btn_row.setSpacing(4)

            export_btn = QPushButton("Export")
            export_btn.setObjectName("primary")
            export_btn.setFixedHeight(26)
            export_btn.setToolTip("Open AI export bundle")
            export_btn.clicked.connect(lambda: self.export_clicked.emit(self._screen_name))

            diff_btn = QPushButton("Diff")
            diff_btn.setObjectName("diff")
            diff_btn.setFixedHeight(26)
            diff_btn.setToolTip("Diff this screen against another version")
            diff_btn.clicked.connect(lambda: self.diff_clicked.emit(self._screen_name))

            codegen_btn = QPushButton("Flutter")
            codegen_btn.setObjectName("codegen")
            codegen_btn.setFixedHeight(26)
            codegen_btn.setToolTip("Generate Flutter widget code")
            codegen_btn.clicked.connect(lambda: self.codegen_clicked.emit(self._screen_name))

            btn_row.addWidget(export_btn)
            btn_row.addWidget(diff_btn)
            btn_row.addWidget(codegen_btn)
            layout.addLayout(btn_row)

        def _read_element_count(self) -> str:
            ui_json = self._screen_dir.parent / "UI_Screens" / f"{self._screen_name}.json"
            if not ui_json.exists():
                # Try directly inside screen_dir
                for f in self._screen_dir.glob("*.json"):
                    if "token" not in f.name and "diff" not in f.name:
                        try:
                            data = json.loads(f.read_text(encoding="utf-8"))
                            n = len(data.get("elements", []))
                            return f"{n} elements"
                        except Exception:
                            pass
                return ""
            try:
                data = json.loads(ui_json.read_text(encoding="utf-8"))
                return f"{len(data.get('elements', []))} elements"
            except Exception:
                return ""


    class ScreenBrowserPanel(QWidget):
        """Scrollable grid panel of screen cards."""

        export_requested = pyqtSignal(str)
        diff_requested = pyqtSignal(str)
        codegen_requested = pyqtSignal(str)

        def __init__(self, parent=None):
            super().__init__(parent)
            self._screens_dir: Optional[Path] = None
            self._cards: list[_ScreenCard] = []
            self._build_ui()

        def _build_ui(self) -> None:
            outer = QVBoxLayout(self)
            outer.setContentsMargins(8, 8, 8, 8)
            outer.setSpacing(6)

            # Header + search
            header_row = QHBoxLayout()
            header_lbl = QLabel("UI Screens")
            header_lbl.setProperty("class", "header")
            header_row.addWidget(header_lbl)
            header_row.addStretch()
            self._search = QLineEdit()
            self._search.setObjectName("browserSearch")
            self._search.setPlaceholderText("Filter screens…")
            self._search.setFixedWidth(200)
            self._search.textChanged.connect(self._apply_filter)
            header_row.addWidget(self._search)
            outer.addLayout(header_row)

            # Count label
            self._count_lbl = QLabel("No screens loaded")
            self._count_lbl.setProperty("class", "subheader")
            outer.addWidget(self._count_lbl)

            # Scrollable grid
            scroll = QScrollArea()
            scroll.setWidgetResizable(True)
            scroll.setHorizontalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
            self._grid_widget = QWidget()
            self._grid = QGridLayout(self._grid_widget)
            self._grid.setSpacing(10)
            self._grid.setContentsMargins(4, 4, 4, 4)
            scroll.setWidget(self._grid_widget)
            outer.addWidget(scroll)

        def load_screens_dir(self, screens_dir: Path) -> None:
            """Scan *screens_dir* for screen sub-folders and populate the grid."""
            self._screens_dir = Path(screens_dir)
            self._cards.clear()

            # Clear existing grid items
            while self._grid.count():
                item = self._grid.takeAt(0)
                if item.widget():
                    item.widget().deleteLater()

            screen_dirs = sorted(
                d for d in self._screens_dir.iterdir()
                if d.is_dir() and not d.name.startswith(".")
            )

            cols = 3
            for idx, sd in enumerate(screen_dirs):
                card = _ScreenCard(sd.name, sd, parent=self._grid_widget)
                card.export_clicked.connect(self.export_requested)
                card.diff_clicked.connect(self.diff_requested)
                card.codegen_clicked.connect(self.codegen_requested)
                self._cards.append(card)
                self._grid.addWidget(card, idx // cols, idx % cols)

            self._count_lbl.setText(f"{len(screen_dirs)} screen(s) found")

        def _apply_filter(self, text: str) -> None:
            q = text.lower()
            for card in self._cards:
                card.setVisible(q in card._screen_name.lower())

else:
    # Stub when PyQt5 is not installed
    class ScreenBrowserPanel:  # type: ignore[no-redef]
        def __init__(self, *a, **kw):
            pass

        def load_screens_dir(self, *a, **kw):
            pass
