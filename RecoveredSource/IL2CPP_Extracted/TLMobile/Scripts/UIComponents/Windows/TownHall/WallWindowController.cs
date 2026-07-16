// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TownHall
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WallWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Scripts.VillageView.ExtensionInfo _extensionInfo;
		[ObservableValue]
		private bool _isCity;
		[ObservableValue]
		private int _currentlyBuildingLevelForExpansion;
		[ObservableValue]
		private ObservableDictionary<int, float?> _upgradeEffectsForExpansion;
		[ObservableValue]
		private string _levelEffectCurrentKeyForExpansion;
		[ObservableValue]
		private string _levelEffectDescriptionKeyForExpansion;
		[ObservableValue]
		private string _levelEffectAmountKeyForExpansion;
		[ObservableValue]
		private string _levelEffectAmountKeyInfoTabForExpansion;
		[ObservableValue]
		private string _nextLevelValueChangeInBracketsForExpansion;
		[ObservableValue]
		private float _nextLevelEffectValueForExpansion;
		[ObservableValue]
		private bool _showLevelEffectInUIForExpansion;
		[ObservableValue]
		private Wall _wall;
		[ObservableValue]
		private int _nextUpgradeLevel;
	
		// Properties
		[ObservableValue]
		public TLMobile.Scripts.VillageView.ExtensionInfo extensionInfo { get => default; set {} }
		[ObservableValue]
		public bool isCity { get => default; set {} }
		[ObservableValue]
		public int currentlyBuildingLevelForExpansion { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, float?> upgradeEffectsForExpansion { get => default; set {} }
		[ObservableValue]
		public string levelEffectCurrentKeyForExpansion { get => default; set {} }
		[ObservableValue]
		public string levelEffectDescriptionKeyForExpansion { get => default; set {} }
		[ObservableValue]
		public string levelEffectAmountKeyForExpansion { get => default; set {} }
		[ObservableValue]
		public string levelEffectAmountKeyInfoTabForExpansion { get => default; set {} }
		[ObservableValue]
		public string nextLevelValueChangeInBracketsForExpansion { get => default; set {} }
		[ObservableValue]
		public float nextLevelEffectValueForExpansion { get => default; set {} }
		[ObservableValue]
		public bool showLevelEffectInUIForExpansion { get => default; set {} }
		[ObservableValue]
		public Wall wall { get => default; set {} }
		[ObservableValue]
		public int nextUpgradeLevel { get => default; set {} }
	
		// Constructors
		public WallWindowController() {}
	
		// Methods
		private void _upgradeEffectsForExpansionNotify(object sender, PropertyChangedEventArgs args) {}
		[Testable]
		protected override void CurrentVillageChanged(OwnVillage newVill) {}
		[Testable]
		protected override void UpdateBuildingData(OwnVillage newVillage) {}
		private void ObserveOnCurrentVillage() {}
		private void UpdateWall() {}
		private void StopObservingCurrentVillage() {}
		protected override void NewBuildingInfo(OwnVillage newVill) {}
		protected override void UpdateUpgradeTabData(OwnVillage village) {}
		private void UpdateLevelEffectKeysForExtension(Building.TypeId buildingType) {}
	}
