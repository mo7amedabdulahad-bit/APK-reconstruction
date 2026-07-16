// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MilitaryRank : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _playersAmount;
		[ObservableValue]
		private int _villagesAmount;
		[ObservableValue]
		private int _offenceStrength;
		[ObservableValue]
		private int _defenceStrength;
		[ObservableValue]
		private TotalRank _offenceRank;
		[ObservableValue]
		private TotalRank _defenceRank;
		private int ownVillageIdFromOwnVillageMilitaryStatistic;
		private static readonly string[] namesInNestedResponseFromOwnVillageMilitaryStatistic;
		public int? villageId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MilitaryRankSource Source { get; set; }
		[ObservableValue]
		public int playersAmount { get => default; set {} }
		[ObservableValue]
		public int villagesAmount { get => default; set {} }
		[ObservableValue]
		public int offenceStrength { get => default; set {} }
		[ObservableValue]
		public int defenceStrength { get => default; set {} }
		[ObservableValue]
		public TotalRank offenceRank { get => default; set {} }
		[ObservableValue]
		public TotalRank defenceRank { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MilitaryRankSource
		{
			FromOwnVillageMilitaryStatistic = 0
		}
	
		// Constructors
		public MilitaryRank() {}
		static MilitaryRank() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MilitaryRankDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MilitaryRankDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MilitaryRank> PromiseGetFromOwnVillageMilitaryStatistic(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MilitaryRank> PromiseGetFromOwnVillageMilitaryStatistic(out MilitaryRank cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MilitaryRank GetNoFetchFromOwnVillageMilitaryStatistic(int ownVillageId, Query query = Query.All) => default;
		public static MilitaryRank GetFromOwnVillageMilitaryStatistic(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static MilitaryRank GetFromOwnVillageMilitaryStatistic(int ownVillageId, Query query = Query.All) => default;
		private static MilitaryRank FetchFromOwnVillageMilitaryStatistic(MilitaryRankSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageMilitaryStatistic(int ownVillageId, object dummy = null) => default;
	}
