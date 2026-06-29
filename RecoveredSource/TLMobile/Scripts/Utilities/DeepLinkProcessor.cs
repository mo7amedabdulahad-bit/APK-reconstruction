// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Utilities/DeepLinkProcessor.cs
// ============================================================================
//
// Reconstructed from: RuntimeInitializeOnLoads initialization chain,
//                      deep link configuration data
// Confidence: 86%
// Evidence:
//   - RuntimeInitializeOnLoads.json: assembly="TLMobile",
//     namespace="TLMobile.Scripts.Utilities", class="DeepLinkProcessor",
//     method="LoadRemoteConfig", loadTypes=0 (BeforeSceneLoad)
//   - UniversalDeepLink.json: deep link domains and schemes
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using UnityEngine;

namespace TLMobile.Scripts.Utilities
{
    /// <summary>
    /// Processes deep links and loads remote configuration.
    /// Confidence: 86%
    /// Evidence: RuntimeInitializeOnLoads entry, UniversalDeepLink.json config
    /// </summary>
    public static class DeepLinkProcessor
    {
        private static bool _initialized;

        /// <summary>
        /// Deep link domains from configuration.
        /// Confidence: 90% - Evidence: UniversalDeepLink.json
        ///   "https://www.travian.com", "https://lobby.travian.com",
        ///   "https://startpage.legends.travian.dev"
        /// </summary>
        private static readonly string[] AllowedDomains = new[]
        {
            "travian.com",
            "lobby.travian.com",
            "startpage.legends.travian.dev"
        };

        /// <summary>
        /// Load remote configuration from deep link or server.
        /// Confidence: 86% - Evidence: RuntimeInitializeOnLoads entry
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadRemoteConfig()
        {
            if (_initialized) return;
            _initialized = true;

            // Check for deep link on startup
            // Evidence: UniversalDeepLink.json with test deep links for
            //   gold purchases, registration, activation
            ProcessPendingDeepLink();
        }

        /// <summary>
        /// Process a pending deep link URI.
        /// Confidence: 83% - Inferred from deep link configuration
        /// </summary>
        private static void ProcessPendingDeepLink()
        {
            // Unknown - requires deep link parsing implementation
            // Evidence: UniversalDeepLink.json contains schemes:
            //   "travian.com://", "lobby.travian.com://",
            //   "startpage.legends.travian.dev://"
        }

        /// <summary>
        /// Validate if a domain is allowed.
        /// Confidence: 85% - Evidence: LinkVerifier.LoadAllowedDomains companion
        /// </summary>
        public static bool IsDomainAllowed(string uri)
        {
            if (string.IsNullOrEmpty(uri)) return false;

            foreach (var domain in AllowedDomains)
            {
                if (uri.Contains(domain, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
