# IL2CPP Reverse Engineering Report - Phase 26 Complete
## Travian Legends Mobile v3.13.0 (Unity IL2CPP, Metadata v39)

---

### Executive Summary
Successfully extracted and reconstructed C# source code from IL2CPP metadata v39 (Unity 6000.x). **9,953 C# files** generated across multiple extraction methods. Full method signatures and addresses mapped for 143,813 methods. Ghidra headless decompilation achieved partial results (2,674 functions from non-game assemblies).

---

### Tool Results

| Tool | Version | v39 Support | Result |
|------|---------|-------------|--------|
| Il2CppDumper | 6.7.46 | No (v16-v31) | Failed |
| Cpp2IL | 2022.0.7 | No | Failed |
| **Il2CppInspectorRedux** | **2026.2** | **Yes** | **Success** |
| Ghidra | 12.1.2 | Partial | 2,674 functions (non-game) |

### Metadata Statistics

| Metric | Count |
|--------|-------|
| Metadata version | 39.0-TypeDefinitionIndex2_GenericContainerIndex2_TypeIndex2_ParameterIndex4 |
| Total types | 22,237 |
| Total methods | 143,813 |
| Total fields | 84,759 |
| Total parameters | 157,526 |
| Total strings | 134,433 |
| Images | 160 |
| Assemblies | 175 |
| Unique classes | 737 |

---

### Generated Output Summary

| Directory | Files | Size | Content |
|-----------|-------|------|---------|
| **IL2CPP_Annotated** | 2,391 | 5.2 MB | Full C# classes with method addresses, signatures, properties |
| **IL2CPP_Extracted** | 2,544 | - | Basic type stubs from Il2CppInspectorRedux |
| **IL2CPP_Decompiled** | 1 | 176 KB | 403 methods with decompiled ARM64 C code |
| **RecoveredSource** | 83 | 3.5 MB | Manually reconstructed types with confidence scores |
| **Total C# files** | **9,953** | **8.8 MB** | |

---

### Method Count by Assembly (Top 20)

| Assembly | Methods | Description |
|----------|---------|-------------|
| TLMobile.dll | 32,842 | **Main game assembly** |
| com.Tivadar.Best.HTTP.dll | 19,629 | HTTP networking |
| mscorlib.dll | 11,146 | .NET runtime |
| UnityEngine.UIElementsModule.dll | 10,227 | UI framework |
| System.Xml.dll | 7,092 | XML processing |
| BouncyCastle.Crypto.dll | 6,059 | Cryptography |
| RestAPI.dll | 5,849 | REST API client |
| System.dll | 5,438 | .NET base |
| TGFramework.dll | 3,818 | **Game framework** |
| UnityEngine.CoreModule.dll | 3,757 | Unity core |
| System.Data.dll | 3,138 | Data access |
| System.Core.dll | 2,864 | .NET core |
| GraphAndChart.dll | 2,825 | Charting library |
| Newtonsoft.Json.dll | 2,104 | JSON serialization |
| AdvancedInputField.dll | 1,937 | Custom input field |
| UnityEngine.UI.dll | 1,853 | Unity UI |
| Unity.TextMeshPro.dll | 1,751 | Text rendering |
| Facebook.Unity.dll | 1,143 | Facebook SDK |
| DOTween.dll | 1,077 | Animation tweening |
| UnityEngine.TextCoreTextEngineModule.dll | 826 | Text engine |

---

### Top Game Classes (by method count)

| Class | Methods | Namespace |
|-------|---------|-----------|
| OwnVillage | 170 | TLMobile.Generated.GraphQL.Game |
| OwnHero | 151 | TLMobile.Generated.GraphQL.Game |
| DebugMenuPopupController | 150 | TLMobile.Scripts.UIComponents.Popups.Debug |
| Village | 128 | TLMobile.Generated.GraphQL.Game |
| OwnPlayer | 127 | TLMobile.Generated.GraphQL.Game |
| ServerSupportedFeatures | 126 | TLMobile.Generated.GraphQL.Game |
| OwnAlliance | 117 | TLMobile.Generated.GraphQL.Game |
| MapCellInfoWindowController | 116 | TLMobile.Scripts.UIComponents.Windows |
| InventoryItemWrapper | 114 | TLMobile.Scripts.DataManagementHelpers |
| HeroInventoryItem | 111 | TLMobile.Generated.GraphQL.Game |

---

### Game Configuration

| Setting | Value |
|---------|-------|
| Package | com.traviangames.travianlegendsmobile |
| Firebase | travian-legends-f5595 |
| Addressables | v2.9.1 |
| Unity Purchasing | v4.14.2 |
| Unity Authentication | v3.6.0 |
| Remote Config | v4.0.4 |
| Target SDK | Android (API 16+) |
| Max concurrent web requests | 500 |

---

### Localization

- **136 language files** in `extracted_assets/localization/common/`
- **12,529 English strings** covering game mechanics
- Key systems: attacks, troops, villages, resources, heroes, alliances, auctions

---

### Ghidra Decompilation

- **2,674 functions** decompiled from libil2cpp.so (ARM64)
- **403 methods** cross-referenced with IL2CPP metadata (AdvancedInputField: 346, AppsFlyer: 57)
- **IL2CPP methods unreachable**: TLMobile/TGFramework methods accessed via CodeRegistration function pointers not discoverable through standard Ghidra analysis
- **Root cause**: IL2CPP methods are registered at runtime through `CodeRegistration` struct, not through standard function prologues

---

### Output Files

```
RecoveredSource/
├── IL2CPP_Annotated/          (2,391 files, 5.2 MB) - Phase 26
│   ├── TLMobile/              (2,138 files)
│   │   ├── Scripts/           (UI controllers, services, etc.)
│   │   └── Generated/         (GraphQL types)
│   ├── TGFramework/           (39 files)
│   └── Other/                 (214 files)
├── IL2CPP_Extracted/          (2,544 files) - Phase 25
├── IL2CPP_Decompiled/         (1 file, 176 KB) - Phase 26
├── TLMobile/Scripts/          (32 files, 128 KB) - Phase 24
├── TGFramework/               (4 files)
└── RECONSTRUCTION_REPORT_PHASE26.md

tools/
├── il2cpp_metadata_with_addresses/
│   ├── il2cpp.json            (174 MB) - Full metadata with addresses
│   ├── il2cpp.h               (85 MB) - C++ type definitions
│   └── il2cpp.py              (23 KB) - IDA script
├── method_address_map.txt     (pipe-delimited, 143K methods)
├── method_address_map_quick.json (address lookup)
├── decompiled_il2cpp.txt      (20.5 MB, 2,674 methods)
├── decompiled_methods.txt     (3.3 MB, 1,874 functions)
├── Il2CppInspectorRedux/      (tool)
├── ghidra_12.1.2_PUBLIC/      (tool)
├── ghidra_project2/           (analyzed binary)
└── jdk21.0.11_10/             (Java runtime)

extracted_assets/
├── Animations/                (12 files)
├── Config/                    (6 files)
├── Data/                      (37 files)
├── Images/                    (1,290 files)
├── localization/              (136 files, 12,529 en-US strings)
├── Materials/                 (88 files)
├── MonoBehaviours/            (4,769 files)
├── Other/                     (7 files)
├── Prefabs/                   (5,588 files)
├── Scripts/                   (4 files)
├── Shaders/                   (6 files)
├── SpriteAtlases/             (129 files)
└── Sprites/                   (10,586 files)
```

---

### Known Limitations

1. **Constructor detection**: Some static factory methods may be misclassified as constructors
2. **Generic types**: IL2CPP generic notation (e.g., `ObservableList\`1[...]`) preserved as-is
3. **Method bodies**: All methods are stubs (`{ return default; }`) - require native decompilation
4. **Ghidra coverage**: Only non-game assemblies fully decompiled (AdvancedInputField, AppsFlyer)
5. **IL2CPP type names**: Some complex types (delegates, generics) use IL2CPP naming

### Next Steps

1. **Targeted decompilation**: Use Ghidra GUI for specific critical game methods
2. **GraphQL API documentation**: Parse type metadata for full API schema
3. **Runtime analysis**: Use Frida/instrumentation to capture method behavior
4. **Asset catalog parsing**: Decode Addressables catalog.bin for asset references
5. **Type hierarchy**: Generate complete class inheritance diagram
