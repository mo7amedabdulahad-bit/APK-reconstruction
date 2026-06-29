// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Language : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private string _flag;
		[ObservableValue]
		private string _langNative;
		[ObservableValue]
		private string _langEnglish;
		[ObservableValue]
		private string _countryNative;
		[ObservableValue]
		private string _countryEnglish;
		[ObservableValue]
		private string _direction;
		[ObservableValue]
		private CountryFlagEnum _countryFlagEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public string flag { get => default; set {} }
		[ObservableValue]
		public string langNative { get => default; set {} }
		[ObservableValue]
		public string langEnglish { get => default; set {} }
		[ObservableValue]
		public string countryNative { get => default; set {} }
		[ObservableValue]
		public string countryEnglish { get => default; set {} }
		[ObservableValue]
		public string direction { get => default; set {} }
		[ObservableValue]
		public CountryFlagEnum countryFlagEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Language() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(LanguageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(LanguageDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
