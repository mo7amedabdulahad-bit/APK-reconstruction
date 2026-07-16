// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Product : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private string _code;
		[ObservableValue]
		private string _packageCode;
		[ObservableValue]
		private int _gold;
		[ObservableValue]
		private int _goldGrants;
		[ObservableValue]
		private string _priceFormatted;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int? _expireAt;
		[ObservableValue]
		private bool _isInPromotion;
		[ObservableValue]
		private bool _isBestValue;
		[ObservableValue]
		private bool _isBestSeller;
		[ObservableValue]
		private bool _isOneTimeOffer;
		[ObservableValue]
		private string _imageUrl;
		[ObservableValue]
		private string _storePrice;
		[ObservableValue]
		private decimal _storePriceValue;
		[ObservableValue]
		private int _appProductIndex;
		[ObservableValue]
		private string _storeProductID;
		[ObservableValue]
		private int _promotionPercentage;
		[ObservableValue]
		private int _grantsTimesValue;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string code { get => default; set {} }
		[ObservableValue]
		public string packageCode { get => default; set {} }
		[ObservableValue]
		public int gold { get => default; set {} }
		[ObservableValue]
		public int goldGrants { get => default; set {} }
		[ObservableValue]
		public string priceFormatted { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int? expireAt { get => default; set {} }
		[ObservableValue]
		public bool isInPromotion { get => default; set {} }
		[ObservableValue]
		public bool isBestValue { get => default; set {} }
		[ObservableValue]
		public bool isBestSeller { get => default; set {} }
		[ObservableValue]
		public bool isOneTimeOffer { get => default; set {} }
		[ObservableValue]
		public string imageUrl { get => default; set {} }
		[ObservableValue]
		public string storePrice { get => default; set {} }
		[ObservableValue]
		public decimal storePriceValue { get => default; set {} }
		[ObservableValue]
		public int appProductIndex { get => default; set {} }
		[ObservableValue]
		public string storeProductID { get => default; set {} }
		[ObservableValue]
		public int promotionPercentage { get => default; set {} }
		[ObservableValue]
		public int grantsTimesValue { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Product() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ProductDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ProductDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		public int GetRequiredUpdateTime() => default;
	}
