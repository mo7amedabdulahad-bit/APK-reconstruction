// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WaitForBackendScreenController : ViewModel
	{
		// Fields
		[SerializeField]
		private RectTransform loadingWheelTransform;
		[SerializeField]
		private float angleRotation;
		[SerializeField]
		private float showUpDelay;
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private bool _blockInteractions;
		private Action<WaitForBackendScreenController> onShutDown;
		private readonly Dictionary<int, double> requests;
		private readonly List<System.Action> onFinished;
	
		// Properties
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public bool blockInteractions { get => default; set {} }
		public RectTransform LoadingWheelTransform { get => default; set {} }
		public float ShowUpDelay { get => default; set {} }
	
		// Constructors
		public WaitForBackendScreenController() {}
	
		// Methods
		protected override void Awake() {}
		protected virtual void Update() {}
		public virtual void Init() {}
		public void Setup(Action<WaitForBackendScreenController> onShutDown) {}
		protected override void OnDestroy() {}
		public virtual void AnimateLoadingSprite(float deltaTime) {}
		public virtual void Show(object requestObj, bool showImmediately, bool shouldBlockInteractions) {}
		public virtual void Show(object requestObj) {}
		public virtual void OnResponse(object requestObj) {}
		private void SetIsActive() {}
		public void CallbackOnFinished(System.Action action) {}
	}
