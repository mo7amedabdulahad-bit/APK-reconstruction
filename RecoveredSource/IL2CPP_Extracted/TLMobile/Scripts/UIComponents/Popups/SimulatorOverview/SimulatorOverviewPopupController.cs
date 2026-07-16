// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.SimulatorOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SimulatorOverviewPopupController : DetailWindowController
	{
		// Fields
		private const int IndexCombatSimulatorTab = 0;
		private const int IndexTravelSimulatorTab = 1;
		private const int MinBackendMajorVersionTravelSimulator = 343;
		private const string TranslationKeyComingSoon = "allgemein.comingSoon";
		[SerializeField]
		private GameObject combatTab;
		[SerializeField]
		private GameObject travelTab;
		[SerializeField]
		private CombatSimulatorController combatSimulatorController;
		[SerializeField]
		private TravelSimulatorController travelSimulatorController;
		[ObservableValue]
		private bool _hasActiveTravelSimulator;
		[ObservableValue]
		private int _tabIndex;
		private BootstrapData bootstrapData;
		private MapCell mapCell;
		private CombatSimulatorParticipant.Role ownRole;
		private OwnPlayer.TribeId targetTribeId;
	
		// Properties
		[ObservableValue]
		public bool hasActiveTravelSimulator { get => default; set {} }
		[ObservableValue]
		public int tabIndex { get => default; set {} }
		public CombatSimulatorController CombatSimulatorController { get => default; }
	
		// Constructors
		public SimulatorOverviewPopupController() {}
	
		// Methods
		public void Apply(MapCell value, bool openCombatSimulator = true) {}
		public void Apply(CombatSimulatorParticipant.Role ownRole, OwnPlayer.TribeId targetTribeId) {}
		[UICallable]
		public void OnTabClicked(int index) {}
		protected override void OnEnable() {}
		private void SwitchTab(int index) {}
	}
