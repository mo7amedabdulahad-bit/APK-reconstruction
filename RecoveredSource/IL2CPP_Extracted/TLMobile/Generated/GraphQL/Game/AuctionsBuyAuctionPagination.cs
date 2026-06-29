// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsBuyAuctionPagination : GraphQLFetchable, IPaginatedObject<AuctionsBuyAuction>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<AuctionsBuyAuctionEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private AuctionFilter buyFilterFromOwnPlayerAuctionsBuy;
		private int buyFirstFromOwnPlayerAuctionsBuy;
		private string buyAfterFromOwnPlayerAuctionsBuy;
		private AuctionsSortBy? buySortByFromOwnPlayerAuctionsBuy;
		private SortOrder? buySortOrderFromOwnPlayerAuctionsBuy;
		private int auctionsFirstFromOwnPlayerAuctionsBidsAuctions;
		private string auctionsAfterFromOwnPlayerAuctionsBidsAuctions;
		private AuctionsBidsSortBy? auctionsSortByFromOwnPlayerAuctionsBidsAuctions;
		private SortOrder? auctionsSortOrderFromOwnPlayerAuctionsBidsAuctions;
		private BidsAuctionsFilter auctionsFilterFromOwnPlayerAuctionsBidsAuctions;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAuctionsBuy;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAuctionsBidsAuctions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AuctionsBuyAuctionPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AuctionsBuyAuctionEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AuctionsBuyAuctionPaginationSource
		{
			FromOwnPlayerAuctionsBuy = 0,
			FromOwnPlayerAuctionsBidsAuctions = 1
		}
	
		// Constructors
		public AuctionsBuyAuctionPagination() {}
		static AuctionsBuyAuctionPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionsBuyAuctionPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionsBuyAuctionPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<AuctionsBuyAuctionEdge> to, List<AuctionsBuyAuctionEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AuctionsBuyAuctionPagination> PromiseGetFromOwnPlayerAuctionsBuy(AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionsBuyAuctionPagination> PromiseGetFromOwnPlayerAuctionsBuy(out AuctionsBuyAuctionPagination cacheObject, AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionsBuyAuctionPagination GetNoFetchFromOwnPlayerAuctionsBuy(AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All) => default;
		public static AuctionsBuyAuctionPagination GetFromOwnPlayerAuctionsBuy(bool forceRefresh, AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All) => default;
		public static AuctionsBuyAuctionPagination GetFromOwnPlayerAuctionsBuy(AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All) => default;
		private static AuctionsBuyAuctionPagination FetchFromOwnPlayerAuctionsBuy(AuctionsBuyAuctionPaginationSource origin, AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<AuctionsBuyAuctionPagination> PromiseGetFromOwnPlayerAuctionsBidsAuctions(int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionsBuyAuctionPagination> PromiseGetFromOwnPlayerAuctionsBidsAuctions(out AuctionsBuyAuctionPagination cacheObject, int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionsBuyAuctionPagination GetNoFetchFromOwnPlayerAuctionsBidsAuctions(int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		public static AuctionsBuyAuctionPagination GetFromOwnPlayerAuctionsBidsAuctions(bool forceRefresh, int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		public static AuctionsBuyAuctionPagination GetFromOwnPlayerAuctionsBidsAuctions(int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		private static AuctionsBuyAuctionPagination FetchFromOwnPlayerAuctionsBidsAuctions(AuctionsBuyAuctionPaginationSource origin, int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerAuctionsBuy(AuctionFilter buyFilter = null, int buyFirst = 10, string buyAfter = null, AuctionsSortBy? buySortBy = default, SortOrder? buySortOrder = default, object dummy = null) => default;
		private static string GetRequestBodyPartFromOwnPlayerAuctionsBidsAuctions(int auctionsFirst = 10, string auctionsAfter = null, AuctionsBidsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, BidsAuctionsFilter auctionsFilter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<AuctionsBuyAuction> CreateListItems() => default;
		public List<AuctionsBuyAuction> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<AuctionsBuyAuction>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
		void IPaginatedObject<AuctionsBuyAuction>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
	}
