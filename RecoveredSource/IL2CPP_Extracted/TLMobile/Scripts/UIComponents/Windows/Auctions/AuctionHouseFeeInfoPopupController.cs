// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionHouseFeeInfoPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private int _exampleSalePrice;
		[ObservableValue]
		private int _examplePayout;
		[ObservableValue]
		private bool _dontAskAgain;
		[ObservableValue]
		private bool _showDontAskAgainToggle;
		private Action<bool> onClosed;
		private bool isConfirmed;
		private bool hasStoredTimestamp;
	
		// Properties
		[ObservableValue]
		public int exampleSalePrice { get => default; set {} }
		[ObservableValue]
		public int examplePayout { get => default; set {} }
		[ObservableValue]
		public bool dontAskAgain { get => default; set {} }
		[ObservableValue]
		public bool showDontAskAgainToggle { get => default; set {} }
	
		// Constructors
		public AuctionHouseFeeInfoPopupController() {}
	
		// Methods
		public void Setup(bool isConfirmationPopup = true, Action<bool> popupClosedCallback = null) {}
		[UICallable]
		public void ToggleDontAskAgain() {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void Confirm() {}
	}
