// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InertiaConfigurator : ViewModel
	{
		// Fields
		[ObservableValue]
		private float _inertiaStrength;
		[ObservableValue]
		private float _maxSpeed;
		[ObservableValue]
		private bool _isVisible;
		[ObservableValue]
		private float _easingToMax;
		[ObservableValue]
		private float _easingToZero;
		private CameraMobileGesturesListener mobileListener;
	
		// Properties
		[ObservableValue]
		public float inertiaStrength { get => default; set {} }
		[ObservableValue]
		public float maxSpeed { get => default; set {} }
		[ObservableValue]
		public bool isVisible { get => default; set {} }
		[ObservableValue]
		public float easingToMax { get => default; set {} }
		[ObservableValue]
		public float easingToZero { get => default; set {} }
	
		// Constructors
		public InertiaConfigurator() {}
	
		// Methods
		protected override void Awake() {}
		private void EasingToZero() {}
		private void EasingToMax() {}
		private void MaxSpeedChanged() {}
		private void InertiaChanged() {}
		[UICallable]
		public void ToggleVisibility() {}
	}
