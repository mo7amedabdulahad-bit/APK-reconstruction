// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination.TroopsPaginatedData
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class TroopsPaginatedDataQuery : IPaginatedDataQuery<RallyPointTroopsOverviewDetailsItem>
	{
		// Constructors
		protected TroopsPaginatedDataQuery() {}
	
		// Methods
		public abstract IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPage(string cursor, int amount, bool forceRefresh);
		public IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPageForResult(ServerObject obj) => default;
	}
