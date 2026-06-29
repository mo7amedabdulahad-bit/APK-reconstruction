// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnPlayerVacationMode : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int? _starts;
		[ObservableValue]
		private int? _ends;
		[ObservableValue]
		private int _availableDays;
		[ObservableValue]
		private GraphQLObservableList<OwnPlayerVacationModeCondition> _conditions;
		[ObservableValue]
		private bool _isInVacationMode;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? starts { get => default; set {} }
		[ObservableValue]
		public int? ends { get => default; set {} }
		[ObservableValue]
		public int availableDays { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnPlayerVacationModeCondition> conditions { get => default; set {} }
		[ObservableValue]
		public bool isInVacationMode { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnPlayerVacationMode() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnPlayerVacationModeDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnPlayerVacationModeDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListConditions(GraphQLObservableList<OwnPlayerVacationModeCondition> to, List<OwnPlayerVacationModeConditionDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _conditionsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
