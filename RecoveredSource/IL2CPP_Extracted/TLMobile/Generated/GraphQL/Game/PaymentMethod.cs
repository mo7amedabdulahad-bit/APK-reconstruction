// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PaymentMethod : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _code;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _icon;
		[ObservableValue]
		private bool _iframeAllowed;
		[ObservableValue]
		private string _status;
		[ObservableValue]
		private int _position;
		[ObservableValue]
		private GraphQLObservableList<int> _transactionDuration;
		private ShopType shopShopListFromShopPaymentMethods;
		private string paymentMethodsCodeListFromShopPaymentMethods;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string code { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string icon { get => default; set {} }
		[ObservableValue]
		public bool iframeAllowed { get => default; set {} }
		[ObservableValue]
		public string status { get => default; set {} }
		[ObservableValue]
		public int position { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> transactionDuration { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum PaymentMethodListSource
		{
			FromShopPaymentMethods = 0
		}
	
		// Constructors
		public PaymentMethod() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PaymentMethodDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PaymentMethodDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTransactionDuration(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<PaymentMethod> CollectionGetNoFetchFromShopPaymentMethods(ShopType shopShop, string paymentMethodsCode, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<PaymentMethod>> PromiseCollectionGetFromShopPaymentMethods(ShopType shopShop, string paymentMethodsCode, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<PaymentMethod>> PromiseCollectionGetFromShopPaymentMethods(out GraphQLFetchableList<PaymentMethod> cacheObject, ShopType shopShop, string paymentMethodsCode, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<PaymentMethod> CollectionGetFromShopPaymentMethods(ShopType shopShop, string paymentMethodsCode, Query query = Query.All) => default;
		public static GraphQLFetchableList<PaymentMethod> CollectionGetFromShopPaymentMethods(bool forceRefresh, ShopType shopShop, string paymentMethodsCode, Query query = Query.All) => default;
		private static GraphQLFetchableList<PaymentMethod> CollectionFetchFromShopPaymentMethods(PaymentMethodListSource origin, ShopType shopShop, string paymentMethodsCode, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromShopPaymentMethods(ShopType shopShop, string paymentMethodsCode, object dummy = null) => default;
		private void _transactionDurationNotify(object sender, PropertyChangedEventArgs args) {}
	}
