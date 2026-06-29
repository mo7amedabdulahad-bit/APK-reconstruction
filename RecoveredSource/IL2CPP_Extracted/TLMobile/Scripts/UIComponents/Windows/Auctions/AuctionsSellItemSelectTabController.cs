// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsSellItemSelectTabController : InventoryController
	{
		// Fields
		[ObservableValue]
		private Subtab _currentTab;
		[ObservableValue]
		private bool _showExtraInfo;
		[ObservableValue]
		private InventoryItemWrapper _selectedItem;
		[ObservableValue]
		private int _selectedBatchSize;
		[ObservableValue]
		private string _itemTypeText;
		[ObservableValue]
		private bool _canSellHorse;
		[ObservableValue]
		private int _maxAuctionDuration;
		private bool sentSellRequest;
		private ObservableList<DropdownOption> batchSizeDropdownOptions;
	
		// Properties
		[ObservableValue]
		public Subtab currentTab { get => default; set {} }
		[ObservableValue]
		public bool showExtraInfo { get => default; set {} }
		[ObservableValue]
		public new InventoryItemWrapper selectedItem { get => default; set {} }
		[ObservableValue]
		public int selectedBatchSize { get => default; set {} }
		[ObservableValue]
		public string itemTypeText { get => default; set {} }
		[ObservableValue]
		public bool canSellHorse { get => default; set {} }
		[ObservableValue]
		public int maxAuctionDuration { get => default; set {} }
	
		// Nested types
		public enum Subtab
		{
			Inventory = 0,
			SelectedItem = 1
		}
	
		// Constructors
		public AuctionsSellItemSelectTabController() {}
	
		// Methods
		private void CheckCanSellHorse() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override void UpdateInventory() {}
		[UICallable]
		public void ToggleExtraInfo() {}
		[UICallable]
		public override void SelectItem(int placeId, InventoryItemWrapper item) {}
		[UICallable]
		public override bool FilterInventory(InventoryItemWrapper wrapper) => default;
		[UICallable]
		public void SellItem() {}
		private void SendSellItemRequest() {}
		[UICallable]
		public void ShowBatchSizeSelector() {}
		[UICallable]
		public void ShowTooltipPopup() {}
		[UICallable]
		public void OnBackButtonPressed() {}
	}
