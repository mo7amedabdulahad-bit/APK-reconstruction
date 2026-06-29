// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions.Queries
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionItemsQuery : IPaginatedDataQuery<AuctionItem>
	{
		// Fields
		private readonly AuctionItemsFilter filter;
		private readonly AuctionItemsSortBy sortBy;
		private readonly SortOrder sortOrder;
	
		// Constructors
		public AuctionItemsQuery() {}
		public AuctionItemsQuery(AuctionItemsFilter filter, AuctionItemsSortBy sortBy, SortOrder sortOrder) {}
	
		// Methods
		public IPaginatedObject<AuctionItem> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionItem> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionItem> GetPageForResult(ServerObject obj) => default;
	}
