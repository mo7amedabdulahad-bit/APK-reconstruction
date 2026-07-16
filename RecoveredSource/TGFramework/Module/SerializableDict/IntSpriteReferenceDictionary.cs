// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TGFramework/Module/SerializableDict/IntSpriteReferenceDictionary.cs
// ============================================================================
//
// Reconstructed from: link.xml preservation rules
// Confidence: 90%
// Evidence:
//   - link.xml: "TGFramework.IntSpriteReferenceDictionary" preserved
//   - TGFramework.Module.SerializableDict assembly in ScriptingAssemblies.txt
//   - Assembly: TGFramework.Module.SerializableDict.dll
// ============================================================================

using System;
using System.Collections.Generic;
using UnityEngine;

namespace TGFramework
{
    /// <summary>
    /// Serializable dictionary mapping integer keys to SpriteReferenceCfg values.
    /// Confidence: 90%
    /// Evidence: link.xml preservation, assembly reference
    /// </summary>
    [Serializable]
    public class IntSpriteReferenceDictionary : Dictionary<int, SpriteReferenceCfg>
    {
        // Unknown - specific serialization implementation
        // Unity typically requires custom serialization for Dictionary types
        // Likely uses a backing array for Unity serialization
    }
}
