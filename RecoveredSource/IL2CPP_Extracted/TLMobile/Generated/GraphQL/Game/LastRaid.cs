// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LastRaid : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _reportObjectId;
		[ObservableValue]
		private string _authKey;
		[ObservableValue]
		private int _time;
		[ObservableValue]
		private ResourcesAmount _raidedResources;
		[ObservableValue]
		private int _bootyMax;
		[ObservableValue]
		private int _icon;
		[ObservableValue]
		private ResourceAmounts _usedCapacityAmount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string reportObjectId { get => default; set {} }
		[ObservableValue]
		public string authKey { get => default; set {} }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount raidedResources { get => default; set {} }
		[ObservableValue]
		public int bootyMax { get => default; set {} }
		[ObservableValue]
		public int icon { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts usedCapacityAmount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public LastRaid() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(LastRaidDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(LastRaidDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
