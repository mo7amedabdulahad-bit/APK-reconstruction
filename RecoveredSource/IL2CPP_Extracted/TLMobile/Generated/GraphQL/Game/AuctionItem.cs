// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionItem : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _typeId;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private bool _isConsumable;
		[ObservableValue]
		private bool _isUsableIfDead;
		[ObservableValue]
		private bool _isAuctionable;
		[ObservableValue]
		private bool _isCrafting;
		[ObservableValue]
		private GraphQLObservableList<InventoryItemAttributes> _attributes;
		[ObservableValue]
		private string _slot;
		[ObservableValue]
		private int _quality;
		[ObservableValue]
		private Rarity? _rarity;
		[ObservableValue]
		private GraphQLObservableList<int> _possibleAmountsToSell;
		[ObservableValue]
		private int _itemsCount;
		[ObservableValue]
		private int _auctionsCount;
		[ObservableValue]
		private int? _nextFinishAt;
		[ObservableValue]
		private int? _averagePrice;
		[ObservableValue]
		private int? _nextPrice;
		private int auctionItemTypeId;
		private Rarity? auctionItemRarityByRarity;
		private static readonly string[] namesInNestedResponse;
		private static readonly string[] namesInNestedResponseByRarity;
		private InventoryItemWrapper _itemWrapper;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AuctionItemSource Source { get; set; }
		[ObservableValue]
		public int typeId { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public bool isConsumable { get => default; set {} }
		[ObservableValue]
		public bool isUsableIfDead { get => default; set {} }
		[ObservableValue]
		public bool isAuctionable { get => default; set {} }
		[ObservableValue]
		public bool isCrafting { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<InventoryItemAttributes> attributes { get => default; set {} }
		[ObservableValue]
		public string slot { get => default; set {} }
		[ObservableValue]
		public int quality { get => default; set {} }
		[ObservableValue]
		public Rarity? rarity { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> possibleAmountsToSell { get => default; set {} }
		[ObservableValue]
		public int itemsCount { get => default; set {} }
		[ObservableValue]
		public int auctionsCount { get => default; set {} }
		[ObservableValue]
		public int? nextFinishAt { get => default; set {} }
		[ObservableValue]
		public int? averagePrice { get => default; set {} }
		[ObservableValue]
		public int? nextPrice { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper itemWrapper { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AuctionItemSource
		{
			RootLevel = 0,
			RootLevelByRarity = 1
		}
	
		// Constructors
		public AuctionItem() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionItemDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionItemDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttributes(GraphQLObservableList<InventoryItemAttributes> to, List<InventoryItemAttributesDTO> from, int query) => default;
		private bool CopyValuesFromDtoListPossibleAmountsToSell(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static AuctionItem GetById(object dtoObject) => default;
		public static IPromise<AuctionItem> PromiseGet(int auctionItemTypeId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionItem> PromiseGet(out AuctionItem cacheObject, int auctionItemTypeId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionItem GetNoFetch(int auctionItemTypeId, Query query = Query.All) => default;
		public static AuctionItem Get(bool forceRefresh, int auctionItemTypeId, Query query = Query.All) => default;
		public static AuctionItem Get(int auctionItemTypeId, Query query = Query.All) => default;
		private static AuctionItem Fetch(AuctionItemSource origin, int auctionItemTypeId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<AuctionItem> PromiseGetByRarity(Rarity? auctionItemRarity = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AuctionItem> PromiseGetByRarity(out AuctionItem cacheObject, Rarity? auctionItemRarity = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AuctionItem GetNoFetchByRarity(Rarity? auctionItemRarity = default, Query query = Query.All) => default;
		public static AuctionItem GetByRarity(bool forceRefresh, Rarity? auctionItemRarity = default, Query query = Query.All) => default;
		public static AuctionItem GetByRarity(Rarity? auctionItemRarity = default, Query query = Query.All) => default;
		private static AuctionItem FetchByRarity(AuctionItemSource origin, Rarity? auctionItemRarity = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int auctionItemTypeId, object dummy = null) => default;
		private static string GetRequestBodyPartByRarity(Rarity? auctionItemRarity = default, object dummy = null) => default;
		private void _attributesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleAmountsToSellNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public int GetRequiredUpdateTime() => default;
	}
