// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnHero : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private Gender _gender;
		[ObservableValue]
		private string _imageHash;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private int _xp;
		[ObservableValue]
		private OwnVillage _homeVillage;
		[ObservableValue]
		private float _health;
		[ObservableValue]
		private bool _isAlive;
		[ObservableValue]
		private bool _enoughResourcesForRegeneration;
		[ObservableValue]
		private bool _enoughCropProductionForRegeneration;
		[ObservableValue]
		private bool _hasRallyPointForRegeneration;
		[ObservableValue]
		private bool _cropProductionIsNegative;
		[ObservableValue]
		private bool _isRegenerating;
		[ObservableValue]
		private int _regenerationDuration;
		[ObservableValue]
		private int? _regenerationTimeLeft;
		[ObservableValue]
		private int? _regenerationEndAt;
		[ObservableValue]
		private ResourcesAmount _regenerationCost;
		[ObservableValue]
		private int _regenerationRate;
		[ObservableValue]
		private int _xpForNextLevel;
		[ObservableValue]
		private int _xpPercentAchievedForNextLevel;
		[ObservableValue]
		private int _speed;
		[ObservableValue]
		private bool _hide;
		[ObservableValue]
		private ResourcesAmount _resourcesProduction;
		[ObservableValue]
		private int _productionType;
		[ObservableValue]
		private ResourcesAmount _resourcesProductionTypes;
		[ObservableValue]
		private int _baseCropProduction;
		[ObservableValue]
		private bool _adventureDifficultyBonus;
		[ObservableValue]
		private int? _adventureDurationBonus;
		[ObservableValue]
		private int _adventuresAmount;
		[ObservableValue]
		private HeroStatus _status;
		[ObservableValue]
		private GraphQLObservableList<HeroAttribute> _attributes;
		[ObservableValue]
		private int _availablePoints;
		[ObservableValue]
		private HeroAppearanceSet _appearance;
		[ObservableValue]
		private int _cpProduction;
		[ObservableValue]
		private int _xpBonus;
		[ObservableValue]
		private string _xpTitle;
		[ObservableValue]
		private string _healthTitle;
		[ObservableValue]
		private string _speedTitle;
		[ObservableValue]
		private string _productionTitle;
		[ObservableValue]
		private int _rewardBonus;
		[ObservableValue]
		private int _nextRewardBonus;
		[ObservableValue]
		private int _completedAdventures;
		private static readonly string[] namesInNestedResponseFromOwnPlayerHero;
		[ObservableValue]
		private float _healthUnitPercentage;
		[ObservableValue]
		private float _xpForNextLevelUnitPercentage;
		[ObservableValue]
		private HeroHealthState _healthState;
		[ObservableValue]
		private ResourceAmounts _reviveCosts;
		[ObservableValue]
		private ResourceAmounts _resourcesProductions;
		[ObservableValue]
		private ResourceAmounts _resourcesProductionsTypes;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private GraphQLFetchableList<HeroInventoryItem> _lumber;
		[ObservableValue]
		private GraphQLFetchableList<HeroInventoryItem> _clay;
		[ObservableValue]
		private GraphQLFetchableList<HeroInventoryItem> _iron;
		[ObservableValue]
		private GraphQLFetchableList<HeroInventoryItem> _crop;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnHeroSource Source { get; set; }
		[ObservableValue]
		public Gender gender { get => default; set {} }
		[ObservableValue]
		public string imageHash { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public int xp { get => default; set {} }
		[ObservableValue]
		public OwnVillage homeVillage { get => default; set {} }
		[ObservableValue]
		public float health { get => default; set {} }
		[ObservableValue]
		public bool isAlive { get => default; set {} }
		[ObservableValue]
		public bool enoughResourcesForRegeneration { get => default; set {} }
		[ObservableValue]
		public bool enoughCropProductionForRegeneration { get => default; set {} }
		[ObservableValue]
		public bool hasRallyPointForRegeneration { get => default; set {} }
		[ObservableValue]
		public bool cropProductionIsNegative { get => default; set {} }
		[ObservableValue]
		public bool isRegenerating { get => default; set {} }
		[ObservableValue]
		public int regenerationDuration { get => default; set {} }
		[ObservableValue]
		public int? regenerationTimeLeft { get => default; set {} }
		[ObservableValue]
		public int? regenerationEndAt { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount regenerationCost { get => default; set {} }
		[ObservableValue]
		public int regenerationRate { get => default; set {} }
		[ObservableValue]
		public int xpForNextLevel { get => default; set {} }
		[ObservableValue]
		public int xpPercentAchievedForNextLevel { get => default; set {} }
		[ObservableValue]
		public int speed { get => default; set {} }
		[ObservableValue]
		public bool hide { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount resourcesProduction { get => default; set {} }
		[ObservableValue]
		public int productionType { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount resourcesProductionTypes { get => default; set {} }
		[ObservableValue]
		public int baseCropProduction { get => default; set {} }
		[ObservableValue]
		public bool adventureDifficultyBonus { get => default; set {} }
		[ObservableValue]
		public int? adventureDurationBonus { get => default; set {} }
		[ObservableValue]
		public int adventuresAmount { get => default; set {} }
		[ObservableValue]
		public HeroStatus status { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<HeroAttribute> attributes { get => default; set {} }
		[ObservableValue]
		public int availablePoints { get => default; set {} }
		[ObservableValue]
		public HeroAppearanceSet appearance { get => default; set {} }
		[ObservableValue]
		public int cpProduction { get => default; set {} }
		[ObservableValue]
		public int xpBonus { get => default; set {} }
		[ObservableValue]
		public string xpTitle { get => default; set {} }
		[ObservableValue]
		public string healthTitle { get => default; set {} }
		[ObservableValue]
		public string speedTitle { get => default; set {} }
		[ObservableValue]
		public string productionTitle { get => default; set {} }
		[ObservableValue]
		public int rewardBonus { get => default; set {} }
		[ObservableValue]
		public int nextRewardBonus { get => default; set {} }
		[ObservableValue]
		public int completedAdventures { get => default; set {} }
		[ObservableValue]
		public float healthUnitPercentage { get => default; set {} }
		[ObservableValue]
		public float xpForNextLevelUnitPercentage { get => default; set {} }
		[ObservableValue]
		public HeroHealthState healthState { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts reviveCosts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesProductions { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesProductionsTypes { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<HeroInventoryItem> lumber { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<HeroInventoryItem> clay { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<HeroInventoryItem> iron { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<HeroInventoryItem> crop { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			HeroPortrait = 1,
			ExperienceAndLevel = 2,
			Status = 3
		}
	
		public enum OwnHeroSource
		{
			FromOwnPlayerHero = 0
		}
	
		// Constructors
		public OwnHero() {}
		static OwnHero() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnHeroDTO dtoValue) => default;
		private bool EqualToDTOHeroPortrait(OwnHeroDTO dtoValue) => default;
		private bool EqualToDTOExperienceAndLevel(OwnHeroDTO dtoValue) => default;
		private bool EqualToDTOStatus(OwnHeroDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnHeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOHeroPortrait(OwnHeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOExperienceAndLevel(OwnHeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStatus(OwnHeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttributes(GraphQLObservableList<HeroAttribute> to, List<HeroAttributeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnHero> PromiseGetFromOwnPlayerHero(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnHero> PromiseGetFromOwnPlayerHero(out OwnHero cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnHero GetNoFetchFromOwnPlayerHero(Query query = Query.All) => default;
		public static OwnHero GetFromOwnPlayerHero(bool forceRefresh, Query query = Query.All) => default;
		public static OwnHero GetFromOwnPlayerHero(Query query = Query.All) => default;
		private static OwnHero FetchFromOwnPlayerHero(OwnHeroSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerHero(object dummy = null) => default;
		private void _attributesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _lumberNotify(object sender, PropertyChangedEventArgs args) {}
		private void _clayNotify(object sender, PropertyChangedEventArgs args) {}
		private void _ironNotify(object sender, PropertyChangedEventArgs args) {}
		private void _cropNotify(object sender, PropertyChangedEventArgs args) {}
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback() {}
		public void UpdateInventoryResourceAmounts() {}
		private GraphQLFetchableList<HeroInventoryItem> UpdateHeroInventoryItem(TypeIdEnum typeIdEnum, GraphQLFetchableList<HeroInventoryItem> items) => default;
		private void OnUpdateHeroInventoryItem(TypeIdEnum typeIdEnum, GraphQLFetchableList<HeroInventoryItem> items) {}
	}
