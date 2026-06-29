// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsLobbyJoinGameWorld : CamsDetailLobbyTabController
	{
		// Fields
		private readonly List<ServerDomain> ServerDomainPriorityOrder;
		[ObservableValue]
		private int _activeFiltersCount;
		[ObservableValue]
		private GameWorldFilterFlag _gameWorldFilterFlag;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> _gameworlds;
		[ObservableValue]
		private ObservableDictionary<ServerDomain, List<TLMobile.Generated.GraphQL.Lobby.Gameworld>> _gameworldsByDomains;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> _newGameworlds;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _recommendedGameworld;
		[ObservableValue]
		private ServerDomainFlags _selectedDomainFlags;
		[ObservableValue]
		private ObservableList<ServerDomain> _sortedServerDomains;
		private ServerFilterPopup filtersPopup;
		private ObservableList<Avatar> ownAvatars;
	
		// Properties
		[ObservableValue]
		public int activeFiltersCount { get => default; set {} }
		[ObservableValue]
		public GameWorldFilterFlag gameWorldFilterFlag { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> gameworlds { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<ServerDomain, List<TLMobile.Generated.GraphQL.Lobby.Gameworld>> gameworldsByDomains { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Lobby.Gameworld> newGameworlds { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld recommendedGameworld { get => default; set {} }
		[ObservableValue]
		public ServerDomainFlags selectedDomainFlags { get => default; set {} }
		[ObservableValue]
		public ObservableList<ServerDomain> sortedServerDomains { get => default; set {} }
	
		// Constructors
		public CamsLobbyJoinGameWorld() {}
	
		// Methods
		private void _gameworldsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _gameworldsByDomainsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _newGameworldsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _sortedServerDomainsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void UpdateRecommended(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> newGameworlds) {}
		private TLMobile.Generated.GraphQL.Lobby.Gameworld FindRecommendedGameworld(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> sortedGameworldList, bool forceRecommended) => default;
		private TLMobile.Generated.GraphQL.Lobby.Gameworld FindLocalServerWithFittingLanguageBelowMaxRecommendedAge(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> sortedGameworldList) => default;
		private TLMobile.Generated.GraphQL.Lobby.Gameworld FindSlowestAndYoungestVanillaOrLocalServer(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> sortedGameworldList) => default;
		private TLMobile.Generated.GraphQL.Lobby.Gameworld FindSlowestAndYoungestSpecialServer(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> sortedGameworldList) => default;
		private void PreselectRegion() {}
		private void UpdateServerSelection() {}
		private GameWorldFilterFlag GetFlagForSpeed(int speed) => default;
		public void FillGameworldInfos(List<TLMobile.Generated.GraphQL.Lobby.Gameworld> gameworldDataList) {}
		private void SortGameworldsByDomains(Dictionary<ServerDomain, List<TLMobile.Generated.GraphQL.Lobby.Gameworld>> unsortedGameworldsByDomains) {}
		[UICallable]
		public void OpenFilterOptions() {}
		private void FilterChanged(GraphQLObservableList<GameWorldFilter> obj) {}
		[UICallable]
		public void SelectRegion(int index) {}
		[UICallable]
		public void JoinGameWorld(TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld) {}
		public static void JoinGameworld(string gameworldUuid) {}
		public static void JoinGameworld(TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld) {}
	}
