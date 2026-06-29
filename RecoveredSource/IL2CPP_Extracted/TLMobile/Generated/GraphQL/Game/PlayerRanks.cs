// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerRanks : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _populationRank;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private int _attackerRank;
		[ObservableValue]
		private int _attackerPoints;
		[ObservableValue]
		private int _defenderRank;
		[ObservableValue]
		private int _defenderPoints;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int populationRank { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public int attackerRank { get => default; set {} }
		[ObservableValue]
		public int attackerPoints { get => default; set {} }
		[ObservableValue]
		public int defenderRank { get => default; set {} }
		[ObservableValue]
		public int defenderPoints { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyPopulation = 1
		}
	
		// Constructors
		public PlayerRanks() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PlayerRanksDTO dtoValue) => default;
		private bool EqualToDTOOnlyPopulation(PlayerRanksDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PlayerRanksDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyPopulation(PlayerRanksDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
