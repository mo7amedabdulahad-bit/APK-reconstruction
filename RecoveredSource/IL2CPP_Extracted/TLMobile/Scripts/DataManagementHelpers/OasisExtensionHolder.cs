// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OasisExtensionHolder : ObservableModel
	{
		// Fields
		[ObservableValue]
		private OasisInterface _oasisInterface;
		[ObservableValue]
		private ObservableList<float> _calculatedValues;
		[ObservableValue]
		private ObservableList<float> _totalValues;
	
		// Properties
		[ObservableValue]
		public OasisInterface oasisInterface { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> calculatedValues { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> totalValues { get => default; set {} }
	
		// Constructors
		public OasisExtensionHolder() {}
		public OasisExtensionHolder(OasisInterface oasis, float effectValue) {}
	
		// Methods
		public static float CalculateBonusValue(float resAmount, float effectValue) => default;
		private void _calculatedValuesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _totalValuesNotify(object sender, PropertyChangedEventArgs args) {}
	}
