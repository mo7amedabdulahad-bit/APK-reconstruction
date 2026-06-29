// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WonderOfWorldStatEntry : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private int? _lastAttackAt;
		[ObservableValue]
		private int? _nextAttackAt;
		[ObservableValue]
		private string _wwName;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public int? lastAttackAt { get => default; set {} }
		[ObservableValue]
		public int? nextAttackAt { get => default; set {} }
		[ObservableValue]
		public string wwName { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum WonderOfWorldStatEntryListSource
		{
			FromStatisticsWow = 0
		}
	
		// Constructors
		public WonderOfWorldStatEntry() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(WonderOfWorldStatEntryDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(WonderOfWorldStatEntryDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<WonderOfWorldStatEntry> CollectionGetNoFetchFromStatisticsWow(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<WonderOfWorldStatEntry>> PromiseCollectionGetFromStatisticsWow(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<WonderOfWorldStatEntry>> PromiseCollectionGetFromStatisticsWow(out GraphQLFetchableList<WonderOfWorldStatEntry> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<WonderOfWorldStatEntry> CollectionGetFromStatisticsWow(Query query = Query.All) => default;
		public static GraphQLFetchableList<WonderOfWorldStatEntry> CollectionGetFromStatisticsWow(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<WonderOfWorldStatEntry> CollectionFetchFromStatisticsWow(WonderOfWorldStatEntryListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromStatisticsWow(object dummy = null) => default;
	}
