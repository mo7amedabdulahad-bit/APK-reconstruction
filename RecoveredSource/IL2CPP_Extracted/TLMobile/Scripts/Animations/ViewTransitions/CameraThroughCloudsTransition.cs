// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.ViewTransitions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CameraThroughCloudsTransition : ViewTransition
	{
		// Fields
		private const float CameraTransitionDuration = 0.9f;
		private readonly ICloudsController cloudsController;
		private readonly float orthoAfterChangeEnd;
		private readonly float orthoAfterChangeStart;
		private readonly float orthoBeforeChangeEnd;
		private readonly float orthoBeforeChangeStart;
	
		// Nested types
		public enum Direction
		{
			ZoomIn = 0,
			ZoomOut = 1
		}
	
		// Constructors
		public CameraThroughCloudsTransition() {} // Dummy constructor
		public CameraThroughCloudsTransition(float orthoStart, float orthoEnd, Direction direction) {}
	
		// Methods
		public override void BeginTransition(bool scaled = false) {}
		private void SkipAnimation() {}
		private void SecondPart() {}
		private TweenerCore<float, float, FloatOptions> GetCameraZoomTweenerObject(float transitionTime, float orthoStart, float orthoEnd) => default;
	}
