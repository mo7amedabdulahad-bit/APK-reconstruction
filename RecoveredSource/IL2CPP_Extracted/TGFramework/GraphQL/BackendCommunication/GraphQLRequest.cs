// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL.BackendCommunication
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLRequest
	{
		// Fields
		public const string RequestedObjectPrefix = "requestedObject_";
		private static ulong requestCounter;
		private Action<GraphQLRequest> requestFinishedCallback;
	
		// Properties
		public static IDictionary<string, string> HeaderValues { get; private set; }
		private string GraphQLUrl { get; set; }
		public GraphQLServerIdentifier ServerIdentifier { get; private set; }
		public HTTPRequest HttpRequest { get; }
		public HTTPResponse HttpResponse { get; private set; }
		public Dictionary<string, CacheService.ObjectRequestInfo> RequestedAliases { get; }
		public bool IsValid { get; private set; }
	
		// Constructors
		public GraphQLRequest() {} // Dummy constructor
		public GraphQLRequest(List<CacheService.ObjectRequestInfo> requestInfos, int timeout, string graphQLUrl, GraphQLServerIdentifier identifier) {}
	
		// Methods
		public static void UpdateHeader(IDictionary<string, string> headerValue) {}
		public void Dispose() {}
		private HTTPRequest CreateWebRequest(StringBuilder queryBody, int timeout) => default;
		private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response) {}
		public void Send(Action<GraphQLRequest> callback) {}
		private void InitGraphQlRequest(CacheService.ObjectRequestInfo requestInfo, int queryType, StringBuilder queryBody) {}
		private static StringBuilder InitializeQueryBody() => default;
		private static void CloseQueryBody(StringBuilder queryBody) {}
		private void PopulateTheType(StringBuilder queryBuilder, IGraphQLFetchable fetchable, int queryType) {}
		private void SetRequestHeaders(HTTPRequest request) {}
	}
