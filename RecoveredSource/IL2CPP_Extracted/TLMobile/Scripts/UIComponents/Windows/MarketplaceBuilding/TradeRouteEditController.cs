// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteEditController : DetailWindowController
	{
		// Fields
		public TradeRouteTargetSelection targetSelection;
		[ObservableValue]
		private List<TradeRoute> _tradeRoutes;
		[ObservableValue]
		private bool _desiredPausedState;
		[ObservableValue]
		private ObservableList<bool> _amountsSame;
		[ObservableValue]
		private bool _allResourceAmountsSame;
		[ObservableValue]
		private bool _startTimeSame;
		[ObservableValue]
		private bool _durationSame;
		[ObservableValue]
		private bool _useShipsSame;
		[ObservableValue]
		private bool _tradeInfoSame;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private int _desiredRepeats;
		[ObservableValue]
		private int _requiredMerchants;
		[ObservableValue]
		private int _totalMerchants;
		[ObservableValue]
		private int _capacityTotal;
		[ObservableValue]
		private TradeRouteInfoModel _tradeRouteInfo;
		[ObservableValue]
		private bool _resourceSelectionValid;
		[ObservableValue]
		private Marketplace _market;
		[ObservableValue]
		private int _duration;
		private System.Action deleteCallback;
		private Destination destination;
		protected MerchantsInfo merchantsInfo;
	
		// Properties
		[ObservableValue]
		public List<TradeRoute> tradeRoutes { get => default; set {} }
		[ObservableValue]
		public bool desiredPausedState { get => default; set {} }
		[ObservableValue]
		public ObservableList<bool> amountsSame { get => default; set {} }
		[ObservableValue]
		public bool allResourceAmountsSame { get => default; set {} }
		[ObservableValue]
		public bool startTimeSame { get => default; set {} }
		[ObservableValue]
		public bool durationSame { get => default; set {} }
		[ObservableValue]
		public bool useShipsSame { get => default; set {} }
		[ObservableValue]
		public bool tradeInfoSame { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public int desiredRepeats { get => default; set {} }
		[ObservableValue]
		public int requiredMerchants { get => default; set {} }
		[ObservableValue]
		public int totalMerchants { get => default; set {} }
		[ObservableValue]
		public int capacityTotal { get => default; set {} }
		[ObservableValue]
		public TradeRouteInfoModel tradeRouteInfo { get => default; set {} }
		[ObservableValue]
		public bool resourceSelectionValid { get => default; set {} }
		[ObservableValue]
		public Marketplace market { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
	
		// Constructors
		public TradeRouteEditController() {}
	
		// Methods
		private void _amountsSameNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(List<TradeRoute> routes, Destination destination, System.Action deleteCallback) {}
		private void ResetProperties() {}
		private ValueTuple<int, int, bool, bool> GetLocalTime(int unixTimestamp) => default;
		private void ConfigureTradeRoutes() {}
		private void ConfigureMarketplaceAndMerchants() {}
		private void SetupTargetSelection() {}
		private void UpdateSimilarities() {}
		private void UpdateDuration(bool useShips) {}
		private void UpdateMerchantInfo() {}
		[UICallable]
		public void SetRepeatAmount(int newAmount) {}
		[UICallable]
		public void OpenResourcesPopup() {}
		private void UpdateResourceAmounts(TradeRouteEditResourcesController controller) {}
		[UICallable]
		public void OpenDeletePopup() {}
		[UICallable]
		public void ConfirmUpdate() {}
		private TradeRoutesBulkUpdateRequestBodyRoutes CreateUpdateRequest(TradeRoute route) => default;
		private void ApplyAmountsSame(TradeRoutesBulkUpdateRequestBodyRoutes editEntry) {}
		[UICallable]
		public void SetTimeIsStartTime(int isStart) {}
		[UICallable]
		public void ToggleDesiredPause() {}
	}
