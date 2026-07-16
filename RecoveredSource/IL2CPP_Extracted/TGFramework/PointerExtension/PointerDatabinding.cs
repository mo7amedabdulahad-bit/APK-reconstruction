// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.PointerExtension
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PointerDatabinding : Databinding, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		// Fields
		public static string[] bindingTargetNames;
		public static Action<GameObject> globalClickCallback;
		public static Action<GameObject> globalEnterCallback;
		public static Action<GameObject> globalExitCallback;
		public static PointerEventData lastPointerEventData;
		public BindingTarget targetType;
		public bool isDisabled;
		public bool changeCursor;
		public float delayMilliseconds;
		public bool useAllMouseButtons;
		public bool allowClickThrough;
		public bool reallyWantsUpdate;
		public int delayLongPressMs;
		public PointerEventData.InputButton inputButton;
		private bool isPointerOver;
		private Dictionary<BindingTarget, List<Action<PointerEventData>>> callbacks;
		private InternalPointerEventParent trigger;
		private bool addedTriggerCallback;
		private bool addedButtonClickListener;
		private bool addedMouseOverCursor;
		private static int stackedClickables;
		private static List<UnityEngine.Component> stackedClickableComponents;
		private bool isHovered;
		private bool callbackAddedViaScript;
		private LongPressInput longPress;
	
		// Properties
		protected override bool isMethodCaller { get => default; }
		public bool disabled { get => default; set {} }
	
		// Nested types
		public enum BindingTarget
		{
			a = 0,
			b = 1,
			c = 2,
			d = 3,
			e = 4,
			f = 5,
			g = 6,
			PointerDown = 7,
			PointerUp = 8,
			PointerClick = 9,
			PointerEnter = 10,
			PointerExit = 11,
			LongPress = 12,
			InternalLongPress = 13
		}
	
		// Constructors
		public PointerDatabinding() {}
		static PointerDatabinding() {}
	
		// Methods
		public override void Reset() {}
		public void AddClickCallback(Action<PointerEventData> callback, BindingTarget type = BindingTarget.PointerClick) {}
		public void InsertClickCallback(Action<PointerEventData> callback, int index = 0) {}
		public void AddButtonClickCallback(UnityAction callback) {}
		public void RemoveButtonClickCallback(UnityAction callback) {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		private void CallMethod(BaseEventData eventData) {}
		private void CallAfterLongPressSuccess(BaseEventData eventData) {}
		[IteratorStateMachine(typeof(_CallMethodWithDelay_d__39))]
		private IEnumerator CallMethodWithDelay(BaseEventData eventData, float delay) => default;
		private void CallMethodWithoutDelay(BaseEventData eventData) {}
		private void OnClickableExit(bool checkForDisabled = true) {}
		protected void SearchTargetComponent() {}
		private void InitializeForTargetType() {}
		protected override bool BindingSuccessful() => default;
		public override void Start() {}
		public void CallCallbacks(BindingTarget type, PointerEventData data) {}
		public void AddCallback(BindingTarget type, Action<PointerEventData> callback) {}
		public void InsertCallback(BindingTarget type, Action<PointerEventData> callback, int index = 0) {}
		public void RemoveCallback(BindingTarget type, Action<PointerEventData> callback) {}
		public void RemoveAllCallbacks(BindingTarget type) {}
		protected void OnDisable() {}
		public void OnPointerEnter(PointerEventData eventData) {}
		public void OnPointerExit(PointerEventData eventData) {}
		public void OnPointerDown(PointerEventData eventData) {}
		public void OnPointerUp(PointerEventData eventData) {}
		public void OnPointerClick(PointerEventData eventData) {}
	}
