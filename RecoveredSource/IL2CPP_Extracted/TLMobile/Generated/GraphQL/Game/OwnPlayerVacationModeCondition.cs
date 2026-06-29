// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnPlayerVacationModeCondition : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private bool _isMet;
		[ObservableValue]
		private ConditionId _conditionIdEnum;
		[ObservableValue]
		private string _translatedName;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public bool isMet { get => default; set {} }
		[ObservableValue]
		public ConditionId conditionIdEnum { get => default; set {} }
		[ObservableValue]
		public string translatedName { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ConditionId
		{
			none = 0,
			has_outgoing_troops = 1,
			has_incoming_troops = 2,
			has_reinforcing_troops_for = 3,
			has_reinforcing_troops_from = 4,
			has_conquered_oase = 5,
			has_ww_village = 6,
			has_artifact_village = 7,
			has_beginners_protection = 8,
			has_trapped_troops = 9,
			has_deletion_event = 10
		}
	
		// Constructors
		public OwnPlayerVacationModeCondition() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnPlayerVacationModeConditionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnPlayerVacationModeConditionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		private void SetTranslatedName() {}
	}
