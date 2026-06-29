// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Unit : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _idString;
		[ObservableValue]
		private int _baseTrainingDuration;
		[ObservableValue]
		private int _attackPower;
		[ObservableValue]
		private int _defencePowerAgainstInfantry;
		[ObservableValue]
		private int _defencePowerAgainstCavalry;
		[ObservableValue]
		private int _velocity;
		[ObservableValue]
		private int _carry;
		[ObservableValue]
		private int _upkeepCost;
		[ObservableValue]
		private GraphQLObservableList<int> _trainedAt;
		[ObservableValue]
		private GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> _requiredBuildings;
		[ObservableValue]
		private ResourcesAmount _researchingCost;
		[ObservableValue]
		private int _researchDuration;
		[ObservableValue]
		private ResourcesAmount _trainingCost;
		[ObservableValue]
		private ResourcesAmount _upgradingCost;
		[ObservableValue]
		private GraphQLObservableList<ExtraProperty> _extraProperties;
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _researchTimeBoosted;
		[ObservableValue]
		private int _researchTimeBoostPercentage;
		[ObservableValue]
		private ResourceAmounts _trainCostObject;
		[ObservableValue]
		private ResourceAmounts _researchCostObject;
		[ObservableValue]
		private ResourceAmounts _upgradeCostObject;
		[ObservableValue]
		private ObservableList<Building.TypeId> _trainedAtEnums;
		[ObservableValue]
		private ObservableDictionary<ExtraPropertyName, string> _extraPropertyByEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string idString { get => default; set {} }
		[ObservableValue]
		public int baseTrainingDuration { get => default; set {} }
		[ObservableValue]
		public int attackPower { get => default; set {} }
		[ObservableValue]
		public int defencePowerAgainstInfantry { get => default; set {} }
		[ObservableValue]
		public int defencePowerAgainstCavalry { get => default; set {} }
		[ObservableValue]
		public int velocity { get => default; set {} }
		[ObservableValue]
		public int carry { get => default; set {} }
		[ObservableValue]
		public int upkeepCost { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> trainedAt { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> requiredBuildings { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount researchingCost { get => default; set {} }
		[ObservableValue]
		public int researchDuration { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount trainingCost { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount upgradingCost { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ExtraProperty> extraProperties { get => default; set {} }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int researchTimeBoosted { get => default; set {} }
		[ObservableValue]
		public int researchTimeBoostPercentage { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts trainCostObject { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts researchCostObject { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts upgradeCostObject { get => default; set {} }
		[ObservableValue]
		public ObservableList<Building.TypeId> trainedAtEnums { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<ExtraPropertyName, string> extraPropertyByEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			TrainingBatchAllUnit = 1
		}
	
		// Constructors
		public Unit() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(UnitDTO dtoValue) => default;
		private bool EqualToDTOTrainingBatchAllUnit(UnitDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(UnitDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOTrainingBatchAllUnit(UnitDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTrainedAt(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		private bool CopyValuesFromDtoListRequiredBuildings(GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> to, List<List<RequiredBuildingDTO>> from, int query) => default;
		private bool CopyValuesFromDtoListRequiredBuildings(GraphQLObservableList<RequiredBuilding> to, List<RequiredBuildingDTO> from, int query) => default;
		private bool CopyValuesFromDtoListExtraProperties(GraphQLObservableList<ExtraProperty> to, List<ExtraPropertyDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _trainedAtNotify(object sender, PropertyChangedEventArgs args) {}
		private void _requiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _extraPropertiesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _trainedAtEnumsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _extraPropertyByEnumNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
		public bool CanBeHealed() => default;
		public static int IdStringToId(string idString) => default;
		public static bool TryParseIdStringToId(string idString, out int id) {
			id = default;
			return default;
		}
	}
