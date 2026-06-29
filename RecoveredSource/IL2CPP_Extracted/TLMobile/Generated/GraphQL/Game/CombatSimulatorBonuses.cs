// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorBonuses : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<float> _alliance;
		[ObservableValue]
		private GraphQLObservableList<float> _buildingMasterArtefact;
		[ObservableValue]
		private GraphQLObservableList<float> _spyArtefact;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<float> alliance { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<float> buildingMasterArtefact { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<float> spyArtefact { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CombatSimulatorBonuses() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CombatSimulatorBonusesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CombatSimulatorBonusesDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAlliance(GraphQLObservableList<float> to, List<float?> from, int query) => default;
		private bool CopyValuesFromDtoListBuildingMasterArtefact(GraphQLObservableList<float> to, List<float?> from, int query) => default;
		private bool CopyValuesFromDtoListSpyArtefact(GraphQLObservableList<float> to, List<float?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _allianceNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingMasterArtefactNotify(object sender, PropertyChangedEventArgs args) {}
		private void _spyArtefactNotify(object sender, PropertyChangedEventArgs args) {}
	}
