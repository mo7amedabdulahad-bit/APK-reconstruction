// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerDTO
	{
		// Fields
		public int? id;
		public string uuid;
		public int? tribeId;
		public string name;
		public AllianceDTO alliance;
		public ProfileDTO profile;
		public HeroDTO hero;
		public PlayerRanksDTO ranks;
		public int? villagesCount;
		public int? beginnersProtection;
		public PlayerRelationType? relation;
		public bool? isInVacationMode;
	
		// Constructors
		public PlayerDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
