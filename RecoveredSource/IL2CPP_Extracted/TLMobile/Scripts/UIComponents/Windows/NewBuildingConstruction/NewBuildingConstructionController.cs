// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.NewBuildingConstruction
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NewBuildingConstructionController : DetailWindowController
	{
		// Fields
		public SpriteCfg buildingEffectSpritesFromConfig;
		private OwnVillage currentVillage;
		private bool hasStorageArtefact;
		private bool useAncientPowers;
		[ObservableValue]
		private bool _detailPopupOpen;
		[ObservableValue]
		private int _masterBuilderCost;
		[ObservableValue]
		private ObservableDictionary<int, ObservableList<BuildingInfo>> _buildingsInCategory;
		[ObservableValue]
		private ObservableDictionary<int, int> _numberOfAvailableBuildingsInCategory;
		[ObservableValue]
		private ObservableDictionary<int, int> _numberOfUnavailableBuildingsInCategory;
		[ObservableValue]
		private ObservableDictionary<int, int> _totalNumberOfBuildingsInCategory;
		[ObservableValue]
		private BuildingInfo _selectedBuilding;
		[ObservableValue]
		private bool _canSpeedUp;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Resource _resources;
		private GraphQLFetchableList<OwnVillage> villages;
	
		// Properties
		[ObservableValue]
		public bool detailPopupOpen { get => default; set {} }
		[ObservableValue]
		public int masterBuilderCost { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, ObservableList<BuildingInfo>> buildingsInCategory { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, int> numberOfAvailableBuildingsInCategory { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, int> numberOfUnavailableBuildingsInCategory { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, int> totalNumberOfBuildingsInCategory { get => default; set {} }
		[ObservableValue]
		public BuildingInfo selectedBuilding { get => default; set {} }
		[ObservableValue]
		public bool canSpeedUp { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Resource resources { get => default; set {} }
		public int CurrentSlotId { get; private set; }
	
		// Constructors
		public NewBuildingConstructionController() {}
	
		// Methods
		private void _buildingsInCategoryNotify(object sender, PropertyChangedEventArgs args) {}
		private void _numberOfAvailableBuildingsInCategoryNotify(object sender, PropertyChangedEventArgs args) {}
		private void _numberOfUnavailableBuildingsInCategoryNotify(object sender, PropertyChangedEventArgs args) {}
		private void _totalNumberOfBuildingsInCategoryNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnDestroy() {}
		public void Init(int slotId) {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void PrepareCategories() {}
		private bool CheckIfBuildingIsRestricted(BootstrapBuilding buildingBootstrapData) => default;
		private bool CheckIfBuildingIsRestrictedByAncientPower(BootstrapBuilding buildingBootstrapData, BuildingInfo buildingInfo) => default;
		private int CalculateAvailableBuildings() => default;
		private bool IsValidSlot(int buildingId, bool isWWVillage, bool isShore) => default;
		[UICallable]
		public void OpenDetailPopup(BuildingInfo clickedBuilding) {}
		private void UpdateLevelEffectKeys(Building.TypeId buildingType) {}
		[UICallable]
		public void CloseDetailPopup() {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void BuildSelectedBuilding(string useMasterBuilder = "false", string adSalesToken = null) {}
		private int GetSlotIdToUse() => default;
		private void ObserveResourcesCallback() {}
		private void CalculateBuildingPrerequisitesAvailable(BuildingInfo buildingInfo, bool hasStorageArtefact) {}
		[UICallable]
		public void BuildSelectedBuildingWithBoost() {}
		private void TriggerNewBuildingRewardedAd(Action<string> onSuccess, BuildingInfo selectedBuilding, int villageId, int slotId, bool tryShowPopup) {}
	}
