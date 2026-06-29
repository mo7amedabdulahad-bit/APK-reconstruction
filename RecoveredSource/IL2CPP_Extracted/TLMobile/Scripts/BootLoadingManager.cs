// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootLoadingManager : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private int waitForFrames;
		[SerializeField]
		private GameHelper gameHelper;
		[SerializeField]
		private BootController bootController;
		[SerializeField]
		private PermanentGameObjectSaver permanentGameObjectSaver;
		[SerializeField]
		private UnityServiceProvider unityServiceProvider;
		[SerializeField]
		private ToastMessageController toastMessageController;
		[SerializeField]
		private PluginsLogHandler pluginsLogHandler;
		[SerializeField]
		private LobbyUIStateController lobbyUIStateController;
		[Header("Loading Screen")]
		[SerializeField]
		private AnimationToolboxService animationToolboxService;
		private RepeatedCallHelper repeatedCallHelper;
		private CacheService cacheService;
		private IPromise bootProcess;
	
		// Constructors
		public BootLoadingManager() {}
	
		// Methods
		private void Awake() {}
		private async void Start() {}
		private async System.Threading.Tasks.Task ShowLoadingScreen() => default;
		private IPromise BootLoading() => default;
	}
