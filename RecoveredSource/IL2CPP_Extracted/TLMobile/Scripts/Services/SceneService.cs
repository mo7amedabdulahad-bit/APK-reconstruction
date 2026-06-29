// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SceneService : MonoBehaviour, ISceneService
	{
		// Fields
		public const string VillageViewObjectContainerName = "VillageView";
		public const string ResourcesViewObjectContainerName = "ResourcesView";
		public const string MapViewObjectContainerName = "Map";
		public const string LoginSceneName = "Login";
		public const string BootstrapSceneName = "Bootstrap";
		[Header("Scene Names Configuration")]
		[SerializeField]
		private string mainSceneNameForInit;
		[Header("Scene Content Configuration")]
		[SerializeField]
		private string[] notMoveToMainScene;
		private readonly List<string> currentlyLoadingScenes;
		private readonly Dictionary<string, SceneCameraData> loadedViewCameraSettings;
		private readonly Dictionary<string, GameObject> loadedViewParentObjects;
		private readonly Dictionary<string, IScreenConfiguration> loadedViewScreenConfigurations;
		private Coroutine applySceneChangesCoroutine;
		private bool isMainSceneLoading;
		private Coroutine loadSceneCoroutine;
		private Scene mainScene;
		private bool transitionInProgress;
		private System.Action onTransitionStart;
		private System.Action onViewChange;
		private System.Action onTransitionEnd;
		private ViewTransition currentViewTransition;
	
		// Properties
		public string MainSceneName { get; private set; }
		public SceneStatus CurrentSceneStatus { get; private set; }
		public IReadOnlyDictionary<string, GameObject> LoadedViewParentObjects { get => default; }
	
		// Events
		public event Action<SceneStatus> ViewChanged;
		public event System.Action LoggedOut;
		public event System.Action LoadMainSceneStarted;
	
		// Nested types
		private struct SceneCameraData
		{
			// Properties
			public Vector3 Position { [IsReadOnly] get; set; }
			public float Size { [IsReadOnly] get; set; }
		}
	
		// Constructors
		public SceneService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		private IPromise Init(string nameMainScene) => default;
		private void CleanupTransitionHandlers() {}
		public void LoadMainScene(System.Action sceneLoadedCallback = null) {}
		public void LoadLoginScene() {}
		public bool LoadOtherScene(string sceneName) => default;
		public GameObject MoveGameObjectsToMainScene(GameObject[] objectsInScene, string parentName) => default;
		public void SwitchToSitter(System.Action sceneLoadedCallback = null) {}
		public bool SwitchToVillageView() => default;
		public bool SwitchToResourcesView() => default;
		public bool SwitchToMapView(int xPos, int yPos, bool targetSelection = false) => default;
		public bool SwitchToOtherView(string viewName, bool targetSelection = false) => default;
		public void ExitToLogin() {}
		public void PrepareLoginScene() {}
		public IScreenConfiguration GetCurrentScreenConfiguration() => default;
		public void SetCurrentScreenConfiguration(IScreenConfiguration screenConfiguration) {}
		[IteratorStateMachine(typeof(_ApplyChangeViewWhenReady_d__57))]
		private IEnumerator ApplyChangeViewWhenReady(string viewName, bool targetSelection = false) => default;
		private string ViewName(SceneStatus sceneStatus) => default;
		[IteratorStateMachine(typeof(_LoadOtherSceneFinalizationCoroutine_d__59))]
		private IEnumerator LoadOtherSceneFinalizationCoroutine(string sceneName) => default;
		private void SwitchToOtherView(string viewName, ViewTransition viewTransition, bool scaledAnimation) {}
		[IteratorStateMachine(typeof(_LoadLoginSceneCoroutine_d__61))]
		private IEnumerator LoadLoginSceneCoroutine() => default;
		[IteratorStateMachine(typeof(_LoadMainSceneCoroutine_d__62))]
		private IEnumerator LoadMainSceneCoroutine(System.Action sceneLoadedCallback) => default;
		private void PreloadAdsForMainScene() {}
		private static void DestroyPermanentGameObjects() {}
		private void SetCurrentSceneStatus(string viewName, bool targetSelection = false) {}
		private void ChangeViewsVisibilities(string viewName) {}
		private Camera AddDefaultCameraSettingsForView(string viewName) => default;
		private GameObject AddDefaultParentSettingsForView(string viewName) => default;
		private void MoveObjectsToViewWithCorrectSetUp(GameObject[] objectsInScene, string viewName, Camera mainCamera, GameObject sceneObjectsContainer) {}
		private void CopyCameraValues(string viewName, Camera sceneCamera) {}
		private bool IsOtherSceneToLoadValid(string sceneName) => default;
	}
