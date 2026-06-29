// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VPRankedAlliancePagination : GraphQLFetchable, IPaginatedObject<VPRankedAlliance>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<VPRankedAllianceEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int? overviewFirstFromStatisticsVictoryPointsRankOverview;
		private string overviewAfterFromStatisticsVictoryPointsRankOverview;
		private int? overviewLastFromStatisticsVictoryPointsRankOverview;
		private string overviewBeforeFromStatisticsVictoryPointsRankOverview;
		private int? overviewRankFromStatisticsVictoryPointsRankOverview;
		private string overviewNameFromStatisticsVictoryPointsRankOverview;
		private static readonly string[] namesInNestedResponseFromStatisticsVictoryPointsRankOverview;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public VPRankedAlliancePaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<VPRankedAllianceEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum VPRankedAlliancePaginationSource
		{
			FromStatisticsVictoryPointsRankOverview = 0
		}
	
		// Constructors
		public VPRankedAlliancePagination() {}
		static VPRankedAlliancePagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(VPRankedAlliancePaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(VPRankedAlliancePaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<VPRankedAllianceEdge> to, List<VPRankedAllianceEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<VPRankedAlliancePagination> PromiseGetFromStatisticsVictoryPointsRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<VPRankedAlliancePagination> PromiseGetFromStatisticsVictoryPointsRankOverview(out VPRankedAlliancePagination cacheObject, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static VPRankedAlliancePagination GetNoFetchFromStatisticsVictoryPointsRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static VPRankedAlliancePagination GetFromStatisticsVictoryPointsRankOverview(bool forceRefresh, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static VPRankedAlliancePagination GetFromStatisticsVictoryPointsRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		private static VPRankedAlliancePagination FetchFromStatisticsVictoryPointsRankOverview(VPRankedAlliancePaginationSource origin, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsVictoryPointsRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<VPRankedAlliance> CreateListItems() => default;
		public List<VPRankedAlliance> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<VPRankedAlliance>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<VPRankedAlliance>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
