// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Alliance : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _tag;
		[ObservableValue]
		private string _description1;
		[ObservableValue]
		private string _description2;
		[ObservableValue]
		private int _rank;
		[ObservableValue]
		private float _points;
		[ObservableValue]
		private int _membersCount;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.AllianceBanner _banner;
		[ObservableValue]
		private GraphQLObservableList<AllianceMedal> _medals;
		[ObservableValue]
		private AllianceDiplomacy _allianceDiplomacy;
		[ObservableValue]
		private GraphQLObservableList<RegionalTop5> _regionalTop5;
		[ObservableValue]
		private int? _victoryPoints;
		[ObservableValue]
		private int? _victoryPointsPerDay;
		[ObservableValue]
		private int _attackerRank;
		[ObservableValue]
		private int _attackerPoints;
		[ObservableValue]
		private int _defenderRank;
		[ObservableValue]
		private int _defenderPoints;
		private int allianceId;
		private static readonly string[] namesInNestedResponse;
		private string findAlliancesTagListByFindAlliances;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private string _tagDecoded;
		[ObservableValue]
		private string _description1Decoded;
		[ObservableValue]
		private string _description2Decoded;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AllianceSource Source { get; set; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string tag { get => default; set {} }
		[ObservableValue]
		public string description1 { get => default; set {} }
		[ObservableValue]
		public string description2 { get => default; set {} }
		[ObservableValue]
		public int rank { get => default; set {} }
		[ObservableValue]
		public float points { get => default; set {} }
		[ObservableValue]
		public int membersCount { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.AllianceBanner banner { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AllianceMedal> medals { get => default; set {} }
		[ObservableValue]
		public AllianceDiplomacy allianceDiplomacy { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RegionalTop5> regionalTop5 { get => default; set {} }
		[ObservableValue]
		public int? victoryPoints { get => default; set {} }
		[ObservableValue]
		public int? victoryPointsPerDay { get => default; set {} }
		[ObservableValue]
		public int attackerRank { get => default; set {} }
		[ObservableValue]
		public int attackerPoints { get => default; set {} }
		[ObservableValue]
		public int defenderRank { get => default; set {} }
		[ObservableValue]
		public int defenderPoints { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public string tagDecoded { get => default; set {} }
		[ObservableValue]
		public string description1Decoded { get => default; set {} }
		[ObservableValue]
		public string description2Decoded { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Stub = 1,
			StubWithBanner = 2,
			StubWithRanks = 3,
			StatisticTab = 4
		}
	
		public enum AllianceSource
		{
			RootLevel = 0
		}
	
		public enum AllianceListSource
		{
			FromOwnAllianceInConfederacyWith = 0,
			RootLevelByFindAlliances = 1
		}
	
		// Constructors
		public Alliance() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceDTO dtoValue) => default;
		private bool EqualToDTOStub(AllianceDTO dtoValue) => default;
		private bool EqualToDTOStubWithBanner(AllianceDTO dtoValue) => default;
		private bool EqualToDTOStubWithRanks(AllianceDTO dtoValue) => default;
		private bool EqualToDTOStatisticTab(AllianceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(AllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithBanner(AllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStubWithRanks(AllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStatisticTab(AllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMedals(GraphQLObservableList<AllianceMedal> to, List<AllianceMedalDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRegionalTop5(GraphQLObservableList<RegionalTop5> to, List<RegionalTop5DTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static Alliance GetById(object dtoObject) => default;
		public static IPromise<Alliance> PromiseGet(int allianceId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Alliance> PromiseGet(out Alliance cacheObject, int allianceId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Alliance GetNoFetch(int allianceId, Query query = Query.All) => default;
		public static Alliance Get(bool forceRefresh, int allianceId, Query query = Query.All) => default;
		public static Alliance Get(int allianceId, Query query = Query.All) => default;
		private static Alliance Fetch(AllianceSource origin, int allianceId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int allianceId, object dummy = null) => default;
		public static GraphQLFetchableList<Alliance> CollectionGetNoFetchFromOwnAllianceInConfederacyWith(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Alliance>> PromiseCollectionGetFromOwnAllianceInConfederacyWith(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Alliance>> PromiseCollectionGetFromOwnAllianceInConfederacyWith(out GraphQLFetchableList<Alliance> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Alliance> CollectionGetFromOwnAllianceInConfederacyWith(Query query = Query.All) => default;
		public static GraphQLFetchableList<Alliance> CollectionGetFromOwnAllianceInConfederacyWith(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Alliance> CollectionFetchFromOwnAllianceInConfederacyWith(AllianceListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnAllianceInConfederacyWith(object dummy = null) => default;
		public static GraphQLFetchableList<Alliance> CollectionGetNoFetchByFindAlliances(string findAlliancesTag, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Alliance>> PromiseCollectionGetByFindAlliances(string findAlliancesTag, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Alliance>> PromiseCollectionGetByFindAlliances(out GraphQLFetchableList<Alliance> cacheObject, string findAlliancesTag, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Alliance> CollectionGetByFindAlliances(string findAlliancesTag, Query query = Query.All) => default;
		public static GraphQLFetchableList<Alliance> CollectionGetByFindAlliances(bool forceRefresh, string findAlliancesTag, Query query = Query.All) => default;
		private static GraphQLFetchableList<Alliance> CollectionFetchByFindAlliances(AllianceListSource origin, string findAlliancesTag, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFindAlliances(string findAlliancesTag, object dummy = null) => default;
		private void _medalsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _regionalTop5Notify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
