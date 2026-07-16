// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ItemCountAdjusterForRectTransformHeight : InjectableViewModel
	{
		// Fields
		public int maxListItemsAtStart;
		public DraggableHandle draggableHandle;
		public RectTransform rectTransform;
		public VerticalLayoutGroup verticalLayoutGroup;
		public RectTransform itemRectTransform;
		public float itemHeight;
		[InjectableValue(acceptsConstant = true, hasToBeSet = true)]
		[ObservableValue]
		private int _itemCount;
		private float maxScrollRectHeight;
		private float minScrollRectHeight;
	
		// Properties
		[InjectableValue(acceptsConstant = true, hasToBeSet = true)]
		[ObservableValue]
		public int itemCount { get => default; set {} }
	
		// Constructors
		public ItemCountAdjusterForRectTransformHeight() {}
	
		// Methods
		protected override void Awake() {}
		[ContextMenu("UpdateItemHeight")]
		private void UpdateItemHeight() {}
		private void UpdateRectTransformHeight() {}
		public void SetRectTransformHeight(float height) {}
	}
