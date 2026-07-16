// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDragAndDropContextController
	{
		// Methods
		bool IsDraggable(IDraggableObject draggable);
		bool IsDroppable(IDraggableObject draggable, IDroppableObject target);
		void OnStartDragging(IDraggableObject draggable);
		void OnStopDragging(IDraggableObject draggable);
		void OnDropped(IDraggableObject draggable, IDroppableObject target);
		bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target);
	}
