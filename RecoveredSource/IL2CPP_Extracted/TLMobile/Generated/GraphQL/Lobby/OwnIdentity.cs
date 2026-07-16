// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnIdentity : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _guid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _email;
		[ObservableValue]
		private string _created;
		[ObservableValue]
		private IdentityOptions _options;
		[ObservableValue]
		private int? _inDeletionAt;
		private static readonly string[] namesInNestedResponseFromSessionIdentity;
		[ObservableValue]
		private string _namePart;
		[ObservableValue]
		private string _tagPart;
		[ObservableValue]
		private bool _isSocialLoginAccount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnIdentitySource Source { get; set; }
		[ObservableValue]
		public string guid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string email { get => default; set {} }
		[ObservableValue]
		public string created { get => default; set {} }
		[ObservableValue]
		public IdentityOptions options { get => default; set {} }
		[ObservableValue]
		public int? inDeletionAt { get => default; set {} }
		[ObservableValue]
		public string namePart { get => default; set {} }
		[ObservableValue]
		public string tagPart { get => default; set {} }
		[ObservableValue]
		public bool isSocialLoginAccount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyInDeletionAt = 1
		}
	
		public enum OwnIdentitySource
		{
			FromSessionIdentity = 0
		}
	
		// Constructors
		public OwnIdentity() {}
		static OwnIdentity() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnIdentityDTO dtoValue) => default;
		private bool EqualToDTOOnlyInDeletionAt(OwnIdentityDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnIdentityDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyInDeletionAt(OwnIdentityDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnIdentity> PromiseGetFromSessionIdentity(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnIdentity> PromiseGetFromSessionIdentity(out OwnIdentity cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnIdentity GetNoFetchFromSessionIdentity(Query query = Query.All) => default;
		public static OwnIdentity GetFromSessionIdentity(bool forceRefresh, Query query = Query.All) => default;
		public static OwnIdentity GetFromSessionIdentity(Query query = Query.All) => default;
		private static OwnIdentity FetchFromSessionIdentity(OwnIdentitySource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromSessionIdentity(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
