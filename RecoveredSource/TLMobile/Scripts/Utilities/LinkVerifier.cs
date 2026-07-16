// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Utilities/LinkVerifier.cs
// ============================================================================
//
// Reconstructed from: RuntimeInitializeOnLoads initialization chain
// Confidence: 85%
// Evidence:
//   - RuntimeInitializeOnLoads.json: assembly="TLMobile",
//     namespace="TLMobile.Scripts.Utilities", class="LinkVerifier",
//     method="LoadAllowedDomains", loadTypes=0 (BeforeSceneLoad)
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using UnityEngine;

namespace TLMobile.Scripts.Utilities
{
    /// <summary>
    /// Verifies and loads allowed domains for deep linking and security.
    /// Confidence: 85%
    /// Evidence: RuntimeInitializeOnLoads initialization entry
    /// </summary>
    public static class LinkVerifier
    {
        private static HashSet<string> _allowedDomains;
        private static bool _loaded;

        /// <summary>
        /// Load allowed domains configuration.
        /// Confidence: 85% - Evidence: RuntimeInitializeOnLoads entry
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadAllowedDomains()
        {
            if (_loaded) return;
            _loaded = true;

            _allowedDomains = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "travian.com",
                "lobby.travian.com",
                "startpage.legends.travian.dev"
            };
        }

        /// <summary>
        /// Check if a domain is in the allowed list.
        /// Confidence: 83% - Inferred
        /// </summary>
        public static bool IsAllowed(string domain)
        {
            if (_allowedDomains == null) LoadAllowedDomains();
            return _allowedDomains.Contains(domain);
        }
    }
}
