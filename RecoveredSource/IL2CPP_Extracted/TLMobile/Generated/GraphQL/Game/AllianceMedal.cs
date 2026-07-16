// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceMedal : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _categoryId;
		[ObservableValue]
		private string _categoryName;
		[ObservableValue]
		private int _rank;
		[ObservableValue]
		private int _week;
		[ObservableValue]
		private int _time;
		[ObservableValue]
		private int _points;
		[ObservableValue]
		private int _spriteIndex;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string categoryId { get => default; set {} }
		[ObservableValue]
		public string categoryName { get => default; set {} }
		[ObservableValue]
		public int rank { get => default; set {} }
		[ObservableValue]
		public int week { get => default; set {} }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public int points { get => default; set {} }
		[ObservableValue]
		public int spriteIndex { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceMedal() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceMedalDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceMedalDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
