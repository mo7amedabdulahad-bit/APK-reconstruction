// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootController : ViewModel, IBootable
	{
		// Fields
		[SerializeField]
		private float bootFailTimeOut;
		[ObservableValue]
		private bool _hasInternetConnection;
		[ObservableValue]
		private bool _hasRemoteConfig;
		private Coroutine bootCoroutine;
		private FastLoginController fastLoginController;
	
		// Properties
		[ObservableValue]
		public bool hasInternetConnection { get => default; set {} }
		[ObservableValue]
		public bool hasRemoteConfig { get => default; set {} }
	
		// Constructors
		public BootController() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		protected override void OnDestroy() {}
		[IteratorStateMachine(typeof(_BootCoroutine_d__14))]
		private IEnumerator BootCoroutine() => default;
		private void OnInternetConnectionChanged(bool hasInternetConnection) {}
		private void OnFetchRemoteCompleted(ConfigResponse configResponse) {}
		private bool HasValidAppVersion() => default;
		private bool TryResumeLoginFlow(bool ignoreRemoteConfig = false) => default;
		private void ResumeLoginFlow() {}
	}
