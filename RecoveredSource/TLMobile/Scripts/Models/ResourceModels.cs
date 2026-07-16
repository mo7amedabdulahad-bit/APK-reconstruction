// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/ResourceModels.cs
// ============================================================================
//
// Reconstructed from: Data binding paths, localization keys, resource system
// Confidence: 95%
// Evidence:
//   - 200+ data binding paths referencing resource fields
//   - "resourcesCostInfo/cost/{resource}", "resourceAmounts/{resource}"
//   - "resourcesCostInfo/difference/{resource}", "resourcesCostInfo/ownHero/resourceAmounts/{resource}"
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Resource amount container for the 4 resource types.
    /// Confidence: 98%
    /// Evidence: Data binding paths consistently reference wood/clay/iron/crop
    ///   across 200+ UI binding expressions. Resource costs, production, and
    ///   storage all use this structure.
    /// </summary>
    [Serializable]
    public class ResourceAmounts
    {
        /// <summary>Wood amount. Confidence: 98% - Evidence: "resourcesCostInfo/cost/wood"</summary>
        public long wood;

        /// <summary>Clay amount. Confidence: 98% - Evidence: "resourcesCostInfo/cost/clay"</summary>
        public long clay;

        /// <summary>Iron amount. Confidence: 98% - Evidence: "resourcesCostInfo/cost/iron"</summary>
        public long iron;

        /// <summary>Crop amount. Confidence: 98% - Evidence: "resourcesCostInfo/cost/crop"</summary>
        public long crop;

        public ResourceAmounts() { }

        public ResourceAmounts(long wood, long clay, long iron, long crop)
        {
            this.wood = wood;
            this.clay = clay;
            this.iron = iron;
            this.crop = crop;
        }

        /// <summary>
        /// Get resource amount by type index.
        /// Confidence: 90% - Inferred from enum usage pattern
        /// </summary>
        public long GetAmount(ResourceType type)
        {
            return type switch
            {
                ResourceType.Wood => wood,
                ResourceType.Clay => clay,
                ResourceType.Iron => iron,
                ResourceType.Crop => crop,
                _ => 0
            };
        }

        public static ResourceAmounts operator +(ResourceAmounts a, ResourceAmounts b)
        {
            return new ResourceAmounts(a.wood + b.wood, a.clay + b.clay, a.iron + b.iron, a.crop + b.crop);
        }

        public static ResourceAmounts operator -(ResourceAmounts a, ResourceAmounts b)
        {
            return new ResourceAmounts(a.wood - b.wood, a.clay - b.clay, a.iron - b.iron, a.crop - b.crop);
        }
    }

    /// <summary>
    /// Resource production rates per hour.
    /// Confidence: 85%
    /// Evidence: "resourceAmounts/iron", "resourceAmounts/clay",
    ///   "resourceAmounts/wood" in data binding paths,
    ///   village production display in localization
    ///   Inferred from standard Travian production model
    /// </summary>
    [Serializable]
    public class ResourceProduction
    {
        public ResourceAmounts baseRate;
        public ResourceAmounts bonusRate;
        public ResourceAmounts oasisBonus;
        public ResourceAmounts artifactBonus;
        public ResourceAmounts allianceBonus;
        public ResourceAmounts plusBonus;

        public ResourceAmounts GetTotalProduction()
        {
            return baseRate + bonusRate + oasisBonus + artifactBonus + allianceBonus + plusBonus;
        }
    }

    /// <summary>
    /// Resource cost display model with difference calculation.
    /// Confidence: 96%
    /// Evidence: Data binding paths:
    ///   "resourcesCostInfo/cost/wood", "resourcesCostInfo/ownHero/resourceAmounts/wood",
    ///   "resourcesCostInfo/difference/wood", "resourcesCostInfo/isButtonDisabled"
    /// </summary>
    [Serializable]
    public class ResourceCostInfo
    {
        /// <summary>Required resources. Confidence: 96%</summary>
        public ResourceAmounts cost;

        /// <summary>Player's current resources. Confidence: 95%</summary>
        public ResourceAmounts ownHero;

        /// <summary>Difference (own - cost). Confidence: 94%</summary>
        public ResourceAmounts difference;

        /// <summary>Whether the confirm button should be disabled. Confidence: 95%</summary>
        public bool isButtonDisabled;

        /// <summary>
        /// Calculate if player can afford the cost.
        /// Confidence: 90% - Inferred from isButtonDisabled binding
        /// </summary>
        public bool CanAfford()
        {
            return ownHero.wood >= cost.wood &&
                   ownHero.clay >= cost.clay &&
                   ownHero.iron >= cost.iron &&
                   ownHero.crop >= cost.crop;
        }
    }

    /// <summary>
    /// Warehouse and granary storage capacity.
    /// Confidence: 82%
    /// Evidence: Building types Warehouse (gid13) and Granary (gid14),
    ///   localization keys for storage capacity
    ///   Inferred from standard Travian mechanics
    /// </summary>
    [Serializable]
    public class StorageCapacity
    {
        public long warehouseCapacity;
        public long granaryCapacity;
        public ResourceAmounts currentStorage;
    }
}
