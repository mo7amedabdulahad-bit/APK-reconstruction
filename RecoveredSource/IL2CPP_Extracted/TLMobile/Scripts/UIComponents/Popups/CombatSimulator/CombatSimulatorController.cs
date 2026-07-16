// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorController : DetailWindowController
	{
		// Fields
		public CombatSimulatorSideController attackerController;
		public CombatSimulatorSideController defenderController;
		public ScrollRect scrollRect;
		[ObservableValue]
		private CombatSimulatorParticipant.Role _yourRole;
		[ObservableValue]
		private AttackType _attackType;
		[ObservableValue]
		private ObservableList<OwnPlayer.TribeId> _possibleAttackTribes;
		[ObservableValue]
		private ObservableList<OwnPlayer.TribeId> _possibleDefendTribes;
		[ObservableValue]
		private ObservableList<OwnPlayer.TribeId> _possibleReinforceTribes;
		[ObservableValue]
		private bool _keepTribeOnConquer;
		[ObservableValue]
		private Village _targetVillage;
	
		// Properties
		[ObservableValue]
		public CombatSimulatorParticipant.Role yourRole { get => default; set {} }
		[ObservableValue]
		public AttackType attackType { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnPlayer.TribeId> possibleAttackTribes { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnPlayer.TribeId> possibleDefendTribes { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnPlayer.TribeId> possibleReinforceTribes { get => default; set {} }
		[ObservableValue]
		public bool keepTribeOnConquer { get => default; set {} }
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
	
		// Constructors
		public CombatSimulatorController() {}
	
		// Methods
		private void _possibleAttackTribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleDefendTribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleReinforceTribesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage village) {}
		private void Setup(CombatSimulatorParticipant.Role ownRole = CombatSimulatorParticipant.Role.Attacker) {}
		public void SetupWithMapCell(MapCell mapCellData) {}
		public void Setup(CombatSimulatorParticipant.Role ownRole, OwnPlayer.TribeId otherTribeId) {}
		public void SetupTroops(CombatSimulatorParticipant.Role side, TroopAmounts troops, bool includeHero = false) {}
		public void SetupBuildingInfo(CombatSimulatorParticipant.Role side, List<RequiredBuilding> buildings) {}
		public void SetupTargetVillage(Village village) {}
		[UICallable]
		public void SetAttackType(AttackType type) {}
		private void SetOwnRole(CombatSimulatorParticipant.Role role) {}
		[UICallable]
		public void ReversePlayerRole() {}
		[UICallable]
		public void AddReinforcement(OwnPlayer.TribeId tribeId) {}
		private void SmoothScrollToBottom() {}
		[UICallable]
		public void Simulate() {}
		private void HandleServerResponse(CombatSimulatorResponse response) {}
		private void ApplyLosses(TroopAmounts attCasualties, List<TroopAmounts> defCasualties, int attHeroHealthLoss, List<int> defHeroHealthLosses) {}
		private static bool UpdateHeroEnabled(CombatSimulatorHero hero) => default;
		private void SendTroops() {}
	}
