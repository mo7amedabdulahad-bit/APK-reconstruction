// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LayoutSideObjectCorrection : TLMViewModel, ILayoutElement
	{
		// Fields
		[SerializeField]
		private Transform sideObject;
		[ObservableValue]
		private int _activeChildCount;
		private bool isRightSide;
		private HorizontalLayoutGroup layoutGroup;
		private RectOffset originalPadding;
		private RectOffset correctedPadding;
		private RectTransform rectTransform;
	
		// Properties
		[ObservableValue]
		public int activeChildCount { get => default; set {} }
		public float minWidth { get; }
		public float preferredWidth { get; }
		public float flexibleWidth { get; }
		public float minHeight { get; }
		public float preferredHeight { get; }
		public float flexibleHeight { get; }
		public int layoutPriority { get; }
	
		// Constructors
		public LayoutSideObjectCorrection() {}
	
		// Methods
		private new void Awake() {}
		protected override void OnEnable() {}
		private void CorrectLayout() {}
		public void CalculateLayoutInputHorizontal() {}
		public void CalculateLayoutInputVertical() {}
	}
