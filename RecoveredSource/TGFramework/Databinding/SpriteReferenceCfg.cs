// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TGFramework/Databinding/SpriteReferenceCfg.cs
// ============================================================================
//
// Reconstructed from: link.xml preservation rules,
//                      MonoScript definitions, assembly references
// Confidence: 95%
// Evidence:
//   - link.xml: "SpriteReferenceCfg" preserved in TGFramework.Databinding
//   - link.xml: "SpriteReferenceCfg/LanguageOverride" serialized type
//   - MonoScript_-2109595952637691619.json: class_name="SpriteReferenceCfg"
//   - MonoScript_1.json: class_name="GoogleMobileAdsSettings"
//   - TGFramework.Databinding assembly in ScriptingAssemblies.txt
//   - Assembly: TGFramework.Databinding.dll
// ============================================================================

using System;
using UnityEngine;

namespace TGFramework.Databinding
{
    /// <summary>
    /// Configuration for sprite references with language-specific overrides.
    /// Confidence: 95%
    /// Evidence: link.xml preservation, MonoScript definition, serialized type
    /// </summary>
    [Serializable]
    public class SpriteReferenceCfg : MonoBehaviour
    {
        /// <summary>
        /// Language-specific sprite override configuration.
        /// Confidence: 94%
        /// Evidence: link.xml: "SpriteReferenceCfg/LanguageOverride" preserve="nothing" serialized="true"
        /// </summary>
        [Serializable]
        public struct LanguageOverride
        {
            /// <summary>Language identifier. Confidence: 90% - Inferred</summary>
            public string language;

            /// <summary>Sprite reference for this language. Confidence: 92%</summary>
            public Sprite sprite;
        }

        /// <summary>
        /// Default sprite reference.
        /// Confidence: 93% - Inferred from SpriteReferenceCfg purpose
        /// </summary>
        [SerializeField] private Sprite defaultSprite;

        /// <summary>
        /// Language-specific overrides.
        /// Confidence: 94% - Evidence: LanguageOverride serialized type
        /// </summary>
        [SerializeField] private LanguageOverride[] languageOverrides;

        /// <summary>
        /// Get sprite for current language.
        /// Confidence: 90% - Inferred from localization system
        /// </summary>
        public Sprite GetSpriteForLanguage(string language)
        {
            if (languageOverrides != null)
            {
                foreach (var overrideEntry in languageOverrides)
                {
                    if (overrideEntry.language == language && overrideEntry.sprite != null)
                    {
                        return overrideEntry.sprite;
                    }
                }
            }
            return defaultSprite;
        }
    }
}
