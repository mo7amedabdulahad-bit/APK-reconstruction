// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class GraphQLServerObject : ServerObject
	{
		// Properties
		public GraphQLObjectInfos GraphQlObjectInfos { get; }
		public virtual GraphQLServerIdentifier ServerIdentifier { get; }
	
		// Constructors
		protected GraphQLServerObject() {}
	
		// Methods
		public abstract void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> result);
		public abstract bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false);
		public abstract bool EqualToDTO(object dtoValue, int query = 0);
		public abstract string GetGraphQLBody(int queryType);
		public abstract GraphQLServerObject GetNewObject(object dtoObject, int query);
		public abstract System.Type GetDtoType();
		public abstract object GetDTOObject(object dTOObject);
	}
