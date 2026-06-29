// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedRegion : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private string _artefactName;
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private int? _population;
		[ObservableValue]
		private float? _control;
		[ObservableValue]
		private bool? _isLocked;
		[ObservableValue]
		private float _controlPercentage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public string artefactName { get => default; set {} }
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public int? population { get => default; set {} }
		[ObservableValue]
		public float? control { get => default; set {} }
		[ObservableValue]
		public bool? isLocked { get => default; set {} }
		[ObservableValue]
		public float controlPercentage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum RankedRegionListSource
		{
			FromStatisticsRegions = 0
		}
	
		// Constructors
		public RankedRegion() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RankedRegionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RankedRegionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<RankedRegion> CollectionGetNoFetchFromStatisticsRegions(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<RankedRegion>> PromiseCollectionGetFromStatisticsRegions(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<RankedRegion>> PromiseCollectionGetFromStatisticsRegions(out GraphQLFetchableList<RankedRegion> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<RankedRegion> CollectionGetFromStatisticsRegions(Query query = Query.All) => default;
		public static GraphQLFetchableList<RankedRegion> CollectionGetFromStatisticsRegions(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<RankedRegion> CollectionFetchFromStatisticsRegions(RankedRegionListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromStatisticsRegions(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
