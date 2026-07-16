// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceDiplomacy : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceDiplomacyRelation> _existingRelations;
		[ObservableValue]
		private GraphQLObservableList<Alliance> _unionMembers;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceDiplomacyRelation> existingRelations { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Alliance> unionMembers { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceDiplomacy() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceDiplomacyDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceDiplomacyDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListExistingRelations(GraphQLObservableList<OwnAllianceDiplomacyRelation> to, List<OwnAllianceDiplomacyRelationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListUnionMembers(GraphQLObservableList<Alliance> to, List<AllianceDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _existingRelationsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _unionMembersNotify(object sender, PropertyChangedEventArgs args) {}
	}
