// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorResultController : ReportDetailWindowController
	{
		// Fields
		[ObservableValue]
		private CombatSimulatorParticipant.Role _ownRole;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private bool _attackVillageBlocked;
		private Action<TroopAmounts, List<TroopAmounts>, int, List<int>> applyLossesCallback;
		private TroopAmounts attCasualties;
		private int attHeroHealthLoss;
		private List<TroopAmounts> defCasualties;
		private List<int> defHeroHealthLosses;
		private CombatSimulatorController mainCtrl;
		private System.Action sendTroopsCallback;
	
		// Properties
		[ObservableValue]
		public CombatSimulatorParticipant.Role ownRole { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public bool attackVillageBlocked { get => default; set {} }
	
		// Constructors
		public CombatSimulatorResultController() {}
	
		// Methods
		public void Setup(CombatSimulatorResponse response, CombatSimulatorController mainCtrl, System.Action sendTroopsCallback, Action<TroopAmounts, List<TroopAmounts>, int, List<int>> applyLossesCallback, Village targetVillage = null) {}
		private RaidReport HandleServerResponse(CombatSimulatorResponse response) => default;
		private ReportBattleStatisticsEntry ConvertStatisticsResponse(CombatSimulatorStatistics source) => default;
		[UICallable]
		public void SendTroops() {}
		[UICallable]
		public void ApplyLosses() {}
		private static string DecodeBrowserHtmlStyles(string rawString) => default;
	}
