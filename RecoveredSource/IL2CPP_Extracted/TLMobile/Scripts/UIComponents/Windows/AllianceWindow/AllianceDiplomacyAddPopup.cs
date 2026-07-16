// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceDiplomacyAddPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Alliance _selectedAlliance;
		[ObservableValue]
		private string _error;
		[ObservableValue]
		private OwnAllianceDiplomacyRelation.Type _selectedType;
		[ObservableValue]
		private bool _everythingValid;
		[ObservableValue]
		private OwnAlliance _alliance;
	
		// Properties
		[ObservableValue]
		public Alliance selectedAlliance { get => default; set {} }
		[ObservableValue]
		public string error { get => default; set {} }
		[ObservableValue]
		public OwnAllianceDiplomacyRelation.Type selectedType { get => default; set {} }
		[ObservableValue]
		public bool everythingValid { get => default; set {} }
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
	
		// Constructors
		public AllianceDiplomacyAddPopup() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup() {}
		public void CheckValid() {}
		[UICallable]
		public void OpenAllianceSearch() {}
		[UICallable]
		public void SelectType(OwnAllianceDiplomacyRelation.Type type) {}
		[UICallable]
		public void Confirm() {}
	}
