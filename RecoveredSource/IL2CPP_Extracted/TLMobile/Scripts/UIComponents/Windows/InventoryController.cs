// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryController : DetailWindowTabControllerWithSubTab
	{
		// Fields
		[SerializeField]
		private int gridSize;
		[SerializeField]
		private ScrollRect scrollRect;
		[ObservableValue]
		private ObservableList<InventoryItemWrapper> _inventoryItems;
		[ObservableValue]
		private HeroItemCategory _currentFilter;
		[ObservableValue]
		private ObservableList<HeroItemCategory> _inventoryFilters;
		[ObservableValue]
		private InventoryItemWrapper _selectedItem;
		[ObservableValue]
		private HeroEquipment _equipment;
		[ObservableValue]
		private OwnHero _ownHero;
		[ObservableValue]
		private bool _filteredCategoryIsEmpty;
		[ObservableValue]
		private int _actualInventoryItemCount;
		private GraphQLFetchableList<HeroInventoryItem> inventory;
		private List<int> filteredOutItems;
		[ObservableValue]
		private HeroItemCategory _horseCategory;
	
		// Properties
		[ObservableValue]
		public ObservableList<InventoryItemWrapper> inventoryItems { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory currentFilter { get => default; set {} }
		[ObservableValue]
		public ObservableList<HeroItemCategory> inventoryFilters { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper selectedItem { get => default; set {} }
		[ObservableValue]
		public HeroEquipment equipment { get => default; set {} }
		[ObservableValue]
		public OwnHero ownHero { get => default; set {} }
		[ObservableValue]
		public bool filteredCategoryIsEmpty { get => default; set {} }
		[ObservableValue]
		public int actualInventoryItemCount { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory horseCategory { get => default; set {} }
	
		// Events
		protected event Action<int, InventoryItemWrapper> OnItemSelected;
	
		// Constructors
		public InventoryController() {}
	
		// Methods
		private void _inventoryItemsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _inventoryFiltersNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void TemporarilyFilterOutItem(InventoryItemWrapper item) {}
		public void RemoveAllTemporaryFilters() {}
		public void UpdateHero() {}
		[UICallable]
		public virtual bool FilterInventory(InventoryItemWrapper wrapper) => default;
		protected virtual void UpdateInventory() {}
		[UICallable]
		public bool FilterOutMaterialCategory(HeroItemCategory filter) => default;
		public InventoryItemWrapper GetFirstEmptySlot() => default;
		[UICallable]
		public void SetCurrentFilter(HeroItemCategory filter) {}
		[UICallable]
		public virtual void SelectItem(int placeId, InventoryItemWrapper item) {}
		protected virtual void DeselectItemAndUpdateEquipment(InventoryItemWrapper item) {}
		[UICallable]
		public void UnSelectItem() {}
		public List<InventoryItemWrapper> SearchItemsByCategory(HeroItemCategory category, HeroRarity? rarity = default, HeroQuality? quality = default) => default;
		public void RegisterItemClickHandler(Action<int, InventoryItemWrapper> callback) {}
		public void UnregisterItemClickHandler(Action<int, InventoryItemWrapper> callback) {}
	}
