// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SwipeablePanel : ViewModel
	{
		// Fields
		public const float SidePanelHorizontalArea = 0.15f;
		private const float SidePanelCloseHorizontalArea = 0.5f;
		[ObservableValue]
		private float _currentValue;
		[ObservableValue]
		[SerializeField]
		private MainUIStateController.VisibleSidePanel _sidePanel;
		[ObservableValue]
		[SerializeField]
		private bool _isExpanded;
		[ObservableValue]
		private bool _shouldBeActive;
		[SerializeField]
		private GameObject[] swipeableElements;
		[Help("The target value of the databinding when this panel is opened.")]
		[SerializeField]
		private float expandedPositionValue;
		[Help("The target value of the databinding when this panel is closed.")]
		[SerializeField]
		private float contractedPositionValue;
		[Help("If the values before are percentages, but in the end the panel will move a fixed amount of pixels, you have to define the pixels here")]
		[SerializeField]
		private float valueMultiplicator;
		[Help("Vector needed to open this panel. A swipe to the right would be (1, 0)")]
		public Vector2 directionToOpen;
		[Help("Only start swipe if it has been more than X milliseconds since start")]
		public float timeUntilSwipeStart;
		[Help("If we move more than X% in the correct, start the swipe")]
		public float allowedSwipeAreaInPercent;
		public Action<bool> PanelExpandedStatusChanged;
		public Action<SwipeStatus> SwipeStatusChanged;
		private SwipeStatus swipeStatus;
		private float downPosition;
		private UnityEngine.Canvas myParentCanvas;
	
		// Properties
		[ObservableValue]
		public float currentValue { get => default; set {} }
		[ObservableValue]
		public MainUIStateController.VisibleSidePanel sidePanel { get => default; set {} }
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public bool shouldBeActive { get => default; set {} }
		public SwipeStatus GetSwipeStatus { get; private set; }
		public float ValueMultiplicator { get => default; }
		public float ExpandedPositionValue { get => default; }
		public float ContractedPositionValue { get => default; }
		public GameObject[] SwipeableElements { get => default; }
	
		// Nested types
		public enum SwipeStatus
		{
			None = 0,
			PreSwipe = 1,
			Swiping = 2
		}
	
		// Constructors
		public SwipeablePanel() {}
	
		// Methods
		protected override void Awake() {}
		private void LateUpdate() {}
		protected void OnEnable() {}
		protected void OnDisable() {}
		public void Init(bool isExpanded, float contractedPositionValue, float expandedPositionValue, GameObject[] swipeableElements, float valueMultiplicator) {}
		public void CheckMouseDown(MouseInfo.MouseButton btn, bool newDown) {}
		private void StartSwiping(PointerEventData data) {}
		public void CheckSwipeStatus() {}
		public void UpdateCurrentValue(float diff, bool mouseStillDown) {}
		[UICallable]
		public void SetExpandedStatus(bool newStatus) {}
		[UICallable]
		public void ToggleExpanded() {}
		[UICallable]
		public void SetShouldBeActiveTrue(bool value) {}
		private void UpdateSwipeStatus(SwipeStatus swipeStatus) {}
		private void AdjustToStatus() {}
	}
