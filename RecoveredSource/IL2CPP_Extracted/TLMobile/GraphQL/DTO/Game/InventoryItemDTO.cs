// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryItemDTO
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
		public int? id;
	
		// Constructors
		public InventoryItemDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
