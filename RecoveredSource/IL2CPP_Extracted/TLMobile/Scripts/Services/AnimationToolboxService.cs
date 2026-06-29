// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AnimationToolboxService : MonoBehaviour, IAnimationsToolboxService
	{
		// Fields
		[SerializeField]
		private float fadeInDuration;
		[SerializeField]
		private float fadeOutDuration;
		public CloudsController cloudsController;
		public GameObject loadingAnimation;
		public CanvasGroup canvasGroup;
		private bool isDestroyed;
		private bool? isVisible;
		private int loadingCounter;
		private DG.Tweening.Sequence loadingSequence;
	
		// Properties
		public ICloudsController CloudsController { get => default; }
	
		// Events
		public event IAnimationsToolboxService.LoadingAnimationHandler OnLoadingAnimation;
	
		// Constructors
		public AnimationToolboxService() {}
	
		// Methods
		public System.Threading.Tasks.Task Initialize() => default;
		private System.Threading.Tasks.Task AwaitSequence(DG.Tweening.Sequence sequence) => default;
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public void SetLoadingAnimationState(bool visible, string reason = null, bool forceCallback = false) {}
		private void HandleActivate(bool activate) {}
	}
