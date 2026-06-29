// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroInventoryItem : GraphQLFetchable
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
		private int? _id;
		[ObservableValue]
		private int _placeId;
		[ObservableValue]
		private string _place;
		[ObservableValue]
		private int _amount;
		[ObservableValue]
		private bool? _canBeUsed;
		[ObservableValue]
		private string _popupMessage;
		[ObservableValue]
		private string _errorMessage;
		[ObservableValue]
		private string _tooltipErrorMessage;
		[ObservableValue]
		private string _warningMessage;
		[ObservableValue]
		private int _maxInput;
		[ObservableValue]
		private int _minInput;
		[ObservableValue]
		private int _defaultInput;
		[ObservableValue]
		private int? _alreadyEquipped;
		[ObservableValue]
		private bool? _isEquipped;
		[ObservableValue]
		private bool? _canBeClicked;
		[ObservableValue]
		private ClickShortDescription _clickShortDescription;
		[ObservableValue]
		private InventoryItemCooldown _cooldown;
		private int heroInventoryItemId;
		private static readonly string[] namesInNestedResponse;
		private int? inventoryTypeIdListFromOwnPlayerHeroInventory;
		private InventoryItemWrapper _wrapper;
		[ObservableValue]
		private HeroItemCategory _heroItemCategory;
		[ObservableValue]
		private TypeIdEnum _typeIdEnum;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private string _translateKey;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public HeroInventoryItemSource Source { get; set; }
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
		public int? id { get => default; set {} }
		[ObservableValue]
		public int placeId { get => default; set {} }
		[ObservableValue]
		public string place { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
		[ObservableValue]
		public bool? canBeUsed { get => default; set {} }
		[ObservableValue]
		public string popupMessage { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[ObservableValue]
		public string tooltipErrorMessage { get => default; set {} }
		[ObservableValue]
		public string warningMessage { get => default; set {} }
		[ObservableValue]
		public int maxInput { get => default; set {} }
		[ObservableValue]
		public int minInput { get => default; set {} }
		[ObservableValue]
		public int defaultInput { get => default; set {} }
		[ObservableValue]
		public int? alreadyEquipped { get => default; set {} }
		[ObservableValue]
		public bool? isEquipped { get => default; set {} }
		[ObservableValue]
		public bool? canBeClicked { get => default; set {} }
		[ObservableValue]
		public ClickShortDescription clickShortDescription { get => default; set {} }
		[ObservableValue]
		public InventoryItemCooldown cooldown { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory heroItemCategory { get => default; set {} }
		[ObservableValue]
		public TypeIdEnum typeIdEnum { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public string translateKey { get => default; set {} }
		public bool NotifyWholeObjectObservers { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrapper { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum HeroInventoryItemSource
		{
			RootLevel = 0
		}
	
		public enum HeroInventoryItemListSource
		{
			FromOwnPlayerHeroInventory = 0
		}
	
		// Constructors
		public HeroInventoryItem() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroInventoryItemDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroInventoryItemDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttributes(GraphQLObservableList<InventoryItemAttributes> to, List<InventoryItemAttributesDTO> from, int query) => default;
		private bool CopyValuesFromDtoListPossibleAmountsToSell(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static HeroInventoryItem GetById(object dtoObject) => default;
		public static IPromise<HeroInventoryItem> PromiseGet(int heroInventoryItemId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<HeroInventoryItem> PromiseGet(out HeroInventoryItem cacheObject, int heroInventoryItemId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static HeroInventoryItem GetNoFetch(int heroInventoryItemId, Query query = Query.All) => default;
		public static HeroInventoryItem Get(bool forceRefresh, int heroInventoryItemId, Query query = Query.All) => default;
		public static HeroInventoryItem Get(int heroInventoryItemId, Query query = Query.All) => default;
		private static HeroInventoryItem Fetch(HeroInventoryItemSource origin, int heroInventoryItemId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int heroInventoryItemId, object dummy = null) => default;
		public static GraphQLFetchableList<HeroInventoryItem> CollectionGetNoFetchFromOwnPlayerHeroInventory(int? inventoryTypeId = default, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<HeroInventoryItem>> PromiseCollectionGetFromOwnPlayerHeroInventory(int? inventoryTypeId = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<HeroInventoryItem>> PromiseCollectionGetFromOwnPlayerHeroInventory(out GraphQLFetchableList<HeroInventoryItem> cacheObject, int? inventoryTypeId = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<HeroInventoryItem> CollectionGetFromOwnPlayerHeroInventory(int? inventoryTypeId = default, Query query = Query.All) => default;
		public static GraphQLFetchableList<HeroInventoryItem> CollectionGetFromOwnPlayerHeroInventory(bool forceRefresh, int? inventoryTypeId = default, Query query = Query.All) => default;
		private static GraphQLFetchableList<HeroInventoryItem> CollectionFetchFromOwnPlayerHeroInventory(HeroInventoryItemListSource origin, int? inventoryTypeId = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroInventory(int? inventoryTypeId = default, object dummy = null) => default;
		private void _attributesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleAmountsToSellNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public InventoryItem ConvertToInventoryItem() => default;
	}
