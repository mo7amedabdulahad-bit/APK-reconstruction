// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LobbyUIStateController : TLMViewModel, IBootable
	{
		// Fields
		[SerializeField]
		private bool initOnItsOwn;
		[ObservableValue]
		private int _keyboardHeight;
		private IDeviceFunctionsService deviceFunctionsService;
		private UnityEngine.Canvas rootCanvas;
		[SerializeField]
		private DetailWindowsShowController showController;
	
		// Properties
		[ObservableValue]
		public int keyboardHeight { get => default; set {} }
	
		// Constructors
		public LobbyUIStateController() {}
	
		// Methods
		protected override void Awake() {}
		private void Start() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void FrameUpdate() {}
	}
