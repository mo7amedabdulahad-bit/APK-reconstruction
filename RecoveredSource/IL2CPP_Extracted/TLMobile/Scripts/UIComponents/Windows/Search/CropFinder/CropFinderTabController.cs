// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search.CropFinder
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CropFinderTabController : DetailWindowTabControllerWithPagination<Cropland>
	{
		// Fields
		public DetailWindowController detailWindowController;
		[ObservableValue]
		private CroplandBonus? _croplandBonus;
		[ObservableValue]
		private int _croplandBonusInt;
		[ObservableValue]
		private CroplandType? _croplandType;
		[ObservableValue]
		private bool _onlyShowUnoccupied;
		[ObservableValue]
		private Cropland _selectedCropland;
		[ObservableValue]
		private GreyZoneFilter? _greyZoneFilter;
		[ObservableValue]
		private bool _greyZoneFilterEnabled;
		[ObservableValue]
		private MapQuadrant? _mapQuadrant;
		[ObservableValue]
		private Village _targetVillage;
		[ObservableValue]
		private bool _crop18Enabled;
		[ObservableValue]
		private string _villageFetchServerError;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private DropdownOption _selectedOption;
		[ObservableValue]
		private bool _expandOptions;
		private ObservableList<DropdownOption> options;
		private Village expectedVillage;
	
		// Properties
		[ObservableValue]
		public CroplandBonus? croplandBonus { get => default; set {} }
		[ObservableValue]
		public int croplandBonusInt { get => default; set {} }
		[ObservableValue]
		public CroplandType? croplandType { get => default; set {} }
		[ObservableValue]
		public bool onlyShowUnoccupied { get => default; set {} }
		[ObservableValue]
		public Cropland selectedCropland { get => default; set {} }
		[ObservableValue]
		public GreyZoneFilter? greyZoneFilter { get => default; set {} }
		[ObservableValue]
		public bool greyZoneFilterEnabled { get => default; set {} }
		[ObservableValue]
		public MapQuadrant? mapQuadrant { get => default; set {} }
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
		[ObservableValue]
		public bool crop18Enabled { get => default; set {} }
		[ObservableValue]
		public string villageFetchServerError { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption { get => default; set {} }
		[ObservableValue]
		public bool expandOptions { get => default; set {} }
	
		// Constructors
		public CropFinderTabController() {}
	
		// Methods
		public void Start() {}
		protected override void OnEnable() {}
		private void Init() {}
		private void UpdateCropLandBonus(DropdownOption option) {}
		private void SearchInputChanged() {}
		[IteratorStateMachine(typeof(_FireSearchAfterDelay_d__68))]
		private IEnumerator FireSearchAfterDelay() => default;
		private void DoBackendSearch() {}
		public void RequestVillageInfo() {}
		private void VillageFetchErrorHandler(GraphQLServerError obj) {}
		private void VillageInfoReceived(ServerObject villageObject) {}
		private void AfterInput() {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void OpenVillageSelection() {}
		[UICallable]
		public void SetCropFinderOption(CroplandType croplandType) {}
		[UICallable]
		public void SetCropFinderOptionGreyZone(GreyZoneFilter greyZoneFilter) {}
		[UICallable]
		public void SetCropFinderOptionMapQuadrant(MapQuadrant mapQuadrant) {}
		[UICallable]
		public void SetCropFinderOptionMapQuadrantAll() {}
		[UICallable]
		public void SetCropFinderOptionAll() {}
		[UICallable]
		public void ToggleShowOnlyUnoccupied() {}
		[UICallable]
		public void SelectCropland(Cropland cropland) {}
		[UICallable]
		public void ToggleExpandOptions() {}
		private void OpenMapView(int x, int y) {}
	}
