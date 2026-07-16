"""String analysis engine: extracts and categorizes strings from recovered Unity code."""
from __future__ import annotations

import re

from il2cpp_recovery_studio.core.logging import get_logger
from il2cpp_recovery_studio.strings.models import (
    ExtractedString,
    StringAnalysisResult,
    StringCategory,
)
from il2cpp_recovery_studio.recovery.models import RecoveredClass, RecoveredField

logger = get_logger("strings.analyzer")

URL_RE = re.compile(r'https?://[^\s"\'<>\]\)]+')
JSON_RE = re.compile(r'[\[{].*[\]}]|\{.*\}')
SQL_RE = re.compile(r'(?i)\b(?:SELECT|INSERT|UPDATE|DELETE|FROM|WHERE|JOIN)\b')
API_KEY_RE = re.compile(r'(?i)(?:api[_-]?key|apikey|secret|token)\s*[=:]\s*["\'][^"\']+["\']')
SCENE_RE = re.compile(r'(?i)(?:scene|level|map)\s*[=:]\s*["\'][^"\']+["\']')
ERROR_RE = re.compile(r'(?i)(?:error|exception|fail|crash|fatal|panic)')
DEBUG_RE = re.compile(r'(?i)(?:debug|log|print|trace|verbose|dump)')
LOCALIZATION_RE = re.compile(r'(?i)(?:locali[sz]|i18n|l10n|translate|text|label|caption)')
FILE_PATH_RE = re.compile(r'(?i)(?:\.json|\.xml|\.csv|\.txt|\.dat|\.asset|\.bundle|resources/|assets/)')
EVENT_RE = re.compile(r'(?i)(?:on[A-Z]\w+|Event\s*\(|UnityEvent|Action<|Func<)')

KNOWN_SCENES = {"MainMenu", "LoadingScene", "LoginScene", "GameScene", "BattleScene", "ShopScene"}

UNITY_PREFIXES = ("UnityEngine.", "UnityEditor.", "TMPro.", "TextMeshPro")


class StringAnalyzer:
    """Analyzes recovered Unity classes for string patterns."""

    def analyze(
        self, recovered_classes: list[RecoveredClass]
    ) -> StringAnalysisResult:
        result = StringAnalysisResult()

        for rc in recovered_classes:
            self._analyze_class(rc, result)

        result.compute_statistics()
        logger.info(
            "String analysis: %d strings, %d unique, %d categories",
            result.total_strings,
            result.unique_strings,
            len(result.statistics) - 2,
        )
        return result

    def _analyze_class(self, rc: RecoveredClass, result: StringAnalysisResult) -> None:
        full_class = f"{rc.namespace}.{rc.name}" if rc.namespace else rc.name

        for field in rc.fields:
            if field.default_value:
                cat = self._categorize(field.default_value)
                result.strings.append(ExtractedString(
                    value=field.default_value,
                    category=cat,
                    confidence=0.7,
                    source_class=full_class,
                    source_method="(field)",
                    metadata_token=field.token,
                ))

        for method in rc.methods:
            self._analyze_method(rc, method, full_class, result)

    def _analyze_method(
        self, rc: RecoveredClass, method, full_class: str, result: StringAnalysisResult
    ) -> None:
        text = method.name

        string_literals = re.findall(r'"([^"]*)"', text)
        for s in string_literals:
            if len(s) > 0:
                cat = self._categorize(s)
                result.strings.append(ExtractedString(
                    value=s,
                    category=cat,
                    confidence=0.8,
                    source_class=full_class,
                    source_method=method.name,
                    address=method.native_address,
                ))

    def _categorize(self, value: str) -> StringCategory:
        if URL_RE.search(value):
            return StringCategory.URL
        if SQL_RE.search(value):
            return StringCategory.SQL
        if API_KEY_RE.search(value):
            return StringCategory.API_KEY
        if ERROR_RE.search(value):
            return StringCategory.ERROR
        if DEBUG_RE.search(value):
            return StringCategory.DEBUG
        if LOCALIZATION_RE.search(value):
            return StringCategory.LOCALIZATION
        if FILE_PATH_RE.search(value):
            return StringCategory.FILE_PATH
        if EVENT_RE.search(value):
            return StringCategory.UNITY_EVENT
        if any(scene in value for scene in KNOWN_SCENES):
            return StringCategory.SCENE_NAME
        if value.startswith(UNITY_PREFIXES):
            return StringCategory.CLASS_NAME
        try:
            if JSON_RE.fullmatch(value):
                return StringCategory.JSON
        except re.error:
            pass
        return StringCategory.UNKNOWN
