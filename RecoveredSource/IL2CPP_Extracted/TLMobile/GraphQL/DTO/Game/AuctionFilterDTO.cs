// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionFilterDTO
	{
		// Fields
		public List<TLMobile.Generated.GraphQL.Game.ItemType?> itemTypes;
		public List<InventoryItemSlot?> itemSlots;
		public List<int?> itemIds;
		public int? amount;
		public Rarity? rarity;
		public int? finishAfter;
	
		// Constructors
		public AuctionFilterDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
