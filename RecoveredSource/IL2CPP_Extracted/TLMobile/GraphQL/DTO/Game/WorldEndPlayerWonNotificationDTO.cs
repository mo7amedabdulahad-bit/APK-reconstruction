// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WorldEndPlayerWonNotificationDTO
	{
		// Fields
		public int? id;
		public List<PlayerDTO> topPlayers;
		public PlayerDTO topAttacker;
		public PlayerDTO topDefender;
		public int? worldEndTime;
		public TribeDTO tribe;
		public VillageDTO village;
		public PlayerDTO player;
		public AllianceDTO alliance;
	
		// Constructors
		public WorldEndPlayerWonNotificationDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
