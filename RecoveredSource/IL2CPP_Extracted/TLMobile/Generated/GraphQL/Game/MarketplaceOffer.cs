// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketplaceOffer : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private ResourcesAmount _offeredResources;
		[ObservableValue]
		private ResourcesAmount _searchedResources;
		[ObservableValue]
		private float _ratio;
		[ObservableValue]
		private Village _sellerVillage;
		[ObservableValue]
		private int? _duration;
		private const double Tolerance = 1E-06;
		public const int MinPopulationForNonEqualTrades = 200;
		[ObservableValue]
		private ResourceAmounts _searchedResourceAmounts;
		[ObservableValue]
		private ResourceAmounts _offeredResourceAmounts;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount offeredResources { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount searchedResources { get => default; set {} }
		[ObservableValue]
		public float ratio { get => default; set {} }
		[ObservableValue]
		public Village sellerVillage { get => default; set {} }
		[ObservableValue]
		public int? duration { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts searchedResourceAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts offeredResourceAmounts { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public MarketplaceOffer() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MarketplaceOfferDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MarketplaceOfferDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		public static string GetRatioText(float ratio) => default;
		public static int GetRatioColor(float ratio, bool biggerIsBetter = true) => default;
		public bool IsPlaceholder() => default;
		public static bool HasEnoughResourcesForOffer(MarketplaceOffer marketplaceOffer, OwnVillage village) => default;
		public static bool HasEnoughPopulationForNonEqualTrades(MarketplaceOffer marketplaceOffer, OwnVillage village) => default;
		public static bool IsValidOfferForBeginners(float marketplaceOfferRatio) => default;
		public static int GetNeededMerchants(MarketplaceOffer marketplaceOffer, MerchantsInfo merchantsInfo) => default;
		public static bool HasEnoughMerchants(MarketplaceOffer marketplaceOffer, MerchantsInfo merchantsInfo) => default;
		public static bool IsEqualTrade(double ratio) => default;
	}
