// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DetailWindowTabControllerWithSubTab : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private GenericSubTab _currentSubTab;
	
		// Properties
		[ObservableValue]
		public GenericSubTab currentSubTab { get => default; set {} }
	
		// Constructors
		public DetailWindowTabControllerWithSubTab() {}
	
		// Methods
		[UICallable]
		public virtual void SetSubTab(GenericSubTab subTab) {}
		public override void OnOpen(int tabNumber) {}
	}
