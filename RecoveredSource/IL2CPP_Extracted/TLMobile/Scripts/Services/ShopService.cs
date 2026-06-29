// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ShopService : MonoBehaviour, IShopService
	{
		// Fields
		private const string PendingTransactionIdFormat = "{0}_{1}";
		private const float PurchaseTimeout = 60f;
		private const float RestoreRetryCooldown = 60f;
		private const int NumberOfPackIcons = 6;
		private System.Action purchaseProcessingStartedCallback;
		private Action<bool> purchaseFailedCallback;
		private Action<string> purchaseSuccessCallback;
		private ShopType storeType;
		private Dictionary<string, string> productMap;
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> storeProducts;
		private bool shopAppPaymentInProgress;
		private bool isDevBuild;
		private bool purchaseInProgress;
		private OwnPlayer currentPlayerForShop;
		private PendingPurchaseData.StoreType pendingPurchaseStoreType;
		private CreateShopAppPaymentRequestBody.StoreEnum createShopAppPaymentRequestBodyStoreEnum;
		private Coroutine purchaseTimeout;
	
		// Properties
		public bool IsPromotionUniform { get; set; }
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> StoreProducts { get => default; }
		public TLMobile.Generated.GraphQL.Game.Product OneTimeOfferStoreProduct { get; private set; }
		public TLMobile.Generated.GraphQL.Game.Product BestPromotionStoreProduct { get; private set; }
		public TLMobile.Generated.GraphQL.Game.Product BestSellerStoreProduct { get; private set; }
		public TLMobile.Generated.GraphQL.Game.Product BestValueStoreProduct { get; private set; }
		public ObservableList<TLMobile.Generated.GraphQL.Game.Product> RemainingStoreProducts { get; private set; }
		public Shop ShopInstance { get; private set; }
		public bool IsInitializedOnGameworld { get; set; }
	
		// Events
		public event System.Action OnShopUpdate;
	
		// Constructors
		public ShopService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnGameworldLogout() {}
		public void InitShopOnGameworld() {}
		public void UpdateShop(Shop.Query queryType) {}
		private void LoadProductMap() {}
		private void SetupProducts() {}
		private void InitializeInAppPurchaseService(List<string> productIds) {}
		private void SetStorePricing() {}
		private void SetupPromotion() {}
		public void Purchase(string storeProductId, System.Action onPurchaseProcessingStarted, Action<string> onPurchaseSuccess, Action<bool> onPurchaseFailed) {}
		private void OnBookProduct(string packageShopID, InAppPurchaseService.Payload payload, UnityEngine.Purchasing.Product appleProduct = null) {}
		[IteratorStateMachine(typeof(_TransactionTimeout_d__66))]
		private IEnumerator TransactionTimeout(float seconds) => default;
		private void OnIapInitializedDetailed(bool dispatchUnfinishedTransactions, IStoreController controller, IExtensionProvider extensions) {}
		private void OnBookedProductTransactionNotFound(TLMobile.Generated.GraphQL.Game.Product bookedProduct, string packageShopID, InAppPurchaseService.Payload payload, UnityEngine.Purchasing.Product appleProduct = null) {}
		private void OnBookProductFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason purchaseFailureReason) {}
		private void OnBookProductFailedDetailed(UnityEngine.Purchasing.Product product, PurchaseFailureDescription purchaseFailureDescription) {}
		private void HandleFailedPurchaseCleanup(UnityEngine.Purchasing.Product product, PurchaseFailureDescription purchaseFailureDescription = null) {}
		private void OnBookProductFailed(bool timeoutError, PurchaseFailureReason purchaseFailureReason = PurchaseFailureReason.Unknown) {}
		private void OnPaymentSuccess(string packageShopID, string playerId, UnityEngine.Purchasing.Product appleProduct = null) {}
		private void FinishTransaction(string packageShopID) {}
		private TLMobile.Generated.GraphQL.Game.Product GetBookedProduct(string storeProductId) => default;
	}
