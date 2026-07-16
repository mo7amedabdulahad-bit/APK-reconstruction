// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Tribe : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> _units;
		[ObservableValue]
		private int _merchantSpeed;
		[ObservableValue]
		private int _merchantBaseCarryCapacity;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Unit _trap;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> _ships;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> units { get => default; set {} }
		[ObservableValue]
		public int merchantSpeed { get => default; set {} }
		[ObservableValue]
		public int merchantBaseCarryCapacity { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Unit trap { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> ships { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyId = 1
		}
	
		// Constructors
		public Tribe() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TribeDTO dtoValue) => default;
		private bool EqualToDTOOnlyId(TribeDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TribeDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyId(TribeDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListUnits(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> to, List<UnitDTO> from, int query) => default;
		private bool CopyValuesFromDtoListShips(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Unit> to, List<UnitDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _unitsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _shipsNotify(object sender, PropertyChangedEventArgs args) {}
	}
