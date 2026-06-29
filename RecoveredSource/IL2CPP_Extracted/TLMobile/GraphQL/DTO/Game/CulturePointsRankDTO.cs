// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CulturePointsRankDTO
	{
		// Fields
		public int? totalPlayers;
		public TotalRankDTO perDayRank;
		public int? perDayProduction;
		public TotalRankDTO soFarRank;
		public int? soFarProduction;
		public CulturePointsDistributionDTO distribution;
		public CulturePointsProgressionDTO progression;
	
		// Constructors
		public CulturePointsRankDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
