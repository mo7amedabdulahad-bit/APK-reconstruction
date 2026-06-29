// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IAuthorizationService : IService
	{
		// Properties
		LobbyConfigGraphQL LobbyConfigGraphQL { get; set; }
		IIdentityApi IdentityApi { get; }
		ILobbyApi LobbyApi { get; }
		IAuthenticationApi AuthenticationApi { get; }
		bool IsLoggedIntoLobby { get; }
		bool IsLoggedIntoGameworld { get; }
		string CurrentServer { get; }
		string CurrentServerUuid { get; }
		Avatar CurrentAvatar { get; }
		string CurrentCookieGameworld { get; }
		string CurrentCookieLobby { get; }
		string CurrentCookieHeaderValues { get; }
		IDictionary<string, string> CurrentHeaderValues { get; }
		bool HasAutoLoginFailed { get; set; }
	
		// Events
		event System.Action OnGameworldLogout;
	
		// Methods
		IPromise Login(string serverRestApiUrl, string username, string password);
		IPromise<AuthorisationSuccess> AvatarLogin(string uuid);
		IPromise<AuthorisationSuccess> AvatarActivationLogin(string code);
		IPromise<ApiResponse<LogoutResponseBody>> LogoutGameworld();
		IPromise<ApiResponse<object>> LogoutIdentity();
		IPromise<AuthorisationSuccess> GetAuthorisationTokens(string serverRestApiUrl, string username, string password);
		Promise<AuthorisationSuccess> GetAuthorisationTokenForSocialActivation(string identityApiUrl, string accountApiUrl, string code, string verifier, RestAPI.Lobby.Model.Attestation attestation);
		IPromise<RestAPI.Lobby.Model.Attestation> GetDeviceVerificationToken(string serverChallenge);
		IPromise<AuthorisationSuccess> GetAuthorisationTokenGoogle(string identityApiUrl, string accountApiUrl, string credential, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation);
		IPromise<AuthorisationSuccess> GetAuthorisationTokenFacebook(string identityApiUrl, string accountApiUrl, string accessToken, string authenticationToken, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation);
		IPromise<AuthorisationSuccess> GetAuthorisationTokenApple(string identityApiUrl, string accountApiUrl, string credentials, string verifier, string challenge, RestAPI.Lobby.Model.Attestation attestation);
		void SetTokensCams(string cookieJwt);
		void RegisterForCookieRefresh();
		void UpdateCurrentAvatar(Avatar newAvatar);
		IPromise<AuthorisationSuccess> GetAuthorisationTokenCams(string identityApiUrl, string accountApiUrl, string username, string password);
		IPromise AuthSwitch(SwitchRequestBody switchRequestBody);
		void SetNewBaseUrlToGameworld(string url = "");
		void ResetSavedLobbyLoginTokens();
		void UnAssignCookies();
		void UpdateGameworldCookie(string newCookie);
	}
