// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmRearrangeBuildingsPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GoldActionPrices _priceList;
		[ObservableValue]
		private ObservableList<BuildingInfo> _rearrangedBuildings;
		private System.Action confirmRearrangeCallback;
	
		// Properties
		[ObservableValue]
		public GoldActionPrices priceList { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> rearrangedBuildings { get => default; set {} }
	
		// Constructors
		public ConfirmRearrangeBuildingsPopupController() {}
	
		// Methods
		private void _rearrangedBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(ObservableList<BuildingInfo> rearrangedBuildings, System.Action confirmCallback) {}
		[UICallable]
		public void ConfirmRearrangeBuildings() {}
	}
