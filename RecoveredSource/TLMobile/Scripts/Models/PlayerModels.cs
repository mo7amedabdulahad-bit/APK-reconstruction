// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/PlayerModels.cs
// ============================================================================
//
// Reconstructed from: Player/Village data binding paths,
//                      alliance bindings, permission system
// Confidence: 93%
// Evidence:
//   - ownPlayer/*, player/*, ownVillage/* paths (30+ bindings)
//   - "ownPlayer/permissions", "ownPlayer/isSitter"
//   - "ownVillage/tribeId", "ownVillage/isShore", "ownVillage/isCity"
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Player information model.
    /// Confidence: 94%
    /// Evidence: Data binding paths: "player/id", "player/hero",
    ///   "player/hero/gender", "player/villagesCount",
    ///   "player/alliance", "player/profile/languagesEnum",
    ///   "ownPlayer/id", "ownPlayer/permissions", "ownPlayer/isSitter"
    /// </summary>
    [Serializable]
    public class PlayerInfo
    {
        /// <summary>Player ID. Confidence: 96% - Evidence: "player/id", "ownPlayer/id"</summary>
        public long id;

        /// <summary>Player name. Confidence: 90% - Inferred from "nameDecoded" pattern</summary>
        public string name;

        /// <summary>Hero data. Confidence: 94% - Evidence: "player/hero"</summary>
        public HeroData hero;

        /// <summary>Village count. Confidence: 93% - Evidence: "player/villagesCount"</summary>
        public int villagesCount;

        /// <summary>Alliance data. Confidence: 94% - Evidence: "player/alliance"</summary>
        public AllianceInfo alliance;

        /// <summary>Profile language preferences. Confidence: 92%</summary>
        public string[] profileLanguagesEnum;

        /// <summary>Wallet/gold amount. Confidence: 93% - Evidence: "ownPlayer/wallet/goldAmount"</summary>
        public WalletInfo wallet;
    }

    /// <summary>
    /// Own player (current user) extended data.
    /// Confidence: 93%
    /// Evidence: "ownPlayer/permissions", "ownPlayer/isSitter",
    ///   "ownPlayer/id+", "ownPlayer/wallet/goldAmount"
    /// </summary>
    [Serializable]
    public class OwnPlayer : PlayerInfo
    {
        /// <summary>Player permissions. Confidence: 94%</summary>
        public PermissionMask permissions;

        /// <summary>Whether viewing as sitter. Confidence: 93%</summary>
        public bool isSitter;

        /// <summary>Active role. Confidence: 88% - Evidence: "ownRole"</summary>
        public string ownRole;
    }

    /// <summary>
    /// Village information model.
    /// Confidence: 94%
    /// Evidence: "ownVillage/tribeId", "ownVillage/isShore",
    ///   "ownVillage/isCity", "ownVillage/isWW",
    ///   "ownVillage/villageLayoutType", "ownVillage/waveBuilderIsActivated"
    /// </summary>
    [Serializable]
    public class VillageInfo
    {
        /// <summary>Village ID. Confidence: 95% - Evidence: "targetVillage/id"</summary>
        public long id;

        /// <summary>Village name. Confidence: 94% - Evidence: "targetVillage/nameDecoded"</summary>
        public string nameDecoded;

        /// <summary>Faction ID. Confidence: 95% - Evidence: "ownVillage/tribeId"</summary>
        public TribeId tribeId;

        /// <summary>Is shore village. Confidence: 94% - Evidence: "ownVillage/isShore"</summary>
        public bool isShore;

        /// <summary>Is city. Confidence: 94% - Evidence: "ownVillage/isCity"</summary>
        public bool isCity;

        /// <summary>Is Wonder of the World village. Confidence: 93%</summary>
        public bool isWW;

        /// <summary>Village layout type. Confidence: 94%</summary>
        public VillageLayoutType villageLayoutType;

        /// <summary>Wave builder activated. Confidence: 93%</summary>
        public bool waveBuilderIsActivated;

        /// <summary>Currently building level. Confidence: 91% - Evidence: "currentlyBuildingLevel"</summary>
        public int currentlyBuildingLevel;
    }

    /// <summary>
    /// Alliance information model.
    /// Confidence: 90%
    /// Evidence: "player/alliance", "player/alliance/id",
    ///   localization keys "allianz.*", diplomacy types
    /// </summary>
    [Serializable]
    public class AllianceInfo
    {
        /// <summary>Alliance ID. Confidence: 94% - Evidence: "player/alliance/id"</summary>
        public long id;

        /// <summary>Alliance name. Confidence: 88% - Inferred</summary>
        public string name;

        /// <summary>Alliance tag. Confidence: 87% - Inferred</summary>
        public string tag;

        /// <summary>Diplomacy status. Confidence: 86%</summary>
        public DiplomacyType diplomacyType;

        /// <summary>Alliance member count. Confidence: 82% - Inferred</summary>
        public int memberCount;
    }

    /// <summary>
    /// Player wallet/currency data.
    /// Confidence: 93%
    /// Evidence: "ownPlayer/wallet/goldAmount"
    /// </summary>
    [Serializable]
    public class WalletInfo
    {
        /// <summary>Gold balance. Confidence: 93% - Evidence: "ownPlayer/wallet/goldAmount"</summary>
        public long goldAmount;

        /// <summary>Silver balance. Confidence: 85% - Inferred from auction bidding system</summary>
        public long silverAmount;
    }
}
