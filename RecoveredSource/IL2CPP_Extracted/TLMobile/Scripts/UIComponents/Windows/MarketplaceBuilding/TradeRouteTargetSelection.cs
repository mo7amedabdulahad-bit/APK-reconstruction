// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteTargetSelection : GenericTargetSelection
	{
		// Fields
		[ObservableValue]
		private TradeRouteInfoModel _tradeRouteInfo;
		[ObservableValue]
		private int _maxHour;
	
		// Properties
		[ObservableValue]
		public TradeRouteInfoModel tradeRouteInfo { get => default; set {} }
		[ObservableValue]
		public int maxHour { get => default; set {} }
	
		// Constructors
		public TradeRouteTargetSelection() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void DoAfterChangeChecks() {}
		private async UniTaskVoid CheckArtifactsAndFinish() => default;
		private void FinishAfterChangeChecks() {}
		[UICallable]
		public void SetIntervalString(string interval) {}
		[UICallable]
		public void SetTimeType(int isStart) {}
		[UICallable]
		public void ToggleAmPm() {}
	}
