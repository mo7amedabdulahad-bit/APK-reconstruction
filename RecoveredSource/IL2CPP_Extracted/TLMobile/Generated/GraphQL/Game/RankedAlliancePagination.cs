// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedAlliancePagination : GraphQLFetchable, IPaginatedObject<RankedAlliance>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<RankedAllianceEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int? overviewFirstFromStatisticsAlliancesRankOverview;
		private string overviewAfterFromStatisticsAlliancesRankOverview;
		private int? overviewLastFromStatisticsAlliancesRankOverview;
		private string overviewBeforeFromStatisticsAlliancesRankOverview;
		private int? overviewRankFromStatisticsAlliancesRankOverview;
		private string overviewNameFromStatisticsAlliancesRankOverview;
		private int? attackersFirstFromStatisticsAlliancesRankAttackers;
		private string attackersAfterFromStatisticsAlliancesRankAttackers;
		private int? attackersLastFromStatisticsAlliancesRankAttackers;
		private string attackersBeforeFromStatisticsAlliancesRankAttackers;
		private int? attackersRankFromStatisticsAlliancesRankAttackers;
		private string attackersNameFromStatisticsAlliancesRankAttackers;
		private int? defendersFirstFromStatisticsAlliancesRankDefenders;
		private string defendersAfterFromStatisticsAlliancesRankDefenders;
		private int? defendersLastFromStatisticsAlliancesRankDefenders;
		private string defendersBeforeFromStatisticsAlliancesRankDefenders;
		private int? defendersRankFromStatisticsAlliancesRankDefenders;
		private string defendersNameFromStatisticsAlliancesRankDefenders;
		private static readonly string[] namesInNestedResponseFromStatisticsAlliancesRankOverview;
		private static readonly string[] namesInNestedResponseFromStatisticsAlliancesRankAttackers;
		private static readonly string[] namesInNestedResponseFromStatisticsAlliancesRankDefenders;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public RankedAlliancePaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedAllianceEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum RankedAlliancePaginationSource
		{
			FromStatisticsAlliancesRankOverview = 0,
			FromStatisticsAlliancesRankAttackers = 1,
			FromStatisticsAlliancesRankDefenders = 2
		}
	
		// Constructors
		public RankedAlliancePagination() {}
		static RankedAlliancePagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RankedAlliancePaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RankedAlliancePaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<RankedAllianceEdge> to, List<RankedAllianceEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankOverview(out RankedAlliancePagination cacheObject, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedAlliancePagination GetNoFetchFromStatisticsAlliancesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankOverview(bool forceRefresh, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		private static RankedAlliancePagination FetchFromStatisticsAlliancesRankOverview(RankedAlliancePaginationSource origin, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankAttackers(out RankedAlliancePagination cacheObject, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedAlliancePagination GetNoFetchFromStatisticsAlliancesRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankAttackers(bool forceRefresh, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		private static RankedAlliancePagination FetchFromStatisticsAlliancesRankAttackers(RankedAlliancePaginationSource origin, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedAlliancePagination> PromiseGetFromStatisticsAlliancesRankDefenders(out RankedAlliancePagination cacheObject, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedAlliancePagination GetNoFetchFromStatisticsAlliancesRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankDefenders(bool forceRefresh, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		public static RankedAlliancePagination GetFromStatisticsAlliancesRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		private static RankedAlliancePagination FetchFromStatisticsAlliancesRankDefenders(RankedAlliancePaginationSource origin, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsAlliancesRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromStatisticsAlliancesRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromStatisticsAlliancesRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<RankedAlliance> CreateListItems() => default;
		public List<RankedAlliance> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<RankedAlliance>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<RankedAlliance>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
