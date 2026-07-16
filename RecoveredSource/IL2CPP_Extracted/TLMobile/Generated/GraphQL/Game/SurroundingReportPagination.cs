// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SurroundingReportPagination : GraphQLFetchable, IPaginatedObject<SurroundingReport>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<SurroundingReportEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int ownVillageIdFromOwnVillageSurroundingReports;
		private int surroundingReportsFirstFromOwnVillageSurroundingReports;
		private string surroundingReportsAfterFromOwnVillageSurroundingReports;
		private static readonly string[] namesInNestedResponseFromOwnVillageSurroundingReports;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public SurroundingReportPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<SurroundingReportEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum SurroundingReportPaginationSource
		{
			FromOwnVillageSurroundingReports = 0
		}
	
		// Constructors
		public SurroundingReportPagination() {}
		static SurroundingReportPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SurroundingReportPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SurroundingReportPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<SurroundingReportEdge> to, List<SurroundingReportEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<SurroundingReportPagination> PromiseGetFromOwnVillageSurroundingReports(int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<SurroundingReportPagination> PromiseGetFromOwnVillageSurroundingReports(out SurroundingReportPagination cacheObject, int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static SurroundingReportPagination GetNoFetchFromOwnVillageSurroundingReports(int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All) => default;
		public static SurroundingReportPagination GetFromOwnVillageSurroundingReports(bool forceRefresh, int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All) => default;
		public static SurroundingReportPagination GetFromOwnVillageSurroundingReports(int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All) => default;
		private static SurroundingReportPagination FetchFromOwnVillageSurroundingReports(SurroundingReportPaginationSource origin, int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageSurroundingReports(int ownVillageId, int surroundingReportsFirst = 10, string surroundingReportsAfter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<SurroundingReport> CreateListItems() => default;
		public List<SurroundingReport> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<SurroundingReport>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<SurroundingReport>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
