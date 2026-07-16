// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FarmSlot : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private Village _target;
		[ObservableValue]
		private UnitsAmount _troop;
		[ObservableValue]
		private Tribe _troopTribe;
		[ObservableValue]
		private float? _distance;
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private bool _isRunning;
		[ObservableValue]
		private int _runningAttacks;
		[ObservableValue]
		private int? _nextAttackAt;
		[ObservableValue]
		private LastRaid _lastRaid;
		[ObservableValue]
		private TotalBooty _totalBooty;
		[ObservableValue]
		private bool _isSpying;
		private int farmSlotId;
		private static readonly string[] namesInNestedResponse;
		private int farmListIdListFromFarmListSlots;
		private bool slotsOnlyExpandedListFromFarmListSlots;
		private int abandonedFarmListIdListFromAbandonedFarmListSlots;
		private bool slotsOnlyExpandedListFromAbandonedFarmListSlots;
		[ObservableValue]
		private TroopAmounts _troopAmounts;
		[ObservableValue]
		private bool _isSelected;
		[ObservableValue]
		private bool _hadError;
		[ObservableValue]
		private bool _showError;
		[ObservableValue]
		private string _errorMessage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public FarmSlotSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public Village target { get => default; set {} }
		[ObservableValue]
		public UnitsAmount troop { get => default; set {} }
		[ObservableValue]
		public Tribe troopTribe { get => default; set {} }
		[ObservableValue]
		public float? distance { get => default; set {} }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public bool isRunning { get => default; set {} }
		[ObservableValue]
		public int runningAttacks { get => default; set {} }
		[ObservableValue]
		public int? nextAttackAt { get => default; set {} }
		[ObservableValue]
		public LastRaid lastRaid { get => default; set {} }
		[ObservableValue]
		public TotalBooty totalBooty { get => default; set {} }
		[ObservableValue]
		public bool isSpying { get => default; set {} }
		[ObservableValue]
		public TroopAmounts troopAmounts { get => default; set {} }
		[ObservableValue]
		public bool isSelected { get => default; set {} }
		[ObservableValue]
		public bool hadError { get => default; set {} }
		[ObservableValue]
		public bool showError { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			IsActive = 1,
			Abandoned = 2
		}
	
		public enum FarmSlotSource
		{
			RootLevel = 0
		}
	
		public enum FarmSlotListSource
		{
			FromFarmListSlots = 0,
			FromAbandonedFarmListSlots = 1
		}
	
		// Constructors
		public FarmSlot() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(FarmSlotDTO dtoValue) => default;
		private bool EqualToDTOIsActive(FarmSlotDTO dtoValue) => default;
		private bool EqualToDTOAbandoned(FarmSlotDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(FarmSlotDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOIsActive(FarmSlotDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAbandoned(FarmSlotDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static FarmSlot GetById(object dtoObject) => default;
		public static IPromise<FarmSlot> PromiseGet(int farmSlotId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<FarmSlot> PromiseGet(out FarmSlot cacheObject, int farmSlotId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static FarmSlot GetNoFetch(int farmSlotId, Query query = Query.All) => default;
		public static FarmSlot Get(bool forceRefresh, int farmSlotId, Query query = Query.All) => default;
		public static FarmSlot Get(int farmSlotId, Query query = Query.All) => default;
		private static FarmSlot Fetch(FarmSlotSource origin, int farmSlotId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int farmSlotId, object dummy = null) => default;
		public static GraphQLFetchableList<FarmSlot> CollectionGetNoFetchFromFarmListSlots(int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<FarmSlot>> PromiseCollectionGetFromFarmListSlots(int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<FarmSlot>> PromiseCollectionGetFromFarmListSlots(out GraphQLFetchableList<FarmSlot> cacheObject, int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<FarmSlot> CollectionGetFromFarmListSlots(int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		public static GraphQLFetchableList<FarmSlot> CollectionGetFromFarmListSlots(bool forceRefresh, int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		private static GraphQLFetchableList<FarmSlot> CollectionFetchFromFarmListSlots(FarmSlotListSource origin, int farmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromFarmListSlots(int farmListId, bool slotsOnlyExpanded = false, object dummy = null) => default;
		public static GraphQLFetchableList<FarmSlot> CollectionGetNoFetchFromAbandonedFarmListSlots(int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<FarmSlot>> PromiseCollectionGetFromAbandonedFarmListSlots(int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<FarmSlot>> PromiseCollectionGetFromAbandonedFarmListSlots(out GraphQLFetchableList<FarmSlot> cacheObject, int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<FarmSlot> CollectionGetFromAbandonedFarmListSlots(int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		public static GraphQLFetchableList<FarmSlot> CollectionGetFromAbandonedFarmListSlots(bool forceRefresh, int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All) => default;
		private static GraphQLFetchableList<FarmSlot> CollectionFetchFromAbandonedFarmListSlots(FarmSlotListSource origin, int abandonedFarmListId, bool slotsOnlyExpanded = false, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromAbandonedFarmListSlots(int abandonedFarmListId, bool slotsOnlyExpanded = false, object dummy = null) => default;
		[UICallable]
		public void ToggleShowError() {}
		public bool SetError(string raidError) => default;
		public override void AfterServerDataCallback() {}
	}
