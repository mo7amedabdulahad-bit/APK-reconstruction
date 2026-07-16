// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WallDTO
	{
		// Fields
		public int? id;
		public int? buildingTypeId;
		public int? slotId;
		public int? level;
		public int? levelUpdateTimestamp;
		public int? watchtowersLevel;
		public List<BuildEventDTO> watchtowersInUpgrade;
	
		// Constructors
		public WallDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
