// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.RateThisApp
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RateThisAppMainMenuUIController : ViewModel
	{
		// Fields
		private const int AnimationSortingOrder = 999;
		private const float IntroAnimationDuration = 1f;
		private const float WaitTime = 2f;
		private const float OutroAnimationDuration = 1f;
		private const float StarParticleLoopDuration = 60f;
		[SerializeField]
		private ParticleSystem starParticles;
		[Header("Intro Animation")]
		[SerializeField]
		private Transform rateThisAppButton;
		[SerializeField]
		private RectTransform messageTransform;
		[SerializeField]
		private TextMeshProUGUI messageText;
		[SerializeField]
		private Transform thumbsUpTransform;
		[SerializeField]
		private UnityEngine.UI.Image coverButtonBackground;
		[SerializeField]
		private RectTransform leftAnimationAnchor;
		private DG.Tweening.Sequence buttonIntroSequence;
		private Tween buttonHighlightTween;
		private float messageBackgroundWidth;
		private UnityEngine.Canvas parentCanvas;
		private IRTAService rtaService;
		private int startSortingOrder;
		private float targetMessageWidth;
	
		// Properties
		private float MessageBackgroundWidth { get => default; set {} }
	
		// Constructors
		public RateThisAppMainMenuUIController() {}
	
		// Methods
		[UICallable]
		public virtual void ShowRateThisAppPopup() {}
		protected void Start() {}
		public void Setup() {}
		protected override void OnDestroy() {}
		private void OnShowRTAButtonTriggered() {}
		private void OnShowRTAButtonStateChanged(bool show) {}
		private void StartButtonHighlight() {}
		private void OnPopupClosed(RTAService.ePopUpCloseReason reason) {}
		private void PlayButtonIntroAnimation() {}
	}
