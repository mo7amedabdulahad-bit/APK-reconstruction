// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Marketplace : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<MarketplaceOwnOffer> _ownOffers;
		[ObservableValue]
		private GraphQLObservableList<OwnMerchantMovement> _ownMerchantsMovements;
		[ObservableValue]
		private GraphQLObservableList<TradeRoutesSet> _tradeRoutes;
		[ObservableValue]
		private TradeRoute _nextDelivery;
		[ObservableValue]
		private OwnMerchantMovementPaginationConnection _outgoingMerchants;
		[ObservableValue]
		private OwnMerchantMovementPaginationConnection _merchantsMovements;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private MerchantsInfo _tradeShipsInfo;
		[ObservableValue]
		private int? _tradeShipCapacity;
		[ObservableValue]
		private GraphQLObservableList<Destination> _destinations;
		private static string FromOwnVillageMarketplaceOutgoingMerchantsArgumentAfter;
		private static int? FromOwnVillageMarketplaceOutgoingMerchantsArgumentFirst;
		private static string FromOwnVillageMarketplaceMerchantsMovementsArgumentAfter;
		private static int? FromOwnVillageMarketplaceMerchantsMovementsArgumentFirst;
		private int ownVillageIdFromOwnVillageMarketplace;
		private static readonly string[] namesInNestedResponseFromOwnVillageMarketplace;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MarketplaceSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<MarketplaceOwnOffer> ownOffers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnMerchantMovement> ownMerchantsMovements { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TradeRoutesSet> tradeRoutes { get => default; set {} }
		[ObservableValue]
		public TradeRoute nextDelivery { get => default; set {} }
		[ObservableValue]
		public OwnMerchantMovementPaginationConnection outgoingMerchants { get => default; set {} }
		[ObservableValue]
		public OwnMerchantMovementPaginationConnection merchantsMovements { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo tradeShipsInfo { get => default; set {} }
		[ObservableValue]
		public int? tradeShipCapacity { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Destination> destinations { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OwnMerchants = 1,
			OnlyInfos = 2
		}
	
		public enum MarketplaceSource
		{
			FromOwnVillageMarketplace = 0
		}
	
		// Constructors
		public Marketplace() {}
		static Marketplace() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MarketplaceDTO dtoValue) => default;
		private bool EqualToDTOOwnMerchants(MarketplaceDTO dtoValue) => default;
		private bool EqualToDTOOnlyInfos(MarketplaceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MarketplaceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOwnMerchants(MarketplaceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyInfos(MarketplaceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListOwnOffers(GraphQLObservableList<MarketplaceOwnOffer> to, List<MarketplaceOwnOfferDTO> from, int query) => default;
		private bool CopyValuesFromDtoListOwnMerchantsMovements(GraphQLObservableList<OwnMerchantMovement> to, List<OwnMerchantMovementDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTradeRoutes(GraphQLObservableList<TradeRoutesSet> to, List<TradeRoutesSetDTO> from, int query) => default;
		private bool CopyValuesFromDtoListDestinations(GraphQLObservableList<Destination> to, List<DestinationDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Marketplace> PromiseGetFromOwnVillageMarketplace(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Marketplace> PromiseGetFromOwnVillageMarketplace(out Marketplace cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Marketplace GetNoFetchFromOwnVillageMarketplace(int ownVillageId, Query query = Query.All) => default;
		public static Marketplace GetFromOwnVillageMarketplace(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Marketplace GetFromOwnVillageMarketplace(int ownVillageId, Query query = Query.All) => default;
		private static Marketplace FetchFromOwnVillageMarketplace(MarketplaceSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageMarketplace(int ownVillageId, object dummy = null) => default;
		private void _ownOffersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _ownMerchantsMovementsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _tradeRoutesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _destinationsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
