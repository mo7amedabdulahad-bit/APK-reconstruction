// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Stable : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<TrainingBatch> _trainingUnits;
		[ObservableValue]
		private float _trainingBonus;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<TrainingBatch> trainingUnits { get => default; set {} }
		[ObservableValue]
		public float trainingBonus { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Stable() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(StableDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(StableDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTrainingUnits(GraphQLObservableList<TrainingBatch> to, List<TrainingBatchDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _trainingUnitsNotify(object sender, PropertyChangedEventArgs args) {}
	}
