// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL.BackendCommunication
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLServerError
	{
		// Fields
		public string message;
		public string[] path;
		public bool receivedEmptyResponse;
	
		// Nested types
		[Serializable]
		public class GraphQLErrorResponse
		{
			// Fields
			public GraphQLServerError[] errors;
	
			// Constructors
			public GraphQLErrorResponse() {}
		}
	
		// Constructors
		public GraphQLServerError() {}
	}
