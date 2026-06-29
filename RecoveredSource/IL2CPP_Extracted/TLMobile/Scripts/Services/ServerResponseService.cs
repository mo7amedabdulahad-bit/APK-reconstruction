// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerResponseService : MonoBehaviour, IServerResponseService
	{
		// Fields
		private readonly Dictionary<FailureType, Dictionary<GraphQLRequest, System.Action>> GraphQLFailedRequests;
		private readonly Dictionary<GraphQLRequest, int> GraphQLRequestRetryCount;
		private readonly Dictionary<FailureType, List<System.Action>> registeredCallbacks;
		private readonly Dictionary<FailureType, bool> RequestsExpired;
		private readonly Dictionary<FailureType, Dictionary<RestApiRequest, System.Action>> RestApiFailedRequests;
		private readonly Dictionary<RestApiRequest, int> RestApiRequestRetryCount;
		private IAuthorizationService authService;
		private int maximumRetryCountRestApi;
		private int maxRetryCount;
		private bool refreshInProgressGame;
		private bool refreshInProgressLobby;
		private const int WarningThresholdKilobytes = 10;
	
		// Nested types
		public class RestApiRequest
		{
			// Fields
			public byte[] body;
			public HTTPRequest Request;
			public HTTPResponse Response;
	
			// Constructors
			public RestApiRequest() {}
			public RestApiRequest(HTTPRequest request, HTTPResponse response) {}
		}
	
		// Constructors
		public ServerResponseService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnApplicationFocus(bool hasFocus) {}
		private void InitService(int maximumAttempts = 5, int maximumRestApiAttempts = 0) {}
		public void RegisterCallbackForError(FailureType failureType, System.Action callback) {}
		public void ResendFailedRequests(FailureType failureType) {}
		public bool HasFailedRequests(FailureType failureType) => default;
		public void HandleGraphQLResponse(GraphQLRequest response, Action<GraphQLRequest> parseResponse) {}
		public void HandleRestAPIResponse(HTTPRequest request, HTTPResponse response, Action<HTTPRequest, HTTPResponse> parseResponse) {}
		public void ClearRequestsWithURL(string url) {}
		private void CheckForFailedNetworkRequests() {}
		public void HandleRestAPIResponse(HTTPRequest request, HTTPResponse response, Action<HTTPRequest, HTTPResponse> parseResponse, RestApiRequest lastRestApiRequest) {}
		private void RefreshLobby() {}
		[ContextMenu("Refresh Game")]
		private void RefreshGame() {}
		private void CallErrorCallbacks(FailureType failureType) {}
		private void ClearExpiredRequests(FailureType failureType) {}
		private void HandleUnsupportedVersion() {}
		private bool StoreRequest<T>(int maxRetryCount, Dictionary<FailureType, Dictionary<T, System.Action>> requestsCollection, Dictionary<T, int> retries, FailureType failureType, T request, Action<T> onRetryFinished = null) => default;
		private void AddRequestToCollection<T>(Dictionary<FailureType, Dictionary<T, System.Action>> requestsCollection, FailureType failureType, T request, Action<T> onRetryFinished) {}
		private void SendRequest<T>(T request, Action<T> onRetryFinished) {}
		private void SendRequest(RestApiRequest request, Action<RestApiRequest> onRetryFinished) {}
		private static void CopyHeaderValue(string headerKey, RestApiRequest request, HTTPRequest newRequest) {}
		private void SendRequest(GraphQLRequest request) {}
		private static Dictionary<string, CacheService.ObjectRequestInfo> CopyOutstandingQueryTypes(GraphQLRequest request) => default;
		private void LogGraphQLRequest(HTTPRequest request) {}
		private void LogGraphQLResponse(Dictionary<string, CacheService.ObjectRequestInfo> responseRequestedAliases, HTTPResponse response) {}
		private void LogRestAPIRequest(HTTPRequest request, HTTPResponse response) {}
		public static string PrintHTTPRequest(HTTPRequest request) => default;
		public static string PrintHTTPResponse(HTTPResponse response) => default;
		public static string PrintHTTPResponse(Dictionary<string, CacheService.ObjectRequestInfo> responseRequestedAliases, HTTPResponse response) => default;
		private void OnApplicationQuit() {}
		private void OnDestroy() {}
		private void DoOnShutdown() {}
	}
