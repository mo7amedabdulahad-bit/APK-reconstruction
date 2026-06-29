// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdventureWithDuration : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Adventure _adventure;
		[ObservableValue]
		private int _durationFromSelectedVillage;
		[ObservableValue]
		private int? _reducedDurationFromSelectedVillage;
		[ObservableValue]
		private int _durationDiff;
		[ObservableValue]
		private float _distance;
	
		// Properties
		[ObservableValue]
		public Adventure adventure { get => default; set {} }
		[ObservableValue]
		public int durationFromSelectedVillage { get => default; set {} }
		[ObservableValue]
		public int? reducedDurationFromSelectedVillage { get => default; set {} }
		[ObservableValue]
		public int durationDiff { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
	
		// Constructors
		public AdventureWithDuration() {}
	}
