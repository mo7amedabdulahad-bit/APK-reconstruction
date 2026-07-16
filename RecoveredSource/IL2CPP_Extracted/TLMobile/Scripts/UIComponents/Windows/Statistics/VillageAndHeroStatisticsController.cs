// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageAndHeroStatisticsController : DetailWindowTabController
	{
		// Fields
		public StatisticsHeroTabController heroTab;
		public StatisticsVillageTabController villageTab;
		[ObservableValue]
		private SubTab _currentSubTab;
		[ObservableValue]
		private Village _searchForVillage;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _searchForPlayer;
	
		// Properties
		[ObservableValue]
		public SubTab currentSubTab { get => default; set {} }
		[ObservableValue]
		public Village searchForVillage { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player searchForPlayer { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			Village = 1,
			Hero = 2
		}
	
		// Constructors
		public VillageAndHeroStatisticsController() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public void OpenPlayerSearch() {}
		[UICallable]
		public void NavigateToTop() {}
		[UICallable]
		public void NavigateToCurrentPlayer() {}
		[UICallable]
		public void SetSubTab(SubTab subTab) {}
	}
