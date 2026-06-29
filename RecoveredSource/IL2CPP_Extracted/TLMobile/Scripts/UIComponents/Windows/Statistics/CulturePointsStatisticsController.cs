// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CulturePointsStatisticsController : BaseStatisticsController
	{
		// Fields
		private const string CategoryName = "progression";
		private const int MaxDaysToShow = 2147483647;
		public GraphChart graphChart;
		public PieChart pieChart;
		public IntMaterialDictionary materials;
		[ObservableValue]
		private CulturePointsView _activeView;
		[ObservableValue]
		private StatisticsTimeFrame _activeTimeFrame;
		[ObservableValue]
		private int _rank;
		[ObservableValue]
		private int _rankAlliance;
		[ObservableValue]
		private int _cpProduction;
		[ObservableValue]
		private int _betterValue;
		[ObservableValue]
		private int _worseValue;
		[ObservableValue]
		private int _buildingsValue;
		[ObservableValue]
		private int _itemsValue;
		[ObservableValue]
		private int _allianceValue;
		[ObservableValue]
		private ObservableList<int> _percentageValues;
		[ObservableValue]
		private ObservableList<int> _materialIndices;
		[ObservableValue]
		private CulturePointsRank _culturePointsRank;
	
		// Properties
		[ObservableValue]
		public CulturePointsView activeView { get => default; set {} }
		[ObservableValue]
		public StatisticsTimeFrame activeTimeFrame { get => default; set {} }
		[ObservableValue]
		public int rank { get => default; set {} }
		[ObservableValue]
		public int rankAlliance { get => default; set {} }
		[ObservableValue]
		public int cpProduction { get => default; set {} }
		[ObservableValue]
		public int betterValue { get => default; set {} }
		[ObservableValue]
		public int worseValue { get => default; set {} }
		[ObservableValue]
		public int buildingsValue { get => default; set {} }
		[ObservableValue]
		public int itemsValue { get => default; set {} }
		[ObservableValue]
		public int allianceValue { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> percentageValues { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> materialIndices { get => default; set {} }
		[ObservableValue]
		public CulturePointsRank culturePointsRank { get => default; set {} }
	
		// Constructors
		public CulturePointsStatisticsController() {}
	
		// Methods
		private void _percentageValuesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _materialIndicesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Setup() {}
		private void ContinueSetup() {}
		private void SetupRankValues() {}
		private void SetupChart() {}
		private void InsertTotalRankIntoPieChart(TotalRank totalRank) {}
		private void CreateValueList(CulturePointsDistributionPerDay data) {}
		private void CreateValueList(CulturePointsDistributionSoFar data) {}
		private void SetupPieChartData(List<int> list) {}
		private void SetupGraphChartData(List<CulturePointsProgressionData> list) {}
		private void InsertRankData(TotalRank totalRank) {}
		private void InsertDataIntoPieChart(string name, int materialIndex, int value) {}
		private int CalculatePercentage(float value, float divider) => default;
		[UICallable]
		public void ChangeView(CulturePointsView view) {}
		[UICallable]
		public void ChangeTimeFrame(StatisticsTimeFrame timeFrame) {}
	}
