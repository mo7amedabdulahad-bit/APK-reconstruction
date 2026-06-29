// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAttribute : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _code;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private float _value;
		[ObservableValue]
		private int _usedPoints;
		[ObservableValue]
		private int _maxPoints;
		[ObservableValue]
		private int _valueOfItems;
		[ObservableValue]
		private int _valueBonus;
		[ObservableValue]
		private string _title;
		[ObservableValue]
		private GraphQLObservableList<int> _pointWorth;
		[ObservableValue]
		private float _usedPointsPercent;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string code { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public float value { get => default; set {} }
		[ObservableValue]
		public int usedPoints { get => default; set {} }
		[ObservableValue]
		public int maxPoints { get => default; set {} }
		[ObservableValue]
		public int valueOfItems { get => default; set {} }
		[ObservableValue]
		public int valueBonus { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> pointWorth { get => default; set {} }
		[ObservableValue]
		public float usedPointsPercent { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public HeroAttribute() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroAttributeDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroAttributeDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListPointWorth(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _pointWorthNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
