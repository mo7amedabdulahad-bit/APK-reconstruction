// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CulturePointsDistributionSoFar : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _buildings;
		[ObservableValue]
		private int _items;
		[ObservableValue]
		private int _celebrations;
		[ObservableValue]
		private int _rewards;
		[ObservableValue]
		private int _allianceBonus;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int buildings { get => default; set {} }
		[ObservableValue]
		public int items { get => default; set {} }
		[ObservableValue]
		public int celebrations { get => default; set {} }
		[ObservableValue]
		public int rewards { get => default; set {} }
		[ObservableValue]
		public int allianceBonus { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CulturePointsDistributionSoFar() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CulturePointsDistributionSoFarDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CulturePointsDistributionSoFarDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
