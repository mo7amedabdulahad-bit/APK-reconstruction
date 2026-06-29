// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VPRankedAlliancePaginationQuery : IPaginatedDataQuery<VPRankedAlliance>
	{
		// Fields
		private string askForName;
		private bool overrideForceFetch;
		private int? startFromRank;
	
		// Constructors
		public VPRankedAlliancePaginationQuery() {} // Dummy constructor
		public VPRankedAlliancePaginationQuery(int? startFromRank, string askForName) {}
	
		// Methods
		public IPaginatedObject<VPRankedAlliance> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<VPRankedAlliance> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<VPRankedAlliance> GetPageForResult(ServerObject obj) => default;
		private IPaginatedObject<VPRankedAlliance> GetPaginationPage(string cursor, int amount, bool forceRefresh, bool fetchBefore) => default;
	}
