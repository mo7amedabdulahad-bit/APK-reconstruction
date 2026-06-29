// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.BuildingActivities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingActivitiesController : DetailWindowController
	{
		// Fields
		public RectTransform CloseButton;
		public bool newVillage;
		private readonly Building.TypeId[] AllwaysDisplayBuildings;
		private readonly Building.TypeId[] BuildingsDisplayOrder;
		[ObservableValue]
		private ObservableList<BuildingActivity> _activities;
		[ObservableValue]
		private ObservableList<Building.TypeId> _nonBuildBuildingsToAlwaysDisplay;
		[ObservableValue]
		private int _timestampIn10Minutes;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public ObservableList<BuildingActivity> activities { get => default; set {} }
		[ObservableValue]
		public ObservableList<Building.TypeId> nonBuildBuildingsToAlwaysDisplay { get => default; set {} }
		[ObservableValue]
		public int timestampIn10Minutes { get => default; set {} }
	
		// Constructors
		public BuildingActivitiesController() {}
	
		// Methods
		private void _activitiesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _nonBuildBuildingsToAlwaysDisplayNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public void Init() {}
		private void AddPossibleTrainings(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleWIPstatus(BuildingActivity activity) {}
		private void AddPossibleRallyPointInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleAcademyInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleSmithyInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleTownhallInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleMarketInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleHospitalInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleTrapperInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		private void AddPossibleHarbourInfo(OwnVillage currentVillage, BuildingActivity activity) {}
		[UICallable]
		public void OpenBuilding(Building building) {}
	}
