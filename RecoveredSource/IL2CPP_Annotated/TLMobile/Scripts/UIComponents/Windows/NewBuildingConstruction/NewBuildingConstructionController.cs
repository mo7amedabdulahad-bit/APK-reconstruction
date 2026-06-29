// TLMobile.dll - TLMobile.Scripts.UIComponents.Windows.NewBuildingConstruction.NewBuildingConstructionController
// Extracted from IL2CPP metadata v39
// Method count: 45
// NOTE: Method bodies are stubs - require native decompilation

namespace TLMobile.Scripts.UIComponents.Windows.NewBuildingConstruction
{
    public class NewBuildingConstructionController
    {
        #region Constructors
        // 0x05143754
        public NewBuildingConstructionController() { }
        #endregion

        #region Methods
        // 0x0513FB94: Boolean get_detailPopupOpen()
        public bool get_detailPopupOpen() { return default; }
        // 0x0513FB9C: Void set_detailPopupOpen(Boolean)
        public void set_detailPopupOpen(bool) { return default; }
        // 0x0513FC30: Int32 get_masterBuilderCost()
        public int get_masterBuilderCost() { return default; }
        // 0x0513FC38: Void set_masterBuilderCost(Int32)
        public void set_masterBuilderCost(int) { return default; }
        // 0x0513FCCC: ObservableDictionary`2[System.Int32,ObservableList`1[TLMobile.Scripts.VillageView.BuildingInfo]] get_buildingsInCategory()
        public ObservableDictionary`2[System.Int32,ObservableList`1[TLMobile.Scripts.VillageView.BuildingInfo]] get_buildingsInCategory() { return default; }
        // 0x0513FCD4: Void set_buildingsInCategory(ObservableDictionary`2[System.Int32,ObservableList`1[TLMobile.Scripts.VillageView.BuildingInfo]])
        public void set_buildingsInCategory(ObservableDictionary`2[System.Int32,ObservableList`1[TLMobile.Scripts.VillageView.BuildingInfo]]) { return default; }
        // 0x0513FDD8: Void _buildingsInCategoryNotify(Object, PropertyChangedEventArgs)
        public void _buildingsInCategoryNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x0513FE34: ObservableDictionary`2[System.Int32,System.Int32] get_numberOfAvailableBuildingsInCategory()
        public ObservableDictionary`2[System.Int32,System.Int32] get_numberOfAvailableBuildingsInCategory() { return default; }
        // 0x0513FE3C: Void set_numberOfAvailableBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32])
        public void set_numberOfAvailableBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32]) { return default; }
        // 0x0513FF40: Void _numberOfAvailableBuildingsInCategoryNotify(Object, PropertyChangedEventArgs)
        public void _numberOfAvailableBuildingsInCategoryNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x0513FF9C: ObservableDictionary`2[System.Int32,System.Int32] get_numberOfUnavailableBuildingsInCategory()
        public ObservableDictionary`2[System.Int32,System.Int32] get_numberOfUnavailableBuildingsInCategory() { return default; }
        // 0x0513FFA4: Void set_numberOfUnavailableBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32])
        public void set_numberOfUnavailableBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32]) { return default; }
        // 0x051400A8: Void _numberOfUnavailableBuildingsInCategoryNotify(Object, PropertyChangedEventArgs)
        public void _numberOfUnavailableBuildingsInCategoryNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x05140104: ObservableDictionary`2[System.Int32,System.Int32] get_totalNumberOfBuildingsInCategory()
        public ObservableDictionary`2[System.Int32,System.Int32] get_totalNumberOfBuildingsInCategory() { return default; }
        // 0x0514010C: Void set_totalNumberOfBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32])
        public void set_totalNumberOfBuildingsInCategory(ObservableDictionary`2[System.Int32,System.Int32]) { return default; }
        // 0x05140210: Void _totalNumberOfBuildingsInCategoryNotify(Object, PropertyChangedEventArgs)
        public void _totalNumberOfBuildingsInCategoryNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x0514026C: BuildingInfo get_selectedBuilding()
        public BuildingInfo get_selectedBuilding() { return default; }
        // 0x05140274: Void set_selectedBuilding(BuildingInfo)
        public void set_selectedBuilding(BuildingInfo) { return default; }
        // 0x05140310: Boolean get_canSpeedUp()
        public bool get_canSpeedUp() { return default; }
        // 0x05140318: Void set_canSpeedUp(Boolean)
        public void set_canSpeedUp(bool) { return default; }
        // 0x051403AC: Resource get_resources()
        public Resource get_resources() { return default; }
        // 0x051403B4: Void set_resources(Resource)
        public void set_resources(Resource) { return default; }
        // 0x05140450: Int32 get_CurrentSlotId()
        public int get_CurrentSlotId() { return default; }
        // 0x05140458: Void set_CurrentSlotId(Int32)
        public void set_CurrentSlotId(int) { return default; }
        // 0x05140460: Void OnDestroy()
        public void OnDestroy() { return default; }
        // 0x05140588: Void Init(Int32)
        public void Init(int) { return default; }
        // 0x05140910: Int32 CalculateAvailableBuildings()
        public int CalculateAvailableBuildings() { return default; }
        // 0x05140A0C: Void CurrentVillageChanged(OwnVillage)
        public void CurrentVillageChanged(OwnVillage) { return default; }
        // 0x05140C20: Void PrepareCategories()
        public void PrepareCategories() { return default; }
        // 0x051419A8: Boolean IsValidSlot(Int32, Boolean, Boolean)
        public bool IsValidSlot(Int32, Boolean, Boolean) { return default; }
        // 0x05141AA4: Boolean CheckIfBuildingIsRestricted(BootstrapBuilding)
        public bool CheckIfBuildingIsRestricted(BootstrapBuilding) { return default; }
        // 0x05141E10: Void CalculateBuildingPrerequisitesAvailable(BuildingInfo, Boolean)
        public void CalculateBuildingPrerequisitesAvailable(BuildingInfo, Boolean) { return default; }
        // 0x051422A4: Boolean CheckIfBuildingIsRestrictedByAncientPower(BootstrapBuilding, BuildingInfo)
        public bool CheckIfBuildingIsRestrictedByAncientPower(BootstrapBuilding, BuildingInfo) { return default; }
        // 0x05142530: Void OpenDetailPopup(BuildingInfo)
        public void OpenDetailPopup(BuildingInfo) { return default; }
        // 0x05142728: Void UpdateLevelEffectKeys(Building+TypeId)
        public void UpdateLevelEffectKeys(Building+TypeId) { return default; }
        // 0x05142784: Void CloseDetailPopup()
        public void CloseDetailPopup() { return default; }
        // 0x051427C4: Void Hide()
        public void Hide() { return default; }
        // 0x051427E4: Void BuildSelectedBuilding(String, String)
        public void BuildSelectedBuilding(String, String) { return default; }
        // 0x05142C00: Int32 GetSlotIdToUse()
        public int GetSlotIdToUse() { return default; }
        // 0x05142C78: Void ObserveResourcesCallback()
        public void ObserveResourcesCallback() { return default; }
        // 0x05142F18: Void BuildSelectedBuildingWithBoost()
        public void BuildSelectedBuildingWithBoost() { return default; }
        // 0x05142FC0: Void TriggerNewBuildingRewardedAd(Action`1[String], BuildingInfo, Int32, Int32, Boolean)
        public void TriggerNewBuildingRewardedAd(Action`1[String], BuildingInfo, Int32, Int32, Boolean) { return default; }
        // 0x0514375C: Void <BuildSelectedBuilding>b__61_0(ApiResponse`1[System.Object])
        public void <BuildSelectedBuilding>b__61_0(ApiResponse`1[System.Object]) { return default; }
        // 0x051437B0: Void <BuildSelectedBuildingWithBoost>b__65_0(String)
        public void <BuildSelectedBuildingWithBoost>b__65_0(string) { return default; }
        #endregion
    }
}
