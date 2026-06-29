// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceReportQuery : IPaginatedDataQuery<AllianceReport>
	{
		// Fields
		private readonly AllianceReportsFilter filterToUse;
		private readonly int ownAllianceId;
	
		// Constructors
		public AllianceReportQuery() {} // Dummy constructor
		public AllianceReportQuery(int ownAllianceId, AllianceReportsFilter filter) {}
	
		// Methods
		public IPaginatedObject<AllianceReport> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
		public IPaginatedObject<AllianceReport> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AllianceReport> GetPageForResult(ServerObject obj) => default;
	}
