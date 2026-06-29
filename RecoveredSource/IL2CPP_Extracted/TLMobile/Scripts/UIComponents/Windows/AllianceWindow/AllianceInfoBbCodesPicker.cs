// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceInfoBbCodesPicker : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<AllianceBbCode> _bbCodes;
		private Action<string> onCodeSelected;
	
		// Properties
		[ObservableValue]
		public ObservableList<AllianceBbCode> bbCodes { get => default; set {} }
	
		// Nested types
		public class AllianceBbCode : ObservableModel
		{
			// Fields
			[ObservableValue]
			private string _name;
			[ObservableValue]
			private string _extraInfo;
	
			// Properties
			[ObservableValue]
			public string name { get => default; set {} }
			[ObservableValue]
			public string extraInfo { get => default; set {} }
			public IBBCodeInsertable Code { get; }
	
			// Constructors
			public AllianceBbCode(IBBCodeInsertable code) {}
			public AllianceBbCode() {}
		}
	
		// Constructors
		public AllianceInfoBbCodesPicker() {}
	
		// Methods
		private void _bbCodesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(Action<string> callback) {}
		[UICallable]
		public void CodeClicked(AllianceBbCode code) {}
	}
