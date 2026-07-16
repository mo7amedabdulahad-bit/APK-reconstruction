// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Player : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Profile _profile;
		[ObservableValue]
		private Hero _hero;
		[ObservableValue]
		private PlayerRanks _ranks;
		[ObservableValue]
		private int _villagesCount;
		[ObservableValue]
		private int? _beginnersProtection;
		[ObservableValue]
		private PlayerRelationType? _relation;
		[ObservableValue]
		private bool _isInVacationMode;
		private int playerId;
		private static readonly string[] namesInNestedResponse;
		private string findPlayersNameListByFindPlayers;
		[ObservableValue]
		private string _nameDecoded;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public PlayerSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Profile profile { get => default; set {} }
		[ObservableValue]
		public Hero hero { get => default; set {} }
		[ObservableValue]
		public PlayerRanks ranks { get => default; set {} }
		[ObservableValue]
		public int villagesCount { get => default; set {} }
		[ObservableValue]
		public int? beginnersProtection { get => default; set {} }
		[ObservableValue]
		public PlayerRelationType? relation { get => default; set {} }
		[ObservableValue]
		public bool isInVacationMode { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			WithProfileStub = 1,
			Stub = 2,
			StubWithRanks = 3,
			StubWithRanksAndHero = 4,
			StubWithHeroPortrait = 5,
			StubWithPopulation = 6,
			StubWithHeroRank = 7
		}
	
		public enum PlayerSource
		{
			RootLevel = 0
		}
	
		public enum PlayerListSource
		{
			RootLevelByFindPlayers = 0
		}
	
		// Constructors
		public Player() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PlayerDTO dtoValue) => default;
		private bool EqualToDTOWithProfileStub(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStub(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStubWithRanks(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStubWithRanksAndHero(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStubWithHeroPortrait(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStubWithPopulation(PlayerDTO dtoValue) => default;
		private bool EqualToDTOStubWithHeroRank(PlayerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOWithProfileStub(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithRanks(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithRanksAndHero(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithHeroPortrait(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithPopulation(PlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithHeroRank(PlayerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static Player GetById(object dtoObject) => default;
		public static IPromise<Player> PromiseGet(int playerId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Player> PromiseGet(out Player cacheObject, int playerId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Player GetNoFetch(int playerId, Query query = Query.All) => default;
		public static Player Get(bool forceRefresh, int playerId, Query query = Query.All) => default;
		public static Player Get(int playerId, Query query = Query.All) => default;
		private static Player Fetch(PlayerSource origin, int playerId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int playerId, object dummy = null) => default;
		public static GraphQLFetchableList<Player> CollectionGetNoFetchByFindPlayers(string findPlayersName, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Player>> PromiseCollectionGetByFindPlayers(string findPlayersName, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Player>> PromiseCollectionGetByFindPlayers(out GraphQLFetchableList<Player> cacheObject, string findPlayersName, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Player> CollectionGetByFindPlayers(string findPlayersName, Query query = Query.All) => default;
		public static GraphQLFetchableList<Player> CollectionGetByFindPlayers(bool forceRefresh, string findPlayersName, Query query = Query.All) => default;
		private static GraphQLFetchableList<Player> CollectionFetchByFindPlayers(PlayerListSource origin, string findPlayersName, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFindPlayers(string findPlayersName, object dummy = null) => default;
		public override void AfterServerDataCallback() {}
		public static Player GetNaturePlayer() => default;
		public bool HasBeginnersProtection() => default;
		public bool IsOwnPlayer() => default;
	}
