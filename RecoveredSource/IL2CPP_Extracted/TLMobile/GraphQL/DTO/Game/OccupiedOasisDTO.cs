// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OccupiedOasisDTO
	{
		// Fields
		public int? id;
		public int? x;
		public int? y;
		public int? type;
		public ResourcesAmountDTO bonusResources;
		public VillageDTO belongsTo;
		public int? loyalty;
		public int? conquered;
		public int? finishedAt;
	
		// Constructors
		public OccupiedOasisDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
