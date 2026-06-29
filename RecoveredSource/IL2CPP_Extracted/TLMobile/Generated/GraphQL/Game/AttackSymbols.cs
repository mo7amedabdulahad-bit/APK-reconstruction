// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AttackSymbols : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _gray;
		[ObservableValue]
		private int _green;
		[ObservableValue]
		private int _yellow;
		[ObservableValue]
		private int _red;
		[ObservableValue]
		private bool _hasAnyNoneGreenSymbols;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int gray { get => default; set {} }
		[ObservableValue]
		public int green { get => default; set {} }
		[ObservableValue]
		public int yellow { get => default; set {} }
		[ObservableValue]
		public int red { get => default; set {} }
		[ObservableValue]
		public bool hasAnyNoneGreenSymbols { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AttackSymbols() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AttackSymbolsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AttackSymbolsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
