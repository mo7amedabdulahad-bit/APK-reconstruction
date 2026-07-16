// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RotatingAnimator : MonoBehaviour
	{
		// Fields
		public RectTransform loadingWheel;
		[SerializeField]
		private bool autoStartOnEnable;
		[SerializeField]
		private float animationDuration;
		[SerializeField]
		private float animationRotationGoal;
		[SerializeField]
		private Vector2 animationCurveStartControlPoints;
		[SerializeField]
		private Vector2 animationCurveEndControlPoints;
		private Tween animationTween;
	
		// Properties
		public bool PlayAnimation { get => default; set {} }
	
		// Constructors
		public RotatingAnimator() {}
	
		// Methods
		public void SetupAnimation() {}
		private float InvertedInInvertedOutCirc(float time, float duration, float overshootOrAmplitude, float period) => default;
		private void OnEnable() {}
		private void OnDisable() {}
		private void OnDestroy() {}
	}
