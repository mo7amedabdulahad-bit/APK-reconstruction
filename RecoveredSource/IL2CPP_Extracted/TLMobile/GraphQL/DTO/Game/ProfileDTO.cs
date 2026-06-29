// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProfileDTO
	{
		// Fields
		public List<MedalGameworldDTO> medalsGameworld;
		public List<MedalLifetimeDTO> medalsLifetime;
		public bool? ownProfile;
		public bool? isNPC;
		public bool? allowEdit;
		public Gender? gender;
		public string location;
		public string personalNote;
		public string language;
		public List<string> additionalLanguages;
		public bool? showCountryFlag;
		public CountryFlagDTO countryFlag;
		public DescriptionDTO descriptionPlain;
		public DescriptionDTO descriptionHtml;
		public bool? interactionPossible;
		public bool? ignoredListIsFull;
		public bool? allowedToIgnore;
		public bool? isPlayerIgnoring;
		public bool? isPlayerInvited;
		public bool? isAllianceMember;
		public int? daysPlaying;
	
		// Constructors
		public ProfileDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
