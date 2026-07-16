// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PasswordInput : ViewModel
	{
		// Fields
		public const string ShowPasswordPrefKey = "showPassword";
		public bool SaveToPlayerPrefs;
		[ObservableValue]
		private bool _showPassword;
		private AdvancedInputField inputField;
	
		// Properties
		[ObservableValue]
		public bool showPassword { get => default; set {} }
	
		// Constructors
		public PasswordInput() {}
	
		// Methods
		protected override void Awake() {}
		private void OnEnable() {}
		[UICallable]
		public void TogglePasswordVisibility() {}
		public void Init() {}
		private void SetShowPasswordFromPlayerPrefs() {}
		private void SetPasswordInputState() {}
	}
