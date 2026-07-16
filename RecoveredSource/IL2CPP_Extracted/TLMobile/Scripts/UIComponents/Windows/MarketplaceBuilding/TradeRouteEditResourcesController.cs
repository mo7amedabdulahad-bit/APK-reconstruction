// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteEditResourcesController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ResourceAmounts _previousResourceAmounts;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private ResourceAmounts _totalResources;
		[ObservableValue]
		private int _requiredMerchants;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private bool _resourceSelectionValid;
		[ObservableValue]
		private ObservableList<bool> _amountsSame;
		[ObservableValue]
		private bool _allResourceAmountsSame;
		[ObservableValue]
		private bool _durationSame;
		[ObservableValue]
		private bool _useShipsSame;
		[ObservableValue]
		private bool _tradeInfoSame;
		[ObservableValue]
		private bool _haveHarbour;
		[ObservableValue]
		private Marketplace _market;
		[ObservableValue]
		private bool _useShips;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private List<TradeRoute> _routes;
		[ObservableValue]
		private int _desiredRepeats;
		private System.Action afterConfirmCallback;
		private OwnVillage ownVillage;
		private Village targetVillage;
		private int originalDesiredRepeats;
	
		// Properties
		[ObservableValue]
		public ResourceAmounts previousResourceAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts totalResources { get => default; set {} }
		[ObservableValue]
		public int requiredMerchants { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public bool resourceSelectionValid { get => default; set {} }
		[ObservableValue]
		public ObservableList<bool> amountsSame { get => default; set {} }
		[ObservableValue]
		public bool allResourceAmountsSame { get => default; set {} }
		[ObservableValue]
		public bool durationSame { get => default; set {} }
		[ObservableValue]
		public bool useShipsSame { get => default; set {} }
		[ObservableValue]
		public bool tradeInfoSame { get => default; set {} }
		[ObservableValue]
		public bool haveHarbour { get => default; set {} }
		[ObservableValue]
		public Marketplace market { get => default; set {} }
		[ObservableValue]
		public bool useShips { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public List<TradeRoute> routes { get => default; set {} }
		[ObservableValue]
		public int desiredRepeats { get => default; set {} }
	
		// Constructors
		public TradeRouteEditResourcesController() {}
	
		// Methods
		private void _amountsSameNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(ResourceAmounts originalResources, int repeats, System.Action callback, Marketplace marketplace = null, List<TradeRoute> routes = null, OwnVillage ownVillage = null, Village targetVillage = null) {}
		private void InitializeResourceAmounts() {}
		private void ResetResourceAmountsForDifferentRoutes() {}
		private void UpdateResources() {}
		private void UpdateSimilarities() {}
		[UICallable]
		public void ToggleShips() {}
		private void UpdateShips() {}
		private void UpdateMerchantInfo() {}
		private void UpdateDuration() {}
		[UICallable]
		public void AddOneCapacityToResource(int resourceType) {}
		[UICallable]
		public void ConfirmResources() {}
		[UICallable]
		public void SetRepeatAmount(int newAmount) {}
	}
