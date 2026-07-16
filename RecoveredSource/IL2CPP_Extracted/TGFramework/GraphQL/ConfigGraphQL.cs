// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfigGraphQL : TGFramework.Config
	{
		// Fields
		[SerializeField]
		private string backendRestApiRoute;
		[SerializeField]
		private string backendAuthRoute;
		[SerializeField]
		private string serverListUrl;
		[SerializeField]
		private int webRequestsTimeout;
		[SerializeField]
		private int connectionTimeout;
		[SerializeField]
		private int poorConnectionRetryAttempts;
		public bool XVersionEnabled;
		public string BackendReleaseVersion;
		public string BackendVersionApiUrl;
		public bool UseProxy;
		public string ProxyUri;
		[Header("Lobby")]
		[SerializeField]
		private string lobbyServerUrl;
		[SerializeField]
		private string appClientId;
		[SerializeField]
		private string appClientIdDebug;
		[SerializeField]
		private string accountLobbyUrl;
		[SerializeField]
		private string accountLobbyLobbyDebug;
		[SerializeField]
		private string accountBackendApiRoute;
		[SerializeField]
		private string identityLobbyUrl;
		[SerializeField]
		private string identityLobbyLobbyDebug;
		[SerializeField]
		private int challengeVerifierLength;
		[SerializeField]
		private string originHeader;
		private string deviceId;
	
		// Properties
		public string BackendRestApiRoute { get => default; }
		protected static new string hprotocol { get => default; }
		public string ServerListUrl { get => default; }
		public string BackendRestApiUrl { get => default; }
		public string BackendAuthUrl { get => default; }
		public int WebRequestsTimeout { get => default; set {} }
		public int ConnectionTimeout { get => default; set {} }
		public int PoorConnectionRetryAttempts { get => default; set {} }
		public string LobbyServerUrl { get => default; }
		public string AppClientId { get => default; }
		public string AppClientIdDebug { get => default; }
		public string AccountBackendApiRoute { get => default; }
		public static string AccountBackendApiUrl { get => default; }
		public static string AccountBackendApiUrlDebug { get => default; }
		public string AccountLobbyUrl { get => default; }
		public string AccountLobbyUrlDebug { get => default; }
		public string IdentityLobbyUrl { get => default; }
		public string IdentityLobbyUrlDebug { get => default; }
		public int ChallengeVerifierLength { get => default; }
		public string OriginHeader { get => default; }
		public string DeviceId { get => default; set {} }
	
		// Constructors
		public ConfigGraphQL() {}
	}
