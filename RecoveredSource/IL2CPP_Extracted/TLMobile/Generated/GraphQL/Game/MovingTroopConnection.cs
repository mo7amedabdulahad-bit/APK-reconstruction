// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovingTroopConnection : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private PageInfo _pageInfo;
		[ObservableValue]
		private GraphQLObservableList<MovingTroopEdge> _edges;
		[ObservableValue]
		private int? _totalCount;
		private int ownVillageIdFromOwnVillageTroopsMoving;
		private string movingAfterFromOwnVillageTroopsMoving;
		private int? movingFirstFromOwnVillageTroopsMoving;
		private MovingTroopsFilter movingFilterFromOwnVillageTroopsMoving;
		private MovingTroopsSortOrder? movingSortOrderFromOwnVillageTroopsMoving;
		private static readonly string[] namesInNestedResponseFromOwnVillageTroopsMoving;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MovingTroopConnectionSource Source { get; set; }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MovingTroopEdge> edges { get => default; set {} }
		[ObservableValue]
		public int? totalCount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyTime = 1
		}
	
		public enum MovingTroopConnectionSource
		{
			FromOwnVillageTroopsMoving = 0
		}
	
		// Constructors
		public MovingTroopConnection() {}
		static MovingTroopConnection() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MovingTroopConnectionDTO dtoValue) => default;
		private bool EqualToDTOOnlyTime(MovingTroopConnectionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MovingTroopConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyTime(MovingTroopConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<MovingTroopEdge> to, List<MovingTroopEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MovingTroopConnection> PromiseGetFromOwnVillageTroopsMoving(int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MovingTroopConnection> PromiseGetFromOwnVillageTroopsMoving(out MovingTroopConnection cacheObject, int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MovingTroopConnection GetNoFetchFromOwnVillageTroopsMoving(int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All) => default;
		public static MovingTroopConnection GetFromOwnVillageTroopsMoving(bool forceRefresh, int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All) => default;
		public static MovingTroopConnection GetFromOwnVillageTroopsMoving(int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All) => default;
		private static MovingTroopConnection FetchFromOwnVillageTroopsMoving(MovingTroopConnectionSource origin, int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTroopsMoving(int ownVillageId, string movingAfter = null, int? movingFirst = default, MovingTroopsFilter movingFilter = null, MovingTroopsSortOrder? movingSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
	}
