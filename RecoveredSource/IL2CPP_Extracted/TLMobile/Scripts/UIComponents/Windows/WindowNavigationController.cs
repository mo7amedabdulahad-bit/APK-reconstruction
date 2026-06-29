// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WindowNavigationController
	{
		// Fields
		private readonly List<DetailWindowController> navigationStack;
		private bool haveWindowsOpen;
	
		// Properties
		public List<DetailWindowController> GetNavigationStack { get => default; }
	
		// Constructors
		public WindowNavigationController() {}
	
		// Methods
		public virtual void Show(DetailWindowController window, bool deactivateLastWindow = false) {}
		public virtual void Back(GameObject currentlyOpenWindow) {}
		public DetailWindowController Peek() => default;
		private void Push(DetailWindowController controller) {}
		private DetailWindowController Pop() => default;
		private void RemoveIfExists(DetailWindowController controller) {}
		public int GetOpenWindowAmount(bool ignorePopups = false) => default;
	}
