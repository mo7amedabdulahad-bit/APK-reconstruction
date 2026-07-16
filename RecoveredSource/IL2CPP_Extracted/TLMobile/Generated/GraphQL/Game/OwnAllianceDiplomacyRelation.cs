// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyRelation : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private Alliance _from;
		[ObservableValue]
		private Alliance _to;
		[ObservableValue]
		private string _status;
		[ObservableValue]
		private Alliance _otherAlliance;
		[ObservableValue]
		private Type _typeEnum;
		[ObservableValue]
		private Status _statusEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public Alliance from { get => default; set {} }
		[ObservableValue]
		public Alliance to { get => default; set {} }
		[ObservableValue]
		public string status { get => default; set {} }
		[ObservableValue]
		public Alliance otherAlliance { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
		[ObservableValue]
		public Status statusEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Status
		{
			NotAccepted = 0,
			Active = 1,
			InDeletion = 2
		}
	
		public enum Type
		{
			None = 0,
			Confederacy = 1,
			NAP = 2,
			War = 3,
			Union = 4
		}
	
		// Constructors
		public OwnAllianceDiplomacyRelation() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceDiplomacyRelationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceDiplomacyRelationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
