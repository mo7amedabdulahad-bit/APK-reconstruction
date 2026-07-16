// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TGFramework/Module/PointerExt/MouseInfo.cs
// ============================================================================
//
// Reconstructed from: RuntimeInitializeOnLoads initialization chain
// Confidence: 88%
// Evidence:
//   - RuntimeInitializeOnLoads.json: assembly="TGFramework.Module.PointerExt",
//     namespace="TGFramework.PointerExtension", class="MouseInfo", method="Init",
//     loadTypes=4 (AfterSceneLoad)
//   - TGFramework.Module.PointerExt assembly in ScriptingAssemblies.txt
//   - Assembly: TGFramework.Module.PointerExt.dll
// ============================================================================

using UnityEngine;

namespace TGFramework.PointerExtension
{
    /// <summary>
    /// Mouse/pointer information utility initialized at runtime.
    /// Confidence: 88%
    /// Evidence: RuntimeInitializeOnLoads initialization with loadTypes=4
    /// </summary>
    public static class MouseInfo
    {
        private static bool _initialized;

        /// <summary>
        /// Initialize mouse info system.
        /// Confidence: 88% - Evidence: RuntimeInitializeOnLoads entry
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Init()
        {
            if (_initialized) return;
            _initialized = true;
            // Unknown - specific initialization logic
        }

        /// <summary>
        /// Get mouse position in world space.
        /// Confidence: 82% - Inferred from class purpose
        /// </summary>
        public static Vector3 GetMouseWorldPosition()
        {
            return Input.mousePosition;
        }

        /// <summary>
        /// Check if mouse is over UI element.
        /// Confidence: 80% - Inferred from pointer extension purpose
        /// </summary>
        public static bool IsPointerOverUI()
        {
            // Unknown - requires EventSystem integration
            return false;
        }
    }
}
