// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TGFramework/MaterialColorSetter.cs
// ============================================================================
//
// Reconstructed from: RuntimeInitializeOnLoads initialization chain
// Confidence: 85%
// Evidence:
//   - RuntimeInitializeOnLoads.json: assembly="TGFramework",
//     namespace="TGFramework", class="MaterialColorSetter", method="Init",
//     loadTypes=4 (AfterSceneLoad)
//   - TGFramework assembly in ScriptingAssemblies.txt
//   - Assembly: TGFramework.dll
// ============================================================================

using UnityEngine;

namespace TGFramework
{
    /// <summary>
    /// Material color setter utility initialized at runtime.
    /// Confidence: 85%
    /// Evidence: RuntimeInitializeOnLoads initialization entry
    /// </summary>
    public static class MaterialColorSetter
    {
        private static bool _initialized;

        /// <summary>
        /// Initialize material color setter system.
        /// Confidence: 85% - Evidence: RuntimeInitializeOnLoads entry
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Init()
        {
            if (_initialized) return;
            _initialized = true;
            // Unknown - specific initialization logic
        }
    }
}
