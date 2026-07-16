// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDTO
	{
		// Fields
		public string objectId;
		public int? id;
		public string name;
		public string tag;
		public string description1;
		public string description2;
		public int? rank;
		public float? points;
		public int? membersCount;
		public AllianceBannerDTO banner;
		public List<AllianceMedalDTO> medals;
		public AllianceDiplomacyDTO allianceDiplomacy;
		public List<RegionalTop5DTO> regionalTop5;
		public int? victoryPoints;
		public int? victoryPointsPerDay;
		public int? attackerRank;
		public int? attackerPoints;
		public int? defenderRank;
		public int? defenderPoints;
		public AllianceMemberPermissionsDTO myPermissions;
		public string internalInfo1;
		public string internalInfo2;
		public int? canLeaveAllianceAt;
		public List<AllianceInvitationDTO> sentInvitations;
		public OwnAllianceDiplomacyDTO diplomacy;
		public int? joinAt;
		public AllianceBannerDTO myBanner;
		public List<ProposedDTO> bannersGallery;
		public string forumUrl;
		public bool? isEditingRestricted;
	
		// Constructors
		public OwnAllianceDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
