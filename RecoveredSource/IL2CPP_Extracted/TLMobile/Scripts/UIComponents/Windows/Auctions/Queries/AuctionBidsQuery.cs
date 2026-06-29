// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions.Queries
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionBidsQuery : IPaginatedDataQuery<AuctionsBuyAuction>
	{
		// Fields
		private readonly AuctionFilter filter;
		private readonly AuctionsBidsSortBy auctionsBidsSortBy;
		private readonly SortOrder sortOrder;
		private readonly BidsAuctionsFilter bidsAuctionsFilter;
	
		// Constructors
		public AuctionBidsQuery() {} // Dummy constructor
		public AuctionBidsQuery(AuctionsBidsSortBy auctionsBidsSortBy, SortOrder sortOrder, AuctionFilter filter, bool includeFinished) {}
	
		// Methods
		public IPaginatedObject<AuctionsBuyAuction> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsBuyAuction> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsBuyAuction> GetPageForResult(ServerObject obj) => default;
	}
