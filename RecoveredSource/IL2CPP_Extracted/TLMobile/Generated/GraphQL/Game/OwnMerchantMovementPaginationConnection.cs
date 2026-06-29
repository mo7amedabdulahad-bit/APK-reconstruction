// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnMerchantMovementPaginationConnection : GraphQLFetchable, IPaginatedObject<OwnMerchantMovement>
	{
		// Fields
		[ObservableValue]
		private PageInfo _pageInfo;
		[ObservableValue]
		private GraphQLObservableList<OwnMerchantMovementPaginationEdge> _edges;
		[ObservableValue]
		private int _totalCount;
		private int ownVillageIdFromOwnVillageMarketplaceArrivingMerchants;
		private string arrivingMerchantsAfterFromOwnVillageMarketplaceArrivingMerchants;
		private int? arrivingMerchantsFirstFromOwnVillageMarketplaceArrivingMerchants;
		private ArrivingMerchantsSortBy? arrivingMerchantsSortByFromOwnVillageMarketplaceArrivingMerchants;
		private SortOrder? arrivingMerchantsSortOrderFromOwnVillageMarketplaceArrivingMerchants;
		private static readonly string[] namesInNestedResponseFromOwnVillageMarketplaceArrivingMerchants;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnMerchantMovementPaginationConnectionSource Source { get; set; }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnMerchantMovementPaginationEdge> edges { get => default; set {} }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OwnMerchantMovementPaginationConnectionSource
		{
			FromOwnVillageMarketplaceArrivingMerchants = 0
		}
	
		// Constructors
		public OwnMerchantMovementPaginationConnection() {}
		static OwnMerchantMovementPaginationConnection() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnMerchantMovementPaginationConnectionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnMerchantMovementPaginationConnectionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<OwnMerchantMovementPaginationEdge> to, List<OwnMerchantMovementPaginationEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnMerchantMovementPaginationConnection> PromiseGetFromOwnVillageMarketplaceArrivingMerchants(int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnMerchantMovementPaginationConnection> PromiseGetFromOwnVillageMarketplaceArrivingMerchants(out OwnMerchantMovementPaginationConnection cacheObject, int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnMerchantMovementPaginationConnection GetNoFetchFromOwnVillageMarketplaceArrivingMerchants(int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All) => default;
		public static OwnMerchantMovementPaginationConnection GetFromOwnVillageMarketplaceArrivingMerchants(bool forceRefresh, int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All) => default;
		public static OwnMerchantMovementPaginationConnection GetFromOwnVillageMarketplaceArrivingMerchants(int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All) => default;
		private static OwnMerchantMovementPaginationConnection FetchFromOwnVillageMarketplaceArrivingMerchants(OwnMerchantMovementPaginationConnectionSource origin, int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageMarketplaceArrivingMerchants(int ownVillageId, string arrivingMerchantsAfter = null, int? arrivingMerchantsFirst = default, ArrivingMerchantsSortBy? arrivingMerchantsSortBy = default, SortOrder? arrivingMerchantsSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<OwnMerchantMovement> CreateListItems() => default;
		public List<OwnMerchantMovement> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<OwnMerchantMovement>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<OwnMerchantMovement>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
