// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Treasury
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TreasuryStoredTabController : DetailWindowTabController
	{
		// Fields
		public bool showPlaceBonusesActiveOnly;
		[ObservableValue]
		private int _nextFreeTimeStamp;
		[ObservableValue]
		private bool _displayAncientPowers;
		[ObservableValue]
		private PlaceBonusInterface.ScopeType _activeScopeTypes;
		[ObservableValue]
		private TreasuryStoredObject _currentStoredObjectType;
		[ObservableValue]
		private ObservableList<TreasuryObject> _displayedPlaceBonuses;
		[ObservableValue]
		private ObservableList<TreasuryObject> _displayedPlaceBonusesSecond;
		[ObservableValue]
		private bool _showActiveOnlyToggle;
		private BuildingDetailWindowController buildingController;
		private OwnVillage currentVillage;
		private bool isUsingCurrentVillageSlot;
	
		// Properties
		[ObservableValue]
		public int nextFreeTimeStamp { get => default; set {} }
		[ObservableValue]
		public bool displayAncientPowers { get => default; set {} }
		[ObservableValue]
		public PlaceBonusInterface.ScopeType activeScopeTypes { get => default; set {} }
		[ObservableValue]
		public TreasuryStoredObject currentStoredObjectType { get => default; set {} }
		[ObservableValue]
		public ObservableList<TreasuryObject> displayedPlaceBonuses { get => default; set {} }
		[ObservableValue]
		public ObservableList<TreasuryObject> displayedPlaceBonusesSecond { get => default; set {} }
		[ObservableValue]
		public bool showActiveOnlyToggle { get => default; set {} }
	
		// Constructors
		public TreasuryStoredTabController() {}
	
		// Methods
		private void _displayedPlaceBonusesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _displayedPlaceBonusesSecondNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void OnVillageChanged(OwnVillage village) {}
		private void UpdateArtefacts() {}
		private void UpdateTreasury() {}
		private void UpdateAncientPowerManagement() {}
		private void UpdateErrorState() {}
		[UICallable]
		public void ToggleActivePlaceBonusesOnly(bool value) {}
		[UICallable]
		public void ShowDetails(Artefact placeBonus) {}
		[UICallable]
		public void ActivatePlaceBonus(AncientPower placeBonus) {}
		[UICallable]
		public void ToggleAutoReactivate(AncientPower placeBonus) {}
	}
