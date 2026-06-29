// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourcesRank : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _bountyIn;
		[ObservableValue]
		private int _tradedIn;
		[ObservableValue]
		private int _production;
		[ObservableValue]
		private int _bountyOut;
		[ObservableValue]
		private int _tradedOut;
		[ObservableValue]
		private TotalRank _perDayRank;
		[ObservableValue]
		private ResourcesProduction _perDayProduction;
		[ObservableValue]
		private TotalRank _soFarRank;
		[ObservableValue]
		private ResourcesProduction _soFarProduction;
		private static readonly string[] namesInNestedResponseFromStatisticsResourcesRank;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ResourcesRankSource Source { get; set; }
		[ObservableValue]
		public int bountyIn { get => default; set {} }
		[ObservableValue]
		public int tradedIn { get => default; set {} }
		[ObservableValue]
		public int production { get => default; set {} }
		[ObservableValue]
		public int bountyOut { get => default; set {} }
		[ObservableValue]
		public int tradedOut { get => default; set {} }
		[ObservableValue]
		public TotalRank perDayRank { get => default; set {} }
		[ObservableValue]
		public ResourcesProduction perDayProduction { get => default; set {} }
		[ObservableValue]
		public TotalRank soFarRank { get => default; set {} }
		[ObservableValue]
		public ResourcesProduction soFarProduction { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ResourcesRankSource
		{
			FromStatisticsResourcesRank = 0
		}
	
		// Constructors
		public ResourcesRank() {}
		static ResourcesRank() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ResourcesRankDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ResourcesRankDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<ResourcesRank> PromiseGetFromStatisticsResourcesRank(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<ResourcesRank> PromiseGetFromStatisticsResourcesRank(out ResourcesRank cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static ResourcesRank GetNoFetchFromStatisticsResourcesRank(Query query = Query.All) => default;
		public static ResourcesRank GetFromStatisticsResourcesRank(bool forceRefresh, Query query = Query.All) => default;
		public static ResourcesRank GetFromStatisticsResourcesRank(Query query = Query.All) => default;
		private static ResourcesRank FetchFromStatisticsResourcesRank(ResourcesRankSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsResourcesRank(object dummy = null) => default;
	}
