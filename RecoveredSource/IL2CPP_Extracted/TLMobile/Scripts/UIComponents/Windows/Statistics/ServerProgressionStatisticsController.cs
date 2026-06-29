// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerProgressionStatisticsController : BaseStatisticsController
	{
		// Fields
		public PieChart pieChart;
		public IntMaterialDictionary tribeColors;
		[ObservableValue]
		private GameWorldProgress _statisticsData;
	
		// Properties
		[ObservableValue]
		public GameWorldProgress statisticsData { get => default; set {} }
	
		// Constructors
		public ServerProgressionStatisticsController() {}
	
		// Methods
		protected override void Setup() {}
		private void SetupPieChart() {}
		[UICallable]
		public int SortTribeDistribution(TribeDistribution a, TribeDistribution b) => default;
	}
