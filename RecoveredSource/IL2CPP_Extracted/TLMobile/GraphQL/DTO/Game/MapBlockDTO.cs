// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapBlockDTO
	{
		// Fields
		public int? xMin;
		public int? yMin;
		public int? xMax;
		public int? yMax;
		public string hash;
		public List<MapPlayerDataDTO> playerData;
		public List<VillageDTO> villages;
		public List<JObject> oases;
	
		// Constructors
		public MapBlockDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
