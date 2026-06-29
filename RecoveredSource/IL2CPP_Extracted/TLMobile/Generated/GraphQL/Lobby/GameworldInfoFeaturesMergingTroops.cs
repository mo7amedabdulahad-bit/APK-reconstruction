// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldInfoFeaturesMergingTroops : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private bool _enabled;
		[ObservableValue]
		private int? _goldLimit;
		[ObservableValue]
		private int? _minimumCost;
		[ObservableValue]
		private int? _costDivider;
		[ObservableValue]
		private int? _costMultiplier;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool enabled { get => default; set {} }
		[ObservableValue]
		public int? goldLimit { get => default; set {} }
		[ObservableValue]
		public int? minimumCost { get => default; set {} }
		[ObservableValue]
		public int? costDivider { get => default; set {} }
		[ObservableValue]
		public int? costMultiplier { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public GameworldInfoFeaturesMergingTroops() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GameworldInfoFeaturesMergingTroopsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GameworldInfoFeaturesMergingTroopsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
