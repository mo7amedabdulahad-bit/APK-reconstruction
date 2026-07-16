// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRoutesSetDTO
	{
		// Fields
		public string objectId;
		public OwnVillageDTO from;
		public DestinationDTO to;
		public List<TradeRouteDTO> routes;
		public bool? expanded;
		public TradeRouteDTO nextDelivery;
	
		// Constructors
		public TradeRoutesSetDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
