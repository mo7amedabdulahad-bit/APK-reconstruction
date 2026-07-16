// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RegionalTop5 : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _regionId;
		[ObservableValue]
		private string _regionName;
		[ObservableValue]
		private string _ancientPower;
		[ObservableValue]
		private int _victoryPoints;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private float _control;
		[ObservableValue]
		private float _controlPercentage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int regionId { get => default; set {} }
		[ObservableValue]
		public string regionName { get => default; set {} }
		[ObservableValue]
		public string ancientPower { get => default; set {} }
		[ObservableValue]
		public int victoryPoints { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public float control { get => default; set {} }
		[ObservableValue]
		public float controlPercentage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public RegionalTop5() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RegionalTop5DTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RegionalTop5DTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
