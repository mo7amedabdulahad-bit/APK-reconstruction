// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroInventoryItemDTO
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
		public int? placeId;
		public string place;
		public int? amount;
		public bool? canBeUsed;
		public string popupMessage;
		public string errorMessage;
		public string tooltipErrorMessage;
		public string warningMessage;
		public int? maxInput;
		public int? minInput;
		public int? defaultInput;
		public int? alreadyEquipped;
		public bool? isEquipped;
		public bool? canBeClicked;
		public ClickShortDescriptionDTO clickShortDescription;
		public InventoryItemCooldownDTO cooldown;
	
		// Constructors
		public HeroInventoryItemDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
