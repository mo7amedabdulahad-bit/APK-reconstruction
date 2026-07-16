// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AvatarDTO
	{
		// Fields
		public IdentityDTO identity;
		public string uuid;
		public string name;
		public List<DualDTO> duals;
		public TLMobile.GraphQL.DTO.Lobby.GameworldDTO gameworld;
		public TLMobile.Generated.GraphQL.Lobby.AvatarAccessType? type;
		public AvatarDetailsDTO details;
		public bool? isLegacy;
		public int? inDeletionAt;
		public bool? inDeletionImminent;
		public int? inVacation;
	
		// Constructors
		public AvatarDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
