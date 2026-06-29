// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ToastMessageAnimator : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private string _displayedMessage;
		[ObservableValue]
		private ToastMessageType _displayedMessageType;
		[SerializeField]
		private RectTransform parentTransform;
		[SerializeField]
		private CanvasGroup canvasGroup;
		[SerializeField]
		private UnityEngine.UI.Image flashImage;
		private DG.Tweening.Sequence sequence;
	
		// Properties
		[ObservableValue]
		public string displayedMessage { get => default; set {} }
		[ObservableValue]
		public ToastMessageType displayedMessageType { get => default; set {} }
	
		// Constructors
		public ToastMessageAnimator() {}
	
		// Methods
		protected new void Awake() {}
		public void Init(RectTransform rootTransform, CanvasGroup toastCanvasGroup, UnityEngine.UI.Image flashImage) {}
		public void PlayAnimation(ToastMessageController.ToastMessage currentMessage, float initialPhase, float secondPhase, float pauseAfterInitialPhase, float staticTime, float totalTime, System.Action onComplete) {}
	}
