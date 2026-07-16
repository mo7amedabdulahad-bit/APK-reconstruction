// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IWindowsService : IService
	{
		// Properties
		Dictionary<DetailWindows, DetailWindowController> AvailableWindows { get; }
		Dictionary<DetailWindows, DetailWindowController> InstantiatedWindows { get; }
	
		// Events
		event Action<DetailWindows?> OnWindowsChanged;
	
		// Methods
		bool SetAvailableWindowsPrefabs(Dictionary<DetailWindows, DetailWindowController> prefabs, bool checkWindowsPrefabExistance = false);
		DetailWindowController ShowWindow(DetailWindows windowToOpen, bool deactivateLastWindow = true, GameObject parentObject = null);
		bool HideWindow(DetailWindows windowToHide);
		bool HideAllOpenWindows(bool callHideMethods = true);
		void DestroyWindow(DetailWindows windowToDestroy);
		int GetOpenWindowAmount(bool ignorePopups = false);
		DetailWindowController GetHighestWindow();
		T GetWindow<T>(DetailWindows window)
			where T : DetailWindowController;
		T GetOpenWindow<T>(DetailWindows window)
			where T : DetailWindowController;
		DetailWindows GetDetailWindowType(System.Type windowType, string prefabName = null);
	}
