// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL.BackendCommunication
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class GraphQLErrorHandler
	{
		// Fields
		private static readonly Dictionary<IGraphQLFetchable, Dictionary<int, List<Action<GraphQLServerError>>>> errorSubscribers;
		private static readonly List<List<Action<GraphQLServerError>>> subscribersListPool;
	
		// Constructors
		static GraphQLErrorHandler() {}
	
		// Methods
		public static void HandleNext(int queryType, IGraphQLFetchable serverObject, Action<GraphQLServerError> callback) {}
		public static void HandleNextIfNotFilled(int queryType, IGraphQLFetchable serverObject, Action<GraphQLServerError> callback) {}
		public static bool RemoveErrorHandle(int queryType, IGraphQLFetchable serverObject, Action<GraphQLServerError> callback) => default;
		public static void NotifyAboutError(int queryType, IGraphQLFetchable serverObject, GraphQLServerError serverError) {}
		public static void NotifyAboutSuccess(int queryType, IGraphQLFetchable serverObject) {}
		public static GraphQLServerError GetErrorForGraphQlFetchable(IGraphQLFetchable graphql, string alias, GraphQLServerError[] errors) => default;
		private static string[] GetResponseFullPath(IGraphQLFetchable graphql, string alias) => default;
		private static List<Action<GraphQLServerError>> GetEmptySubscribersList() => default;
		private static void PutToPool(List<Action<GraphQLServerError>> list) {}
	}
