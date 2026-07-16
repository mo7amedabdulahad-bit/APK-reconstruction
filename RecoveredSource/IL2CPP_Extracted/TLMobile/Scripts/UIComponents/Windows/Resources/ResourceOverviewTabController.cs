// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Resources
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceOverviewTabController : DetailWindowTabController
	{
		// Fields
		private static readonly string[] TabLocalizationKeys;
		[ObservableValue]
		private ResourceTypes _type;
		[ObservableValue]
		private ObservableList<BuildingInfo> _productionBuildings;
		[ObservableValue]
		private ObservableList<BuildingInfo> _bonusBuildings;
		[ObservableValue]
		private ObservableList<OccupiedOasis> _bonusOases;
		[ObservableValue]
		private SubscriptionFeature _goldFeature;
		[ObservableValue]
		private int _productionFromBuildings;
		[ObservableValue]
		private int _productionBonusPercent;
		[ObservableValue]
		private int _productionBonus;
		[ObservableValue]
		private int _productionFromHero;
		[ObservableValue]
		private int _productionFromGoldFeature;
		[ObservableValue]
		private int _productionInterimBalance;
		[ObservableValue]
		private int _productionTotal;
		[ObservableValue]
		private int _productionWithBonus;
		[ObservableValue]
		private int _goldFeatureCost;
		[ObservableValue]
		private string _tabTitleLocalizationKey;
		[ObservableValue]
		private bool _hasActiveVideoFeatureBonus;
		[ObservableValue]
		private int _videoFeatureBonusPercent;
		[ObservableValue]
		private int _productionFromVideoFeature;
		protected OwnVillage currentVillage;
		protected GraphQLFetchableList<OccupiedOasis> oases;
		protected OwnHero ownHero;
		protected OwnPlayer ownPlayer;
		protected List<int> productionBonuses;
	
		// Properties
		[ObservableValue]
		public ResourceTypes type { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> productionBuildings { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> bonusBuildings { get => default; set {} }
		[ObservableValue]
		public ObservableList<OccupiedOasis> bonusOases { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature goldFeature { get => default; set {} }
		[ObservableValue]
		public int productionFromBuildings { get => default; set {} }
		[ObservableValue]
		public int productionBonusPercent { get => default; set {} }
		[ObservableValue]
		public int productionBonus { get => default; set {} }
		[ObservableValue]
		public int productionFromHero { get => default; set {} }
		[ObservableValue]
		public int productionFromGoldFeature { get => default; set {} }
		[ObservableValue]
		public int productionInterimBalance { get => default; set {} }
		[ObservableValue]
		public int productionTotal { get => default; set {} }
		[ObservableValue]
		public int productionWithBonus { get => default; set {} }
		[ObservableValue]
		public int goldFeatureCost { get => default; set {} }
		[ObservableValue]
		public string tabTitleLocalizationKey { get => default; set {} }
		[ObservableValue]
		public bool hasActiveVideoFeatureBonus { get => default; set {} }
		[ObservableValue]
		public int videoFeatureBonusPercent { get => default; set {} }
		[ObservableValue]
		public int productionFromVideoFeature { get => default; set {} }
	
		// Constructors
		public ResourceOverviewTabController() {}
		static ResourceOverviewTabController() {}
	
		// Methods
		private void _productionBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bonusBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bonusOasesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		protected virtual void CalculateAllValues() {}
		private void FillBuildings() {}
		private void FillOases() {}
		[UICallable]
		public void ActivateFeature() {}
		private void ShowUpgradeConfirmationPopup() {}
		private void ProcessActivation() {}
		[UICallable]
		public void ToggleAutoExtension() {}
	}
