// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RefineItemTabController : ItemCraftingTabController
	{
		// Fields
		[ObservableValue]
		private InventoryItemWrapper _itemTop;
		[ObservableValue]
		private InventoryItemWrapper _itemBottom;
		[ObservableValue]
		private InventoryItemWrapper _itemMaterial;
		[ObservableValue]
		private InventoryItemWrapper _itemResult;
		[ObservableValue]
		private bool _showTooltip;
		[ObservableValue]
		private bool _showResultItemTooltip;
		[ObservableValue]
		private CraftingAction _methodActionButton01;
		[ObservableValue]
		private CraftingAction _methodActionButton02;
		private RefineError refineError;
	
		// Properties
		[ObservableValue]
		public InventoryItemWrapper itemTop { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper itemBottom { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper itemMaterial { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper itemResult { get => default; set {} }
		[ObservableValue]
		public bool showTooltip { get => default; set {} }
		[ObservableValue]
		public bool showResultItemTooltip { get => default; set {} }
		[ObservableValue]
		public CraftingAction methodActionButton01 { get => default; set {} }
		[ObservableValue]
		public CraftingAction methodActionButton02 { get => default; set {} }
		[ObservableValue]
		public string TranslationKeyActionButton01 { get => default; }
		[ObservableValue]
		public string TranslationKeyActionButton02 { get => default; }
	
		// Nested types
		public enum RefineSlot
		{
			ItemTop = 1,
			ItemBottom = 2,
			Material = 3,
			Result = 4
		}
	
		// Constructors
		public RefineItemTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override List<InventoryItemWrapper> GetItemsInUse() => default;
		private void RemoveItemFromAnySlot(InventoryItemWrapper item) {}
		protected override void OnItemSelected(int placeId, InventoryItemWrapper item) {}
		private void SetupErrorHandlingForPopup(EquipmentTooltipPopupController controller) {}
		private void ErrorHandlingCallback(InventoryItemWrapper wrapper) {}
		public override void OnDropped(IDraggableObject draggable, IDroppableObject dropTarget) {}
		public override bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target) => default;
		private InventoryItemWrapper PutItemInEmptySlot(InventoryItemWrapper item) => default;
		private InventoryItemWrapper PutMaterialInEmptySlot(InventoryItemWrapper item) => default;
		private bool ShouldFakeItems() => default;
		private RefineError IsItemCompatible(InventoryItemWrapper target, InventoryItemWrapper itemToCheck) => default;
		private void TryFakeItemInput() {}
		private void FillMaterial() {}
		private void UpdateCompleteRefineState() {}
		[UICallable]
		public void ToggleItemTooltip() {}
		[UICallable]
		public void CallButtonAction(CraftingAction action) {}
		private void Refine() {}
		public override bool IsDraggable(IDraggableObject draggable) => default;
		public override bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
		public override void OnStartDragging(IDraggableObject draggable) {}
	}
