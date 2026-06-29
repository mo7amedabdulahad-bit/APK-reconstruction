// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PerformanceSettingsController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private bool _enableLowBandwidthMode;
	
		// Properties
		[ObservableValue]
		public bool enableLowBandwidthMode { get => default; set {} }
	
		// Constructors
		public PerformanceSettingsController() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public void ToggledLowBandwidthMode() {}
	}
