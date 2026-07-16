// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RearrangeBuildingsPopupController : ArrangementPopupController
	{
		// Fields
		[ObservableValue]
		private ObservableDictionary<int, int> _idRearrangedSlotID;
		[ObservableValue]
		private ObservableList<BuildingInfo> _rearrangedBuildings;
		[ObservableValue]
		private BuildingInfo _swappedBuildingInfo;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<int, int> idRearrangedSlotID { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> rearrangedBuildings { get => default; set {} }
		[ObservableValue]
		public BuildingInfo swappedBuildingInfo { get => default; set {} }
	
		// Constructors
		public RearrangeBuildingsPopupController() {}
	
		// Methods
		private void _idRearrangedSlotIDNotify(object sender, PropertyChangedEventArgs args) {}
		private void _rearrangedBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override void OnBuildingsInVillageChanged() {}
		public override void SetIsRearranging(bool isRearranging) {}
		public void RearrangeBuilding(BuildingInfo draggedBuilding, int? previousPlaceId = default, int? currentPlaceId = default) {}
		private void UpdateRearrangedBuildings(BuildingInfo draggedBuilding) {}
		protected override bool CheckBuildingIsDraggable(BuildingInfo buildingInfo) => default;
		protected override void DoOnNotDraggable() {}
		[UICallable]
		public void ConfirmRearrangeBuildings() {}
		private void RearrangeBuildings() {}
		protected override void UpdateSiblingIndexOfSelectedBuildingDroppable(List<BuildingDroppable> allBuildingDroppables, int sortedBuildingDroppablesCount, int sortedLevelIndicatorsCount) {}
		protected override void UpdateSiblingIndexOfSelectedBuildingDroppableLevelIndicators(List<LevelIndicator> levelIndicators, int sortedBuildingDroppablesCount, int sortedLevelIndicatorsCount) {}
		protected override void SortOutBuildingDroppables(List<BuildingDroppable> sortedBuildingDroppables) {}
		protected override void SortOutLevelIndicators(List<LevelIndicator> sortedLevelIndicators) {}
	}
