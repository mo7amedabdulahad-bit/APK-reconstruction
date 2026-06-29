# IL2CPP Metadata Reconstruction Report - Phase 25

## Summary
Successfully extracted real IL2CPP metadata from Travian Legends Mobile v3.13.0 using 
Il2CppInspectorRedux v2026.2 (supports metadata version 39 / Unity 6000.x).

## Tool Chain
| Tool | Version | Purpose | Status |
|------|---------|---------|--------|
| Il2CppInspectorRedux | 2026.2 | Metadata v39 extraction | SUCCESS |
| Il2CppDumper | 6.7.46 | Metadata extraction | FAILED (max v31) |
| Cpp2IL | 2022.0.7 | Metadata extraction | FAILED (max v31) |
| Ghidra | N/A | Native decompilation | PENDING (needs Java) |

## Metadata Statistics
| Metric | Count |
|--------|-------|
| Metadata version | 39 (Unity 6000.x) |
| Index sizes | TypeDef=2, GenericContainer=2, TypeIndex=2, ParameterIndex=4 |
| Total game types | 2,544 |
| Total namespaces | 139 |
| Enums | 153 |
| Classes | 2,317 |
| Interfaces | 66 |
| Service types | 76 |
| Controller classes | 325 |

## Key Game Types Recovered (24/24 found)
| Type | Namespace | Kind | Fields | Props | Methods |
|------|-----------|------|--------|-------|---------|
| TribeId | OwnPlayer (nested) | enum | - | - | - |
| AttackType | TLMobile.Scripts.Enums | enum | - | - | - |
| HeroRarity | TLMobile.Scripts.Enums | enum | - | - | - |
| HeroQuality | TLMobile.Scripts.Enums | enum | - | - | - |
| ResourceAmounts | TLMobile.Scripts.DataManagementHelpers | class | 34 | 7 | 19 |
| TroopInfo | TLMobile.Scripts.DataManagementHelpers | class | 48 | 14 | 15 |
| SendTroopInfo | TLMobile.Scripts.DataManagementHelpers | class | 42 | 15 | 12 |
| HeroAppearance | TLMobile.Generated.GraphQL.Game | class | 44 | 15 | 12 |
| HeroEquipment | TLMobile.Generated.GraphQL.Game | class | 68 | 18 | 29 |
| CombatSimulatorParticipant | TLMobile.Scripts.UIComponents.Popups.CombatSimulator | class | 62 | 22 | 16 |
| AuctionItem | TLMobile.Generated.GraphQL.Game | class | 73 | 16 | 37 |
| Building | TLMobile.Generated.GraphQL.Game | class | 42 | 8 | 23 |
| Village | TLMobile.Generated.GraphQL.Game | class | 127 | 24 | 63 |
| OwnPlayer | TLMobile.Generated.GraphQL.Game | class | 127 | 38 | 51 |
| OwnVillage | TLMobile.Generated.GraphQL.Game | class | 170 | 54 | 62 |
| CombatSimulatorController | TLMobile.Scripts.UIComponents.Popups.CombatSimulator | class | 38 | 6 | 22 |
| BuildingDetailWindowController | TLMobile.Scripts.UIComponents.Windows | class | 45 | 13 | 15 |
| DemolishBuildingPopupController | TLMobile.Scripts.UIComponents.Windows.MainBuilding | class | 50 | 8 | 19 |
| ArrangementPopupController | TLMobile.Scripts.UIComponents.Windows.MainBuilding | class | 71 | 10 | 28 |
| RallyPointTroopsOverviewDetailsController | TLMobile.Scripts.UIComponents.Windows.RallyPoint | class | 48 | 6 | 33 |
| InventoryController | TLMobile.Scripts.UIComponents.Windows | class | 43 | 9 | 19 |
| DetailWindowsShowController | TLMobile.Scripts.MainUI | class | 54 | 2 | 48 |
| UnityMainThreadDispatcher | TLMobile.Scripts.Services | class | 11 | 1 | 5 |

## Output Files
`
RecoveredSource/IL2CPP_Extracted/     2,544 .cs files (real metadata)
metadata_output/game_types.json       Structured JSON of all game types
metadata_output/all_types.json        All 14,105 types (game + framework)
metadata_output/il2cpp_metadata_dump.json  Comprehensive metadata dump
tools/Il2CppInspectorRedux/           CLI tool (supports v39)
tools/il2cpp_inspector_output/cs/     Full 425K-line C# stub dump
tools/libil2cpp.so                    ARM64 native binary (95.4 MB)
`

## Top Game Namespaces
| Namespace | Types |
|-----------|-------|
| TLMobile.Generated.GraphQL.Game | 849 |
| TLMobile.GraphQL.DTO.Game | 401 |
| TGFramework | 126 |
| TLMobile.Scripts.Utilities | 101 |
| TLMobile.Generated.GraphQL.Lobby | 50 |
| TLMobile.Scripts.Enums | 47 |
| TLMobile.Scripts.Interfaces.Services | 44 |
| TLMobile.Scripts.DataManagementHelpers | 42 |
| TLMobile.Scripts.LoginUI.CAMS | 41 |
| TLMobile.Scripts.BBCodes | 35 |
| TLMobile.Scripts.Services | 35 |

## v39 Header Format (Key Discovery)
For metadata v38+, the header uses `Il2CppSectionMetadata` structs (12 bytes each: 
Offset + SectionSize + Count) instead of raw (offset, size) pairs. This is why 
Il2CppDumper v6.7.46 failed - it assumes the old header format.

## Remaining Work
1. **Native Decompilation**: Install Java + Ghidra to decompile method bodies from libil2cpp.so
2. **Method Implementations**: Add real C# implementations from decompiled ARM64 code
3. **API Documentation**: Cross-reference GraphQL types with ScriptingAssemblies.txt
4. **Addressable Catalogs**: Parse Addressables v2.9.1 catalogs for asset references
