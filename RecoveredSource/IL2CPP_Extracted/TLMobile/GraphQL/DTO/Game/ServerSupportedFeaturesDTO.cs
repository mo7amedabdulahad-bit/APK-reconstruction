// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerSupportedFeaturesDTO
	{
		// Fields
		[Obsolete("Please use field vacation")]
		public bool? vacationMode;
		public VacationModeFeatureDTO vacation;
		public bool? territory;
		public bool? allianceBonus;
		public bool? boostedStart;
		public bool? tribesEgyptiansAndHuns;
		public bool? tribesSpartans;
		public bool? hideFoolsArtifacts;
		public bool? resourcesInHeroBag;
		public bool? useAdventureSpawnTime;
		public bool? contextHelp;
		public bool? multiLanguage;
		public bool? sittingOnlyFriends;
		public bool? lockingRegionsAgain;
		public bool? rearrangeBuildings;
		public bool? travelOverTheWorldEdge;
		public bool? cities;
		public bool? allianceBanner;
		public AllianceUnionFeatureDTO allianceUnion;
		public MergingTroopsFeatureDTO mergingTroops;
		public AuctionsV2FeatureDTO auctionsV2;
		public bool? forwardingTroops;
		public bool? victoryPoints2020;
		public bool? namesLengthLimited;
		public bool? referAFriend;
		public bool? isEuropeMap;
		public bool? keepVidOnConquer;
		public bool? victoryPoints2021;
		public bool? victoryPoints2024;
		public bool? recallMerchants;
		public bool? blockWWAttacks;
		public bool? crop18;
		public bool? allianceShowIncomingAttacks;
		public bool? tribesVikings;
		public bool? harbours;
		public bool? respawn;
		[Obsolete("Always on")]
		public bool? customerCare2024;
		public bool? supportOnlyFriends;
		public SettlersCanChangeTribeFeatureDTO settlersCanChangeTribe;
		public bool? craftingItems;
		public bool? craftingItems2026;
		public bool? legendaryItems;
		public bool? heroCentricAdventures;
		public bool? RomanEliteBalancing2023;
		public bool? TeutonEliteBalancing2024;
		public bool? GaulEliteBalancing2024;
		public bool? LegionnaireEliteBalancing2024;
		public bool? videoFeatureDailyQuest;
		public VideoFeatureAdventuresDTO videoFeatureAdventures;
		public VideoFeatureSmithyDTO videoFeatureSmithy;
		public VideoFeatureAcademyDTO videoFeatureAcademy;
		public bool? videoFeatureConstruction;
		[Obsolete("New config key name is videoFeatureProductionBoost")]
		public bool? videoFeatureResourceBonus;
		public bool? videoFeatureProductionBoost;
		public VideoFeatureConstructionQueueDTO videoFeatureConstructionQueue;
		public bool? customerCare2026;
	
		// Constructors
		public ServerSupportedFeaturesDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
