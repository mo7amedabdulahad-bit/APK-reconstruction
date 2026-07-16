// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapPlayerData : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _cellId;
		[ObservableValue]
		private int? _markId;
		[ObservableValue]
		private GraphQLObservableList<int> _flags;
		[ObservableValue]
		private GraphQLObservableList<string> _movementTypes;
		[ObservableValue]
		private int? _settlingMovement;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int cellId { get => default; set {} }
		[ObservableValue]
		public int? markId { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> flags { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> movementTypes { get => default; set {} }
		[ObservableValue]
		public int? settlingMovement { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public MapPlayerData() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MapPlayerDataDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MapPlayerDataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListFlags(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		private bool CopyValuesFromDtoListMovementTypes(GraphQLObservableList<string> to, List<string> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _flagsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _movementTypesNotify(object sender, PropertyChangedEventArgs args) {}
	}
