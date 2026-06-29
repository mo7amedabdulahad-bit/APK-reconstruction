// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Tooltip : TGFramework.Translate, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler, IPointerUpHandler
	{
		// Fields
		public MobileInputMode mobileInputMode;
		public float delayMilliseconds;
		public GameObject template;
		private GameObject reallyUseTemplate;
		[Tooltip("This prefix will ONLY be used, if the translationKey is used. In this case the two of them will be concatenated.")]
		private string _fixedTooltipContent;
		public TTPosition positioning;
		public Vector2 offset;
		public Vector3 offset3d;
		public Hierarchy hierarchyChange;
		public GameObject makeChildOfThisParent;
		[ObservableValue]
		private string _tooltipParameter;
		[Tooltip("Use this string parameter if you use a template with TooltipContent component and that should get some information.")]
		public string tooltipContentParameter;
		private GameObject ttObject;
		private RectTransform ownRectTransform;
		private Transform ownTransform;
		private RectTransform ttRectTransform;
		private static UnityEngine.Canvas parentCanvas;
		private static UnityEngine.Canvas parentOverlayCanvas;
		private bool currentlyDragged;
		private bool usesDefaultTemplate;
		private LongPressInput longPress;
		public bool closeOnHoverOverTooltip;
		public static bool forceStayOpen;
		public bool forceStayOpenSingle;
		public bool toggleOnMobile;
		public bool resetAnchorsAndScale;
		public bool showInWorldSpace;
		public bool destroyOnClose;
		public bool useSharedTooltipInstance;
		public TGFramework.Translate takeValuesFromTranslate;
		[ObservableValue]
		private bool _disabled;
		public bool ForceNoRendererRect;
		private int alreadyFlippedAmount;
		private bool ignoreNextHover;
		private PointerEventData lastEventData;
		private float currentZposition;
		private Vector4 lastClampedDirections;
		private static bool doDebugMarking;
		private static GameObject debugMarkerObject;
		private static Tooltip alreadyOpenMobileTooltip;
		private static int dontShowUntilFrame;
		private static Dictionary<int, GameObject> sharedTooltipInstances;
		public static Tooltip lastTooltip;
		private static Dictionary<GameObject, Tooltip> cachedTooltips;
		private bool isHovered;
		private bool isIn3dSpace;
		private UnityEngine.Canvas usedTooltipCanvas;
		private RectTransformHelper originalRectTransform;
		private UnityEngine.Canvas canvasForMyElement;
		private int mayCloseOnlyAfterFrame;
		private bool positionDirty;
	
		// Properties
		public GameObject templateToSet { set {} }
		public string fixedTooltipContent { set {} }
		public GameObject TooltipInstance { get => default; }
		public Func<Rect> GetScreenSpaceRectToOrientate { get; set; }
		public bool IsActive { get => default; }
		[ObservableValue]
		public string tooltipParameter { get => default; set {} }
		[ObservableValue]
		public bool disabled { get => default; set {} }
	
		// Events
		public event System.Action TooltipActivated;
		public event System.Action TooltipDeactivated;
		private static event System.Action CameraChangedCallbacks;
	
		// Nested types
		public enum MobileInputMode
		{
			Touch = 0,
			LongPress = 1
		}
	
		public enum TTPosition
		{
			Bottom = 0,
			Top = 1,
			Left = 2,
			Right = 3,
			NoChange = 4,
			MouseRight = 5,
			MouseTop = 6,
			MouseLeft = 7
		}
	
		public enum Hierarchy
		{
			NoChange = 0,
			MakeChild = 1,
			MoveToGlobal = 2
		}
	
		// Constructors
		public Tooltip() {}
		static Tooltip() {}
	
		// Methods
		public override void Start() {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		public void OnPointerDown(PointerEventData eventData) {}
		public void OnPointerUp(PointerEventData eventData) {}
		public void OnPointerEnter(PointerEventData eventData) {}
		public void OnSelect(BaseEventData eventData) {}
		public void OnPointerExit(PointerEventData eventData) {}
		public void OnDeselect(BaseEventData eventData) {}
		private new void OnDisable() {}
		public override bool BindingSuccessfulInEditor() => default;
		private bool ShouldHandleLongPress() => default;
		private void SetRelativePosition(TTPosition positioning, Rect rect) {}
		private void UpdateMobileTooltip(MouseInfo.MouseButton button, bool status) {}
		public void StartHover(PointerEventData eventData = null) {}
		private bool CheckMobileToggle() => default;
		[IteratorStateMachine(typeof(_DelayTooltip_d__89))]
		private IEnumerator DelayTooltip() => default;
		public void ShowTooltip() {}
		private void LayoutSmart() {}
		private void LateUpdate() {}
		private void CheckDebugMarker() {}
		private void ReparentTooltip() {}
		public void HideTooltip(bool forceClose = false) {}
		private GameObject GetSharedTooltipInstance() => default;
		public void AdjustFacingIn3d() {}
		private void SetCorrectPosition(bool copyOrigTransform = true) {}
		private Rect GetCurrentRectCorners(RectTransform transformToUse = null) => default;
		private void EnsureIsOnScreen() {}
		public override void OnDestroy() {}
		public void StartDrag() {}
		public void StopDrag() {}
		public void CloseTooltip() {}
	}
