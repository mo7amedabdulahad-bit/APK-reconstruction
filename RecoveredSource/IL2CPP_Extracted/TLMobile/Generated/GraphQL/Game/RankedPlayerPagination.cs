// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RankedPlayerPagination : GraphQLFetchable, IPaginatedObject<RankedPlayer>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<RankedPlayerEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int? overviewFirstFromStatisticsPlayersRankOverview;
		private string overviewAfterFromStatisticsPlayersRankOverview;
		private int? overviewLastFromStatisticsPlayersRankOverview;
		private string overviewBeforeFromStatisticsPlayersRankOverview;
		private int? overviewRankFromStatisticsPlayersRankOverview;
		private string overviewNameFromStatisticsPlayersRankOverview;
		private int? attackersFirstFromStatisticsPlayersRankAttackers;
		private string attackersAfterFromStatisticsPlayersRankAttackers;
		private int? attackersLastFromStatisticsPlayersRankAttackers;
		private string attackersBeforeFromStatisticsPlayersRankAttackers;
		private int? attackersRankFromStatisticsPlayersRankAttackers;
		private string attackersNameFromStatisticsPlayersRankAttackers;
		private int? defendersFirstFromStatisticsPlayersRankDefenders;
		private string defendersAfterFromStatisticsPlayersRankDefenders;
		private int? defendersLastFromStatisticsPlayersRankDefenders;
		private string defendersBeforeFromStatisticsPlayersRankDefenders;
		private int? defendersRankFromStatisticsPlayersRankDefenders;
		private string defendersNameFromStatisticsPlayersRankDefenders;
		private static readonly string[] namesInNestedResponseFromStatisticsPlayersRankOverview;
		private static readonly string[] namesInNestedResponseFromStatisticsPlayersRankAttackers;
		private static readonly string[] namesInNestedResponseFromStatisticsPlayersRankDefenders;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public RankedPlayerPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedPlayerEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum RankedPlayerPaginationSource
		{
			FromStatisticsPlayersRankOverview = 0,
			FromStatisticsPlayersRankAttackers = 1,
			FromStatisticsPlayersRankDefenders = 2
		}
	
		// Constructors
		public RankedPlayerPagination() {}
		static RankedPlayerPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RankedPlayerPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RankedPlayerPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<RankedPlayerEdge> to, List<RankedPlayerEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankOverview(out RankedPlayerPagination cacheObject, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedPlayerPagination GetNoFetchFromStatisticsPlayersRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankOverview(bool forceRefresh, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All) => default;
		private static RankedPlayerPagination FetchFromStatisticsPlayersRankOverview(RankedPlayerPaginationSource origin, int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankAttackers(out RankedPlayerPagination cacheObject, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedPlayerPagination GetNoFetchFromStatisticsPlayersRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankAttackers(bool forceRefresh, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All) => default;
		private static RankedPlayerPagination FetchFromStatisticsPlayersRankAttackers(RankedPlayerPaginationSource origin, int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<RankedPlayerPagination> PromiseGetFromStatisticsPlayersRankDefenders(out RankedPlayerPagination cacheObject, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static RankedPlayerPagination GetNoFetchFromStatisticsPlayersRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankDefenders(bool forceRefresh, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		public static RankedPlayerPagination GetFromStatisticsPlayersRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All) => default;
		private static RankedPlayerPagination FetchFromStatisticsPlayersRankDefenders(RankedPlayerPaginationSource origin, int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsPlayersRankOverview(int? overviewFirst = default, string overviewAfter = null, int? overviewLast = default, string overviewBefore = null, int? overviewRank = default, string overviewName = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromStatisticsPlayersRankAttackers(int? attackersFirst = default, string attackersAfter = null, int? attackersLast = default, string attackersBefore = null, int? attackersRank = default, string attackersName = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromStatisticsPlayersRankDefenders(int? defendersFirst = default, string defendersAfter = null, int? defendersLast = default, string defendersBefore = null, int? defendersRank = default, string defendersName = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<RankedPlayer> CreateListItems() => default;
		public List<RankedPlayer> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<RankedPlayer>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<RankedPlayer>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
