// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootstrapDataDTO
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
		[Obsolete("Moved to configuration fields, type changed. New Field: serverConfiguration.tribeNames")]
		public List<TribeDTO> tribes;
		[JsonProperty("buildings")]
		public List<BootstrapBuildingDTO> buildingsRaw;
		public GoldActionPricesDTO goldActionPrices;
		[Obsolete("Moved to configuration fields. New Field: serverConfiguration.mapConfiguration")]
		public MapConfigurationDTO mapConfiguration;
		public string serverTitle;
		public ServerSupportedFeaturesDTO serverSupportedFeatures;
		public ServerConfigurationDTO serverConfiguration;
		public List<LanguageDTO> languages;
		public int? timestamp;
		public int? lastResetTimestamp;
		public int? nextResetTimestamp;
		public string serverTimezoneOffset;
		public string releaseVersion;
		public int? settlersAmountToFoundVillage;
		public AuctionConfigurationDTO auction;
		public TLMobile.GraphQL.DTO.Game.GameworldDTO gameworld;
		public int? requiredMainBuildingLevelForDemolition;
	
		// Constructors
		public BootstrapDataDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
