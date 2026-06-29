// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingArrangementTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private BuildEvent _buildEvent;
		[ObservableValue]
		private bool _canDemolishBuildings;
		[ObservableValue]
		private int _requiredMainBuildingLevelForDemolition;
		[ObservableValue]
		[PollForUpdates(5f, 0, -1f)]
		private OwnVillage _currentVillage;
		private Building selectedBuilding;
	
		// Properties
		[ObservableValue]
		public BuildEvent buildEvent { get => default; set {} }
		[ObservableValue]
		public bool canDemolishBuildings { get => default; set {} }
		[ObservableValue]
		public int requiredMainBuildingLevelForDemolition { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(5f, 0, -1f)]
		public OwnVillage currentVillage { get => default; set {} }
	
		// Constructors
		public BuildingArrangementTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDisable() {}
		public override void OnOpen(int tabNumber) {}
		private void RefreshVillageData() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void OnVillageChange() {}
		public void Setup(Building building) {}
		[UICallable]
		public void CancelDemolishLevel() {}
		[UICallable]
		public void OpenRearrangeMode() {}
		[UICallable]
		public void ShowCompleteImmediatelyPopupAndRefresh() {}
		[UICallable]
		public void OpenDemolishMode() {}
	}
