// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/BuildingModels.cs
// ============================================================================
//
// Reconstructed from: Building data binding paths, building reference assets,
//                      construction queue, building detail bindings
// Confidence: 93%
// Evidence:
//   - buildingInfo/* paths (10+ bindings)
//   - 14 building reference assets (7 factions × day/night)
//   - 51 unique class/controller names from MonoBehaviour strings
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Building information for a single building instance.
    /// Confidence: 95%
    /// Evidence: Data binding paths:
    ///   "buildingInfo/building/level", "buildingInfo/building/buildingTypeId",
    ///   "buildingInfo/isUpgrading", "buildingInfo/levelIndicatorError"
    /// </summary>
    [Serializable]
    public class BuildingInfo
    {
        /// <summary>Building data. Confidence: 95%</summary>
        public Building building;

        /// <summary>Whether currently upgrading. Confidence: 95%</summary>
        public bool isUpgrading;

        /// <summary>Level indicator error state. Confidence: 93%</summary>
        public bool levelIndicatorError;

        /// <summary>Building info text lines. Confidence: 90%</summary>
        public string[] buildingInfoText;
    }

    /// <summary>
    /// Building data model.
    /// Confidence: 94%
    /// Evidence: "buildingInfo/building/buildingTypeId", "buildingInfo/building/level",
    ///   building type enum values from data binding
    /// </summary>
    [Serializable]
    public class Building
    {
        /// <summary>Building type ID (GID). Confidence: 96%</summary>
        public TypeId buildingTypeId;

        /// <summary>Current level. Confidence: 96%</summary>
        public int level;

        /// <summary>Maximum level. Confidence: 85% - Inferred</summary>
        public int maxLevel;
    }

    /// <summary>
    /// Selected building in the village view.
    /// Confidence: 93%
    /// Evidence: "selectedBuildingInfo/building/buildingTypeId",
    ///   "selectedBuildingInfo/building/level", "selectedBuildingInfo"
    /// </summary>
    [Serializable]
    public class SelectedBuildingInfo
    {
        public Building building;
    }

    /// <summary>
    /// Building drag-and-drop state.
    /// Confidence: 88%
    /// Evidence: "draggable", "emptyOrDraggable", "isRearranging" binding strings
    /// </summary>
    [Serializable]
    public class BuildingDragState
    {
        public bool draggable;
        public bool emptyOrDraggable;
        public bool isRearranging;
    }

    /// <summary>
    /// Demolish building popup data.
    /// Confidence: 90%
    /// Evidence: "DemolishBuildingPopupController" class name from MonoBehaviour strings,
    ///   "demolishBuildingPopup_title", "demolishBuildingPopup_descriptionWithSelection",
    ///   "demolishTime" localization keys
    /// </summary>
    [Serializable]
    public class DemolishBuildingData
    {
        public TypeId buildingType;
        public int currentLevel;
        public int targetLevel;
        public TimeSpan demolishTime;
    }

    /// <summary>
    /// Building arrangement/rearrangement data.
    /// Confidence: 87%
    /// Evidence: "ArrangementPopupController" class name,
    ///   "isRearranging" binding string
    /// </summary>
    [Serializable]
    public class ArrangementData
    {
        public bool isRearranging;
        // Unknown fields - marking as inferred
        // Evidence insufficient for full reconstruction
    }

    /// <summary>
    /// Building reference configuration per faction.
    /// Confidence: 92%
    /// Evidence: 14 named MonoBehaviour assets:
    ///   BuildingsEgyptianReferences, BuildingsGaulReferences,
    ///   BuildingsRomanReferences, BuildingsSpartanReferences,
    ///   BuildingsVikingReferences, BuildingsHunReferences,
    ///   BuildingsTeutonsReferences (each with Day/Night variants)
    /// </summary>
    [Serializable]
    public class BuildingReferenceConfig
    {
        public string name;
        public string type;
        public string faction;
    }
}
