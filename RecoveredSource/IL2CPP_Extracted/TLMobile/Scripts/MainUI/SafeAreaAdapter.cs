// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SafeAreaAdapter : MonoBehaviour
	{
		// Fields
		public static Vector2 AnchorMin;
		public static Vector2 AnchorMax;
		[SerializeField]
		private UnityEngine.Canvas canvas;
		[SerializeField]
		private bool addSideSafeArea;
		public CanvasScaler scalerToAdjust;
		public float maxAspectRatio;
		private Rect currentSafeArea;
		private Vector2 oldScreenDimension;
	
		// Properties
		public RectTransform SafeAreaTransform { get; private set; }
		public UnityEngine.Canvas Canvas { get; private set; }
	
		// Constructors
		public SafeAreaAdapter() {}
		static SafeAreaAdapter() {}
	
		// Methods
		private void Start() {}
		private void Init() {}
		private void FrameUpdate() {}
		private void ApplySafeArea(Rect safeArea) {}
	}
