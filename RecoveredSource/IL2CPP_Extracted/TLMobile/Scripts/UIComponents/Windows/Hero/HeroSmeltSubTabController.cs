// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroSmeltSubTabController : ItemCraftingTabController
	{
		// Fields
		[ObservableValue]
		private HeroItemCategory _everyCategory;
		[ObservableValue]
		private CraftingItems _craftingItems;
		[ObservableValue]
		private SmeltingState _smeltingState;
		[ObservableValue]
		private bool _enableSmeltImmediately;
		[ObservableValue]
		private int _smeltImmediatelyCost;
		[ObservableValue]
		private InventoryItemWrapper _smeltSlot;
		[ObservableValue]
		private InventoryItemWrapper _materialSlot1;
		[ObservableValue]
		private InventoryItemWrapper _materialSlot2;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.SmeltedItem _secondMaterial;
		[ObservableValue]
		private bool _showEarlyCollectWarning;
		[ObservableValue]
		private int _takeableAmount;
		[ObservableValue]
		private int _maxAmount;
		[ObservableValue]
		private float _secondMaterialProgress;
	
		// Properties
		[ObservableValue]
		public HeroItemCategory everyCategory { get => default; set {} }
		[ObservableValue]
		public CraftingItems craftingItems { get => default; set {} }
		[ObservableValue]
		public SmeltingState smeltingState { get => default; set {} }
		[ObservableValue]
		public bool enableSmeltImmediately { get => default; set {} }
		[ObservableValue]
		public int smeltImmediatelyCost { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper smeltSlot { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper materialSlot1 { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper materialSlot2 { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.SmeltedItem secondMaterial { get => default; set {} }
		[ObservableValue]
		public bool showEarlyCollectWarning { get => default; set {} }
		[ObservableValue]
		public int takeableAmount { get => default; set {} }
		[ObservableValue]
		public int maxAmount { get => default; set {} }
		[ObservableValue]
		public float secondMaterialProgress { get => default; set {} }
	
		// Nested types
		public enum SmeltingState
		{
			Idle = 0,
			ReadyToSmelt = 1,
			InProgress = 2,
			Completed = 3
		}
	
		// Constructors
		public HeroSmeltSubTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void UpdateSecondMaterialProgress() {}
		protected override List<InventoryItemWrapper> GetItemsInUse() => default;
		protected override void OnItemSelected(int placeId, InventoryItemWrapper item) {}
		public override void OnDropped(IDraggableObject draggable, IDroppableObject dropTarget) {}
		public override void OnStartDragging(IDraggableObject draggable) {}
		public override void OnStopDragging(IDraggableObject draggable) {}
		private void OnItemSlotUpdated(int? targetSlot, InventoryItemWrapper item) {}
		private void RefreshData() {}
		private void RefreshSmeltingState() {}
		private void ResetSmeltSlot() {}
		private void ResetMaterialSlots() {}
		private void ResetSmeltingToIdle() {}
		private void OnDraggedToInventory(InventoryItemWrapper item) {}
		[UICallable]
		public void SetItemToSmelt(InventoryItemWrapper item) {}
		[UICallable]
		public void SmeltItem() {}
		[UICallable]
		public void TakeMaterials() {}
		[UICallable]
		public void CompleteImmediately() {}
		public override bool IsDraggable(IDraggableObject draggable) => default;
		public override bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
	}
