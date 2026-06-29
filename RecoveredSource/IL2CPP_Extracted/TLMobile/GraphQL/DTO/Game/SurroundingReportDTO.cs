// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SurroundingReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? type;
		public int? cellId;
		public PlayerDTO activePlayer;
		public string activePlayerName;
		public PlayerDTO passivePlayer;
		public string passivePlayerName;
		public string name1;
		public string name2;
		public VillageDTO village;
		public AllianceDTO alliance1;
		public AllianceDTO alliance2;
	
		// Constructors
		public SurroundingReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
