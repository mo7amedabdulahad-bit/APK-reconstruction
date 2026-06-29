// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageController : ViewModelWithPolling
	{
		// Fields
		[SerializeField]
		public List<BuildingSlot> slotIdToPositionList;
		[ObservableValue]
		private ObservableList<BuildingInfo> _buildings;
		[ObservableValue]
		private ObservableList<BuildingInfo> _emptySlots;
		[ObservableValue]
		private BuildingInfo _wall;
		[ObservableValue]
		private float _buildingNameRibbonOpacity;
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		private OwnVillage _ownVillage;
		[Testable]
		private ObservableList<BuildingInfo> allConstructedBuildings;
		private ObservableDictionary<int, BuildingInfo> allSlots;
	
		// Properties
		[ObservableValue]
		public ObservableList<BuildingInfo> buildings { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> emptySlots { get => default; set {} }
		[ObservableValue]
		public BuildingInfo wall { get => default; set {} }
		[ObservableValue]
		public float buildingNameRibbonOpacity { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		public OwnVillage ownVillage { get => default; set {} }
		public Dictionary<int, Vector3> SlotIdToPosition { get; private set; }
		public Dictionary<int, int> SlotIdToOrderInLayer { get; private set; }
	
		// Constructors
		public VillageController() {}
	
		// Methods
		private void _buildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _emptySlotsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void PointerStatusChanged(MouseInfo.MouseButton btn, bool status) {}
		public void Init() {}
		private void ObserveOnOwnVillage(OwnVillage currentVillage) {}
		private void OnBuildingsInVillageChanged() {}
		private void UpdateBuildingsUpgradeState() {}
		[UICallable]
		public void OpenMenu(Building building) {}
		[UICallable]
		public void OpenNewBuildingMenu(int slotId) {}
		private void InitializeSlotIdMapping(List<BuildingSlot> slotIdToPositionInGameObjectTransform) {}
	}
