// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonusesOverview : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private OwnAllianceBonus _recruitment;
		[ObservableValue]
		private OwnAllianceBonus _philosophy;
		[ObservableValue]
		private OwnAllianceBonus _metallurgy;
		[ObservableValue]
		private OwnAllianceBonus _commerce;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public OwnAllianceBonus recruitment { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonus philosophy { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonus metallurgy { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonus commerce { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnAllianceBonusesOverview() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceBonusesOverviewDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceBonusesOverviewDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
