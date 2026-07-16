// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsRegistrationTabController : CamsEmailInputTabController
	{
		// Fields
		public float redirectDelay;
		public WebViewLinkLocalized CamsGtcLink;
		public WebViewLinkLocalized CamsWithdrawalLink;
		public WebViewLinkLocalized CamsPrivacyLink;
		[ObservableValue]
		private bool _isRedirecting;
		[ObservableValue]
		private int _redirectionCountdown;
		private bool isSocialLoginPending;
		private Coroutine redirectCoroutine;
	
		// Properties
		[ObservableValue]
		public bool isRedirecting { get => default; set {} }
		[ObservableValue]
		public int redirectionCountdown { get => default; set {} }
	
		// Constructors
		public CamsRegistrationTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		public override void OnOpen(int tabNumber) {}
		private IPromise<ApiResponse<RestAPI.Lobby.Model.StandardSuccess>> ConfirmEmail(string email) => default;
		[UICallable]
		public void ToggleNewsletter() {}
		[UICallable]
		public void CheckEmail() {}
		[UICallable]
		public void LaunchGoogleLogin() {}
		[UICallable]
		public void LaunchFacebookLogin() {}
		[UICallable]
		public void LaunchAppleLogin() {}
		private void SocialLoginResults(Func<Promise<AuthorisationSuccess>> onSuccess, SocialRegistrationError error) {}
		private void RedirectToLoginScreen() {}
		[IteratorStateMachine(typeof(_RedirectToLoginScreenCoroutine_d__24))]
		private IEnumerator RedirectToLoginScreenCoroutine() => default;
		[UICallable]
		public void StopRedirection() {}
		[UICallable]
		public void OpenLoginAlreadyHaveAnAccount() {}
		[UICallable]
		public void LinkClicked(WebViewLinkLocalized webViewLink) {}
	}
