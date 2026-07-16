// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WholeInventoryDroppable : ViewModel, IDroppableObject
	{
		// Fields
		[ObservableValue]
		private DropStatus _activeDropStatus;
	
		// Properties
		[ObservableValue]
		public DropStatus activeDropStatus { get => default; set {} }
	
		// Constructors
		public WholeInventoryDroppable() {}
	
		// Methods
		public new void Awake() {}
		public new void OnDestroy() {}
		private void OnStartDragging(IDraggableObject draggable) {}
		private void OnStopDragging(IDraggableObject draggable) {}
		public System.Type GetDropTargetType() => default;
		public GameObject GetGameObject() => default;
		public bool IsDroppable(IDraggableObject draggedObj) => default;
		public void OnDropped(IDraggableObject draggedObj, System.Action cleanupDraggedElement) {}
		public void ResetDropStatus() {}
		public void SetDropStatus(DropStatus newStatus) {}
	}
