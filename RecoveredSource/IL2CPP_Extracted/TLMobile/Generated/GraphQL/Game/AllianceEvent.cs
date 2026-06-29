// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEvent : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private int _time;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private RemovablePlayer _player1;
		[ObservableValue]
		private RemovablePlayer _player2;
		[ObservableValue]
		private Alliance _alliance1;
		[ObservableValue]
		private Alliance _alliance2;
		[ObservableValue]
		private int? _x;
		[ObservableValue]
		private int? _y;
		[ObservableValue]
		private int? _statPlace;
		[ObservableValue]
		private int? _statType;
		[ObservableValue]
		private string _artifactName;
		[ObservableValue]
		private AllianceEventType _typeEnum;
		[ObservableValue]
		private TopStatisticsType? _statTypeEnum;
		[ObservableValue]
		private string _inlineableText;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer player1 { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer player2 { get => default; set {} }
		[ObservableValue]
		public Alliance alliance1 { get => default; set {} }
		[ObservableValue]
		public Alliance alliance2 { get => default; set {} }
		[ObservableValue]
		public int? x { get => default; set {} }
		[ObservableValue]
		public int? y { get => default; set {} }
		[ObservableValue]
		public int? statPlace { get => default; set {} }
		[ObservableValue]
		public int? statType { get => default; set {} }
		[ObservableValue]
		public string artifactName { get => default; set {} }
		[ObservableValue]
		public AllianceEventType typeEnum { get => default; set {} }
		[ObservableValue]
		public TopStatisticsType? statTypeEnum { get => default; set {} }
		[ObservableValue]
		public string inlineableText { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceEvent() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceEventDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceEventDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		private string GenerateStringWithInlineReplacements() => default;
	}
