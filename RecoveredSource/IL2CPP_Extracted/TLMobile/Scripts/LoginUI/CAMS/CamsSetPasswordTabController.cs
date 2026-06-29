// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsSetPasswordTabController : CamsDetailWindowTabController
	{
		// Fields
		private const int PasswordMinLength = 8;
		private const int PasswordMaxLength = 64;
		private const int PasswordGoodLength = 16;
		public AdvancedInputField passwordInputField;
		[ObservableValue]
		private PasswordCondition _passwordCondition;
		[ObservableValue]
		private SingleInputController _passwordInputController;
		[ObservableValue]
		private int _passwordStrengthPoints;
		[ObservableValue]
		private int _passwordUsesCharacterTypeCount;
	
		// Properties
		[ObservableValue]
		public PasswordCondition passwordCondition { get => default; set {} }
		[ObservableValue]
		public SingleInputController passwordInputController { get => default; set {} }
		[ObservableValue]
		public int passwordStrengthPoints { get => default; set {} }
		[ObservableValue]
		public int passwordUsesCharacterTypeCount { get => default; set {} }
	
		// Constructors
		public CamsSetPasswordTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDestroy() {}
		public override void OnOpen(int tabNumber) {}
		private void ResetInputField() {}
		[UICallable]
		public void UpdatePasswordInput() {}
		[UICallable]
		public bool HasInputError() => default;
		private void CheckPasswordStrength(int passwordLength) {}
		[UICallable]
		public void SetPassword() {}
		[UICallable]
		private void OnResetErrors() {}
	}
