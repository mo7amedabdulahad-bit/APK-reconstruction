// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorHero : ObservableModel
	{
		// Fields
		public const int BaseHeroStrength = 100;
		private const int RomanStrengthPerLevel = 100;
		private const int OthersStrengthsPerLevel = 80;
		[ObservableValue]
		private bool _enabled;
		[ObservableValue]
		private int _health;
		[ObservableValue]
		private int _strength;
		[ObservableValue]
		private int _offPoints;
		[ObservableValue]
		private int _defPoints;
		[ObservableValue]
		private bool _horseEnabled;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeId;
		[ObservableValue]
		private int _calculatedStrength;
		[ObservableValue]
		private float _calculatedOffBonus;
		[ObservableValue]
		private float _calculatedDefBonus;
	
		// Properties
		[ObservableValue]
		public bool enabled { get => default; set {} }
		[ObservableValue]
		public int health { get => default; set {} }
		[ObservableValue]
		public int strength { get => default; set {} }
		[ObservableValue]
		public int offPoints { get => default; set {} }
		[ObservableValue]
		public int defPoints { get => default; set {} }
		[ObservableValue]
		public bool horseEnabled { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeId { get => default; set {} }
		[ObservableValue]
		public int calculatedStrength { get => default; set {} }
		[ObservableValue]
		public float calculatedOffBonus { get => default; set {} }
		[ObservableValue]
		public float calculatedDefBonus { get => default; set {} }
		public int CombatStrengthPerLevel { get => default; }
	
		// Constructors
		[Obsolete("Only for TGFramework; Please use .ctor with parameters instead")]
		public CombatSimulatorHero() {}
		public CombatSimulatorHero(OwnPlayer.TribeId tribeId, bool isPlayer = false) {}
	
		// Methods
		public CombatSimulatorForceHero ConvertToApi() => default;
		[UICallable]
		public void ToggleEnabled() {}
		[UICallable]
		public void ToggleHorse() {}
		public void ChangeTribe(OwnPlayer.TribeId tribeId) {}
		private void SetupHero(bool isPlayer) {}
		public void ResetHero(bool isPlayer) {}
		public void SetStrengthSpentPoints(int spentPoints) {}
		private void UpdateCalculatedStrength() {}
		private void UpdateCalculatedOffBonus() {}
		private void UpdateCalculatedDefBonus() {}
	}
