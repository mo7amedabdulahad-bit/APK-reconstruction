// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StandingTroopConnection : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private PageInfo _pageInfo;
		[ObservableValue]
		private GraphQLObservableList<StandingTroopEdge> _edges;
		[ObservableValue]
		private int? _totalCount;
		private int ownVillageIdFromOwnVillageTroopsStandingAtTown;
		private string standingAtTownAfterFromOwnVillageTroopsStandingAtTown;
		private int? standingAtTownFirstFromOwnVillageTroopsStandingAtTown;
		private StandingAtTownTroopsFilter standingAtTownFilterFromOwnVillageTroopsStandingAtTown;
		private int ownVillageIdFromOwnVillageTroopsStandingOutOfTown;
		private string standingOutOfTownAfterFromOwnVillageTroopsStandingOutOfTown;
		private int? standingOutOfTownFirstFromOwnVillageTroopsStandingOutOfTown;
		private static readonly string[] namesInNestedResponseFromOwnVillageTroopsStandingAtTown;
		private static readonly string[] namesInNestedResponseFromOwnVillageTroopsStandingOutOfTown;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public StandingTroopConnectionSource Source { get; set; }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<StandingTroopEdge> edges { get => default; set {} }
		[ObservableValue]
		public int? totalCount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum StandingTroopConnectionSource
		{
			FromOwnVillageTroopsStandingAtTown = 0,
			FromOwnVillageTroopsStandingOutOfTown = 1
		}
	
		// Constructors
		public StandingTroopConnection() {}
		static StandingTroopConnection() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(StandingTroopConnectionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(StandingTroopConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<StandingTroopEdge> to, List<StandingTroopEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<StandingTroopConnection> PromiseGetFromOwnVillageTroopsStandingAtTown(int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<StandingTroopConnection> PromiseGetFromOwnVillageTroopsStandingAtTown(out StandingTroopConnection cacheObject, int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static StandingTroopConnection GetNoFetchFromOwnVillageTroopsStandingAtTown(int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All) => default;
		public static StandingTroopConnection GetFromOwnVillageTroopsStandingAtTown(bool forceRefresh, int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All) => default;
		public static StandingTroopConnection GetFromOwnVillageTroopsStandingAtTown(int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All) => default;
		private static StandingTroopConnection FetchFromOwnVillageTroopsStandingAtTown(StandingTroopConnectionSource origin, int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<StandingTroopConnection> PromiseGetFromOwnVillageTroopsStandingOutOfTown(int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<StandingTroopConnection> PromiseGetFromOwnVillageTroopsStandingOutOfTown(out StandingTroopConnection cacheObject, int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static StandingTroopConnection GetNoFetchFromOwnVillageTroopsStandingOutOfTown(int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All) => default;
		public static StandingTroopConnection GetFromOwnVillageTroopsStandingOutOfTown(bool forceRefresh, int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All) => default;
		public static StandingTroopConnection GetFromOwnVillageTroopsStandingOutOfTown(int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All) => default;
		private static StandingTroopConnection FetchFromOwnVillageTroopsStandingOutOfTown(StandingTroopConnectionSource origin, int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTroopsStandingAtTown(int ownVillageId, string standingAtTownAfter = null, int? standingAtTownFirst = default, StandingAtTownTroopsFilter standingAtTownFilter = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromOwnVillageTroopsStandingOutOfTown(int ownVillageId, string standingOutOfTownAfter = null, int? standingOutOfTownFirst = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
	}
