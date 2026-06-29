// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CatapultTargetsDropdown : InjectableViewModel
	{
		// Fields
		public const int RandomBuildingsIndex = 99;
		public const int NoneBuildingIndex = -1;
		private const string BuildingNameTranslationStringBase = "allgemein.gid";
		private const string RandomBuildingTranslateKey = "rallyPoint_sendTroops_catapultTarget_random";
		private const string NoneBuildingTranslateKey = "manual.keine";
		public SpriteCfg catapultTargetIconCfg;
		public ObservableList<DropdownOption> options;
		public ObservableList<DropdownOption> optionsSecondCatapult;
		public ObservableList<DropdownOption> recentOptions;
		[InjectableValue]
		[ObservableValue]
		private SelectedAmountWithSendInfo _waveInfos;
		[InjectableValue]
		[ObservableValue]
		private SendTroopInfo _sendInfos;
		[ObservableValue]
		private DropdownOption _selectedOption1;
		[ObservableValue]
		private DropdownOption _selectedOption2;
		private BootstrapData bootstrapData;
		private int rallyPointLevel;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public SelectedAmountWithSendInfo waveInfos { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public SendTroopInfo sendInfos { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption1 { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption2 { get => default; set {} }
	
		// Constructors
		public CatapultTargetsDropdown() {}
	
		// Methods
		public void OnEnable() {}
		public override void OnInjectedValueChanged() {}
		public void Init() {}
		private void CreateCatapultTargets() {}
		private void CreateNewOption(BootstrapBuilding.Category category) {}
		private void AddRecentTargets() {}
		private bool ShouldSkipBuilding(int buildingTypeId) => default;
		private DropdownOption SelectOptionWithValue(int value, List<DropdownOption> optionsToSearch) => default;
		public void SelectOption(DropdownOption option, int index) {}
		[UICallable]
		public void OpenDropdownList(int index) {}
	}
