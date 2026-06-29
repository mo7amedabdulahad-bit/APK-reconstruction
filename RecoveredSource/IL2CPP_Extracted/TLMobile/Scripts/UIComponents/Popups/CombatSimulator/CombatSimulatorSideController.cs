// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorSideController : TLMViewModel
	{
		// Fields
		[SerializeField]
		private SpriteByStringCfg itemIcons;
		[ObservableValue]
		private CombatSimulatorSide _simulatorSide;
		[ObservableValue]
		private OwnVillage _selectedVillage;
		[ObservableValue]
		private bool _hasSelectedItemEffects;
		[ObservableValue]
		private Generated.GraphQL.Game.CombatSimulator _combatSimulatorGraphqlObject;
		private GraphQLFetchableList<HeroInventoryItem> inventory;
		private HeroItemCategory lastSelectedCategory;
		private DefaultInventoryItem[] lastSelectedData;
		private int lastSelectedParticipant;
		private CombatSimulatorParticipant.Role yourRole;
	
		// Properties
		[ObservableValue]
		public CombatSimulatorSide simulatorSide { get => default; set {} }
		[ObservableValue]
		public OwnVillage selectedVillage { get => default; set {} }
		[ObservableValue]
		public bool hasSelectedItemEffects { get => default; set {} }
		[ObservableValue]
		public Generated.GraphQL.Game.CombatSimulator combatSimulatorGraphqlObject { get => default; set {} }
	
		// Constructors
		public CombatSimulatorSideController() {}
	
		// Methods
		public void Setup(CombatSimulatorParticipant.Role playerRole, CombatSimulatorParticipant.Role role) {}
		public void SetRole(CombatSimulatorParticipant.Role role, CombatSimulatorParticipant.Role playerRole) {}
		private DropdownListController SetupInventoryPopupController(DefaultInventoryItem[] data, string title) => default;
		[UICallable]
		public void SetupAndOpenEagleEyeSelection() {}
		[UICallable]
		public void SetupAndOpenArchitectSecretSelection() {}
		private void UpdateEaglesEyes(DropdownOption selectedOption) {}
		private void UpdateArchitectSecret(DropdownOption selectedOption) {}
		[UICallable]
		public void SetupAndOpenMetallurgyBonusSelection() {}
		private void UpdateMetallurgyBonus(DropdownOption selectedOption) {}
		[UICallable]
		public void SetupAndOpenVillageSelection() {}
		private void UpdateVillage(DropdownOption selectedOption) {}
		[UICallable]
		public void SetupAndOpenItemSelection(HeroItemCategory category, int participant) {}
		private void PreselectInventoryItemOption(int id, DropdownListController controller) {}
		[UICallable]
		public void SetupAndOpenBuildingLevelSelection(Building.TypeId buildingType) {}
		private void UpdateItem(DropdownOption selectedOption) {}
		private void UpdateBag(int id, int value) {}
		private void ClampValues() {}
		public OwnPlayer.TribeId GetTribeId(int index = 0) => default;
		public CombatSimulatorParticipant GetParticipant(int index = 0) => default;
		public void SetParticipant(CombatSimulatorParticipant simulatorParticipant, int index = 0) {}
		[UICallable]
		public void SetupForOwnVillage(OwnVillage village = null) {}
		public void SetupVillageLevels(OwnVillage village) {}
		public void ResetVillageLevels() {}
		public OwnVillage GetLastSelectedVillage() => default;
		[UICallable]
		public void ToggleCelebration() {}
		[UICallable]
		public void ResetEverything(CombatSimulatorParticipant participant) {}
		[UICallable]
		public void RemoveParticipant(CombatSimulatorParticipant participant) {}
		[UICallable]
		public void OpenItemEffectPopup(int participant) {}
		private void ApplyItemEffects(CombatSimulatorForceHeroSelectedItemEffects selectedItemsEffects, int selectedBagItemId, int selectedBagItemCount, CombatSimulatorParticipant selected = null) {}
	}
