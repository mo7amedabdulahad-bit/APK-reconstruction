// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GeneralStatisticsTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private StatisticView _currentView;
	
		// Properties
		[ObservableValue]
		public StatisticView currentView { get => default; set {} }
	
		// Nested types
		public enum StatisticView
		{
			None = 0,
			ServerProgression = 1,
			PopulationRank = 2,
			ResourcesRank = 3,
			MilitaryStrength = 4,
			CulturePoints = 5
		}
	
		// Constructors
		public GeneralStatisticsTabController() {}
	
		// Methods
		private void Start() {}
		[UICallable]
		public void ToggleView(StatisticView view) {}
	}
