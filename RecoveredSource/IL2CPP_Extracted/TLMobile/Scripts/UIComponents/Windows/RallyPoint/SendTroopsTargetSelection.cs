// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendTroopsTargetSelection : GenericTargetSelection
	{
		// Fields
		[ObservableValue]
		private int _totalUnitsAvailable;
		[ObservableValue]
		private int _attackingWWBlockedUntil;
		[ObservableValue]
		private bool _targetSelectedAndUnitsAvailable;
		[ObservableValue]
		private bool _canForwardToVillage;
		[ObservableValue]
		private bool _sameVillage;
		[ObservableValue]
		private bool _permissibleTarget;
		[ObservableValue]
		private bool _confirmTargetBlocked;
		[ObservableValue]
		private SendTroopInfo _sendTroopInfo;
		[ObservableValue]
		private bool _targetHasBeginnersProtection;
		[ObservableValue]
		private bool _ownPlayerHasBeginnersProtection;
		private StandingTroop ownTroopsAtHome;
	
		// Properties
		[ObservableValue]
		public int totalUnitsAvailable { get => default; set {} }
		[ObservableValue]
		public int attackingWWBlockedUntil { get => default; set {} }
		[ObservableValue]
		public bool targetSelectedAndUnitsAvailable { get => default; set {} }
		[ObservableValue]
		public bool canForwardToVillage { get => default; set {} }
		[ObservableValue]
		public bool sameVillage { get => default; set {} }
		[ObservableValue]
		public bool permissibleTarget { get => default; set {} }
		[ObservableValue]
		public bool confirmTargetBlocked { get => default; set {} }
		[ObservableValue]
		public SendTroopInfo sendTroopInfo { get => default; set {} }
		[ObservableValue]
		public bool targetHasBeginnersProtection { get => default; set {} }
		[ObservableValue]
		public bool ownPlayerHasBeginnersProtection { get => default; set {} }
	
		// Constructors
		public SendTroopsTargetSelection() {}
	
		// Methods
		protected override void OnEnable() {}
		public virtual void Setup(SendTroopInfo sendTroopInfo) {}
		protected override void DoAfterChangeChecks() {}
		private void UpdateTotalUnitsAvailable() {}
		private void CheckIfValidForwardingDestination() {}
		[UICallable]
		public void OpenSimulatorsWithTarget() {}
	}
