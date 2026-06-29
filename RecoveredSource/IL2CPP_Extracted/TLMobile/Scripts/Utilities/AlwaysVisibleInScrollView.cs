// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AlwaysVisibleInScrollView : TLMViewModel
	{
		// Fields
		public float tweenDuration;
		public RectTransform target;
		public ScrollRect scrollRect;
		private RectTransform scrollContent;
		private RectTransform scrollViewport;
	
		// Constructors
		public AlwaysVisibleInScrollView() {}
	
		// Methods
		protected override void Awake() {}
		[UICallable]
		public void StayVisible() {}
		[IteratorStateMachine(typeof(_RecalculatePositionAfterFrames_d__7))]
		private IEnumerator RecalculatePositionAfterFrames(int framesToSkip) => default;
	}
