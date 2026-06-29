// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryItemAttributesDTO
	{
		// Fields
		public EffectType? effectType;
		public bool? sign;
		public float? value;
		public string unit;
		public int? tribeId;
		public string unitId;
		public string descriptionTranslationKey;
		public List<NameValueContainerDTO> descriptionPlaceholders;
		public string description;
		public string descriptionDetails;
	
		// Constructors
		public InventoryItemAttributesDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
		public static explicit operator InventoryItemAttributesDTO(InventoryItemAttributes obj) => default;
	}
