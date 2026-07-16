// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.ListDragAndDrop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ListDragAndDropScroller : MonoBehaviour
	{
		// Fields
		public ScrollRect associatedScrollRect;
		public ListDragAndDropController dragAndDropController;
		[Tooltip("If true scrolls up, if false scrolls down. ")]
		public bool isScrollingUp;
		private Coroutine performScrollingCoroutine;
	
		// Constructors
		public ListDragAndDropScroller() {}
	
		// Methods
		public void OnPointerEnter() {}
		public void OnPointerExit() {}
		[IteratorStateMachine(typeof(_PerformScrollingCoroutine_d__6))]
		private IEnumerator PerformScrollingCoroutine() => default;
	}
