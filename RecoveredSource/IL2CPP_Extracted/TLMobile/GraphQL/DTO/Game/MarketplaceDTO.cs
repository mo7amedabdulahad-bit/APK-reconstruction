// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketplaceDTO
	{
		// Fields
		public List<MarketplaceOwnOfferDTO> ownOffers;
		public List<OwnMerchantMovementDTO> ownMerchantsMovements;
		public List<TradeRoutesSetDTO> tradeRoutes;
		public TradeRouteDTO nextDelivery;
		public OwnMerchantMovementPaginationConnectionDTO outgoingMerchants;
		public OwnMerchantMovementPaginationConnectionDTO merchantsMovements;
		public MerchantsInfoDTO merchantsInfo;
		public MerchantsInfoDTO tradeShipsInfo;
		public int? tradeShipCapacity;
		public List<DestinationDTO> destinations;
	
		// Constructors
		public MarketplaceDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
