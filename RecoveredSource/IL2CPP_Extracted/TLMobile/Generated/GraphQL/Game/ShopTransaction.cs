// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ShopTransaction : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _paymentId;
		[ObservableValue]
		private string _paymentMethod;
		[ObservableValue]
		private string _price;
		[ObservableValue]
		private int _goldGrants;
		[ObservableValue]
		private string _createdDate;
		[ObservableValue]
		private string _createdDateTime;
		[ObservableValue]
		private ShopTransactionState _state;
		private ShopType shopShopListFromShopTransactions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string paymentId { get => default; set {} }
		[ObservableValue]
		public string paymentMethod { get => default; set {} }
		[ObservableValue]
		public string price { get => default; set {} }
		[ObservableValue]
		public int goldGrants { get => default; set {} }
		[ObservableValue]
		public string createdDate { get => default; set {} }
		[ObservableValue]
		public string createdDateTime { get => default; set {} }
		[ObservableValue]
		public ShopTransactionState state { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ShopTransactionListSource
		{
			FromShopTransactions = 0
		}
	
		// Constructors
		public ShopTransaction() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ShopTransactionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ShopTransactionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<ShopTransaction> CollectionGetNoFetchFromShopTransactions(ShopType shopShop, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<ShopTransaction>> PromiseCollectionGetFromShopTransactions(ShopType shopShop, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<ShopTransaction>> PromiseCollectionGetFromShopTransactions(out GraphQLFetchableList<ShopTransaction> cacheObject, ShopType shopShop, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<ShopTransaction> CollectionGetFromShopTransactions(ShopType shopShop, Query query = Query.All) => default;
		public static GraphQLFetchableList<ShopTransaction> CollectionGetFromShopTransactions(bool forceRefresh, ShopType shopShop, Query query = Query.All) => default;
		private static GraphQLFetchableList<ShopTransaction> CollectionFetchFromShopTransactions(ShopTransactionListSource origin, ShopType shopShop, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromShopTransactions(ShopType shopShop, object dummy = null) => default;
	}
