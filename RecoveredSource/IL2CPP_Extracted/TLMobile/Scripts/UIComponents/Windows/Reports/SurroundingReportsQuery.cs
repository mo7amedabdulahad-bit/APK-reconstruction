// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SurroundingReportsQuery : IPaginatedDataQuery<SurroundingReport>
	{
		// Fields
		private readonly int villageId;
	
		// Constructors
		public SurroundingReportsQuery() {} // Dummy constructor
		public SurroundingReportsQuery(int villageId) {}
	
		// Methods
		public IPaginatedObject<SurroundingReport> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<SurroundingReport> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<SurroundingReport> GetPageForResult(ServerObject obj) => default;
	}
