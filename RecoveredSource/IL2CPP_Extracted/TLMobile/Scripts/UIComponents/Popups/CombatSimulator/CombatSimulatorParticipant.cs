// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorParticipant : ObservableModel
	{
		// Fields
		[ObservableValue]
		private OwnPlayer.TribeId _tribeId;
		[ObservableValue]
		private TroopAmounts _troopAmounts;
		[ObservableValue]
		private ObservableList<int> _catapultTargets;
		[ObservableValue]
		private CombatSimulatorHero _hero;
		[ObservableValue]
		private Role _role;
		[ObservableValue]
		private TroopInfo _chief;
		[ObservableValue]
		private bool _allLevelZero;
		[ObservableValue]
		private bool _allAmountsZero;
		[ObservableValue]
		private int _catapultId;
		[ObservableValue]
		private int _selectedWeapon;
		[ObservableValue]
		private int _selectedWeaponQuality;
		[ObservableValue]
		private int _selectedUtility;
		[ObservableValue]
		private int _selectedUtilityQuality;
		[ObservableValue]
		private int _selectedArmor;
		[ObservableValue]
		private int _selectedArmorQuality;
		[ObservableValue]
		private int _selectedBagItemId;
		[ObservableValue]
		private int _selectedBagItemAmount;
		[ObservableValue]
		private int _wallSpriteId;
		[ObservableValue]
		private int _palaceSpriteId;
		[ObservableValue]
		private int _stonemasonSpriteId;
		[ObservableValue]
		private bool _breweryAvailable;
		[ObservableValue]
		private bool _isArabicLocalization;
		public CombatSimulatorForceHeroSelectedItemEffects selectedItemsEffects;
		private OwnVillage ownVillage;
	
		// Properties
		[ObservableValue]
		public OwnPlayer.TribeId tribeId { get => default; set {} }
		[ObservableValue]
		public TroopAmounts troopAmounts { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> catapultTargets { get => default; set {} }
		[ObservableValue]
		public CombatSimulatorHero hero { get => default; set {} }
		[ObservableValue]
		public Role role { get => default; set {} }
		[ObservableValue]
		public TroopInfo chief { get => default; set {} }
		[ObservableValue]
		public bool allLevelZero { get => default; set {} }
		[ObservableValue]
		public bool allAmountsZero { get => default; set {} }
		[ObservableValue]
		public int catapultId { get => default; set {} }
		[ObservableValue]
		public int selectedWeapon { get => default; set {} }
		[ObservableValue]
		public int selectedWeaponQuality { get => default; set {} }
		[ObservableValue]
		public int selectedUtility { get => default; set {} }
		[ObservableValue]
		public int selectedUtilityQuality { get => default; set {} }
		[ObservableValue]
		public int selectedArmor { get => default; set {} }
		[ObservableValue]
		public int selectedArmorQuality { get => default; set {} }
		[ObservableValue]
		public int selectedBagItemId { get => default; set {} }
		[ObservableValue]
		public int selectedBagItemAmount { get => default; set {} }
		[ObservableValue]
		public int wallSpriteId { get => default; set {} }
		[ObservableValue]
		public int palaceSpriteId { get => default; set {} }
		[ObservableValue]
		public int stonemasonSpriteId { get => default; set {} }
		[ObservableValue]
		public bool breweryAvailable { get => default; set {} }
		[ObservableValue]
		public bool isArabicLocalization { get => default; set {} }
	
		// Nested types
		public enum Role
		{
			Attacker = 1,
			Defender = 2,
			Reinforcement = 3
		}
	
		// Constructors
		public CombatSimulatorParticipant() {}
		public CombatSimulatorParticipant(Role role, OwnPlayer.TribeId tribeId, bool isPlayer) {}
	
		// Methods
		private void _catapultTargetsNotify(object sender, PropertyChangedEventArgs args) {}
		private void ChangeCatapultID() {}
		[UICallable]
		public bool FilterNatureForAttackers(OwnPlayer.TribeId tribeId) => default;
		public void SetupForOwnVillage(OwnVillage ownVillage) {}
		public void SetOwnHeroItems() {}
		private void SetSpriteIds() {}
		private static TroopAmounts GetTroopAmountsForVillage(OwnVillage ownVillage) => default;
		public CombatSimulatorForce Convert(AttackType type) => default;
		private CombatSimulatorForceHero GetCombatSimulatorForceHero() => default;
		[UICallable]
		public void SetTribe(OwnPlayer.TribeId tribe) {}
		public void SetRole(Role role) {}
		[UICallable]
		public void OpenTroopSelection(int preselectedUid = 0) {}
		[UICallable]
		public void SetupAndOpenAdjustHeroStats() {}
		public void SetTroops(TroopAmounts amounts, bool includeHero = false) {}
		private void HandleHeroStatusResponse(CombatSimulatorHero hero) {}
		private void DetermineBreweryAvailability() {}
	}
