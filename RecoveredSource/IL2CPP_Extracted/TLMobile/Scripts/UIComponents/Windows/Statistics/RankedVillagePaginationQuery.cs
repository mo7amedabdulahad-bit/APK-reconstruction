// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedVillagePaginationQuery : IPaginatedDataQuery<RankedVillage>
	{
		// Fields
		private string askForName;
		private bool overrideForceFetch;
		private int? startFromRank;
	
		// Constructors
		public RankedVillagePaginationQuery() {} // Dummy constructor
		public RankedVillagePaginationQuery(int? startFromRank, string askForName) {}
	
		// Methods
		public IPaginatedObject<RankedVillage> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
		public IPaginatedObject<RankedVillage> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<RankedVillage> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<RankedVillage> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
