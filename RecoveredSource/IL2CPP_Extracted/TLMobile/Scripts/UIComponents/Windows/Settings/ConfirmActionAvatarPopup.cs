// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmActionAvatarPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _confirmationCorrect;
		[ObservableValue]
		private string _requiredWordToType;
		[InjectableValue]
		[ObservableValue]
		private string _playerInput;
		[ObservableValue]
		private bool _playerInputError;
		[ObservableValue]
		private string _keySuffix;
		[ObservableValue]
		private ButtonColor _buttonColor;
		private System.Action confirmActionCallback;
	
		// Properties
		[ObservableValue]
		public bool confirmationCorrect { get => default; set {} }
		[ObservableValue]
		public string requiredWordToType { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public string playerInput { get => default; set {} }
		[ObservableValue]
		public bool playerInputError { get => default; set {} }
		[ObservableValue]
		public string keySuffix { get => default; set {} }
		[ObservableValue]
		public ButtonColor buttonColor { get => default; set {} }
		private string RequestedWordKey { get => default; }
	
		// Constructors
		public ConfirmActionAvatarPopup() {}
	
		// Methods
		protected override void OnEnable() {}
		public void OnInjectedValueChanged() {}
		public void Setup(System.Action confirmActionCallback, string keySuffix, ButtonColor buttonColor) {}
		private void CheckConfirmationInputMatches() {}
		[UICallable]
		public void ConfirmAvatarAction() {}
	}
