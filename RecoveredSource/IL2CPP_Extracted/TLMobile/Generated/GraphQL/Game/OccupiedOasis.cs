// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OccupiedOasis : OasisInterface, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private Village _belongsTo;
		[ObservableValue]
		private int? _loyalty;
		[ObservableValue]
		private int? _conquered;
		[ObservableValue]
		private int? _finishedAt;
		private int ownVillageIdListFromOwnVillageOccupiedOases;
		private int? villageIdListFromVillageOccupiedOases;
		private TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinatesListFromVillageOccupiedOasesByCoordinates;
		[ObservableValue]
		private string _resourcesIllustrationKey;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Village belongsTo { get => default; set {} }
		[ObservableValue]
		public int? loyalty { get => default; set {} }
		[ObservableValue]
		public int? conquered { get => default; set {} }
		[ObservableValue]
		public int? finishedAt { get => default; set {} }
		[ObservableValue]
		public string resourcesIllustrationKey { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OccupiedOasisListSource
		{
			FromOwnVillageOccupiedOases = 0,
			FromVillageOccupiedOases = 1,
			FromVillageOccupiedOasesByCoordinates = 2
		}
	
		// Constructors
		public OccupiedOasis() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OccupiedOasisDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OccupiedOasisDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetNoFetchFromOwnVillageOccupiedOases(int ownVillageId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromOwnVillageOccupiedOases(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromOwnVillageOccupiedOases(out GraphQLFetchableList<OccupiedOasis> cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromOwnVillageOccupiedOases(int ownVillageId, Query query = Query.All) => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromOwnVillageOccupiedOases(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		private static GraphQLFetchableList<OccupiedOasis> CollectionFetchFromOwnVillageOccupiedOases(OccupiedOasisListSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnVillageOccupiedOases(int ownVillageId, object dummy = null) => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetNoFetchFromVillageOccupiedOases(int? villageId = default, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromVillageOccupiedOases(int? villageId = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromVillageOccupiedOases(out GraphQLFetchableList<OccupiedOasis> cacheObject, int? villageId = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromVillageOccupiedOases(int? villageId = default, Query query = Query.All) => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromVillageOccupiedOases(bool forceRefresh, int? villageId = default, Query query = Query.All) => default;
		private static GraphQLFetchableList<OccupiedOasis> CollectionFetchFromVillageOccupiedOases(OccupiedOasisListSource origin, int? villageId = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromVillageOccupiedOases(int? villageId = default, object dummy = null) => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetNoFetchFromVillageOccupiedOasesByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromVillageOccupiedOasesByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OccupiedOasis>> PromiseCollectionGetFromVillageOccupiedOasesByCoordinates(out GraphQLFetchableList<OccupiedOasis> cacheObject, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromVillageOccupiedOasesByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<OccupiedOasis> CollectionGetFromVillageOccupiedOasesByCoordinates(bool forceRefresh, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<OccupiedOasis> CollectionFetchFromVillageOccupiedOasesByCoordinates(OccupiedOasisListSource origin, TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromVillageOccupiedOasesByCoordinates(TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinates = null, object dummy = null) => default;
		public override void AfterServerDataCallback(object data = null) {}
		public int GetRequiredUpdateTime() => default;
		private string GetResourceIllustrationKey() => default;
	}
