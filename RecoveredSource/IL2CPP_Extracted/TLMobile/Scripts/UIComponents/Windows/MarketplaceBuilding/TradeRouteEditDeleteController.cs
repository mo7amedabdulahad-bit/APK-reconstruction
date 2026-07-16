// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteEditDeleteController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private List<TradeRoute> _tradeRoutes;
		[ObservableValue]
		private Destination _destination;
		private System.Action afterConfirmCallback;
	
		// Properties
		[ObservableValue]
		public List<TradeRoute> tradeRoutes { get => default; set {} }
		[ObservableValue]
		public Destination destination { get => default; set {} }
	
		// Constructors
		public TradeRouteEditDeleteController() {}
	
		// Methods
		public void Setup(List<TradeRoute> routes, Destination destination, System.Action callback) {}
		[UICallable]
		public void ConfirmDeletion() {}
	}
