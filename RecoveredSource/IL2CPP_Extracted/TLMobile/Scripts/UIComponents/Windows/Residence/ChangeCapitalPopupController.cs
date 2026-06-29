// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Residence
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ChangeCapitalPopupController : DetailWindowController
	{
		// Fields
		public AdvancedInputField passwordInput;
		[ObservableValue]
		private bool _hasError;
		[ObservableValue]
		private bool _confirmButtonDisabled;
		public Action<CapitalChangeRequestState> OnRequest;
	
		// Properties
		[ObservableValue]
		public bool hasError { get => default; set {} }
		[ObservableValue]
		public bool confirmButtonDisabled { get => default; set {} }
	
		// Constructors
		public ChangeCapitalPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void InputChanged(string input) {}
		[UICallable]
		public void ChangeCapitalButtonClicked() {}
		public void ChangeCapital() {}
	}
