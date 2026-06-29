// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.EmbassyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LeaveAlliancePopup : DetailWindowController
	{
		// Fields
		private const string TranslationKeyLeavePassword = "allianz.leave";
		private const string TranslationKeyInputError = "allgemein.pleaseTypeTextAbove";
		[ObservableValue]
		private bool _apiError;
		[ObservableValue]
		private string _password;
		[ObservableValue]
		private string _errorLocaleKey;
		[ObservableValue]
		private bool _confirmButtonDisabled;
	
		// Properties
		[ObservableValue]
		public bool apiError { get => default; set {} }
		[ObservableValue]
		public string password { get => default; set {} }
		[ObservableValue]
		public string errorLocaleKey { get => default; set {} }
		[ObservableValue]
		public bool confirmButtonDisabled { get => default; set {} }
	
		// Constructors
		public LeaveAlliancePopup() {}
	
		// Methods
		protected override void OnEnable() {}
		private void InputChanged() {}
		[UICallable]
		public void LeaveAlliance(string password) {}
	}
