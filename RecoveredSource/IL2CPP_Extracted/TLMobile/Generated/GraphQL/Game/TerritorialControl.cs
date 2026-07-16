// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TerritorialControl : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int? _rank;
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private int? _population;
		[ObservableValue]
		private int? _villages;
		[ObservableValue]
		private float? _control;
		[ObservableValue]
		private float _controlPercentage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? rank { get => default; set {} }
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public int? population { get => default; set {} }
		[ObservableValue]
		public int? villages { get => default; set {} }
		[ObservableValue]
		public float? control { get => default; set {} }
		[ObservableValue]
		public float controlPercentage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TerritorialControl() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TerritorialControlDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TerritorialControlDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
