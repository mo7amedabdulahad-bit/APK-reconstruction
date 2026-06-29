// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsLoginTabController : CamsDetailWindowTabController
	{
		// Fields
		public string BackToRegistrationLink;
		public string CreateAccountLink;
		public AdvancedInputField passwordInputField;
		public AdvancedInputField usernameInputField;
		[ObservableValue]
		private SingleInputController _passwordInputController;
		[ObservableValue]
		private SingleInputController _usernameInputController;
		private bool isSocialLoginPending;
	
		// Properties
		[ObservableValue]
		public SingleInputController passwordInputController { get => default; set {} }
		[ObservableValue]
		public SingleInputController usernameInputController { get => default; set {} }
	
		// Constructors
		public CamsLoginTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected void OnApplicationQuit() {}
		public override void OnOpen(int tabNumber) {}
		private void UpdateLoginState() {}
		[UICallable]
		public void UpdateUsernameInput() {}
		[UICallable]
		public void UpdatePasswordInput() {}
		[UICallable]
		public bool HasInputError() => default;
		[UICallable]
		public void Login() {}
		[UICallable]
		public void LaunchGoogleLogin() {}
		[UICallable]
		public void LaunchFacebookLogin() {}
		[UICallable]
		public void LaunchAppleLogin() {}
		private void SocialLoginResults(Func<Promise<AuthorisationSuccess>> onSuccess, SocialRegistrationError error) {}
	}
