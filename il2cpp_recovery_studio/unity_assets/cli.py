"""CLI entry point for Unity Asset Reconstruction."""

from __future__ import annotations

import argparse
import sys
from pathlib import Path


def main():
    """Main CLI entry point."""
    parser = argparse.ArgumentParser(
        description="Unity Asset Reconstruction Engine - Phase 21",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Examples:
  python -m unity_assets --apk game.xapk --output ./recovered
  python -m unity_assets --apk game.apk --output ./out --verbose
  python -m unity_assets --help
        """
    )

    parser.add_argument(
        "--apk", "-a",
        type=Path,
        required=True,
        help="Path to APK or XAPK file"
    )
    parser.add_argument(
        "--output", "-o",
        type=Path,
        default=Path("./RecoveredProject"),
        help="Output directory (default: ./RecoveredProject)"
    )
    parser.add_argument(
        "--verbose", "-v",
        action="store_true",
        help="Enable verbose output"
    )
    parser.add_argument(
        "--version",
        action="version",
        version="Unity Asset Reconstruction Engine v21.0.0"
    )

    args = parser.parse_args()

    if not args.apk.exists():
        print(f"Error: APK file not found: {args.apk}")
        sys.exit(1)

    # Import here to avoid circular imports
    from .orchestrator import UnityAssetReconstructor

    reconstructor = UnityAssetReconstructor(
        output_dir=args.output,
        verbose=args.verbose,
    )

    result = reconstructor.reconstruct(args.apk)

    print(f"\nReconstruction complete!")
    print(f"  Output: {args.output}")
    print(f"  Assets: {result.total_assets}")
    print(f"  Sprites: {result.total_sprites_extracted}")
    print(f"  Features: {len(result.feature_groups)}")


if __name__ == "__main__":
    main()
