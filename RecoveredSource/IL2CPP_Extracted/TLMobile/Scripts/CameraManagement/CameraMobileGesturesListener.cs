// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.CameraManagement
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CameraMobileGesturesListener : MonoBehaviour
	{
		// Fields
		private const float ZoomSpeed = 1f;
		private const float BaseInertiaTime = 5f;
		private const float SpeedThresholdForInertia = 5f;
		[SerializeField]
		private TouchHighlight highlightPrefab;
		[SerializeField]
		private UnityEngine.Canvas canvasParent;
		[SerializeField]
		private float inertia;
		[SerializeField]
		private float maxSpeed;
		[SerializeField]
		private float easingToMax;
		[SerializeField]
		private float easingToZero;
		private TouchHighlight currentlyPlayingTabHighlight;
		private FingersScript fingersScript;
		private ScaleGestureRecognizer scaleGesture;
		private PanGestureRecognizer panGesture;
		private TapGestureRecognizer tapGesture;
		private EventSystem disabledEventSystem;
		private Coroutine inertiaCoroutine;
	
		// Properties
		public float Inertia { get => default; set {} }
		public float MaxSpeed { get => default; set {} }
		public float EasingToMax { get => default; set {} }
		public float EasingToZero { get => default; set {} }
	
		// Constructors
		public CameraMobileGesturesListener() {}
	
		// Methods
		private void Start() {}
		private void Update() {}
		public void Init(FingersScript fingersScript) {}
		private void OnDestroy() {}
		private void Tap(GestureRecognizer gesture) {}
		private void Zoom(GestureRecognizer gesture) {}
		private void Move(GestureRecognizer gesture) {}
		private void SuspendEventSystemDuringThisGesture(GestureRecognizer _) {}
		private void SuspendEventSystemIfPresent() {}
		private void ResumeSuspendedEventSystem() {}
		[IteratorStateMachine(typeof(_MoveWithAcceleration_d__38))]
		private static IEnumerator MoveWithAcceleration(float speed, float acceleration, float time, Vector2 direction, ICameraService cameraService) => default;
		[IteratorStateMachine(typeof(_InertiaOnCamera_d__39))]
		private IEnumerator InertiaOnCamera(Vector2 velocity) => default;
	}
