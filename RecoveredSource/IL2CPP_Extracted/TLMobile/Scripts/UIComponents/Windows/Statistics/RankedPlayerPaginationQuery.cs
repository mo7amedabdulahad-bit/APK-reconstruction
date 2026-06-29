// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedPlayerPaginationQuery : IPaginatedDataQuery<RankedPlayer>
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
		public RankedPlayerPaginationQuery() {} // Dummy constructor
		public RankedPlayerPaginationQuery(Ranking ranking, int? startFromRank, string askForName) {}
	
		// Methods
		public IPaginatedObject<RankedPlayer> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
		public IPaginatedObject<RankedPlayer> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedPlayer> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<RankedPlayer> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
