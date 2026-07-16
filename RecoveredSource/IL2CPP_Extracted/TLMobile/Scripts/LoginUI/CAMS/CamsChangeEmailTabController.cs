// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsChangeEmailTabController : CamsDetailWindowTabController
	{
		// Fields
		private const int ResendEmailCooldown = 60;
		[ObservableValue]
		private Step _currentStep;
		[ObservableValue]
		private string _currentTitle;
		[ObservableValue]
		private string _mailSentTo;
		[ObservableValue]
		private string _enteredText;
		[ObservableValue]
		private int _enteredDigits;
		[ObservableValue]
		private bool _validInput;
		[ObservableValue]
		private int _redirectionTime;
		[ObservableValue]
		private bool _isAccountSocialLogin;
		[ObservableValue]
		private bool _codeHasInputError;
		[ObservableValue]
		private string _codeInputErrorKey;
		[ObservableValue]
		private int _emailConfirmationResendCountdown;
		[ObservableValue]
		private int _newEmailConfirmationResendCountdown;
		[SerializeField]
		private AdvancedInputField activationCodeInputField;
		[SerializeField]
		private AdvancedInputField newEmailActivationCodeInputField;
		private float? emailConfirmationSentTime;
		private float? newEmailConfirmationSentTime;
		private string currentChangeCode;
	
		// Properties
		[ObservableValue]
		public Step currentStep { get => default; set {} }
		[ObservableValue]
		public string currentTitle { get => default; set {} }
		[ObservableValue]
		public string mailSentTo { get => default; set {} }
		[ObservableValue]
		public string enteredText { get => default; set {} }
		[ObservableValue]
		public int enteredDigits { get => default; set {} }
		[ObservableValue]
		public bool validInput { get => default; set {} }
		[ObservableValue]
		public int redirectionTime { get => default; set {} }
		[ObservableValue]
		public bool isAccountSocialLogin { get => default; set {} }
		[ObservableValue]
		public bool codeHasInputError { get => default; set {} }
		[ObservableValue]
		public string codeInputErrorKey { get => default; set {} }
		[ObservableValue]
		public int emailConfirmationResendCountdown { get => default; set {} }
		[ObservableValue]
		public int newEmailConfirmationResendCountdown { get => default; set {} }
	
		// Nested types
		public enum Step
		{
			Description = 0,
			ConfirmCurrent = 1,
			EnterNew = 2,
			ConfirmNew = 3,
			AllDone = 4
		}
	
		// Constructors
		public CamsChangeEmailTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void Logout() {}
		protected override void OnDisable() {}
		private bool HasCodeInputErrors() => default;
		private void OnTextChanged() {}
		[UICallable]
		public void OpenHelp() {}
		[UICallable]
		public void ContinueToConfirmCurrent() {}
		[UICallable]
		public void VerifyCurrentMail() {}
		[UICallable]
		public void EnteredNewMail() {}
		[UICallable]
		public void ConfirmNewMail() {}
		[UICallable]
		public void ResendNewMail() {}
	}
