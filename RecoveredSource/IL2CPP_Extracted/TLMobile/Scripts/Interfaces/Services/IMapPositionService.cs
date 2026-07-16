// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IMapPositionService : IService
	{
		// Properties
		Vector2Int CurrentOpeningPosition { get; }
	
		// Methods
		void GoToCell(int x, int y);
		void MoveCamera(float xMovement, float yMovement);
		void SetOpeningMapPosition(int x, int y);
		void GoToCurrentPosition();
		float GetDistance(Vector2Int source, Vector2Int destination, BootstrapData bootstrap);
		Vector2Int GetMouseCellPosition(Vector2 currentMousePosition, Vector2 offset = default);
		Vector2Int GetCenterOfTheScreenCellPosition();
	}
