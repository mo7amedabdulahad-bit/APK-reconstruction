// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WatchTowerUpgradeTabController : InjectableViewModel
	{
		// Fields
		private const int MaxParallelUpgrades = 2;
		public SpriteCfg buildingEffectSpritesFromConfig;
		[InjectableValue]
		[ObservableValue]
		private Building _currentBuilding;
		[InjectableValue]
		[ObservableValue]
		private int _buildingType;
		[ObservableValue]
		private Sprite _buildingEffectSprite;
		[ObservableValue]
		private TLMobile.Scripts.VillageView.ExtensionInfo _extensionInfo;
		[ObservableValue]
		private GoldActionPrices _goldActionPrices;
		[ObservableValue]
		private Wall _ownWall;
		[ObservableValue]
		private string _watchTowerName;
		[ObservableValue]
		private int _maxParallelUpgrades;
		private OwnVillage currentVillage;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public Building currentBuilding { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public int buildingType { get => default; set {} }
		[ObservableValue]
		public Sprite buildingEffectSprite { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.VillageView.ExtensionInfo extensionInfo { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices goldActionPrices { get => default; set {} }
		[ObservableValue]
		public Wall ownWall { get => default; set {} }
		[ObservableValue]
		public string watchTowerName { get => default; set {} }
		[ObservableValue]
		public int maxParallelUpgrades { get => default; set {} }
	
		// Constructors
		public WatchTowerUpgradeTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected virtual void OnEnable() {}
		private void OnDisable() {}
		private void OnLanguageChanged() {}
		public override void OnInjectedValueChanged() {}
		public virtual void Init() {}
		protected override void OnDestroy() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void UpdateTabData() {}
		[UICallable]
		public void UpgradeWatchTower() {}
		[UICallable]
		public void OpenConstructionList() {}
	}
