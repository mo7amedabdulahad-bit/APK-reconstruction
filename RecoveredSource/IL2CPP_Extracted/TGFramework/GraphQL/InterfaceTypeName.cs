// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InterfaceTypeName : GraphQLFetchable
	{
		// Fields
		private GraphQLServerIdentifier _serverIdentifier;
		private string[] namesInNestedResponse;
		private string serverId;
		private string typeName;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
	
		// Nested types
		[Serializable]
		public class InterfaceTypeNameDTO
		{
			// Fields
			public string __typename;
	
			// Constructors
			public InterfaceTypeNameDTO() {}
	
			// Methods
			[OnError]
			internal void OnError(StreamingContext context, ErrorContext errorContext) {}
		}
	
		// Constructors
		public InterfaceTypeName() {}
	
		// Methods
		public override string[] GetNamesInNestedResponse() => default;
		public override string GetServerId() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public override string GetGraphQLBody(int queryType) => default;
		public static IPromise<string> GetTypeName(string serverId, int nestedDepth, string[] nestedNames, GraphQLServerIdentifier identifier) => default;
		protected IPromise<string> FetchInterfaceTypeName(int nestedDepth, string[] nestedNames) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> result) {}
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override System.Type GetDtoType() => default;
		public override object GetDTOObject(object dTOObject) => default;
		public override void Update(int queryType = 0) {}
	}
