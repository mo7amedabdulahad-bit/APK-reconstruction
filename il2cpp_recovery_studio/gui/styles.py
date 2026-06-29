"""Dark mode stylesheet for IL2CPP Recovery Studio."""
from __future__ import annotations

DARK_STYLESHEET = """
QMainWindow, QDialog {
    background-color: #1e1e2e;
    color: #cdd6f4;
}
QMenuBar {
    background-color: #181825;
    color: #cdd6f4;
    border-bottom: 1px solid #313244;
}
QMenuBar::item:selected {
    background-color: #45475a;
}
QMenu {
    background-color: #1e1e2e;
    color: #cdd6f4;
    border: 1px solid #313244;
}
QMenu::item:selected {
    background-color: #585b70;
}
QTabWidget::pane {
    border: 1px solid #313244;
    background-color: #1e1e2e;
}
QTabBar::tab {
    background-color: #181825;
    color: #a6adc8;
    padding: 8px 16px;
    border: 1px solid #313244;
    border-bottom: none;
    margin-right: 2px;
}
QTabBar::tab:selected {
    background-color: #1e1e2e;
    color: #cdd6f4;
    border-bottom: 2px solid #89b4fa;
}
QTabBar::tab:hover:!selected {
    background-color: #313244;
}
QStatusBar {
    background-color: #181825;
    color: #a6adc8;
    border-top: 1px solid #313244;
}
QToolBar {
    background-color: #181825;
    border-bottom: 1px solid #313244;
    spacing: 4px;
    padding: 2px;
}
QToolButton {
    color: #cdd6f4;
    background-color: transparent;
    border: 1px solid transparent;
    border-radius: 4px;
    padding: 4px 8px;
}
QToolButton:hover {
    background-color: #313244;
    border: 1px solid #45475a;
}
QDockWidget {
    color: #cdd6f4;
    titlebar-close-icon: none;
    titlebar-normal-icon: none;
}
QDockWidget::title {
    background-color: #181825;
    padding: 6px;
    border-bottom: 1px solid #313244;
}
QLabel {
    color: #cdd6f4;
}
QGroupBox {
    color: #cdd6f4;
    border: 1px solid #313244;
    border-radius: 6px;
    margin-top: 12px;
    padding-top: 16px;
    font-weight: bold;
}
QGroupBox::title {
    subcontrol-origin: margin;
    left: 10px;
    padding: 0 6px;
    color: #89b4fa;
}
QPushButton {
    color: #cdd6f4;
    background-color: #313244;
    border: 1px solid #45475a;
    border-radius: 6px;
    padding: 6px 16px;
    font-weight: bold;
}
QPushButton:hover {
    background-color: #45475a;
    border: 1px solid #585b70;
}
QPushButton:pressed {
    background-color: #585b70;
}
QPushButton:disabled {
    color: #6c7086;
    background-color: #1e1e2e;
    border: 1px solid #313244;
}
QLineEdit, QTextEdit, QPlainTextEdit {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 4px;
    padding: 4px;
    selection-background-color: #585b70;
}
QLineEdit:focus, QTextEdit:focus, QPlainTextEdit:focus {
    border: 1px solid #89b4fa;
}
QSpinBox, QDoubleSpinBox, QComboBox {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 4px;
    padding: 4px;
}
QComboBox QAbstractItemView {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    selection-background-color: #45475a;
}
QCheckBox {
    color: #cdd6f4;
    spacing: 6px;
}
QCheckBox::indicator {
    width: 16px;
    height: 16px;
    border: 1px solid #45475a;
    border-radius: 3px;
    background-color: #181825;
}
QCheckBox::indicator:checked {
    background-color: #89b4fa;
    border-color: #89b4fa;
}
QProgressBar {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 4px;
    text-align: center;
}
QProgressBar::chunk {
    background-color: #89b4fa;
    border-radius: 3px;
}
QScrollBar:vertical {
    background-color: #181825;
    width: 10px;
    border: none;
}
QScrollBar::handle:vertical {
    background-color: #45475a;
    min-height: 20px;
    border-radius: 5px;
}
QScrollBar::handle:vertical:hover {
    background-color: #585b70;
}
QScrollBar::add-line:vertical, QScrollBar::sub-line:vertical {
    height: 0px;
}
QScrollBar:horizontal {
    background-color: #181825;
    height: 10px;
    border: none;
}
QScrollBar::handle:horizontal {
    background-color: #45475a;
    min-width: 20px;
    border-radius: 5px;
}
QScrollBar::handle:horizontal:hover {
    background-color: #585b70;
}
QScrollBar::add-line:horizontal, QScrollBar::sub-line:horizontal {
    width: 0px;
}
QTreeWidget, QTableWidget, QListWidget {
    color: #cdd6f4;
    background-color: #181825;
    border: 1px solid #313244;
    border-radius: 4px;
    gridline-color: #313244;
    alternate-background-color: #1e1e2e;
    selection-background-color: #45475a;
}
QTreeWidget::item, QTableWidget::item, QListWidget::item {
    padding: 4px;
}
QTreeWidget::item:selected, QTableWidget::item:selected, QListWidget::item:selected {
    background-color: #45475a;
}
QHeaderView::section {
    background-color: #181825;
    color: #a6adc8;
    border: 1px solid #313244;
    padding: 4px 8px;
    font-weight: bold;
}
QSplitter::handle {
    background-color: #313244;
}
QSplitter::handle:horizontal {
    width: 2px;
}
QSplitter::handle:vertical {
    height: 2px;
}
QLabel[class="header"] {
    font-size: 16px;
    font-weight: bold;
    color: #89b4fa;
}
QLabel[class="subheader"] {
    font-size: 12px;
    color: #a6adc8;
}
QLabel[class="stat-value"] {
    font-size: 24px;
    font-weight: bold;
    color: #a6e3a1;
}
QLabel[class="stat-label"] {
    font-size: 10px;
    color: #a6adc8;
}
"""
