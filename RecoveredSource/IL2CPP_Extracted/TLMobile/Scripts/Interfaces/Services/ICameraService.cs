// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ICameraService : IService
	{
		// Properties
		Camera CurrentCamera { get; }
	
		// Events
		event System.Action OnCameraTranslation;
	
		// Methods
		void SetMainCamera(Camera newMainCamera);
		void SafeSetNewOrthoSize(float newOrtho);
		void SafeTranslateCamera(Vector3 translation);
		Vector3 GetSafeCameraTranslationPosition(Vector3 targetPosition);
		Vector2 ScreenSpaceDirectionToWorldSpaceDirection(Vector2 screenSpace);
		Vector2Int GetScreenDimensions();
		void SetCanMoveAndZoom(bool canMove);
	}
