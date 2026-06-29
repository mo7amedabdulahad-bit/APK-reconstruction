// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Identity : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _guid;
		[ObservableValue]
		private string _name;
		private string identityGuid;
		private string identityName;
		private static readonly string[] namesInNestedResponse;
		private string identitiesNameListByIdentities;
		private List<string> identitiesGuidListByIdentities;
		private IdentitiesSearchContext identitiesContextListByIdentities;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public IdentitySource Source { get; set; }
		[ObservableValue]
		public string guid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum IdentitySource
		{
			RootLevel = 0
		}
	
		public enum IdentityListSource
		{
			RootLevelByIdentities = 0
		}
	
		// Constructors
		public Identity() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(IdentityDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(IdentityDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Identity> PromiseGet(string identityGuid = null, string identityName = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Identity> PromiseGet(out Identity cacheObject, string identityGuid = null, string identityName = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Identity GetNoFetch(string identityGuid = null, string identityName = null, Query query = Query.All) => default;
		public static Identity Get(bool forceRefresh, string identityGuid = null, string identityName = null, Query query = Query.All) => default;
		public static Identity Get(string identityGuid = null, string identityName = null, Query query = Query.All) => default;
		private static Identity Fetch(IdentitySource origin, string identityGuid = null, string identityName = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string identityGuid = null, string identityName = null, object dummy = null) => default;
		public static GraphQLFetchableList<Identity> CollectionGetNoFetchByIdentities(string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Identity>> PromiseCollectionGetByIdentities(string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Identity>> PromiseCollectionGetByIdentities(out GraphQLFetchableList<Identity> cacheObject, string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Identity> CollectionGetByIdentities(string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<Identity> CollectionGetByIdentities(bool forceRefresh, string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<Identity> CollectionFetchByIdentities(IdentityListSource origin, string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetArgumentValue_identitiesGuid(List<string> guid) => default;
		private static string GetRequestBodyPartByIdentities(string identitiesName = null, List<string> identitiesGuid = null, IdentitiesSearchContext identitiesContext = null, object dummy = null) => default;
	}
