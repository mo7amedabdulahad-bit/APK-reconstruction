// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionConfirmDeletionPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private int _dataAmount;
		[ObservableValue]
		private bool _dontAskAgain;
		private Action<bool> callback;
	
		// Properties
		[ObservableValue]
		public int dataAmount { get => default; set {} }
		[ObservableValue]
		public bool dontAskAgain { get => default; set {} }
	
		// Constructors
		public AuctionConfirmDeletionPopupController() {}
	
		// Methods
		public void Setup(int dataAmount, Action<bool> callback) {}
		[UICallable]
		public void ToggleDontAskAgain() {}
		[UICallable]
		public void ConfirmAction() {}
	}
