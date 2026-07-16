// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ArchivedReportsQuery : IPaginatedDataQuery<ReportInterface>
	{
		// Fields
		private readonly SortOrder sortOrder;
	
		// Constructors
		public ArchivedReportsQuery() {} // Dummy constructor
		public ArchivedReportsQuery(SortOrder sortOrder) {}
	
		// Methods
		public IPaginatedObject<ReportInterface> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<ReportInterface> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<ReportInterface> GetPageForResult(ServerObject obj) => default;
	}
