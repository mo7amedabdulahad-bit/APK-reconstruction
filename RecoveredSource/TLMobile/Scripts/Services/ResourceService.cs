// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Services/ResourceService.cs
// ============================================================================
//
// Reconstructed from: Resource data binding paths, production system,
//                      storage, resource cost calculations
// Confidence: 86%
// Evidence:
//   - resourceAmounts/* paths, resourcesCostInfo/* paths
//   - ResourceType enum (4 types)
//   - "resourceAmounts/iron", "resourceAmounts/clay", "resourceAmounts/wood"
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using Cysharp.Threading.Tasks;
using TLMobile.Scripts.Models;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Services
{
    /// <summary>
    /// Service managing resource production, storage, and calculations.
    /// Confidence: 86%
    /// Evidence: Resource data binding paths, production display, storage system
    /// </summary>
    public class ResourceService
    {
        /// <summary>
        /// Get resource production rates for a village.
        /// Confidence: 84% - Inferred from production display
        /// </summary>
        public ResourceProduction GetProduction(long villageId)
        {
            // Unknown - requires server data
            return new ResourceProduction();
        }

        /// <summary>
        /// Get current resource storage.
        /// Confidence: 83%
        /// </summary>
        public ResourceAmounts GetStorage(long villageId)
        {
            // Unknown
            return new ResourceAmounts();
        }

        /// <summary>
        /// Get warehouse/granary capacity.
        /// Confidence: 82% - Inferred from Warehouse (gid13), Granary (gid14) buildings
        /// </summary>
        public StorageCapacity GetCapacity(long villageId)
        {
            // Unknown
            return new StorageCapacity();
        }

        /// <summary>
        /// Calculate resource cost difference.
        /// Confidence: 85% - Evidence: "resourcesCostInfo/difference/*" bindings
        /// </summary>
        public ResourceAmounts CalculateDifference(ResourceAmounts cost, ResourceAmounts available)
        {
            return new ResourceAmounts(
                available.wood - cost.wood,
                available.clay - cost.clay,
                available.iron - cost.iron,
                available.crop - cost.crop
            );
        }

        /// <summary>
        /// Check if resources are sufficient.
        /// Confidence: 85% - Evidence: "resourcesCostInfo/isButtonDisabled" binding
        /// </summary>
        public bool HasSufficientResources(ResourceAmounts cost, ResourceAmounts available)
        {
            return available.wood >= cost.wood &&
                   available.clay >= cost.clay &&
                   available.iron >= cost.iron &&
                   available.crop >= cost.crop;
        }

        /// <summary>
        /// Get hero resource amounts.
        /// Confidence: 84% - Evidence: "resourcesCostInfo/ownHero/resourceAmounts/*"
        /// </summary>
        public ResourceAmounts GetHeroResources()
        {
            // Unknown
            return new ResourceAmounts();
        }
    }
}
