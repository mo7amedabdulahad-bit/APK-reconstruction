// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Treasury
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TreasuryCategoryObject : ObservableModel
	{
		// Fields
		[ObservableValue]
		private bool _visible;
		[ObservableValue]
		private PlaceBonusInterface.Type _type;
		[ObservableValue]
		private ObservableList<PlaceBonusInterface> _placeBonuses;
	
		// Properties
		[ObservableValue]
		public bool visible { get => default; set {} }
		[ObservableValue]
		public PlaceBonusInterface.Type type { get => default; set {} }
		[ObservableValue]
		public ObservableList<PlaceBonusInterface> placeBonuses { get => default; set {} }
	
		// Constructors
		public TreasuryCategoryObject() {}
		public TreasuryCategoryObject(PlaceBonusInterface.Type type, ObservableList<PlaceBonusInterface> placeBonuses) {}
	
		// Methods
		private void _placeBonusesNotify(object sender, PropertyChangedEventArgs args) {}
		private void CheckVisibility() {}
	}
