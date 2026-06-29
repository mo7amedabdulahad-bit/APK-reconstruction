// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidListDetailViewController : ViewModelWithPolling
	{
		// Fields
		[SerializeField]
		private SpriteCfg sprites;
		public ScrollRect scrollRect;
		[ObservableValue]
		private FarmList _selectedRaidList;
		[ObservableValue]
		private int _selectedTargetsAmount;
		[ObservableValue]
		private TroopAmounts _selectedTargetsTroopAmounts;
		[ObservableValue]
		private TroopAmounts _selectedContainerVillageAvailableTroops;
		[ObservableValue]
		private RaidsFiltersController.FilterOption _filtersFlags;
		[ObservableValue]
		private GraphQLFetchableList<FarmSlot> _raids;
		[ObservableValue]
		private int _activeFilterCount;
		[ObservableValue]
		private bool _allAreInactive;
		[ObservableValue]
		private bool _allSelectedAreActive;
		[ObservableValue]
		[PollForUpdates(5f, 0, -1f)]
		private OwnVillage _selectedRaidListVillage;
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> sortingOptions;
		private TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption currentSortingOption;
	
		// Properties
		[ObservableValue]
		public FarmList selectedRaidList { get => default; set {} }
		[ObservableValue]
		public int selectedTargetsAmount { get => default; set {} }
		[ObservableValue]
		public TroopAmounts selectedTargetsTroopAmounts { get => default; set {} }
		[ObservableValue]
		public TroopAmounts selectedContainerVillageAvailableTroops { get => default; set {} }
		[ObservableValue]
		public RaidsFiltersController.FilterOption filtersFlags { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmSlot> raids { get => default; set {} }
		[ObservableValue]
		public int activeFilterCount { get => default; set {} }
		[ObservableValue]
		public bool allAreInactive { get => default; set {} }
		[ObservableValue]
		public bool allSelectedAreActive { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(5f, 0, -1f)]
		public OwnVillage selectedRaidListVillage { get => default; set {} }
	
		// Constructors
		public RaidListDetailViewController() {}
	
		// Methods
		private void _raidsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public virtual void Setup(FarmList raidList, GraphQLFetchableList<FarmSlot> raids) {}
		private void UpdateAvailableTroops() {}
		[UICallable]
		public void ToggleRaidListTarget(FarmSlot raid) {}
		[UICallable]
		public void CloseRaidList() {}
		[UICallable]
		public void ToggleAllTargetsTo(int newState) {}
		[UICallable]
		public void StartSelectedRaids() {}
		[UICallable]
		public void EditSelected() {}
		[UICallable]
		public void DuplicateSelected() {}
		[UICallable]
		public void DeleteSelected() {}
		private void ConfirmDelete() {}
		[UICallable]
		public void ToggleIsActiveStatusSelected() {}
		[UICallable]
		public void OpenAddTargetPopup(FarmList raidList) {}
		[UICallable]
		public void OpenFiltersPopup() {}
		[UICallable]
		public void OpenSortingPopup() {}
		private void ScrollToTop() {}
		private void UpdateSelectedTargets() {}
		private void AfterSendCallback(ApiResponse<SendRaidsResponse> response) {}
		[Testable]
		private void UpdateFilterCount() {}
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> CreateSortingOptions(SortOrder order) => default;
		private ChangeSortingRequest.SortFieldEnum GetSortEnumFromString(string graphQLValue) => default;
		private SortOrder GetSortDirectionEnumFromString(string graphQlValue) => default;
		public void OnCallbackApplyChanges(TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption sortingOption) {}
	}
