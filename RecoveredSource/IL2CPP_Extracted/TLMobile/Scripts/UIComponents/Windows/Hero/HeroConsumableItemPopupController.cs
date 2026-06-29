// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroConsumableItemPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private InventoryItemWrapper _consumableItem;
		[ObservableValue]
		private int _selectedAmount;
		[ObservableValue]
		private int _amountLeft;
		[ObservableValue]
		private int _maxAmount;
		[ObservableValue]
		private int _equippedAmount;
		[ObservableValue]
		private int _xpBonusAddedValue;
		[ObservableValue]
		private int _resultingXp;
		[ObservableValue]
		private int _resultingHealth;
		[ObservableValue]
		private int _baseXpPerScroll;
		[ObservableValue]
		private int _baseHealthPerOintment;
		[ObservableValue]
		private OwnHero _hero;
		[ObservableValue]
		private string _description;
		private HeroEquipment equipment;
	
		// Properties
		[ObservableValue]
		public InventoryItemWrapper consumableItem { get => default; set {} }
		[ObservableValue]
		public int selectedAmount { get => default; set {} }
		[ObservableValue]
		public int amountLeft { get => default; set {} }
		[ObservableValue]
		public int maxAmount { get => default; set {} }
		[ObservableValue]
		public int equippedAmount { get => default; set {} }
		[ObservableValue]
		public int xpBonusAddedValue { get => default; set {} }
		[ObservableValue]
		public int resultingXp { get => default; set {} }
		[ObservableValue]
		public int resultingHealth { get => default; set {} }
		[ObservableValue]
		public int baseXpPerScroll { get => default; set {} }
		[ObservableValue]
		public int baseHealthPerOintment { get => default; set {} }
		[ObservableValue]
		public OwnHero hero { get => default; set {} }
		[ObservableValue]
		public string description { get => default; set {} }
	
		// Constructors
		public HeroConsumableItemPopupController() {}
	
		// Methods
		protected override void Awake() {}
		public void Init() {}
		public void Setup(InventoryItemWrapper item) {}
		[UICallable]
		public void FillAmount() {}
		[UICallable]
		public void Use() {}
		private void UpdateDataAndClosePopup() {}
		private void SelectedAmountChanged() {}
	}
