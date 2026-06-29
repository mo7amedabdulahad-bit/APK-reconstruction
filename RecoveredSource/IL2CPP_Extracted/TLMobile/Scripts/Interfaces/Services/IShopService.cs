// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IShopService : IService
	{
		// Properties
		bool IsPromotionUniform { get; }
		GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Product> StoreProducts { get; }
		TLMobile.Generated.GraphQL.Game.Product OneTimeOfferStoreProduct { get; }
		TLMobile.Generated.GraphQL.Game.Product BestPromotionStoreProduct { get; }
		TLMobile.Generated.GraphQL.Game.Product BestSellerStoreProduct { get; }
		TLMobile.Generated.GraphQL.Game.Product BestValueStoreProduct { get; }
		ObservableList<TLMobile.Generated.GraphQL.Game.Product> RemainingStoreProducts { get; }
		bool IsInitializedOnGameworld { get; }
		Shop ShopInstance { get; }
	
		// Events
		event System.Action OnShopUpdate;
	
		// Methods
		void InitShopOnGameworld();
		void UpdateShop(Shop.Query queryType);
	}
