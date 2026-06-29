"""Unit tests for the logging module."""
from __future__ import annotations

import logging
from pathlib import Path

from il2cpp_recovery_studio.core.logging import get_logger, setup_logging


class TestLogging:
    def test_get_logger_returns_logger(self) -> None:
        logger = get_logger("test.module")
        assert isinstance(logger, logging.Logger)
        assert logger.name == "il2cpp_recovery.test.module"

    def test_get_logger_caches(self) -> None:
        l1 = get_logger("cached")
        l2 = get_logger("cached")
        assert l1 is l2

    def test_setup_logging_idempotent(self, tmp_path: Path) -> None:
        setup_logging(level="DEBUG")
        setup_logging(level="WARNING")
        logger = get_logger("idempotent_test")
        assert logger is not None

    def test_setup_with_file(self, tmp_path: Path) -> None:
        import logging as _logging

        log_file = tmp_path / "test.log"
        # Reset the module-level flag so setup_logging re-runs
        import il2cpp_recovery_studio.core.logging as _mod

        old = _mod._ROOT_CONFIGURED
        _mod._ROOT_CONFIGURED = False
        try:
            setup_logging(level="INFO", log_file=log_file)
            logger = get_logger("file_test")
            logger.info("test message")
            assert log_file.exists()
        finally:
            _mod._ROOT_CONFIGURED = old
