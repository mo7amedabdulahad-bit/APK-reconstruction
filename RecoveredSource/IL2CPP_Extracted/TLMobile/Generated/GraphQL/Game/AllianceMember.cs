// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceMember : GraphQLServerObject
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
		private int allianceIdListFromAllianceMembers;
		[ObservableValue]
		private string _positionDecoded;
	
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
		public string positionDecoded { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AllianceMemberListSource
		{
			FromAllianceMembers = 0
		}
	
		// Constructors
		public AllianceMember() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceMemberDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceMemberDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<AllianceMember> CollectionGetNoFetchFromAllianceMembers(int allianceId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<AllianceMember>> PromiseCollectionGetFromAllianceMembers(int allianceId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<AllianceMember>> PromiseCollectionGetFromAllianceMembers(out GraphQLFetchableList<AllianceMember> cacheObject, int allianceId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<AllianceMember> CollectionGetFromAllianceMembers(int allianceId, Query query = Query.All) => default;
		public static GraphQLFetchableList<AllianceMember> CollectionGetFromAllianceMembers(bool forceRefresh, int allianceId, Query query = Query.All) => default;
		private static GraphQLFetchableList<AllianceMember> CollectionFetchFromAllianceMembers(AllianceMemberListSource origin, int allianceId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromAllianceMembers(int allianceId, object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
