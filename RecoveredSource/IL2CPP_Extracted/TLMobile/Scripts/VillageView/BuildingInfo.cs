// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingInfo : ObservableModel, IMoveableDroppable, CustomIdentityRepeatedObject
	{
		// Fields
		[ObservableValue]
		private Sprite _buildingEffectSprite;
		[ObservableValue]
		private string _levelEffectAmountKey;
		[ObservableValue]
		private TLMobile.Scripts.VillageView.PositionInfo _rearrangedVillagePosition;
		[ObservableValue]
		private SlotSpriteType _slotSpriteType;
		[ObservableValue]
		private bool _isMissingAncientPowerRequirement;
		private const GeneralErrorType MaxReachedCondition = GeneralErrorType.None | GeneralErrorType.MaxReached | GeneralErrorType.MaxWillBeReached;
		private const GeneralErrorType RequirementMissingCondition = GeneralErrorType.None | GeneralErrorType.ExtendWarehouse | GeneralErrorType.ExtendGranary | GeneralErrorType.ExtendWarehouseAndGranary | GeneralErrorType.RequirementMissing;
		private const GeneralErrorType NotEnoughResourcesOrSlotsCondition = GeneralErrorType.None | GeneralErrorType.NotEnoughResources | GeneralErrorType.NegativeCropProduction | GeneralErrorType.FreeCrop | GeneralErrorType.QueueFull;
		private const int cityMaxResourceLevel = 12;
		private const int capitalMaxResourceLevel = 20;
		private const float TimeBoostFactor = 0.75f;
		private const float BaseCropProductionFactor = 0.05f;
		private const int CroplandProductionLevel = 5;
		private const int CroplandProductionAmount = 6;
		[ObservableValue]
		private int _spriteIndex;
		[ObservableValue]
		private int _adjustedBuildingType;
		[ObservableValue]
		private Building _building;
		[ObservableValue]
		private BootstrapBuilding _currentBuildingData;
		[ObservableValue]
		private BootstrapBuildingLevel _currentBuildingLevelData;
		[ObservableValue]
		private BootstrapBuildingLevel _nextBuildingLevelData;
		[ObservableValue]
		private BootstrapBuildingLevel _levelDifferenceData;
		[ObservableValue]
		private int _buildingTime;
		[ObservableValue]
		private int _buildingTimeWithBoost;
		[ObservableValue]
		private int _buildingTimeWithBoostPercentage;
		[ObservableValue]
		private GeneralErrorType _upgradeError;
		[ObservableValue]
		private LevelIndicatorError _levelIndicatorError;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private int _usedPopulation;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
		[ObservableValue]
		private TLMobile.Scripts.VillageView.PositionInfo _villagePosition;
		[ObservableValue]
		private ObservableList<RequiredBuilding> _requiredBuildings;
		[ObservableValue]
		private bool _masterBuilderButtonActivated;
		[ObservableValue]
		private bool _masterBuilderDisabled;
		[ObservableValue]
		private bool _boostButtonDisabled;
		[ObservableValue]
		private bool _isUpgrading;
		[ObservableValue]
		private bool _enoughGoldToQueueMasterBuilderTasks;
		[ObservableValue]
		private BuildingHitboxTypes _hitboxType;
		[ObservableValue]
		private bool _requiresShore;
		[ObservableValue]
		private bool _requiresCity;
		private int currentLevelData;
	
		// Properties
		[ObservableValue]
		public int spriteIndex { get => default; set {} }
		[ObservableValue]
		public int adjustedBuildingType { get => default; set {} }
		[ObservableValue]
		public Building building { get => default; set {} }
		[ObservableValue]
		public BootstrapBuilding currentBuildingData { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingLevel currentBuildingLevelData { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingLevel nextBuildingLevelData { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingLevel levelDifferenceData { get => default; set {} }
		[ObservableValue]
		public int buildingTime { get => default; set {} }
		[ObservableValue]
		public int buildingTimeWithBoost { get => default; set {} }
		[ObservableValue]
		public int buildingTimeWithBoostPercentage { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType upgradeError { get => default; set {} }
		[ObservableValue]
		public LevelIndicatorError levelIndicatorError { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public int usedPopulation { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.VillageView.PositionInfo villagePosition { get => default; set {} }
		[ObservableValue]
		public ObservableList<RequiredBuilding> requiredBuildings { get => default; set {} }
		[ObservableValue]
		public bool masterBuilderButtonActivated { get => default; set {} }
		[ObservableValue]
		public bool masterBuilderDisabled { get => default; set {} }
		[ObservableValue]
		public bool boostButtonDisabled { get => default; set {} }
		[ObservableValue]
		public bool isUpgrading { get => default; set {} }
		[ObservableValue]
		public bool enoughGoldToQueueMasterBuilderTasks { get => default; set {} }
		[ObservableValue]
		public BuildingHitboxTypes hitboxType { get => default; set {} }
		[ObservableValue]
		public bool requiresShore { get => default; set {} }
		[ObservableValue]
		public bool requiresCity { get => default; set {} }
		[ObservableValue]
		public Sprite buildingEffectSprite { get => default; set {} }
		[ObservableValue]
		public string levelEffectAmountKey { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.VillageView.PositionInfo rearrangedVillagePosition { get => default; set {} }
		[ObservableValue]
		public SlotSpriteType slotSpriteType { get => default; set {} }
		[ObservableValue]
		public bool isMissingAncientPowerRequirement { get => default; set {} }
		[ObservableValue]
		public ObservableList<string> BuildingInfoDescription { get => default; }
	
		// Nested types
		public enum SlotSpriteType
		{
			Default = 0,
			RallyPoint = 1,
			Harbor = 2,
			CityHarbor = 3
		}
	
		// Constructors
		[Obsolete("Added only for TGFramework compatibility. Use the constructor with parameters.")]
		public BuildingInfo() {}
		public BuildingInfo(int tribeId, int buildingTypeId) {}
		public BuildingInfo(int tribeId, Building building) {}
	
		// Methods
		private void _requiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		public IPromise CallMoveDroppable(int? target, int selectedAmount, System.Action afterSuccessCallback = null, Action<Exception> afterFailCallback = null) => default;
		public void UpdateSlotSpriteType(int? slotid = default, OwnVillage ownVillage = null) {}
		public static void GetLevelEffectKeys(Building.TypeId buildingType, out string levelEffectAmountKey, out string levelEffectAmountKeyInfoTab, out string nextLevelValueChangeInBrackets, out bool showLevelEffectInUI) {
			levelEffectAmountKey = default;
			levelEffectAmountKeyInfoTab = default;
			nextLevelValueChangeInBrackets = default;
			showLevelEffectInUI = default;
		}
		public void SetRearrangedPosition(Vector3 position, int sortingOrder) {}
		public void UpdateBuildingInfo(int tribeId, Building building) {}
		private void Setup(int tribeId, Building building) {}
		private void TryFetchBoostrapData(int buildingType, int currentLevel) {}
		public void SetPosition(Vector3 position, int sortingOrder) {}
		private void SetBuildingTime(OwnVillage ownVillage, int targetLevel) {}
		public void UpdateUpgradeAvailability(OwnVillage currentVillage) {}
		public static int GetSpriteIndex(int tribeId, int buildingTypeId, int level = 0, bool? isCity = default, bool? hasWatchTowers = default) => default;
		public void UpdateHitboxType(int slotId, OwnVillage ownVillage = null) {}
		public void UpdateHitboxType(OwnVillage ownVillage = null) {}
		private void UpdateLevelIndicator() {}
		public int GetRepeatIdentity() => default;
	}
