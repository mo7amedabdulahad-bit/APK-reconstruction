// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyUnion : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private GraphQLObservableList<Alliance> _members;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> _inviteProposals;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> _kickOutProposals;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Alliance> members { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> inviteProposals { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> kickOutProposals { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnAllianceDiplomacyUnion() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceDiplomacyUnionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceDiplomacyUnionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMembers(GraphQLObservableList<Alliance> to, List<AllianceDTO> from, int query) => default;
		private bool CopyValuesFromDtoListInviteProposals(GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> to, List<OwnAllianceDiplomacyUnionProposalDTO> from, int query) => default;
		private bool CopyValuesFromDtoListKickOutProposals(GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> to, List<OwnAllianceDiplomacyUnionProposalDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _membersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _inviteProposalsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _kickOutProposalsNotify(object sender, PropertyChangedEventArgs args) {}
	}
