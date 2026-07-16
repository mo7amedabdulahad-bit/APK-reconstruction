// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportBattleStatisticsEntryDTO
	{
		// Fields
		[JsonProperty("strength")]
		public int? strengthInt32;
		[JsonProperty("supplyBefore")]
		public int? supplyBeforeInt32;
		[JsonProperty("supplyLost")]
		public int? supplyLostInt32;
		[JsonProperty("resourcesLost")]
		public int? resourcesLostInt32;
	
		// Constructors
		public ReportBattleStatisticsEntryDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
