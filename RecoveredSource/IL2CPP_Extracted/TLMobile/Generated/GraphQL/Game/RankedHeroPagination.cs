// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedHeroPagination : GraphQLFetchable, IPaginatedObject<RankedHero>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<RankedHeroEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int? overviewFirstFromStatisticsHeroesRankOverview;
		private string overviewAfterFromStatisticsHeroesRankOverview;
		private int? overviewLastFromStatisticsHeroesRankOverview;
		private string overviewBeforeFromStatisticsHeroesRankOverview;
		private int? overviewRankFromStatisticsHeroesRankOverview;
		private string overviewNameFromStatisticsHeroesRankOverview;
		private static readonly string[] namesInNestedResponseFromStatisticsHeroesRankOverview;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public RankedHeroPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedHeroEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum RankedHeroPaginationSource
		{
			FromStatisticsHeroesRankOverview = 0
		}
	
		// Constructors
		public RankedHeroPagination() {}
		static RankedHeroPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RankedHeroPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RankedHeroPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<RankedHeroEdge> to, List<RankedHeroEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<RankedHeroPagination> PromiseGetFromStatisticsHeroesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedHeroPagination> PromiseGetFromStatisticsHeroesRankOverview(out RankedHeroPagination cacheObject, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedHeroPagination GetNoFetchFromStatisticsHeroesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedHeroPagination GetFromStatisticsHeroesRankOverview(bool forceRefresh, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedHeroPagination GetFromStatisticsHeroesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		private static RankedHeroPagination FetchFromStatisticsHeroesRankOverview(RankedHeroPaginationSource origin, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsHeroesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<RankedHero> CreateListItems() => default;
		public List<RankedHero> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<RankedHero>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<RankedHero>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
