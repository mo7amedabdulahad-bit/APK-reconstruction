// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuyGoldController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Product _oneTimeOfferStoreProduct;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Product _bestSellerStoreProduct;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Product _bestValueStoreProduct;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Game.Product> _remainingStoreProducts;
		[ObservableValue]
		[PollForUpdates(2f, 3, -1f)]
		private OwnPlayer _currentPlayer;
		[ObservableValue]
		[PollForUpdates(10f, 9, -1f)]
		private OwnPlayer _currentPlayerForShop;
		[ObservableValue]
		private bool _isAndroid;
		[ObservableValue]
		private int? _neededGold;
		[ObservableValue]
		private string _selectedProductId;
		[ObservableValue]
		private bool _isGoldShopEnabled;
		[ObservableValue]
		private bool _isGoldShopDisabledOnThisGameworld;
		[ObservableValue]
		private bool _purchaseInProgress;
		[ObservableValue]
		private int _bestPromotionAmount;
		[ObservableValue]
		private bool _isPromotionUniform;
		private BuyGoldInProgressPopup buyGoldInProgressPopup;
		private ShopService shopService;
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> storeProducts;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Product oneTimeOfferStoreProduct { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Product bestSellerStoreProduct { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Product bestValueStoreProduct { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Game.Product> remainingStoreProducts { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(2f, 3, -1f)]
		public OwnPlayer currentPlayer { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 9, -1f)]
		public OwnPlayer currentPlayerForShop { get => default; set {} }
		[ObservableValue]
		public bool isAndroid { get => default; set {} }
		[ObservableValue]
		public int? neededGold { get => default; set {} }
		[ObservableValue]
		public string selectedProductId { get => default; set {} }
		[ObservableValue]
		public bool isGoldShopEnabled { get => default; set {} }
		[ObservableValue]
		public bool isGoldShopDisabledOnThisGameworld { get => default; set {} }
		[ObservableValue]
		public bool purchaseInProgress { get => default; set {} }
		[ObservableValue]
		public int bestPromotionAmount { get => default; set {} }
		[ObservableValue]
		public bool isPromotionUniform { get => default; set {} }
	
		// Constructors
		public BuyGoldController() {}
	
		// Methods
		private void _remainingStoreProductsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(int? neededGold = default) {}
		private void PreselectProduct() {}
		private void Init() {}
		private void SetupFromShopService() {}
		private void UpdateIsGoldShopEnabled() {}
		[Conditional("UNITY_ANDROID")]
		[Conditional("UNITY_IOS")]
		[UICallable]
		public void Purchase(string storeProductId) {}
		private void ShowProcessingPopup() {}
		private void OnPurchaseSuccess(string packageShopID) {}
		private void OnPurchaseFailed(bool timedOut) {}
	}
