// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DailyQuests : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _day;
		[ObservableValue]
		private int _lastSeenAt;
		[ObservableValue]
		private int _achievedPoints;
		[ObservableValue]
		private int _resetAt;
		[ObservableValue]
		private GraphQLObservableList<QuestReward> _rewards;
		[ObservableValue]
		private GraphQLObservableList<QuestData> _quests;
		private int? dailyQuestsUntilFromOwnPlayerDailyQuests;
		private static readonly string[] namesInNestedResponseFromOwnPlayerDailyQuests;
		[ObservableValue]
		private bool _anythingToRedeem;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public DailyQuestsSource Source { get; set; }
		[ObservableValue]
		public int day { get => default; set {} }
		[ObservableValue]
		public int lastSeenAt { get => default; set {} }
		[ObservableValue]
		public int achievedPoints { get => default; set {} }
		[ObservableValue]
		public int resetAt { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<QuestReward> rewards { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<QuestData> quests { get => default; set {} }
		[ObservableValue]
		public bool anythingToRedeem { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum DailyQuestsSource
		{
			FromOwnPlayerDailyQuests = 0
		}
	
		// Constructors
		public DailyQuests() {}
		static DailyQuests() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(DailyQuestsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(DailyQuestsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListRewards(GraphQLObservableList<QuestReward> to, List<QuestRewardDTO> from, int query) => default;
		private bool CopyValuesFromDtoListQuests(GraphQLObservableList<QuestData> to, List<QuestDataDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<DailyQuests> PromiseGetFromOwnPlayerDailyQuests(int? dailyQuestsUntil = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<DailyQuests> PromiseGetFromOwnPlayerDailyQuests(out DailyQuests cacheObject, int? dailyQuestsUntil = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static DailyQuests GetNoFetchFromOwnPlayerDailyQuests(int? dailyQuestsUntil = default, Query query = Query.All) => default;
		public static DailyQuests GetFromOwnPlayerDailyQuests(bool forceRefresh, int? dailyQuestsUntil = default, Query query = Query.All) => default;
		public static DailyQuests GetFromOwnPlayerDailyQuests(int? dailyQuestsUntil = default, Query query = Query.All) => default;
		private static DailyQuests FetchFromOwnPlayerDailyQuests(DailyQuestsSource origin, int? dailyQuestsUntil = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerDailyQuests(int? dailyQuestsUntil = default, object dummy = null) => default;
		private void _rewardsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _questsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
