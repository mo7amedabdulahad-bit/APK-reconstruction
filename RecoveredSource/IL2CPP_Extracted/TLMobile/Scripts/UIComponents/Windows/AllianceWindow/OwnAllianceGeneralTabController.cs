// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceGeneralTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private SubTab _currentTab;
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private bool _harbours;
	
		// Properties
		[ObservableValue]
		public SubTab currentTab { get => default; set {} }
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public bool harbours { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			General = 0,
			Top10 = 1
		}
	
		// Constructors
		public OwnAllianceGeneralTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		[UICallable]
		public void SetSubTab(SubTab subTab) {}
	}
