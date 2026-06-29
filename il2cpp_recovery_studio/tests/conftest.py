"""Shared test configuration for il2cpp_recovery_studio."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.core.logging import setup_logging


@pytest.fixture(autouse=True, scope="session")
def _setup_test_logging() -> None:
    """Configure logging once for all tests."""
    setup_logging(level="WARNING")
