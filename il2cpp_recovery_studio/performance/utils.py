"""Performance utilities: caching, timed execution, and parallel processing."""
from __future__ import annotations

import functools
import hashlib
import json
import os
import time
from concurrent.futures import ThreadPoolExecutor, as_completed
from dataclasses import dataclass, field
from pathlib import Path
from typing import Any, Callable

from il2cpp_recovery_studio.core.logging import get_logger

logger = get_logger("performance")


@dataclass
class CacheEntry:
    """A single cache entry."""

    key: str
    value: Any = None
    created_at: float = 0.0
    hit_count: int = 0


@dataclass
class PerformanceMetrics:
    """Performance metrics for an operation."""

    operation: str = ""
    duration_ms: float = 0.0
    memory_bytes: int = 0
    items_processed: int = 0
    throughput: float = 0.0
    errors: int = 0


class LRUCache:
    """Simple LRU cache with eviction."""

    def __init__(self, max_size: int = 1000) -> None:
        self._max_size = max_size
        self._cache: dict[str, CacheEntry] = {}

    def get(self, key: str) -> Any | None:
        entry = self._cache.get(key)
        if entry:
            entry.hit_count += 1
            return entry.value
        return None

    def put(self, key: str, value: Any) -> None:
        if len(self._cache) >= self._max_size:
            oldest = min(self._cache, key=lambda k: self._cache[k].created_at)
            del self._cache[oldest]
        self._cache[key] = CacheEntry(
            key=key, value=value, created_at=time.time()
        )

    def clear(self) -> None:
        self._cache.clear()

    @property
    def size(self) -> int:
        return len(self._cache)

    @property
    def hit_rate(self) -> float:
        total = sum(e.hit_count for e in self._cache.values())
        return total / max(len(self._cache), 1)


class TimedExecutor:
    """Measures execution time of operations."""

    def __init__(self) -> None:
        self._metrics: list[PerformanceMetrics] = []

    def time(self, operation: str) -> Callable:
        def decorator(func: Callable) -> Callable:
            @functools.wraps(func)
            def wrapper(*args, **kwargs):
                start = time.perf_counter()
                errors = 0
                try:
                    result = func(*args, **kwargs)
                except Exception:
                    errors += 1
                    raise
                finally:
                    duration = (time.perf_counter() - start) * 1000
                    self._metrics.append(PerformanceMetrics(
                        operation=operation,
                        duration_ms=duration,
                        errors=errors,
                    ))
                return result
            return wrapper
        return decorator

    @property
    def metrics(self) -> list[PerformanceMetrics]:
        return list(self._metrics)

    def summary(self) -> dict[str, float]:
        if not self._metrics:
            return {}
        durations = [m.duration_ms for m in self._metrics]
        return {
            "total_operations": len(durations),
            "total_ms": sum(durations),
            "avg_ms": sum(durations) / len(durations),
            "min_ms": min(durations),
            "max_ms": max(durations),
        }


class ParallelProcessor:
    """Processes items in parallel using thread pool."""

    def __init__(self, max_workers: int = 4) -> None:
        self._max_workers = max_workers

    def process(
        self, items: list[Any], func: Callable, **kwargs
    ) -> list[Any]:
        results: list[Any] = [None] * len(items)

        with ThreadPoolExecutor(max_workers=self._max_workers) as executor:
            future_to_idx = {
                executor.submit(func, item, **kwargs): i
                for i, item in enumerate(items)
            }
            for future in as_completed(future_to_idx):
                idx = future_to_idx[future]
                try:
                    results[idx] = future.result()
                except Exception as e:
                    logger.error("Parallel task %d failed: %s", idx, e)
                    results[idx] = None

        return results


def file_hash(path: str) -> str:
    """Compute SHA256 hash of a file."""
    h = hashlib.sha256()
    with open(path, "rb") as f:
        for chunk in iter(lambda: f.read(8192), b""):
            h.update(chunk)
    return h.hexdigest()


def compute_hash(data: bytes) -> str:
    """Compute SHA256 hash of bytes."""
    return hashlib.sha256(data).hexdigest()


class DiskCache:
    """File-system-based cache for large objects."""

    def __init__(self, cache_dir: str) -> None:
        self._dir = Path(cache_dir)
        self._dir.mkdir(parents=True, exist_ok=True)

    def get(self, key: str) -> Any | None:
        path = self._dir / f"{key}.json"
        if path.exists():
            return json.loads(path.read_text(encoding="utf-8"))
        return None

    def put(self, key: str, value: Any) -> None:
        path = self._dir / f"{key}.json"
        path.write_text(json.dumps(value), encoding="utf-8")

    def has(self, key: str) -> bool:
        return (self._dir / f"{key}.json").exists()

    def clear(self) -> None:
        for f in self._dir.glob("*.json"):
            f.unlink()

    @property
    def size(self) -> int:
        return sum(1 for _ in self._dir.glob("*.json"))
