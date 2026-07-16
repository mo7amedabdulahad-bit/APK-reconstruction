// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.ServerList
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LoginFlowController : ViewModel
	{
		// Fields
		public const string SavedServersPlayerPrefKey = "savedServers";
		[ObservableValue]
		private string _currentVersion;
		[ObservableValue]
		private bool _errorGettingServerList;
		[ObservableValue]
		private LoginState _loginState;
		[ObservableValue]
		private ServerDomain _selectedRegion;
	
		// Properties
		[ObservableValue]
		public string currentVersion { get => default; set {} }
		[ObservableValue]
		public bool errorGettingServerList { get => default; set {} }
		[ObservableValue]
		public LoginState loginState { get => default; set {} }
		[ObservableValue]
		public ServerDomain selectedRegion { get => default; set {} }
	
		// Nested types
		public enum LoginState
		{
			Loading = 0,
			DevLogin = 1,
			RegionSelection = 2,
			ServerSelection = 3,
			LoginScreen = 4,
			MyServersScreen = 5,
			LoggingIn = 6,
			LoggedIn = 7,
			BuildExpired = 8,
			CAMS = 9
		}
	
		// Constructors
		public LoginFlowController() {}
	
		// Methods
		protected override void Awake() {}
		private void Start() {}
		private static void ResumeWithLoginFlow() {}
		private static void TryTriggerDeeplink() {}
		private static bool TryResumeRecognizedDeeplink() => default;
		private static bool TryResumeWithUnRecognizedDeeplink(System.Action onClose = null) => default;
		public void RestartLoginFlow() {}
		public void Init() {}
		private static string GetCurrentVersion() => default;
		private static void ShowDataConsentPopup(System.Action callback = null) {}
		[UICallable]
		public void ToggleCurrentVersionNumber() {}
	}
