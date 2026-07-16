// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryDraggable : DraggableObject<InventoryItemWrapper>
	{
		// Fields
		public Action<InventoryDraggable> OnDragBegin;
		public Action<InventoryDraggable> OnDragEnd;
		[Header("Drag to area")]
		[SerializeField]
		[Tooltip("When true, normal drag and drop will not be possible, but dragging to a specific area will be possible.")]
		private bool enableDragToArea;
		[SerializeField]
		private RectTransform targetArea;
		[ObservableValue]
		protected bool _emptyOrDraggable;
		private InventoryItemDataContainer injectableData;
		[HideInInspector]
		public int sourcePlaceId;
	
		// Properties
		[ObservableValue]
		public bool emptyOrDraggable { get => default; set {} }
	
		// Constructors
		public InventoryDraggable() {}
	
		// Methods
		protected override bool IsDraggable() => default;
		protected override void TransferData() {}
		public override void ResetDraggedObject() {}
		public override void OnBeginDrag(PointerEventData eventData) {}
	}
