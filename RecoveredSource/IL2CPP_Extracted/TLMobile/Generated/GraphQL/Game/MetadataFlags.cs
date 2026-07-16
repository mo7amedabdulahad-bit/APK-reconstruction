// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MetadataFlags : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private bool _registrationClosed;
		[ObservableValue]
		private bool _registrationKeyRequired;
		[ObservableValue]
		private bool _showInApp;
		[ObservableValue]
		private bool _lobby;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool registrationClosed { get => default; set {} }
		[ObservableValue]
		public bool registrationKeyRequired { get => default; set {} }
		[ObservableValue]
		public bool showInApp { get => default; set {} }
		[ObservableValue]
		public bool lobby { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public MetadataFlags() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MetadataFlagsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MetadataFlagsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
