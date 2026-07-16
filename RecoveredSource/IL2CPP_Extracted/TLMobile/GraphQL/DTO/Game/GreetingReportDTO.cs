// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GreetingReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? readStatus;
		public string title;
		public int? ownerId;
		public ReportParticipantDTO attacker;
		public TroopInBattleDTO attackerTroop;
		public ReportParticipantDTO defender;
		public TruceDTO truce;
	
		// Constructors
		public GreetingReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
