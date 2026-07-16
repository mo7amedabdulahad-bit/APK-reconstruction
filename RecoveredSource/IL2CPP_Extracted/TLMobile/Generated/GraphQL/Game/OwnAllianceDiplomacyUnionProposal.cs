// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyUnionProposal : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _type;
		[ObservableValue]
		private string _unionId;
		[ObservableValue]
		private Alliance _initiator;
		[ObservableValue]
		private Alliance _subject;
		[ObservableValue]
		private GraphQLObservableList<Alliance> _approvedBy;
		[ObservableValue]
		private Type _typeEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string type { get => default; set {} }
		[ObservableValue]
		public string unionId { get => default; set {} }
		[ObservableValue]
		public Alliance initiator { get => default; set {} }
		[ObservableValue]
		public Alliance subject { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Alliance> approvedBy { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Type
		{
			None = 0,
			Kick = 1,
			Invite = 2
		}
	
		// Constructors
		public OwnAllianceDiplomacyUnionProposal() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceDiplomacyUnionProposalDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceDiplomacyUnionProposalDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListApprovedBy(GraphQLObservableList<Alliance> to, List<AllianceDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _approvedByNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
