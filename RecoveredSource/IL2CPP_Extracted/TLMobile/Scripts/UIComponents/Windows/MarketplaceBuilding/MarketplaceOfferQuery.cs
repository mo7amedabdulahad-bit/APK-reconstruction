// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketplaceOfferQuery : IPaginatedDataQuery<MarketplaceOffer>
	{
		// Fields
		private readonly MarketplaceOffersFilter filterToUse;
		private readonly int villageId;
	
		// Constructors
		public MarketplaceOfferQuery() {} // Dummy constructor
		public MarketplaceOfferQuery(int villId, MarketplaceOffersFilter filter) {}
	
		// Methods
		public IPaginatedObject<MarketplaceOffer> GetPaginationPage(string cursor, int amount, bool forceRefresh) => default;
		public IPaginatedObject<MarketplaceOffer> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<MarketplaceOffer> GetPageForResult(ServerObject obj) => default;
	}
