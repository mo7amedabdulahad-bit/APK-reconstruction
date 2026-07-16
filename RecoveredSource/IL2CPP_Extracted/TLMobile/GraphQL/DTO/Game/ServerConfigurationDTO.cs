// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerConfigurationDTO
	{
		// Fields
		public int? speed;
		public int? blockWWAttacksUntil;
		public int? ancientPowerCooldown;
		public List<string> languages;
		public int? maxVillageGroupsAmount;
		public MapConfigurationDTO map;
		public List<TribeName?> tribeNames;
	
		// Constructors
		public ServerConfigurationDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
