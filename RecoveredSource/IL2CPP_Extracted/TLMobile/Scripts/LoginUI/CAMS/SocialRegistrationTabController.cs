// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SocialRegistrationTabController : DetailWindowTabController
	{
		// Fields
		public WebViewLinkLocalized CamsGtcLink;
		public WebViewLinkLocalized CamsWithdrawalLink;
		public WebViewLinkLocalized CamsPrivacyLink;
		[ObservableValue]
		private SocialRegistrationError _socialRegistrationError;
		protected CamsWindowController camsWindowController;
		private Func<Promise<AuthorisationSuccess>> confirmCallback;
	
		// Properties
		[ObservableValue]
		public SocialRegistrationError socialRegistrationError { get => default; set {} }
	
		// Constructors
		public SocialRegistrationTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		public void SetupForActivation(Func<Promise<AuthorisationSuccess>> confirmCallback, SocialRegistrationError error) {}
		[UICallable]
		public void ToggleNewsletter() {}
		[UICallable]
		public void GoToLogin() {}
		[UICallable]
		public void GoToRegistration() {}
		[UICallable]
		public void ConfirmAccountCreation() {}
		[UICallable]
		public void LinkClicked(WebViewLinkLocalized webViewLink) {}
	}
