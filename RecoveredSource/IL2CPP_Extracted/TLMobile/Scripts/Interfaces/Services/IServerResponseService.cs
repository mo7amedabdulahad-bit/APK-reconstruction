// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IServerResponseService : IService
	{
		// Methods
		void RegisterCallbackForError(FailureType failureType, System.Action callback);
		void ResendFailedRequests(FailureType failureType);
		bool HasFailedRequests(FailureType failureType);
		void HandleGraphQLResponse(GraphQLRequest response, Action<GraphQLRequest> parseResponse);
		void HandleRestAPIResponse(HTTPRequest request, HTTPResponse response, Action<HTTPRequest, HTTPResponse> parseResponse);
		void ClearRequestsWithURL(string url);
	}
