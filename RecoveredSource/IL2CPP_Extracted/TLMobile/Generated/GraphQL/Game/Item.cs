// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Item : GraphQLFetchable
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
		private int itemTypeId;
		private Rarity? itemRarity;
		private static readonly string[] namesInNestedResponse;
		private InventoryItemWrapper _wrapper;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private TypeIdEnum _typeIdEnum;
		[ObservableValue]
		private HeroItemCategory _heroItemCategory;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ItemSource Source { get; set; }
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
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public TypeIdEnum typeIdEnum { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory heroItemCategory { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrapper { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			SimpleAttributes = 1
		}
	
		public enum ItemSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public Item() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ItemDTO dtoValue) => default;
		private bool EqualToDTOSimpleAttributes(ItemDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ItemDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOSimpleAttributes(ItemDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttributes(GraphQLObservableList<InventoryItemAttributes> to, List<InventoryItemAttributesDTO> from, int query) => default;
		private bool CopyValuesFromDtoListPossibleAmountsToSell(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Item> PromiseGet(int itemTypeId, Rarity? itemRarity = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Item> PromiseGet(out Item cacheObject, int itemTypeId, Rarity? itemRarity = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Item GetNoFetch(int itemTypeId, Rarity? itemRarity = default, Query query = Query.All) => default;
		public static Item Get(bool forceRefresh, int itemTypeId, Rarity? itemRarity = default, Query query = Query.All) => default;
		public static Item Get(int itemTypeId, Rarity? itemRarity = default, Query query = Query.All) => default;
		private static Item Fetch(ItemSource origin, int itemTypeId, Rarity? itemRarity = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int itemTypeId, Rarity? itemRarity = default, object dummy = null) => default;
		private void _attributesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleAmountsToSellNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
