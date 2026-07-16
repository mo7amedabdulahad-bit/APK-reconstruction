// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Debug
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebugButton : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private bool _hideDebugButton;
		[ObservableValue]
		private bool _wasDevelopBuild;
	
		// Properties
		[ObservableValue]
		public bool hideDebugButton { get => default; set {} }
		[ObservableValue]
		public bool wasDevelopBuild { get => default; set {} }
	
		// Constructors
		public DebugButton() {}
	
		// Methods
		protected override void Awake() {}
		[UICallable]
		public void OpenDebug(DebugFunction.AccessLevel level) {}
	}
