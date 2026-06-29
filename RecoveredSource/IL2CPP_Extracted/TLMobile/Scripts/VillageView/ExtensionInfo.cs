// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExtensionInfo : ObservableModel
	{
		// Fields
		private const GeneralErrorType MaxReachedCondition = GeneralErrorType.None | GeneralErrorType.MaxReached | GeneralErrorType.MaxWillBeReached;
		private const GeneralErrorType RequirementMissingCondition = GeneralErrorType.None | GeneralErrorType.ExtendWarehouse | GeneralErrorType.ExtendGranary | GeneralErrorType.ExtendWarehouseAndGranary | GeneralErrorType.RequirementMissing;
		private const GeneralErrorType NotEnoughResourcesOrSlotsCondition = GeneralErrorType.None | GeneralErrorType.NotEnoughResources | GeneralErrorType.NegativeCropProduction | GeneralErrorType.FreeCrop | GeneralErrorType.QueueFull;
		[ObservableValue]
		private Building _building;
		[ObservableValue]
		private BootstrapBuildingExtension _bootstrapBuildingExtension;
		[ObservableValue]
		private BootstrapBuildingExtensionLevel _currentExtensionLevelData;
		[ObservableValue]
		private BootstrapBuildingExtensionLevel _nextExtensionLevelData;
		[ObservableValue]
		private BootstrapBuildingExtensionLevel _extensionLevelDifferenceData;
		[ObservableValue]
		private int _buildingTime;
		[ObservableValue]
		private GeneralErrorType _upgradeError;
		[ObservableValue]
		private LevelIndicatorError _levelIndicatorError;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private ObservableList<RequiredBuilding> _requiredBuildings;
		[ObservableValue]
		private bool _masterBuilderButtonActivated;
		[ObservableValue]
		private bool _masterBuilderDisabled;
		[ObservableValue]
		private bool _isUpgrading;
		[ObservableValue]
		private bool _enoughGoldToQueueMasterBuilderTasks;
		[ObservableValue]
		private Wall _wall;
		[ObservableValue]
		private string _extensionName;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
	
		// Properties
		[ObservableValue]
		public Building building { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingExtension bootstrapBuildingExtension { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingExtensionLevel currentExtensionLevelData { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingExtensionLevel nextExtensionLevelData { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingExtensionLevel extensionLevelDifferenceData { get => default; set {} }
		[ObservableValue]
		public int buildingTime { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType upgradeError { get => default; set {} }
		[ObservableValue]
		public LevelIndicatorError levelIndicatorError { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public ObservableList<RequiredBuilding> requiredBuildings { get => default; set {} }
		[ObservableValue]
		public bool masterBuilderButtonActivated { get => default; set {} }
		[ObservableValue]
		public bool masterBuilderDisabled { get => default; set {} }
		[ObservableValue]
		public bool isUpgrading { get => default; set {} }
		[ObservableValue]
		public bool enoughGoldToQueueMasterBuilderTasks { get => default; set {} }
		[ObservableValue]
		public Wall wall { get => default; set {} }
		[ObservableValue]
		public string extensionName { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
	
		// Constructors
		public ExtensionInfo() {} // Dummy constructor
		public ExtensionInfo(Building building) {}
	
		// Methods
		private void _requiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void UpdateResourceInfo() {}
		private void TryFetchBoostrapData(int buildingType) {}
		public void UpdateUpgradeAvailabilityForExtension(OwnVillage currentVillage, Wall wall = null) {}
		private void SetBuildingTime(OwnVillage ownVillage, int targetLevel) {}
		public static void GetLevelEffectKeys(Building.TypeId buildingType, out string levelEffectAmountKey, out string levelEffectAmountKeyInfoTab, out string nextLevelValueChangeInBrackets, out bool showLevelEffectInUI) {
			levelEffectAmountKey = default;
			levelEffectAmountKeyInfoTab = default;
			nextLevelValueChangeInBrackets = default;
			showLevelEffectInUI = default;
		}
		private void UpdateLevelIndicator() {}
	}
