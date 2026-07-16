// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuthorizationService : MonoBehaviour, IAuthorizationService
	{
		// Fields
		public const string LastLobbyCookiePlayerPrefKey = "lastLobbyCookie";
		public static readonly string AuthCookieNameGameworld;
		public static readonly string AuthCookieNameLobby;
		private IDeviceFunctionsService deviceFunctionsService;
		private IRestApiService restApiService;
		private string screenWidthHeight;
	
		// Properties
		private string ScreenWidthHeight { get => default; }
		public LobbyConfigGraphQL LobbyConfigGraphQL { get; set; }
		public IAuthenticationApi AuthenticationApi { get => default; }
		public IIdentityApi IdentityApi { get => default; }
		public ILobbyApi LobbyApi { get => default; }
		public bool IsLoggedIntoLobby { get; private set; }
		public bool IsLoggedIntoGameworld { get => default; }
		public string CurrentServer { get => default; }
		public string CurrentServerUuid { get; private set; }
		public Avatar CurrentAvatar { get; private set; }
		public string CurrentCookieGameworld { get; private set; }
		public string CurrentCookieLobby { get; private set; }
		public string CurrentCookieHeaderValues { get => default; }
		public IDictionary<string, string> CurrentHeaderValues { get; private set; }
		public bool HasAutoLoginFailed { get; set; }
	
		// Events
		public event System.Action OnGameworldLogout;
	
		// Constructors
		public AuthorizationService() {}
		static AuthorizationService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		private void PreSetup() {}
		private IPromise PostSetup() => default;
		public IPromise BootInstance(params object[] args) => default;
		private void SetupGraphQL() {}
		private void SetupHeaders() {}
		private void Setup() {}
		private LobbyConfigGraphQL CreateLobbyConfigGraphQL(bool useDevServers) => default;
		public IPromise Login(string restApiUrl, string username, string password) => default;
		public IPromise<AuthorisationSuccess> AvatarLogin(string uuid) => default;
		public IPromise<AuthorisationSuccess> AvatarActivationLogin(string code) => default;
		private IPromise<AuthorisationSuccess> AvatarAuth(string code) => default;
		public void RegisterForCookieRefresh() {}
		public void UpdateCurrentAvatar(Avatar newAvatar) {}
		public IPromise AuthSwitch(SwitchRequestBody switchRequestBody) => default;
		public IPromise<ApiResponse<LogoutResponseBody>> LogoutGameworld() => default;
		public IPromise<ApiResponse<object>> LogoutIdentity() => default;
		[Obsolete("Old Login method directly onto the gameworld, use AvatarLogin instead!")]
		public IPromise<AuthorisationSuccess> GetAuthorisationTokens(string restApiUrl, string username, string password) => default;
		private void SetTokens(string cookieJwt) {}
		public void SetTokensCams(string cookieJwt) {}
		public void SetNewBaseUrlToGameworld(string url = "") {}
		public void ResetSavedLobbyLoginTokens() {}
		public void UnAssignCookies() {}
		private AuthRequestBody GetAuthRequestBody(string token) => default;
		private void UpdateCookieCallback(string cookiesString) {}
		public void UpdateGameworldCookie(string newCookie) {}
		private void UpdateLobbyCookie(string newCookie) {}
		private void UpdateApiHeaders() {}
		public static string ExtractCookie(string cookieString, string identifier) => default;
		public IPromise<AuthorisationSuccess> GetAuthorisationTokenCams(string identityApiUrl, string accountApiUrl, string username, string password) => default;
		public Promise<AuthorisationSuccess> GetAuthorisationTokenThroughActivation(string identityApiUrl, string accountApiUrl, string code) => default;
		public IPromise<AuthorisationSuccess> GetAuthorisationTokenGoogle(string identityApiUrl, string accountApiUrl, string credential, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation) => default;
		public IPromise<AuthorisationSuccess> GetAuthorisationTokenFacebook(string identityApiUrl, string accountApiUrl, string accessToken, string authenticationToken, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation) => default;
		public IPromise<AuthorisationSuccess> GetAuthorisationTokenApple(string identityApiUrl, string accountApiUrl, string credential, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation) => default;
		private void HandleSocialLoginProviderResponse(IPromise<ApiResponse<RestAPI.Lobby.Model.StandardSuccess>> promise, Promise<AuthorisationSuccess> resultPromise, string verifier) {}
		public IPromise<RestAPI.Lobby.Model.Attestation> GetDeviceVerificationToken(string serverChallenge = null) => default;
		public Promise<AuthorisationSuccess> GetAuthorisationTokenForSocialActivation(string identityApiUrl, string accountApiUrl, string code, string verifier, RestAPI.Lobby.Model.Attestation attestation) => default;
	}
