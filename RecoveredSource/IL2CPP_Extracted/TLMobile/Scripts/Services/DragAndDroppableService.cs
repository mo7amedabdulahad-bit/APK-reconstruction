// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DragAndDroppableService : MonoBehaviour, IDragAndDroppableService
	{
		// Fields
		private List<IDragAndDropContextController> contextControllers;
		private bool removeDataFromSource;
		private bool refreshRequested;
	
		// Properties
		public bool RemoveDataFromSource { get => default; set {} }
	
		// Events
		public event Action<IDraggableObject> OnStartDragging;
		public event Action<IDraggableObject> OnStopDragging;
		public event Action<IDraggableObject, IDroppableObject> OnDropped;
		public event System.Action OnDragDropRefresh;
	
		// Constructors
		public DragAndDroppableService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void InvokeOnStartDragging(IDraggableObject item) {}
		public void InvokeOnStopDragging(IDraggableObject item) {}
		public bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target) => default;
		public void InvokeOnDropped(IDraggableObject draggable, IDroppableObject target) {}
		public void RegisterContextController(IDragAndDropContextController contextController) {}
		public void UnregisterContextController(IDragAndDropContextController contextController) {}
		public bool IsDraggable(IDraggableObject draggable) => default;
		public bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
		public void RefreshAllObjects() {}
	}
