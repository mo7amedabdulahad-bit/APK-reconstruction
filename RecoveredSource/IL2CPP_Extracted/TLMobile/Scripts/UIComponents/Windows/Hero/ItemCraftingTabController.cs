// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ItemCraftingTabController : DetailWindowTabController, IDragAndDropContextController
	{
		// Fields
		private const string NotAvailableAnymoreTranslationKey = "hero_crafting_action_error_missingItem";
		private const HeroItemCategory EquipmentItemCategories = HeroItemCategory.HeadGear | HeroItemCategory.Utility | HeroItemCategory.Weapon | HeroItemCategory.Armour | HeroItemCategory.Boots;
		protected InventoryController inventoryController;
		protected GraphQLFetchableList<HeroInventoryItem> inventoryRawData;
		private HeroEquipment equipment;
		private OwnHero ownHero;
		private ItemSlotError itemSlotError;
		[ObservableValue]
		private bool _hasNoEquipmentItems;
	
		// Properties
		[ObservableValue]
		public bool hasNoEquipmentItems { get; set; }
	
		// Constructors
		protected ItemCraftingTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected abstract List<InventoryItemWrapper> GetItemsInUse();
		protected virtual void OnInventoryChanged() {}
		protected bool HasNoEquipmentItems() => default;
		protected void UpdateItemAmountInUse() {}
		[UICallable]
		public virtual IPromise Equip(InventoryItemWrapper item, bool resetSlotWrapper = true) => default;
		[UICallable]
		public virtual void MoveToInventory(InventoryItemWrapper item) {}
		[UICallable]
		public virtual void BuyItem(InventoryItemWrapper wrapper) {}
		[UICallable]
		public virtual void CraftMaterial() {}
		protected virtual void RefreshDragState() {}
		protected virtual void RefreshInventory() {}
		protected virtual void OnCraftingApiException(Exception exception) {}
		protected bool DraggableIsItem(IDraggableObject draggable, bool acceptFakes = true) => default;
		protected bool DraggableIsMaterial(IDraggableObject draggable, bool acceptFakes = true) => default;
		protected virtual void OnItemSelected(int placeId, InventoryItemWrapper item) {}
		public virtual bool IsDraggable(IDraggableObject draggable) => default;
		public virtual bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
		public virtual void OnStartDragging(IDraggableObject draggable) {}
		public virtual void OnStopDragging(IDraggableObject draggable) {}
		public virtual bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target) => default;
		public virtual void OnDropped(IDraggableObject draggable, IDroppableObject target) {}
		protected virtual ItemSlotError IsSlotFitting(InventoryItemWrapper item, InventoryDroppable target) => default;
	}
