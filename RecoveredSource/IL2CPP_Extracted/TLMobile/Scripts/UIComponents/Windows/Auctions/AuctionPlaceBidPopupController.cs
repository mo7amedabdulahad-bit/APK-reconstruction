// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionPlaceBidPopupController : DetailWindowController
	{
		// Fields
		private const float RefreshCooldown = 1f;
		[SerializeField]
		private AdvancedInputField inputField;
		[SerializeField]
		private InputFieldHelper inputFieldHelper;
		[ObservableValue]
		private AuctionsBuyAuction _auction;
		[ObservableValue]
		private int _availableSilver;
		[ObservableValue]
		private int _silverInWallet;
		[ObservableValue]
		private int? _newBid;
		[ObservableValue]
		private int _highestBidderChangedMinResetTime;
		[ObservableValue]
		private bool _biddingInfoFoldout;
		[ObservableValue]
		private bool _auctionStatsFoldout;
		[ObservableValue]
		private string _itemTypeText;
		[ObservableValue]
		private bool _playerWasOutbid;
		[ObservableValue]
		private bool _isHighestBidder;
		[ObservableValue]
		private bool _hasPreviousBid;
		[ObservableValue]
		private bool _isButtonDisabled;
		private float lastRefreshTime;
		private bool isEndEdit;
		private System.Action onClose;
	
		// Properties
		[ObservableValue]
		public AuctionsBuyAuction auction { get => default; set {} }
		[ObservableValue]
		public int availableSilver { get => default; set {} }
		[ObservableValue]
		public int silverInWallet { get => default; set {} }
		[ObservableValue]
		public int? newBid { get => default; set {} }
		[ObservableValue]
		public int highestBidderChangedMinResetTime { get => default; set {} }
		[ObservableValue]
		public bool biddingInfoFoldout { get => default; set {} }
		[ObservableValue]
		public bool auctionStatsFoldout { get => default; set {} }
		[ObservableValue]
		public string itemTypeText { get => default; set {} }
		[ObservableValue]
		public bool playerWasOutbid { get => default; set {} }
		[ObservableValue]
		public bool isHighestBidder { get => default; set {} }
		[ObservableValue]
		public bool hasPreviousBid { get => default; set {} }
		[ObservableValue]
		public bool isButtonDisabled { get => default; set {} }
	
		// Constructors
		public AuctionPlaceBidPopupController() {}
	
		// Methods
		protected override void Awake() {}
		public void Setup(AuctionsBuyAuction auction, System.Action onClose = null) {}
		[UICallable]
		public void UpdateAuction() {}
		private void SetDescriptionText() {}
		public override void Hide() {}
		private void OnEndEdit(string value) {}
		private void UpdateNewBidValue() {}
		private bool HasError() => default;
		private void UpdateAvailableSilver() {}
		private bool HasNothingChanged() => default;
		private bool IsBidToLow() => default;
		private bool HasNotEnoughSilver() => default;
		private bool IsButtonDisabled() => default;
		[UICallable]
		public void PlaceBid(bool isMinBid) {}
		[UICallable]
		public void ToggleBiddingInfoFoldout() {}
		[UICallable]
		public void ToggleAuctionStatsFoldout() {}
	}
