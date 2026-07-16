// TLMobile.dll - TLMobile.Scripts.Services.ShopService
// Extracted from IL2CPP metadata v39
// Method count: 44
// NOTE: Method bodies are stubs - require native decompilation

namespace TLMobile.Scripts.Services
{
    public class ShopService
    {
        #region Constructors
        // 0x05002AF8
        public ShopService() { }
        #endregion

        #region Methods
        // 0x04FFECDC: Void add_OnShopUpdate(Action)
        public void add_OnShopUpdate(Action) { return default; }
        // 0x04FFED78: Void remove_OnShopUpdate(Action)
        public void remove_OnShopUpdate(Action) { return default; }
        // 0x04FFEE14: Boolean get_IsPromotionUniform()
        public bool get_IsPromotionUniform() { return default; }
        // 0x04FFEE1C: Void set_IsPromotionUniform(Boolean)
        public void set_IsPromotionUniform(bool) { return default; }
        // 0x04FFEE24: GraphQLObservableList`1[TLMobile.Generated.GraphQL.Game.Product] get_StoreProducts()
        public GraphQLObservableList`1[TLMobile.Generated.GraphQL.Game.Product] get_StoreProducts() { return default; }
        // 0x04FFEE2C: Product get_OneTimeOfferStoreProduct()
        public Product get_OneTimeOfferStoreProduct() { return default; }
        // 0x04FFEE34: Void set_OneTimeOfferStoreProduct(Product)
        public void set_OneTimeOfferStoreProduct(Product) { return default; }
        // 0x04FFEE3C: Product get_BestPromotionStoreProduct()
        public Product get_BestPromotionStoreProduct() { return default; }
        // 0x04FFEE44: Void set_BestPromotionStoreProduct(Product)
        public void set_BestPromotionStoreProduct(Product) { return default; }
        // 0x04FFEE4C: Product get_BestSellerStoreProduct()
        public Product get_BestSellerStoreProduct() { return default; }
        // 0x04FFEE54: Void set_BestSellerStoreProduct(Product)
        public void set_BestSellerStoreProduct(Product) { return default; }
        // 0x04FFEE5C: Product get_BestValueStoreProduct()
        public Product get_BestValueStoreProduct() { return default; }
        // 0x04FFEE64: Void set_BestValueStoreProduct(Product)
        public void set_BestValueStoreProduct(Product) { return default; }
        // 0x04FFEE6C: ObservableList`1[TLMobile.Generated.GraphQL.Game.Product] get_RemainingStoreProducts()
        public ObservableList`1[TLMobile.Generated.GraphQL.Game.Product] get_RemainingStoreProducts() { return default; }
        // 0x04FFEE74: Void set_RemainingStoreProducts(ObservableList`1[TLMobile.Generated.GraphQL.Game.Product])
        public void set_RemainingStoreProducts(ObservableList`1[TLMobile.Generated.GraphQL.Game.Product]) { return default; }
        // 0x04FFEE7C: Shop get_ShopInstance()
        public Shop get_ShopInstance() { return default; }
        // 0x04FFEE84: Void set_ShopInstance(Shop)
        public void set_ShopInstance(Shop) { return default; }
        // 0x04FFEE8C: Boolean get_IsInitializedOnGameworld()
        public bool get_IsInitializedOnGameworld() { return default; }
        // 0x04FFEE94: Void set_IsInitializedOnGameworld(Boolean)
        public void set_IsInitializedOnGameworld(bool) { return default; }
        // 0x04FFEE9C: IPromise Init(Object[])
        public IPromise Init(object) { return default; }
        // 0x04FFF124: Void LoadProductMap()
        public void LoadProductMap() { return default; }
        // 0x04FFF438: IPromise BootInstance(Object[])
        public IPromise BootInstance(object) { return default; }
        // 0x04FFF6C0: Void OnGameworldLogout()
        public void OnGameworldLogout() { return default; }
        // 0x04FFF780: Void InitShopOnGameworld()
        public void InitShopOnGameworld() { return default; }
        // 0x04FFFC08: Void SetupProducts()
        public void SetupProducts() { return default; }
        // 0x050002D8: Void UpdateShop(Shop+Query)
        public void UpdateShop(Shop+Query) { return default; }
        // 0x050002EC: Void InitializeInAppPurchaseService(List`1[System.String])
        public void InitializeInAppPurchaseService(List`1[System.String]) { return default; }
        // 0x05000780: Void SetStorePricing()
        public void SetStorePricing() { return default; }
        // 0x0500098C: Void SetupPromotion()
        public void SetupPromotion() { return default; }
        // 0x05000C58: Void Purchase(String, Action, Action`1[String], Action`1[Boolean])
        public void Purchase(String, Action, Action`1[String], Action`1[Boolean]) { return default; }
        // 0x050011F0: Void OnBookProduct(String, InAppPurchaseService+Payload, Product)
        public void OnBookProduct(String, InAppPurchaseService+Payload, Product) { return default; }
        // 0x05001BC4: Product GetBookedProduct(String)
        public Product GetBookedProduct(string) { return default; }
        // 0x05001D18: Void OnBookedProductTransactionNotFound(Product, String, InAppPurchaseService+Payload, Product)
        public void OnBookedProductTransactionNotFound(Product, String, InAppPurchaseService+Payload, Product) { return default; }
        // 0x05001DC8: IEnumerator TransactionTimeout(Single)
        public IEnumerator TransactionTimeout(float) { return default; }
        // 0x05001E6C: Void OnIapInitializedDetailed(Boolean, IStoreController, IExtensionProvider)
        public void OnIapInitializedDetailed(Boolean, IStoreController, IExtensionProvider) { return default; }
        // 0x05001E70: Void OnBookProductFailed(Product, PurchaseFailureReason)
        public void OnBookProductFailed(Product, PurchaseFailureReason) { return default; }
        // 0x05001F7C: Void HandleFailedPurchaseCleanup(Product, PurchaseFailureDescription)
        public void HandleFailedPurchaseCleanup(Product, PurchaseFailureDescription) { return default; }
        // 0x05002204: Void OnBookProductFailed(Boolean, PurchaseFailureReason)
        public void OnBookProductFailed(Boolean, PurchaseFailureReason) { return default; }
        // 0x05002440: Void OnBookProductFailedDetailed(Product, PurchaseFailureDescription)
        public void OnBookProductFailedDetailed(Product, PurchaseFailureDescription) { return default; }
        // 0x050024F0: Void OnPaymentSuccess(String, String, Product)
        public void OnPaymentSuccess(String, String, Product) { return default; }
        // 0x05002928: Void FinishTransaction(String)
        public void FinishTransaction(string) { return default; }
        // 0x05002B00: IPromise <BootInstance>b__55_0(Shop)
        public IPromise <BootInstance>b__55_0(Shop) { return default; }
        // 0x05002BCC: Boolean <SetupProducts>b__60_4(Product)
        public bool <SetupProducts>b__60_4(Product) { return default; }
        #endregion
    }
}
