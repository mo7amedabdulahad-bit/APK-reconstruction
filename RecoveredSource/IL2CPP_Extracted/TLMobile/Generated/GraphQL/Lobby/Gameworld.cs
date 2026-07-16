// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Gameworld : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _domain;
		[ObservableValue]
		private int _start;
		[ObservableValue]
		private int? _end;
		[ObservableValue]
		private GameworldMetadata _metadata;
		[ObservableValue]
		private GameworldFlags _flags;
		[ObservableValue]
		private GameworldInfo _info;
		private string gameworldWuid;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private List<ServerDomain> _serverDomains;
		[ObservableValue]
		private int _mapSizeCategory;
		[ObservableValue]
		private string _xSpeed;
		[ObservableValue]
		private bool _isTestEnvironment;
		[ObservableValue]
		private bool _isDisabledOnMobileOverwrite;
		[ObservableValue]
		private bool _isForceRecommended;
		[ObservableValue]
		private ObservableList<ServerDomainFlags?> _serverDomainsOverwrite;
		[ObservableValue]
		private ObservableList<RecommendedLanguageOverwrites> _languagesOverwrite;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public GameworldSource Source { get; set; }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string domain { get => default; set {} }
		[ObservableValue]
		public int start { get => default; set {} }
		[ObservableValue]
		public int? end { get => default; set {} }
		[ObservableValue]
		public GameworldMetadata metadata { get => default; set {} }
		[ObservableValue]
		public GameworldFlags flags { get => default; set {} }
		[ObservableValue]
		public GameworldInfo info { get => default; set {} }
		[ObservableValue]
		public List<ServerDomain> serverDomains { get => default; set {} }
		[ObservableValue]
		public int mapSizeCategory { get => default; set {} }
		[ObservableValue]
		public string xSpeed { get => default; set {} }
		[ObservableValue]
		public bool isTestEnvironment { get => default; set {} }
		[ObservableValue]
		public bool isDisabledOnMobileOverwrite { get => default; set {} }
		[ObservableValue]
		public bool isForceRecommended { get => default; set {} }
		[ObservableValue]
		public ObservableList<ServerDomainFlags?> serverDomainsOverwrite { get => default; set {} }
		[ObservableValue]
		public ObservableList<RecommendedLanguageOverwrites> languagesOverwrite { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyIdAndName = 1
		}
	
		public enum GameworldSource
		{
			RootLevel = 0
		}
	
		public enum GameworldListSource
		{
			RootLevelByGameworlds = 0
		}
	
		// Constructors
		public Gameworld() {}
		public Gameworld(InlineResponse20011 response, CalendarEntry calendarEntry) {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TLMobile.GraphQL.DTO.Lobby.GameworldDTO dtoValue) => default;
		private bool EqualToDTOOnlyIdAndName(TLMobile.GraphQL.DTO.Lobby.GameworldDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TLMobile.GraphQL.DTO.Lobby.GameworldDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIdAndName(TLMobile.GraphQL.DTO.Lobby.GameworldDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Gameworld> PromiseGet(string gameworldWuid, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Gameworld> PromiseGet(out Gameworld cacheObject, string gameworldWuid, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Gameworld GetNoFetch(string gameworldWuid, Query query = Query.All) => default;
		public static Gameworld Get(bool forceRefresh, string gameworldWuid, Query query = Query.All) => default;
		public static Gameworld Get(string gameworldWuid, Query query = Query.All) => default;
		private static Gameworld Fetch(GameworldSource origin, string gameworldWuid, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string gameworldWuid, object dummy = null) => default;
		public static GraphQLFetchableList<Gameworld> CollectionGetNoFetchByGameworlds(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Gameworld>> PromiseCollectionGetByGameworlds(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Gameworld>> PromiseCollectionGetByGameworlds(out GraphQLFetchableList<Gameworld> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Gameworld> CollectionGetByGameworlds(Query query = Query.All) => default;
		public static GraphQLFetchableList<Gameworld> CollectionGetByGameworlds(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Gameworld> CollectionFetchByGameworlds(GameworldListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByGameworlds(object dummy = null) => default;
		private void _serverDomainsOverwriteNotify(object sender, PropertyChangedEventArgs args) {}
		private void _languagesOverwriteNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		private void SetPartialData() {}
		private void UpdateServerDomains() {}
		private List<ServerDomain> GetRegionDomains(List<string> regions) => default;
		public bool HasMatchingRegion(ServerDomainFlags serverDomainFlags) => default;
		public bool HasMatchingCulture() => default;
		public bool HasMatchingLanguage() => default;
	}
