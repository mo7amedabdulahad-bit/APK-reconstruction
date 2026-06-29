// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AddHeroItemEffectPopupController : DetailWindowController
	{
		// Fields
		private readonly List<int> invalidConsumableTypes;
		[ObservableValue]
		private ObservableList<InventoryItemAttributes> _selectedUtilityEffects;
		[ObservableValue]
		private ObservableList<InventoryItemAttributes> _selectedWeaponEffects;
		[ObservableValue]
		private ObservableList<InventoryItemAttributes> _selectedArmorEffects;
		[ObservableValue]
		private int _selectedConsumableType;
		[ObservableValue]
		private string _selectedConsumableDisplayName;
		[ObservableValue]
		private int _selectedConsumableAmount;
		[ObservableValue]
		private bool _canAddUtilityEffect;
		[ObservableValue]
		private bool _canAddWeaponEffect;
		[ObservableValue]
		private bool _canAddArmorEffect;
		[ObservableValue]
		private bool _canSaveData;
		private GraphQLFetchableList<HeroInventoryItem> heroInventory;
		private Generated.GraphQL.Game.CombatSimulator combatSimulatorGraphqlObject;
		private Dictionary<EffectType, List<InventoryItemAttributes>> utilityEffects;
		private Dictionary<EffectType, List<InventoryItemAttributes>> weaponEffects;
		private Dictionary<EffectType, List<InventoryItemAttributes>> armorEffects;
		private int differentUtilityEffectsCount;
		private int differentWeaponEffectsCount;
		private int differentArmorEffectsCount;
		private ObservableList<TLMobile.Generated.GraphQL.Game.Item> bagItems;
		private Dictionary<OwnPlayer.TribeId, Dictionary<int, List<InventoryItemAttributes>>> unitAttackDefenceEffects;
		private Dictionary<int, List<InventoryItemAttributes>> unitAttackDefenceEffectsMapByUnitUId;
		private ObservableList<DropdownOption> options;
		private ObservableList<DropdownOption> unitOptions;
		private Action<CombatSimulatorForceHeroSelectedItemEffects, int, int, CombatSimulatorParticipant> saveCallback;
		private bool canHaveMultipleTribes;
		private bool isInitialized;
	
		// Properties
		[ObservableValue]
		public ObservableList<InventoryItemAttributes> selectedUtilityEffects { get => default; set {} }
		[ObservableValue]
		public ObservableList<InventoryItemAttributes> selectedWeaponEffects { get => default; set {} }
		[ObservableValue]
		public ObservableList<InventoryItemAttributes> selectedArmorEffects { get => default; set {} }
		[ObservableValue]
		public int selectedConsumableType { get => default; set {} }
		[ObservableValue]
		public string selectedConsumableDisplayName { get => default; set {} }
		[ObservableValue]
		public int selectedConsumableAmount { get => default; set {} }
		[ObservableValue]
		public bool canAddUtilityEffect { get => default; set {} }
		[ObservableValue]
		public bool canAddWeaponEffect { get => default; set {} }
		[ObservableValue]
		public bool canAddArmorEffect { get => default; set {} }
		[ObservableValue]
		public bool canSaveData { get => default; set {} }
	
		// Nested types
		public class HeroItemEffectData
		{
			// Fields
			public CombatSimulatorForceHeroSelectedItemEffects SelectedItemsEffects;
			public int SelectedBagItemId;
			public int SelectedBagItemAmount;
	
			// Constructors
			public HeroItemEffectData() {}
		}
	
		public enum DropDownOptionType
		{
			Utility = 0,
			Weapon = 1,
			Armor = 2,
			Consumable = 3
		}
	
		// Constructors
		public AddHeroItemEffectPopupController() {}
	
		// Methods
		private void _selectedUtilityEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _selectedWeaponEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _selectedArmorEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(Action<CombatSimulatorForceHeroSelectedItemEffects, int, int, CombatSimulatorParticipant> saveHeroEffect, Generated.GraphQL.Game.CombatSimulator combatSimulator, CombatSimulatorParticipant selectedParticipant) {}
		private void InitialSetup(Generated.GraphQL.Game.CombatSimulator combatSimulator) {}
		private void ResetData() {}
		private void BuildUnitList(CombatSimulatorParticipant selectedParticipant) {}
		private void LoadSavedData(CombatSimulatorParticipant selectedParticipant) {}
		private InventoryItemAttributes GetAttributeFromSimulatorEffect(SimulatorItemEffect effect) => default;
		private void RefreshButtons() {}
		[UICallable]
		public void OpenMainDropdown(DropDownOptionType type, int entryIndex) {}
		private void OpenConsumablePopup() {}
		private void OnConsumableSelected(DropdownOption selectedOption) {}
		[UICallable]
		public void OpenUnitSelectionPopup(int entryIndex) {}
		private void OnUnitSelected(DropdownOption selected, int entryIndex) {}
		[UICallable]
		public void OpenMagnitudePopup(DropDownOptionType category, int entryIndex) {}
		private void OnMagnitudeSelected(DropdownOption selectedOption, ObservableList<InventoryItemAttributes> selectedList, int entryIndex, List<InventoryItemAttributes> effectList) {}
		private static void AddEffectDisplay(InventoryItemAttributes entry) {}
		private void OnEffectTypeSelected(DropdownOption selectedOption, int entryIndex, Dictionary<EffectType, List<InventoryItemAttributes>> availableTypes, ObservableList<InventoryItemAttributes> selectedList) {}
		[UICallable]
		public void ImportHeroEffects() {}
		public static Promise<HeroItemEffectData> GetHeroEffectFromEquipment() => default;
		[UICallable]
		public void SaveHeroEffects() {}
		private static List<SimulatorItemEffect> GetCombatSimulatorItemEffects(List<InventoryItemAttributes> effects) => default;
		[UICallable]
		public void AddNewEffect(DropDownOptionType type) {}
	}
