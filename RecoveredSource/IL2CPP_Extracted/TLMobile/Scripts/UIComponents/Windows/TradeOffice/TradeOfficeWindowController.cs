// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TradeOffice
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeOfficeWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<int> _merchantCarryCapacity;
		[ObservableValue]
		private ObservableList<int> _tradeShipCarryCapacity;
	
		// Properties
		[ObservableValue]
		public ObservableList<int> merchantCarryCapacity { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> tradeShipCarryCapacity { get => default; set {} }
	
		// Constructors
		public TradeOfficeWindowController() {}
	
		// Methods
		private void _merchantCarryCapacityNotify(object sender, PropertyChangedEventArgs args) {}
		private void _tradeShipCarryCapacityNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void UpdateBuildingData(OwnVillage village) {}
	}
