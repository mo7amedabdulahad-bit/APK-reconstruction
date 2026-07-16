// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRoute : GraphQLFetchable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private bool _enabled;
		[ObservableValue]
		private bool _sendOnce;
		[ObservableValue]
		private ResourcesAmount _carriedResources;
		[ObservableValue]
		private int _departureAt;
		[ObservableValue]
		private int _arrivalAt;
		[ObservableValue]
		private int _repeat;
		[ObservableValue]
		private int _merchants;
		[ObservableValue]
		private int _ships;
		[ObservableValue]
		private bool _useTradeShips;
		private int tradeRouteId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private int _returnAt;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private bool _isSelected;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TradeRouteSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public bool enabled { get => default; set {} }
		[ObservableValue]
		public bool sendOnce { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount carriedResources { get => default; set {} }
		[ObservableValue]
		public int departureAt { get => default; set {} }
		[ObservableValue]
		public int arrivalAt { get => default; set {} }
		[ObservableValue]
		public int repeat { get => default; set {} }
		[ObservableValue]
		public int merchants { get => default; set {} }
		[ObservableValue]
		public int ships { get => default; set {} }
		[ObservableValue]
		public bool useTradeShips { get => default; set {} }
		[ObservableValue]
		public int returnAt { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public bool isSelected { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TradeRouteSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public TradeRoute() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TradeRouteDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TradeRouteDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static TradeRoute GetById(object dtoObject) => default;
		public static IPromise<TradeRoute> PromiseGet(int tradeRouteId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<TradeRoute> PromiseGet(out TradeRoute cacheObject, int tradeRouteId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static TradeRoute GetNoFetch(int tradeRouteId, Query query = Query.All) => default;
		public static TradeRoute Get(bool forceRefresh, int tradeRouteId, Query query = Query.All) => default;
		public static TradeRoute Get(int tradeRouteId, Query query = Query.All) => default;
		private static TradeRoute Fetch(TradeRouteSource origin, int tradeRouteId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int tradeRouteId, object dummy = null) => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback() {}
	}
