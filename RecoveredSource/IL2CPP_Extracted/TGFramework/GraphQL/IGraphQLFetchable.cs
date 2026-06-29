// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IGraphQLFetchable
	{
		// Properties
		GraphQLServerIdentifier ServerIdentifier { get; }
		int NestedDepth { get; }
		ServerObject.ServerObjectInfos ObjectInfos { get; }
		GraphQLObjectInfos GraphQlObjectInfos { get; }
	
		// Methods
		string[] GetNamesInNestedResponse();
		string GetServerId();
		string GetGraphQLBody(int queryType);
		void Update(int queryType);
	}
