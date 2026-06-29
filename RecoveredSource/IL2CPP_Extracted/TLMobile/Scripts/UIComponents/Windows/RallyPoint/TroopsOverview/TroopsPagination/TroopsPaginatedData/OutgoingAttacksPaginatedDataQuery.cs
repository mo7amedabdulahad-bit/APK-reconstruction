// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination.TroopsPaginatedData
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OutgoingAttacksPaginatedDataQuery : TroopsPaginatedDataQuery
	{
		// Fields
		private readonly MovingTroopsFilter outgoingTroopsFilter;
		private readonly MovingTroopsSortOrder sortingOrder;
	
		// Constructors
		public OutgoingAttacksPaginatedDataQuery() {} // Dummy constructor
		public OutgoingAttacksPaginatedDataQuery(int sorting) {}
	
		// Methods
		public override IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
	}
