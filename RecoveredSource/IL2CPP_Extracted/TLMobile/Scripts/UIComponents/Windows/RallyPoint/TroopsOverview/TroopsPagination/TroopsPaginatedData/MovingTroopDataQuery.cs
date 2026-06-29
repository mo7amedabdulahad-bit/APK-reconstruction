// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination.TroopsPaginatedData
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovingTroopDataQuery : TroopsPaginatedDataQuery
	{
		// Fields
		private readonly MovingTroopsFilter currentFilter;
		private readonly MovingTroopsSortOrder currentSorting;
	
		// Constructors
		public MovingTroopDataQuery() {} // Dummy constructor
		public MovingTroopDataQuery(int[] filters, int sorting) {}
	
		// Methods
		public override IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
	}
