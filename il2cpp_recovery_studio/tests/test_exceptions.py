"""Unit tests for the exception hierarchy."""
from __future__ import annotations

import pytest

from il2cpp_recovery_studio.core.exceptions import (
    APKCorruptedError,
    APKError,
    APKNotFoundError,
    APKValidationError,
    BinaryAnalysisError,
    IL2CPPRecoveryError,
    MetadataError,
    ToolExecutionError,
    UnityDetectionError,
)


class TestExceptionHierarchy:
    def test_apk_errors_inherit(self) -> None:
        assert issubclass(APKError, IL2CPPRecoveryError)
        assert issubclass(APKNotFoundError, APKError)
        assert issubclass(APKValidationError, APKError)
        assert issubclass(APKCorruptedError, APKError)

    def test_other_errors_inherit(self) -> None:
        assert issubclass(UnityDetectionError, IL2CPPRecoveryError)
        assert issubclass(ToolExecutionError, IL2CPPRecoveryError)
        assert issubclass(MetadataError, IL2CPPRecoveryError)
        assert issubclass(BinaryAnalysisError, IL2CPPRecoveryError)

    def test_exceptions_are_catchable(self) -> None:
        with pytest.raises(IL2CPPRecoveryError):
            raise APKNotFoundError("missing.apk")

        with pytest.raises(APKError):
            raise APKValidationError("bad zip")

    def test_message_preserved(self) -> None:
        err = APKCorruptedError("file is corrupt")
        assert str(err) == "file is corrupt"
