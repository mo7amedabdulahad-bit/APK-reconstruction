// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DraggableHandle : TLMViewModel, IDragHandler, IEndDragHandler
	{
		// Fields
		public float minHeight;
		[SerializeField]
		private RectTransform rectTransform;
		public UnityEvent OnMinimize;
		public UnityEvent<float> OnHeightChange;
		[ObservableValue]
		private float _rectTransformHeightToConsider;
		private float additionalMaxHeight;
		private float additionalStartHeight;
		private float canvasMaxHeight;
		private float maxHeight;
		private float startHeight;
	
		// Properties
		[ObservableValue]
		public float rectTransformHeightToConsider { get => default; set {} }
	
		// Constructors
		public DraggableHandle() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void OnDrag(PointerEventData eventData) {}
		public void OnEndDrag(PointerEventData eventData) {}
		public void SetStartHeightAndMaxHeight(float? additionalStartHeight = default, float? additionalMaxHeight = default) {}
		private void ApplyOffset() {}
	}
