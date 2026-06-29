// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroForgeTabController : ItemCraftingTabController
	{
		// Fields
		private const int MaterialSlotCount = 3;
		[SerializeField]
		private HeroForgeProbabilityController heroForgeProbabilityController;
		[ObservableValue]
		private ForgeState _state;
		[ObservableValue]
		private ObservableList<InventoryItemWrapper> _forgeMaterials;
		[ObservableValue]
		private ObservableList<InventoryItemWrapper> _forgedEquipment;
		[ObservableValue]
		private InventoryItemWrapper _forgeOutput;
		[ObservableValue]
		private InventoryItemWrapper _emptyFakeItem;
		[ObservableValue]
		private HeroItemCategory _filterCategoryForSlots;
		[ObservableValue]
		private InventoryItemWrapper _templateAuctionMaterial;
		private CraftingItems crafting;
	
		// Properties
		[ObservableValue]
		public ForgeState state { get => default; set {} }
		[ObservableValue]
		public ObservableList<InventoryItemWrapper> forgeMaterials { get => default; set {} }
		[ObservableValue]
		public ObservableList<InventoryItemWrapper> forgedEquipment { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper forgeOutput { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper emptyFakeItem { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory filterCategoryForSlots { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper templateAuctionMaterial { get => default; set {} }
	
		// Nested types
		public enum ForgeState
		{
			SelectMaterials = 0,
			NoMoreMaterials = 1,
			Preview = 2,
			Forged = 3
		}
	
		// Constructors
		public HeroForgeTabController() {}
	
		// Methods
		private void _forgeMaterialsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _forgedEquipmentNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override List<InventoryItemWrapper> GetItemsInUse() => default;
		protected override void OnInventoryChanged() {}
		protected override void OnItemSelected(int placeId, InventoryItemWrapper item) {}
		private void StartObserveForSlots() {}
		private void StopObserveForSlots() {}
		private void UseMaterial(InventoryItemWrapper item) {}
		private void RemoveMaterial(int placeId, InventoryItemWrapper item) {}
		public override void OnDropped(IDraggableObject draggable, IDroppableObject dropTarget) {}
		private void UseItem(int? targetSlot, InventoryItemWrapper item) {}
		private void UpdateCurrentForgeState() {}
		private void UpdateCrafting() {}
		private void ClearMaterialSlots() {}
		[UICallable]
		public void DoForge() {}
		[UICallable]
		public void TakeForgedItem(int itemIndex) {}
		[UICallable]
		public void OpenReforge() {}
		public override bool IsDraggable(IDraggableObject draggable) => default;
		public override bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
	}
