	public class StatisticsVillageTabController : DetailWindowTabControllerWithPagination<RankedVillage>
	{
		// Properties
		protected override bool AllowBackwardLoading { get => default; }
	
		// Constructors
		public StatisticsVillageTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void SearchForVillage(Village v) {}
		public void NavigateToTop() {}
		public void NavigateToCurrentPlayer(OwnVillage village) {}
	}
