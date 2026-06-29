// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionInterfaceDTO
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
	
		// Constructors
		public AuctionInterfaceDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
