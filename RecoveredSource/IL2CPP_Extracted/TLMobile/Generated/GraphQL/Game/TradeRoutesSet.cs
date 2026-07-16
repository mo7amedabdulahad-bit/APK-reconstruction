// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRoutesSet : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private OwnVillage _from;
		[ObservableValue]
		private Destination _to;
		[ObservableValue]
		private GraphQLObservableList<TradeRoute> _routes;
		[ObservableValue]
		private bool _expanded;
		[ObservableValue]
		private TradeRoute _nextDelivery;
		private string tradeRoutesSetObjectId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private int _travelDuration;
		[ObservableValue]
		private bool _isPaused;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TradeRoutesSetSource Source { get; set; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public OwnVillage from { get => default; set {} }
		[ObservableValue]
		public Destination to { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TradeRoute> routes { get => default; set {} }
		[ObservableValue]
		public bool expanded { get => default; set {} }
		[ObservableValue]
		public TradeRoute nextDelivery { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public int travelDuration { get => default; set {} }
		[ObservableValue]
		public bool isPaused { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TradeRoutesSetSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public TradeRoutesSet() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TradeRoutesSetDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TradeRoutesSetDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListRoutes(GraphQLObservableList<TradeRoute> to, List<TradeRouteDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static TradeRoutesSet GetById(object dtoObject) => default;
		public static IPromise<TradeRoutesSet> PromiseGet(string tradeRoutesSetObjectId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<TradeRoutesSet> PromiseGet(out TradeRoutesSet cacheObject, string tradeRoutesSetObjectId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static TradeRoutesSet GetNoFetch(string tradeRoutesSetObjectId, Query query = Query.All) => default;
		public static TradeRoutesSet Get(bool forceRefresh, string tradeRoutesSetObjectId, Query query = Query.All) => default;
		public static TradeRoutesSet Get(string tradeRoutesSetObjectId, Query query = Query.All) => default;
		private static TradeRoutesSet Fetch(TradeRoutesSetSource origin, string tradeRoutesSetObjectId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string tradeRoutesSetObjectId, object dummy = null) => default;
		private void _routesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
