// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameHelper : MonoBehaviour, IBootable, IDisposable
	{
		// Fields
		public static GameHelper instance;
		public static double serverTimeDiff;
		public TGFramework.Config frameworkConfig;
		public CursorConfig CursorConfig;
		[NonSerialized]
		public Camera currentSceneCam;
		public Camera uiCamera;
		private static List<KeyValuePair<int, System.Action>> callbacksToRegisterOnStart;
		private static List<System.Action> callbacksForThisFrame;
		private static List<System.Action> callbacksForNextFrame;
		private static double currentTimestamp;
		private static Dictionary<KeyCode, bool> isKeyPressed;
		private static Dictionary<Scene, Camera> cachedCams;
	
		// Events
		public event System.Action OnNewFrame;
		public event System.Action OnAfterFrame;
	
		// Constructors
		public GameHelper() {}
		static GameHelper() {}
	
		// Methods
		private void Awake() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void ResetAndClear() {}
		public static void AddOnNewFrameCallback(System.Action callback, int timing = 0) {}
		public static bool IsKeyPressed(KeyCode code) => default;
		private void OnGUI() {}
		public static void PleaseCallNextFrame(System.Action callback) {}
		private void Update() {}
		public void AnalyzeCallbackStats(ref Dictionary<string, int> counter) {}
		private void LateUpdate() {}
		public static Camera GetCamForScene(Scene s) => default;
		public static Camera GetMyCamera(UnityEngine.Component comp) => default;
		public static void SetSceneCam(Scene s, Scene old) {}
		public static int GetTimestamp() => default;
		public static double GetExactTimestamp(bool forceGetNew = false) => default;
		public static UnityEngine.Canvas GetTopmostCanvas(bool onlySearchForType = false, RenderMode searchFor = RenderMode.ScreenSpaceOverlay) => default;
		private void HandleTabPress() {}
		public static Rect RectTransformToScreenSpace(RectTransform transform, UnityEngine.Canvas canvas = null) => default;
		public static Vector3[] Get2DCorners(RectTransform rectTransform) => default;
		public static Vector3[] Get2DCorners(Transform transform, UnityEngine.Canvas canvas, Vector3 useScale, bool stayInWorldSpace = false) => default;
		public static Vector3[] Get2DCorners(Bounds bounds, bool stayInWorldSpace = false) => default;
		public static bool HasBit(int number, int position) => default;
		public static int SetBit(int number, int position) => default;
		public static int UnsetBit(int number, int position) => default;
		public static bool HasBitmask(int number, int mask) => default;
		public static int SetBitmask(int number, int mask) => default;
		public static int UnsetBitmask(int number, int mask) => default;
		public static string GetAbsoluteName(UnityEngine.Component comp, int maxDepth = 4, bool overrideGetCompleteName = false) => default;
		public static string GetAbsoluteName(GameObject go, int maxDepth = 99) => default;
		public void Dispose() {}
	}
