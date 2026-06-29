// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnityServiceProvider : MonoBehaviour, IBootable
	{
		// Fields
		[SerializeField]
		private bool cacheServicesAtStartup;
		[SerializeField]
		private DetailWindowsContainerInitializer[] detailWindowsContainerInitializers;
		[Header("Init")]
		[SerializeField]
		private int framesToWaitBetweenServiceInit;
		private readonly Dictionary<System.Type, IService> cachedServices;
		private static bool isShuttingDown;
	
		// Properties
		public static UnityServiceProvider Instance { get; private set; }
	
		// Constructors
		public UnityServiceProvider() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void InitDetailWindowContainer() {}
		private void CacheAvailableServices() {}
		private void InitProvider(bool cacheAvailableServices = true) {}
		public static T Get<T>()
			where T : IService => default;
		private T GetService<T>()
			where T : IService => default;
		private bool GetCachedService<T>(out System.Type serviceType, out ref T cachedService)
			where T : IService {
			serviceType = default;
			cachedService = default;
			return default;
		}
		private static void LogRestApiCall(HTTPRequest request) {}
		private void OnApplicationQuit() {}
		private void OnDestroy() {}
		private void ShutDown() {}
		public static void CleanUp() {}
		private IPromise SetupTravianLogger() => default;
		private IPromise SetupFirebaseCrashlytics() => default;
		private IPromise SetupAppsFlyer() => default;
		private IPromise SetupFirebaseAnalytics() => default;
		private IPromise SetupMessagingService() => default;
		public static IPromise SetupApiClient() => default;
		public static IPromise SetupGraphQL() => default;
		public static IPromise SetupHttpManager() => default;
	}
