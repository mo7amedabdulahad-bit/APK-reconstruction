// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UISwipeAnimator : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private RectTransform target;
		[SerializeField]
		private Vector2 swipeOffset;
		[SerializeField]
		private float swipeDuration;
		[SerializeField]
		private Ease swipeEase;
		[SerializeField]
		private bool fadeDuringSwipe;
		[SerializeField]
		private float endAlpha;
		[SerializeField]
		private float fadeDuration;
		[SerializeField]
		private float fadeInDuration;
		[SerializeField]
		private float fadeDelay;
		[SerializeField]
		private bool loop;
		[SerializeField]
		private LoopType loopType;
		[SerializeField]
		private float delayBetweenLoops;
		[SerializeField]
		private bool autoStart;
		private CanvasGroup canvasGroup;
		private DG.Tweening.Sequence swipeSequence;
		private Vector2 originalPosition;
		private float originalAlpha;
	
		// Constructors
		public UISwipeAnimator() {}
	
		// Methods
		private void Awake() {}
		private void OnEnable() {}
		private void OnDisable() {}
		private void OnDestroy() {}
		[ContextMenu("Play")]
		public void Play() {}
		public void Stop() {}
	}
