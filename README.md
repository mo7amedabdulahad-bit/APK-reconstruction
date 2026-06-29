# Travian Legends Mobile — IL2CPP Reverse Engineering

Reverse engineering of **Travian Legends Mobile v3.13.0** (Unity IL2CPP, Metadata v39 / Unity 6000.x).

## Results

| Metric | Value |
|--------|-------|
| C# files generated | **5,019** |
| Methods mapped | **143,813** |
| Game methods (TLMobile.dll) | **32,842** |
| Framework methods (TGFramework.dll) | **3,818** |
| Unique game classes | **3,971** |
| Ghidra functions decompiled | **2,674** |
| Methods cross-referenced | **403** |
| Extracted assets | **22,658 files** |
| Localization strings | **12,529 (en-US)** |

## Project Structure

```
├── COMPREHENSIVE_REVERSE_ENGINEERING_REPORT.md   ← Full report (start here)
├── RecoveredSource/
│   ├── IL2CPP_Annotated/        2,391 C# files with method addresses
│   ├── IL2CPP_Extracted/        2,544 type stubs from metadata
│   ├── IL2CPP_Decompiled/       403 methods with decompiled ARM64 code
│   └── TLMobile/Scripts/        28 manually reconstructed files
├── extracted_assets/
│   ├── localization/            136 language files (12,529 en-US strings)
│   ├── MonoBehaviours/          4,769 JSON files
│   ├── Config/                  Settings, manifests, Firebase config
│   └── Data/                    Game data files
├── metadata_output/             Structured metadata JSONs
├── tools/                       Analysis scripts (Python/Java)
└── il2cpp_recovery_studio/      Recovery tooling (Python)
```

## Tools Used

### Required (must install manually)

| Tool | Version | Purpose | Download |
|------|---------|---------|----------|
| **Il2CppInspectorRedux** | 2026.2 | IL2CPP metadata extraction (v39) | [GitHub](https://github.com/djkaty/Il2CppInspector) |
| **Ghidra** | 12.1.2 | ARM64 binary decompilation | [ghidra-sre.org](https://ghidra-sre.org/) |
| **Java (JDK)** | 21+ | Runtime for Ghidra | [Amazon Corretto](https://docs.aws.amazon.com/corretto/) |
| **Python** | 3.10+ | Data processing scripts | [python.org](https://python.org) |

### Why these specific tools?

- **Il2CppDumper v6.7.46** and **Cpp2IL v2022.0.7** do NOT support metadata v39 (Unity 6000.x). They max out at v31.
- **Il2CppInspectorRedux 2026.2** is the only tool that supports the v39 header format (`Il2CppSectionMetadata` structs).
- **Ghidra** is used for ARM64 decompilation of `libil2cpp.so`.

### What was NOT included (too large for git)

| File | Size | Purpose |
|------|------|---------|
| `tools/ghidra_12.1.2_PUBLIC/` | 872 MB | Ghidra installation |
| `tools/jdk21.0.11_10/` | 328 MB | Java runtime |
| `tools/libil2cpp.so` | 95 MB | ARM64 binary (extracted from APK) |
| `tools/il2cpp_metadata_with_addresses/il2cpp.json` | 174 MB | Full metadata dump |
| `extracted_assets/Images/` | 792 MB | Extracted images |
| `extracted_assets/Sprites/` | 645 MB | Extracted sprites |

These files are generated during the analysis process. See the full report for instructions on regenerating them.

## Quick Start

1. Read `COMPREHENSIVE_REVERSE_ENGINEERING_REPORT.md` for the full analysis
2. Browse `RecoveredSource/IL2CPP_Annotated/` for annotated C# source with method addresses
3. Browse `RecoveredSource/TLMobile/Scripts/` for manually reconstructed code with confidence scores
4. Check `extracted_assets/localization/common/en-US.txt` for 12,529 game strings

## Key Game Systems

| System | Classes | Description |
|--------|---------|-------------|
| Village Management | OwnVillage, Village, Building | Building construction, demolition |
| Hero System | OwnHero, HeroEquipment, HeroAppearance | Hero leveling, equipment, inventory |
| Combat | CombatSimulator, AttackType, BattleReport | Attack, raid, reinforcement, scouting |
| Alliance | OwnAlliance, Alliance | Membership, diplomacy, war |
| Economy | ResourceAmounts, AuctionItem, FarmList | Resources, auction, farming |
| UI Framework | 325 controller classes | Windows, popups, notifications |
| Networking | GraphQL, RestAPI, WebSocket | API calls, real-time updates |

## Metadata Version

This project targets **metadata version 39** (Unity 6000.x / Unity 6), which uses a new header format:

```
Header: 8 bytes header + 31 × 12 bytes sections = 380 bytes
Section format: Offset (int32) + SectionSize (int32) + Count (int32)
Index sizes: TypeDefinitionIndex=2, GenericContainerIndex=2, TypeIndex=2, ParameterIndex=4
```

## License

This project is for educational and research purposes only. Travian Legends Mobile is © Travian Games GmbH.

## Author

[@mo7amedabdulahad-bit](https://github.com/mo7amedabdulahad-bit)
