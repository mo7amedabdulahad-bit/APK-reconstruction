// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TrainingBatchDTO
	{
		// Fields
		public int? eventId;
		public BuildingDTO building;
		public UnitDTO unit;
		public int? unitsLeft;
		public int? timePerUnit;
		public int? nextUnitReadyAt;
		public int? lastUnitReadyAt;
		public int? cancellableUntil;
	
		// Constructors
		public TrainingBatchDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
