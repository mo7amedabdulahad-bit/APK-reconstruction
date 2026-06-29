// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapCellInfoWindowController : DetailWindowController
	{
		// Fields
		private readonly GraphQLFetchableList<Region> allRegions;
		[ObservableValue]
		private MapCell _mapCellData;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _ownerPlayer;
		[ObservableValue]
		private Alliance _ownerAlliance;
		[ObservableValue]
		private Village _belongsToVillage;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private bool _showVillageInfos;
		[ObservableValue]
		private bool _showLandDistribution;
		[ObservableValue]
		private bool _foundVillagePossible;
		[ObservableValue]
		private bool _heroIsAvailable;
		[ObservableValue]
		private bool _sendMerchantsPossible;
		[ObservableValue]
		private int _troopsAvailable;
		[ObservableValue]
		private bool _addRaidlistPossible;
		[ObservableValue]
		private Adventure _adventureHere;
		[ObservableValue]
		private TroopAmounts _freeOasisTroopAmounts;
		[ObservableValue]
		private Tab _currentTab;
		[ObservableValue]
		private GraphQLFetchableList<FarmList> _existingRaidLists;
		[ObservableValue]
		private int _maxCellDistance;
		[ObservableValue]
		private int _villageId;
		[ObservableValue]
		private MapReports _mapReports;
		[ObservableValue]
		private float _maxCurrentVillageOasesSlots;
		[ObservableValue]
		private bool _isOasisOccupiable;
		[ObservableValue]
		private bool _canOccupyOasis;
		[ObservableValue]
		private LandDistribution _landDistributionObject;
		[ObservableValue]
		private bool _sendTroopsValid;
		[ObservableValue]
		private bool _targetHasBeginnersProtection;
		[ObservableValue]
		private bool _ownPlayerHasBeginnersProtection;
		[ObservableValue]
		private bool _sendTroopsBlocked;
		[ObservableValue]
		private bool _isEuropeMap;
		[ObservableValue]
		private bool _isTerritory;
		[ObservableValue]
		private Region _cellRegion;
		[ObservableValue]
		private MapPlayerData _mapPlayerData;
		[ObservableValue]
		private MapMarker _playerMarker;
		[ObservableValue]
		private MapMarker _allianceMarker;
		[ObservableValue]
		private GraphQLObservableList<MapFlag> _flagMarkers;
		private bool isInitialized;
		private OwnPlayer ownPlayer;
		private OwnVillage ownVillage;
		private TroopAmounts troopAmountsAtVillage;
	
		// Properties
		[ObservableValue]
		public MapCell mapCellData { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player ownerPlayer { get => default; set {} }
		[ObservableValue]
		public Alliance ownerAlliance { get => default; set {} }
		[ObservableValue]
		public Village belongsToVillage { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public bool showVillageInfos { get => default; set {} }
		[ObservableValue]
		public bool showLandDistribution { get => default; set {} }
		[ObservableValue]
		public bool foundVillagePossible { get => default; set {} }
		[ObservableValue]
		public bool heroIsAvailable { get => default; set {} }
		[ObservableValue]
		public bool sendMerchantsPossible { get => default; set {} }
		[ObservableValue]
		public int troopsAvailable { get => default; set {} }
		[ObservableValue]
		public bool addRaidlistPossible { get => default; set {} }
		[ObservableValue]
		public Adventure adventureHere { get => default; set {} }
		[ObservableValue]
		public TroopAmounts freeOasisTroopAmounts { get => default; set {} }
		[ObservableValue]
		public Tab currentTab { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmList> existingRaidLists { get => default; set {} }
		[ObservableValue]
		public int maxCellDistance { get => default; set {} }
		[ObservableValue]
		public int villageId { get => default; set {} }
		[ObservableValue]
		public MapReports mapReports { get => default; set {} }
		[ObservableValue]
		public float maxCurrentVillageOasesSlots { get => default; set {} }
		[ObservableValue]
		public bool isOasisOccupiable { get => default; set {} }
		[ObservableValue]
		public bool canOccupyOasis { get => default; set {} }
		[ObservableValue]
		public LandDistribution landDistributionObject { get => default; set {} }
		[ObservableValue]
		public bool sendTroopsValid { get => default; set {} }
		[ObservableValue]
		public bool targetHasBeginnersProtection { get => default; set {} }
		[ObservableValue]
		public bool ownPlayerHasBeginnersProtection { get => default; set {} }
		[ObservableValue]
		public bool sendTroopsBlocked { get => default; set {} }
		[ObservableValue]
		public bool isEuropeMap { get => default; set {} }
		[ObservableValue]
		public bool isTerritory { get => default; set {} }
		[ObservableValue]
		public Region cellRegion { get => default; set {} }
		[ObservableValue]
		public MapPlayerData mapPlayerData { get => default; set {} }
		[ObservableValue]
		public MapMarker playerMarker { get => default; set {} }
		[ObservableValue]
		public MapMarker allianceMarker { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MapFlag> flagMarkers { get => default; set {} }
	
		// Nested types
		public enum Tab
		{
			Infos = 0,
			Reports = 1,
			Surrounding = 2
		}
	
		// Constructors
		public MapCellInfoWindowController() {}
	
		// Methods
		private void _existingRaidListsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _flagMarkersNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void Initialize() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void CheckOwnVillageForUnoccupiedOasesSlots() {}
		private void CheckAnnexOasisButton() {}
		private void SetOwnerPlayer(int id) {}
		public void SetMapCell(MapCell mapCell) {}
		private void UpdateMapCell(MapCell mapCell) {}
		public void RefreshMapMarkers() {}
		private bool MaxVillagesNotReached() => default;
		private bool RegionIsAvailableToSettle() => default;
		private TroopAmounts GetFreeOasisTroopInfos() => default;
		private void OnRegionsLoaded(GraphQLFetchableList<Region> regions) {}
		[UICallable]
		public void SwitchToTab(Tab tab) {}
		[UICallable]
		public void SendTroopsToRaid() {}
		[UICallable]
		public void SendTroopsToSettle() {}
		[UICallable]
		public void SendTroopsToVillage(UnitType unitToPreSelect) {}
		private SendTroopsMainController OpenSendTroopWindow(Village targetVillage, UnitType unitToPreSelect = UnitType.None, AttackType preselectedAttackType = AttackType.NoSelection, int preselectedAmount = -1, SendTroopsView sendTroopsView = SendTroopsView.SelectUnits) => default;
		private SendTroopsMainController OpenSendTroopWindow(MapCell targetMapCell, UnitType unitToPreSelect = UnitType.None, AttackType preselectedAttackType = AttackType.NoSelection, int preselectedAmount = -1, SendTroopsView sendTroopsView = SendTroopsView.SelectUnits) => default;
		private void UpdateFoundNewVillageStatus(BootstrapData bootstrap) {}
		private static SendTroopsMainController GetSendTroopMainController() => default;
		[UICallable]
		public void OpenMapMarkerMenu() {}
		[UICallable]
		public void CenterMap() {}
		private void OnMapViewLoaded(SceneStatus status) {}
		private void CloseAllWindows() {}
		[UICallable]
		public void AddToRaidList() {}
		[UICallable]
		public void EditExistingRaidList() {}
		[UICallable]
		public void RemoveTargetFromAllLists() {}
		private void RemoveFromAllFarmListsConfirmed(bool remove) {}
		[UICallable]
		public void StartAdventure() {}
		[UICallable]
		public void SendMerchants() {}
		[UICallable]
		public void OpenReport(ReportInterface report) {}
		[UICallable]
		public void GoToOwnVillage() {}
		[UICallable]
		public void OpenSimulatorOverview() {}
		[UICallable]
		public void OpenFilteredReports() {}
	}
