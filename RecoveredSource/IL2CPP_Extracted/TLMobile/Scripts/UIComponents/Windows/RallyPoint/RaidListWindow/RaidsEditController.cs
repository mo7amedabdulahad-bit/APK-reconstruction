// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidsEditController : DetailWindowController
	{
		// Fields
		public GenericUnitsSelection unitsSelection;
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private bool _editPopupOpen;
		[ObservableValue]
		private FarmList _containingRaidList;
		[ObservableValue]
		private bool _allTroopsAreTheSame;
		[ObservableValue]
		private bool _noTroopsSelected;
		[ObservableValue]
		private bool _multiEdit;
		[ObservableValue]
		private GraphQLObservableList<FarmSlot> _raidsInEdit;
		[ObservableValue]
		private bool? _deactivateRaids;
		[ObservableValue]
		private RaidsFiltersController.FilterOption _filtersFlags;
		[ObservableValue]
		private bool _raidListIsFull;
		[ObservableValue]
		private bool _raidListAlreadyContainsTargets;
		[ObservableValue]
		private bool _isDuplicating;
		[ObservableValue]
		private TargetRelation _relationToTarget;
		[ObservableValue]
		private float _distanceToTarget;
		[ObservableValue]
		private int _timeToTarget;
		[ObservableValue]
		private FarmList _originalRaidList;
		private GraphQLFetchableList<FarmList> allLists;
		private RaidListDetailViewController master;
		private int ownTribeId;
		[ObservableValue]
		private DropdownOption _selectedOption;
		public ObservableList<DropdownOption> options;
		private System.Action onClosed;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public bool editPopupOpen { get => default; set {} }
		[ObservableValue]
		public FarmList containingRaidList { get => default; set {} }
		[ObservableValue]
		public bool allTroopsAreTheSame { get => default; set {} }
		[ObservableValue]
		public bool noTroopsSelected { get => default; set {} }
		[ObservableValue]
		public bool multiEdit { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<FarmSlot> raidsInEdit { get => default; set {} }
		[ObservableValue]
		public bool? deactivateRaids { get => default; set {} }
		[ObservableValue]
		public RaidsFiltersController.FilterOption filtersFlags { get => default; set {} }
		[ObservableValue]
		public bool raidListIsFull { get => default; set {} }
		[ObservableValue]
		public bool raidListAlreadyContainsTargets { get => default; set {} }
		[ObservableValue]
		public bool isDuplicating { get => default; set {} }
		[ObservableValue]
		public TargetRelation relationToTarget { get => default; set {} }
		[ObservableValue]
		public float distanceToTarget { get => default; set {} }
		[ObservableValue]
		public int timeToTarget { get => default; set {} }
		[ObservableValue]
		public FarmList originalRaidList { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption { get => default; set {} }
	
		// Constructors
		public RaidsEditController() {}
	
		// Methods
		private void _raidsInEditNotify(object sender, PropertyChangedEventArgs args) {}
		private void CheckTheTargetFarmlistErrors() {}
		public virtual void Setup(RaidListDetailViewController master, GraphQLObservableList<FarmSlot> raidsToEdit, FarmList activeRaidList, RaidsFiltersController.FilterOption filters = RaidsFiltersController.FilterOption.None, bool duplicate = false, System.Action onPopupClosed = null) {}
		private void UpdateTravelDurationAndDistance() {}
		private void SelectedRaidListChanged(DropdownOption option) {}
		[UICallable]
		public void OpenConfirmDeleteRaidListTarget() {}
		[UICallable]
		public void ChangeDeactivateState() {}
		public void ConfirmDelete() {}
		[UICallable]
		public void SetTroops() {}
		[UICallable]
		public void ConfirmTroopsEdit() {}
		[UICallable]
		public void CancelTroopsEdit() {}
		[UICallable]
		public void SaveChanges() {}
		[UICallable]
		public void DuplicateTargets() {}
		[UICallable]
		public void OpenDropdown() {}
		public override void Hide() {}
		private void FinalizeApiCall(GraphQLFetchableList<FarmList> raidLists) {}
	}
