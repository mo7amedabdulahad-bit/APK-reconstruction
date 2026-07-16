// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedRegionPaginationQuery : IPaginatedDataQuery<RankedRegion>
	{
		// Fields
		private string askForName;
		private bool overrideForceFetch;
		private RegionSortBy sorting;
		private SortOrder sortOrder;
		private int? startFromRank;
	
		// Nested types
		public enum Ranking
		{
			VictoryPoints = 1
		}
	
		// Constructors
		public RankedRegionPaginationQuery() {} // Dummy constructor
		public RankedRegionPaginationQuery(int? startFromRank, string askForName, RegionSortBy sorting, SortOrder order) {}
	
		// Methods
		public IPaginatedObject<RankedRegion> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedRegion> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedRegion> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<RankedRegion> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
