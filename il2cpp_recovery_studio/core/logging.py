from __future__ import annotations

import logging
import sys
from pathlib import Path
from typing import Optional

_MODULE_LOGGERS: dict[str, logging.Logger] = {}
_ROOT_CONFIGURED = False


def setup_logging(
    level: str = "INFO",
    log_file: Optional[Path] = None,
    verbose: bool = False,
) -> None:
    """Configure root logging with optional rich console output and file handler.

    Parameters
    ----------
    level:
        Minimum severity for console output (DEBUG, INFO, WARNING, ERROR, CRITICAL).
    log_file:
        If provided, a rotating file handler is also attached.
    verbose:
        Shortcut - when *True* the level is forced to DEBUG.
    """
    global _ROOT_CONFIGURED
    if _ROOT_CONFIGURED:
        return

    if verbose:
        level = "DEBUG"

    root = logging.getLogger("il2cpp_recovery")
    root.setLevel(getattr(logging, level.upper(), logging.INFO))

    try:
        from rich.console import Console
        from rich.logging import RichHandler

        handler = RichHandler(
            console=Console(stderr=True),
            show_time=True,
            show_path=False,
            rich_tracebacks=True,
        )
    except ImportError:
        handler = logging.StreamHandler(sys.stderr)
        fmt = logging.Formatter("%(asctime)s [%(levelname)s] %(name)s: %(message)s")
        handler.setFormatter(fmt)

    handler.setLevel(root.level)
    root.addHandler(handler)

    if log_file is not None:
        log_file.parent.mkdir(parents=True, exist_ok=True)
        file_handler = logging.FileHandler(str(log_file), encoding="utf-8")
        file_handler.setLevel(root.level)
        fmt = logging.Formatter("%(asctime)s [%(levelname)s] %(name)s: %(message)s")
        file_handler.setFormatter(fmt)
        root.addHandler(file_handler)

    _ROOT_CONFIGURED = True


def get_logger(name: str) -> logging.Logger:
    """Return a namespaced logger underneath the ``il2cpp_recovery`` hierarchy.

    Parameters
    ----------
    name:
        Module or component name, for example ``"apk.parser"``.
    """
    full_name = f"il2cpp_recovery.{name}"
    if full_name not in _MODULE_LOGGERS:
        _MODULE_LOGGERS[full_name] = logging.getLogger(full_name)
    return _MODULE_LOGGERS[full_name]
