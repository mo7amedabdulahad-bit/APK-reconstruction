// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Treasury
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TreasuryOverviewTabController : DetailWindowTabController
	{
		// Fields
		private const string TitleKeyArtefact = "artefact_overview";
		private const string TitleKeyAncientPower = "ancientPower_overview";
		private const string NoContentNearbyKeyArtefact = "gid27.keine_nahen_artefakte";
		private const string NoContentSmallKeyArtefact = "gid27.no_small_arte";
		private const string NoContentLargeKeyArtefact = "gid27.no_big_arte";
		private const string NoContentKeyAncientPower = "ancientPower_no_ancientPower";
		private const string NearbyTipArtefact = "artefact_tip_nearby";
		private const string SmallTipArtefact = "artefact_tip_small";
		private const string LargeTipArtefact = "artefact_tip_large";
		private const string NearbyTipAncientPower = "ancientPower_tip_nearby";
		private const string SmallTipAncientPower = "ancientPower_tip_small";
		private const string LargeTipAncientPower = "ancientPower_tip_large";
		public ObservableList<TreasuryCategoryObject> nearbyPlaceBonuses;
		public ObservableList<TreasuryCategoryObject> smallPlaceBonuses;
		public ObservableList<TreasuryCategoryObject> largePlaceBonuses;
		[ObservableValue]
		private int _firstFilledContent;
		[ObservableValue]
		private bool _noContent;
		[ObservableValue]
		private string _title;
		[ObservableValue]
		private string _noContentMessage;
		[ObservableValue]
		private string _currentTip;
		[ObservableValue]
		private TreasuryStoredObject _currentStoredObjectType;
		[ObservableValue]
		private TreasurySubTab _currentTreasurySubTab;
		[ObservableValue]
		private ObservableList<TreasuryCategoryObject> _currentPlaceBonusesList;
		private OwnVillage currentVillage;
		private IMapPositionService mapPositionService;
		private GraphQLFetchableList<Region> nearbyRegions;
	
		// Properties
		[ObservableValue]
		public int firstFilledContent { get => default; set {} }
		[ObservableValue]
		public bool noContent { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public string noContentMessage { get => default; set {} }
		[ObservableValue]
		public string currentTip { get => default; set {} }
		[ObservableValue]
		public TreasuryStoredObject currentStoredObjectType { get => default; set {} }
		[ObservableValue]
		public TreasurySubTab currentTreasurySubTab { get => default; set {} }
		[ObservableValue]
		public ObservableList<TreasuryCategoryObject> currentPlaceBonusesList { get => default; set {} }
	
		// Constructors
		public TreasuryOverviewTabController() {}
	
		// Methods
		private void _currentPlaceBonusesListNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void UpdatePlaceBonusLists() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void OnVillageChange() {}
		private void UpdateTreasurySubTab() {}
		private void RecalculateDistance(ObservableList<TreasuryCategoryObject> placeBonuses) {}
		private void RecalculateDistance<T>(List<T> placeBonuses)
			where T : PlaceBonusInterface {}
		private void ReorganizeCurrentPlaceBonusesList<T>(List<T> placeBonuses, ObservableList<TreasuryCategoryObject> list, bool nearby = false)
			where T : PlaceBonusInterface {}
		private void UpdateNoContentMessage() {}
		private ObservableList<TreasuryCategoryObject> CreateSortedDictionary() => default;
		[UICallable]
		public void ChangeSubTab(TreasurySubTab next) {}
	}
