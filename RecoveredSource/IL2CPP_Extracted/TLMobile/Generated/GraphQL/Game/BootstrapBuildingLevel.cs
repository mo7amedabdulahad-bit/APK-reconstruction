// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BootstrapBuildingLevel : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private ResourcesAmount _buildingCost;
		[ObservableValue]
		private int _cropUsage;
		[ObservableValue]
		private float _producedCulture;
		[ObservableValue]
		private int _producedPopulation;
		[ObservableValue]
		private float? _effectValue;
		[ObservableValue]
		private ResourceAmounts _buildCostObject;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount buildingCost { get => default; set {} }
		[ObservableValue]
		public int cropUsage { get => default; set {} }
		[ObservableValue]
		public float producedCulture { get => default; set {} }
		[ObservableValue]
		public int producedPopulation { get => default; set {} }
		[ObservableValue]
		public float? effectValue { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts buildCostObject { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public BootstrapBuildingLevel() {}
		public BootstrapBuildingLevel(BootstrapBuildingLevel bootstrapBuildingLevel) {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BootstrapBuildingLevelDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BootstrapBuildingLevelDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public sealed override void AfterServerDataCallback(object data = null) {}
	}
