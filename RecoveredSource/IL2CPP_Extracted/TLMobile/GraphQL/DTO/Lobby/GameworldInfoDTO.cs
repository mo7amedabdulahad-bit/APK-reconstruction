// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldInfoDTO
	{
		// Fields
		public int? ageInDays;
		public int? playersCount;
		public int? artefactsDate;
		public int? artefactsInDays;
		public int? constructionPlansDate;
		public int? constructionPlansInDays;
		public int? wwLevel;
		public int? wwTribeId;
		public List<GameworldInfoTribeDTO> tribes;
		public GameworldInfoMapDTO mapConfiguration;
		public GameworldInfoFeaturesDTO serverSupportedFeatures;
		public GameworldInfoConfigurationDTO serverConfiguration;
	
		// Constructors
		public GameworldInfoDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
