// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.ListDragAndDrop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ListDragElementHandler : InjectableViewModel
	{
		// Fields
		public ListDragAndDropController dragAndDropController;
		public RectTransform parentObjectWhileDragged;
		public RectTransform emptyRowObject;
		public float dragPixelsIndent;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _groupId;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _elementId;
		[ObservableValue]
		private bool _isDragged;
		private int currentSiblingIndex;
		private bool isLongPress;
		private RectTransform objectToDrag;
		private Transform objectToDragOriginalParent;
		private Transform originalEmptyRowParent;
		private Transform targetObject;
		private bool isBelowTarget;
	
		// Properties
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int groupId { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int elementId { get => default; set {} }
		[ObservableValue]
		public bool isDragged { get => default; set {} }
		public bool DropEnabled { get; set; }
	
		// Constructors
		public ListDragElementHandler() {}
	
		// Methods
		protected override void Awake() {}
		private void Update() {}
		public void Init() {}
		[UICallable]
		public void OnLongPress() {}
		public void OnDrag(BaseEventData eventData) {}
		public void OnEndDrag() {}
		private void PerformLongPressAction() {}
		private void InsertEmptyRowOver(Transform target) {}
		private void SetDraggedObjectPosition(Vector2 newPosition, float heightDifference = 0f) {}
	}
