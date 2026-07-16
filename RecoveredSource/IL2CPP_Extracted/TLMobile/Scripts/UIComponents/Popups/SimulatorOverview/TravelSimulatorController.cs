// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.SimulatorOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TravelSimulatorController : DetailWindowController
	{
		// Fields
		private const int HeroAbilityBonusGauls = 5;
		private const int HeroAbilityBonusHuns = 3;
		private const string TranslationKeyArtefactBonus = "production.crobBalanceTroopConsumptionArtefact";
		private const string TranslationKeyHeroBoots = "gid16.ds_heroBoots";
		private const string TranslationKeyHeroHorse = "gid16.ds_heroHorse";
		private const string TranslationKeyHeroItem = "gid16.ds_heroItem";
		private const string TranslationKeyHeroSelectMagnitude = "addItemEffect_selectMagnitude";
		private const string TranslationKeyHeroAbilityGaulBonus = "gid16.ds_heroAbility_gaulBonus";
		private const string TranslationKeyHeroAbilityHunBonus = "gid16.ds_heroAbility_hunBonus";
		private const string TranslationKeyNone = "gid16.ds_none";
		private const string TranslationKeySlowestUnitSettings = "travelSimulator_slowestUnit_settings";
		private const string TranslationKeyToastSelectSourceAndTarget = "travelSimulator_toast_selectSourceAndTarget";
		private const string TranslationKeyToastSelectSourceTribe = "travelSimulator_toast_selectSourceTribe";
		private const string TranslationKeyTournamentSquareLevel = "travelSimulator_tournamentSquareLevel_title";
		private const string TranslationKeyTournamentSquareLevelOption = "travelSimulator_tournamentSquareLevel_option";
		[ObservableValue]
		private bool _canCalculate;
		[ObservableValue]
		private bool _hasAncientPowerActive;
		[ObservableValue]
		private bool _hasHarbourActive;
		[ObservableValue]
		private bool _hasHarbourShipsActive;
		[ObservableValue]
		private bool _hasHarbourVikingRaidActive;
		[ObservableValue]
		private bool _hasHeroAbilitySelected;
		[ObservableValue]
		private bool _hasValidTribeSelected;
		[ObservableValue]
		private bool _hasValidHeroBootsItemEffect;
		[ObservableValue]
		private bool _hasValidHeroUtilityItemEffect;
		[ObservableValue]
		private bool _isHeroAbilityAvailable;
		[ObservableValue]
		private bool _isHeroAbilityFulfilled;
		[ObservableValue]
		private bool _isHeroAttending;
		[ObservableValue]
		private int? _sourceCoordinatesX;
		[ObservableValue]
		private int? _sourceCoordinatesY;
		[ObservableValue]
		private int? _targetCoordinatesX;
		[ObservableValue]
		private int? _targetCoordinatesY;
		[ObservableValue]
		private ObservableList<OwnPlayer.TribeId> _possibleTribes;
		[ObservableValue]
		private ObservableList<TravelSimulatorItemEffect> _heroBootsItemEffects;
		[ObservableValue]
		private ObservableList<TravelSimulatorItemEffect> _heroUtilityItemEffects;
		[ObservableValue]
		private OwnPlayer.TribeId? _selectedTribe;
		[ObservableValue]
		private SelectedTroopInfo _selectedTroopInfo;
		[ObservableValue]
		private string _artefactBonusText;
		[ObservableValue]
		private string _calculationDistanceLand;
		[ObservableValue]
		private string _calculationDistanceSea;
		[ObservableValue]
		private string _calculationTime;
		[ObservableValue]
		private string _heroAbilityText;
		[ObservableValue]
		private string _heroBootsText;
		[ObservableValue]
		private string _heroHorseText;
		[ObservableValue]
		private string _heroUtilityText;
		[ObservableValue]
		private string _selectedTroopText;
		[ObservableValue]
		private string _tournamentSquareLevelText;
		[ObservableValue]
		private Village _sourceVillage;
		[ObservableValue]
		private Village _targetVillage;
		private bool hasAllianceUnionEnabled;
		private bool hasVillageUpdateBlocker;
		private BootstrapBuildingLevel bootstrapBuildingLevel;
		private BootstrapData bootstrapData;
		private TravelSimulator travelSimulator;
		private Dictionary<HeroItemCategory, Dictionary<EffectType, List<float>>> availableEffects;
		private IArtefactService artefactService;
		private int lastRequestHashcode;
		private TextFilterPercent textFilterPercent;
		private TravelInfoRequestBody.HeroAbilityEnum? usedHeroAbility;
		private TravelSimulatorItem artefactItem;
		private TravelSimulatorItem heroBootsItem;
		private TravelSimulatorItem heroHorseItem;
		private TravelSimulatorItem heroUtilityItem;
	
		// Properties
		[ObservableValue]
		public bool canCalculate { get => default; set {} }
		[ObservableValue]
		public bool hasAncientPowerActive { get => default; set {} }
		[ObservableValue]
		public bool hasHarbourActive { get => default; set {} }
		[ObservableValue]
		public bool hasHarbourShipsActive { get => default; set {} }
		[ObservableValue]
		public bool hasHarbourVikingRaidActive { get => default; set {} }
		[ObservableValue]
		public bool hasHeroAbilitySelected { get => default; set {} }
		[ObservableValue]
		public bool hasValidTribeSelected { get => default; set {} }
		[ObservableValue]
		public bool hasValidHeroBootsItemEffect { get => default; set {} }
		[ObservableValue]
		public bool hasValidHeroUtilityItemEffect { get => default; set {} }
		[ObservableValue]
		public bool isHeroAbilityAvailable { get => default; set {} }
		[ObservableValue]
		public bool isHeroAbilityFulfilled { get => default; set {} }
		[ObservableValue]
		public bool isHeroAttending { get => default; set {} }
		[ObservableValue]
		public int? sourceCoordinatesX { get => default; set {} }
		[ObservableValue]
		public int? sourceCoordinatesY { get => default; set {} }
		[ObservableValue]
		public int? targetCoordinatesX { get => default; set {} }
		[ObservableValue]
		public int? targetCoordinatesY { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnPlayer.TribeId> possibleTribes { get => default; set {} }
		[ObservableValue]
		public ObservableList<TravelSimulatorItemEffect> heroBootsItemEffects { get => default; set {} }
		[ObservableValue]
		public ObservableList<TravelSimulatorItemEffect> heroUtilityItemEffects { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId? selectedTribe { get => default; set {} }
		[ObservableValue]
		public SelectedTroopInfo selectedTroopInfo { get => default; set {} }
		[ObservableValue]
		public string artefactBonusText { get => default; set {} }
		[ObservableValue]
		public string calculationDistanceLand { get => default; set {} }
		[ObservableValue]
		public string calculationDistanceSea { get => default; set {} }
		[ObservableValue]
		public string calculationTime { get => default; set {} }
		[ObservableValue]
		public string heroAbilityText { get => default; set {} }
		[ObservableValue]
		public string heroBootsText { get => default; set {} }
		[ObservableValue]
		public string heroHorseText { get => default; set {} }
		[ObservableValue]
		public string heroUtilityText { get => default; set {} }
		[ObservableValue]
		public string selectedTroopText { get => default; set {} }
		[ObservableValue]
		public string tournamentSquareLevelText { get => default; set {} }
		[ObservableValue]
		public Village sourceVillage { get => default; set {} }
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
	
		// Constructors
		public TravelSimulatorController() {}
	
		// Methods
		private void _possibleTribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _heroBootsItemEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _heroUtilityItemEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(MapCell mapCell) {}
		[UICallable]
		public void OnAddItemSlotClicked(HeroItemCategory value) {}
		[UICallable]
		public void OnArtefactBonusClicked() {}
		[UICallable]
		public void OnCalculateClicked() {}
		[UICallable]
		public void OnCoordinateSwitchClicked() {}
		[UICallable]
		public void OnHarbourShipsSwitchClicked() {}
		[UICallable]
		public void OnHarbourVikingRaidSwitchClicked() {}
		[UICallable]
		public void OnHeroAbilityToggleClicked() {}
		[UICallable]
		public void OnHeroAttendingToggleClicked() {}
		[UICallable]
		public void OnHeroBootsClicked(TravelSimulatorItemEffect value) {}
		[UICallable]
		public void OnHeroBootsMagnitudeClicked(TravelSimulatorItemEffect value) {}
		[UICallable]
		public void OnHeroHorseClicked() {}
		[UICallable]
		public void OnHeroUtilityClicked(TravelSimulatorItemEffect value) {}
		[UICallable]
		public void OnHeroUtilityMagnitudeClicked(TravelSimulatorItemEffect value) {}
		[UICallable]
		public void OnSelectSlowestUnitClicked() {}
		[UICallable]
		public void OnSourceTribeSelected(OwnPlayer.TribeId tribeId) {}
		[UICallable]
		public void OnTournamentSquareLevelClicked() {}
		[UICallable]
		public void OpenVillageSelection(bool isSource) {}
		protected override void OnEnable() {}
		private Dictionary<EffectType, List<float>> GetAvailableItemEffects(HeroItemCategory heroItemCategory) => default;
		private int GetAbilityBonus(int baseSpeed) => default;
		private string GetTournamentSquareLevelText(BootstrapBuildingLevel value) => default;
		private string GetItemText(TravelSimulatorItem value, bool boldName = true, bool useDescriptionAlt = false) => default;
		private void OnCoordinatesChanged() {}
		private void SetAvailableItemEffects(HeroItemCategory heroItemCategory, Dictionary<EffectType, List<float>> value) {}
		private void OnHarbourShipsActiveChanged() {}
		private void SelectSlowestTroopForTribe() {}
		private void Refresh() {}
	}
