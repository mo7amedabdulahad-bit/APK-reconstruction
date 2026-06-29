// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDroppableObject
	{
		// Methods
		System.Type GetDropTargetType();
		GameObject GetGameObject();
		bool IsDroppable(IDraggableObject draggedObj);
		void OnDropped(IDraggableObject draggedObj, System.Action cleanupDraggedElement);
		void ResetDropStatus();
		void SetDropStatus(DropStatus newStatus);
	}
