// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedRegionPaginationConnection : GraphQLFetchable, IPaginatedObject<RankedRegion>
	{
		// Fields
		[ObservableValue]
		private PageInfo _pageInfo;
		[ObservableValue]
		private GraphQLObservableList<RankedRegionPaginationEdge> _edges;
		[ObservableValue]
		private int _totalCount;
		private string paginatedRegionsAfterFromStatisticsPaginatedRegions;
		private int? paginatedRegionsFirstFromStatisticsPaginatedRegions;
		private string paginatedRegionsBeforeFromStatisticsPaginatedRegions;
		private int? paginatedRegionsLastFromStatisticsPaginatedRegions;
		private string paginatedRegionsNameFromStatisticsPaginatedRegions;
		private RegionSortBy? paginatedRegionsSortByFromStatisticsPaginatedRegions;
		private SortOrder? paginatedRegionsSortOrderFromStatisticsPaginatedRegions;
		private static readonly string[] namesInNestedResponseFromStatisticsPaginatedRegions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public RankedRegionPaginationConnectionSource Source { get; set; }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedRegionPaginationEdge> edges { get => default; set {} }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum RankedRegionPaginationConnectionSource
		{
			FromStatisticsPaginatedRegions = 0
		}
	
		// Constructors
		public RankedRegionPaginationConnection() {}
		static RankedRegionPaginationConnection() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RankedRegionPaginationConnectionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RankedRegionPaginationConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<RankedRegionPaginationEdge> to, List<RankedRegionPaginationEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<RankedRegionPaginationConnection> PromiseGetFromStatisticsPaginatedRegions(string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedRegionPaginationConnection> PromiseGetFromStatisticsPaginatedRegions(out RankedRegionPaginationConnection cacheObject, string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedRegionPaginationConnection GetNoFetchFromStatisticsPaginatedRegions(string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All) => default;
		public static RankedRegionPaginationConnection GetFromStatisticsPaginatedRegions(bool forceRefresh, string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All) => default;
		public static RankedRegionPaginationConnection GetFromStatisticsPaginatedRegions(string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All) => default;
		private static RankedRegionPaginationConnection FetchFromStatisticsPaginatedRegions(RankedRegionPaginationConnectionSource origin, string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsPaginatedRegions(string paginatedRegionsAfter = null, int? paginatedRegionsFirst = default, string paginatedRegionsBefore = null, int? paginatedRegionsLast = default, string paginatedRegionsName = null, RegionSortBy? paginatedRegionsSortBy = default, SortOrder? paginatedRegionsSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<RankedRegion> CreateListItems() => default;
		public List<RankedRegion> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<RankedRegion>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<RankedRegion>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
