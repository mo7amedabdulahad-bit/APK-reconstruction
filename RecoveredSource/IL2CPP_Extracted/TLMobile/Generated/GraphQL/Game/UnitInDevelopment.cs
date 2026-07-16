// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitInDevelopment : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _eventId;
		[ObservableValue]
		private string _unitId;
		[ObservableValue]
		private int _finishedAt;
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _upgradeToLevel;
		[ObservableValue]
		private TroopInfo _troopInfo;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int eventId { get => default; set {} }
		[ObservableValue]
		public string unitId { get => default; set {} }
		[ObservableValue]
		public int finishedAt { get => default; set {} }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int upgradeToLevel { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public UnitInDevelopment() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(UnitInDevelopmentDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(UnitInDevelopmentDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
