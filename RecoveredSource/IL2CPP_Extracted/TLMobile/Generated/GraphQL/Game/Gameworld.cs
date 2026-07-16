// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Gameworld : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _domain;
		[ObservableValue]
		private int _start;
		[ObservableValue]
		private MetadataFields _metadata;
		[ObservableValue]
		private MetadataFlags _flags;
		[ObservableValue]
		private List<ServerDomain> _serverDomains;
		[ObservableValue]
		private bool _isGoldShopDisabled;
		[ObservableValue]
		private bool _isTestEnvironment;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string domain { get => default; set {} }
		[ObservableValue]
		public int start { get => default; set {} }
		[ObservableValue]
		public MetadataFields metadata { get => default; set {} }
		[ObservableValue]
		public MetadataFlags flags { get => default; set {} }
		[ObservableValue]
		public List<ServerDomain> serverDomains { get => default; set {} }
		[ObservableValue]
		public bool isGoldShopDisabled { get => default; set {} }
		[ObservableValue]
		public bool isTestEnvironment { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Gameworld() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TLMobile.GraphQL.DTO.Game.GameworldDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TLMobile.GraphQL.DTO.Game.GameworldDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		private void UpdateServerDomains() {}
		private List<ServerDomain> GetRegionDomains(List<string> regions) => default;
	}
