// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.CameraManagement
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ScreenConfigurationProvider : MonoBehaviour, IScreenConfiguration
	{
		// Fields
		[SerializeField]
		private SpriteRenderer screenBorders;
		[SerializeField]
		private Transform optimalCenterPositionTransform;
		[SerializeField]
		private SpriteRenderer targetWidthCoverage;
		[SerializeField]
		private SpriteRenderer minimalCoveredWidth;
		[SerializeField]
		private SpriteRenderer minimalCoveredHeight;
		[SerializeField]
		private SpriteRenderer maximumCoveredHeight;
	
		// Properties
		public Vector2 OptimalCenterPosition { get => default; }
		public Rect ScreenBorders { get => default; }
		public float TargetScreenWidth { get => default; }
		public float MinScreenWidth { get => default; }
		public float MaximumOrthoSize { get => default; }
		public float MinimumOrthoSize { get => default; }
	
		// Constructors
		public ScreenConfigurationProvider() {}
	
		// Methods
		private void Awake() {}
		public void Init(SpriteRenderer screenBorders, Transform optimalCenterPosition, SpriteRenderer targetWidth, SpriteRenderer minimalWidth, SpriteRenderer minimumOrthoSize, SpriteRenderer maximumOrthoSize) {}
	}
