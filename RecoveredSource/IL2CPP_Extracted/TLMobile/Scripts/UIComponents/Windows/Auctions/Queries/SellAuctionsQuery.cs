// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions.Queries
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SellAuctionsQuery : IPaginatedDataQuery<AuctionsSellAuction>
	{
		// Fields
		private readonly SellAuctionsSortBy sortBy;
		private readonly SortOrder sortOrder;
		private SellAuctionsFilter auctionsFilter;
	
		// Constructors
		public SellAuctionsQuery() {}
		public SellAuctionsQuery(SellAuctionsSortBy sortBy, SortOrder sortOrder, bool showOngoing) {}
	
		// Methods
		public IPaginatedObject<AuctionsSellAuction> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsSellAuction> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<AuctionsSellAuction> GetPageForResult(ServerObject obj) => default;
	}
