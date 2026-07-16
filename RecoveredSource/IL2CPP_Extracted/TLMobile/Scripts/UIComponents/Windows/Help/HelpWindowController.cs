// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Help
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HelpWindowController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private string _buildNumber;
	
		// Properties
		[ObservableValue]
		public string buildNumber { get => default; set {} }
	
		// Constructors
		public HelpWindowController() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public void OpenTicket() {}
		[UICallable]
		public void JoinDiscord() {}
		[UICallable]
		public void OpenKnowledgeBase() {}
		[UICallable]
		public void OpenGameRules() {}
		private void OpenFreshDeskLink(GetAuthLinkRequest.ForceRedirectEnum redirectValue) {}
		[UICallable]
		public void CopyVersionToClipboard() {}
	}
