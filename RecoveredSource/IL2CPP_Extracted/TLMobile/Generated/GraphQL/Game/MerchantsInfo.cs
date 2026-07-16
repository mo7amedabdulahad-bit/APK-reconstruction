// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MerchantsInfo : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _total;
		[ObservableValue]
		private float _capacity;
		[ObservableValue]
		private int _offering;
		[ObservableValue]
		private int _underway;
		[ObservableValue]
		private int _available;
		private int merchantsInfoBuildingId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private int _capacityAvailable;
		[ObservableValue]
		private int _capacityTotal;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MerchantsInfoSource Source { get; set; }
		[ObservableValue]
		public int capacityAvailable { get => default; set {} }
		[ObservableValue]
		public int capacityTotal { get => default; set {} }
		[ObservableValue]
		public int total { get => default; set {} }
		[ObservableValue]
		public float capacity { get => default; set {} }
		[ObservableValue]
		public int offering { get => default; set {} }
		[ObservableValue]
		public int underway { get => default; set {} }
		[ObservableValue]
		public int available { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MerchantsInfoSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public MerchantsInfo() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MerchantsInfoDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MerchantsInfoDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		[Obsolete("Please use {ownPlayer{village{marketplace{merchantsInfo}}}}")]
		public static IPromise<MerchantsInfo> PromiseGet(int merchantsInfoBuildingId, Query query = Query.All, bool forceFetch = true) => default;
		[Obsolete("Please use {ownPlayer{village{marketplace{merchantsInfo}}}}")]
		public static IPromise<MerchantsInfo> PromiseGet(out MerchantsInfo cacheObject, int merchantsInfoBuildingId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		[Obsolete("Please use {ownPlayer{village{marketplace{merchantsInfo}}}}")]
		public static MerchantsInfo GetNoFetch(int merchantsInfoBuildingId, Query query = Query.All) => default;
		[Obsolete("Please use {ownPlayer{village{marketplace{merchantsInfo}}}}")]
		public static MerchantsInfo Get(bool forceRefresh, int merchantsInfoBuildingId, Query query = Query.All) => default;
		[Obsolete("Please use {ownPlayer{village{marketplace{merchantsInfo}}}}")]
		public static MerchantsInfo Get(int merchantsInfoBuildingId, Query query = Query.All) => default;
		private static MerchantsInfo Fetch(MerchantsInfoSource origin, int merchantsInfoBuildingId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int merchantsInfoBuildingId, object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
