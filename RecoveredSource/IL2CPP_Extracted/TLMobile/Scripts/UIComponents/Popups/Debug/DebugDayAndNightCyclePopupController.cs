// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Debug
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebugDayAndNightCyclePopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _debugDayAndNight;
	
		// Properties
		[ObservableValue]
		public bool debugDayAndNight { get => default; set {} }
	
		// Constructors
		public DebugDayAndNightCyclePopupController() {}
	
		// Methods
		[UICallable]
		public void ToggleDebugDayAndNight() {}
		[UICallable]
		public void ForceDay() {}
		[UICallable]
		public void ForceNight() {}
	}
