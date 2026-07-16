// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BottomMenuAnimationController : InjectableViewModel
	{
		// Fields
		private const float ButtonBigScale = 1.2f;
		private const float CircleBigScale = 2f;
		[InjectableValue]
		[ObservableValue]
		private MainUIView _currentView;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private MainUIView _viewToSwitchTo;
		public RectTransform buttonRectObject;
		public RectTransform circleObject;
		public UnityEngine.UI.Image circleImageObject;
		public UnityEngine.UI.Image shineOverlayObject;
		private DG.Tweening.Sequence masterIntroSequence;
		private DG.Tweening.Sequence masterOutroSequence;
		private bool active;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public MainUIView currentView { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public MainUIView viewToSwitchTo { get => default; set {} }
	
		// Constructors
		public BottomMenuAnimationController() {}
	
		// Methods
		protected override void Awake() {}
		public virtual void Init() {}
		public override void OnInjectedValueChanged() {}
		private void ViewSwitched() {}
		public virtual void PlayIntro() {}
		public virtual void PlayOutro() {}
	}
