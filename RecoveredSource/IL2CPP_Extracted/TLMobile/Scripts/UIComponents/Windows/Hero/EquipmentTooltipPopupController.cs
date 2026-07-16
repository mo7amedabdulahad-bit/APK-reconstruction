// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class EquipmentTooltipPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private InventoryItemWrapper _inventoryItemWrapper;
		[ObservableValue]
		private bool _button01Disabled;
		[ObservableValue]
		private bool _button01DisabledIsClickable;
		[ObservableValue]
		private bool _button02Disabled;
		[ObservableValue]
		private bool _button02DisabledIsClickable;
		[ObservableValue]
		private int _amountToSell;
		[ObservableValue]
		private int _firstHorsePrice;
		[ObservableValue]
		private bool _firstHorseWarningVisible;
		private ObservableList<DropdownOption> amountToSellChoice;
		private Action<InventoryItemWrapper> afterUseCallback;
		private Action<InventoryItemWrapper> afterUseCallbackDisabled;
	
		// Properties
		[ObservableValue]
		public InventoryItemWrapper inventoryItemWrapper { get => default; set {} }
		[ObservableValue]
		public bool button01Disabled { get => default; set {} }
		[ObservableValue]
		public bool button01DisabledIsClickable { get => default; set {} }
		[ObservableValue]
		public bool button02Disabled { get => default; set {} }
		[ObservableValue]
		public bool button02DisabledIsClickable { get => default; set {} }
		[ObservableValue]
		public int amountToSell { get => default; set {} }
		[ObservableValue]
		public int firstHorsePrice { get => default; set {} }
		[ObservableValue]
		public bool firstHorseWarningVisible { get => default; set {} }
	
		// Constructors
		public EquipmentTooltipPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		private void Init() {}
		public virtual void Setup(InventoryItemWrapper inventoryItemWrapper, Action<InventoryItemWrapper> afterUseCallback) {}
		public virtual void SetupDisabled(bool button01Disabled, bool button01DisabledIsClickable, Action<InventoryItemWrapper> afterUseCallbackDisabled) {}
		[UICallable]
		public virtual void InteractWithItem(InteractionPurpose interactionPurpose, bool isButtonDisabled) {}
		private void HandleSellItem() {}
		private void SendSellItemRequest() {}
		[UICallable]
		public void ChangeAmountToSell() {}
		private void PopulateOptions(ObservableList<DropdownOption> list, int availableAmount) {}
	}
