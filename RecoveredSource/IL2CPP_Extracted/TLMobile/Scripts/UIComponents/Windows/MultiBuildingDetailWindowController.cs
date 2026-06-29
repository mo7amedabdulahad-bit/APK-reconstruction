// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MultiBuildingDetailWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private float _totalEffectValue;
		[ObservableValue]
		private int _totalBuildingsBuilt;
		[ObservableValue]
		private ObservableList<float> _adjustedEffectValues;
	
		// Properties
		[ObservableValue]
		public float totalEffectValue { get => default; set {} }
		[ObservableValue]
		public int totalBuildingsBuilt { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> adjustedEffectValues { get => default; set {} }
	
		// Constructors
		public MultiBuildingDetailWindowController() {}
	
		// Methods
		private void _adjustedEffectValuesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void UpdateBuildingData(OwnVillage village) {}
	}
