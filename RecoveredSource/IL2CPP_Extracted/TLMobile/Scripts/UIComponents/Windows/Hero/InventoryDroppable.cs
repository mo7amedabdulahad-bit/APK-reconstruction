// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryDroppable : BaseDroppable<InventoryItemWrapper>
	{
		// Fields
		private const int AmountToUse = 1;
		public HeroItemCategory fittingCategory;
		public SlotType slotType;
		[InjectableValue]
		[ObservableValue]
		private InventoryItemWrapper _item;
		[InjectableValue]
		[ObservableValue]
		private HeroItemCategory _currentFilter;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _placeId;
		[ObservableValue]
		private bool _isSlotEnabled;
		[ObservableValue]
		private bool _isSlotInteractable;
		private InventoryItemWrapper oldItem;
		private OwnHero ownHero;
		private DraggableObject<InventoryItemWrapper> currentlyDraggedObj;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public InventoryItemWrapper item { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public HeroItemCategory currentFilter { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int placeId { get => default; set {} }
		[ObservableValue]
		public bool isSlotEnabled { get => default; set {} }
		[ObservableValue]
		public bool isSlotInteractable { get => default; set {} }
		[ObservableValue]
		public int SlotAmountToUse { get => default; }
	
		// Nested types
		public enum SlotType
		{
			InventorySlot = 0,
			EquipmentSlot = 1,
			CraftingSlot = 2
		}
	
		// Constructors
		public InventoryDroppable() {}
	
		// Methods
		protected void OnEnable() {}
		protected override void OnDisable() {}
		public override void OnInjectedValueChanged() {}
		protected override void ReactToDragStart(DraggableObject<InventoryItemWrapper> draggedObj) {}
		protected override void ReactToDragStop(DraggableObject<InventoryItemWrapper> draggedObj) {}
		private void CheckSlotStatus() {}
		private void CheckSlotInteractableState() {}
		private void CheckSlotActiveState() {}
		protected override void OnDropped(DraggableObject<InventoryItemWrapper> draggedObj, System.Action cleanupDraggedElement) {}
		private void HandleItemCraftingInventory(DraggableObject<InventoryItemWrapper> draggedObj, System.Action cleanupDraggedElement) {}
		private bool HandleGeneralInventory(DraggableObject<InventoryItemWrapper> draggedObj, System.Action cleanupDraggedElement) => default;
	}
