// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RequiredBuilding : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _buildingTypeId;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private bool _isLastInList;
		[ObservableValue]
		private Building.TypeId _buildingTypeIdEnum;
		[ObservableValue]
		private int _absoluteBuildingTypeId;
		[ObservableValue]
		private bool _requiredBuildingAvailable;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int buildingTypeId { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public bool isLastInList { get => default; set {} }
		[ObservableValue]
		public Building.TypeId buildingTypeIdEnum { get => default; set {} }
		[ObservableValue]
		public int absoluteBuildingTypeId { get => default; set {} }
		[ObservableValue]
		public bool requiredBuildingAvailable { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public RequiredBuilding() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RequiredBuildingDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RequiredBuildingDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
