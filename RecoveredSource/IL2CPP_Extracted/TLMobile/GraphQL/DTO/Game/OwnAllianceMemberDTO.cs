// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceMemberDTO
	{
		// Fields
		public PlayerDTO player;
		public string position;
		public AllianceAttacksDTO attacksOnMember;
		public int? victoryPoints;
		public float? victoryPointsPerDay;
		public int? onlineStatus;
		public string onlineStatusTitle;
		public OwnAllianceMemberSpecialization? specialization;
		public int? joinAt;
		public AllianceMemberPermissionsDTO permissions;
	
		// Constructors
		public OwnAllianceMemberDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
