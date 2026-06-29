// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedHeroPaginationQuery : IPaginatedDataQuery<RankedHero>
	{
		// Fields
		private string askForName;
		private bool overrideForceFetch;
		private int? startFromRank;
	
		// Constructors
		public RankedHeroPaginationQuery() {} // Dummy constructor
		public RankedHeroPaginationQuery(int? startFromRank, string askForName) {}
	
		// Methods
		public IPaginatedObject<RankedHero> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
		public IPaginatedObject<RankedHero> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedHero> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<RankedHero> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
