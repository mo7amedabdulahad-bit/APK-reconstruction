// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericUpgradeTabController : InjectableViewModel
	{
		// Fields
		public SpriteCfg buildingEffectSpritesFromConfig;
		[ObservableValue]
		private Sprite _buildingEffectSprite;
		[InjectableValue]
		[ObservableValue]
		private int _buildingType;
		[InjectableValue]
		[ObservableValue]
		private int _currentBuildingLevel;
		[InjectableValue]
		[ObservableValue]
		private Building _currentBuilding;
		[InjectableValue]
		[ObservableValue]
		private bool _canSpeedup;
		[ObservableValue]
		private GoldActionPrices _goldActionPrices;
		[ObservableValue]
		private BuildingInfo _selectedBuilding;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public Sprite buildingEffectSprite { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public int buildingType { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public int currentBuildingLevel { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public Building currentBuilding { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public bool canSpeedup { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices goldActionPrices { get => default; set {} }
		[ObservableValue]
		public BuildingInfo selectedBuilding { get => default; set {} }
	
		// Constructors
		public GenericUpgradeTabController() {}
	
		// Methods
		protected virtual void OnEnable() {}
		public override void OnInjectedValueChanged() {}
		public virtual void Init(int buildingTypeToUse, int currentLevelToUse = 0) {}
		protected override void OnDestroy() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		protected virtual void UpdateTabData() {}
		[UICallable]
		public void UpgradeBuilding(Building building, bool useMasterBuilder = false, string adSalesToken = null) {}
		[UICallable]
		public void UpgradeBuildingWithBoost() {}
		private void TriggerBuildingRewardedAd(Action<string> onSuccess, BuildingInfo selectedBuilding, int villageId, int slotId, bool tryShowPopup) {}
	}
