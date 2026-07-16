// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Enums/UIEnums.cs
// ============================================================================
//
// Reconstructed from: UI state binding strings, MonoBehaviour data
// Confidence: 88%
// Evidence:
//   - UI state flag strings (currentState, activeView, currentTab)
//   - Button state strings (Highlighted, Disabled, Pressed, Normal)
//   - UI element binding paths (Image/slice, CanvasGroup/alpha, etc.)
//   - Assembly: TLMobile.dll
// ============================================================================

namespace TLMobile.Scripts.Enums
{
    /// <summary>
    /// Main application view/screen states.
    /// Confidence: 85%
    /// Evidence: "activeView" binding string, localization key patterns
    ///   for different screens (dorf1, dorf2, dorf3, rallyPoint, etc.)
    ///   Inferred from Travian game structure
    /// </summary>
    public enum AppView
    {
        Loading = 0,
        Login = 1,
        VillageOverview = 2,
        Map = 3,
        RallyPoint = 4,
        Hero = 5,
        Reports = 6,
        Marketplace = 7,
        Alliance = 8,
        Profile = 9,
        Settings = 10,
        GoldShop = 11
    }

    /// <summary>
    /// Village overview tab identifiers.
    /// Confidence: 80%
    /// Evidence: "currentTab", "currentSubTab" binding strings,
    ///   localization keys "dorf1u2.*", "dorf3.*"
    ///   Inferred from standard Travian layout
    /// </summary>
    public enum VillageTab
    {
        Buildings = 0,
        Resources = 1,
        Troops = 2,
        Map = 3
    }

    /// <summary>
    /// Hero panel tab states.
    /// Confidence: 82%
    /// Evidence: "hero.*" localization keys, hero sprite binding paths
    ///   (heroBaseSpriteKey, heroBodySpriteKey, etc.)
    /// </summary>
    public enum HeroTab
    {
        Attributes = 0,
        Equipment = 1,
        Adventures = 2,
        Auctions = 3,
        Inventory = 4
    }

    /// <summary>
    /// Send troops flow step.
    /// Confidence: 97%
    /// Evidence: Exact values "(Enum)SendTroopsView.Checkout",
    ///   "(Enum)SendTroopsView.SelectUnits", "(Enum)SendTroopsView.SelectTarget"
    /// </summary>
    public enum SendTroopsStep
    {
        SelectTarget = 0,
        SelectUnits = 1,
        Checkout = 2
    }

    /// <summary>
    /// Building detail window display mode.
    /// Confidence: 83%
    /// Evidence: "BuildingDetailWindowController" class name,
    ///   "buildingInfo/isUpgrading", "buildingInfo/building/level" bindings
    /// </summary>
    public enum BuildingDetailMode
    {
        View = 0,
        Upgrade = 1,
        Demolish = 2
    }

    /// <summary>
    /// Rally point sub-view states.
    /// Confidence: 85%
    /// Evidence: "RallyPointTroopsOverviewMainController",
    ///   "RallyPointTroopsOverviewDetailsController" class names,
    ///   "rallyPoint.*" localization keys
    /// </summary>
    public enum RallyPointView
    {
        TroopsOverview = 0,
        SendTroops = 1,
        FarmLists = 2,
        WaveBuilder = 3
    }
}
