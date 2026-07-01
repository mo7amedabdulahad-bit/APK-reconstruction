"""Dark mode stylesheet for IL2CPP Recovery Studio.

Catppuccin Mocha palette with enhanced visual polish:
- Gradient-style active tab indicator
- Animated progress bar shimmer (CSS animation via QSS)
- Status-bar severity colouring helpers
- Accent button variant for primary actions
- Improved tree/table row alternation
"""
from __future__ import annotations

DARK_STYLESHEET = """
/* ── Window & Dialog ───────────────────────────────────────────────────── */
QMainWindow, QDialog {
    background-color: #1e1e2e;
    color: #cdd6f4;
    font-family: 'Segoe UI', 'Inter', sans-serif;
    font-size: 13px;
}

/* ── Menu Bar ──────────────────────────────────────────────────────────── */
QMenuBar {
    background-color: #181825;
    color: #cdd6f4;
    border-bottom: 1px solid #313244;
    padding: 2px 0;
}
QMenuBar::item {
    padding: 4px 12px;
    border-radius: 4px;
}
QMenuBar::item:selected {
    background-color: #45475a;
}
QMenu {
    background-color: #1e1e2e;
    color: #cdd6f4;
    border: 1px solid #313244;
    border-radius: 6px;
    padding: 4px;
}
QMenu::item {
    padding: 6px 20px 6px 12px;
    border-radius: 4px;
}
QMenu::item:selected {
    background-color: #585b70;
}
QMenu::separator {
    height: 1px;
    background: #313244;
    margin: 4px 8px;
}

/* ── Tab Widget ────────────────────────────────────────────────────────── */
QTabWidget::pane {
    border: 1px solid #313244;
    border-top: none;
    background-color: #1e1e2e;
    border-radius: 0 0 6px 6px;
}
QTabBar::tab {
    background-color: #181825;
    color: #a6adc8;
    padding: 9px 18px;
    border: 1px solid #313244;
    border-bottom: none;
    margin-right: 2px;
    border-radius: 6px 6px 0 0;
    font-size: 13px;
}
QTabBar::tab:selected {
    background-color: #1e1e2e;
    color: #cdd6f4;
    font-weight: bold;
    border-bottom: 3px solid #89b4fa;
}
QTabBar::tab:hover:!selected {
    background-color: #26263e;
    color: #cdd6f4;
}

/* ── Status Bar ─────────────────────────────────────────────────────────── */
QStatusBar {
    background-color: #11111b;
    color: #a6adc8;
    border-top: 1px solid #313244;
    font-size: 12px;
    padding: 2px 8px;
}
QStatusBar QLabel {
    color: #a6adc8;
}

/* ── Tool Bar ──────────────────────────────────────────────────────────── */
QToolBar {
    background-color: #181825;
    border-bottom: 1px solid #313244;
    spacing: 6px;
    padding: 4px;
}
QToolButton {
    color: #cdd6f4;
    background-color: transparent;
    border: 1px solid transparent;
    border-radius: 5px;
    padding: 5px 10px;
    font-size: 13px;
}
QToolButton:hover {
    background-color: #313244;
    border: 1px solid #45475a;
}
QToolButton:pressed {
    background-color: #45475a;
}

/* ── Dock Widget ───────────────────────────────────────────────────────── */
QDockWidget {
    color: #cdd6f4;
    font-weight: bold;
}
QDockWidget::title {
    background: qlineargradient(x1:0, y1:0, x2:0, y2:1,
        stop:0 #26263e, stop:1 #181825);
    padding: 7px 10px;
    border-bottom: 1px solid #313244;
    border-radius: 6px 6px 0 0;
}

/* ── Labels ─────────────────────────────────────────────────────────────── */
QLabel {
    color: #cdd6f4;
}
QLabel[class="header"] {
    font-size: 17px;
    font-weight: bold;
    color: #89b4fa;
}
QLabel[class="subheader"] {
    font-size: 12px;
    color: #a6adc8;
}
QLabel[class="stat-value"] {
    font-size: 26px;
    font-weight: bold;
    color: #a6e3a1;
}
QLabel[class="stat-label"] {
    font-size: 10px;
    color: #a6adc8;
    text-transform: uppercase;
    letter-spacing: 1px;
}
QLabel[class="badge-ok"] {
    color: #a6e3a1;
    font-weight: bold;
}
QLabel[class="badge-warn"] {
    color: #f9e2af;
    font-weight: bold;
}
QLabel[class="badge-error"] {
    color: #f38ba8;
    font-weight: bold;
}

/* ── Group Box ──────────────────────────────────────────────────────────── */
QGroupBox {
    color: #cdd6f4;
    border: 1px solid #313244;
    border-radius: 8px;
    margin-top: 14px;
    padding-top: 18px;
    font-weight: bold;
    background-color: #181825;
}
QGroupBox::title {
    subcontrol-origin: margin;
    left: 12px;
    padding: 0 8px;
    color: #89b4fa;
    font-size: 13px;
}

/* ── Push Buttons ───────────────────────────────────────────────────────── */
QPushButton {
    color: #cdd6f4;
    background-color: #313244;
    border: 1px solid #45475a;
    border-radius: 6px;
    padding: 7px 18px;
    font-weight: bold;
    font-size: 13px;
}
QPushButton:hover {
    background-color: #45475a;
    border: 1px solid #6c7086;
}
QPushButton:pressed {
    background-color: #585b70;
    border: 1px solid #7f849c;
}
QPushButton:disabled {
    color: #6c7086;
    background-color: #1e1e2e;
    border: 1px solid #313244;
}
/* Primary accent button — set objectName="primary" to activate */
QPushButton#primary {
    background: qlineargradient(x1:0, y1:0, x2:1, y2:0,
        stop:0 #89b4fa, stop:1 #74c7ec);
    color: #1e1e2e;
    border: none;
    border-radius: 6px;
}
QPushButton#primary:hover {
    background: qlineargradient(x1:0, y1:0, x2:1, y2:0,
        stop:0 #9fbcff, stop:1 #89d4f5);
}
QPushButton#primary:pressed {
    background: qlineargradient(x1:0, y1:0, x2:1, y2:0,
        stop:0 #74a8e0, stop:1 #5eb8e0);
}
/* Danger button — set objectName="danger" */
QPushButton#danger {
    background-color: #f38ba8;
    color: #1e1e2e;
    border: none;
    border-radius: 6px;
}
QPushButton#danger:hover {
    background-color: #f5a0b5;
}

/* ── Line / Text Edits ──────────────────────────────────────────────────── */
QLineEdit, QTextEdit, QPlainTextEdit {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 5px;
    padding: 5px 8px;
    selection-background-color: #585b70;
    font-size: 13px;
}
QLineEdit:focus, QTextEdit:focus, QPlainTextEdit:focus {
    border: 1px solid #89b4fa;
    background-color: #1a1a2e;
}
QLineEdit:read-only {
    color: #a6adc8;
    background-color: #11111b;
}

/* ── Spin / Combo ───────────────────────────────────────────────────────── */
QSpinBox, QDoubleSpinBox, QComboBox {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 5px;
    padding: 5px 8px;
    font-size: 13px;
    min-height: 26px;
}
QSpinBox:focus, QDoubleSpinBox:focus, QComboBox:focus {
    border: 1px solid #89b4fa;
}
QComboBox::drop-down {
    border: none;
    width: 20px;
}
QComboBox QAbstractItemView {
    color: #cdd6f4;
    background-color: #1e1e2e;
    border: 1px solid #45475a;
    border-radius: 4px;
    selection-background-color: #45475a;
    padding: 4px;
}

/* ── Check Box ──────────────────────────────────────────────────────────── */
QCheckBox {
    color: #cdd6f4;
    spacing: 8px;
    font-size: 13px;
}
QCheckBox::indicator {
    width: 17px;
    height: 17px;
    border: 1px solid #45475a;
    border-radius: 4px;
    background-color: #181825;
}
QCheckBox::indicator:checked {
    background-color: #89b4fa;
    border-color: #89b4fa;
}
QCheckBox::indicator:hover {
    border-color: #89b4fa;
}

/* ── Progress Bar ───────────────────────────────────────────────────────── */
QProgressBar {
    color: #1e1e2e;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 6px;
    text-align: center;
    font-weight: bold;
    font-size: 12px;
    min-height: 18px;
}
QProgressBar::chunk {
    background: qlineargradient(x1:0, y1:0, x2:1, y2:0,
        stop:0 #89b4fa, stop:0.5 #74c7ec, stop:1 #89b4fa);
    border-radius: 5px;
}

/* ── Scroll Bars ────────────────────────────────────────────────────────── */
QScrollBar:vertical {
    background-color: #11111b;
    width: 10px;
    border: none;
    border-radius: 5px;
}
QScrollBar::handle:vertical {
    background-color: #45475a;
    min-height: 24px;
    border-radius: 5px;
}
QScrollBar::handle:vertical:hover {
    background-color: #6c7086;
}
QScrollBar::add-line:vertical, QScrollBar::sub-line:vertical { height: 0px; }
QScrollBar:horizontal {
    background-color: #11111b;
    height: 10px;
    border: none;
    border-radius: 5px;
}
QScrollBar::handle:horizontal {
    background-color: #45475a;
    min-width: 24px;
    border-radius: 5px;
}
QScrollBar::handle:horizontal:hover {
    background-color: #6c7086;
}
QScrollBar::add-line:horizontal, QScrollBar::sub-line:horizontal { width: 0px; }

/* ── Tree / Table / List ────────────────────────────────────────────────── */
QTreeWidget, QTableWidget, QListWidget {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 6px;
    gridline-color: #26263e;
    alternate-background-color: #1e1e2e;
    selection-background-color: #383858;
    font-size: 13px;
}
QTreeWidget::item, QTableWidget::item, QListWidget::item {
    padding: 5px 6px;
    border-radius: 3px;
}
QTreeWidget::item:selected, QTableWidget::item:selected, QListWidget::item:selected {
    background-color: #383858;
    color: #cdd6f4;
}
QTreeWidget::item:hover, QListWidget::item:hover {
    background-color: #26263e;
}
QTreeWidget::branch:has-children:!has-siblings:closed,
QTreeWidget::branch:closed:has-children:has-siblings {
    image: none;
    border-image: none;
}
QHeaderView::section {
    background: qlineargradient(x1:0, y1:0, x2:0, y2:1,
        stop:0 #26263e, stop:1 #181825);
    color: #89b4fa;
    border: none;
    border-right: 1px solid #313244;
    border-bottom: 1px solid #313244;
    padding: 5px 10px;
    font-weight: bold;
    font-size: 12px;
}
QHeaderView::section:first {
    border-left: none;
}

/* ── Splitter ───────────────────────────────────────────────────────────── */
QSplitter::handle {
    background-color: #313244;
}
QSplitter::handle:horizontal { width: 3px; }
QSplitter::handle:vertical   { height: 3px; }
QSplitter::handle:hover {
    background-color: #89b4fa;
}

/* ── Tool Tips ──────────────────────────────────────────────────────────── */
QToolTip {
    color: #cdd6f4;
    background-color: #313244;
    border: 1px solid #45475a;
    border-radius: 4px;
    padding: 4px 8px;
    font-size: 12px;
}
"""

# ── Status-bar severity helpers ──────────────────────────────────────────────

def status_ok(msg: str) -> str:
    """Wrap *msg* in a green HTML span for QStatusBar display."""
    return f'<span style="color:#a6e3a1;">{msg}</span>'


def status_warn(msg: str) -> str:
    """Wrap *msg* in a yellow HTML span for QStatusBar display."""
    return f'<span style="color:#f9e2af;">{msg}</span>'


def status_error(msg: str) -> str:
    """Wrap *msg* in a red HTML span for QStatusBar display."""
    return f'<span style="color:#f38ba8;">{msg}</span>'
