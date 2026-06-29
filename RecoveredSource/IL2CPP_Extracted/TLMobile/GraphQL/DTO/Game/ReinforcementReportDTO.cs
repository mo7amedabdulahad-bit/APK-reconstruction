// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReinforcementReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? readStatus;
		public string title;
		public int? ownerId;
		public int? icon;
		public ReportParticipantDTO sender;
		public ReportParticipantDTO defender;
		public TroopInBattleDTO troop;
		public int? duration;
		public int? consumption;
		public bool? failed;
		public int? failureReason;
		public bool? ship;
	
		// Constructors
		public ReinforcementReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
