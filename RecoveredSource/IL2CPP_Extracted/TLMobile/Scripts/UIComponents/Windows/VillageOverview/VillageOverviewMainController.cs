// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewMainController : DetailWindowController
	{
		// Fields
		public UnityEvent OnVillageListChanged;
		[ObservableValue]
		private ObservableList<OwnVillageWithOverviewInfos> _ownVillages;
		public GraphQLFetchableList<OwnVillage> villagesFromBackend;
	
		// Properties
		[ObservableValue]
		public ObservableList<OwnVillageWithOverviewInfos> ownVillages { get => default; set {} }
	
		// Constructors
		public VillageOverviewMainController() {}
	
		// Methods
		private void _ownVillagesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void SyncVillageList() {}
		public void SortVillageList(Comparison<OwnVillageWithOverviewInfos> compare) {}
		[UICallable]
		public void ToggleExpandedState(OwnVillageWithOverviewInfos vill) {}
		[UICallable]
		public int DefaultVillageSorting(OwnVillageWithOverviewInfos a, OwnVillageWithOverviewInfos b) => default;
		[UICallable]
		public void OpenMarketplace(OwnVillageWithOverviewInfos vill) {}
		[UICallable]
		public void OpenTownHall(OwnVillageWithOverviewInfos vill) {}
		[UICallable]
		public void OpenSmithy(OwnVillageWithOverviewInfos vill) {}
		[UICallable]
		public void OpenHospital(OwnVillageWithOverviewInfos vill) {}
		[UICallable]
		public void SwitchVillageAndOpenBuilding(int villageId, Building.TypeId type, int switchToTab = -1) {}
	}
