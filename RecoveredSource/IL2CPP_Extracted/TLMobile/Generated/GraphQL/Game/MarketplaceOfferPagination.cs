// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketplaceOfferPagination : GraphQLFetchable, IPaginatedObject<MarketplaceOffer>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<MarketplaceOfferEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int ownVillageIdFromOwnVillageMarketplaceOffers;
		private int? offersFirstFromOwnVillageMarketplaceOffers;
		private string offersAfterFromOwnVillageMarketplaceOffers;
		private MarketplaceOffersFilter offersFilterFromOwnVillageMarketplaceOffers;
		private MarketplaceOffersSortBy? offersSortByFromOwnVillageMarketplaceOffers;
		private SortOrder? offersSortOrderFromOwnVillageMarketplaceOffers;
		private static readonly string[] namesInNestedResponseFromOwnVillageMarketplaceOffers;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MarketplaceOfferPaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MarketplaceOfferEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MarketplaceOfferPaginationSource
		{
			FromOwnVillageMarketplaceOffers = 0
		}
	
		// Constructors
		public MarketplaceOfferPagination() {}
		static MarketplaceOfferPagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MarketplaceOfferPaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MarketplaceOfferPaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<MarketplaceOfferEdge> to, List<MarketplaceOfferEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MarketplaceOfferPagination> PromiseGetFromOwnVillageMarketplaceOffers(int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MarketplaceOfferPagination> PromiseGetFromOwnVillageMarketplaceOffers(out MarketplaceOfferPagination cacheObject, int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MarketplaceOfferPagination GetNoFetchFromOwnVillageMarketplaceOffers(int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All) => default;
		public static MarketplaceOfferPagination GetFromOwnVillageMarketplaceOffers(bool forceRefresh, int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All) => default;
		public static MarketplaceOfferPagination GetFromOwnVillageMarketplaceOffers(int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All) => default;
		private static MarketplaceOfferPagination FetchFromOwnVillageMarketplaceOffers(MarketplaceOfferPaginationSource origin, int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageMarketplaceOffers(int ownVillageId, int? offersFirst = default, string offersAfter = null, MarketplaceOffersFilter offersFilter = null, MarketplaceOffersSortBy? offersSortBy = default, SortOrder? offersSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<MarketplaceOffer> CreateListItems() => default;
		public List<MarketplaceOffer> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<MarketplaceOffer>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<MarketplaceOffer>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
