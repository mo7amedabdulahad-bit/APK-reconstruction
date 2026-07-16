// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnPlayerDTO
	{
		// Fields
		public int? id;
		public string uuid;
		public int? tribeId;
		public string name;
		public int? currentVillageId;
		public OwnAllianceDTO alliance;
		public WalletDTO wallet;
		public int? unreadReportsCount;
		public PlayerGoldFeaturesDTO goldFeatures;
		public ProductionBoostListDTO productionBoost;
		public CulturalPointsOverviewDTO culturalPointsOverview;
		public bool? isSitter;
		public bool? isLocked;
		public int? accusingOthersLeft;
		public bool? hasRightToSentInvitation;
		public ProfileBanDTO messagesBan;
		public ProfileBanDTO profileBan;
		public int? beginnersProtection;
		public int? notCollectedTasks;
		public int? population;
		public bool? dailyQuestsHasReward;
		public OwnPlayerVacationModeDTO vacationMode;
		public bool? isInVacationMode;
		public AccessRightsDTO accessRights;
		public VillageOverviewDTO villageOverview;
		public PreferencesDTO preferences;
		public PlayerDeletionDTO deletion;
		public PlayerDeletionBlockedDTO deletionBlocked;
	
		// Constructors
		public OwnPlayerDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
