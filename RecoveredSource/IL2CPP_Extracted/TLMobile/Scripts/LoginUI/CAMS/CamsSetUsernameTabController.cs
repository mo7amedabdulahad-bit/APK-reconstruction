// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsSetUsernameTabController : CamsDetailWindowTabController
	{
		// Fields
		private const string EmptyApiError = "try_again";
		private const string ErrorTranslationKey = "changeAccountNameWaiting";
		private const int UserNameMinLength = 3;
		private const int UserNameMaxLength = 15;
		private const int TagMinLength = 2;
		private const int TagMaxLength = 5;
		private const int UpdateInterval = 30;
		public AdvancedInputField usernameInputField;
		public AdvancedInputField tagInputField;
		[ObservableValue]
		private AccountNameCondition _accountNameCondition;
		[ObservableValue]
		private AccountTagCondition _accountTagCondition;
		[ObservableValue]
		private SingleInputController _tagInputController;
		[ObservableValue]
		private SingleInputController _usernameInputController;
		[ObservableValue]
		private bool _displayMissingUsernameOrTagError;
		[ObservableValue]
		private string _accountName;
		[ObservableValue]
		private int? _timestampError;
		[ObservableValue]
		private bool _timestampIsLessThanADay;
		[ObservableValue]
		private bool _isFreeNameChange;
	
		// Properties
		[ObservableValue]
		public AccountNameCondition accountNameCondition { get => default; set {} }
		[ObservableValue]
		public AccountTagCondition accountTagCondition { get => default; set {} }
		[ObservableValue]
		public SingleInputController tagInputController { get => default; set {} }
		[ObservableValue]
		public SingleInputController usernameInputController { get => default; set {} }
		[ObservableValue]
		public bool displayMissingUsernameOrTagError { get => default; set {} }
		[ObservableValue]
		public string accountName { get => default; set {} }
		[ObservableValue]
		public int? timestampError { get => default; set {} }
		[ObservableValue]
		public bool timestampIsLessThanADay { get => default; set {} }
		[ObservableValue]
		public bool isFreeNameChange { get => default; set {} }
	
		// Constructors
		public CamsSetUsernameTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void DoUpdateLoop() {}
		protected override void OnDestroy() {}
		protected void OnApplicationQuit() {}
		private void EmptyApiCheck() {}
		public override void OnOpen(int tabNumber) {}
		private void PrefillAccountName() {}
		private void UpdateLoginState() {}
		[UICallable]
		public void UpdateUsernameInput() {}
		[UICallable]
		public void UpdateTagInput() {}
		[UICallable]
		public bool HasUsernameInputError() => default;
		[UICallable]
		public bool HasTagInputError() => default;
		[UICallable]
		public bool HasInputError() => default;
		private void UpdateAccountName(string name = null, string tag = null) {}
		[UICallable]
		public void CreateAccount() {}
		[UICallable]
		public void ChangeAccountName() {}
		private void ChangeUserName(bool isNewAccount) {}
		private void OnInputValueChanged(string input) {}
		[UICallable]
		private void OnResetUsernameErrors() {}
		[UICallable]
		private void OnResetTagErrors() {}
		[UICallable]
		public void RandomizeTag() {}
	}
