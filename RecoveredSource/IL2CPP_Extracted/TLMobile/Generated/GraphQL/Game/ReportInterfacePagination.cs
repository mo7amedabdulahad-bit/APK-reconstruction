// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportInterfacePagination : GraphQLFetchable, IPaginatedObject<ReportInterface>
	{
		// Fields
		[ObservableValue]
		private int? _totalCount;
		[ObservableValue]
		private GraphQLObservableList<ReportInterfaceEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private SortOrder? reportsSortOrderFromOwnPlayerReports;
		private int reportsFirstFromOwnPlayerReports;
		private string reportsAfterFromOwnPlayerReports;
		private ReportsFilter reportsFilterFromOwnPlayerReports;
		private SortOrder? archivedReportsSortOrderFromOwnPlayerArchivedReports;
		private int archivedReportsFirstFromOwnPlayerArchivedReports;
		private string archivedReportsAfterFromOwnPlayerArchivedReports;
		private static readonly string[] namesInNestedResponseFromOwnPlayerReports;
		private static readonly string[] namesInNestedResponseFromOwnPlayerArchivedReports;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ReportInterfacePaginationSource Source { get; set; }
		[ObservableValue]
		public int? totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ReportInterfaceEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ReportInterfacePaginationSource
		{
			FromOwnPlayerReports = 0,
			FromOwnPlayerArchivedReports = 1
		}
	
		// Constructors
		public ReportInterfacePagination() {}
		static ReportInterfacePagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ReportInterfacePaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ReportInterfacePaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<ReportInterfaceEdge> to, List<ReportInterfaceEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<ReportInterfacePagination> PromiseGetFromOwnPlayerReports(SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<ReportInterfacePagination> PromiseGetFromOwnPlayerReports(out ReportInterfacePagination cacheObject, SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static ReportInterfacePagination GetNoFetchFromOwnPlayerReports(SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All) => default;
		public static ReportInterfacePagination GetFromOwnPlayerReports(bool forceRefresh, SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All) => default;
		public static ReportInterfacePagination GetFromOwnPlayerReports(SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All) => default;
		private static ReportInterfacePagination FetchFromOwnPlayerReports(ReportInterfacePaginationSource origin, SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<ReportInterfacePagination> PromiseGetFromOwnPlayerArchivedReports(SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<ReportInterfacePagination> PromiseGetFromOwnPlayerArchivedReports(out ReportInterfacePagination cacheObject, SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static ReportInterfacePagination GetNoFetchFromOwnPlayerArchivedReports(SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All) => default;
		public static ReportInterfacePagination GetFromOwnPlayerArchivedReports(bool forceRefresh, SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All) => default;
		public static ReportInterfacePagination GetFromOwnPlayerArchivedReports(SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All) => default;
		private static ReportInterfacePagination FetchFromOwnPlayerArchivedReports(ReportInterfacePaginationSource origin, SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerReports(SortOrder? reportsSortOrder = default, int reportsFirst = 10, string reportsAfter = null, ReportsFilter reportsFilter = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromOwnPlayerArchivedReports(SortOrder? archivedReportsSortOrder = default, int archivedReportsFirst = 10, string archivedReportsAfter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<ReportInterface> CreateListItems() => default;
		public List<ReportInterface> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<ReportInterface>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<ReportInterface>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
