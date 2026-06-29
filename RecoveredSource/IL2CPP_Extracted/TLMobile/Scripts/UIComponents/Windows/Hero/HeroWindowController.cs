// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GenericSubTab _currentSubTab;
	
		// Properties
		[ObservableValue]
		public GenericSubTab currentSubTab { get => default; set {} }
	
		// Constructors
		public HeroWindowController() {}
	
		// Methods
		protected override void OpenDefaultTab() {}
		[UICallable]
		public void OpenTabWithSubTab(GenericSubTab subTab, int tab) {}
	}
