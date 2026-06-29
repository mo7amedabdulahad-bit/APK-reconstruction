// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TLMConfigService : MonoBehaviour, ITLMConfigService
	{
		// Fields
		private const string EnvironmentIDProduction = "9998f8c3-10d7-441c-8716-cff025dc0c81";
		private const string EnvironmentIDDevelop = "04318c6f-0be2-4444-94d1-444ccb5300e8";
		private readonly Dictionary<string, string> localConfigMap;
	
		// Properties
		private string Environment { get => default; }
		public static TLMConfigService Instance { get; private set; }
		public bool IsFetchingRemoteConfig { get; private set; }
		public bool FetchRemoteCompleted { get; private set; }
		public Action<ConfigResponse> OnFetchRemoteCompleted { get; set; }
		public ConfigResponse LastFetchedConfigResponse { get; private set; }
		public static bool IsInstanceNull { get => default; }
	
		// Constructors
		public TLMConfigService() {}
	
		// Methods
		public string GetLocalConfigValue(string key) => default;
		private async System.Threading.Tasks.Task FetchRemoteConfigWithTimeout(System.Action onSuccess, System.Action onFail, int timeoutSeconds = 30, int? checkAvailabilityInterval = default) => default;
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		private async System.Threading.Tasks.Task Init() => default;
		private async System.Threading.Tasks.Task InitializeRemoteConfigAsync() => default;
		private void OnRemoteFetched(ConfigResponse configResponse) {}
		private void LoadLocalConfigs() {}
		private bool FetchConfig() => default;
		private void OnInternetConnectionChanged(bool isConnected) {}
		private async System.Threading.Tasks.Task OnInternetConnectionChangedAsync(bool isConnected) => default;
	}
