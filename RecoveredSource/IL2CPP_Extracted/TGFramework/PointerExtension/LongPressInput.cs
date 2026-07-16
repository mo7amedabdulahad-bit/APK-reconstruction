// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.PointerExtension
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LongPressInput
	{
		// Fields
		private float longPressDelay;
		private float longPressStartTime;
		private bool isTouchTooFar;
		private const int defaultDelay = 400;
		public static Action<LongPressInput> AnyLongPressStarted;
		public static Action<LongPressInput> AnyLongPressEnd;
		private FlagSet<LongPressStatus> longPressStatus;
	
		// Properties
		public bool IsLongPressActive { get; private set; }
		public bool WasSuccessful { get => default; }
		public Vector2 LongPressStartPosition { get; private set; }
		private Action<PointerEventData> longPressSuccess { get; set; }
		public float LongPressProgress { get => default; }
		public Action<bool> longPressOver { get; set; }
	
		// Nested types
		[Flags]
		public enum LongPressStatus
		{
			Started = 1,
			Success = 2,
			IsOverContext = 4
		}
	
		// Constructors
		public LongPressInput() {}
	
		// Methods
		public void Setup(Action<PointerEventData> longPressSuccessCallback, int longPressDelayMs = -1, Action<bool> longPressOverCallback = null) {}
		public void StartLongPress(BaseEventData eventData, MonoBehaviour managingComponent) {}
		[IteratorStateMachine(typeof(_StartLongPress_Co_d__30))]
		public IEnumerator StartLongPress_Co(PointerEventData eventData) => default;
		[IteratorStateMachine(typeof(_LongPressRoutine_Co_d__31))]
		private IEnumerator LongPressRoutine_Co(PointerEventData eventData) => default;
		private void ConcludeLongPress() {}
		public void LeaveContext(PointerEventData eventData = null) {}
		private void UpdateCurrentTouch() {}
	}
