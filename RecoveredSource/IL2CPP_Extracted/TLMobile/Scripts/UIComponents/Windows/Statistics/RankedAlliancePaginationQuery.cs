// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedAlliancePaginationQuery : IPaginatedDataQuery<RankedAlliance>
	{
		// Fields
		private readonly Ranking rankingToUse;
		private string askForName;
		private bool overrideForceFetch;
		private int? startFromRank;
	
		// Nested types
		public enum Ranking
		{
			Overview = 1,
			Attackers = 2,
			Defenders = 3,
			Top10 = 4
		}
	
		// Constructors
		public RankedAlliancePaginationQuery() {} // Dummy constructor
		public RankedAlliancePaginationQuery(Ranking ranking, int? startFromRank, string askForName) {}
	
		// Methods
		public IPaginatedObject<RankedAlliance> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedAlliance> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedAlliance> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<RankedAlliance> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
