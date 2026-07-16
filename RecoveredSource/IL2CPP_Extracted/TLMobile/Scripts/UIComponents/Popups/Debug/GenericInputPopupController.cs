// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Debug
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericInputPopupController : DetailWindowController
	{
		// Fields
		private const string LastInputKey = "LastInput";
		[ObservableValue]
		private string _input;
		[ObservableValue]
		private string _title;
		[SerializeField]
		private AdvancedInputField inputField;
		private string lastInput;
		private Action<string> callback;
	
		// Properties
		[ObservableValue]
		public string input { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
	
		// Constructors
		public GenericInputPopupController() {}
	
		// Methods
		public void Setup(Action<string> callback, string title = "Input", string defaultInput = "") {}
		[UICallable]
		public void Paste() {}
		[UICallable]
		public void LoadLastInput() {}
		[UICallable]
		public void ConfirmSelection() {}
	}
