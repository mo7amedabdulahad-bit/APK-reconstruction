// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDragAndDroppableService : IService
	{
		// Properties
		bool RemoveDataFromSource { get; set; }
	
		// Events
		event Action<IDraggableObject> OnStartDragging;
		event Action<IDraggableObject> OnStopDragging;
		event Action<IDraggableObject, IDroppableObject> OnDropped;
		event System.Action OnDragDropRefresh;
	
		// Methods
		void InvokeOnStartDragging(IDraggableObject draggable);
		void InvokeOnStopDragging(IDraggableObject draggable);
		void InvokeOnDropped(IDraggableObject draggable, IDroppableObject target);
		void RegisterContextController(IDragAndDropContextController contextController);
		void UnregisterContextController(IDragAndDropContextController contextController);
		bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target);
		bool IsDraggable(IDraggableObject draggable);
		bool IsDroppable(IDraggableObject draggable, IDroppableObject target);
		void RefreshAllObjects();
	}
