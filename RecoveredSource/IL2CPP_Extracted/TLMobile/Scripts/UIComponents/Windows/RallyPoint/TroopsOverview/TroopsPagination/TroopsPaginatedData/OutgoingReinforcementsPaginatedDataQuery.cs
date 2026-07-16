// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination.TroopsPaginatedData
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OutgoingReinforcementsPaginatedDataQuery : TroopsPaginatedDataQuery
	{
		// Fields
		private readonly MovingTroopsFilter movingTroopsFilter;
		private readonly MovingTroopsSortOrder sortingOrder;
	
		// Constructors
		public OutgoingReinforcementsPaginatedDataQuery() {} // Dummy constructor
		public OutgoingReinforcementsPaginatedDataQuery(int sorting) {}
	
		// Methods
		public override IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
	}
