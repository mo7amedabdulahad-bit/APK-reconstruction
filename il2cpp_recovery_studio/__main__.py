"""CLI entry point for IL2CPP Recovery Studio.

When frozen (packaged as .exe), launches the GUI automatically.
When run as a script, supports --apk, --gui, --output flags.
Default is always the GUI.
"""
from __future__ import annotations

import sys
from pathlib import Path


def _is_frozen() -> bool:
    return getattr(sys, "frozen", False) and hasattr(sys, "_MEIPASS")


def main() -> None:
    # Always open GUI by default
    if _is_frozen():
        from il2cpp_recovery_studio.gui.app import run_gui
        run_gui()
        return

    import argparse

    parser = argparse.ArgumentParser(
        prog="il2cpp-recovery-studio",
        description="IL2CPP Recovery Studio - Unity APK analysis and recovery",
    )
    parser.add_argument("--apk", type=Path, help="Path to APK/XAPK file (CLI mode)")
    parser.add_argument("--output", type=Path, default=Path("output"), help="Output directory (CLI mode)")
    parser.add_argument("--gui", action="store_true", default=True,
                        help="Launch GUI (default)")
    parser.add_argument("--cli", action="store_true",
                        help="Run in CLI mode (requires --apk)")
    parser.add_argument("--reconstruct", action="store_true",
                        help="Run Phase 21 Unity Asset Reconstruction (CLI mode)")
    parser.add_argument("--verbose", "-v", action="store_true", help="Verbose output")
    parser.add_argument("--version", action="version", version="1.0.0")

    args = parser.parse_args()

    # Default: launch GUI
    if not args.cli:
        from il2cpp_recovery_studio.gui.app import run_gui
        run_gui()
        return

    # CLI mode
    if not args.apk:
        print("Error: --cli mode requires --apk <path>", file=sys.stderr)
        sys.exit(1)

    if not args.apk.exists():
        print(f"Error: APK not found: {args.apk}", file=sys.stderr)
        sys.exit(1)

    from il2cpp_recovery_studio.core.config import AppConfig
    from il2cpp_recovery_studio.core.logging import get_logger

    logger = get_logger("cli")

    config = AppConfig()
    config.verbose = args.verbose
    args.output.mkdir(parents=True, exist_ok=True)

    logger.info("Opening APK: %s", args.apk)

    from il2cpp_recovery_studio.apk.parser import APKParser

    apk_parser = APKParser()
    apk_info = apk_parser.parse(args.apk)

    print(f"Package: {apk_info.manifest.package_name}")
    print(f"Unity: {apk_info.unity_build.unity_version}")
    print(f"IL2CPP: {apk_info.has_il2cpp}")
    print(f"Architectures: {[a.name for a in apk_info.detected_architectures]}")

    from il2cpp_recovery_studio.recovery.orchestrator import RecoveryOrchestrator

    orch = RecoveryOrchestrator(config=config)
    result = orch.run(apk_info, output_dir=args.output)

    print(f"\nRecovery complete:")
    print(f"  Classes:  {result.classes_recovered}")
    print(f"  Methods:  {result.methods_recovered}")
    print(f"  Fields:   {result.fields_recovered}")
    print(f"  Time:     {result.total_time_ms:.0f}ms")

    if result.errors:
        print(f"\nErrors:")
        for err in result.errors:
            print(f"  - {err}")

    if args.reconstruct:
        print("\n--- Phase 21: Intelligent Asset Reconstruction ---")
        from il2cpp_recovery_studio.unity_assets.orchestrator import UnityAssetReconstructor

        asset_output = args.output / "RecoveredProject"
        reconstructor = UnityAssetReconstructor(
            output_dir=asset_output,
            verbose=args.verbose,
        )

        recovered_classes = []
        if hasattr(result, 'classes') and result.classes:
            recovered_classes = result.classes

        asset_result = reconstructor.reconstruct(args.apk, recovered_classes)

        print(f"\nAsset Reconstruction complete:")
        print(f"  Assets:     {asset_result.total_assets}")
        print(f"  Sprites:    {asset_result.total_sprites_extracted}")
        print(f"  Categories: {len(asset_result.categories)}")
        print(f"  Features:   {len(asset_result.feature_groups)}")
        print(f"  Relations:  {asset_result.relationships_mapped}")
        print(f"  Duplicates: {asset_result.duplicates_found}")
        print(f"  Output:     {asset_output}")


if __name__ == "__main__":
    main()
