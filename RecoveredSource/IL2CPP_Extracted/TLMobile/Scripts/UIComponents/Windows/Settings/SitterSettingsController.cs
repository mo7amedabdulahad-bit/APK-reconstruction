// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SitterSettingsController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private Tab _tab;
	
		// Properties
		[ObservableValue]
		public Tab tab { get => default; set {} }
	
		// Nested types
		public enum Tab
		{
			YourSitters = 0,
			SittingFor = 1
		}
	
		// Constructors
		public SitterSettingsController() {}
	
		// Methods
		[UICallable]
		public void SetTab(Tab tab) {}
	}
