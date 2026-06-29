// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportsOverviewTabController : ReportsTabController
	{
		// Fields
		[ObservableValue]
		private int _activeFiltersCount;
		[ObservableValue]
		private Village _filterForVillage;
		[ObservableValue]
		private OasisInterface _filterForOasis;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _filterForPlayer;
		private ReportFilterPopup filtersPopup;
		private GraphQLObservableList<ReportIcon> lastUsedFilters;
	
		// Properties
		[ObservableValue]
		public int activeFiltersCount { get => default; set {} }
		[ObservableValue]
		public Village filterForVillage { get => default; set {} }
		[ObservableValue]
		public OasisInterface filterForOasis { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player filterForPlayer { get => default; set {} }
	
		// Constructors
		public ReportsOverviewTabController() {}
	
		// Methods
		public override void Init() {}
		private void ApplyFilters(GraphQLObservableList<ReportIcon> filters) {}
		[UICallable]
		public void MarkReportsAsRead() {}
		protected override void DeleteAllReports(IReportsApi reportsApi) {}
		[UICallable]
		public void OpenFilterForTargetPopup() {}
		[UICallable]
		public void DisableTargetFilter() {}
		public void FilterForVillage(Village village) {}
		public void FilterForOasis(OasisInterface oasis) {}
		public void FilterForPlayer(TLMobile.Generated.GraphQL.Game.Player player) {}
	}
