// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StatisticsPlayerTabController : DetailWindowTabControllerWithPagination<RankedPlayer>
	{
		// Fields
		[ObservableValue]
		private RankedPlayerPaginationQuery.Ranking _currentSubTab;
		[ObservableValue]
		private PlayerStatistics _top10;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _searchForPlayer;
		private TLMobile.Generated.GraphQL.Game.Player ownPlayerObject;
	
		// Properties
		[ObservableValue]
		public RankedPlayerPaginationQuery.Ranking currentSubTab { get => default; set {} }
		[ObservableValue]
		public PlayerStatistics top10 { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player searchForPlayer { get => default; set {} }
		protected override bool AllowBackwardLoading { get => default; }
	
		// Constructors
		public StatisticsPlayerTabController() {}
	
		// Methods
		protected override void Awake() {}
		public void Init() {}
		private void InitializeWithOwnRank() {}
		[UICallable]
		public void OpenPlayerSearch() {}
		[UICallable]
		public void NavigateToTop() {}
		[UICallable]
		public void NavigateToCurrentPlayer() {}
		[UICallable]
		public void SetSubTab(RankedPlayerPaginationQuery.Ranking subTab) {}
	}
