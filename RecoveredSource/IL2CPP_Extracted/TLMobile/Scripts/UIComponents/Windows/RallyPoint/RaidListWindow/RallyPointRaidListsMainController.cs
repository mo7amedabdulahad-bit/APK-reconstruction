// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointRaidListsMainController : DetailWindowTabController
	{
		// Fields
		public ListDragAndDropController dragAndDropController;
		public RaidListDetailViewController detailViewController;
		[ObservableValue]
		private ObservableList<VillageRaidLists> _raidListsGroupedByVillage;
		[ObservableValue]
		private int _totalRaidsAmount;
		[ObservableValue]
		private int _totalFarmListAmount;
		[ObservableValue]
		private int _maxFarmListAmount;
		[ObservableValue]
		private GraphQLFetchableList<Village> _deactivatedTargets;
		[ObservableValue]
		private GraphQLFetchableList<FarmList> _abandonedFarmLists;
		[ObservableValue]
		private bool _expandAbandonedFarmLists;
		private OwnPlayer currentPlayer;
		private bool resetErrorState;
		private bool isOpeningRaidListReport;
	
		// Properties
		[ObservableValue]
		public ObservableList<VillageRaidLists> raidListsGroupedByVillage { get => default; set {} }
		[ObservableValue]
		public int totalRaidsAmount { get => default; set {} }
		[ObservableValue]
		public int totalFarmListAmount { get => default; set {} }
		[ObservableValue]
		public int maxFarmListAmount { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<Village> deactivatedTargets { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmList> abandonedFarmLists { get => default; set {} }
		[ObservableValue]
		public bool expandAbandonedFarmLists { get => default; set {} }
	
		// Constructors
		public RallyPointRaidListsMainController() {}
	
		// Methods
		private void _raidListsGroupedByVillageNotify(object sender, PropertyChangedEventArgs args) {}
		private void _deactivatedTargetsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _abandonedFarmListsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void RaidListObserver() {}
		public void Init(GraphQLFetchableList<FarmList> raidLists) {}
		private void UpdateTotalActiveRaidsCount() {}
		[UICallable]
		public void DismissDeactivatedTargets() {}
		public void GroupRaidListsByVillage(IList<FarmList> raidLists, bool shouldResetErrorState = false) {}
		[UICallable]
		public void CreateNewRaidList() {}
		[UICallable]
		public void StartRaidList(FarmList raidListToStart) {}
		[UICallable]
		public void EditRaidList(FarmList raidListToEdit) {}
		[UICallable]
		public void ToggleAbandonedFarmListExpanded() {}
		[UICallable]
		public void ExpandRaidList(FarmList raidListToExpand) {}
		[UICallable]
		public void ExpandVillageRaidList(VillageRaidLists villageRaidLists) {}
		[UICallable]
		public void OpenErrorsPopup(FarmList raidList) {}
		[UICallable]
		public void StartAllLists() {}
		[UICallable]
		public void OpenLastRaidReport(FarmSlot raidSlot) {}
		public static void HandleFarmListSendResponse(ApiResponse<SendRaidsResponse> response) {}
		private void AfterSendCallback(ApiResponse<SendRaidsResponse> response) {}
	}
