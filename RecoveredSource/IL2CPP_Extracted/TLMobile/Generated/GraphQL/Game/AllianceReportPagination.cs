// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceReportPagination : GraphQLFetchable, IPaginatedObject<AllianceReport>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<AllianceReportEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int reportsFirstFromOwnAllianceReports;
		private string reportsAfterFromOwnAllianceReports;
		private AllianceReportsFilter reportsFilterFromOwnAllianceReports;
		private static readonly string[] namesInNestedResponseFromOwnAllianceReports;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AllianceReportPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AllianceReportEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AllianceReportPaginationSource
		{
			FromOwnAllianceReports = 0
		}
	
		// Constructors
		public AllianceReportPagination() {}
		static AllianceReportPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceReportPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceReportPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<AllianceReportEdge> to, List<AllianceReportEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AllianceReportPagination> PromiseGetFromOwnAllianceReports(int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AllianceReportPagination> PromiseGetFromOwnAllianceReports(out AllianceReportPagination cacheObject, int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AllianceReportPagination GetNoFetchFromOwnAllianceReports(int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All) => default;
		public static AllianceReportPagination GetFromOwnAllianceReports(bool forceRefresh, int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All) => default;
		public static AllianceReportPagination GetFromOwnAllianceReports(int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All) => default;
		private static AllianceReportPagination FetchFromOwnAllianceReports(AllianceReportPaginationSource origin, int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnAllianceReports(int reportsFirst = 10, string reportsAfter = null, AllianceReportsFilter reportsFilter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<AllianceReport> CreateListItems() => default;
		public List<AllianceReport> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<AllianceReport>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<AllianceReport>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
