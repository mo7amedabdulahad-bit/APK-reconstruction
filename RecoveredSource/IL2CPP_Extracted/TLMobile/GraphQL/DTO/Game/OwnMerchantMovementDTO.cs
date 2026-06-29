// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnMerchantMovementDTO
	{
		// Fields
		public int? id;
		public MerchantEventType? type;
		public PlayerDTO sender;
		public RemovablePlayerDTO customer;
		public int? route;
		public VillageDTO from;
		public VillageDTO to;
		public int? oneWayDuration;
		public int? arrivalAt;
		public ResourcesAmountDTO carriedResources;
		public ResourcesAmountDTO merchantsCapacity;
		public int? runs;
		public int? merchantsAmount;
		public float? distance;
		public List<MerchantMovementHistoryDTO> history;
		public bool? useTradeShips;
		public int? cancelDeliveryUntil;
		public bool? cancelled;
	
		// Constructors
		public OwnMerchantMovementDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
