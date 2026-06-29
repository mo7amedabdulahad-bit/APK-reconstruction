// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldShopAdvantagesController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<GoldAdvantage> _advantages;
		[ObservableValue]
		private ObservableDictionary<PlusFeature, string> _plusFeatures;
		[ObservableValue]
		private PlusFeature _selectedFeature;
		[ObservableValue]
		private string _selectedFeatureString;
		[ObservableValue]
		private int _selectedFeatureIndex;
		[ObservableValue]
		private GoldAdvantage _plusAdvantage;
		[ObservableValue]
		private int _goldClubPrice;
		[ObservableValue]
		private GoldActionPrices _prices;
		[ObservableValue]
		private int _resourceBonusValuePremium;
		[ObservableValue]
		private int _resourceBonusValueVideoFeature;
		[ObservableValue]
		private GoldAdvantage _selectedShownAdvantage;
		[ObservableValue]
		private int _nextResourceBonusResetTimestamp;
		private BootstrapData bootstrap;
		private OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		public ObservableList<GoldAdvantage> advantages { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<PlusFeature, string> plusFeatures { get => default; set {} }
		[ObservableValue]
		public PlusFeature selectedFeature { get => default; set {} }
		[ObservableValue]
		public string selectedFeatureString { get => default; set {} }
		[ObservableValue]
		public int selectedFeatureIndex { get => default; set {} }
		[ObservableValue]
		public GoldAdvantage plusAdvantage { get => default; set {} }
		[ObservableValue]
		public int goldClubPrice { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices prices { get => default; set {} }
		[ObservableValue]
		public int resourceBonusValuePremium { get => default; set {} }
		[ObservableValue]
		public int resourceBonusValueVideoFeature { get => default; set {} }
		[ObservableValue]
		public GoldAdvantage selectedShownAdvantage { get => default; set {} }
		[ObservableValue]
		public int nextResourceBonusResetTimestamp { get => default; set {} }
	
		// Nested types
		public enum PlusFeature
		{
			None = 0,
			AttackWarning = 1,
			BuildingQueue = 2,
			LinkList = 3,
			VillageStatistics = 4,
			FullScreen = 5,
			DirectLinks = 6,
			TradeTwoTimes = 7
		}
	
		// Constructors
		public GoldShopAdvantagesController() {}
	
		// Methods
		private void _advantagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _plusFeaturesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void OnBootstrapUpdate() {}
		public void Init() {}
		private void RefreshGoldAdvantages() {}
		public void Setup(PlusFeature selectedFeature = PlusFeature.None, GoldAdvantage selectedAdvantage = null) {}
		[UICallable]
		public void ToggleAutoExtension(GoldAdvantage item) {}
		[UICallable]
		public void ShowInfoPopup(GoldAdvantage item) {}
		[UICallable]
		public void Activate(BookFeatureRequestBody.FeatureEnum feature) {}
		[UICallable]
		public void ActivateFromPopup(BookFeatureRequestBody.FeatureEnum feature) {}
		[UICallable]
		public void ActivateFeatureWithVideo(BoostResourceType feature) {}
		private bool ShowUpgradePopupConfirmation(BookFeatureRequestBody.FeatureEnum feature) => default;
		private void ActivateFeature(BookFeatureRequestBody.FeatureEnum feature, bool shouldCloseWindow = false) {}
		private void BookFeature(BookFeatureRequestBody.FeatureEnum feature, bool shouldCloseWindow) {}
		[UICallable]
		public void ActivateWaveBuilder() {}
	}
