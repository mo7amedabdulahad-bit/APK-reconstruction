// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MainUIStateController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private MainUIView _mainUIView;
		[ObservableValue]
		private MainUIView _previousMainUIView;
		[ObservableValue]
		private VisibleSidePanel _currentVisibleSidePanel;
		[ObservableValue]
		private int _keyboardHeight;
		[ObservableValue]
		private bool _networkIssuesDetected;
		[ObservableValue]
		private int _openWindows;
		[ObservableValue]
		private bool _openWindowFullyOverlaysUi;
		[ObservableValue]
		private bool _swipeableSidePanelsAreDisabled;
		[ObservableValue]
		private float _networkIssuesFadeValue;
		[ObservableValue]
		private bool _showResourceProductionButton;
		private IDeviceFunctionsService deviceFunctionsService;
		[SerializeField]
		private float fadeSpeed;
		[SerializeField]
		private float minFadeValue;
		[SerializeField]
		private float maxFadeValue;
		private UnityEngine.Canvas rootCanvas;
		[SerializeField]
		private DetailWindowsShowController showController;
		public Action<bool> OnOpenWindowFullyOverlaysUiChanged;
		private OwnPlayer ownPlayer;
		private SceneStatus currentSceneStatus;
		private bool hasRelevantBoostForResourceProductionButton;
	
		// Properties
		[ObservableValue]
		public MainUIView mainUIView { get => default; set {} }
		[ObservableValue]
		public MainUIView previousMainUIView { get => default; set {} }
		[ObservableValue]
		public VisibleSidePanel currentVisibleSidePanel { get => default; set {} }
		[ObservableValue]
		public int keyboardHeight { get => default; set {} }
		[ObservableValue]
		public bool networkIssuesDetected { get => default; set {} }
		[ObservableValue]
		public int openWindows { get => default; set {} }
		[ObservableValue]
		public bool openWindowFullyOverlaysUi { get => default; set {} }
		[ObservableValue]
		public bool swipeableSidePanelsAreDisabled { get => default; set {} }
		[ObservableValue]
		public float networkIssuesFadeValue { get => default; set {} }
		[ObservableValue]
		public bool showResourceProductionButton { get => default; set {} }
	
		// Nested types
		[Flags]
		public enum VisibleSidePanel
		{
			None = 0,
			Right = 1,
			Left = 2
		}
	
		// Constructors
		public MainUIStateController() {}
	
		// Methods
		protected override void Awake() {}
		private void Start() {}
		protected virtual void Update() {}
		public virtual void Init() {}
		protected override void OnDestroy() {}
		private void InitLoading() {}
		private void UpdateWindowAmount(DetailWindows? detailWindowId) {}
		public virtual void SetVisibleSidePanel(VisibleSidePanel sidePanel) {}
		[UICallable]
		public virtual void SwitchToVillageView() {}
		[UICallable]
		public virtual void SwitchToResourcesView() {}
		[UICallable]
		public virtual void SwitchToMapView() {}
		private void OnMapViewLoaded(SceneStatus status) {}
		[UICallable]
		public void SwitchToMainView() {}
		private void SetView(SceneStatus status) {}
		private void SetView(MainUIView view) {}
		private void OnLoadingEvent(bool visible) {}
		private void UpdateResourceProductionButtonVisibilityForScene(SceneStatus status) {}
		private void OnProductionBoostUpdated() {}
		private static bool HasRelevantActiveBoost(ProductionBoost productionBoost) => default;
		private void RecalculateResourceProductionButtonVisibility() {}
	}
