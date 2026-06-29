// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DualInvite : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Identity _identity;
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _gameworld;
		private string inviteUuid;
		private static readonly string[] namesInNestedResponse;
		private string invitesWuidListByInvites;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public DualInviteSource Source { get; set; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Identity identity { get => default; set {} }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyIdsAndGameworldIdsAndName = 1
		}
	
		public enum DualInviteSource
		{
			RootLevel = 0
		}
	
		public enum DualInviteListSource
		{
			RootLevelByInvites = 0
		}
	
		// Constructors
		public DualInvite() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(DualInviteDTO dtoValue) => default;
		private bool EqualToDTOOnlyIdsAndGameworldIdsAndName(DualInviteDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(DualInviteDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIdsAndGameworldIdsAndName(DualInviteDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<DualInvite> PromiseGet(string inviteUuid, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<DualInvite> PromiseGet(out DualInvite cacheObject, string inviteUuid, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static DualInvite GetNoFetch(string inviteUuid, Query query = Query.All) => default;
		public static DualInvite Get(bool forceRefresh, string inviteUuid, Query query = Query.All) => default;
		public static DualInvite Get(string inviteUuid, Query query = Query.All) => default;
		private static DualInvite Fetch(DualInviteSource origin, string inviteUuid, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string inviteUuid, object dummy = null) => default;
		public static GraphQLFetchableList<DualInvite> CollectionGetNoFetchByInvites(string invitesWuid = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<DualInvite>> PromiseCollectionGetByInvites(string invitesWuid = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<DualInvite>> PromiseCollectionGetByInvites(out GraphQLFetchableList<DualInvite> cacheObject, string invitesWuid = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<DualInvite> CollectionGetByInvites(string invitesWuid = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<DualInvite> CollectionGetByInvites(bool forceRefresh, string invitesWuid = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<DualInvite> CollectionFetchByInvites(DualInviteListSource origin, string invitesWuid = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByInvites(string invitesWuid = null, object dummy = null) => default;
	}
