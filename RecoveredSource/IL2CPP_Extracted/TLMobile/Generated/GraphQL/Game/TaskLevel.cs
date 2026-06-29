// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TaskLevel : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _title;
		[ObservableValue]
		private TaskMetadata _metadata;
		[ObservableValue]
		private bool _wasCollected;
		[ObservableValue]
		private bool _readyToBeCollected;
		[ObservableValue]
		private int _levelValue;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private TaskReward _rewardValues;
		[ObservableValue]
		private bool _wasTakenOver;
		[ObservableValue]
		private string _questId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public TaskMetadata metadata { get => default; set {} }
		[ObservableValue]
		public bool wasCollected { get => default; set {} }
		[ObservableValue]
		public bool readyToBeCollected { get => default; set {} }
		[ObservableValue]
		public int levelValue { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public TaskReward rewardValues { get => default; set {} }
		[ObservableValue]
		public bool wasTakenOver { get => default; set {} }
		[ObservableValue]
		public string questId { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TaskLevel() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TaskLevelDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TaskLevelDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
