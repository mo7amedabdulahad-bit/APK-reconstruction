// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Adventure : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _number;
		[ObservableValue]
		private int _groundType;
		[ObservableValue]
		private string _place;
		[ObservableValue]
		private int? _x;
		[ObservableValue]
		private int? _y;
		[ObservableValue]
		private int? _mapId;
		[ObservableValue]
		private float? _distance;
		[ObservableValue]
		private int _difficulty;
		[ObservableValue]
		private int _travelingDuration;
		[ObservableValue]
		private bool? _hasDifficultyBonusActive;
		[ObservableValue]
		private bool? _hasDurationBonusActive;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int number { get => default; set {} }
		[ObservableValue]
		public int groundType { get => default; set {} }
		[ObservableValue]
		public string place { get => default; set {} }
		[ObservableValue]
		public int? x { get => default; set {} }
		[ObservableValue]
		public int? y { get => default; set {} }
		[ObservableValue]
		public int? mapId { get => default; set {} }
		[ObservableValue]
		public float? distance { get => default; set {} }
		[ObservableValue]
		public int difficulty { get => default; set {} }
		[ObservableValue]
		public int travelingDuration { get => default; set {} }
		[ObservableValue]
		public bool? hasDifficultyBonusActive { get => default; set {} }
		[ObservableValue]
		public bool? hasDurationBonusActive { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AdventureListSource
		{
			FromOwnPlayerHeroAdventures = 0
		}
	
		// Constructors
		public Adventure() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AdventureDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AdventureDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<Adventure> CollectionGetNoFetchFromOwnPlayerHeroAdventures(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Adventure>> PromiseCollectionGetFromOwnPlayerHeroAdventures(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Adventure>> PromiseCollectionGetFromOwnPlayerHeroAdventures(out GraphQLFetchableList<Adventure> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Adventure> CollectionGetFromOwnPlayerHeroAdventures(Query query = Query.All) => default;
		public static GraphQLFetchableList<Adventure> CollectionGetFromOwnPlayerHeroAdventures(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Adventure> CollectionFetchFromOwnPlayerHeroAdventures(AdventureListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroAdventures(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
