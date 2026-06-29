// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDraggableObjectForDemolishBuilding : BuildingDraggableObject
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private int _placeId;
		private Action<int> setPlaceId;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public int placeId { get => default; set {} }
	
		// Constructors
		public BuildingDraggableObjectForDemolishBuilding() {}
	
		// Methods
		public override void Setup(ArrangementPopupController arrangementPopupController) {}
		protected override void StartDragging(PointerEventData eventData) {}
		protected override bool IsDraggable() => default;
	}
