	public class InjectableAuctionConfiguration : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private AuctionConfiguration _auctionConfiguration;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public AuctionConfiguration auctionConfiguration { get => default; set {} }
	
		// Constructors
		public InjectableAuctionConfiguration() {}
	}
