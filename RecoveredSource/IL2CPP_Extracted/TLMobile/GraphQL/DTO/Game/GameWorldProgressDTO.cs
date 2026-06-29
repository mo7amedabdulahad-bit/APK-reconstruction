// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameWorldProgressDTO
	{
		// Fields
		public int? serverAge;
		public int? activatedPlayers;
		public List<GameWorldProgressStageDTO> stages;
		public List<TribeDistributionDTO> tribeDistribution;
	
		// Constructors
		public GameWorldProgressDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
