// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VideoFeatureService : MonoBehaviour, IVideoFeatureService
	{
		// Fields
		private static bool isAdRequestInProgress;
	
		// Properties
		public static bool IsRunningAd { get => default; }
	
		// Constructors
		public VideoFeatureService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void WatchAd(string adSalesVrid, Action<string> onSuccess, System.Action onFail = null, bool useNewAPI = true) {}
		private static void WatchAdAndTriggerCallback_OldAPI(string adSalesVrid, Action<string> onSuccess, System.Action onFail = null) {}
		private static void WatchAdAndTriggerCallback_NewAPI(string adSalesVrid, Action<string> onSuccess, System.Action onFail = null) {}
		private static void OnVideoFeatureStart(IRestApiService restApiService, string adSalesVrid, Action<string> onSuccess, System.Action onFail) {}
		private static void OnAdWatchedSuccessfully(string adSalesVrid, Action<string> onSuccess, System.Action onFail, bool isFallbackAd = false) {}
		private static void OnAdWatchedFailed(AdMobService.AdMobError errorCode, string adSalesVrid, Action<string> onSuccess, System.Action onFail) {}
	}
