// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.RegionsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RegionsOverviewPopupController : DetailWindowController
	{
		// Fields
		private const int NumberOfAlliancesShown = 5;
		private static readonly int ColorCount;
		private static readonly int ColorArray;
		private static readonly int HighlightedColorCount;
		private static readonly int HighlightedColorArray;
		[SerializeField]
		private ColorCfg regionsColorCfg;
		[SerializeField]
		private UnityEngine.UI.Image regionColorImage;
		[SerializeField]
		private CanvasPieChart pieChart;
		[SerializeField]
		private ColorCfg topAllianceColorCfg;
		[SerializeField]
		private Material pieChartMaterial;
		[SerializeField]
		private GameObject overviewTab;
		[SerializeField]
		private GameObject neighboursTab;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private GraphQLObservableList<TerritorialControl> _territorialControl;
		[ObservableValue]
		private Alliance _topAlliance;
		[ObservableValue]
		private bool _isRegionEmpty;
		[ObservableValue]
		private bool _hideAncientPower;
		[ObservableValue]
		private int _tabIndex;
		[ObservableValue]
		private int _selectedNeighbourRegionId;
		[ObservableValue]
		private int? _ownPlayerAllianceId;
		[ObservableValue]
		private float _regionPopulationProgress;
		[ObservableValue]
		private string _settleStatus;
		[ObservableValue]
		private RegionStatusDisplay _regionStatusType;
		[ObservableValue]
		private string _regionStatus;
		[ObservableValue]
		private AncientPowerStatusDisplay _ancientPowerStatusDescriptionType;
		[ObservableValue]
		private string _ancientPowerStatusDescription;
		[ObservableValue]
		private string _ancientPowerStatus;
		[ObservableValue]
		private string _regionPopulationStatus;
		[ObservableValue]
		private bool _isTerritory;
		[ObservableValue]
		private AncientPower _ancientPower;
		private bool hasNoValidAncientPower;
		private Material[] pieChartMaterialInstances;
		private Material regionMapMaterialInstance;
	
		// Properties
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TerritorialControl> territorialControl { get => default; set {} }
		[ObservableValue]
		public Alliance topAlliance { get => default; set {} }
		[ObservableValue]
		public bool isRegionEmpty { get => default; set {} }
		[ObservableValue]
		public bool hideAncientPower { get => default; set {} }
		[ObservableValue]
		public int tabIndex { get => default; set {} }
		[ObservableValue]
		public int selectedNeighbourRegionId { get => default; set {} }
		[ObservableValue]
		public int? ownPlayerAllianceId { get => default; set {} }
		[ObservableValue]
		public float regionPopulationProgress { get => default; set {} }
		[ObservableValue]
		public string settleStatus { get => default; set {} }
		[ObservableValue]
		public RegionStatusDisplay regionStatusType { get => default; set {} }
		[ObservableValue]
		public string regionStatus { get => default; set {} }
		[ObservableValue]
		public AncientPowerStatusDisplay ancientPowerStatusDescriptionType { get => default; set {} }
		[ObservableValue]
		public string ancientPowerStatusDescription { get => default; set {} }
		[ObservableValue]
		public string ancientPowerStatus { get => default; set {} }
		[ObservableValue]
		public string regionPopulationStatus { get => default; set {} }
		[ObservableValue]
		public bool isTerritory { get => default; set {} }
		[ObservableValue]
		public AncientPower ancientPower { get => default; set {} }
	
		// Nested types
		public enum AncientPowerStatusDisplay
		{
			SimpleKey = 0,
			Capturing_Own = 1,
			Capturing_Own_NoPower = 2,
			Capturing_Other = 3,
			Capturing_Other_NoPower = 4,
			Secured_Other = 5,
			Secured_Other_NoPower = 6,
			Secured_Own = 7
		}
	
		public enum RegionStatusDisplay
		{
			SimpleKey = 0,
			Capturing = 1,
			Secured = 2
		}
	
		// Constructors
		public RegionsOverviewPopupController() {}
		static RegionsOverviewPopupController() {}
	
		// Methods
		private void _territorialControlNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Set(int regionId) {}
		[UICallable]
		public void SwitchTab(int index) {}
		[UICallable]
		public void SelectNeighbour(int regionId) {}
		private void SetupNeighboursOverviewTab() {}
		private void SetupRegionOverviewTab() {}
		private void SetPieChart() {}
		private void ShowRegions(List<int> regionIDs) {}
		private void HighlightRegions(List<int> regionIDs) {}
	}
