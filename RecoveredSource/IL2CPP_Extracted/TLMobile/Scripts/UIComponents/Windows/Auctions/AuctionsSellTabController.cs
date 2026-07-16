// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsSellTabController : DetailWindowTabControllerWithPagination<AuctionsSellAuction>
	{
		// Fields
		[ObservableValue]
		private int _maxSellingAmount;
		[ObservableValue]
		private Subtab _currentTab;
		[ObservableValue]
		private bool _noAuctions;
		private AuctionsSellAuctionPagination allSellAuctions;
	
		// Properties
		[ObservableValue]
		public int maxSellingAmount { get => default; set {} }
		[ObservableValue]
		public Subtab currentTab { get => default; set {} }
		[ObservableValue]
		public bool noAuctions { get => default; set {} }
	
		// Nested types
		public enum Subtab
		{
			CurrentSales = 0,
			FinishedSales = 1
		}
	
		// Constructors
		public AuctionsSellTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CheckAuctionAmount() {}
		private void SetQuery() {}
		[UICallable]
		public void SellItem() {}
		[UICallable]
		public void CancelSale(AuctionInterface auction) {}
		[UICallable]
		public void ChangeSubTab(Subtab newSubTab) {}
		[UICallable]
		public void ShowAuctionFeeInfoPopup() {}
		[UICallable]
		public override bool Refresh() => default;
		private void RefreshAllSellAuctions() {}
	}
