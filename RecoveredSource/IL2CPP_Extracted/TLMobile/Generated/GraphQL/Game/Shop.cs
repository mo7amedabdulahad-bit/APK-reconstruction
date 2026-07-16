// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Shop : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private Country _currentCountry;
		[ObservableValue]
		private GraphQLObservableList<Country> _countries;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> _products;
		[ObservableValue]
		private Promotion _promotion;
		private ShopType shopShop;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ShopSource Source { get; set; }
		[ObservableValue]
		public Country currentCountry { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Country> countries { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> products { get => default; set {} }
		[ObservableValue]
		public Promotion promotion { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Promotions = 1
		}
	
		public enum ShopSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public Shop() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ShopDTO dtoValue) => default;
		private bool EqualToDTOPromotions(ShopDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ShopDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOPromotions(ShopDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListCountries(GraphQLObservableList<Country> to, List<CountryDTO> from, int query) => default;
		private bool CopyValuesFromDtoListProducts(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> to, List<ProductDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Shop> PromiseGet(ShopType shopShop, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Shop> PromiseGet(out Shop cacheObject, ShopType shopShop, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Shop GetNoFetch(ShopType shopShop, Query query = Query.All) => default;
		public static Shop Get(bool forceRefresh, ShopType shopShop, Query query = Query.All) => default;
		public static Shop Get(ShopType shopShop, Query query = Query.All) => default;
		private static Shop Fetch(ShopSource origin, ShopType shopShop, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(ShopType shopShop, object dummy = null) => default;
		private void _countriesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _productsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
