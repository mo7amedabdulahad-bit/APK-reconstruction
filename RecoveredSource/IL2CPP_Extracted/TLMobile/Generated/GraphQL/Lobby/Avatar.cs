// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Avatar : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Identity _identity;
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private GraphQLObservableList<Dual> _duals;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _gameworld;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.AvatarAccessType _type;
		[ObservableValue]
		private AvatarDetails _details;
		[ObservableValue]
		private bool _isLegacy;
		[ObservableValue]
		private int? _inDeletionAt;
		[ObservableValue]
		private bool? _inDeletionImminent;
		[ObservableValue]
		private int? _inVacation;
		private string avatarUuid;
		private static readonly string[] namesInNestedResponse;
		private string avatarsWuidListByAvatars;
		private AvatarsSearchContext avatarsContextListByAvatars;
		private const string LastPlayedKeyFormat = "LastPlayed_{0}";
		private const int HoursInAYear = 8760;
		[ObservableValue]
		private int _timeSinceLastPlayed;
		[ObservableValue]
		private string _lastActivityOnAvatar;
		[ObservableValue]
		private int _onVacationDaysLeft;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AvatarSource Source { get; set; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Identity identity { get => default; set {} }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Dual> duals { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.AvatarAccessType type { get => default; set {} }
		[ObservableValue]
		public AvatarDetails details { get => default; set {} }
		[ObservableValue]
		public bool isLegacy { get => default; set {} }
		[ObservableValue]
		public int? inDeletionAt { get => default; set {} }
		[ObservableValue]
		public bool? inDeletionImminent { get => default; set {} }
		[ObservableValue]
		public int? inVacation { get => default; set {} }
		[ObservableValue]
		public int timeSinceLastPlayed { get => default; set {} }
		[ObservableValue]
		public string lastActivityOnAvatar { get => default; set {} }
		[ObservableValue]
		public int onVacationDaysLeft { get => default; set {} }
		private string LastPlayedKey { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyIdentityIdNameDualsTypeInDeletionAtAndGameworldIdsAndName = 1
		}
	
		public enum AvatarSource
		{
			RootLevel = 0
		}
	
		public enum AvatarListSource
		{
			RootLevelByAvatars = 0
		}
	
		// Constructors
		public Avatar() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AvatarDTO dtoValue) => default;
		private bool EqualToDTOOnlyIdentityIdNameDualsTypeInDeletionAtAndGameworldIdsAndName(AvatarDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AvatarDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIdentityIdNameDualsTypeInDeletionAtAndGameworldIdsAndName(AvatarDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListDuals(GraphQLObservableList<Dual> to, List<DualDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Avatar> PromiseGet(string avatarUuid, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Avatar> PromiseGet(out Avatar cacheObject, string avatarUuid, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Avatar GetNoFetch(string avatarUuid, Query query = Query.All) => default;
		public static Avatar Get(bool forceRefresh, string avatarUuid, Query query = Query.All) => default;
		public static Avatar Get(string avatarUuid, Query query = Query.All) => default;
		private static Avatar Fetch(AvatarSource origin, string avatarUuid, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string avatarUuid, object dummy = null) => default;
		public static GraphQLFetchableList<Avatar> CollectionGetNoFetchByAvatars(string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Avatar>> PromiseCollectionGetByAvatars(string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Avatar>> PromiseCollectionGetByAvatars(out GraphQLFetchableList<Avatar> cacheObject, string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Avatar> CollectionGetByAvatars(string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All) => default;
		public static GraphQLFetchableList<Avatar> CollectionGetByAvatars(bool forceRefresh, string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All) => default;
		private static GraphQLFetchableList<Avatar> CollectionFetchByAvatars(AvatarListSource origin, string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByAvatars(string avatarsWuid = null, AvatarsSearchContext avatarsContext = null, object dummy = null) => default;
		private void _dualsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public void UpdateLastPlayed() {}
	}
