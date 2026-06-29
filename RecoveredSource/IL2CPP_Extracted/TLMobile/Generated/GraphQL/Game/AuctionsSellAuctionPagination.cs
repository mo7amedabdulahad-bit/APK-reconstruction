// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsSellAuctionPagination : GraphQLFetchable, IPaginatedObject<AuctionsSellAuction>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<AuctionsSellAuctionEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int auctionsFirstFromOwnPlayerAuctionsSellAuctions;
		private string auctionsAfterFromOwnPlayerAuctionsSellAuctions;
		private SellAuctionsSortBy? auctionsSortByFromOwnPlayerAuctionsSellAuctions;
		private SortOrder? auctionsSortOrderFromOwnPlayerAuctionsSellAuctions;
		private SellAuctionsFilter auctionsFilterFromOwnPlayerAuctionsSellAuctions;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAuctionsSellAuctions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AuctionsSellAuctionPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AuctionsSellAuctionEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AuctionsSellAuctionPaginationSource
		{
			FromOwnPlayerAuctionsSellAuctions = 0
		}
	
		// Constructors
		public AuctionsSellAuctionPagination() {}
		static AuctionsSellAuctionPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionsSellAuctionPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionsSellAuctionPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<AuctionsSellAuctionEdge> to, List<AuctionsSellAuctionEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AuctionsSellAuctionPagination> PromiseGetFromOwnPlayerAuctionsSellAuctions(int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionsSellAuctionPagination> PromiseGetFromOwnPlayerAuctionsSellAuctions(out AuctionsSellAuctionPagination cacheObject, int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionsSellAuctionPagination GetNoFetchFromOwnPlayerAuctionsSellAuctions(int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		public static AuctionsSellAuctionPagination GetFromOwnPlayerAuctionsSellAuctions(bool forceRefresh, int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		public static AuctionsSellAuctionPagination GetFromOwnPlayerAuctionsSellAuctions(int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All) => default;
		private static AuctionsSellAuctionPagination FetchFromOwnPlayerAuctionsSellAuctions(AuctionsSellAuctionPaginationSource origin, int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerAuctionsSellAuctions(int auctionsFirst = 10, string auctionsAfter = null, SellAuctionsSortBy? auctionsSortBy = default, SortOrder? auctionsSortOrder = default, SellAuctionsFilter auctionsFilter = null, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<AuctionsSellAuction> CreateListItems() => default;
		public List<AuctionsSellAuction> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<AuctionsSellAuction>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
		void IPaginatedObject<AuctionsSellAuction>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
	}
