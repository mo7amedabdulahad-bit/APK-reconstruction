// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovingTroopEdge : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private MovingTroop _node;
		[ObservableValue]
		private string _cursor;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public MovingTroop node { get => default; set {} }
		[ObservableValue]
		public string cursor { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			MovingTroopConnectionOnlyTimeEdges = 1
		}
	
		// Constructors
		public MovingTroopEdge() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MovingTroopEdgeDTO dtoValue) => default;
		private bool EqualToDTOMovingTroopConnectionOnlyTimeEdges(MovingTroopEdgeDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MovingTroopEdgeDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOMovingTroopConnectionOnlyTimeEdges(MovingTroopEdgeDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
