// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldDTO
	{
		// Fields
		public string uuid;
		public string name;
		public string domain;
		public int? start;
		public int? end;
		public GameworldMetadataDTO metadata;
		public GameworldFlagsDTO flags;
		public GameworldInfoDTO info;
	
		// Constructors
		public GameworldDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
