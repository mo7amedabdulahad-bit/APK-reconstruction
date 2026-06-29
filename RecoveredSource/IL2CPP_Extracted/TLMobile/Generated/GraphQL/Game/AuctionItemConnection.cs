// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionItemConnection : GraphQLFetchable, IPaginatedObject<AuctionItem>
	{
		// Fields
		[ObservableValue]
		private PageInfo _pageInfo;
		[ObservableValue]
		private GraphQLObservableList<AuctionItemEdge> _edges;
		[ObservableValue]
		private int _totalCount;
		private string itemsAfterFromOwnPlayerAuctionsItems;
		private int? itemsFirstFromOwnPlayerAuctionsItems;
		private AuctionItemsFilter itemsFilterFromOwnPlayerAuctionsItems;
		private AuctionItemsSortBy? itemsSortByFromOwnPlayerAuctionsItems;
		private SortOrder? itemsSortOrderFromOwnPlayerAuctionsItems;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAuctionsItems;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AuctionItemConnectionSource Source { get; set; }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AuctionItemEdge> edges { get => default; set {} }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AuctionItemConnectionSource
		{
			FromOwnPlayerAuctionsItems = 0
		}
	
		// Constructors
		public AuctionItemConnection() {}
		static AuctionItemConnection() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionItemConnectionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionItemConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<AuctionItemEdge> to, List<AuctionItemEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AuctionItemConnection> PromiseGetFromOwnPlayerAuctionsItems(string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionItemConnection> PromiseGetFromOwnPlayerAuctionsItems(out AuctionItemConnection cacheObject, string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionItemConnection GetNoFetchFromOwnPlayerAuctionsItems(string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All) => default;
		public static AuctionItemConnection GetFromOwnPlayerAuctionsItems(bool forceRefresh, string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All) => default;
		public static AuctionItemConnection GetFromOwnPlayerAuctionsItems(string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All) => default;
		private static AuctionItemConnection FetchFromOwnPlayerAuctionsItems(AuctionItemConnectionSource origin, string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerAuctionsItems(string itemsAfter = null, int? itemsFirst = default, AuctionItemsFilter itemsFilter = null, AuctionItemsSortBy? itemsSortBy = default, SortOrder? itemsSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<AuctionItem> CreateListItems() => default;
		public List<AuctionItem> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<AuctionItem>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
		void IPaginatedObject<AuctionItem>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
	}
