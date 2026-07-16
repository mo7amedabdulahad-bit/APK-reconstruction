// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.SimulatorOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TravelSimulatorItemEffect : ObservableModel
	{
		// Fields
		[ObservableValue]
		private float? _magnitude;
		[ObservableValue]
		private string _effectTypeText;
	
		// Properties
		[ObservableValue]
		public float? magnitude { get => default; set {} }
		[ObservableValue]
		public string effectTypeText { get => default; set {} }
		public EffectType? EffectType { get; private set; }
		public float? Magnitude { get => default; }
		public float? MagnitudeNormal { get; private set; }
	
		// Constructors
		public TravelSimulatorItemEffect() {}
	
		// Methods
		public void SetEffectType(EffectType? value) {}
		public void SetMagnitude(float? value) {}
	}
