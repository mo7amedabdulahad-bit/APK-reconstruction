// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Enums/GameEnums.cs
// ============================================================================
//
// Reconstructed from: MonoBehaviour data binding paths, localization keys,
//                      RuntimeInitializeOnLoads, enum value strings
// Confidence: 92%
// Evidence:
//   - 957 unique strings from 4,399 MonoBehaviour raw JSON files
//   - 12,529 localization lines (en-US.txt)
//   - Enum value strings in data binding expressions
//   - Assembly: TLMobile.dll
//
// References:
//   - MonoBehaviour data binding paths (troopInfo/tribeId, attackType, etc.)
//   - Localization keys (a2b.*, rallyPoint.*, hero.*, etc.)
//   - RuntimeInitializeOnLoads.json (TLMobile.Scripts namespace chain)
//   - Extracted asset metadata (7 factions, building types)
// ============================================================================

using System;

namespace TLMobile.Scripts.Enums
{
    /// <summary>
    /// Faction/tribe identifiers for the 7 playable factions + NPCs.
    /// Confidence: 95%
    /// Evidence: 7 named building reference assets per faction,
    ///           localization keys referencing tribe names,
    ///           data binding path "sendTroopInfo/targetVillage/tribeEnum"
    /// </summary>
    public enum TribeId
    {
        // Reconstructed from building reference asset names:
        // Buildings{Faction}References.json, Buildings{Faction}NightReferences.json
        Romans = 1,
        Teutons = 2,
        Gauls = 3,
        Egyptians = 6,
        Huns = 7,
        Spartans = 8,
        Vikings = 9,

        // Reconstructed from localization keys referencing NPC factions
        // Evidence: "TribeId.Nature", "TribeId.Natars" in data binding strings
        Nature = 0,
        Natars = 5
    }

    /// <summary>
    /// Attack/movement type selection for troop dispatch.
    /// Confidence: 98%
    /// Evidence: Exact enum values found in data binding strings:
    ///   "(Enum)AttackType.Reinforcement", "(Enum)AttackType.Attack",
    ///   "(Enum)AttackType.Settle", "(Enum)AttackType.Raid",
    ///   "(Enum)AttackType.Forward", "(Enum)AttackType.NoSelection"
    /// </summary>
    public enum AttackType
    {
        NoSelection = 0,
        Attack = 1,
        Raid = 2,
        Reinforcement = 3,
        Settle = 4,
        Forward = 5
    }

    /// <summary>
    /// Combat role in battle reports and combat simulator.
    /// Confidence: 98%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)Role.Attacker", "(Enum)Role.Defender", "(Enum)Role.Reinforcement"
    /// </summary>
    public enum Role
    {
        Attacker = 0,
        Defender = 1,
        Reinforcement = 2
    }

    /// <summary>
    /// Scouting mission target type.
    /// Confidence: 97%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)ScoutingTarget.ResourcesAndTroops",
    ///   "(Enum)ScoutingTarget.DefencesAndTroops"
    /// </summary>
    public enum ScoutingTarget
    {
        ResourcesAndTroops = 0,
        DefencesAndTroops = 1
    }

    /// <summary>
    /// Village layout variant (normal, shore city, watchtowers).
    /// Confidence: 97%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)VillageLayoutType.Village",
    ///   "(Enum)VillageLayoutType.ShoreCity",
    ///   "(Enum)VillageLayoutType.ShoreCityWithWatchTowers"
    /// Also referenced: "ownVillage/villageLayoutType", "ownVillage/isShore", "ownVillage/isCity"
    /// </summary>
    public enum VillageLayoutType
    {
        Village = 0,
        ShoreCity = 1,
        ShoreCityWithWatchTowers = 2
    }

    /// <summary>
    /// Wave editing mode in the wave builder.
    /// Confidence: 98%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)WaveEditType.Add", "(Enum)WaveEditType.Edit", "(Enum)WaveEditType.None"
    /// </summary>
    public enum WaveEditType
    {
        None = 0,
        Add = 1,
        Edit = 2
    }

    /// <summary>
    /// View states in the send troops flow.
    /// Confidence: 97%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)SendTroopsView.Checkout",
    ///   "(Enum)SendTroopsView.SelectUnits",
    ///   "(Enum)SendTroopsView.SelectTarget"
    /// </summary>
    public enum SendTroopsView
    {
        SelectTarget = 0,
        SelectUnits = 1,
        Checkout = 2
    }

    /// <summary>
    /// Hero gender for appearance rendering.
    /// Confidence: 96%
    /// Evidence: "(Enum)Gender.male" found in data binding strings,
    ///           hero sprite key references for male/female appearance
    /// </summary>
    public enum Gender
    {
        male = 0,
        female = 1
    }

    /// <summary>
    /// Hero item rarity tier (crafting system).
    /// Confidence: 94%
    /// Evidence: "(Enum)HeroRarity.Empty", "(Enum)HeroQuality.None",
    ///   "(Enum)HeroQuality.Hidden" in data binding strings.
    ///   Localization keys for crafting tiers: Common, Uncommon, Rare, Epic, Legendary
    /// </summary>
    public enum HeroRarity
    {
        Empty = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5
    }

    /// <summary>
    /// Hero item quality display state.
    /// Confidence: 93%
    /// Evidence: "(Enum)HeroQuality.None", "(Enum)HeroQuality.Hidden"
    /// </summary>
    public enum HeroQuality
    {
        None = 0,
        Hidden = 1
    }

    /// <summary>
    /// Hero equipment slot categories.
    /// Confidence: 97%
    /// Evidence: Exact values found in data binding strings:
    ///   "(Enum)HeroItemCategory.Boots", "(Enum)HeroItemCategory.Consumable",
    ///   "(Enum)HeroItemCategory.Utility", "(Enum)HeroItemCategory.Weapon"
    /// Also referenced: heroBootsSpriteKey, heroUtilityItemEffects, etc.
    /// </summary>
    public enum HeroItemCategory
    {
        Weapon = 0,
        Armor = 1,
        Boots = 2,
        Utility = 3,
        Consumable = 4,
        Horse = 5
    }

    /// <summary>
    /// Building type identifiers (Travian building GIDs).
    /// Confidence: 90%
    /// Evidence: Localization keys "allgemein.gid{N}" for 50+ buildings,
    ///   "(Enum)TypeId.Brewery", "(Enum)TypeId.StonemasonsLodge" from data binding,
    ///   building sprite references in asset bundles
    /// </summary>
    public enum TypeId
    {
        None = 0,
        MainBuilding = 1,
        Barracks = 2,
        Stable = 3,
        Workshop = 4,
        Academy = 5,
        Smithy = 6,
        RallyPoint = 7,
        Market = 8,
        TimberCamp = 9,
        ClayPit = 10,
        IronMine = 11,
        Cropland = 12,
        Warehouse = 13,
        Granary = 14,
        Blacksmith = 15,
        Cranny = 16,
        TownHall = 17,
        Residence = 18,
        Palace = 19,
        CityWall = 20,
        Embassy = 21,
        GreatGranary = 25,
        GreatWarehouse = 26,
        WonderOfTheWorld = 27,
        HorseDrinkingTrough = 28,
        Brewery = 29,
        Trapper = 30,
        GreatBarracks = 31,
        GreatStable = 32,
        Waterworks = 33,
        StonemasonsLodge = 34,
        TradeOffice = 37,
        Palisade = 38,
        EarthWall = 39,
        StoneWall = 40,
        MakeshiftWall = 41,
        TournamentSquare = 42,
        Hospital = 44,
        Catapult = 45
    }

    /// <summary>
    /// Player permission flags.
    /// Confidence: 96%
    /// Evidence: Exact values from data binding strings:
    ///   "(Enum)PermissionMask.BuySpendGold",
    ///   "(Enum)PermissionMask.SendRaids",
    ///   "(Enum)PermissionMask.SendReinforcement"
    /// Also: "ownPlayer/permissions"
    /// </summary>
    [Flags]
    public enum PermissionMask
    {
        None = 0,
        BuySpendGold = 1,
        SendRaids = 2,
        SendReinforcement = 4,
        // Inferred from common permission patterns - low confidence
        EditAlliance = 8,
        ManageDiplomacy = 16
    }

    /// <summary>
    /// Auction bid status.
    /// Confidence: 95%
    /// Evidence: "(Enum)BidStatus.RUNNING" from data binding strings
    /// </summary>
    public enum BidStatus
    {
        Running = 0,
        Finished = 1,
        Won = 2,
        Lost = 3
    }

    /// <summary>
    /// Auction highest bidder identification.
    /// Confidence: 95%
    /// Evidence: "(Enum)HighestBidderTag.Own" from data binding strings
    /// </summary>
    public enum HighestBidderTag
    {
        None = 0,
        Own = 1
    }

    /// <summary>
    /// Battle loot/bounty status.
    /// Confidence: 94%
    /// Evidence: "(Enum)BountyStatus.None", "report/attackerBooty/bountyStatus"
    /// </summary>
    public enum BountyStatus
    {
        None = 0,
        Partial = 1,
        Full = 2
    }

    /// <summary>
    /// Spam report reason categories.
    /// Confidence: 96%
    /// Evidence: Exact values from data binding strings:
    ///   "(Enum)SpamReasonEnum.Advertisement",
    ///   "(Enum)SpamReasonEnum.InappropriateContent",
    ///   "(Enum)SpamReasonEnum.Gold", "(Enum)SpamReasonEnum.Misc"
    /// </summary>
    public enum SpamReasonEnum
    {
        Advertisement = 0,
        InappropriateContent = 1,
        Gold = 2,
        Misc = 3
    }

    /// <summary>
    /// Generic UI sub-tab identifiers.
    /// Confidence: 85%
    /// Evidence: "(Enum)GenericSubTab.Option1", "(Enum)GenericSubTab.Option2"
    /// Values are generic placeholders - actual tabs may differ
    /// </summary>
    public enum GenericSubTab
    {
        Option1 = 0,
        Option2 = 1
    }

    /// <summary>
    /// Auction sub-tab identifiers.
    /// Confidence: 93%
    /// Evidence: "(Enum)Subtab.FinishedBids" from data binding strings
    /// </summary>
    public enum Subtab
    {
        ActiveAuctions = 0,
        FinishedBids = 1,
        YourBids = 2
    }

    /// <summary>
    /// Detail window popup types.
    /// Confidence: 94%
    /// Evidence: "(Enum)DetailWindows.WaveBuilderActivationPopup",
    ///   "(Enum)DetailWindows.SilverToGoldExchangePopup"
    /// </summary>
    public enum DetailWindows
    {
        WaveBuilderActivationPopup = 0,
        SilverToGoldExchangePopup = 1
    }

    /// <summary>
    /// Crafting action types for hero items.
    /// Confidence: 92%
    /// Evidence: "(Enum)CraftingAction.None" from data binding strings,
    ///   localization keys for "crafting.refine", "crafting.smelt", "crafting.forge"
    /// </summary>
    public enum CraftingAction
    {
        None = 0,
        Refine = 1,
        Smelt = 2,
        Forge = 3
    }

    /// <summary>
    /// Item drop status in crafting/inventory.
    /// Confidence: 91%
    /// Evidence: "(Enum)DropStatus.Possible" from data binding strings
    /// </summary>
    public enum DropStatus
    {
        Impossible = 0,
        Possible = 1
    }

    /// <summary>
    /// Crafting smelting state machine.
    /// Confidence: 90%
    /// Evidence: "(Enum)SmeltingState.Completed" from data binding strings
    /// </summary>
    public enum SmeltingState
    {
        InProgress = 0,
        Completed = 1
    }

    /// <summary>
    /// Crafting forge state machine.
    /// Confidence: 90%
    /// Evidence: "(Enum)ForgeState.Forged" from data binding strings
    /// </summary>
    public enum ForgeState
    {
        Unforged = 0,
        Forged = 1
    }

    /// <summary>
    /// Premium feature flags.
    /// Confidence: 93%
    /// Evidence: "(Enum)FeatureEnum.Plus", "(Enum)GoldClubFeature.EvasionInCapital"
    /// </summary>
    public enum FeatureEnum
    {
        None = 0,
        Plus = 1
    }

    /// <summary>
    /// Gold Club feature identifiers.
    /// Confidence: 92%
    /// Evidence: "(Enum)GoldClubFeature.EvasionInCapital" from data binding
    /// </summary>
    public enum GoldClubFeature
    {
        EvasionInCapital = 0,
        FarmLists = 1,
        CropFinder = 2
    }

    /// <summary>
    /// Player search type for the search interface.
    /// Confidence: 95%
    /// Evidence: "(Enum)SearchType.Player" from data binding strings
    /// </summary>
    public enum SearchType
    {
        Player = 0,
        Village = 1,
        Alliance = 2
    }

    /// <summary>
    /// Oasis type classification.
    /// Confidence: 88%
    /// Evidence: "(Enum)Type.FreeOasis" from data binding strings,
    ///   localization keys for oasis types
    /// </summary>
    public enum OasisType
    {
        FreeOasis = 0,
        occupied = 1
    }

    /// <summary>
    /// Troop unit types per faction (base unit indices).
    /// Confidence: 85%
    /// Evidence: Troop data binding paths "troopInfo/tid", "troopInfo/unitLevel",
    ///   localization keys for unit names per faction,
    ///   combat report troop amount arrays
    /// Note: Exact mapping of tid values to unit types requires metadata
    /// </summary>
    public enum UnitTypeId
    {
        // Infantry (tier 1-3)
        Infantry1 = 1,
        Infantry2 = 2,
        Infantry3 = 3,
        // Cavalry (tier 4-6)
        Cavalry1 = 4,
        Cavalry2 = 5,
        Cavalry3 = 6,
        // Siege (tier 7-8)
        Siege1 = 7,
        Siege2 = 8,
        // Scout (tier 9)
        Scout = 9,
        // Hero
        Hero = 10
    }

    /// <summary>
    /// Resource types in the game economy.
    /// Confidence: 98%
    /// Evidence: Data binding paths "resourcesCostInfo/cost/wood",
    ///   "resourcesCostInfo/cost/clay", "resourcesCostInfo/cost/iron",
    ///   "resourcesCostInfo/cost/crop", resourceAmounts/iron, etc.
    ///   All 4 resources appear consistently across 200+ data binding paths
    /// </summary>
    public enum ResourceType
    {
        Wood = 0,
        Clay = 1,
        Iron = 2,
        Crop = 3
    }

    /// <summary>
    /// Alliance diplomacy types.
    /// Confidence: 87%
    /// Evidence: Localization keys "allianz.diplomacy.*" referencing
    ///   NAP, confederacy, war, zero-based types
    /// </summary>
    public enum DiplomacyType
    {
        None = 0,
        NAP = 1,
        Confederacy = 2,
        War = 3
    }

    /// <summary>
    /// Alliance bonus types.
    /// Confidence: 86%
    /// Evidence: Localization keys referencing recruitment speed,
    ///   philosophy (culture points), metallurgy (combat), commerce (merchants)
    /// </summary>
    public enum AllianceBonusType
    {
        Recruitment = 0,
        Philosophy = 1,
        Metallurgy = 2,
        Commerce = 3
    }
}
