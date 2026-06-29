// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketTradeRoutesController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private Marketplace _marketplace;
		[ObservableValue]
		private TradeRoute _nextRoute;
		[ObservableValue]
		private SubTab _currentSubTab;
		[ObservableValue]
		private TradeRoutesSet _selectedRoutesSet;
		[ObservableValue]
		private ObservableList<TradeRoute> _activeRoutes;
		[ObservableValue]
		private ObservableList<TradeRoute> _pausedRoutes;
		[ObservableValue]
		private ObservableList<TradeRoute> _visibleRoutes;
		[ObservableValue]
		private int _selectedAmount;
		[ObservableValue]
		private bool _lookingAtActiveRoutes;
		[ObservableValue]
		private bool _showMerchantRow;
		[ObservableValue]
		private bool _showResourceRow;
		[ObservableValue]
		private int _activeFiltersCount;
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private bool _harbours;
		[ObservableValue]
		private int _idleMerchants;
		[ObservableValue]
		private int _tradeShipCarryCapacity;
		[ObservableValue]
		private string _villageTribeId;
		private bool isDirty;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public Marketplace marketplace { get => default; set {} }
		[ObservableValue]
		public TradeRoute nextRoute { get => default; set {} }
		[ObservableValue]
		public SubTab currentSubTab { get => default; set {} }
		[ObservableValue]
		public TradeRoutesSet selectedRoutesSet { get => default; set {} }
		[ObservableValue]
		public ObservableList<TradeRoute> activeRoutes { get => default; set {} }
		[ObservableValue]
		public ObservableList<TradeRoute> pausedRoutes { get => default; set {} }
		[ObservableValue]
		public ObservableList<TradeRoute> visibleRoutes { get => default; set {} }
		[ObservableValue]
		public int selectedAmount { get => default; set {} }
		[ObservableValue]
		public bool lookingAtActiveRoutes { get => default; set {} }
		[ObservableValue]
		public bool showMerchantRow { get => default; set {} }
		[ObservableValue]
		public bool showResourceRow { get => default; set {} }
		[ObservableValue]
		public int activeFiltersCount { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public bool harbours { get => default; set {} }
		[ObservableValue]
		public int idleMerchants { get => default; set {} }
		[ObservableValue]
		public int tradeShipCarryCapacity { get => default; set {} }
		[ObservableValue]
		public string villageTribeId { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			Overview = 0,
			ActiveRoutes = 1,
			PausedRoutes = 2
		}
	
		// Constructors
		public MarketTradeRoutesController() {}
	
		// Methods
		private void _activeRoutesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _pausedRoutesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _visibleRoutesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void CurrentVillageChanged(OwnVillage newVill) {}
		private void UpdateTradeRoutes() {}
		private void UpdateHarbour() {}
		[UICallable]
		public void OpenFilterPopup() {}
		[UICallable]
		public void SetSubTab(SubTab tab) {}
		[UICallable]
		public void SelectRouteSet(TradeRoutesSet set) {}
		[UICallable]
		public void BackToOverview() {}
		[UICallable]
		public void ToggleRouteSelection(TradeRoute route) {}
		[UICallable]
		public void ToggleAllRouteSelection() {}
		[UICallable]
		public void TogglePauseOnSelected() {}
		[UICallable]
		public void DeleteSelected() {}
		[UICallable]
		public void ActuallyDeleteSelected() {}
		[UICallable]
		public void EditSelectedRoutes() {}
		private void CheckAllSelected() {}
		[Testable]
		private void UpdateFilersCount() {}
	}
