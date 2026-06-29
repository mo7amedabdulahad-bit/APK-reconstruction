// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ItemTypeSellingInformation : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int? _lowestPrice;
		[ObservableValue]
		private int? _averagePrice;
		[ObservableValue]
		private int? _highestPrice;
		[ObservableValue]
		private GraphQLObservableList<int> _priceHistory;
		[ObservableValue]
		private GraphQLObservableList<int> _salesHistory;
		private int itemTypeSellingInformationItemTypeId;
		private Rarity itemTypeSellingInformationRarity;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ItemTypeSellingInformationSource Source { get; set; }
		[ObservableValue]
		public int? lowestPrice { get => default; set {} }
		[ObservableValue]
		public int? averagePrice { get => default; set {} }
		[ObservableValue]
		public int? highestPrice { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> priceHistory { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> salesHistory { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ItemTypeSellingInformationSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public ItemTypeSellingInformation() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ItemTypeSellingInformationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ItemTypeSellingInformationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListPriceHistory(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		private bool CopyValuesFromDtoListSalesHistory(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<ItemTypeSellingInformation> PromiseGet(int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<ItemTypeSellingInformation> PromiseGet(out ItemTypeSellingInformation cacheObject, int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static ItemTypeSellingInformation GetNoFetch(int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All) => default;
		public static ItemTypeSellingInformation Get(bool forceRefresh, int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All) => default;
		public static ItemTypeSellingInformation Get(int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All) => default;
		private static ItemTypeSellingInformation Fetch(ItemTypeSellingInformationSource origin, int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int itemTypeSellingInformationItemTypeId, Rarity itemTypeSellingInformationRarity, object dummy = null) => default;
		private void _priceHistoryNotify(object sender, PropertyChangedEventArgs args) {}
		private void _salesHistoryNotify(object sender, PropertyChangedEventArgs args) {}
	}
