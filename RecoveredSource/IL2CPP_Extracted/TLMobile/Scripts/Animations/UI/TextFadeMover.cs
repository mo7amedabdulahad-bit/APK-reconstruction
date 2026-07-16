// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFadeMover : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private float fadeInDuration;
		[SerializeField]
		private float fadeOutDuration;
		[SerializeField]
		private float holdDuration;
		[SerializeField]
		private Ease fadeEase;
		[SerializeField]
		private Vector2 startOffset;
		[SerializeField]
		private Vector2 endOffset;
		[SerializeField]
		private float moveDuration;
		[SerializeField]
		private Ease moveEase;
		private CanvasGroup canvasGroup;
		private Vector3 originalPosition;
		private Tween sequenceTween;
	
		// Constructors
		public TextFadeMover() {}
	
		// Methods
		private void Awake() {}
		[ContextMenu("Play")]
		public void Play() {}
		public void Stop() {}
	}
