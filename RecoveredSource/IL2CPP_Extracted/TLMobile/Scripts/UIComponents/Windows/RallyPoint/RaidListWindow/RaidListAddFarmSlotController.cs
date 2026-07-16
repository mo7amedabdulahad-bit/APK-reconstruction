// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidListAddFarmSlotController : DetailWindowController
	{
		// Fields
		public const int MaxSlotsAmount = 100;
		public GenericUnitsSelection UnitsSelection;
		public GenericTargetSelection TargetSelection;
		public ObservableList<DropdownOption> options;
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private FarmList _existingRaidList;
		[ObservableValue]
		private GraphQLFetchableList<FarmList> _allRaidLists;
		[ObservableValue]
		private float _distanceToTarget;
		[ObservableValue]
		private int _timeToTarget;
		[ObservableValue]
		private bool _deactivateTarget;
		[ObservableValue]
		private bool _editPopupOpen;
		[ObservableValue]
		private bool _raidListIsFull;
		[ObservableValue]
		private bool _showConfirmAddTarget;
		private System.Action addedToFarmList;
		private ObservableList<DropdownOption> villagesForDropdown;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public FarmList existingRaidList { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmList> allRaidLists { get => default; set {} }
		[ObservableValue]
		public float distanceToTarget { get => default; set {} }
		[ObservableValue]
		public int timeToTarget { get => default; set {} }
		[ObservableValue]
		public bool deactivateTarget { get => default; set {} }
		[ObservableValue]
		public bool editPopupOpen { get => default; set {} }
		[ObservableValue]
		public bool raidListIsFull { get => default; set {} }
		[ObservableValue]
		public bool showConfirmAddTarget { get => default; set {} }
	
		// Constructors
		public RaidListAddFarmSlotController() {}
	
		// Methods
		private void _allRaidListsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Setup(FarmList useExistingRaidList = null, Village preSelectedTarget = null, System.Action addedToFarmList = null) {}
		private void RaidListsChanged() {}
		private void SelectedRaidListChanged(DropdownOption option) {}
		private void SelectRaidList(FarmList toSelect) {}
		private void CheckTargetVillageValid() {}
		private void UpdateTravelDurationAndDistance() {}
		[UICallable]
		public void AddTargetToList() {}
		[UICallable]
		public void ConfirmAddTargetToList() {}
		[UICallable]
		public void CancelAddTargetToList() {}
		private void ShowSuccessAndClose(string translationKey) {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void OpenEditPopup() {}
		[UICallable]
		public void CloseEditPopup() {}
		[UICallable]
		public void ToggleDeactivateTarget() {}
		[UICallable]
		public void CreateNewList() {}
	}
