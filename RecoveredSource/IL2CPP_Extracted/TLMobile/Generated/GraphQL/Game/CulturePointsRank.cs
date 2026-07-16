// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CulturePointsRank : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _totalPlayers;
		[ObservableValue]
		private TotalRank _perDayRank;
		[ObservableValue]
		private int _perDayProduction;
		[ObservableValue]
		private TotalRank _soFarRank;
		[ObservableValue]
		private int _soFarProduction;
		[ObservableValue]
		private CulturePointsDistribution _distribution;
		[ObservableValue]
		private CulturePointsProgression _progression;
		private static readonly string[] namesInNestedResponseFromStatisticsCulturePointsRank;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public CulturePointsRankSource Source { get; set; }
		[ObservableValue]
		public int totalPlayers { get => default; set {} }
		[ObservableValue]
		public TotalRank perDayRank { get => default; set {} }
		[ObservableValue]
		public int perDayProduction { get => default; set {} }
		[ObservableValue]
		public TotalRank soFarRank { get => default; set {} }
		[ObservableValue]
		public int soFarProduction { get => default; set {} }
		[ObservableValue]
		public CulturePointsDistribution distribution { get => default; set {} }
		[ObservableValue]
		public CulturePointsProgression progression { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum CulturePointsRankSource
		{
			FromStatisticsCulturePointsRank = 0
		}
	
		// Constructors
		public CulturePointsRank() {}
		static CulturePointsRank() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CulturePointsRankDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CulturePointsRankDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<CulturePointsRank> PromiseGetFromStatisticsCulturePointsRank(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<CulturePointsRank> PromiseGetFromStatisticsCulturePointsRank(out CulturePointsRank cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static CulturePointsRank GetNoFetchFromStatisticsCulturePointsRank(Query query = Query.All) => default;
		public static CulturePointsRank GetFromStatisticsCulturePointsRank(bool forceRefresh, Query query = Query.All) => default;
		public static CulturePointsRank GetFromStatisticsCulturePointsRank(Query query = Query.All) => default;
		private static CulturePointsRank FetchFromStatisticsCulturePointsRank(CulturePointsRankSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsCulturePointsRank(object dummy = null) => default;
	}
