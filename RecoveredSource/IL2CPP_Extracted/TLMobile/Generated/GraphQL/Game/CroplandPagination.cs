// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CroplandPagination : GraphQLFetchable, IPaginatedObject<Cropland>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<CroplandEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int croplandsFirst;
		private string croplandsAfter;
		private CroplandsFilter croplandsFilter;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public CroplandPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<CroplandEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum CroplandPaginationSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public CroplandPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CroplandPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CroplandPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<CroplandEdge> to, List<CroplandEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<CroplandPagination> PromiseGet(int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<CroplandPagination> PromiseGet(out CroplandPagination cacheObject, int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static CroplandPagination GetNoFetch(int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All) => default;
		public static CroplandPagination Get(bool forceRefresh, int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All) => default;
		public static CroplandPagination Get(int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All) => default;
		private static CroplandPagination Fetch(CroplandPaginationSource origin, int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int croplandsFirst = 10, string croplandsAfter = null, CroplandsFilter croplandsFilter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<Cropland> CreateListItems() => default;
		public List<Cropland> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<Cropland>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<Cropland>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
