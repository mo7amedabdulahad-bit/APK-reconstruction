// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AttackReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? readStatus;
		public string title;
		public int? ownerId;
		public string authKey;
		public int? icon;
		public ReportParticipantDTO attacker;
		public TroopInBattleDTO attackerTroop;
		public List<ReportInformationItemDTO> attackerInformation;
		public BootyDTO attackerBooty;
		public ReportParticipantDTO defender;
		public TroopInBattleDTO defenderTroop;
		public List<ReportInformationItemDTO> defenderInformation;
		public List<TroopInBattleDTO> reinforcements;
		public ReportBattleStatisticsDTO statistics;
		public string description;
		public bool? ship;
	
		// Constructors
		public AttackReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
