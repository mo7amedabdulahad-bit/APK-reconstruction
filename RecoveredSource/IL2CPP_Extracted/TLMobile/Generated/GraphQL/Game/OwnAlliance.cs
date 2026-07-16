// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAlliance : GraphQLFetchable
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
		[ObservableValue]
		private AllianceMemberPermissions _myPermissions;
		[ObservableValue]
		private string _internalInfo1;
		[ObservableValue]
		private string _internalInfo2;
		[ObservableValue]
		private int _canLeaveAllianceAt;
		[ObservableValue]
		private GraphQLObservableList<AllianceInvitation> _sentInvitations;
		[ObservableValue]
		private OwnAllianceDiplomacy _diplomacy;
		[ObservableValue]
		private int _joinAt;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.AllianceBanner _myBanner;
		[ObservableValue]
		private GraphQLObservableList<Proposed> _bannersGallery;
		[ObservableValue]
		private string _forumUrl;
		[ObservableValue]
		private bool _isEditingRestricted;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private string _tagDecoded;
		[ObservableValue]
		private string _description1Decoded;
		[ObservableValue]
		private string _description2Decoded;
		[ObservableValue]
		private string _internalInfo1Decoded;
		[ObservableValue]
		private string _internalInfo2Decoded;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnAllianceSource Source { get; set; }
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
		public AllianceMemberPermissions myPermissions { get => default; set {} }
		[ObservableValue]
		public string internalInfo1 { get => default; set {} }
		[ObservableValue]
		public string internalInfo2 { get => default; set {} }
		[ObservableValue]
		public int canLeaveAllianceAt { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AllianceInvitation> sentInvitations { get => default; set {} }
		[ObservableValue]
		public OwnAllianceDiplomacy diplomacy { get => default; set {} }
		[ObservableValue]
		public int joinAt { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.AllianceBanner myBanner { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Proposed> bannersGallery { get => default; set {} }
		[ObservableValue]
		public string forumUrl { get => default; set {} }
		[ObservableValue]
		public bool isEditingRestricted { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public string tagDecoded { get => default; set {} }
		[ObservableValue]
		public string description1Decoded { get => default; set {} }
		[ObservableValue]
		public string description2Decoded { get => default; set {} }
		[ObservableValue]
		public string internalInfo1Decoded { get => default; set {} }
		[ObservableValue]
		public string internalInfo2Decoded { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Stub = 1,
			OwnPlayerAllAlliance = 2,
			OwnPlayerOnlyAllianceRelationsAlliance = 3
		}
	
		public enum OwnAllianceSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public OwnAlliance() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceDTO dtoValue) => default;
		private bool EqualToDTOStub(OwnAllianceDTO dtoValue) => default;
		private bool EqualToDTOOwnPlayerAllAlliance(OwnAllianceDTO dtoValue) => default;
		private bool EqualToDTOOwnPlayerOnlyAllianceRelationsAlliance(OwnAllianceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(OwnAllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOwnPlayerAllAlliance(OwnAllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOwnPlayerOnlyAllianceRelationsAlliance(OwnAllianceDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMedals(GraphQLObservableList<AllianceMedal> to, List<AllianceMedalDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRegionalTop5(GraphQLObservableList<RegionalTop5> to, List<RegionalTop5DTO> from, int query) => default;
		private bool CopyValuesFromDtoListSentInvitations(GraphQLObservableList<AllianceInvitation> to, List<AllianceInvitationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBannersGallery(GraphQLObservableList<Proposed> to, List<ProposedDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnAlliance> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnAlliance> PromiseGet(out OwnAlliance cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnAlliance GetNoFetch(Query query = Query.All) => default;
		public static OwnAlliance Get(bool forceRefresh, Query query = Query.All) => default;
		public static OwnAlliance Get(Query query = Query.All) => default;
		private static OwnAlliance Fetch(OwnAllianceSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
		private void _medalsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _regionalTop5Notify(object sender, PropertyChangedEventArgs args) {}
		private void _sentInvitationsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bannersGalleryNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public OwnAllianceDiplomacyRelation.Type GetRelationToAlliance(Alliance alliance) => default;
	}
