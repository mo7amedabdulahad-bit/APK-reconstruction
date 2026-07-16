// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteDTO
	{
		// Fields
		public int? id;
		public bool? enabled;
		public bool? sendOnce;
		public ResourcesAmountDTO carriedResources;
		public int? departureAt;
		public int? arrivalAt;
		public int? repeat;
		public int? merchants;
		public int? ships;
		public bool? useTradeShips;
	
		// Constructors
		public TradeRouteDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
