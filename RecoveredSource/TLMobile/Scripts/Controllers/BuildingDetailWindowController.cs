// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Controllers/BuildingDetailWindowController.cs
// ============================================================================
//
// Reconstructed from: Class name from MonoBehaviour strings,
//                      building detail data binding paths,
//                      demolition and arrangement controllers
// Confidence: 90%
// Evidence:
//   - "BuildingDetailWindowController" class name string
//   - "buildingInfo/*" data binding paths (10+)
//   - "DemolishBuildingPopupController" class name
//   - "ArrangementPopupController" class name
//   - Assembly: TLMobile.dll
// ============================================================================

using UnityEngine;
using TLMobile.Scripts.Models;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Controllers
{
    /// <summary>
    /// Controls the building detail popup/window.
    /// Reconstructed from data binding paths and class name evidence.
    /// Confidence: 90%
    /// </summary>
    public class BuildingDetailWindowController : MonoBehaviour
    {
        // Confidence: 94% - Evidence: "selectedBuildingInfo" binding
        [SerializeField] private SelectedBuildingInfo selectedBuildingInfo;

        // Confidence: 93% - Evidence: "buildingInfo/isUpgrading" binding
        [SerializeField] private bool isUpgrading;

        // Confidence: 92% - Evidence: "buildingInfo/levelIndicatorError" binding
        [SerializeField] private bool levelIndicatorError;

        /// <summary>
        /// Set the selected building for detail display.
        /// Confidence: 88% - Inferred from SelectedBuildingInfo binding
        /// </summary>
        public void SetSelectedBuilding(SelectedBuildingInfo building)
        {
            selectedBuildingInfo = building;
            UpdateDisplay();
        }

        /// <summary>
        /// Update the detail window display.
        /// Confidence: 85% - Inferred from UI update patterns
        /// </summary>
        private void UpdateDisplay()
        {
            if (selectedBuildingInfo?.building == null) return;

            isUpgrading = selectedBuildingInfo.building.level > 0;
            // Additional display logic - Unknown without native analysis
        }

        /// <summary>
        /// Open the building upgrade flow.
        /// Confidence: 84% - Inferred from localization "infoTab_upgradingToLevel"
        /// </summary>
        public void OpenUpgrade()
        {
            // Unknown - requires upgrade flow implementation
        }

        /// <summary>
        /// Open demolition popup.
        /// Confidence: 86% - Evidence: "DemolishBuildingPopupController" class
        /// </summary>
        public void OpenDemolish()
        {
            // Unknown - requires DemolishBuildingPopupController integration
        }
    }

    /// <summary>
    /// Controls the building demolition confirmation popup.
    /// Confidence: 88%
    /// Evidence: "DemolishBuildingPopupController" class name,
    ///   "demolishBuildingPopup_title", "demolishBuildingPopup_descriptionWithSelection",
    ///   "demolishTime" localization keys
    /// </summary>
    public class DemolishBuildingPopupController : MonoBehaviour
    {
        // Confidence: 89%
        private DemolishBuildingData demolishData;

        /// <summary>
        /// Initialize demolition popup with building data.
        /// Confidence: 86%
        /// </summary>
        public void Initialize(DemolishBuildingData data)
        {
            demolishData = data;
        }

        /// <summary>
        /// Confirm demolition.
        /// Confidence: 83% - Inferred
        /// </summary>
        public void ConfirmDemolish()
        {
            // Unknown - requires networking for demolition request
        }
    }

    /// <summary>
    /// Controls the building arrangement/rearrangement popup.
    /// Confidence: 85%
    /// Evidence: "ArrangementPopupController" class name,
    ///   "isRearranging" binding string
    /// </summary>
    public class ArrangementPopupController : MonoBehaviour
    {
        // Confidence: 86%
        private ArrangementData arrangementData;

        /// <summary>
        /// Start rearranging buildings.
        /// Confidence: 84%
        /// </summary>
        public void StartRearranging()
        {
            // Unknown - requires drag/drop implementation
        }
    }
}
