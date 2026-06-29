// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WindowsService : MonoBehaviour, IWindowsService
	{
		// Fields
		private static readonly HashSet<System.Type> GenericBaseTypes;
		private DetailWindowToPrefab prefabConfig;
		protected WindowNavigationController windowNavigationController;
	
		// Properties
		public Dictionary<DetailWindows, DetailWindowController> AvailableWindows { get; }
		public Dictionary<DetailWindows, DetailWindowController> InstantiatedWindows { get; }
	
		// Events
		public event Action<DetailWindows?> OnWindowsChanged;
	
		// Constructors
		public WindowsService() {}
		static WindowsService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public bool SetAvailableWindowsPrefabs(Dictionary<DetailWindows, DetailWindowController> prefabs, bool checkWindowsPrefabExistance = false) => default;
		public DetailWindows GetDetailWindowType(System.Type windowType, string prefabName = null) => default;
		public DetailWindowController ShowWindow(DetailWindows windowToOpen, bool deactivateLastWindow = true, GameObject parentObject = null) => default;
		public bool HideWindow(DetailWindows windowToHide) => default;
		public bool HideAllOpenWindows(bool callHideMethods = true) => default;
		public void DestroyWindow(DetailWindows windowToDestroy) {}
		public int GetOpenWindowAmount(bool ignorePopups = false) => default;
		public DetailWindowController GetHighestWindow() => default;
		public T GetWindow<T>(DetailWindows window)
			where T : DetailWindowController => default;
		public T GetOpenWindow<T>(DetailWindows window)
			where T : DetailWindowController => default;
		private void CheckForWindowsPrefabsExistence() {}
		private DetailWindows FindByPrefabName(string prefabName) => default;
		private DetailWindowController GetWindowInstance(DetailWindows window) => default;
		private void OnLoadMainSceneStarted() {}
	}
