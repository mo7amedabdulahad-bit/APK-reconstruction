// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionItemDetailGraph : InjectableViewModel
	{
		// Fields
		private const string CategoryNamePrice = "Price";
		private const string CategoryNameQuantity = "Quantity";
		[InjectableValue(hasToBeSet = true)]
		[ObservableValue]
		private InventoryItemWrapper _item;
		[ObservableValue]
		private ItemTypeSellingInformation _sellingInformation;
		[ObservableValue]
		private bool _hasSalesInLast24Hours;
		public GraphChart quantityChart;
		public GraphChart priceChart;
	
		// Properties
		[InjectableValue(hasToBeSet = true)]
		[ObservableValue]
		public InventoryItemWrapper item { get => default; set {} }
		[ObservableValue]
		public ItemTypeSellingInformation sellingInformation { get => default; set {} }
		[ObservableValue]
		public bool hasSalesInLast24Hours { get => default; set {} }
	
		// Constructors
		public AuctionItemDetailGraph() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		private void UpdateGraph() {}
	}
