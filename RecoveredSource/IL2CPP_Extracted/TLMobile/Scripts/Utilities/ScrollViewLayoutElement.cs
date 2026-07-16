// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ScrollViewLayoutElement : LayoutElement
	{
		// Fields
		public bool useMaxHeight;
		public float maxHeight;
		private RectTransform content;
		private float oldCalculatedHeight;
		private System.Action recalculatePreferredHeightDelegate;
	
		// Properties
		public override float preferredHeight { get => default; set {} }
	
		// Constructors
		public ScrollViewLayoutElement() {}
	
		// Methods
		protected override void Awake() {}
		public override void CalculateLayoutInputVertical() {}
		private void RecalculatePreferredHeight() {}
	}
