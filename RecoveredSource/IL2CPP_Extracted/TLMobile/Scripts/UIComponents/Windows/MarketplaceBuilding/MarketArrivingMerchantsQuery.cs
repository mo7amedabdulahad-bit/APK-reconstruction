// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketArrivingMerchantsQuery : IPaginatedDataQuery<OwnMerchantMovement>
	{
		// Fields
		private readonly ArrivingMerchantsSortBy merchantsSortBy;
		private readonly SortOrder sortOrder;
		private readonly int villageId;
	
		// Constructors
		public MarketArrivingMerchantsQuery() {} // Dummy constructor
		public MarketArrivingMerchantsQuery(int villageId, ArrivingMerchantsSortBy merchantsSortBy, SortOrder sortOrder) {}
	
		// Methods
		public IPaginatedObject<OwnMerchantMovement> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<OwnMerchantMovement> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<OwnMerchantMovement> GetPageForResult(ServerObject obj) => default;
	}
