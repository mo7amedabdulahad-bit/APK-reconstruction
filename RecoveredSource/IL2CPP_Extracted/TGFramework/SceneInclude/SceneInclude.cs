// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.SceneInclude
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SceneInclude : MonoBehaviour
	{
		// Fields
		[Help("Used to include a different scene at this point in the hierarchy. The scene will be loaded asynchroniously. Remember that it as to have exactly one Gameobject with SceneIncludeAnchor component. Otherwise it will just copy over the root object.")]
		public Behaviour includeBehaviour;
		public SceneField linkedScene;
		public static int loadingAmount;
		private int includeState;
		private static Dictionary<string, SceneInLoading> currentlyLoadingScenes;
		private static bool debug;
		private static bool loadAsync;
	
		// Events
		public static event Action<GameObject> OnSceneIncluded;
	
		// Nested types
		private class SceneInLoading
		{
			// Fields
			public Scene scene;
			public AsyncOperation async;
			public int amountOfWaiting;
	
			// Constructors
			public SceneInLoading() {}
		}
	
		public enum Behaviour
		{
			AsChild = 0,
			ReplaceAndThisLayout = 1,
			ReplaceAndIncludedLayout = 2
		}
	
		// Constructors
		public SceneInclude() {}
		static SceneInclude() {}
	
		// Methods
		private void copyLayout(Transform source, Transform dest) {}
		private void LinkGameObject(GameObject go) {}
		private void LinkScene(string name) {}
		[IteratorStateMachine(typeof(_AsyncLoadContent_d__15))]
		private IEnumerator AsyncLoadContent(string name) => default;
		public void LateUpdate() {}
		public static bool IsSceneLoading() => default;
	}
