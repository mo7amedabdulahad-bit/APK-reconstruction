// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InfoboxMessageInterface : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		protected int _id;
		[ObservableValue]
		protected int? _disappearsAt;
		[ObservableValue]
		protected bool _removable;
		[ObservableValue]
		protected InfoboxVisibleIn _visibleIn;
		[ObservableValue]
		private InfoboxMessageType _type;
		[ObservableValue]
		private bool _removableLeft;
		[ObservableValue]
		private bool _removableRight;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int? disappearsAt { get => default; set {} }
		[ObservableValue]
		public bool removable { get => default; set {} }
		[ObservableValue]
		public InfoboxVisibleIn visibleIn { get => default; set {} }
		[ObservableValue]
		public InfoboxMessageType type { get => default; set {} }
		[ObservableValue]
		public bool removableLeft { get => default; set {} }
		[ObservableValue]
		public bool removableRight { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum InfoboxMessageInterfaceListSource
		{
			RootLevelByInfoboxMessages = 0
		}
	
		public enum InfoboxMessageType
		{
			Unknown = 0,
			AccountLockedInfoboxMessage = 1,
			BeginnersProtectionInfoboxMessage = 2,
			BeginnersProtectionExtendingInfoboxMessage = 3,
			ReinforcementsWhileBannedInfoboxMessage = 4,
			AttackableWhileBannedInfoboxMessage = 5,
			AccountDeletionInfoboxMessage = 6,
			TruceBeforeInfoboxMessage = 7,
			TruceInfoboxMessage = 8,
			TruceAfterInfoboxMessage = 9,
			PlusInfoboxMessage = 10,
			ProductionBoostInfoboxMessage = 11,
			ArtefactsAppearInfoboxMessage = 12,
			BuildingPlansAppearInfoboxMessage = 13,
			NatarsWWInfoboxMessage = 14,
			DelayedKickInfoboxMessage = 15,
			CancelDelayedKickInfoboxMessage = 16,
			VacationModeInfoboxMessage = 17,
			WorldEndNoticeInfoboxMessage = 18,
			WorldEndCountdownInfoboxMessage = 19,
			SitterAccessWarningInfoboxMessage = 20,
			PromoInfoboxMessage = 21,
			MaintenanceInfoboxMessage = 22,
			BlockWWAttacksAfterInfoboxMessage = 23,
			BlockWWAttacksBeforeInfoboxMessage = 24,
			LevelUpProductionReminderInfoboxMessage = 25,
			OneTimeProductionBoostReminderInfoboxMessage = 26,
			CompensationBonusInfoboxMessage = 27
		}
	
		// Constructors
		public InfoboxMessageInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(InfoboxMessageInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(InfoboxMessageInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static InfoboxMessageInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		public static GraphQLFetchableList<InfoboxMessageInterface> CollectionGetNoFetchByInfoboxMessages(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<InfoboxMessageInterface>> PromiseCollectionGetByInfoboxMessages(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<InfoboxMessageInterface>> PromiseCollectionGetByInfoboxMessages(out GraphQLFetchableList<InfoboxMessageInterface> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<InfoboxMessageInterface> CollectionGetByInfoboxMessages(Query query = Query.All) => default;
		public static GraphQLFetchableList<InfoboxMessageInterface> CollectionGetByInfoboxMessages(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<InfoboxMessageInterface> CollectionFetchByInfoboxMessages(InfoboxMessageInterfaceListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByInfoboxMessages(object dummy = null) => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object serverObject = null) {}
	}
