// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceRankStatisticsController : BaseStatisticsController
	{
		// Fields
		public PieChart pieChart;
		public IntMaterialDictionary materials;
		[ObservableValue]
		private ResourceRankView _activeView;
		[ObservableValue]
		private StatisticsTimeFrame _activeTimeFrame;
		[ObservableValue]
		private int _rank;
		[ObservableValue]
		private int _rankAlliance;
		[ObservableValue]
		private int _production;
		[ObservableValue]
		private int _betterValue;
		[ObservableValue]
		private int _worseValue;
		[ObservableValue]
		private ObservableList<int> _percentageValues;
		[ObservableValue]
		private ObservableList<int> _materialIndices;
		[ObservableValue]
		private ResourcesProduction _resourcesProduction;
		private ResourcesRank resourceRank;
	
		// Properties
		[ObservableValue]
		public ResourceRankView activeView { get => default; set {} }
		[ObservableValue]
		public StatisticsTimeFrame activeTimeFrame { get => default; set {} }
		[ObservableValue]
		public int rank { get => default; set {} }
		[ObservableValue]
		public int rankAlliance { get => default; set {} }
		[ObservableValue]
		public int production { get => default; set {} }
		[ObservableValue]
		public int betterValue { get => default; set {} }
		[ObservableValue]
		public int worseValue { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> percentageValues { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> materialIndices { get => default; set {} }
		[ObservableValue]
		public ResourcesProduction resourcesProduction { get => default; set {} }
	
		// Constructors
		public ResourceRankStatisticsController() {}
	
		// Methods
		private void _percentageValuesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _materialIndicesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Setup() {}
		private void ContinueSetup() {}
		private void SetupRankValues() {}
		private void SetupChart() {}
		private void InsertTwoIntegerIntoPieChart(int better, int worse) {}
		private void CreateValueList(ResourcesProduction data, int totalProduction) {}
		private void SetupPieChartData(List<int> list) {}
		private void InsertRankData(TotalRank totalRank) {}
		private void InsertDataIntoPieChart(string name, int materialIndex, int value) {}
		private int CalculatePercentage(float value, float divider) => default;
		[UICallable]
		public void ChangeView(ResourceRankView view) {}
		[UICallable]
		public void ChangeTimeFrame(StatisticsTimeFrame timeFrame) {}
	}
