// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceGeneralInfoEditPopup : GenericPopupWithInsertInEditButton
	{
		// Fields
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private string _currentInfo1;
		[ObservableValue]
		private string _currentInfo2;
	
		// Properties
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public string currentInfo1 { get => default; set {} }
		[ObservableValue]
		public string currentInfo2 { get => default; set {} }
	
		// Constructors
		public AllianceGeneralInfoEditPopup() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup() {}
		[UICallable]
		public void OpenBbCodes() {}
		[UICallable]
		public void SaveChanges() {}
	}
