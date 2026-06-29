// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AncientPowerDTO
	{
		// Fields
		public int? id;
		public string objectId;
		public string name;
		public int? type;
		public bool? isFool;
		public bool? isUnique;
		public ArtefactScope? scope;
		public float? bonus;
		public int? requiredLevel;
		public AllianceDTO owner;
		public RegionDTO region;
		public AncientPowerStatus? status;
		public AncientPowerStatusMessageDTO statusMessage;
		public bool? increasedVpProduction;
	
		// Constructors
		public AncientPowerDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
