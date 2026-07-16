// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildEvent : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _buildingTypeId;
		[ObservableValue]
		private int _slotId;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _aspiredLevel;
		[ObservableValue]
		private int _timestamp;
		[ObservableValue]
		private int _status;
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private int _buildingSpriteIndex;
		[ObservableValue]
		private BuildEventType _typeEnum;
		[ObservableValue]
		private Building.TypeId _buildingTypeIdEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int buildingTypeId { get => default; set {} }
		[ObservableValue]
		public int slotId { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int aspiredLevel { get => default; set {} }
		[ObservableValue]
		public int timestamp { get => default; set {} }
		[ObservableValue]
		public int status { get => default; set {} }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public int buildingSpriteIndex { get => default; set {} }
		[ObservableValue]
		public BuildEventType typeEnum { get => default; set {} }
		[ObservableValue]
		public Building.TypeId buildingTypeIdEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum BuildEventType
		{
			BuildTask = 1,
			Demolition = 2,
			MasterBuilderTask = 38
		}
	
		// Constructors
		public BuildEvent() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BuildEventDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BuildEventDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
