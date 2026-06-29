// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointRaidListEditController : DetailWindowController
	{
		// Fields
		public GenericUnitsSelection UnitsSelection;
		public ObservableList<DropdownOption> options;
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private string _listName;
		[ObservableValue]
		private bool _editPopupOpen;
		[ObservableValue]
		private FarmList _existingRaidList;
		[ObservableValue]
		private GraphQLFetchableList<FarmSlot> _existingRaids;
		[ObservableValue]
		private OwnVillage _parentVillage;
		[ObservableValue]
		private bool _useShips;
		[ObservableValue]
		private bool _onlyCreateReportsForLosses;
		private int ownTribeId;
		private ObservableList<DropdownOption> villagesForDropdown;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public string listName { get => default; set {} }
		[ObservableValue]
		public bool editPopupOpen { get => default; set {} }
		[ObservableValue]
		public FarmList existingRaidList { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmSlot> existingRaids { get => default; set {} }
		[ObservableValue]
		public OwnVillage parentVillage { get => default; set {} }
		[ObservableValue]
		public bool useShips { get => default; set {} }
		[ObservableValue]
		public bool onlyCreateReportsForLosses { get => default; set {} }
	
		// Constructors
		public RallyPointRaidListEditController() {}
	
		// Methods
		private void _existingRaidsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Setup(FarmList useExistingRaidList = null, bool showRaidListSelection = false) {}
		private void SelectRaidList(FarmList toSelect) {}
		[UICallable]
		public void ToggleUseShips() {}
		[UICallable]
		public void ToggleOnlyCreateReportsForLosses() {}
		[UICallable]
		public void OpenConfirmDeleteRaidList() {}
		[UICallable]
		public void OpenEditPopup() {}
		[UICallable]
		public void CloseEditPopup() {}
		[UICallable]
		public void CreateOrUpdateList() {}
		public void DeleteList() {}
		[UICallable]
		public void CreateNewList() {}
		[UICallable]
		public void SelectVillage() {}
		private void ShowSuccessAndClose(string translationKey) {}
	}
