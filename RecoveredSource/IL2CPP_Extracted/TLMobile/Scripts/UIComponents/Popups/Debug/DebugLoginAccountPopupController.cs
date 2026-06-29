// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Debug
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebugLoginAccountPopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private AdvancedInputField displayNameInputField;
		[SerializeField]
		private AdvancedInputField usernameInputField;
		[SerializeField]
		private AdvancedInputField passwordInputField;
		private Action<string, string, string> callback;
	
		// Constructors
		public DebugLoginAccountPopupController() {}
	
		// Methods
		public void Setup(Action<string, string, string> callback) {}
		[UICallable]
		public void CreateAccount() {}
	}
