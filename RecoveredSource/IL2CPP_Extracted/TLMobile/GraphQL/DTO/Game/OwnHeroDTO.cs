// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnHeroDTO
	{
		// Fields
		public Gender? gender;
		public string imageHash;
		public int? level;
		public int? xp;
		public OwnVillageDTO homeVillage;
		public float? health;
		public bool? isAlive;
		public bool? enoughResourcesForRegeneration;
		public bool? enoughCropProductionForRegeneration;
		public bool? hasRallyPointForRegeneration;
		public bool? cropProductionIsNegative;
		public bool? isRegenerating;
		public int? regenerationDuration;
		public int? regenerationTimeLeft;
		public int? regenerationEndAt;
		public ResourcesAmountDTO regenerationCost;
		public int? regenerationRate;
		public int? xpForNextLevel;
		public int? xpPercentAchievedForNextLevel;
		public int? speed;
		public bool? hide;
		public ResourcesAmountDTO resourcesProduction;
		public int? productionType;
		public ResourcesAmountDTO resourcesProductionTypes;
		public int? baseCropProduction;
		public bool? adventureDifficultyBonus;
		public int? adventureDurationBonus;
		public int? adventuresAmount;
		public HeroStatusDTO status;
		public List<HeroAttributeDTO> attributes;
		public int? availablePoints;
		public HeroAppearanceSetDTO appearance;
		public int? cpProduction;
		public int? xpBonus;
		public string xpTitle;
		public string healthTitle;
		public string speedTitle;
		public string productionTitle;
		public int? rewardBonus;
		public int? nextRewardBonus;
		public int? completedAdventures;
	
		// Constructors
		public OwnHeroDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
