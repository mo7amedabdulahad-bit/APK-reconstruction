// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsWindowController : DetailWindowController
	{
		// Fields
		public const string LastLoginStateUsernamePlayerPrefsKey = "LastLoginStateUserName";
		public const string LastLoginStateEmailAlreadyExitsPlayerPrefsKey = "LastLoginStateEmailAlreadyExits";
		public const string LastLoginStateNewsletterAcceptedExitsPlayerPrefsKey = "LastLoginStateNewsletterAcceptedExits";
		public const string LastLoginStateCodePlayerPrefsKey = "LastLoginStateCode";
		public const string LastLoginStateActivationCodePlayerPrefsKey = "LastLoginStateActivationCode";
		public const string LastLoginStateChallengePlayerPrefsKey = "LastLoginStateChallenge";
		public const string LastLoginStateVerifierPlayerPrefsKey = "LastLoginStateVerifier";
		public const string LastLoginStateAccountNamePlayerPrefsKey = "LastLoginStateAccountName";
		public const string LastLoginStateSetNewPasswordPrefsKey = "LastLoginStateSetNewPassword";
		public const string LastLoginStateSetActivationCodePrefsKey = "LastLoginStateSetActivationCode";
		public const string LastLoginStateRecoveryCodePrefsKey = "LastLoginStateRecoveryCode";
		public const string LastLoginStateStartedRegistrationPrefsKey = "LastLoginStateStartedRegistration";
		public const string LastCamsWindowPlayerPrefsKey = "LastCamsWindow";
		public const string LastPasswordChangeTime = "LastPasswordChangeTime";
		public const string LastPasswordRecoverTime = "LastPasswordRecoverTime";
		public static readonly string LastLoginEmailPlayerPrefsKey;
		public static readonly string LastCompleteLoginPlayerPrefsKey;
		private static readonly List<int> showCamsInfoInTabs;
		[SerializeField]
		private ScrollRectCenterer scrollRectCenterer;
		[ObservableValue]
		private string _accountName;
		[ObservableValue]
		private string _activationCode;
		[ObservableValue]
		private string _challenge;
		[ObservableValue]
		private string _code;
		[ObservableValue]
		private bool _emailAlreadyExists;
		[ObservableValue]
		private bool _newsletterAccepted;
		[ObservableValue]
		private string _password;
		[ObservableValue]
		private bool _passwordUpdated;
		[ObservableValue]
		private string _recoveryCode;
		[ObservableValue]
		private bool _setActivationCode;
		[ObservableValue]
		private bool _setNewPassword;
		[ObservableValue]
		private bool _showMoreInformation;
		[ObservableValue]
		private bool _showMoreInformationOnThisTab;
		[ObservableValue]
		private string _username;
		[ObservableValue]
		private string _verifier;
		[ObservableValue]
		private float _topPadding;
		[SerializeField]
		private float topPaddingWithCharacters;
		[ObservableValue]
		private bool _enableSocialLogins;
		[ObservableValue]
		private bool _enableSocialLoginsApple;
		[ObservableValue]
		private bool _enableSocialLoginsGoogle;
		[ObservableValue]
		private bool _enableSocialLoginsFacebook;
		[SerializeField]
		private GameObject inProgressPanel;
		private CamsWindowTab requestedTab;
		private bool resumeFromDeeplink;
	
		// Properties
		[ObservableValue]
		public string accountName { get => default; set {} }
		[ObservableValue]
		public string activationCode { get => default; set {} }
		[ObservableValue]
		public string challenge { get => default; set {} }
		[ObservableValue]
		public string code { get => default; set {} }
		[ObservableValue]
		public bool emailAlreadyExists { get => default; set {} }
		[ObservableValue]
		public bool newsletterAccepted { get => default; set {} }
		[ObservableValue]
		public string password { get => default; set {} }
		[ObservableValue]
		public bool passwordUpdated { get => default; set {} }
		[ObservableValue]
		public string recoveryCode { get => default; set {} }
		[ObservableValue]
		public bool setActivationCode { get => default; set {} }
		[ObservableValue]
		public bool setNewPassword { get => default; set {} }
		[ObservableValue]
		public bool showMoreInformation { get => default; set {} }
		[ObservableValue]
		public bool showMoreInformationOnThisTab { get => default; set {} }
		[ObservableValue]
		public string username { get => default; set {} }
		[ObservableValue]
		public string verifier { get => default; set {} }
		[ObservableValue]
		public float topPadding { get => default; set {} }
		[ObservableValue]
		public bool enableSocialLogins { get => default; set {} }
		[ObservableValue]
		public bool enableSocialLoginsApple { get => default; set {} }
		[ObservableValue]
		public bool enableSocialLoginsGoogle { get => default; set {} }
		[ObservableValue]
		public bool enableSocialLoginsFacebook { get => default; set {} }
		public bool ShowInProgressPanel { get => default; set {} }
	
		// Constructors
		public CamsWindowController() {}
		static CamsWindowController() {}
	
		// Methods
		protected override void Awake() {}
		[IteratorStateMachine(typeof(_Start_d__107))]
		private IEnumerator Start() => default;
		protected override void OpenDefaultTab() {}
		private void ShowUsedServer() {}
		protected override void OnDestroy() {}
		[UICallable]
		public void ToggleShowMoreInformation() {}
		[UICallable]
		public virtual DetailWindowTabController SetWindowTab(CamsWindowTab newTab) => default;
		public override DetailWindowTabController SetWindowTab(int newTabIndex) => default;
		[ContextMenu("CenterContent")]
		public void CenterContent() {}
		[ContextMenu("AlignTop")]
		public void AlignTop() {}
		public void SetupActivationThroughDeepLink(Dictionary<string, string> queryStrings) {}
		public void SetupSetNewPasswordThroughDeepLink(Dictionary<string, string> queryStrings) {}
		public void SetupLoginLobbyThroughDeepLink(Dictionary<string, string> queryStrings) {}
		public void SetupRegistrationThroughDeepLink(Dictionary<string, string> queryStrings) {}
		private void SetRequestedTab(CamsWindowTab requestedTab) {}
		[UICallable]
		public void OpenRegistrationNewAccount() {}
		[UICallable]
		public void OpenHome() {}
		[UICallable]
		public void OpenGameworldCalendar() {}
		[UICallable]
		public void OpenNewsWindow(string newsArticleId) {}
	}
