// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProductionOverviewBalance : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _totalProductionPerHour;
		[ObservableValue]
		private int _totalProductionPerHourBonus;
		[ObservableValue]
		private int _cropConsumptionsOfBuildingsInQueue;
		[ObservableValue]
		private int _heroProduction;
		[ObservableValue]
		private int _productionBoost;
		[ObservableValue]
		private int _productionBoostFactor;
		[ObservableValue]
		private bool _playerHasBoost;
		[ObservableValue]
		private OwnTroopsConsumption _ownTroopsConsumption;
		[ObservableValue]
		private ForeignTroopsConsumption _foreignTroopsConsumption;
		[ObservableValue]
		private int? _compensationBoostFactor;
		[ObservableValue]
		private int _compensationBoostValue;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int totalProductionPerHour { get => default; set {} }
		[ObservableValue]
		public int totalProductionPerHourBonus { get => default; set {} }
		[ObservableValue]
		public int cropConsumptionsOfBuildingsInQueue { get => default; set {} }
		[ObservableValue]
		public int heroProduction { get => default; set {} }
		[ObservableValue]
		public int productionBoost { get => default; set {} }
		[ObservableValue]
		public int productionBoostFactor { get => default; set {} }
		[ObservableValue]
		public bool playerHasBoost { get => default; set {} }
		[ObservableValue]
		public OwnTroopsConsumption ownTroopsConsumption { get => default; set {} }
		[ObservableValue]
		public ForeignTroopsConsumption foreignTroopsConsumption { get => default; set {} }
		[ObservableValue]
		public int? compensationBoostFactor { get => default; set {} }
		[ObservableValue]
		public int compensationBoostValue { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ProductionOverviewBalance() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ProductionOverviewBalanceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ProductionOverviewBalanceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
