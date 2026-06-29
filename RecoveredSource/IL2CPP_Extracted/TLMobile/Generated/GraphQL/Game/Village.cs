// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Village : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _landDistribution;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private int _mapId;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private bool _isWW;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private string _typeText;
		[ObservableValue]
		private string _typeTitle;
		[ObservableValue]
		private bool _isShore;
		[ObservableValue]
		private bool _isCity;
		[ObservableValue]
		private Village _ownerVillage;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private int? _victoryPoints;
		[ObservableValue]
		private float? _victoryPointsPerDay;
		private int? villageId;
		private TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinatesByCoordinates;
		private static readonly string[] namesInNestedResponse;
		private static readonly string[] namesInNestedResponseByCoordinates;
		private int ownVillageIdListFromOwnVillageNearbyVillages;
		private int? nearbyVillagesFirstListFromOwnVillageNearbyVillages;
		private VillageRelation? nearbyVillagesRelationTypeListFromOwnVillageNearbyVillages;
		private int playerIdListFromPlayerVillages;
		private string findNearbyVillagesNameListByFindNearbyVillages;
		private string findAllianceVillagesNameListByFindAllianceVillages;
		private bool findAllianceVillagesIncludeOwnVillagesListByFindAllianceVillages;
		[ObservableValue]
		private OwnVillage.Type _typeEnum;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeEnum;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private LandDistribution _landDistributionObject;
		[ObservableValue]
		private string _villageTypeName;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public VillageSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int landDistribution { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public int mapId { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public bool isWW { get => default; set {} }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public string typeText { get => default; set {} }
		[ObservableValue]
		public string typeTitle { get => default; set {} }
		[ObservableValue]
		public bool isShore { get => default; set {} }
		[ObservableValue]
		public bool isCity { get => default; set {} }
		[ObservableValue]
		public Village ownerVillage { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public int? victoryPoints { get => default; set {} }
		[ObservableValue]
		public float? victoryPointsPerDay { get => default; set {} }
		[ObservableValue]
		public OwnVillage.Type typeEnum { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeEnum { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public LandDistribution landDistributionObject { get => default; set {} }
		[ObservableValue]
		public string villageTypeName { get => default; set {} }
		public int size { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Stub = 1,
			IdOnly = 2
		}
	
		public enum VillageSource
		{
			RootLevel = 0,
			RootLevelByCoordinates = 1
		}
	
		public enum VillageListSource
		{
			FromOwnPlayerDeactivatedFarmListTargets = 0,
			FromOwnVillageNearbyVillages = 1,
			FromPlayerVillages = 2,
			RootLevelByFindNearbyVillages = 3,
			RootLevelByFindAllianceVillages = 4
		}
	
		// Constructors
		public Village() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(VillageDTO dtoValue) => default;
		private bool EqualToDTOStub(VillageDTO dtoValue) => default;
		private bool EqualToDTOIdOnly(VillageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(VillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(VillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOIdOnly(VillageDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static Village GetById(object dtoObject) => default;
		public static IPromise<Village> PromiseGet(int? villageId = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Village> PromiseGet(out Village cacheObject, int? villageId = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Village GetNoFetch(int? villageId = default, Query query = Query.All) => default;
		public static Village Get(bool forceRefresh, int? villageId = default, Query query = Query.All) => default;
		public static Village Get(int? villageId = default, Query query = Query.All) => default;
		private static Village Fetch(VillageSource origin, int? villageId = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<Village> PromiseGetByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Village> PromiseGetByCoordinates(out Village cacheObject, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Village GetNoFetchByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		public static Village GetByCoordinates(bool forceRefresh, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		public static Village GetByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		private static Village FetchByCoordinates(VillageSource origin, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int? villageId = default, object dummy = null) => default;
		private static string GetRequestBodyPartByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, object dummy = null) => default;
		public static GraphQLFetchableList<Village> CollectionGetNoFetchFromOwnPlayerDeactivatedFarmListTargets(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromOwnPlayerDeactivatedFarmListTargets(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromOwnPlayerDeactivatedFarmListTargets(out GraphQLFetchableList<Village> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Village> CollectionGetFromOwnPlayerDeactivatedFarmListTargets(Query query = Query.All) => default;
		public static GraphQLFetchableList<Village> CollectionGetFromOwnPlayerDeactivatedFarmListTargets(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Village> CollectionFetchFromOwnPlayerDeactivatedFarmListTargets(VillageListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerDeactivatedFarmListTargets(object dummy = null) => default;
		public static GraphQLFetchableList<Village> CollectionGetNoFetchFromOwnVillageNearbyVillages(int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromOwnVillageNearbyVillages(int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromOwnVillageNearbyVillages(out GraphQLFetchableList<Village> cacheObject, int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Village> CollectionGetFromOwnVillageNearbyVillages(int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All) => default;
		public static GraphQLFetchableList<Village> CollectionGetFromOwnVillageNearbyVillages(bool forceRefresh, int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All) => default;
		private static GraphQLFetchableList<Village> CollectionFetchFromOwnVillageNearbyVillages(VillageListSource origin, int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnVillageNearbyVillages(int ownVillageId, int? nearbyVillagesFirst = default, VillageRelation? nearbyVillagesRelationType = default, object dummy = null) => default;
		public static GraphQLFetchableList<Village> CollectionGetNoFetchFromPlayerVillages(int playerId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromPlayerVillages(int playerId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetFromPlayerVillages(out GraphQLFetchableList<Village> cacheObject, int playerId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Village> CollectionGetFromPlayerVillages(int playerId, Query query = Query.All) => default;
		public static GraphQLFetchableList<Village> CollectionGetFromPlayerVillages(bool forceRefresh, int playerId, Query query = Query.All) => default;
		private static GraphQLFetchableList<Village> CollectionFetchFromPlayerVillages(VillageListSource origin, int playerId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromPlayerVillages(int playerId, object dummy = null) => default;
		public static GraphQLFetchableList<Village> CollectionGetNoFetchByFindNearbyVillages(string findNearbyVillagesName, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetByFindNearbyVillages(string findNearbyVillagesName, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetByFindNearbyVillages(out GraphQLFetchableList<Village> cacheObject, string findNearbyVillagesName, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Village> CollectionGetByFindNearbyVillages(string findNearbyVillagesName, Query query = Query.All) => default;
		public static GraphQLFetchableList<Village> CollectionGetByFindNearbyVillages(bool forceRefresh, string findNearbyVillagesName, Query query = Query.All) => default;
		private static GraphQLFetchableList<Village> CollectionFetchByFindNearbyVillages(VillageListSource origin, string findNearbyVillagesName, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFindNearbyVillages(string findNearbyVillagesName, object dummy = null) => default;
		public static GraphQLFetchableList<Village> CollectionGetNoFetchByFindAllianceVillages(string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetByFindAllianceVillages(string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Village>> PromiseCollectionGetByFindAllianceVillages(out GraphQLFetchableList<Village> cacheObject, string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Village> CollectionGetByFindAllianceVillages(string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All) => default;
		public static GraphQLFetchableList<Village> CollectionGetByFindAllianceVillages(bool forceRefresh, string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All) => default;
		private static GraphQLFetchableList<Village> CollectionFetchByFindAllianceVillages(VillageListSource origin, string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFindAllianceVillages(string findAllianceVillagesName, bool findAllianceVillagesIncludeOwnVillages = true, object dummy = null) => default;
		public override void AfterServerDataCallback() {}
		private string VillageTypeName(OwnVillage.Type type) => default;
		public bool IsAttackingBlocked() => default;
	}
