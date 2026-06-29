	public class AuctionsSearchPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<AuctionItem> _recentlySelectedObjects;
		[ObservableValue]
		private ObservableList<AuctionItem> _matchingObjects;
		[ObservableValue]
		private AuctionItem _selectedEntry;
		[ObservableValue]
		private string _searchInput;
		[ObservableValue]
		private string _textKeySuffix;
		[ObservableValue]
		private bool _hasError;
		private Action<AuctionItem> callback;
		private AuctionItemConnection allAuctions;
	
		// Properties
		[ObservableValue]
		public ObservableList<AuctionItem> recentlySelectedObjects { get => default; set {} }
		[ObservableValue]
		public ObservableList<AuctionItem> matchingObjects { get => default; set {} }
		[ObservableValue]
		public AuctionItem selectedEntry { get => default; set {} }
		[ObservableValue]
		public string searchInput { get => default; set {} }
		[ObservableValue]
		public string textKeySuffix { get => default; set {} }
		[ObservableValue]
		public bool hasError { get => default; set {} }
		private string PlayerPrefsKey { get => default; }
	
		// Constructors
		public AuctionsSearchPopupController() {}
	
		// Methods
		private void _recentlySelectedObjectsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _matchingObjectsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(Action<AuctionItem> callback) {}
		private void OnSearchTextChanged() {}
		[UICallable]
		public void SelectEntry(AuctionItem entry) {}
		[UICallable]
		public void ConfirmSelection() {}
		private void PersistRecentlySelected() {}
	}
