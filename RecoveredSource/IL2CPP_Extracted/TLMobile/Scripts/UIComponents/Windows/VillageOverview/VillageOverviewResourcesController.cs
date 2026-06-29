// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewResourcesController : VillageOverviewTabController
	{
		// Fields
		public ObservableList<DropdownOption> sortDropdownOptions;
		[ObservableValue]
		private ResourceAmounts _resourceSum;
		[ObservableValue]
		private ResourceAmounts _productionSum;
		[ObservableValue]
		private DropdownOption _selectedOption;
		private CancellationTokenSource updateAllVillagesCts;
	
		// Properties
		[ObservableValue]
		public ResourceAmounts resourceSum { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts productionSum { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption { get => default; set {} }
	
		// Nested types
		public enum SortBy
		{
			None = 0,
			VillageList = 1,
			GranaryLowest = 2,
			GranaryHighest = 3,
			WarehouseLowest = 4,
			WarehouseHighest = 5,
			NegativeProduction = 6
		}
	
		// Constructors
		public VillageOverviewResourcesController() {}
	
		// Methods
		protected void Start() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override void GatherVillageInformation(bool forceFetch) {}
		public void Setup() {}
		private int SortByVillageList(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private int SortByGranaryLowest(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private int SortByGranaryHighest(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private int SortByWarehouseLowest(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private int SortByWarehouseHighest(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private int SortByNegativeProduction(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		private void SortingChanged() {}
		private async UniTaskVoid UpdateAllVillageResources() => default;
		private void UpdateResourceAndProductionSum() {}
		[UICallable]
		public void OpenDropdown() {}
	}
