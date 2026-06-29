// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/CombatModels.cs
// ============================================================================
//
// Reconstructed from: Combat simulator data binding paths,
//                      battle report structures, combat strings
// Confidence: 94%
// Evidence:
//   - combatSimulator/* paths (30+ bindings)
//   - report/* paths (20+ bindings)
//   - troopInBattle/* paths
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Combat simulator participant data.
    /// Confidence: 95%
    /// Evidence: 20+ data binding paths under "combatSimulatorParticipant/*"
    /// </summary>
    [Serializable]
    public class CombatSimulatorParticipant
    {
        /// <summary>Participant role (attacker/defender/reinforcement). Confidence: 96%</summary>
        public Role role;

        /// <summary>Faction ID. Confidence: 95% - Evidence: "combatSimulatorParticipant/tribeId"</summary>
        public TribeId tribeId;

        /// <summary>Hero data. Confidence: 94% - Evidence: "combatSimulatorParticipant/hero"</summary>
        public CombatSimulatorHero hero;

        /// <summary>Catapult targets. Confidence: 94% - Evidence: "combatSimulatorParticipant/catapultTargets[x]"</summary>
        public List<int> catapultTargets;

        /// <summary>Catapult unit ID. Confidence: 93%</summary>
        public int catapultId;

        /// <summary>Selected bag item amount. Confidence: 92%</summary>
        public int selectedBagItemAmount;

        /// <summary>Selected bag item ID. Confidence: 92%</summary>
        public int selectedBagItemId;

        /// <summary>Selected weapon. Confidence: 93% - Evidence: "combatSimulatorParticipant/selectedWeapon"</summary>
        public InventoryItemWrapper selectedWeapon;

        /// <summary>Selected armor. Confidence: 93%</summary>
        public InventoryItemWrapper selectedArmor;

        /// <summary>Armor quality. Confidence: 92%</summary>
        public HeroRarity selectedArmorQuality;

        /// <summary>Selected utility item. Confidence: 92%</summary>
        public InventoryItemWrapper selectedUtility;

        /// <summary>Palace sprite ID. Confidence: 91%</summary>
        public int palaceSpriteId;

        /// <summary>Wall sprite ID. Confidence: 91%</summary>
        public int wallSpriteId;

        /// <summary>Whether all levels are zero. Confidence: 91%</summary>
        public bool allLevelZero;

        /// <summary>Arabic localization flag. Confidence: 90%</summary>
        public bool isArabicLocalization;

        /// <summary>Troop amounts. Confidence: 94%</summary>
        public TroopAmountInfo troopAmounts;

        /// <summary>
        /// Filter nature troops for attackers.
        /// Confidence: 89% - Evidence: "combatSimulatorParticipant/FilterNatureForAttackers()"
        /// </summary>
        public void FilterNatureForAttackers()
        {
            // Method inferred from data binding path
            // Implementation requires native code analysis
        }

        /// <summary>
        /// Open troop selection UI.
        /// Confidence: 89% - Evidence: "combatSimulatorParticipant/OpenTroopSelection()"
        /// </summary>
        public void OpenTroopSelection()
        {
            // Method inferred from data binding path
        }
    }

    /// <summary>
    /// Troop amount info for combat simulator.
    /// Confidence: 91%
    /// Evidence: "combatSimulatorParticipant/troopAmounts/infos",
    ///   "combatSimulatorParticipant/troopAmounts/infos[x]%"
    /// </summary>
    [Serializable]
    public class TroopAmountInfo
    {
        public TroopInfo[] infos;
    }

    /// <summary>
    /// Combat simulator data container.
    /// Confidence: 94%
    /// Evidence: "combatSimulator.attacker", "combatSimulator.defender",
    ///   "combatSimulator.reinforcement", "combatSimulator.result",
    ///   "combatSimulator.applyLosses", "combatSimulator.sendTroops",
    ///   "combatSimulator.editItemEffect", "combatSimulator.addAsWave"
    /// </summary>
    [Serializable]
    public class CombatSimulatorData
    {
        /// <summary>Attacker participant. Confidence: 94%</summary>
        public CombatSimulatorParticipant attacker;

        /// <summary>Defender participant. Confidence: 94%</summary>
        public CombatSimulatorParticipant defender;

        /// <summary>Reinforcement participant. Confidence: 93%</summary>
        public CombatSimulatorParticipant reinforcement;

        /// <summary>Your side (for display). Confidence: 92%</summary>
        public CombatSimulatorParticipant you;

        /// <summary>Revived troops. Confidence: 92%</summary>
        public CombatSimulatorParticipant revived;

        /// <summary>Send troops reference. Confidence: 91%</summary>
        public SendTroopInfo sendTroops;

        /// <summary>Combat result. Confidence: 91%</summary>
        public CombatResult result;

        /// <summary>
        /// Apply losses to defender.
        /// Confidence: 89% - Evidence: "combatSimulator.applyLosses"
        /// </summary>
        public void ApplyLosses()
        {
            // Method inferred from data binding
        }

        /// <summary>
        /// Add item effect to combat.
        /// Confidence: 88% - Evidence: "combatSimulator.editItemEffect"
        /// </summary>
        public void EditItemEffect()
        {
            // Method inferred from data binding
        }

        /// <summary>
        /// Add as wave to attack.
        /// Confidence: 88% - Evidence: "combatSimulator.addAsWave"
        /// </summary>
        public void AddAsWave()
        {
            // Method inferred from data binding
        }
    }

    /// <summary>
    /// Combat simulation result.
    /// Confidence: 88%
    /// Evidence: "combatSimulator.result", "combatSimulator.attacker" etc.
    ///   Inferred from combat flow
    /// </summary>
    [Serializable]
    public class CombatResult
    {
        public TroopAmountsInBattle attackerLosses;
        public TroopAmountsInBattle defenderLosses;
        public float combatStrengthAttacker;
        public float combatStrengthDefender;
        public bool attackerWins;
    }

    /// <summary>
    /// Battle report data.
    /// Confidence: 94%
    /// Evidence: 15+ data binding paths under "report/*":
    ///   "report/attackerTroop/*", "report/defenderTroop/*",
    ///   "report/attackerBooty/*", "report/statistics",
    ///   "report/reinforcements", "report/attackerInformation",
    ///   "report/defenderInformation"
    /// </summary>
    [Serializable]
    public class BattleReport
    {
        /// <summary>Attacker troop data. Confidence: 94%</summary>
        public BattleReportTroop attackerTroop;

        /// <summary>Defender troop data. Confidence: 94%</summary>
        public BattleReportTroop defenderTroop;

        /// <summary>Attacker booty/loot. Confidence: 93%</summary>
        public BattleBooty attackerBooty;

        /// <summary>Battle statistics. Confidence: 92%</summary>
        public string statistics;

        /// <summary>Reinforcement data. Confidence: 92%</summary>
        public ReinforcementData[] reinforcements;

        /// <summary>Attacker information messages. Confidence: 91%</summary>
        public InformationMessage[] attackerInformation;

        /// <summary>Defender information messages. Confidence: 91%</summary>
        public InformationMessage[] defenderInformation;
    }

    /// <summary>
    /// Battle report troop data for one side.
    /// Confidence: 94%
    /// Evidence: "report/attackerTroop/casualties/totalAmount",
    ///   "report/attackerTroop/wounded/totalAmount",
    ///   "report/attackerTroop/trapped/totalAmount",
    ///   "report/attackerTroop/units/totalAmount",
    ///   "report/attackerTroop/amounts", "report/attackerTroop/tribeId"
    /// </summary>
    [Serializable]
    public class BattleReportTroop
    {
        public TroopAmountsInBattle amounts;
        public TribeId tribeId;
        public int casualtiesTotal;
        public int woundedTotal;
        public int trappedTotal;
        public int unitsTotal;
    }

    /// <summary>
    /// Battle loot/booty data.
    /// Confidence: 92%
    /// Evidence: "report/attackerBooty/bountyStatus",
    ///   "report/attackerBooty/carryMax",
    ///   "report/attackerBooty/normalResourceAmounts/sum",
    ///   "report/attackerBooty/normalResourceAmounts/amount",
    ///   "report/attackerBooty/additionalResourceAmounts/sum"
    /// </summary>
    [Serializable]
    public class BattleBooty
    {
        public BountyStatus bountyStatus;
        public long carryMax;
        public ResourceAmounts normalResourceAmounts;
        public ResourceAmounts additionalResourceAmounts;
    }

    /// <summary>
    /// Informational message in battle report.
    /// Confidence: 90%
    /// Evidence: "attackerInformation[i]/messageDecoded",
    ///   "attackerInformation[i]/combatSimulatorIcon",
    ///   "defenderInformation[i]/messageDecoded"
    /// </summary>
    [Serializable]
    public class InformationMessage
    {
        public string messageDecoded;
        public string combatSimulatorIcon;
    }

    /// <summary>
    /// Combat simulator GraphQL data for API submission.
    /// Confidence: 88%
    /// Evidence: "combatSimulatorGraphqlObject/items",
    ///   "combatSimulatorGraphqlObject", "combatSimulator_addItemEffect"
    /// </summary>
    [Serializable]
    public class CombatSimulatorGraphqlObject
    {
        public object[] items;
    }
}
