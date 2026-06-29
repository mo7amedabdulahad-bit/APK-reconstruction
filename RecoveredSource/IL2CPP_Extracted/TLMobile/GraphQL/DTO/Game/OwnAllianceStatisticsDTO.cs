// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceStatisticsDTO
	{
		// Fields
		public List<OwnAllianceStatisticsStatEntityDTO> strength;
		public List<OwnAllianceStatisticsStatEntityDTO> fightingPoints;
		public int? attackersOfWeekPoints;
		public int? defendersOfWeekPoints;
		public int? climbersOfWeekPoints;
		public int? robbersOfWeekPoints;
		public Top10PlayersOfWeekDTO top10PlayersOfWeek;
	
		// Constructors
		public OwnAllianceStatisticsDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
