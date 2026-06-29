// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDroppableForRearrangeBuilding : BuildingDroppable
	{
		// Fields
		private Action<BuildingInfo, int?, int?> rearrangeBuilding;
	
		// Constructors
		public BuildingDroppableForRearrangeBuilding() {}
	
		// Methods
		public override void Setup(ArrangementPopupController arrangementPopupController) {}
		protected override bool IsDroppable(DraggableObject<BuildingInfo> draggedObj) => default;
		protected override void OnDropped(DraggableObject<BuildingInfo> draggedObj, System.Action cleanupDraggedElement) {}
	}
