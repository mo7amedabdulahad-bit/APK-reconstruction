// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionInterface : GraphQLFetchable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		protected string _identifier;
		[ObservableValue]
		protected TLMobile.Generated.GraphQL.Game.Item _item;
		[ObservableValue]
		protected int _amount;
		[ObservableValue]
		protected BidStatus _status;
		[ObservableValue]
		protected int _startedAt;
		[ObservableValue]
		protected int _finishedAt;
		[ObservableValue]
		protected int _price;
		[ObservableValue]
		protected int _bidsAmount;
		[ObservableValue]
		protected int? _maxBid;
		protected string thisTypeName;
		private string auctionIdentifier;
		private static readonly string[] namesInNestedResponse;
		private const int CancellationWindow = 300;
		private InventoryItemWrapper _itemWrapper;
		[ObservableValue]
		private int _cancellableUntil;
		[ObservableValue]
		private bool _isSelected;
		[ObservableValue]
		private bool _hasPreviousBid;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AuctionInterfaceSource Source { get; set; }
		[ObservableValue]
		public string identifier { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Item item { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
		[ObservableValue]
		public BidStatus status { get => default; set {} }
		[ObservableValue]
		public int startedAt { get => default; set {} }
		[ObservableValue]
		public int finishedAt { get => default; set {} }
		[ObservableValue]
		public int price { get => default; set {} }
		[ObservableValue]
		public int bidsAmount { get => default; set {} }
		[ObservableValue]
		public int? maxBid { get => default; set {} }
		[ObservableValue]
		public int cancellableUntil { get => default; set {} }
		[ObservableValue]
		public bool isSelected { get => default; set {} }
		[ObservableValue]
		public bool hasPreviousBid { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper itemWrapper { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AuctionInterfaceSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public AuctionInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static AuctionInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static AuctionInterface GetById(string typeName, object dtoObject) => default;
		public static IPromise<AuctionInterface> PromiseGet(string auctionIdentifier, Query query = Query.All, bool forceFetch = true) => default;
		public static AuctionInterface GetNoFetch(string typeName, string auctionIdentifier, Query query = Query.All) => default;
		private static AuctionInterface Fetch(string typeName, AuctionInterfaceSource origin, string auctionIdentifier, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string auctionIdentifier, object dummy = null) => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
		[UICallable]
		public void ShowItemDetailsPopup() {}
	}
