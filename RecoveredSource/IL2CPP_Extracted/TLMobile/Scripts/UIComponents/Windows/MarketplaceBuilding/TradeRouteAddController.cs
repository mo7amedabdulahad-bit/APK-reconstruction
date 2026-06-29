// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteAddController : SendResourcesController
	{
		// Fields
		public TradeRouteTargetSelection targetSelection;
		[ObservableValue]
		private TradeRouteInfoModel _tradeRouteInfo;
	
		// Properties
		[ObservableValue]
		public TradeRouteInfoModel tradeRouteInfo { get => default; set {} }
		protected override bool useTotalProductionInsteadOfStock { get => default; }
	
		// Constructors
		public TradeRouteAddController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Init() {}
		private void SanitizeInputTime() {}
		protected override void UpdateResourceSelectionValid() {}
		protected override int GetSelectedResourceMax(int key) => default;
		[UICallable]
		public void SelectTradeRouteTarget(Village targetVillage) {}
		private void UpdateTime() {}
		[UICallable]
		public void ConfirmCreate() {}
	}
