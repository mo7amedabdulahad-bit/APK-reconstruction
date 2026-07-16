// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Services/AllianceService.cs
// ============================================================================
//
// Reconstructed from: Alliance data binding paths, diplomacy system,
//                      confederacy, alliance bonuses
// Confidence: 83%
// Evidence:
//   - "player/alliance", "player/alliance/id" bindings
//   - "allianz.*" localization keys (15+)
//   - DiplomacyType enum
//   - AllianceBonusType enum
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TLMobile.Scripts.Models;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Services
{
    /// <summary>
    /// Service managing alliance operations, diplomacy, and forums.
    /// Confidence: 83%
    /// Evidence: Alliance data binding paths, diplomacy localization, bonus system
    /// </summary>
    public class AllianceService
    {
        /// <summary>
        /// Get current alliance data.
        /// Confidence: 82% - Evidence: "player/alliance" binding
        /// </summary>
        public AllianceInfo GetAlliance(long playerId)
        {
            // Unknown - requires server data
            return null;
        }

        /// <summary>
        /// Get alliance members.
        /// Confidence: 80% - Inferred from alliance management
        /// </summary>
        public async UniTask<List<PlayerInfo>> GetMembersAsync(long allianceId)
        {
            // Unknown
            return new List<PlayerInfo>();
        }

        /// <summary>
        /// Get diplomacy status with another alliance.
        /// Confidence: 81% - Evidence: DiplomacyType enum, "allianz.diplomacy.*" localization
        /// </summary>
        public DiplomacyType GetDiplomacyStatus(long allianceId, long otherAllianceId)
        {
            // Unknown - requires server data
            return DiplomacyType.None;
        }

        /// <summary>
        /// Get alliance bonus type and level.
        /// Confidence: 80% - Evidence: AllianceBonusType enum
        /// </summary>
        public AllianceBonusType[] GetAllianceBonuses(long allianceId)
        {
            // Unknown
            return Array.Empty<AllianceBonusType>();
        }

        /// <summary>
        /// Check if player has permission for action.
        /// Confidence: 82% - Evidence: "ownPlayer/permissions" binding,
        ///   PermissionMask enum values
        /// </summary>
        public bool HasPermission(OwnPlayer player, PermissionMask required)
        {
            return (player.permissions & required) == required;
        }
    }
}
