// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RemovablePlayer : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int? _id;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private Tribe _tribe;
		[ObservableValue]
		private int? _allianceId;
		[ObservableValue]
		private string _allianceTag;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private string _inlineableName;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? id { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public Tribe tribe { get => default; set {} }
		[ObservableValue]
		public int? allianceId { get => default; set {} }
		[ObservableValue]
		public string allianceTag { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public string inlineableName { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Stub = 1
		}
	
		// Constructors
		public RemovablePlayer() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RemovablePlayerDTO dtoValue) => default;
		private bool EqualToDTOStub(RemovablePlayerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RemovablePlayerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(RemovablePlayerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public string GetInlineableName() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
