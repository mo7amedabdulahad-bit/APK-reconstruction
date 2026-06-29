// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnPlayer : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int _currentVillageId;
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private Wallet _wallet;
		[ObservableValue]
		private int _unreadReportsCount;
		[ObservableValue]
		private PlayerGoldFeatures _goldFeatures;
		[ObservableValue]
		private ProductionBoostList _productionBoost;
		[ObservableValue]
		private CulturalPointsOverview _culturalPointsOverview;
		[ObservableValue]
		private bool _isSitter;
		[ObservableValue]
		private bool _isLocked;
		[ObservableValue]
		private int _accusingOthersLeft;
		[ObservableValue]
		private bool _hasRightToSentInvitation;
		[ObservableValue]
		private ProfileBan _messagesBan;
		[ObservableValue]
		private ProfileBan _profileBan;
		[ObservableValue]
		private int? _beginnersProtection;
		[ObservableValue]
		private int _notCollectedTasks;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private bool? _dailyQuestsHasReward;
		[ObservableValue]
		private OwnPlayerVacationMode _vacationMode;
		[ObservableValue]
		private bool _isInVacationMode;
		[ObservableValue]
		private AccessRights _accessRights;
		[ObservableValue]
		private VillageOverview _villageOverview;
		[ObservableValue]
		private Preferences _preferences;
		[ObservableValue]
		private PlayerDeletion _deletion;
		[ObservableValue]
		private PlayerDeletionBlocked _deletionBlocked;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private TribeId _tribeIdEnum;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private bool _noobProtectionActive;
		[ObservableValue]
		private PermissionMask _permissions;
		[ObservableValue]
		private bool _canWriteMessage;
		[ObservableValue]
		private bool _canUnlockGoldFeature;
		[ObservableValue]
		private bool _canUnlockPlusFeature;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnPlayerSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int currentVillageId { get => default; set {} }
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public Wallet wallet { get => default; set {} }
		[ObservableValue]
		public int unreadReportsCount { get => default; set {} }
		[ObservableValue]
		public PlayerGoldFeatures goldFeatures { get => default; set {} }
		[ObservableValue]
		public ProductionBoostList productionBoost { get => default; set {} }
		[ObservableValue]
		public CulturalPointsOverview culturalPointsOverview { get => default; set {} }
		[ObservableValue]
		public bool isSitter { get => default; set {} }
		[ObservableValue]
		public bool isLocked { get => default; set {} }
		[ObservableValue]
		public int accusingOthersLeft { get => default; set {} }
		[ObservableValue]
		public bool hasRightToSentInvitation { get => default; set {} }
		[ObservableValue]
		public ProfileBan messagesBan { get => default; set {} }
		[ObservableValue]
		public ProfileBan profileBan { get => default; set {} }
		[ObservableValue]
		public int? beginnersProtection { get => default; set {} }
		[ObservableValue]
		public int notCollectedTasks { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public bool? dailyQuestsHasReward { get => default; set {} }
		[ObservableValue]
		public OwnPlayerVacationMode vacationMode { get => default; set {} }
		[ObservableValue]
		public bool isInVacationMode { get => default; set {} }
		[ObservableValue]
		public AccessRights accessRights { get => default; set {} }
		[ObservableValue]
		public VillageOverview villageOverview { get => default; set {} }
		[ObservableValue]
		public Preferences preferences { get => default; set {} }
		[ObservableValue]
		public PlayerDeletion deletion { get => default; set {} }
		[ObservableValue]
		public PlayerDeletionBlocked deletionBlocked { get => default; set {} }
		[ObservableValue]
		public TribeId tribeIdEnum { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public bool noobProtectionActive { get => default; set {} }
		[ObservableValue]
		public PermissionMask permissions { get => default; set {} }
		[ObservableValue]
		public bool canWriteMessage { get => default; set {} }
		[ObservableValue]
		public bool canUnlockGoldFeature { get => default; set {} }
		[ObservableValue]
		public bool canUnlockPlusFeature { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			CurrentVillage = 1,
			Preferences = 2,
			OnlyWallet = 3,
			GoldFeatures = 4,
			Advantages = 5,
			UnreadReportsCount = 6,
			NotCollectedTasks = 7,
			OnlyIsLocked = 8,
			OnlyDeletionAndUuid = 9,
			VacationMode = 10,
			OnlyAllianceRelations = 11
		}
	
		public enum OwnPlayerSource
		{
			RootLevel = 0
		}
	
		[Flags]
		public enum PermissionMask
		{
			None = 0,
			SendRaids = 1,
			SendReinforcement = 2,
			SendResources = 4,
			BuySpendGold = 8,
			ReadWriteMessages = 16,
			DeleteReportsMessages = 32,
			DonateResources = 64
		}
	
		public enum TribeId
		{
			Romans = 1,
			Germans = 2,
			Gauls = 3,
			Nature = 4,
			Natars = 5,
			Egyptians = 6,
			Huns = 7,
			Spartans = 8,
			Vikings = 9
		}
	
		// Constructors
		public OwnPlayer() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOCurrentVillage(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOPreferences(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOOnlyWallet(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOGoldFeatures(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOAdvantages(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOUnreadReportsCount(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTONotCollectedTasks(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOOnlyIsLocked(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOOnlyDeletionAndUuid(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOVacationMode(OwnPlayerDTO dtoValue) => default;
		private bool EqualToDTOOnlyAllianceRelations(OwnPlayerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOCurrentVillage(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOPreferences(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyWallet(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOGoldFeatures(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAdvantages(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOUnreadReportsCount(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTONotCollectedTasks(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIsLocked(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyDeletionAndUuid(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOVacationMode(OwnPlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyAllianceRelations(OwnPlayerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnPlayer> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnPlayer> PromiseGet(out OwnPlayer cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnPlayer GetNoFetch(Query query = Query.All) => default;
		public static OwnPlayer Get(bool forceRefresh, Query query = Query.All) => default;
		public static OwnPlayer Get(Query query = Query.All) => default;
		private static OwnPlayer Fetch(OwnPlayerSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
		private void UpdatePermissions() {}
		public TargetRelation GetRelationToPlayer(TLMobile.Generated.GraphQL.Game.Player otherPlayer) => default;
		public bool MayWriteMessage(TLMobile.Generated.GraphQL.Game.Player receiver) => default;
		public bool IsValidTargetToSendTroops(TargetRelation relationToTarget, Village village) => default;
		public string GetPreference(string key) => default;
	}
