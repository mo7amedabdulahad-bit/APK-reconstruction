// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CameraService : MonoBehaviour, ICameraService
	{
		// Fields
		public float maxAspectRatio;
		private bool canMoveAndZoom;
	
		// Properties
		public Camera CurrentCamera { get; private set; }
	
		// Events
		public event System.Action OnCameraTranslation;
	
		// Constructors
		public CameraService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void SetMainCamera(Camera newMainCamera) {}
		public void SafeSetNewOrthoSize(float newOrtho) {}
		public void SafeTranslateCamera(Vector3 translation) {}
		public Vector3 GetSafeCameraTranslationPosition(Vector3 targetPosition) => default;
		public void SetCanMoveAndZoom(bool canMove) {}
		public Vector2 ScreenSpaceDirectionToWorldSpaceDirection(Vector2 screenSpace) => default;
		public Vector2Int GetScreenDimensions() => default;
		public void Init(Camera mainCamera) {}
		private bool CanMoveAndZoom() => default;
		private static Vector3 GetClosestAcceptableCenter(Vector3 center, float halfWidth, float halfHeight, Rect borders) => default;
	}
