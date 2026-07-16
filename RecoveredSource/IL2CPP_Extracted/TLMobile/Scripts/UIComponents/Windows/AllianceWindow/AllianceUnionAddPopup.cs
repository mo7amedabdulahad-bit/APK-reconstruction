// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceUnionAddPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Alliance _selectedAlliance;
		[ObservableValue]
		private OwnAlliance _alliance;
	
		// Properties
		[ObservableValue]
		public Alliance selectedAlliance { get => default; set {} }
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
	
		// Constructors
		public AllianceUnionAddPopup() {}
	
		// Methods
		public void Setup(Alliance otherAlliance) {}
		[UICallable]
		public void Confirm() {}
	}
