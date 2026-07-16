// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class IdentityOptions : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _locale;
		[ObservableValue]
		private bool _newsletter;
		[ObservableValue]
		private bool _mobileOptimizations;
		[ObservableValue]
		private bool _askForMobileOptimizations;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string locale { get => default; set {} }
		[ObservableValue]
		public bool newsletter { get => default; set {} }
		[ObservableValue]
		public bool mobileOptimizations { get => default; set {} }
		[ObservableValue]
		public bool askForMobileOptimizations { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public IdentityOptions() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(IdentityOptionsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(IdentityOptionsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
