// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UIScalePulseAnimator : AnimatorPlayable
	{
		// Fields
		[SerializeField]
		private RectTransform target;
		[SerializeField]
		private float scaleStart;
		[SerializeField]
		private float scaleUp;
		[SerializeField]
		private float scaleDown;
		[SerializeField]
		[Space]
		private float pulseDuration;
		[SerializeField]
		private Ease pulseEaseUp;
		[SerializeField]
		private Ease pulseEase;
		[SerializeField]
		[Space]
		private bool fadeOnContract;
		[SerializeField]
		private float fadedAlpha;
		[SerializeField]
		[Space]
		private bool loop;
		[SerializeField]
		private LoopType loopType;
		private CanvasGroup canvasGroup;
		private float originalAlpha;
		private Vector3 originalScale;
		private DG.Tweening.Sequence pulseSequence;
	
		// Properties
		public override bool IsPlaying { get => default; }
	
		// Constructors
		public UIScalePulseAnimator() {}
	
		// Methods
		private void Awake() {}
		private void OnDestroy() {}
		[ContextMenu("PlayWithoutDelay")]
		public override void PlayWithoutDelay() {}
		public override void Stop() {}
		protected override void ResetAnimationValues() {}
	}
