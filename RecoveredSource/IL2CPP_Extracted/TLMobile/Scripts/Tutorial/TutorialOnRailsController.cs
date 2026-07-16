// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Tutorial
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TutorialOnRailsController : TLMViewModel
	{
		// Fields
		public const string TutorialOnRailsCompletionFlagPrefsKey = "TutorialOnRailsCompleted";
		private const int AfterBackgroundImagesIndex = 1;
		private const float TimeToLetPopupsExpand = 0.3f;
		public RectTransform TutorialParent;
		public RectTransform TutorialClickCatcher;
		public RectTransform BottomMenu;
		public RectTransform SettingsButton;
		public RectTransform TopResourcesBar;
		public RectTransform RightSideNavigationButtons;
		public RectTransform BuildingActivitiesButton;
		public RectTransform RallyPointShortcutButton;
		public RectTransform RightSidePanel;
		public RectTransform RightSidePanelHandle;
		public UnityEngine.UI.Image TextBackground;
		public RectTransform DarkBackground;
		public SwipeablePanel TopMenuController;
		public GameObject FingerPrefab;
		public GameObject FingerWithoutCirclePrefab;
		public GameObject FingerSwipePrefab;
		public RectTransform TutorialText;
		public RectTransform TutorialTextPositions;
		[ObservableValue]
		private TutorialSteps _currentStepEnum;
		[ObservableValue]
		private int _currentStepNumber;
		[ObservableValue]
		private int _totalSteps;
		[ObservableValue]
		private bool _showText;
		[ObservableValue]
		private bool _catchClicks;
		private GameObject fingerInstance;
		private int lastIndex;
		private RectTransform lastMoved;
		private Transform lastParent;
		private SwipeablePanel rightSideSwipeablePanel;
		private Dictionary<int, RectTransform> textPositions;
	
		// Properties
		[ObservableValue]
		public TutorialSteps currentStepEnum { get => default; set {} }
		[ObservableValue]
		public int currentStepNumber { get => default; set {} }
		[ObservableValue]
		public int totalSteps { get => default; set {} }
		[ObservableValue]
		public bool showText { get => default; set {} }
		[ObservableValue]
		public bool catchClicks { get => default; set {} }
	
		// Nested types
		public enum TutorialSteps
		{
			Start = 0,
			BottomNavigation = 1,
			MainMenu = 2,
			ResourceBarFold = 3,
			ResourceBarUnfold = 4,
			RightSideNavigation = 5,
			BuildingActivity = 6,
			RallyPoint = 7,
			SideMenus = 8,
			VillagesList = 9
		}
	
		// Constructors
		public TutorialOnRailsController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private void StartTutorial(bool visibile) {}
		[UICallable]
		public void InterceptClick() {}
		[UICallable]
		public void BeginTutorial() {}
		[UICallable]
		public void OpenMainMenu() {}
		[UICallable]
		public void CloseMainMenu() {}
		[UICallable]
		public void OpenResourceBar() {}
		[UICallable]
		public void CloseResourceBar() {}
		[UICallable]
		public void OpenBuildingActivity() {}
		[UICallable]
		public void CloseBuildingActivity() {}
		[UICallable]
		public void CloseRallyPointIntroduction() {}
		private void OnPanelOpened(bool obj) {}
		[UICallable]
		public void OpenSideMenu() {}
		[UICallable]
		public void SkipTutorial() {}
		[UICallable]
		public void FinishTutorial() {}
		private void BringToFront(RectTransform transform) {}
		private void BringLastMovedBack() {}
		private void SetTutorialStep(TutorialSteps step) {}
		private void RemoveTouchTarget() {}
		private void SetTouchTarget(RectTransform targetRectTransform, bool showUnder, bool showSwipe = false, bool hideCircle = false) {}
		private static Rect GetCoveringRect(RectTransform targetRectTransform, Transform parent) => default;
		private void OnGameworldOpenedAndReady() {}
	}
