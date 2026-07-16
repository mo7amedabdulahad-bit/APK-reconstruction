// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.SwipeableMenus
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewMenuController : ViewModelWithPolling
	{
		// Fields
		private const int MaxVillageGroups = 20;
		public ListDragAndDropController dragAndDropController;
		public SwipeablePanel swipeablePanel;
		[ObservableValue]
		[PollForUpdates(15f, 0, -1f)]
		private GraphQLFetchableList<VillageListItem> _villageItems;
		[ObservableValue]
		private bool _renamingActive;
		[ObservableValue]
		private string _currentVillageName;
		[ObservableValue]
		private ObservableDictionary<Building.TypeId, Building> _buildingAvailable;
		[ObservableValue]
		private bool _anyVillageUnderAttack;
		[ObservableValue]
		private int _usedVillageGroups;
		[ObservableValue]
		private int _maxVillageGroups;
		[ObservableValue]
		private bool _editModeEnabled;
		private OwnVillage currentVillage;
		private List<Building.TypeId> interestingTypes;
		private OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(15f, 0, -1f)]
		public GraphQLFetchableList<VillageListItem> villageItems { get => default; set {} }
		[ObservableValue]
		public bool renamingActive { get => default; set {} }
		[ObservableValue]
		public string currentVillageName { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<Building.TypeId, Building> buildingAvailable { get => default; set {} }
		[ObservableValue]
		public bool anyVillageUnderAttack { get => default; set {} }
		[ObservableValue]
		public int usedVillageGroups { get => default; set {} }
		[ObservableValue]
		public int maxVillageGroups { get => default; set {} }
		[ObservableValue]
		public bool editModeEnabled { get => default; set {} }
	
		// Constructors
		public VillageOverviewMenuController() {}
	
		// Methods
		private void _villageItemsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingAvailableNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private List<UpdateVillageListRequestData> BuildNewVillageList(List<VillageListItem> villageListItems) => default;
		private VillageListItem GetItemWithId(int id) => default;
		public void InitVillages() {}
		private void UpdateGroups() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		[UICallable]
		public void ChangeVillage(OwnVillage village) {}
		[UICallable]
		public void ChangeToVillageId(int id) {}
		[UICallable]
		public void SwitchRenaming() {}
		[UICallable]
		public void OpenBuilding(Building building) {}
		[UICallable]
		public void RenameVillage() {}
		public void CancelRenameVillage(bool value) {}
		[UICallable]
		public void CancelRenameVillage() {}
		private bool IsUnderAttack(VillageListItem item) => default;
		private void CheckAllVillagesForAttacks() {}
		public void CancelEditMode(bool value) {}
		[UICallable]
		public void CreateVillageGroup() {}
	}
