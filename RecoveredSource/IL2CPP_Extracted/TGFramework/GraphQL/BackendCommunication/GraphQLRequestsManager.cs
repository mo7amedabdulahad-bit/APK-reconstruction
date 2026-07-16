// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL.BackendCommunication
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class GraphQLRequestsManager
	{
		// Fields
		private static Dictionary<GraphQLServerIdentifier, string> serverUrlsByIdentifier;
		private static Dictionary<GraphQLServerIdentifier, bool> serverStateByIdentifier;
		private const int RequestLimit = 3;
	
		// Properties
		public static bool HooksRegistered { get; private set; }
		public static int RequestTimeout { get; set; }
		public static Action<GraphQLRequest, Action<GraphQLRequest>> GraphQLResponseHandler { get; set; }
		public static Action<string> CookieRefreshCallback { get; set; }
	
		// Events
		public static event Action<GraphQLRequest> RequestSent;
		public static event Action<GraphQLRequest> RequestFinished;
	
		// Constructors
		static GraphQLRequestsManager() {}
	
		// Methods
		public static void RegisterHooks() {}
		public static void ChangeIdentifierUrl(GraphQLServerIdentifier identifier, string url) {}
		public static string GetIdentifierUrl(GraphQLServerIdentifier identifier) => default;
		public static void ChangeIdentifierState(GraphQLServerIdentifier identifier, bool allowedToSend) {}
		public static void RequestObjectsFromServer(List<CacheService.ObjectRequestInfo> objIdsToFetchFromServer) {}
		public static Dictionary<GraphQLServerIdentifier, GraphQLRequest> CreateNewGraphQLRequest(List<CacheService.ObjectRequestInfo> batchInOneQuery) => default;
		private static void ProcessSingleRequest(GraphQLRequest runningRequest) {}
		private static void ProcessResponse(GraphQLRequest runningRequest) {}
		private static void GetResponseErrors(string responsePart, out GraphQLServerError[] errors, out bool couldParseErrors) {
			errors = default;
			couldParseErrors = default;
		}
		private static void NotifyResponseGeneralError(GraphQLRequest runningRequest, GraphQLServerError[] errors) {}
		private static void FillResponseData(GraphQLRequest runningRequest, GraphQLServerError[] errors, string responsePart) {}
		public static void ProcessRequestError(GraphQLRequest request, string error) {}
		private static void UpdateCookieFromWebRequest(HTTPResponse response) {}
	}
