// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LazyRenderingParent : MonoBehaviour
	{
		// Fields
		public Camera useTransformCam;
		private readonly HashSet<LazyRenderingObject> children;
		private readonly HashSet<LazyRenderingObject> childrenToAdd;
		private readonly HashSet<LazyRenderingObject> childrenToRemove;
		private UnityEngine.Canvas canvas;
		private bool duringUpdate;
		public System.Action firstElementVisibleCallback;
		private Vector3 lastCanvasScale;
		public System.Action lastElementVisibleCallback;
		private bool requestedNextFrameCheck;
		private ScrollRect scrollRect;
	
		// Constructors
		public LazyRenderingParent() {}
	
		// Methods
		public void OnEnable() {}
		public void OnDisable() {}
		public void Register(LazyRenderingObject toRegister) {}
		public void Unregister(LazyRenderingObject toUnregister) {}
		private void ManageRepeatCallbacks(bool addListener = true) {}
		private void CheckAfterOneFrame() {}
		private void CheckVisibility(Vector2 notNeededValue) {}
		private void CheckVisibility() {}
		private void UpdateScrollRectChildren(Camera camera, Rect scrollRectScreenRect) {}
		private RectIntersectionInfo CountCornersVisibleFrom(RectTransform rectTransform, Camera camera, Rect screenBounds) => default;
	}
