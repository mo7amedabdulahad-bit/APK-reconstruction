// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StatisticsVictoryPointsTabController : DetailWindowTabControllerWithPagination<VictoryPointsRank>
	{
		// Fields
		[SerializeField]
		private StatisticsAllianceVPSubTabController allianceVPSubTabController;
		[SerializeField]
		private StatisticsRegionVPSubTabController regionVPSubTabController;
		[SerializeField]
		private StatisticsWonderOfTheWorldTabController wonderOfTheWorldTabController;
		[ObservableValue]
		private eActiveTab _currentSubTab;
		[ObservableValue]
		private AllianceStatistics _top10;
		[ObservableValue]
		private Alliance _searchForAlliance;
		[ObservableValue]
		private Region _searchForRegion;
		[ObservableValue]
		private bool _isTerritory;
		[ObservableValue]
		private bool _isEuropeMap;
	
		// Properties
		[ObservableValue]
		public eActiveTab currentSubTab { get => default; set {} }
		[ObservableValue]
		public AllianceStatistics top10 { get => default; set {} }
		[ObservableValue]
		public Alliance searchForAlliance { get => default; set {} }
		[ObservableValue]
		public Region searchForRegion { get => default; set {} }
		[ObservableValue]
		public bool isTerritory { get => default; set {} }
		[ObservableValue]
		public bool isEuropeMap { get => default; set {} }
	
		// Nested types
		public enum eActiveTab
		{
			AllianceVP = 0,
			WonderOfTheWorld = 1,
			Regions = 2
		}
	
		// Constructors
		public StatisticsVictoryPointsTabController() {}
	
		// Methods
		protected override void Awake() {}
		public void Init() {}
		[UICallable]
		public void SetSubTab(eActiveTab subTab) {}
	}
