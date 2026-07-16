// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PopulationRankDTO
	{
		// Fields
		public int? serverAge;
		public bool? hasAlliance;
		public int? currentWorldPosition;
		public int? currentAlliancePosition;
		public List<DailyRankDTO> worldRankPlot;
		public List<DailyRankDTO> allianceRankPlot;
	
		// Constructors
		public PopulationRankDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
