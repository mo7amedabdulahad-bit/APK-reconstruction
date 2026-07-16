// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PopulationStatisticsController : BaseStatisticsController
	{
		// Fields
		private const string CategoryName = "population";
		private const int MaxDaysToShow = 2147483647;
		public GraphChart graphChart;
		[ObservableValue]
		private PopulationRank _populationRank;
	
		// Properties
		[ObservableValue]
		public PopulationRank populationRank { get => default; set {} }
	
		// Constructors
		public PopulationStatisticsController() {}
	
		// Methods
		protected override void Setup() {}
		private void SetupGraph() {}
	}
