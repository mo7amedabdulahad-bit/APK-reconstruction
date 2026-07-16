// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmDemolishCompletelyPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GoldActionPrices _priceList;
		[ObservableValue]
		private BuildingInfo _rearrangedBuilding;
		private System.Action confirmDemolishCallback;
		private System.Action onCloseCallback;
	
		// Properties
		[ObservableValue]
		public GoldActionPrices priceList { get => default; set {} }
		[ObservableValue]
		public BuildingInfo rearrangedBuilding { get => default; set {} }
	
		// Constructors
		public ConfirmDemolishCompletelyPopupController() {}
	
		// Methods
		protected override void Awake() {}
		public void Setup(BuildingInfo rearrangedBuilding, System.Action confirmCallback, System.Action onCloseCallback) {}
		[UICallable]
		public void ConfirmDemolishCompletely() {}
		[UICallable]
		public override void Hide() {}
	}
