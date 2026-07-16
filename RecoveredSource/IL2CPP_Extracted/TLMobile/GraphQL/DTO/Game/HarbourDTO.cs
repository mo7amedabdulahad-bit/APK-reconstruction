// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HarbourDTO
	{
		// Fields
		public List<ShipAmountDTO> availableShips;
		public List<ShipAmountDTO> shipsOnTheWay;
		public List<ShipInProductionEntryDTO> inProduction;
		public int? nextShipIsReadyAt;
	
		// Constructors
		public HarbourDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
