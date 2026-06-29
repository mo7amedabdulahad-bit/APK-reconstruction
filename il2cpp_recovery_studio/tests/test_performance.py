"""Tests for Phase 19: Performance utilities."""
from __future__ import annotations

import os
import tempfile
import time

import pytest

from il2cpp_recovery_studio.performance.utils import (
    LRUCache,
    ParallelProcessor,
    PerformanceMetrics,
    TimedExecutor,
    DiskCache,
    compute_hash,
    file_hash,
)


class TestLRUCache:
    def test_put_get(self):
        c = LRUCache(max_size=5)
        c.put("a", 1)
        assert c.get("a") == 1

    def test_miss(self):
        c = LRUCache()
        assert c.get("missing") is None

    def test_eviction(self):
        c = LRUCache(max_size=3)
        c.put("a", 1)
        c.put("b", 2)
        c.put("c", 3)
        c.put("d", 4)
        assert c.size == 3
        assert c.get("a") is None

    def test_clear(self):
        c = LRUCache()
        c.put("x", 1)
        c.clear()
        assert c.size == 0

    def test_hit_rate(self):
        c = LRUCache()
        c.put("a", 1)
        c.get("a")
        c.get("a")
        c.get("missing")
        assert c.hit_rate > 0


class TestTimedExecutor:
    def test_time(self):
        executor = TimedExecutor()

        @executor.time("test_op")
        def do_work():
            time.sleep(0.01)
            return 42

        result = do_work()
        assert result == 42
        assert len(executor.metrics) == 1
        assert executor.metrics[0].duration_ms > 0

    def test_summary(self):
        executor = TimedExecutor()

        @executor.time("op")
        def work():
            pass

        work()
        work()
        summary = executor.summary()
        assert summary["total_operations"] == 2


class TestParallelProcessor:
    def test_process(self):
        processor = ParallelProcessor(max_workers=2)
        items = [1, 2, 3, 4]
        results = processor.process(items, lambda x: x * 2)
        assert results == [2, 4, 6, 8]

    def test_empty(self):
        processor = ParallelProcessor()
        results = processor.process([], lambda x: x)
        assert results == []


class TestHashing:
    def test_compute_hash(self):
        h = compute_hash(b"hello")
        assert len(h) == 64

    def test_file_hash(self):
        with tempfile.NamedTemporaryFile(delete=False, suffix=".txt") as f:
            f.write(b"test data")
            path = f.name
        try:
            h = file_hash(path)
            assert len(h) == 64
        finally:
            os.unlink(path)


class TestDiskCache:
    def test_put_get(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            cache = DiskCache(tmpdir)
            cache.put("key1", {"data": 42})
            result = cache.get("key1")
            assert result == {"data": 42}

    def test_miss(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            cache = DiskCache(tmpdir)
            assert cache.get("nope") is None

    def test_has(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            cache = DiskCache(tmpdir)
            assert not cache.has("key")
            cache.put("key", "val")
            assert cache.has("key")

    def test_clear(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            cache = DiskCache(tmpdir)
            cache.put("a", 1)
            cache.clear()
            assert cache.size == 0

    def test_size(self):
        with tempfile.TemporaryDirectory() as tmpdir:
            cache = DiskCache(tmpdir)
            cache.put("a", 1)
            cache.put("b", 2)
            assert cache.size == 2
