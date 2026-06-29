// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WorldEndAnnualSpecialNotificationDTO
	{
		// Fields
		public int? id;
		public List<PlayerDTO> topPlayers;
		public PlayerDTO topAttacker;
		public PlayerDTO topDefender;
		public int? worldEndTime;
		public List<AllianceDTO> topAlliances;
		public int? victoryPointsTop1;
	
		// Constructors
		public WorldEndAnnualSpecialNotificationDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
