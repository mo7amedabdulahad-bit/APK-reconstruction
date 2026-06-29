// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceInvitation : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _invitee;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _invitedBy;
		[ObservableValue]
		private int _id;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player invitee { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player invitedBy { get => default; set {} }
		[ObservableValue]
		public int id { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceInvitation() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceInvitationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceInvitationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
