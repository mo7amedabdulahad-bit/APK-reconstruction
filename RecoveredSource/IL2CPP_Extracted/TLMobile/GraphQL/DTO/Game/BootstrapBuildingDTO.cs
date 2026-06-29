// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootstrapBuildingDTO
	{
		// Fields
		public int? type;
		public List<int?> validTribes;
		public List<int?> validVillageTypes;
		public int? maxPerVillage;
		public int? maxLevel;
		public List<List<RequiredBuildingDTO>> requiredBuildings;
		public int? category;
		public int? sortIndex;
		public int? baseBuildingTime;
		public float? buildingTimeFactor;
		public int? additionalBuildingTime;
		public List<BootstrapBuildingLevelDTO> levels;
		public List<BuildingRestriction?> restrictions;
		public BootstrapBuildingExtensionDTO extension;
	
		// Constructors
		public BootstrapBuildingDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
