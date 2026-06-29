// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootstrapData : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _ageInDays;
		[ObservableValue]
		private int _playersCount;
		[ObservableValue]
		private int? _artefactsDate;
		[ObservableValue]
		private int? _artefactsInDays;
		[ObservableValue]
		private int? _constructionPlansDate;
		[ObservableValue]
		private int? _constructionPlansInDays;
		[ObservableValue]
		private int? _wwLevel;
		[ObservableValue]
		private int? _wwTribeId;
		[ObservableValue]
		[Obsolete("Moved to configuration fields, type changed. New Field: serverConfiguration.tribeNames")]
		private GraphQLObservableList<Tribe> _tribes;
		[ObservableValue]
		private GraphQLObservableList<BootstrapBuilding> _buildingsRaw;
		[ObservableValue]
		private GoldActionPrices _goldActionPrices;
		[ObservableValue]
		[Obsolete("Moved to configuration fields. New Field: serverConfiguration.mapConfiguration")]
		private MapConfiguration _mapConfiguration;
		[ObservableValue]
		private string _serverTitle;
		[ObservableValue]
		private ServerSupportedFeatures _serverSupportedFeatures;
		[ObservableValue]
		private ServerConfiguration _serverConfiguration;
		[ObservableValue]
		private GraphQLObservableList<Language> _languages;
		[ObservableValue]
		private int _timestamp;
		[ObservableValue]
		private int _lastResetTimestamp;
		[ObservableValue]
		private int _nextResetTimestamp;
		[ObservableValue]
		private string _serverTimezoneOffset;
		[ObservableValue]
		private string _releaseVersion;
		[ObservableValue]
		private int _settlersAmountToFoundVillage;
		[ObservableValue]
		private AuctionConfiguration _auction;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Gameworld _gameworld;
		[ObservableValue]
		private int _requiredMainBuildingLevelForDemolition;
		private static readonly string[] namesInNestedResponse;
		public const float GaulsCrannyBonus = 1.5f;
		[ObservableValue]
		private int _serverTimeUtcOffsetSeconds;
		private GraphQLObservableList<BootstrapBuilding> gaulBuildings;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public BootstrapDataSource Source { get; set; }
		[ObservableValue]
		public int ageInDays { get => default; set {} }
		[ObservableValue]
		public int playersCount { get => default; set {} }
		[ObservableValue]
		public int? artefactsDate { get => default; set {} }
		[ObservableValue]
		public int? artefactsInDays { get => default; set {} }
		[ObservableValue]
		public int? constructionPlansDate { get => default; set {} }
		[ObservableValue]
		public int? constructionPlansInDays { get => default; set {} }
		[ObservableValue]
		public int? wwLevel { get => default; set {} }
		[ObservableValue]
		public int? wwTribeId { get => default; set {} }
		[ObservableValue]
		[Obsolete("Moved to configuration fields, type changed. New Field: serverConfiguration.tribeNames")]
		public GraphQLObservableList<Tribe> tribes { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<BootstrapBuilding> buildingsRaw { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices goldActionPrices { get => default; set {} }
		[ObservableValue]
		[Obsolete("Moved to configuration fields. New Field: serverConfiguration.mapConfiguration")]
		public MapConfiguration mapConfiguration { get => default; set {} }
		[ObservableValue]
		public string serverTitle { get => default; set {} }
		[ObservableValue]
		public ServerSupportedFeatures serverSupportedFeatures { get => default; set {} }
		[ObservableValue]
		public ServerConfiguration serverConfiguration { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Language> languages { get => default; set {} }
		[ObservableValue]
		public int timestamp { get => default; set {} }
		[ObservableValue]
		public int lastResetTimestamp { get => default; set {} }
		[ObservableValue]
		public int nextResetTimestamp { get => default; set {} }
		[ObservableValue]
		public string serverTimezoneOffset { get => default; set {} }
		[ObservableValue]
		public string releaseVersion { get => default; set {} }
		[ObservableValue]
		public int settlersAmountToFoundVillage { get => default; set {} }
		[ObservableValue]
		public AuctionConfiguration auction { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Gameworld gameworld { get => default; set {} }
		[ObservableValue]
		public int requiredMainBuildingLevelForDemolition { get => default; set {} }
		[ObservableValue]
		public int serverTimeUtcOffsetSeconds { get => default; set {} }
		public int BackendMajorVersion { get; set; }
		public int BackendMinorVersion { get; set; }
		public GraphQLObservableList<BootstrapBuilding> buildings { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyTimestamp = 1,
			OnlyBackendVersion = 2,
			OnlyGameworld = 3,
			OnlyBackendVersionAndGameworld = 4,
			OnlyServerSupportedFeatures = 5,
			OnlyAuctions = 6
		}
	
		public enum BootstrapDataSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public BootstrapData() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyTimestamp(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyBackendVersion(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyGameworld(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyBackendVersionAndGameworld(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyServerSupportedFeatures(BootstrapDataDTO dtoValue) => default;
		private bool EqualToDTOOnlyAuctions(BootstrapDataDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyTimestamp(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyBackendVersion(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyGameworld(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyBackendVersionAndGameworld(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyServerSupportedFeatures(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyAuctions(BootstrapDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTribes(GraphQLObservableList<Tribe> to, List<TribeDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBuildingsRaw(GraphQLObservableList<BootstrapBuilding> to, List<BootstrapBuildingDTO> from, int query) => default;
		private bool CopyValuesFromDtoListLanguages(GraphQLObservableList<Language> to, List<LanguageDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<BootstrapData> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<BootstrapData> PromiseGet(out BootstrapData cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static BootstrapData GetNoFetch(Query query = Query.All) => default;
		public static BootstrapData Get(bool forceRefresh, Query query = Query.All) => default;
		public static BootstrapData Get(Query query = Query.All) => default;
		private static BootstrapData Fetch(BootstrapDataSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
		private void _tribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingsRawNotify(object sender, PropertyChangedEventArgs args) {}
		private void _languagesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		private void InitialiseGaulBuildings() {}
		public int GetRequiredUpdateTime() => default;
	}
