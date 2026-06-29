// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapPositionService : MonoBehaviour, IMapPositionService
	{
		// Fields
		private Tween cameraMovementTween;
	
		// Properties
		public Vector2Int CurrentOpeningPosition { get; private set; }
	
		// Constructors
		public MapPositionService() {}
	
		// Methods
		public IPromise Init(object[] args = null) => default;
		public IPromise BootInstance(object[] args = null) => default;
		private void OnDisable() {}
		public void GoToCell(int x, int y) {}
		public void MoveCamera(float xMovement, float yMovement) {}
		public void SetOpeningMapPosition(int x, int y) {}
		public void GoToCurrentPosition() {}
		public float GetDistance(Vector2Int source, Vector2Int destination, BootstrapData bootstrap) => default;
		public Vector2Int GetMouseCellPosition(Vector2 currentMousePosition, Vector2 offset = default) => default;
		public Vector2Int GetCenterOfTheScreenCellPosition() => default;
		private void CurrentVillageChanged(OwnVillage village) {}
		private void MoveCameraToPosition(Vector2 cellPosition) {}
		private static Vector2 GetScreenCenter() => default;
	}
