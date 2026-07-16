// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StatisticsAllianceTabController : DetailWindowTabControllerWithPagination<RankedAlliance>
	{
		// Fields
		[ObservableValue]
		private RankedAlliancePaginationQuery.Ranking _currentSubTab;
		[ObservableValue]
		private AllianceStatistics _top10;
		[ObservableValue]
		private Alliance _searchForAlliance;
		private Alliance ownAllianceObject;
	
		// Properties
		[ObservableValue]
		public RankedAlliancePaginationQuery.Ranking currentSubTab { get => default; set {} }
		[ObservableValue]
		public AllianceStatistics top10 { get => default; set {} }
		[ObservableValue]
		public Alliance searchForAlliance { get => default; set {} }
		protected override bool AllowBackwardLoading { get => default; }
	
		// Constructors
		public StatisticsAllianceTabController() {}
	
		// Methods
		protected override void Awake() {}
		public void Init() {}
		private void InitializeWithOwnRank() {}
		[UICallable]
		public void OpenAllianceSearch() {}
		[UICallable]
		public void NavigateToTop() {}
		[UICallable]
		public void NavigateToCurrentPlayer() {}
		[UICallable]
		public void SetSubTab(RankedAlliancePaginationQuery.Ranking subTab) {}
	}
