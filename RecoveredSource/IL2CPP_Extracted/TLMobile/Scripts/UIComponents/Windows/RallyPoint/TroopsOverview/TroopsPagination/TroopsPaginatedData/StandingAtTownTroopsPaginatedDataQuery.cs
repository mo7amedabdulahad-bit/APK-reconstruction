// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination.TroopsPaginatedData
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StandingAtTownTroopsPaginatedDataQuery : TroopsPaginatedDataQuery
	{
		// Fields
		private readonly StandingAtTownTroopsFilter standingAtTownTroopsFilter;
	
		// Constructors
		public StandingAtTownTroopsPaginatedDataQuery() {} // Dummy constructor
		public StandingAtTownTroopsPaginatedDataQuery(GraphQLObservableList<StandingAtTownTroopsType> filterTypes) {}
	
		// Methods
		public override IPaginatedObject<RallyPointTroopsOverviewDetailsItem> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
	}
