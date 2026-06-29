// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConnectivityService : MonoBehaviour, IConnectivityService
	{
		// Fields
		private const float CheckInterval = 5f;
		private const bool AllowCarrierDataNetwork = true;
		[SerializeField]
		private bool debugNoInternetConnection;
		private bool lastInternetConnectionState;
	
		// Properties
		public bool HasInternetConnection { get; private set; }
		public Action<bool> OnInternetConnectionChanged { get; set; }
	
		// Constructors
		public ConnectivityService() {}
	
		// Methods
		private void CheckInternetConnection() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public async System.Threading.Tasks.Task WaitForOrTimeout(Func<bool> condition, System.Action onSuccess, System.Action onFail, int timeoutSeconds = 10, int? checkAvailabilityInterval = default) => default;
	}
