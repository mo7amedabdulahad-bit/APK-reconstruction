// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AppLifecycleService : MonoBehaviour, IAppLifecycleService
	{
		// Properties
		public static AppLifecycleService Instance { get; private set; }
		public bool IsPaused { get; private set; }
		public bool IsFocused { get; private set; }
		public bool IsQuitting { get; private set; }
	
		// Events
		public event Action<bool> FocusChanged;
		public event Action<bool> PauseChanged;
		public event System.Action ApplicationQuit;
	
		// Constructors
		public AppLifecycleService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnApplicationFocus(bool hasFocus) {}
		private void OnApplicationPause(bool isPaused) {}
		private void OnApplicationQuit() {}
		private void OnDestroy() {}
		private void DoOnApplicationQuit() {}
	}
