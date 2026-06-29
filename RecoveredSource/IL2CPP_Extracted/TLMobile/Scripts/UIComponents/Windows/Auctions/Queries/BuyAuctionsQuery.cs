// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions.Queries
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuyAuctionsQuery : IPaginatedDataQuery<AuctionsBuyAuction>
	{
		// Fields
		private readonly AuctionFilter filter;
		private readonly AuctionsSortBy sortBy;
		private readonly SortOrder sortOrder;
	
		// Constructors
		public BuyAuctionsQuery() {}
		public BuyAuctionsQuery(AuctionFilter filter, AuctionsSortBy sortBy, SortOrder sortOrder) {}
	
		// Methods
		public IPaginatedObject<AuctionsBuyAuction> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsBuyAuction> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsBuyAuction> GetPageForResult(ServerObject obj) => default;
	}
