// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WeekendWarrior : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private bool _isBattleDay;
		[ObservableValue]
		private bool _isNightTruce;
		[ObservableValue]
		private bool _isEndgame;
		private int? weekendWarriorTimestamp;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public WeekendWarriorSource Source { get; set; }
		[ObservableValue]
		public bool isBattleDay { get => default; set {} }
		[ObservableValue]
		public bool isNightTruce { get => default; set {} }
		[ObservableValue]
		public bool isEndgame { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum WeekendWarriorSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public WeekendWarrior() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(WeekendWarriorDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(WeekendWarriorDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<WeekendWarrior> PromiseGet(int? weekendWarriorTimestamp = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<WeekendWarrior> PromiseGet(out WeekendWarrior cacheObject, int? weekendWarriorTimestamp = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static WeekendWarrior GetNoFetch(int? weekendWarriorTimestamp = default, Query query = Query.All) => default;
		public static WeekendWarrior Get(bool forceRefresh, int? weekendWarriorTimestamp = default, Query query = Query.All) => default;
		public static WeekendWarrior Get(int? weekendWarriorTimestamp = default, Query query = Query.All) => default;
		private static WeekendWarrior Fetch(WeekendWarriorSource origin, int? weekendWarriorTimestamp = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int? weekendWarriorTimestamp = default, object dummy = null) => default;
	}
