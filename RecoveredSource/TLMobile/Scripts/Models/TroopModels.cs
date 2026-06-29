// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/TroopModels.cs
// ============================================================================
//
// Reconstructed from: Data binding paths, combat report structures,
//                      send troops UI bindings, wave builder data
// Confidence: 94%
// Evidence:
//   - troopInfo/tid, troopInfo/amount, troopInfo/uidForTroop paths
//   - sendTroopInfo/* paths (200+ bindings)
//   - troopInBattle/amounts/* paths (casualties, wounded, survived, etc.)
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Individual troop information for a unit type.
    /// Confidence: 96%
    /// Evidence: Data binding paths:
    ///   "troopInfo/tid", "troopInfo/amount", "troopInfo/uidForTroop",
    ///   "troopInfo/tribeId", "troopInfo/unitLevel", "troopInfo/translateKey"
    /// </summary>
    [Serializable]
    public class TroopInfo
    {
        /// <summary>Troop type ID. Confidence: 96% - Evidence: "troopInfo/tid"</summary>
        public int tid;

        /// <summary>Troop count. Confidence: 96% - Evidence: "troopInfo/amount"</summary>
        public int amount;

        /// <summary>Unique troop identifier. Confidence: 95% - Evidence: "troopInfo/uidForTroop"</summary>
        public string uidForTroop;

        /// <summary>Faction ID. Confidence: 95% - Evidence: "troopInfo/tribeId"</summary>
        public TribeId tribeId;

        /// <summary>Unit level (upgrades). Confidence: 94% - Evidence: "troopInfo/unitLevel"</summary>
        public int unitLevel;

        /// <summary>Localization key for display name. Confidence: 93% - Evidence: "troopInfo/translateKey"</summary>
        public string translateKey;
    }

    /// <summary>
    /// Extended troop info with selection state for UI.
    /// Confidence: 94%
    /// Evidence: Data binding paths:
    ///   "selectedUnit/info/uidForTroop", "selectedUnit/info/amount",
    ///   "selectedUnit/selectedAmount", "selectedTroopInfo/*"
    /// </summary>
    [Serializable]
    public class SelectedTroopInfo
    {
        public TroopInfo info;
        public int selectedAmount;
    }

    /// <summary>
    /// Send troops data container for the troop dispatch flow.
    /// Confidence: 95%
    /// Evidence: 50+ data binding paths prefixed with "sendTroopInfo/"
    ///   including targetVillage, waves, attackType, distance, etc.
    /// </summary>
    [Serializable]
    public class SendTroopInfo
    {
        /// <summary>Attack/raid type. Confidence: 96%</summary>
        public AttackType attackType;

        /// <summary>Target village data. Confidence: 96%</summary>
        public TargetVillage targetVillage;

        /// <summary>Target map cell. Confidence: 94%</summary>
        public MapCell targetMapCell;

        /// <summary>Target map cell type name. Confidence: 90%</summary>
        public string targetMapCellTypeName;

        /// <summary>Resource cost for this movement. Confidence: 94%</summary>
        public ResourceAmounts resourcesCostInfo;

        /// <summary>Whether catapult target is valid. Confidence: 93%</summary>
        public bool validCatapultTarget;

        /// <summary>Wave editing state. Confidence: 96%</summary>
        public WaveEditType waveEditType;

        /// <summary>Attack waves. Confidence: 96% - Evidence: "sendTroopInfo/waves[x]"</summary>
        public List<TroopWave> waves;

        /// <summary>Distance to target. Confidence: 94% - Evidence: "sendTroopInfo/distance"</summary>
        public float distance;
    }

    /// <summary>
    /// A single attack wave in a multi-wave attack.
    /// Confidence: 93%
    /// Evidence: "sendTroopInfo/waves[x]", "waves[x]/selectableAmounts",
    ///   wave builder localization keys, "AddNewWave()", "DeleteWave()"
    /// </summary>
    [Serializable]
    public class TroopWave
    {
        public List<TroopInfo> troops;
        public int waveIndex;
    }

    /// <summary>
    /// Target village information for troop dispatch.
    /// Confidence: 96%
    /// Evidence: 15+ data binding paths under "sendTroopInfo/targetVillage/*"
    /// </summary>
    [Serializable]
    public class TargetVillage
    {
        /// <summary>Village ID. Confidence: 96%</summary>
        public long id;

        /// <summary>Map ID. Confidence: 95% - Evidence: "targetVillage/mapId"</summary>
        public long mapId;

        /// <summary>Village name (decoded). Confidence: 95%</summary>
        public string nameDecoded;

        /// <summary>Village type name. Confidence: 94%</summary>
        public string villageTypeName;

        /// <summary>Village type enum. Confidence: 94%</summary>
        public VillageLayoutType typeEnum;

        /// <summary>Village type. Confidence: 93%</summary>
        public int type;

        /// <summary>Owner player. Confidence: 95%</summary>
        public PlayerInfo player;
    }

    /// <summary>
    /// Map cell information.
    /// Confidence: 90%
    /// Evidence: "sendTroopInfo/targetMapCell/id",
    ///   "sendTroopInfo/targetMapCell/village/player/id"
    /// </summary>
    [Serializable]
    public class MapCell
    {
        public long id;
        public TargetVillage village;
    }

    /// <summary>
    /// Troop amounts in battle (before/after combat).
    /// Confidence: 95%
    /// Evidence: Data binding paths:
    ///   "troopInBattle/amounts/revived[x]",
    ///   "troopInBattle/amounts/casualties[x]",
    ///   "troopInBattle/amounts/wounded[x]",
    ///   "troopInBattle/amounts/trapped[x]",
    ///   "troopInBattle/amounts/survived[x]",
    ///   "troopInBattle/amounts/infos"
    /// </summary>
    [Serializable]
    public class TroopAmountsInBattle
    {
        /// <summary>Survived units per type. Confidence: 95%</summary>
        public int[] survived;

        /// <summary>Casualties per type. Confidence: 95%</summary>
        public int[] casualties;

        /// <summary>Wounded per type. Confidence: 95%</summary>
        public int[] wounded;

        /// <summary>Revived per type. Confidence: 94%</summary>
        public int[] revived;

        /// <summary>Trapped per type. Confidence: 93%</summary>
        public int[] trapped;

        /// <summary>Total revived count. Confidence: 93%</summary>
        public int totalRevived;

        /// <summary>Troop type infos. Confidence: 92%</summary>
        public TroopInfo[] infos;
    }

    /// <summary>
    /// Reinforcement troop data in battle reports.
    /// Confidence: 92%
    /// Evidence: "reinforcements[i]", "reinforcements[i]/tribeId",
    ///   "reinforcements[i]/amounts", "reinforcements[i]/wounded/totalAmount",
    ///   "reinforcements[i]/casualties/totalAmount"
    /// </summary>
    [Serializable]
    public class ReinforcementData
    {
        public TribeId tribeId;
        public TroopAmountsInBattle amounts;
        public int woundedTotal;
        public int casualtiesTotal;
        public int trappedTotal;
    }

    /// <summary>
    /// Selected amount with additional send info.
    /// Confidence: 94%
    /// Evidence: 20+ data binding paths under "selectedAmountWithSendInfo/*"
    /// </summary>
    [Serializable]
    public class SelectedAmountWithSendInfo
    {
        public float duration;
        public ScoutingTarget scoutingTarget;
        public bool scoutingOptionsAvailable;
        public bool useShips;
        public float useShipUIAlpha;
        public bool heroSelected;
        public int selectedKataAmount;
        public int selectedKata2;
        public SelectableAmounts selectableAmounts;
        public float timeSavedUsingShip;
        public int catapultsSelected;
        public string shipTypeUsedTLMTranslated;
        public string shipTypeUsedTranslated;
    }

    /// <summary>
    /// Selectable units for troop selection UI.
    /// Confidence: 91%
    /// Evidence: "selectableUnits[i]", "selectableUnits[i]/selectedAmount",
    ///   "selectableUnits[i]/info"
    /// </summary>
    [Serializable]
    public class SelectableAmounts
    {
        public List<SelectedTroopInfo> selectableUnits;
    }
}
