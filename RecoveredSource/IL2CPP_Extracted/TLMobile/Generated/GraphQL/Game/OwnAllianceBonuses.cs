// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonuses : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private DailyContributionLimit _dailyContributionLimit;
		[ObservableValue]
		private OwnAllianceBonusesOverview _overview;
		private static readonly string[] namesInNestedResponseFromOwnAllianceBonuses;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnAllianceBonusesSource Source { get; set; }
		[ObservableValue]
		public DailyContributionLimit dailyContributionLimit { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonusesOverview overview { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OwnAllianceBonusesSource
		{
			FromOwnAllianceBonuses = 0
		}
	
		// Constructors
		public OwnAllianceBonuses() {}
		static OwnAllianceBonuses() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceBonusesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceBonusesDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnAllianceBonuses> PromiseGetFromOwnAllianceBonuses(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnAllianceBonuses> PromiseGetFromOwnAllianceBonuses(out OwnAllianceBonuses cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnAllianceBonuses GetNoFetchFromOwnAllianceBonuses(Query query = Query.All) => default;
		public static OwnAllianceBonuses GetFromOwnAllianceBonuses(bool forceRefresh, Query query = Query.All) => default;
		public static OwnAllianceBonuses GetFromOwnAllianceBonuses(Query query = Query.All) => default;
		private static OwnAllianceBonuses FetchFromOwnAllianceBonuses(OwnAllianceBonusesSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnAllianceBonuses(object dummy = null) => default;
	}
