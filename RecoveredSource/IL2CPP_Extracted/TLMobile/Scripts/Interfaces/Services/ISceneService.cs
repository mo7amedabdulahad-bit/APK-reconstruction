// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ISceneService : IService
	{
		// Properties
		string MainSceneName { get; }
		SceneStatus CurrentSceneStatus { get; }
		IReadOnlyDictionary<string, GameObject> LoadedViewParentObjects { get; }
	
		// Events
		event Action<SceneStatus> ViewChanged;
		event System.Action LoggedOut;
		event System.Action LoadMainSceneStarted;
	
		// Methods
		void LoadMainScene(System.Action sceneLoadedCallback = null);
		void LoadLoginScene();
		bool LoadOtherScene(string sceneName);
		GameObject MoveGameObjectsToMainScene(GameObject[] objectsInScene, string parentName);
		void SwitchToSitter(System.Action sceneLoadedCallback = null);
		void PrepareLoginScene();
		bool SwitchToVillageView();
		bool SwitchToResourcesView();
		bool SwitchToMapView(int xPos, int yPos, bool targetSelection = false);
		bool SwitchToOtherView(string viewName, bool targetSelection = false);
		void ExitToLogin();
		IScreenConfiguration GetCurrentScreenConfiguration();
		void SetCurrentScreenConfiguration(IScreenConfiguration screenConfiguration);
	}
