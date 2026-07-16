// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEventPagination : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<AllianceEventEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int eventsFirstFromOwnAllianceEvents;
		private string eventsAfterFromOwnAllianceEvents;
		private static readonly string[] namesInNestedResponseFromOwnAllianceEvents;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AllianceEventPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AllianceEventEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AllianceEventPaginationSource
		{
			FromOwnAllianceEvents = 0
		}
	
		// Constructors
		public AllianceEventPagination() {}
		static AllianceEventPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceEventPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceEventPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<AllianceEventEdge> to, List<AllianceEventEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AllianceEventPagination> PromiseGetFromOwnAllianceEvents(int eventsFirst = 10, string eventsAfter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AllianceEventPagination> PromiseGetFromOwnAllianceEvents(out AllianceEventPagination cacheObject, int eventsFirst = 10, string eventsAfter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AllianceEventPagination GetNoFetchFromOwnAllianceEvents(int eventsFirst = 10, string eventsAfter = null, Query query = Query.All) => default;
		public static AllianceEventPagination GetFromOwnAllianceEvents(bool forceRefresh, int eventsFirst = 10, string eventsAfter = null, Query query = Query.All) => default;
		public static AllianceEventPagination GetFromOwnAllianceEvents(int eventsFirst = 10, string eventsAfter = null, Query query = Query.All) => default;
		private static AllianceEventPagination FetchFromOwnAllianceEvents(AllianceEventPaginationSource origin, int eventsFirst = 10, string eventsAfter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnAllianceEvents(int eventsFirst = 10, string eventsAfter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
	}
