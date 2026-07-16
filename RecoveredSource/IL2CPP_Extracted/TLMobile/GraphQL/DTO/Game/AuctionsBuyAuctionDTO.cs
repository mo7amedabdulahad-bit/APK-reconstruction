// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsBuyAuctionDTO
	{
		// Fields
		public string identifier;
		public ItemDTO item;
		public int? amount;
		public BidStatus? status;
		public int? startedAt;
		public int? finishedAt;
		public int? price;
		public int? bidsAmount;
		public int? maxBid;
		public PlayerDTO highestBidder;
	
		// Constructors
		public AuctionsBuyAuctionDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
