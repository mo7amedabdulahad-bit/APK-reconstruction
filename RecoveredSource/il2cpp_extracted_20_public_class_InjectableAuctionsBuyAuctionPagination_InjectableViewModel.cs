	public class InjectableAuctionsBuyAuctionPagination : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private AuctionsBuyAuctionPagination _auctionsBuyAuctionPagination;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public AuctionsBuyAuctionPagination auctionsBuyAuctionPagination { get => default; set {} }
	
		// Constructors
		public InjectableAuctionsBuyAuctionPagination() {}
	}
