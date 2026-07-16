// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class EquipmentTabController : DetailWindowTabController, IDragAndDropContextController
	{
		// Fields
		private InventoryController inventoryController;
		private OwnHero ownHero;
	
		// Constructors
		public EquipmentTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		[UICallable]
		public void OpenEquipmentBenefits() {}
		public bool IsDraggable(IDraggableObject draggable) => default;
		public bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
		public void OnStartDragging(IDraggableObject draggable) {}
		public void OnStopDragging(IDraggableObject draggable) {}
		public void OnDropped(IDraggableObject draggable, IDroppableObject target) {}
		public bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target) => default;
	}
