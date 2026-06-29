// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Residence
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResidenceExpansionTabController : DetailWindowTabControllerWithSubTab
	{
		// Fields
		private const int CacaoTextColorIndex = 4;
		private const int OrangeTextColorIndex = 11;
		[SerializeField]
		private GameObject settlementSlotLocked;
		[ObservableValue]
		private bool _citiesEnabled;
		[ObservableValue]
		private int _usedTextColor;
		[ObservableValue]
		private int _nextSlotPrediction;
		[ObservableValue]
		private int _cpProductionOtherVillages;
		[ObservableValue]
		private int _totalCpProduction;
		[ObservableValue]
		private Expansion _expansion;
		[ObservableValue]
		private CulturalPointsOverview _cpOverview;
		[ObservableValue]
		private OwnVillage _ownVillage;
		[ObservableValue]
		private OwnHero _hero;
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private bool _isSettlementSlotTabExpanded;
		[ObservableValue]
		private ObservableList<int> _settlementSlots;
		[ObservableValue]
		private int _villageSlotCount;
		private BootstrapData bootstrapData;
	
		// Properties
		[ObservableValue]
		public bool citiesEnabled { get => default; set {} }
		[ObservableValue]
		public int usedTextColor { get => default; set {} }
		[ObservableValue]
		public int nextSlotPrediction { get => default; set {} }
		[ObservableValue]
		public int cpProductionOtherVillages { get => default; set {} }
		[ObservableValue]
		public int totalCpProduction { get => default; set {} }
		[ObservableValue]
		public Expansion expansion { get => default; set {} }
		[ObservableValue]
		public CulturalPointsOverview cpOverview { get => default; set {} }
		[ObservableValue]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		public OwnHero hero { get => default; set {} }
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public bool isSettlementSlotTabExpanded { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> settlementSlots { get => default; set {} }
		[ObservableValue]
		public int villageSlotCount { get => default; set {} }
	
		// Nested types
		public enum eSettlementSlotState
		{
			Locked = 0,
			Unlocked = 1,
			Village = 2,
			CitySlot1 = 3,
			CitySlot2 = 4
		}
	
		// Constructors
		public ResidenceExpansionTabController() {}
	
		// Methods
		private void _settlementSlotsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage currentVillage) {}
		[UICallable]
		public void OpenAllianceCpBonus() {}
		[UICallable]
		public void ToggleSettlementSlots() {}
		private void OnSettlementSlotChanged() {}
	}
