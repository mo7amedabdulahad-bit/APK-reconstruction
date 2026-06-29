// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionBuyTabController : DetailWindowTabControllerWithPagination<AuctionsBuyAuction>
	{
		// Fields
		[ObservableValue]
		private bool _showItemGroups;
		[ObservableValue]
		private bool _showFilterButton;
		[ObservableValue]
		private int _activeFiltersCount;
		[ObservableValue]
		private ObservableList<HeroItemCategory> _inventoryFilters;
		[ObservableValue]
		private HeroItemCategory _currentFilter;
		[ObservableValue]
		private ObservableList<AuctionItem> _groupedAuctions;
		[ObservableValue]
		private AuctionItem _selectedAuctionItem;
		[ObservableValue]
		private bool _priceProgressionExtended;
		[SerializeField]
		private Transform groupedItemSeparator;
		private AuctionItemConnection allGroupedAuctions;
		private TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption currentSorting;
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> sortingOptions;
		private TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption currentSortingGrouped;
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> sortingOptionsGrouped;
		private AuctionFilter currentAuctionFilter;
		private AuctionsFilterPopup auctionsFilterPopup;
	
		// Properties
		[ObservableValue]
		public bool showItemGroups { get => default; set {} }
		[ObservableValue]
		public bool showFilterButton { get => default; set {} }
		[ObservableValue]
		public int activeFiltersCount { get => default; set {} }
		[ObservableValue]
		public ObservableList<HeroItemCategory> inventoryFilters { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory currentFilter { get => default; set {} }
		[ObservableValue]
		public ObservableList<AuctionItem> groupedAuctions { get => default; set {} }
		[ObservableValue]
		public AuctionItem selectedAuctionItem { get => default; set {} }
		[ObservableValue]
		public bool priceProgressionExtended { get => default; set {} }
	
		// Constructors
		public AuctionBuyTabController() {}
	
		// Methods
		private void _inventoryFiltersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _groupedAuctionsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void OpenWithFilter(AuctionFilter filter) {}
		private void OnSelectedItemChanged() {}
		[UICallable]
		public void ToggleShowItemGroups() {}
		[UICallable]
		public void SetCurrentFilter(HeroItemCategory filter) {}
		[UICallable]
		public bool FilterOutMaterialCategory(HeroItemCategory filter) => default;
		[UICallable]
		public void BidOnAuction(AuctionsBuyAuction auction) {}
		[UICallable]
		public override bool Refresh() => default;
		[UICallable]
		public void OpenSearchPopup() {}
		[UICallable]
		public void OpenDetailsPage(AuctionItem auctionItem) {}
		[UICallable]
		public void CloseDetailsPage() {}
		[UICallable]
		public void OpenSortPopup() {}
		[UICallable]
		public void TogglePriceProgression() {}
		[UICallable]
		public void ChangeFilterAmountToSell() {}
		private void SetupFilterPopup() {}
		private void OnFilterApplied(HeroRarity? rarity, int? amount) {}
		private void SortingChanged(TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption option) {}
		private void RefreshGroupedSeparator() {}
		private void UpdatePaginatedDataWithFilter() {}
		private void SetupSorting() {}
		private void SetupSortingGroup() {}
		private void RefreshAuctionItemGrouped() {}
		private void FilterAndSortGroupedAuctions() {}
		private void ResetRarityFilter() {}
	}
