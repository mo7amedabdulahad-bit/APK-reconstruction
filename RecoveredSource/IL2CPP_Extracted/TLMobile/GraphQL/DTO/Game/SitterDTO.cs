// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SitterDTO
	{
		// Fields
		public int? sittingId;
		public PlayerDTO player;
		public AccessRightsDTO sitterPermissions;
		public bool? loggedIn;
		public bool? loginIsPossible;
		public string loginImpossibleError;
	
		// Constructors
		public SitterDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
