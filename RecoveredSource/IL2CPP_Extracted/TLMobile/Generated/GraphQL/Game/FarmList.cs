// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FarmList : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private OwnVillage _ownerVillage;
		[ObservableValue]
		private UnitsAmount _defaultTroop;
		[ObservableValue]
		private int _slotsAmount;
		[ObservableValue]
		private int _runningRaidsAmount;
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private int _sortIndex;
		[ObservableValue]
		private int? _lastStartedTime;
		[ObservableValue]
		private string _sortField;
		[ObservableValue]
		private string _sortDirection;
		[ObservableValue]
		private bool _useShip;
		[ObservableValue]
		private bool? _onlyLosses;
		private int farmListId;
		private static readonly string[] namesInNestedResponse;
		private FarmListsFilter farmListsFilterListFromOwnPlayerFarmLists;
		private FarmListsFilter abandonedFarmListsFilterListFromOwnPlayerAbandonedFarmLists;
		private int farmListsWithTargetTargetIdListByFarmListsWithTarget;
		private readonly List<FarmSlot> associatedRaids;
		[ObservableValue]
		private bool _hadError;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private bool _isAbandoned;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public FarmListSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public OwnVillage ownerVillage { get => default; set {} }
		[ObservableValue]
		public UnitsAmount defaultTroop { get => default; set {} }
		[ObservableValue]
		public int slotsAmount { get => default; set {} }
		[ObservableValue]
		public int runningRaidsAmount { get => default; set {} }
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public int sortIndex { get => default; set {} }
		[ObservableValue]
		public int? lastStartedTime { get => default; set {} }
		[ObservableValue]
		public string sortField { get => default; set {} }
		[ObservableValue]
		public string sortDirection { get => default; set {} }
		[ObservableValue]
		public bool useShip { get => default; set {} }
		[ObservableValue]
		public bool? onlyLosses { get => default; set {} }
		[ObservableValue]
		public bool hadError { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public bool isAbandoned { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum FarmListSource
		{
			RootLevel = 0
		}
	
		public enum FarmListListSource
		{
			FromOwnPlayerFarmLists = 0,
			FromOwnPlayerAbandonedFarmLists = 1,
			RootLevelByFarmListsWithTarget = 2
		}
	
		// Constructors
		public FarmList() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(FarmListDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(FarmListDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static FarmList GetById(object dtoObject) => default;
		public static IPromise<FarmList> PromiseGet(int farmListId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<FarmList> PromiseGet(out FarmList cacheObject, int farmListId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static FarmList GetNoFetch(int farmListId, Query query = Query.All) => default;
		public static FarmList Get(bool forceRefresh, int farmListId, Query query = Query.All) => default;
		public static FarmList Get(int farmListId, Query query = Query.All) => default;
		private static FarmList Fetch(FarmListSource origin, int farmListId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int farmListId, object dummy = null) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetNoFetchFromOwnPlayerFarmLists(FarmListsFilter farmListsFilter = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetFromOwnPlayerFarmLists(FarmListsFilter farmListsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetFromOwnPlayerFarmLists(out GraphQLFetchableList<FarmList> cacheObject, FarmListsFilter farmListsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<FarmList> CollectionGetFromOwnPlayerFarmLists(FarmListsFilter farmListsFilter = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetFromOwnPlayerFarmLists(bool forceRefresh, FarmListsFilter farmListsFilter = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<FarmList> CollectionFetchFromOwnPlayerFarmLists(FarmListListSource origin, FarmListsFilter farmListsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerFarmLists(FarmListsFilter farmListsFilter = null, object dummy = null) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetNoFetchFromOwnPlayerAbandonedFarmLists(FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetFromOwnPlayerAbandonedFarmLists(FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetFromOwnPlayerAbandonedFarmLists(out GraphQLFetchableList<FarmList> cacheObject, FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<FarmList> CollectionGetFromOwnPlayerAbandonedFarmLists(FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetFromOwnPlayerAbandonedFarmLists(bool forceRefresh, FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<FarmList> CollectionFetchFromOwnPlayerAbandonedFarmLists(FarmListListSource origin, FarmListsFilter abandonedFarmListsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerAbandonedFarmLists(FarmListsFilter abandonedFarmListsFilter = null, object dummy = null) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetNoFetchByFarmListsWithTarget(int farmListsWithTargetTargetId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetByFarmListsWithTarget(int farmListsWithTargetTargetId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<FarmList>> PromiseCollectionGetByFarmListsWithTarget(out GraphQLFetchableList<FarmList> cacheObject, int farmListsWithTargetTargetId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<FarmList> CollectionGetByFarmListsWithTarget(int farmListsWithTargetTargetId, Query query = Query.All) => default;
		public static GraphQLFetchableList<FarmList> CollectionGetByFarmListsWithTarget(bool forceRefresh, int farmListsWithTargetTargetId, Query query = Query.All) => default;
		private static GraphQLFetchableList<FarmList> CollectionFetchByFarmListsWithTarget(FarmListListSource origin, int farmListsWithTargetTargetId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFarmListsWithTarget(int farmListsWithTargetTargetId, object dummy = null) => default;
		public override void AfterServerDataCallback(object data = null) {}
		public int SetErrorState(FarmListResponse list) => default;
		public void ResetErrorState() {}
	}
