// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorSide : ObservableModel
	{
		// Fields
		[ObservableValue]
		private ObservableList<CombatSimulatorParticipant> _participants;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private int _breweryLevel;
		[ObservableValue]
		private int _wallLevel;
		[ObservableValue]
		private int _palaceLevel;
		[ObservableValue]
		private int _stonemasonLevel;
		[ObservableValue]
		private int _traps;
		[ObservableValue]
		private float _metallurgyBonus;
		[ObservableValue]
		private float _architectBonus;
		[ObservableValue]
		private float _eagleEyeBonus;
		[ObservableValue]
		private bool _celebration;
		[ObservableValue]
		private bool _isPlayer;
		[ObservableValue]
		private CombatSimulatorParticipant _mainParticipant;
	
		// Properties
		[ObservableValue]
		public ObservableList<CombatSimulatorParticipant> participants { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public int breweryLevel { get => default; set {} }
		[ObservableValue]
		public int wallLevel { get => default; set {} }
		[ObservableValue]
		public int palaceLevel { get => default; set {} }
		[ObservableValue]
		public int stonemasonLevel { get => default; set {} }
		[ObservableValue]
		public int traps { get => default; set {} }
		[ObservableValue]
		public float metallurgyBonus { get => default; set {} }
		[ObservableValue]
		public float architectBonus { get => default; set {} }
		[ObservableValue]
		public float eagleEyeBonus { get => default; set {} }
		[ObservableValue]
		public bool celebration { get => default; set {} }
		[ObservableValue]
		public bool isPlayer { get => default; set {} }
		[ObservableValue]
		public CombatSimulatorParticipant mainParticipant { get => default; set {} }
	
		// Constructors
		public CombatSimulatorSide() {}
		public CombatSimulatorSide(CombatSimulatorParticipant.Role playerRole, CombatSimulatorParticipant.Role role, OwnPlayer.TribeId tribeId = OwnPlayer.TribeId.Romans) {}
	
		// Methods
		private void _participantsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Reset(CombatSimulatorParticipant.Role playerRole, CombatSimulatorParticipant.Role role, OwnPlayer.TribeId tribeId = OwnPlayer.TribeId.Romans) {}
		public CombatSimulatorBattleSide ConvertToApiAttacker(AttackType type) => default;
		public CombatSimulatorBattleSide ConvertToApiDefender() => default;
	}
