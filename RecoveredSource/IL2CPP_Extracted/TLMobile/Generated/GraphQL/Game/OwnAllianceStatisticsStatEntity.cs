// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceStatisticsStatEntity : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _time;
		[ObservableValue]
		private int? _value1;
		[ObservableValue]
		private int? _value2;
		[ObservableValue]
		private int? _value3;
		[ObservableValue]
		private int? _value4;
		private string lossesCompareWithListFromOwnAllianceStatisticsLosses;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public int? value1 { get => default; set {} }
		[ObservableValue]
		public int? value2 { get => default; set {} }
		[ObservableValue]
		public int? value3 { get => default; set {} }
		[ObservableValue]
		public int? value4 { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OwnAllianceStatisticsStatEntityListSource
		{
			FromOwnAllianceStatisticsLosses = 0
		}
	
		// Constructors
		public OwnAllianceStatisticsStatEntity() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceStatisticsStatEntityDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceStatisticsStatEntityDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<OwnAllianceStatisticsStatEntity> CollectionGetNoFetchFromOwnAllianceStatisticsLosses(string lossesCompareWith, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OwnAllianceStatisticsStatEntity>> PromiseCollectionGetFromOwnAllianceStatisticsLosses(string lossesCompareWith, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OwnAllianceStatisticsStatEntity>> PromiseCollectionGetFromOwnAllianceStatisticsLosses(out GraphQLFetchableList<OwnAllianceStatisticsStatEntity> cacheObject, string lossesCompareWith, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OwnAllianceStatisticsStatEntity> CollectionGetFromOwnAllianceStatisticsLosses(string lossesCompareWith, Query query = Query.All) => default;
		public static GraphQLFetchableList<OwnAllianceStatisticsStatEntity> CollectionGetFromOwnAllianceStatisticsLosses(bool forceRefresh, string lossesCompareWith, Query query = Query.All) => default;
		private static GraphQLFetchableList<OwnAllianceStatisticsStatEntity> CollectionFetchFromOwnAllianceStatisticsLosses(OwnAllianceStatisticsStatEntityListSource origin, string lossesCompareWith, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnAllianceStatisticsLosses(string lossesCompareWith, object dummy = null) => default;
	}
