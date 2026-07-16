// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.ResourceFields
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceFieldsController : ViewModelWithPolling
	{
		// Fields
		public GameObject resourceFieldLevelUpAnimationsPrefab;
		public GameObject resourceFieldUpgradingAnimationPrefab;
		public List<Transform> slotIdToPositionList;
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		private OwnVillage _currentVillage;
		[ObservableValue]
		private ObservableList<Vector3> _slotPositions;
		[ObservableValue]
		private ObservableList<BuildingInfo> _resourceFields;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		public OwnVillage currentVillage { get => default; set {} }
		[ObservableValue]
		public ObservableList<Vector3> slotPositions { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildingInfo> resourceFields { get => default; set {} }
	
		// Constructors
		public ResourceFieldsController() {}
	
		// Methods
		private void _slotPositionsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _resourceFieldsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		protected override void OnDestroy() {}
		private void CurrentVillageChanged(OwnVillage curVillage) {}
		private void InitializeResourceFields() {}
		private void UpdateBuildingsUpgradeState() {}
		private void SetSlotPositions() {}
		[UICallable]
		public void OpenMenu(Building building) {}
		[UICallable]
		public void OpenMenuBySlotId(int slotId) {}
		[UICallable]
		public void SwitchToVillageView() {}
	}
