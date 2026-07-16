// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceMember : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private string _position;
		[ObservableValue]
		private AllianceAttacks _attacksOnMember;
		[ObservableValue]
		private int? _victoryPoints;
		[ObservableValue]
		private float? _victoryPointsPerDay;
		[ObservableValue]
		private int _onlineStatus;
		[ObservableValue]
		private string _onlineStatusTitle;
		[ObservableValue]
		private OwnAllianceMemberSpecialization? _specialization;
		[ObservableValue]
		private int _joinAt;
		[ObservableValue]
		private AllianceMemberPermissions _permissions;
		[ObservableValue]
		private OnlineStatus _onlineStatusEnum;
		[ObservableValue]
		private string _positionDecoded;
		[ObservableValue]
		private int _specializationSpriteConfigId;
		[ObservableValue]
		private AllianceMemberPermissions _allianceMemberPermissions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public string position { get => default; set {} }
		[ObservableValue]
		public AllianceAttacks attacksOnMember { get => default; set {} }
		[ObservableValue]
		public int? victoryPoints { get => default; set {} }
		[ObservableValue]
		public float? victoryPointsPerDay { get => default; set {} }
		[ObservableValue]
		public int onlineStatus { get => default; set {} }
		[ObservableValue]
		public string onlineStatusTitle { get => default; set {} }
		[ObservableValue]
		public OwnAllianceMemberSpecialization? specialization { get => default; set {} }
		[ObservableValue]
		public int joinAt { get => default; set {} }
		[ObservableValue]
		public AllianceMemberPermissions permissions { get => default; set {} }
		[ObservableValue]
		public OnlineStatus onlineStatusEnum { get => default; set {} }
		[ObservableValue]
		public string positionDecoded { get => default; set {} }
		[ObservableValue]
		public int specializationSpriteConfigId { get => default; set {} }
		[ObservableValue]
		public AllianceMemberPermissions allianceMemberPermissions { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OwnAllianceMemberListSource
		{
			FromOwnAllianceMembers = 0
		}
	
		public enum OnlineStatus
		{
			LessThan5MinutesAgo = 1,
			LessThan24HoursAgo = 2,
			LessThan3DaysAgo = 3,
			LessThan7DaysAgo = 4,
			LongTimeNoSee = 5
		}
	
		// Constructors
		public OwnAllianceMember() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceMemberDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceMemberDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<OwnAllianceMember> CollectionGetNoFetchFromOwnAllianceMembers(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OwnAllianceMember>> PromiseCollectionGetFromOwnAllianceMembers(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OwnAllianceMember>> PromiseCollectionGetFromOwnAllianceMembers(out GraphQLFetchableList<OwnAllianceMember> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OwnAllianceMember> CollectionGetFromOwnAllianceMembers(Query query = Query.All) => default;
		public static GraphQLFetchableList<OwnAllianceMember> CollectionGetFromOwnAllianceMembers(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<OwnAllianceMember> CollectionFetchFromOwnAllianceMembers(OwnAllianceMemberListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnAllianceMembers(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
		public void RefreshPermission() {}
	}
