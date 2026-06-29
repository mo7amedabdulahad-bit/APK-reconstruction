// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacy : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyRelation> _ownOffers;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyRelation> _incomingOffers;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyRelation> _existingRelations;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> _invitationsToUnion;
		[ObservableValue]
		private OwnAllianceDiplomacyUnion _union;
		[ObservableValue]
		private int _existingNapAmount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyRelation> ownOffers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyRelation> incomingOffers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyRelation> existingRelations { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> invitationsToUnion { get => default; set {} }
		[ObservableValue]
		public OwnAllianceDiplomacyUnion union { get => default; set {} }
		[ObservableValue]
		public int existingNapAmount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnAllianceDiplomacy() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceDiplomacyDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceDiplomacyDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListOwnOffers(GraphQLObservableList<OwnAllianceDiplomacyRelation> to, List<OwnAllianceDiplomacyRelationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListIncomingOffers(GraphQLObservableList<OwnAllianceDiplomacyRelation> to, List<OwnAllianceDiplomacyRelationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListExistingRelations(GraphQLObservableList<OwnAllianceDiplomacyRelation> to, List<OwnAllianceDiplomacyRelationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListInvitationsToUnion(GraphQLObservableList<OwnAllianceDiplomacyUnionProposal> to, List<OwnAllianceDiplomacyUnionProposalDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _ownOffersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _incomingOffersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _existingRelationsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _invitationsToUnionNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
