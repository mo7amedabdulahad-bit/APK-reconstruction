	public class AuctionItemDTO
	{
		// Fields
		public int? typeId;
		public string name;
		public bool? isConsumable;
		public bool? isUsableIfDead;
		public bool? isAuctionable;
		public bool? isCrafting;
		public List<InventoryItemAttributesDTO> attributes;
		public string slot;
		public int? quality;
		public Rarity? rarity;
		public List<int?> possibleAmountsToSell;
		public int? itemsCount;
		public int? auctionsCount;
		public int? nextFinishAt;
		public int? averagePrice;
		public int? nextPrice;
	
		// Constructors
		public AuctionItemDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
