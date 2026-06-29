"""Tests for Phase 15: GUI application."""
from __future__ import annotations

import pytest

try:
    from PySide6.QtWidgets import QApplication
    HAS_PYSIDE = True
except ImportError:
    HAS_PYSIDE = False

pytestmark = pytest.mark.skipif(not HAS_PYSIDE, reason="PySide6 not installed")


@pytest.fixture(scope="module")
def qapp_instance():
    app = QApplication.instance()
    if app is None:
        app = QApplication([])
    yield app


class TestMainWindowCreation:
    def test_creation(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w.windowTitle() == "IL2CPP Recovery Studio"
        assert w.minimumWidth() >= 1200
        w.close()

    def test_tabs_count(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w.tabs.count() == 12
        w.close()

    def test_tab_names(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        names = [w.tabs.tabText(i) for i in range(w.tabs.count())]
        assert "Overview" in names
        assert "Metadata" in names
        assert "Methods" in names
        assert "Strings" in names
        assert "Assets" in names
        assert "Network" in names
        assert "Unity" in names
        assert "Graphs" in names
        assert "Search" in names
        assert "Ghidra" in names
        assert "Plugins" in names
        assert "Settings" in names
        w.close()

    def test_status_bar(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w.statusBar() is not None
        w.close()

    def test_docks_exist(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        from PySide6.QtWidgets import QDockWidget
        w = MainWindow()
        docks = w.findChildren(QDockWidget)
        assert len(docks) >= 2
        assert w._log_dock is not None
        assert w._file_dock is not None
        w.close()

    def test_menu_bar(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        menubar = w.menuBar()
        actions = [a.text() for a in menubar.actions()]
        assert "File" in actions
        assert "Tools" in actions
        assert "Help" in actions
        w.close()

    def test_toolbar(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._open_btn is not None
        assert w._analyze_btn is not None
        assert w._export_btn is not None
        assert w._analyze_btn.isEnabled() is False
        w.close()


class TestStatCard:
    def test_creation(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import StatCard
        card = StatCard("Test", "42")
        card.set_value("99")
        card.close()

    def test_default_value(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import StatCard
        card = StatCard("Label")
        card.close()


class TestOverviewTab:
    def test_overview_stats(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._stat_classes.set_value("100")
        w._stat_methods.set_value("500")
        w._stat_fields.set_value("200")
        w._stat_strings.set_value("1000")
        w._stat_tools.set_value("3")
        w._stat_time.set_value("1234ms")
        w.close()

    def test_overview_info_table(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._overview_info.columnCount() == 2
        w.close()


class TestMetadataTab:
    def test_metadata_tree(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._metadata_tree.columnCount() == 5
        w.close()


class TestMethodsTab:
    def test_methods_table(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._methods_table.columnCount() == 6
        w.close()

    def test_method_filter(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._method_filter.setText("test")
        w.close()


class TestStringsTab:
    def test_strings_table(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._strings_table.columnCount() == 3
        w.close()

    def test_string_categories(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        categories = [w._string_category.itemText(i) for i in range(w._string_category.count())]
        assert "All" in categories
        assert "URL" in categories
        assert "JSON" in categories
        w.close()


class TestAssetsTab:
    def test_assets_tree(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._assets_tree.columnCount() == 4
        w.close()


class TestNetworkTab:
    def test_network_table(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._network_table.columnCount() == 4
        w.close()


class TestUnityTab:
    def test_unity_tree(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._unity_tree.columnCount() == 3
        w.close()


class TestGraphsTab:
    def test_graph_controls(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._graph_type.count() == 4
        w.close()


class TestSearchTab:
    def test_search_controls(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._search_scope.count() == 6
        assert w._search_mode.count() == 4
        w.close()

    def test_search_perform(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._search_input.setText("test")
        w._perform_search()
        w.close()


class TestGhidraTab:
    def test_ghidra_controls(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._ghidra_run_btn is not None
        assert w._ghidra_log.isReadOnly()
        w.close()


class TestPluginsTab:
    def test_plugin_controls(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._plugin_refresh_btn is not None
        assert w._plugin_load_btn is not None
        w.close()


class TestSettingsTab:
    def test_settings_values(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._setting_parallel.value() >= 1
        assert w._setting_extract.isChecked()
        assert w._setting_graphs.isChecked()
        w.close()

    def test_tool_path_fields(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        assert w._tool_cpp2il.text() != ""
        assert w._tool_dumper.text() != ""
        w.close()


class TestActions:
    def test_run_analysis_no_apk(self, qapp_instance):
        from unittest.mock import patch
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        with patch("il2cpp_recovery_studio.gui.app.QMessageBox"):
            w._run_analysis()
        w.close()

    def test_clear_results(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._stat_classes.set_value("99")
        w._clear_results()
        w.close()

    def test_about(self, qapp_instance):
        from unittest.mock import patch
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        with patch("il2cpp_recovery_studio.gui.app.QMessageBox"):
            w._about()
        w.close()

    def test_log_message(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._log_message("Test message")
        assert "Test message" in w._log_text.toPlainText()
        w.close()

    def test_export_no_apk(self, qapp_instance):
        from unittest.mock import patch
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        with patch("il2cpp_recovery_studio.gui.app.QMessageBox"):
            w._export_results()
        w.close()

    def test_run_metadata_only_no_apk(self, qapp_instance):
        from unittest.mock import patch
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        with patch("il2cpp_recovery_studio.gui.app.QMessageBox"):
            w._run_metadata_only()
        w.close()

    def test_file_tree_populated(self, qapp_instance, tmp_path):
        from il2cpp_recovery_studio.gui.app import MainWindow
        import zipfile
        apk = tmp_path / "test.apk"
        with zipfile.ZipFile(str(apk), "w") as zf:
            zf.writestr("classes.dex", b"\x00" * 100)
        w = MainWindow()
        w._populate_file_tree(str(apk))
        assert w._file_tree.topLevelItemCount() > 0
        w._populate_overview_info(str(apk))
        assert w._overview_info.rowCount() > 0
        w.close()

    def test_filter_methods(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._filter_methods()
        w.close()

    def test_search_empty(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._search_input.setText("")
        w._perform_search()
        w.close()

    def test_populate_results_non_pipeline(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        w = MainWindow()
        w._populate_results("not_a_result")
        w.close()


class TestFormatSize:
    def test_bytes(self):
        from il2cpp_recovery_studio.gui.app import MainWindow
        assert MainWindow._format_size(100) == "100.0 B"

    def test_kilobytes(self):
        from il2cpp_recovery_studio.gui.app import MainWindow
        assert MainWindow._format_size(1024) == "1.0 KB"

    def test_megabytes(self):
        from il2cpp_recovery_studio.gui.app import MainWindow
        result = MainWindow._format_size(1024 * 1024)
        assert "MB" in result

    def test_gigabytes(self):
        from il2cpp_recovery_studio.gui.app import MainWindow
        result = MainWindow._format_size(1024 * 1024 * 1024)
        assert "GB" in result


class TestDarkMode:
    def test_stylesheet_applied(self, qapp_instance):
        from il2cpp_recovery_studio.gui.app import MainWindow
        from il2cpp_recovery_studio.gui.styles import DARK_STYLESHEET
        assert len(DARK_STYLESHEET) > 100
        assert "QMainWindow" in DARK_STYLESHEET
        assert "background-color" in DARK_STYLESHEET
        w = MainWindow()
        w.close()
