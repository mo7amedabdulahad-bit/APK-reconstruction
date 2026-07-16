// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Account : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _guid;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.AvatarAccessType _accessType;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AccountSource Source { get; set; }
		[ObservableValue]
		public string guid { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.AvatarAccessType accessType { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AccountSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public Account() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AccountDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AccountDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Account> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Account> PromiseGet(out Account cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Account GetNoFetch(Query query = Query.All) => default;
		public static Account Get(bool forceRefresh, Query query = Query.All) => default;
		public static Account Get(Query query = Query.All) => default;
		private static Account Fetch(AccountSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
	}
