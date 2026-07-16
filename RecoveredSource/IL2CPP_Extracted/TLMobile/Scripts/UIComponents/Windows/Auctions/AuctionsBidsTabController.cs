// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsBidsTabController : DetailWindowTabControllerWithPagination<AuctionsBuyAuction>
	{
		// Fields
		private const int MaxFinishedBidsPaginationAmount = 99;
		private const string PlayerPrefsKey = "auctionBids_showFinished";
		private const string PlayerPrefsKeyDelete = "_delete";
		private const string PlayerPrefsKeyDeleteAll = "_deleteAll";
		[ObservableValue]
		private bool _showFinished;
		[ObservableValue]
		private bool _isDeleteAllPossible;
		[ObservableValue]
		private int _currentFinishedBidsAmount;
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> sortingOptions;
		private TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption currentSorting;
	
		// Properties
		[ObservableValue]
		public bool showFinished { get => default; set {} }
		[ObservableValue]
		public bool isDeleteAllPossible { get => default; set {} }
		[ObservableValue]
		public int currentFinishedBidsAmount { get => default; set {} }
	
		// Constructors
		public AuctionsBidsTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void RefreshData() {}
		protected override void OnDisable() {}
		private void UpdateButtonState() {}
		private void SetQuery() {}
		[UICallable]
		public void ToggleShowFinished() {}
		[UICallable]
		public void BidOnAuction(AuctionsBuyAuction auction) {}
		[UICallable]
		public void DeleteFinishedAuction(AuctionsBuyAuction auction) {}
		[UICallable]
		public void OpenSortPopup() {}
		private void SortingChanged(TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption option) {}
		[UICallable]
		public override bool Refresh() => default;
		[UICallable]
		public void DeleteAllFinishedAuctions() {}
		private void OnDelete(AuctionsBuyAuction auction = null) {}
		private void SetupSorting() {}
	}
