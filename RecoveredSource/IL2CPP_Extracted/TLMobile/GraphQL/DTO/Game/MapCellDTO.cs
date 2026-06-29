// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapCellDTO
	{
		// Fields
		public int? id;
		public int? x;
		public int? y;
		public int? type;
		public int? groundType;
		public int? regionId;
		public int? landDistribution;
		public VillageDTO village;
		public JObject oasis;
		public List<MapShapeDTO> shapes;
	
		// Constructors
		public MapCellDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
