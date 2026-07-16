// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEventDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? type;
		public RemovablePlayerDTO player1;
		public RemovablePlayerDTO player2;
		public AllianceDTO alliance1;
		public AllianceDTO alliance2;
		public int? x;
		public int? y;
		public int? statPlace;
		public int? statType;
		public string artifactName;
	
		// Constructors
		public AllianceEventDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
