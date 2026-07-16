from __future__ import annotations


class IL2CPPRecoveryError(Exception):
    """Base exception for all IL2CPP Recovery Studio errors."""


class APKError(IL2CPPRecoveryError):
    """APK-level error."""


class APKNotFoundError(APKError):
    """The specified APK file does not exist."""


class APKValidationError(APKError):
    """The file is not a valid ZIP / APK archive."""


class APKCorruptedError(APKError):
    """The APK archive is corrupted or unreadable."""


class UnityDetectionError(IL2CPPRecoveryError):
    """Failed to detect Unity build characteristics."""


class ToolExecutionError(IL2CPPRecoveryError):
    """An external tool (Cpp2IL, Il2CppDumper, Ghidra …) failed."""


class MetadataError(IL2CPPRecoveryError):
    """Error recovering or parsing IL2CPP metadata."""


class BinaryAnalysisError(IL2CPPRecoveryError):
    """Error analysing native binaries."""


class AssetError(IL2CPPRecoveryError):
    """Error extracting or parsing Unity assets."""


class GraphError(IL2CPPRecoveryError):
    """Error generating or rendering a graph."""


class PluginError(IL2CPPRecoveryError):
    """Plugin system error."""
