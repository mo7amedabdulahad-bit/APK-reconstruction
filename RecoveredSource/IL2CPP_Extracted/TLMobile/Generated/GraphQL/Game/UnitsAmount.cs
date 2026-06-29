// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitsAmount : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int? _t1;
		[ObservableValue]
		private int? _t2;
		[ObservableValue]
		private int? _t3;
		[ObservableValue]
		private int? _t4;
		[ObservableValue]
		private int? _t5;
		[ObservableValue]
		private int? _t6;
		[ObservableValue]
		private int? _t7;
		[ObservableValue]
		private int? _t8;
		[ObservableValue]
		private int? _t9;
		[ObservableValue]
		private int? _t10;
		[ObservableValue]
		private int? _t11;
		[ObservableValue]
		private long _totalAmount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? t1 { get => default; set {} }
		[ObservableValue]
		public int? t2 { get => default; set {} }
		[ObservableValue]
		public int? t3 { get => default; set {} }
		[ObservableValue]
		public int? t4 { get => default; set {} }
		[ObservableValue]
		public int? t5 { get => default; set {} }
		[ObservableValue]
		public int? t6 { get => default; set {} }
		[ObservableValue]
		public int? t7 { get => default; set {} }
		[ObservableValue]
		public int? t8 { get => default; set {} }
		[ObservableValue]
		public int? t9 { get => default; set {} }
		[ObservableValue]
		public int? t10 { get => default; set {} }
		[ObservableValue]
		public int? t11 { get => default; set {} }
		[ObservableValue]
		public long totalAmount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public UnitsAmount() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(UnitsAmountDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(UnitsAmountDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
