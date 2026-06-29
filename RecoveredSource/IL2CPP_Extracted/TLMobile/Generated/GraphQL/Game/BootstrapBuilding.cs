// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootstrapBuilding : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private GraphQLObservableList<int> _validTribes;
		[ObservableValue]
		private GraphQLObservableList<int> _validVillageTypes;
		[ObservableValue]
		private int _maxPerVillage;
		[ObservableValue]
		private int _maxLevel;
		[ObservableValue]
		private GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> _requiredBuildings;
		[ObservableValue]
		private int _category;
		[ObservableValue]
		private int _sortIndex;
		[ObservableValue]
		private int _baseBuildingTime;
		[ObservableValue]
		private float _buildingTimeFactor;
		[ObservableValue]
		private int _additionalBuildingTime;
		[ObservableValue]
		private GraphQLObservableList<BootstrapBuildingLevel> _levels;
		[ObservableValue]
		private GraphQLObservableList<BuildingRestriction> _restrictions;
		[ObservableValue]
		private BootstrapBuildingExtension _extension;
		[ObservableValue]
		private Category _categoryEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> validTribes { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> validVillageTypes { get => default; set {} }
		[ObservableValue]
		public int maxPerVillage { get => default; set {} }
		[ObservableValue]
		public int maxLevel { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> requiredBuildings { get => default; set {} }
		[ObservableValue]
		public int category { get => default; set {} }
		[ObservableValue]
		public int sortIndex { get => default; set {} }
		[ObservableValue]
		public int baseBuildingTime { get => default; set {} }
		[ObservableValue]
		public float buildingTimeFactor { get => default; set {} }
		[ObservableValue]
		public int additionalBuildingTime { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<BootstrapBuildingLevel> levels { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<BuildingRestriction> restrictions { get => default; set {} }
		[ObservableValue]
		public BootstrapBuildingExtension extension { get => default; set {} }
		[ObservableValue]
		public Category categoryEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Category
		{
			Infrastructure = 1,
			Military = 2,
			Resources = 3
		}
	
		// Constructors
		public BootstrapBuilding() {}
		public BootstrapBuilding(BootstrapBuilding original) {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BootstrapBuildingDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BootstrapBuildingDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListValidTribes(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		private bool CopyValuesFromDtoListValidVillageTypes(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		private bool CopyValuesFromDtoListRequiredBuildings(GraphQLObservableList<GraphQLObservableList<RequiredBuilding>> to, List<List<RequiredBuildingDTO>> from, int query) => default;
		private bool CopyValuesFromDtoListRequiredBuildings(GraphQLObservableList<RequiredBuilding> to, List<RequiredBuildingDTO> from, int query) => default;
		private bool CopyValuesFromDtoListLevels(GraphQLObservableList<BootstrapBuildingLevel> to, List<BootstrapBuildingLevelDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRestrictions(GraphQLObservableList<BuildingRestriction> to, List<BuildingRestriction?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _validTribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _validVillageTypesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _requiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _levelsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _restrictionsNotify(object sender, PropertyChangedEventArgs args) {}
		public sealed override void AfterServerDataCallback() {}
	}
