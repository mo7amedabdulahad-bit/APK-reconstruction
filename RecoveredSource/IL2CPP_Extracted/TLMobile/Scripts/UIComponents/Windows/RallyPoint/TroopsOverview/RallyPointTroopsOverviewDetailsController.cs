// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointTroopsOverviewDetailsController : DetailWindowTabControllerWithPagination<RallyPointTroopsOverviewDetailsItem>
	{
		// Fields
		public const string DetailsViewEnabledPrefsKey = "TroopsOverviewDetailsOn";
		public RallyPointTroopsOverviewNavigation troopsOverviewNavigation;
		public RallyPointMergeTroopsController mergeTroopsController;
		[ObservableValue]
		private ObservableList<RallyPointTroopsOverviewDetailsItem> _currentSelectedTroops;
		[ObservableValue]
		private RallyPointTroopsOverviewItem.Category _currentSelectedCategory;
		[ObservableValue]
		private bool _allExpanded;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption> _currentFilters;
		[ObservableValue]
		private ObservableList<DropdownOption> _sortOptions;
		private DropdownOption selectedOption;
	
		// Properties
		[ObservableValue]
		public ObservableList<RallyPointTroopsOverviewDetailsItem> currentSelectedTroops { get => default; set {} }
		[ObservableValue]
		public RallyPointTroopsOverviewItem.Category currentSelectedCategory { get => default; set {} }
		[ObservableValue]
		public bool allExpanded { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption> currentFilters { get => default; set {} }
		[ObservableValue]
		public ObservableList<DropdownOption> sortOptions { get => default; set {} }
		public ITroopsPaginatedDataQueryFactory TroopsPaginatedDataQueryFactory { get; set; }
	
		// Nested types
		public enum SortingOption
		{
			None = 0,
			Flagged = 1,
			EarliestArriving = 2,
			LastArriving = 3,
			RecentlySent = 4,
			OldestSent = 5
		}
	
		// Constructors
		public RallyPointTroopsOverviewDetailsController() {}
	
		// Methods
		private void _currentSelectedTroopsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _currentFiltersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _sortOptionsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		[Testable]
		private void SanitizeTroopMovementList() {}
		private void UpdateDataForCurrentSelectedCategory(OwnVillage village) {}
		private void UpdateDataForCurrentSelectedCategory() {}
		private void OnPaginationDataChanged() {}
		private PaginatedListProvider<RallyPointTroopsOverviewDetailsItem> CreateNewDataQuery(RallyPointTroopsOverviewItem.Category category) => default;
		private void SelectedTroopsChanged() {}
		private void ApplyFilterChanges(GraphQLObservableList<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption> obj) {}
		private void ForceUpdateTroopOverview() {}
		[Testable]
		private void PrepareSortingDropdown(RallyPointTroopsOverviewItem.Category itemCategory, GraphQLObservableList<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption> filterOptions) {}
		private DropdownOption GetSortingDropdownOption(int value, SortingOption option) => default;
		private void CheckGlobalExpansionState() {}
		[UICallable]
		public virtual void GoToTroopsDetails(RallyPointTroopsOverviewItem.Category itemCategory) {}
		[UICallable]
		public virtual void ToggleTroopDetail(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public virtual void ExpandAll() {}
		[UICallable]
		public virtual void CollapseAll() {}
		[UICallable]
		public void ForwardTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void MergeTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void WithdrawTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void ReleaseTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void OpenTravelSimulator(int x, int y) {}
		[UICallable]
		public void KillTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void MarkTroops(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void ToggleDetailActions(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void CancelMovement(RallyPointTroopsOverviewDetailsItem item) {}
		[UICallable]
		public void SetupFilters() {}
		[UICallable]
		public void ExitDetailsMode() {}
		[UICallable]
		public void OpenDropdown() {}
	}
