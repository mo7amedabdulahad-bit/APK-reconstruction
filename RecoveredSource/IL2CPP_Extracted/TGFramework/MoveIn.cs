// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MoveIn : AnimatorPlayable
	{
		// Fields
		[SerializeField]
		private UnityEngine.UI.Image image;
		[SerializeField]
		private float fadeDuration;
		[SerializeField]
		private Vector2 offset;
		[SerializeField]
		private float duration;
		[SerializeField]
		private Ease ease;
		[SerializeField]
		private float delay;
		private bool isInitialized;
		private RectTransform animatedRectTransform;
		private Vector2 startPosition;
		private Vector2 targetPosition;
		private DG.Tweening.Sequence sequence;
	
		// Properties
		public RectTransform AnimatedRectTransform { get => default; }
		public override bool IsPlaying { get => default; }
	
		// Constructors
		public MoveIn() {}
	
		// Methods
		protected override void OnEnable() {}
		private void OnDestroy() {}
		[ContextMenu("Play Animation")]
		public override void PlayWithoutDelay() {}
		public override void Stop() {}
		protected override void ResetAnimationValues() {}
	}
