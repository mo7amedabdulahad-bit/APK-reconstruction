// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.News
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldNewsWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnIdentity _ownIdentity;
		private DetailWindows? previousWindowType;
		private int previousTabIndex;
		private bool isInGame;
		private GameworldNewsArticleTab articleTabInstance;
	
		// Properties
		[ObservableValue]
		public OwnIdentity ownIdentity { get => default; set {} }
		public NewsEntry SelectedNewsEntry { get; set; }
	
		// Constructors
		public GameworldNewsWindowController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup(DetailWindows? previousWindowType = default, int? previousTabIndex = default, string deepLinkArticleID = null) {}
		public void SetupInGame() {}
		public override DetailWindowTabController SetWindowTab(int newTabIndex) => default;
		private void LoadNewsArticleForDeeplink(string id) {}
		[UICallable]
		public void Back() {}
		[UICallable]
		public void OpenMenu() {}
		[UICallable]
		public void ShareLink() {}
	}
