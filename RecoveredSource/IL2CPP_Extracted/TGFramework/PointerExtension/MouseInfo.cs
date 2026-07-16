// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.PointerExtension
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MouseInfo : ObservableModel
	{
		// Fields
		private static bool debugMouse;
		[ObservableValue]
		private Vector2 _mousePosition;
		[ObservableValue]
		private bool _mouseHasHit;
		[ObservableValue]
		private GameObject _isOverUi;
		[ObservableValue]
		private GameObject _startedOverUi;
		[ObservableValue]
		private TGFramework.PointerExtension.HitInfo _mouseHit;
		[ObservableValue]
		private GameObject _mouseOver;
		[ObservableValue]
		private GameObject _mouseOverOriginal;
		[ObservableValue]
		private GameObject _oldMouseOver;
		[ObservableValue]
		private bool _wasTouchInput;
		[ObservableValue]
		private bool _mouseOverChanged;
		[ObservableValue]
		private bool _mouseClicked;
		[ObservableValue]
		private bool _mouseClickedRight;
		[ObservableValue]
		private bool _mouseDown;
		[ObservableValue]
		private bool _mouseDownRight;
		[ObservableValue]
		private bool _mouseDragging;
		[ObservableValue]
		private double _mouseDownStartTime;
		[ObservableValue]
		private double _mouseDownStartTimeRight;
		[ObservableValue]
		private Vector2 _mouseDownPos;
		[ObservableValue]
		private Vector2 _mouseDownPosRight;
		public bool ignoreNextClick;
		public int ignoreLayerMask;
		private static readonly int[] raycast3DWhenUILayers;
		private static int raycast3DWhenUILayerMask;
		public static MouseInfo instance;
		public List<GameObject> overUIElements;
		private int oldTouchCount;
		public float movedDistance;
		private Vector2 oldMousePos;
		private int lastUiCheckFrame;
		public static CursorMode cursorMode;
		private Texture2D currentCursor;
		private CursorConfig _cursorConfig;
		private List<RaycastResult> pointerRaycastResults;
	
		// Properties
		public CursorConfig cursorConfig { get => default; }
		public Texture2D CurrentCursor { get => default; }
		[ObservableValue]
		public Vector2 mousePosition { get => default; set {} }
		[ObservableValue]
		public bool mouseHasHit { get => default; set {} }
		[ObservableValue]
		public GameObject isOverUi { get => default; set {} }
		[ObservableValue]
		public GameObject startedOverUi { get => default; set {} }
		[ObservableValue]
		public TGFramework.PointerExtension.HitInfo mouseHit { get => default; set {} }
		[ObservableValue]
		public GameObject mouseOver { get => default; set {} }
		[ObservableValue]
		public GameObject mouseOverOriginal { get => default; set {} }
		[ObservableValue]
		public GameObject oldMouseOver { get => default; set {} }
		[ObservableValue]
		public bool wasTouchInput { get => default; set {} }
		[ObservableValue]
		public bool mouseOverChanged { get => default; set {} }
		[ObservableValue]
		public bool mouseClicked { get => default; set {} }
		[ObservableValue]
		public bool mouseClickedRight { get => default; set {} }
		[ObservableValue]
		public bool mouseDown { get => default; set {} }
		[ObservableValue]
		public bool mouseDownRight { get => default; set {} }
		[ObservableValue]
		public bool mouseDragging { get => default; set {} }
		[ObservableValue]
		public double mouseDownStartTime { get => default; set {} }
		[ObservableValue]
		public double mouseDownStartTimeRight { get => default; set {} }
		[ObservableValue]
		public Vector2 mouseDownPos { get => default; set {} }
		[ObservableValue]
		public Vector2 mouseDownPosRight { get => default; set {} }
	
		// Events
		public event Action<Direction> OnSwipe;
		public static event Action<MouseButton, bool> OnMouseDownStatusChanged;
		public static event Action<GameObject> OnElementClicked;
	
		// Nested types
		public enum Direction
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3
		}
	
		public enum MouseButton
		{
			Left = 0,
			Right = 1,
			Middle = 2,
			Touch = 3
		}
	
		// Constructors
		static MouseInfo() {}
		public MouseInfo() {}
	
		// Methods
		public void SetCursor(Texture2D texture) {}
		public void SetCursor(Texture2D texture, Vector2 hotspot) {}
		public bool CursorIsDragging() => default;
		public bool CursorIsPointer() => default;
		public bool CursorIsDraggable() => default;
		public bool IsUsingCustomCursor() => default;
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init() {}
		public void FireSwipe(Direction dir) {}
		public void ConsumeClick() {}
		public void UpdateMousePosition() {}
		public GameObject IsPointerOverUIObject(bool force = false) => default;
		private bool UILayerAllows3DRaycast(GameObject hitUIElement) => default;
		private void DoHitTest() {}
		public void Update() {}
		public bool IsEligibleForClick() => default;
		public static bool MouseIsOver(GameObject toCheck, bool useUIOver = false) => default;
		public static bool IsWithinSelectionBounds(GameObject gameObject, float clickMargin = 0f) => default;
		private static Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2) => default;
	}
