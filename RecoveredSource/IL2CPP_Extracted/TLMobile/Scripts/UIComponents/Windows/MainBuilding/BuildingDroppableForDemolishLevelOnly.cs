// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDroppableForDemolishLevelOnly : BuildingDroppableForDemolishLevel
	{
		// Fields
		private Action<BuildingInfo> demolishLevel;
	
		// Constructors
		public BuildingDroppableForDemolishLevelOnly() {}
	
		// Methods
		public override void Setup(ArrangementPopupController arrangementPopupController) {}
		protected override void OnDropped(DraggableObject<BuildingInfo> draggedObj, System.Action cleanupDraggedElement) {}
		protected override bool IsDroppable(DraggableObject<BuildingInfo> draggedObj) => default;
		public override void ResetDropStatus() {}
	}
