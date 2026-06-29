// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Tests.SharedUtilities.StubModels
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLFetchableStub : GraphQLFetchable
	{
		// Properties
		public Mock<GraphQLFetchable> Mock { get; }
	
		// Constructors
		public GraphQLFetchableStub() {}
		public GraphQLFetchableStub(string serverId) {}
	
		// Methods
		public static GraphQLFetchableStub GetNoFetchThroughCacheService(string serverId) => default;
		public override string[] GetNamesInNestedResponse() => default;
		public override void Update(int val = 0) {}
		public override GraphQLServerObject GetNewObject(object dto, int query) => default;
		public override System.Type GetDtoType() => default;
		public override object GetDTOObject(object dTOObject) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> result) {}
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query) => default;
		public override string GetGraphQLBody(int queryType) => default;
	}
