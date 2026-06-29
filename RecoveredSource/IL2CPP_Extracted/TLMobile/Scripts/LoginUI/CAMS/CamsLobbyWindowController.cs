// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsLobbyWindowController : DetailWindowController
	{
		// Fields
		private const string LastSeenNewsArticleSaveKey = "lastSeenNewsArticleId";
		private readonly string[] pTRURLs;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> _gameworlds;
		[ObservableValue]
		private OwnIdentity _ownIdentity;
		[ObservableValue]
		private int _calendarNotificationCount;
		[ObservableValue]
		private NewsEntry _previewEntry;
		private CamsLobbyWindowTab requestedTab;
		private bool resumeFromDeeplink;
	
		// Properties
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> gameworlds { get => default; set {} }
		[ObservableValue]
		public OwnIdentity ownIdentity { get => default; set {} }
		[ObservableValue]
		public int calendarNotificationCount { get => default; set {} }
		[ObservableValue]
		public NewsEntry previewEntry { get => default; set {} }
	
		// Nested types
		public enum CamsLobbyWindowTab
		{
			GamworldOverview = 0,
			JoinGameworld = 1
		}
	
		// Constructors
		public CamsLobbyWindowController() {}
	
		// Methods
		private void _gameworldsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void RefreshNotificationCount() {}
		[UICallable]
		public virtual DetailWindowTabController SetWindowTab(CamsLobbyWindowTab newTab) => default;
		public override DetailWindowTabController SetWindowTab(int newTabIndex) => default;
		[UICallable]
		public void ReturnToGameworldOverview() {}
		[UICallable]
		public void JoinNewGameWorld() {}
		[UICallable]
		public void OpenMenu() {}
		[UICallable]
		public void JoinDiscord() {}
		public void SetupJoinGameworld(Dictionary<string, string> _) {}
		public void SetupGameWorldOverview(Dictionary<string, string> _) {}
		private void SetRequestedTab(CamsLobbyWindowTab requestedTab) {}
		[UICallable]
		public void OpenGameworldCalendar() {}
		[UICallable]
		public void OpenNewsWindow(string newsArticleId = null) {}
		private void LoadNewsPreviewArticle() {}
	}
