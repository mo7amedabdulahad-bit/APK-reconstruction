// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteFilterPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _showMerchantRow;
		[ObservableValue]
		private bool _showResourceRow;
		public System.Action OnClose;
	
		// Properties
		[ObservableValue]
		public bool showMerchantRow { get => default; set {} }
		[ObservableValue]
		public bool showResourceRow { get => default; set {} }
	
		// Constructors
		public TradeRouteFilterPopupController() {}
	
		// Methods
		protected override void OnDisable() {}
		[UICallable]
		public void ToggleMerchants() {}
		[UICallable]
		public void ToggleResources() {}
	}
