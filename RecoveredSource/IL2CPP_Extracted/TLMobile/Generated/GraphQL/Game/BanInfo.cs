// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BanInfo : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private LockStatus _lockStatus;
		[ObservableValue]
		private Punishment _offeredPunishment;
		private static readonly string[] namesInNestedResponseFromOwnPlayerBanInfo;
		[ObservableValue]
		private int _lockStatusTranslationId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public BanInfoSource Source { get; set; }
		[ObservableValue]
		public LockStatus lockStatus { get => default; set {} }
		[ObservableValue]
		public Punishment offeredPunishment { get => default; set {} }
		[ObservableValue]
		public int lockStatusTranslationId { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum BanInfoSource
		{
			FromOwnPlayerBanInfo = 0
		}
	
		// Constructors
		public BanInfo() {}
		static BanInfo() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BanInfoDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BanInfoDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<BanInfo> PromiseGetFromOwnPlayerBanInfo(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<BanInfo> PromiseGetFromOwnPlayerBanInfo(out BanInfo cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static BanInfo GetNoFetchFromOwnPlayerBanInfo(Query query = Query.All) => default;
		public static BanInfo GetFromOwnPlayerBanInfo(bool forceRefresh, Query query = Query.All) => default;
		public static BanInfo GetFromOwnPlayerBanInfo(Query query = Query.All) => default;
		private static BanInfo FetchFromOwnPlayerBanInfo(BanInfoSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerBanInfo(object dummy = null) => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
